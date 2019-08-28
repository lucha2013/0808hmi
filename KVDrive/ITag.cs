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
            this._lastValue = _value;

        }
        public ITag(short id, Storage value, string address)
        {
            this._id = id;
            this._value = value;
            this._address = address;
            this._lastValue = _value;
            

        }

        public ITag()
        {
            
        }

        //private DateTime _timeStamp;
        private short _id;

        public IDriver Parent { get { return _drive; } set { _drive = value; } }
        public short ID { get { return _id; } }
        protected Storage _value;
        protected Storage _lastValue;
        public Storage Value
        {
            get
            {
                return _value;
            }
        }
        /// <summary>
        /// 读取PLC
        /// </summary>
        /// <returns></returns>
        
            

        public string Address { get { return _address; } set { _address = value; } }

        public void Update()
        {
            Storage newValue = Read();
            if (_value.Equals(newValue)) return;
            _value = newValue;
            _lastValue = newValue;
            if (ValueChangeEvent != null)
            {
                ValueChangeEvent(this, new ValueChangeEventArgs(newValue));
            }
        }
        public void UpdatePLC()
        {
            if (_lastValue.Equals(_value))
            {
                return;
            }
            Write(_value);
        }
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
        public BoolTag() : base()
        {

        }
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
        
        public override bool Write(object value)
        {
            DeviceAddress address = GetDeviceAddress(Address, 1);
            return ((KeyencePlcDrive)Parent).WriteBit(address,((Storage)value).Boolean);

        }
    }
    public class FloatTag : ITag
    {
        public FloatTag() : base()
        {

        }
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
        public override bool Write(object value)
        {
            DeviceAddress address = GetDeviceAddress(Address, 2);
            return ((KeyencePlcDrive)Parent).WriteFloat(address, ((Storage)value).Single);

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
