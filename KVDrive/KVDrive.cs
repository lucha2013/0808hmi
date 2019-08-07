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

        public string GetAddress(DeviceAddress address)
        {
            throw new NotImplementedException();
        }

        public DeviceAddress GetDeviceAddress(string address, ushort len)
        {

            Response<DeviceAddress> response = DeviceAddress.ParseKeyenceFrom(address, len);
            return response.Value;

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


        public Response<bool> ReadBit(DeviceAddress address)
        {
            throw new NotImplementedException();
        }

        public Response<float> ReadFloat(DeviceAddress address)
        {
            Response<float[]> response = ReadFloat(address, 1);
            Response<float> response2 = new Response<float>();
            if (response.IsSuccess)
            {
                response2.IsSuccess = true;
                response2.Value = response.Value[0];
                return response2;
            }
            return Response.CreateFailResponse<float>(false, 3, "fail");
        }
        public Response<float[]> ReadFloat(DeviceAddress address, ushort length)
        {
            float[] f = new float[length];
            ushort len = (ushort)(length * 2);
            byte[] command = MelsecHelper.BuildAsciiReadMcCoreCommand(address, false);

            byte[] read = SyncSend(PackMcCommand(command, 0, 0));

            ushort errorCode = Convert.ToUInt16(Encoding.ASCII.GetString(read, 18, 4), 16);
            if (errorCode != 0) Response.CreateFailResponse<float>(false, 3, "fail");

            byte[] extract = ExtractActualData(read, false);
            for (int i = 0; i < (extract.Length) / 4; i++)
            {
                f[i] = BitConverter.ToSingle(extract, i * 4);
            }
            return Response.CreateSuccessResponse<float[]>(f);
        }

        public bool WriteFloat(DeviceAddress address, float value)
        {
            throw new NotImplementedException();
        }


        public static byte[] PackMcCommand(byte[] mcCore, byte networkNumber = 0, byte networkStationNumber = 0)
        {
            byte[] plcCommand = new byte[22 + mcCore.Length];
            plcCommand[0] = 0x35;                                                                        // 副标题
            plcCommand[1] = 0x30;
            plcCommand[2] = 0x30;
            plcCommand[3] = 0x30;
            plcCommand[4] = MelsecHelper.BuildBytesFromData(networkNumber)[0];                         // 网络号
            plcCommand[5] = MelsecHelper.BuildBytesFromData(networkNumber)[1];
            plcCommand[6] = 0x46;                                                                        // PLC编号
            plcCommand[7] = 0x46;
            plcCommand[8] = 0x30;                                                                        // 目标模块IO编号
            plcCommand[9] = 0x33;
            plcCommand[10] = 0x46;
            plcCommand[11] = 0x46;
            plcCommand[12] = MelsecHelper.BuildBytesFromData(networkStationNumber)[0];                  // 目标模块站号
            plcCommand[13] = MelsecHelper.BuildBytesFromData(networkStationNumber)[1];
            plcCommand[14] = MelsecHelper.BuildBytesFromData((ushort)(plcCommand.Length - 18))[0];     // 请求数据长度
            plcCommand[15] = MelsecHelper.BuildBytesFromData((ushort)(plcCommand.Length - 18))[1];
            plcCommand[16] = MelsecHelper.BuildBytesFromData((ushort)(plcCommand.Length - 18))[2];
            plcCommand[17] = MelsecHelper.BuildBytesFromData((ushort)(plcCommand.Length - 18))[3];
            plcCommand[18] = 0x30;                                                                        // CPU监视定时器
            plcCommand[19] = 0x30;
            plcCommand[20] = 0x31;
            plcCommand[21] = 0x30;
            mcCore.CopyTo(plcCommand, 22);

            return plcCommand;
        }
        public static byte[] ExtractActualData(byte[] response, bool isBit)
        {
            if (isBit)
            {
                // 位读取
                byte[] Content = new byte[response.Length - 22];
                for (int i = 22; i < response.Length; i++)
                {
                    Content[i - 22] = response[i] == 0x30 ? (byte)0x00 : (byte)0x01;
                }

                return (Content);
            }
            else
            {
                // 字读取
                byte[] Content = new byte[(response.Length - 22) / 2];
                for (int i = 0; i < Content.Length / 2; i++)
                {
                    ushort tmp = Convert.ToUInt16(Encoding.ASCII.GetString(response, i * 4 + 22, 4), 16);
                    BitConverter.GetBytes(tmp).CopyTo(Content, i * 2);
                }

                return (Content);
            }
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
