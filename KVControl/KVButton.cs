using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.Windows.Forms;
using KVDrive;
using System.ComponentModel;

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
        private List<ITag> _kvTags;

        public KVButton() : base()
        {
            _kvTags = new List<ITag>();
            _kvTags.Add(new BoolTag(1,Storage.Empty,_kvMenAddr));
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
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public List<ITag> KVTags
        {
            get { return _kvTags; }
            set { _kvTags= value; }
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
