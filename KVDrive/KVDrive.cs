using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Text;
//using System.Threading;
using System.Threading.Tasks;
using System.Timers;

namespace KVDrive
{
    public class KeyencePlcDrive : IPLCDrive
    {
        public KeyencePlcDrive(short id,string name,string ip,int port)
        {
            _id = id;
            _name = name;
            _ip = ip;
            _port = port;

        }
        //public static AutoResetEvent event_1 = new AutoResetEvent(true);
        private short _id;
        private string _name;
        private string _ip;
        private int _port;
        private Socket socketSyc;
        private int _timeout;
        private IEnumerable<IGroup> _grps;
        private Timer time1 = new Timer();

        public short ID
        {
            get { return _id; }
        }

        public string Name
        {
            get
            {
                return _name;
            }
        }


        public string ServerName
        {
            get { return _ip; }
            set { _ip = value; }
        }
        public int Port
        {
            get { return _port; }
            set { _port = value; }
        }

        public bool IsClosed
        {
            get { return socketSyc == null || socketSyc.Connected == false; }
        }

        public int TimeOut
        {
            get { return _timeout; }
            set { _timeout = value; }
        }

        public IEnumerable<IGroup> Groups
        {
            get { return _grps; }
            set { _grps = value; }
        }

        public void Dispose()
        {
            throw new NotImplementedException();
        }

       
        public void init()
        {
            _timeout = 10000;
            if (!Connect())
            {
                return;
            }
            time1.Enabled = true;
            time1.AutoReset = false;
            time1.Interval = 1000;
            time1.Elapsed += Time1_Elapsed;
            time1.Start();
       }

        private void Time1_Elapsed(object sender, ElapsedEventArgs e)
        {
            time1.Stop();
            foreach (IGroup grp in _grps)
            {

                if (grp != null&&grp.IsActive )
                {
                    Refresh(grp);
                }
            }
            time1.Start();
        }

        private void Refresh(IGroup grp)
        {
            foreach(ITag tag in grp.Items)
            {
                tag.Update();
                tag.UpdatePLC();
            }
        }

        public bool Connect()
        {
            try
            {
                if (socketSyc != null)
                    socketSyc.Close();
                //IPAddress ip = IPAddress.Parse(_ip);
                // ----------------------------------------------------------------
                // Connect synchronous client
                if (_timeout <= 0) _timeout = 1000;
                socketSyc = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
                socketSyc.SendTimeout = _timeout;
                socketSyc.ReceiveTimeout = _timeout;
                socketSyc.NoDelay = true;
                socketSyc.Connect(_ip, _port);
                return true;
            }
            catch (SocketException error)
            {
                return false;
            }
        }
        public byte[] SyncSend(byte[] sendBuf)
        {
            if (sendBuf.Length < 1) return null;
            if (IsClosed) return null;
            try
            {
                int sendLen = socketSyc.Send(sendBuf);
                if (sendLen < 1)
                {
                    return null;
                }
                byte[] data = new byte[1024];
                int receiveLen = socketSyc.Receive(data);
                byte[] buf = new byte[receiveLen];
                Array.Copy(data, 0, buf, 0, receiveLen);
                return buf;
            }
            catch
            {

            }
            return null;

        }

        #region ReadWrite
        public ItemData<bool> ReadBit(DeviceAddress address)
        {
            ItemData<byte[]> b1 = ReadBits(address, 1);
            if (b1.Value[0] == (byte)0)
            {
                return new ItemData<bool>(false, false);
            }
            return new ItemData<bool>(true, false);
        }
        public ItemData<byte[]> ReadBits(DeviceAddress address,short length)
        {
            float[] f = new float[length];

            byte[] command = MelsecHelper.BuildAsciiReadMcCoreCommand(address, true);

            byte[] read = SyncSend(MelsecHelper.PackMcCommand(command, 0, 0));

            ushort errorCode = Convert.ToUInt16(Encoding.ASCII.GetString(read, 18, 4), 16);
            if (errorCode != 0) return (new ItemData<byte[]>(null,false));

            byte[] extract = MelsecHelper.ExtractActualData(read, true);

            return new ItemData<byte[]>(extract, true);
        }
        public bool WriteBit(DeviceAddress address, bool bit)
        {
            bool[] bs = new bool[1] { bit};
            return WriteBits(address, bs);
        }
        public bool WriteBits(DeviceAddress address, bool[] bits)
        {
            byte[] command = MelsecHelper.BuildAsciiWriteBitCoreCommand(address, bits);

            byte[] read = SyncSend(MelsecHelper.PackMcCommand(command, 0, 0));

            ushort errorCode = Convert.ToUInt16(Encoding.ASCII.GetString(read, 18, 4), 16);
            if (errorCode != 0) return false;

            byte[] extract = MelsecHelper.ExtractActualData(read, true);

            return true;
        }

        public ItemData<float> ReadFloat(DeviceAddress address)
        {
            ItemData<float[]> response = ReadFloats(address, 1);
            if (response.Quality)
            {
                return new ItemData<float>(response.Value[0],true);
            }
            return new ItemData<float>(-1, false);
        }
        public ItemData<float[]> ReadFloats(DeviceAddress address, ushort length)
        {
            float[] f = new float[length];

            byte[] command = MelsecHelper.BuildAsciiReadMcCoreCommand(address, false);

            byte[] read = SyncSend(MelsecHelper.PackMcCommand(command, 0, 0));

            ushort errorCode = Convert.ToUInt16(Encoding.ASCII.GetString(read, 18, 4), 16);
            if (errorCode != 0) return (new ItemData<float[]>(null,false));

            byte[] extract = MelsecHelper.ExtractActualData(read, false);
            for (int i = 0; i < (extract.Length) / 4; i++)
            {
                f[i] = BitConverter.ToSingle(extract, i * 4);
            }
            return new ItemData<float[]>(f,true);
        }

        public bool WriteFloat(DeviceAddress address, float value)
        {
            float[] f1 = new float[1] { value };
            return WriteFloats(address, f1);
        }
        public bool WriteFloats(DeviceAddress address, float[] value)
        {

            byte[] b1 = new byte[value.Length * 4];
            for (int i = 0; i < value.Length; i++)
            {
                Array.Copy(BitConverter.GetBytes(value[i]), 0, b1, i * 4, 4);
            }
            byte[] command = MelsecHelper.BuildAsciiWriteWordCoreCommand(address, b1);

            byte[] read = SyncSend(MelsecHelper.PackMcCommand(command, 0, 0));
            ushort errorCode = Convert.ToUInt16(Encoding.ASCII.GetString(read, 18, 4), 16);
            if (errorCode != 0) return false;
            return true;
        }
        #endregion


        public IGroup AddGroup(string name, short id, int updateRate, float deadBand = 0, bool active = false)
        {
            throw new NotImplementedException();
        }

        public bool RemoveGroup(IGroup group)
        {
            throw new NotImplementedException();
        }
    }

}
