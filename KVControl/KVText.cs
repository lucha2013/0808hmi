using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.Windows.Forms;
using KVDrive;


namespace KVControl
{
    /// <summary>
    /// 指示灯开关
    /// </summary>
    public class KVText : Button, KVBox
    {
        private bool _kvReadOnly;
        private string _kvMenAddr;
        private ITag[] _kvTags=new ITag[1];
        private KVType _kvType;

        public KVText() : base()
        {
            if (_kvTags[0] == null)
            {
                _kvTags[0] = new BoolTag(1, Storage.Empty, _kvMenAddr);
            }
            this._kvTags[0].ValueChangeEvent += ValueChange;
        }

        public ITag[] KVTags { get { return _kvTags; } set { _kvTags = value; } }

        public Color KVTrueColor
        {
            get; set;
        }

        public Color KVFalseColor
        {
            get; set;
        }
        public bool KVReadOnly { get { return _kvReadOnly; } set { _kvReadOnly = value; } }
        public string KVMemAddr { get { return _kvMenAddr; } set { _kvMenAddr = value; } }

        public KVType KVType { get { return _kvType; }set { _kvType = value; } }

        public void ValueChange(object sender, ValueChangeEventArgs e)
        {
            this.Text = e.Value.ToString() ;
        }
    }
}
