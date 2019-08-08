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
    /// [0]
    /// </summary>
    public class KVButton : Button, KVBox
    {
        private bool _kvReadOnly;
        private string _kvMenAddr;
        private ITag[] _kvtag=new ITag[2];
        private KVType _type;

        public KVButton() : base()
        {
            for(int i=0;i<2;i++)
            {
                _kvtag[i] = new BoolTag(1,Storage.Empty,_kvMenAddr);
            }
            this._kvtag[0].ValueChangeEvent += ValueChange;
        }
        public Color KVTrueColor
        {
            get; set;
        }

        public Color KVFalseColor
        {
            get; set;
        }
        public bool KVReadOnly
        {
            get { return _kvReadOnly; }
            set
            {
                if (_type == KVType.Light)
                {
                    _kvReadOnly = true;
                }
                else if( _type==KVType.Button || _type == KVType.ButtonAndLight)
                {
                    _kvReadOnly = false;
                }
            }
        }
        public string KVMemAddr { get { return _kvMenAddr; } set { _kvMenAddr = value; } }
        public ITag this[int i]
        {
            get { return _kvtag[i]; }
            set { _kvtag[i] = value; }
        }

        public KVType Type { get { return _type; ; } }

        public void ValueChange(object sender, ValueChangeEventArgs e)
        {
            if (e.Value.Boolean)
            {
                this.BackColor = KVTrueColor;
            }
            else
            {
                this.BackColor = KVFalseColor;
            }
        }
    }
}
