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
        private ITag[] _kvTag=new ITag[1];
        private KVType _type;

        public KVText() : base()
        {
            if (_kvTag[0] == null)
            {
                _kvTag[0] = new BoolTag(1, Storage.Empty, _kvMenAddr);
            }
            this._kvTag[0].ValueChangeEvent += ValueChange;
        }

        public ITag this[int i] { get { return _kvTag[i]; } set { _kvTag[i] = value; } }

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

        public KVType Type { get { return _type; }set { _type = value; } }

        public void ValueChange(object sender, ValueChangeEventArgs e)
        {
            this.Text = e.Value.ToString() ;
        }
    }
}
