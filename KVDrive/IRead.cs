using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KVDrive
{
    public interface IReadWrite
    {
        ItemData<bool> ReadBit(DeviceAddress address);
        bool WriteBit(DeviceAddress address,bool bit);
        ItemData<float> ReadFloat(DeviceAddress address);
        bool WriteFloat(DeviceAddress address, float value);

    }
    
    public interface IDriver : IDisposable
    {
        short ID { get; }
        string Name { get; }
        string ServerName { get; set; }
        bool IsClosed { get; }
        int TimeOut { get; set; }
        IEnumerable<IGroup> Groups { get; set; }
        ////IDataServer Parent { get; }
        bool Connect();
        IGroup AddGroup(string name, short id, int updateRate, float deadBand = 0f, bool active = false);
        bool RemoveGroup(IGroup group);
        //event IOErrorEventHandler OnError;
    }
    public interface IPLCDrive : IDriver, IReadWrite
    {
        //DeviceAddress GetDeviceAddress(string address, ushort len);
        //string GetAddress(DeviceAddress address);

    }

    public interface IGroup
    {
        bool IsActive { get; set; }
        short ID { get; }
        string Name { get; }
        int UpdateRate { get; set; }
        List<ITag> Items { get; }
        //float DeadBand { get; set; }
        void AddTag(ITag tags);
        void RemoveTag(ITag tags);
    }
    public struct ItemData<T>
    {
        public T Value;
        //public long TimeStamp;
        public bool Quality;

        public ItemData(T value,bool quality)
        {
            Value = value;
            //TimeStamp = timeStamp;
            Quality = quality;
        }
        
    }





}
