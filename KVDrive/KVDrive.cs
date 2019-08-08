using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace KVDrive
{
    public class KeyencePlcDrive : IPLCDrive
    {
        private short _id;
        private string _name;
        private string _ip;
        private int _port;
        private Socket socketSyc;
        private int _timeout;

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

        public IEnumerable<IGroup> Groups => throw new NotImplementedException();

        public void Dispose()
        {
            throw new NotImplementedException();
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


        public ItemData<bool> ReadBit(DeviceAddress address)
        {
            throw new NotImplementedException();
        }
        public bool WriteBit(DeviceAddress address, bool bit)
        {
            throw new NotImplementedException();
        }

        public ItemData<float> ReadFloat(DeviceAddress address)
        {
            ItemData<float[]> response = ReadFloat(address, 1);
            if (response.Quality)
            {
                return new ItemData<float>(response.Value[0],true);
            }
            return new ItemData<float>(-1, false);
        }
        public ItemData<float[]> ReadFloat(DeviceAddress address, ushort length)
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
