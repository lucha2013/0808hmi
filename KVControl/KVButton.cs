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
    /// 开关
    /// [0]
    /// </summary>
    public class KVButton : Button,KVBox
    {
        private bool _kvReadOnly = false;
        private string _kvMenAddr;
        private ITag[] _kvTags;
        private short _kvTagCount = 1;

        public KVButton() : base()
        {
            _kvTags = new ITag[_kvTagCount];
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
        }
        public string KVMemAddr { get { return _kvMenAddr; } set { _kvMenAddr = value; } }
        public ITag[] KVTags
        {
            get { return _kvTags; }
            set { _kvTags= value; }
        }
        public short KVTagCount
        {
            get { return _kvTagCount; }
        }

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
