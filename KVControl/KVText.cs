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
    /// 指示灯开关
    /// </summary>
    public class KVFloatText : TextBox, KVBox
    {
        private bool _kvReadOnly=false;
        private string _kvMenAddr;
        private List<ITag> _kvTags;


        public KVFloatText() : base()
        {
            _kvTags = new List<ITag>();
            _kvTags.Add(new FloatTag(1, Storage.Empty, _kvMenAddr));
        }
  

        public Color KVTrueColor
        {
            get; set;
        }

        public Color KVFalseColor
        {
            get; set;
        }
        public bool KVReadOnly { get { return _kvReadOnly; }  }
        public string KVMemAddr { get { return _kvMenAddr; } set { _kvMenAddr = value; } }
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public List<ITag> KVTags
        {
            get { return _kvTags; }
            set { _kvTags = value; }
        }

        public void ValueChange(object sender, ValueChangeEventArgs e)
        {
            if (this.InvokeRequired)//如果调用控件的线程和创建创建控件的线程不是同一个则为True
            {
                while (!this.IsHandleCreated)
                {
                    //解决窗体关闭时出现“访问已释放句柄“的异常
                    if (this.Disposing || this.IsDisposed)
                        return;
                }
                this.Invoke(new Action(() => 
                {

                    this.Text =e.Value.Single.ToString();
                }));
                
            }
            else
            {
                this.Text = e.Value.Single.ToString();
            }
        }
        public string GetData2String(ITag  tag, Storage storage)
        {
            Type t = tag.GetType();
            if(t==typeof(BoolTag))
            {
                return storage.Boolean.ToString();
            }
            if(t == typeof(FloatTag))
            {
                return storage.Single.ToString();
            }
            return null;
        }
    }
}
