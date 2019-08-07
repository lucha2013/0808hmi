using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KVDrive
{
    public class KVGroup : IGroup
    {
        private bool _isActive;
        private short _id;
        private string _name;
        private int _updateRate;
        private List<ITag> _items;

        public bool IsActive { get { return _isActive; } set { _isActive = value; } }

        public short ID { get { return _id; } set { _id = value; } }

        public string Name { get { return _name; } set { _name = value; } }

        public int UpdateRate { get { return _updateRate; } set { _updateRate = value; } }

        public List<ITag> Items { get { return _items; } set { _items = value; } }


        public void AddTag(ITag tag)
        {
            _items.Add(tag);
        }


        public void RemoveTag(ITag tag)
        {
            _items.Remove(tag);//可否删除引用对象？
        }

    }
}

