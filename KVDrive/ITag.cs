using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace KVDrive
{
    public abstract class ITag : IComparable<ITag>
    {
        public ITag(short id, Storage value,string address,IDriver parent)
        {
            this._id = id;
            this._value = value;
            this._address = address;
            this._drive = parent;

        }
        public ITag(short id, Storage value, string address)
        {
            this._id = id;
            this._value = value;
            this._address = address;


        }

        public ITag()
        {
        }

        //private DateTime _timeStamp;
        private short _id;

        public IDriver Parent { get { return _drive; } set { _drive = value; } }
        //public DateTime TimeStamp { get { return _timeStamp; } }
        public short ID { get { return _id; } }
        protected Storage _value;
        public Storage Value
        {
            get
            {
                return _value;
            }
        }
        public Storage Refresh()
        {
            return Read();
        }

        public string Address { get { return _address; } set { _address = value; } }

        public abstract void Update(Storage newValue);
        //public void Update(Storage newValue)
        //{
        //    if (_value.Equals(newValue)) return;
        //    if (ValueChangeEvent != null)
        //    {
        //        ValueChangeEvent(this, new ValueChangeEventArgs(newValue));
        //    }
        //}

        public string GetAddress(DeviceAddress address)
        {
            throw new NotImplementedException();
        }

        public DeviceAddress GetDeviceAddress(string address, ushort len)
        {

            ItemData<DeviceAddress> response = DeviceAddress.ParseKeyenceFrom(address, len);
            return response.Value;

        }

        public abstract Storage Read();

        public abstract bool Write(object value);
        public int CompareTo(ITag other)
        {
            if (this.Equals(other))
            {
                return 0;
            }
            else
            {
                return 1;
            }
        }
        public ValueChangeHandler ValueChangeEvent;
        private string _address;
        private IDriver _drive;
    }
    public class BoolTag : ITag
    {
        //public BoolTag() : base()
        //{

        //}
        public BoolTag(short id, Storage value, string address):base(id, value,address)
        {

        }
        public override Storage Read()
        {
            DeviceAddress address=GetDeviceAddress(Address,1);
            ItemData<bool> response = ((KeyencePlcDrive)Parent).ReadBit(address);
            if (!response.Quality)
            {
                //return null; 怎么写？
            }
            Storage value = Storage.Empty;
            value.Boolean = response.Value;
            return value;
        }
        public override void Update(Storage newValue)
        {
            if (_value.Boolean.Equals(newValue.Boolean)) return;
            if (ValueChangeEvent != null)
            {
                ValueChangeEvent(this, new ValueChangeEventArgs(newValue));
            }
        }
        public override bool Write(object value)
        {
            DeviceAddress address = GetDeviceAddress(Address, 1);
            return ((KeyencePlcDrive)Parent).WriteBit(address,(bool)value);

        }
    }
    public class FloatTag : ITag
    {
        //public BoolTag() : base()
        //{

        //}
        public FloatTag(short id, Storage value, string address) : base(id, value, address)
        {

        }
        public override Storage Read()
        {
            DeviceAddress address = GetDeviceAddress(Address, 2);
            ItemData<float> response = ((KeyencePlcDrive)Parent).ReadFloat(address);
            if (!response.Quality)
            {
                //return null; 怎么写？
            }
            Storage value = Storage.Empty;
            value.Single = response.Value;
            return value;
        }
        public override void Update(Storage newValue)
        {
            if (_value.Single.Equals(newValue.Single)) return;
            if (ValueChangeEvent != null)
            {
                ValueChangeEvent(this, new ValueChangeEventArgs(newValue));
            }
        }
        public override bool Write(object value)
        {
            DeviceAddress address = GetDeviceAddress(Address, 2);
            return ((KeyencePlcDrive)Parent).WriteFloat(address, (float)value);

        }
    }





    [StructLayout(LayoutKind.Explicit, Size = 4)]
    public struct Storage
    {
        // Fields
        [FieldOffset(0)]
        public bool Boolean;
        [FieldOffset(0)]
        public byte Byte;
        [FieldOffset(0)]
        public short Int16;
        [FieldOffset(0)]
        public int Int32;
        [FieldOffset(0)]
        public float Single;
        [FieldOffset(0)]
        public ushort Word;
        [FieldOffset(0)]
        public uint DWord;

        public static readonly Storage Empty;

        static Storage()
        {
            Empty = new Storage();
        }

        public override bool Equals(object obj)
        {
            if (obj == null) return false;
            Type type = obj.GetType();
            if (type == typeof(Storage))
                return this.Int32 == ((Storage)obj).Int32;
            else
            {
                if (type == typeof(int))
                    return this.Int32 == (int)obj;
                if (type == typeof(short))
                    return this.Int16 == (short)obj;
                if (type == typeof(byte))
                    return this.Byte == (byte)obj;
                if (type == typeof(bool))
                    return this.Boolean == (bool)obj;
                if (type == typeof(float))
                    return this.Single == (float)obj;
                if (type == typeof(ushort))
                    return this.Word == (ushort)obj;
                if (type == typeof(uint))
                    return this.DWord == (uint)obj;
                if (type == typeof(string))
                    return this.ToString() == obj.ToString();
            }
            return false;
        }
    }
    public delegate void ValueChangeHandler(ITag sender, ValueChangeEventArgs e);
    public class ValueChangeEventArgs : EventArgs
    {
        public ValueChangeEventArgs(Storage value)
        {
            this.Value = value;
        }

        public Storage Value;
    }
}
