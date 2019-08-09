using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using KVControl;
using KVDrive;

namespace hmi0807_2
{
    public partial class Home : Form
    {
        private KVGroup _homeGroup;

        public ParaSetting ParaSettingForm{ get; set; }
        public KVGroup HomeGroup { get { return _homeGroup; } set { _homeGroup = value; } }
        public Home()
        {
            InitializeComponent();
        }

        private void Button1_Click(object sender, EventArgs e)
        {
            this.ParaSettingForm.Show();
            this.Hide();
        }

        private void Home_Load(object sender, EventArgs e)
        {
            ParaSettingForm = new ParaSetting() { FromWindow = this };
            AddGroup(this, HomeGroup = new KVGroup(true, 1, "homeGroup", 50, new List<ITag>()));
            AddGroup(ParaSettingForm, HomeGroup);
        }

        private void AddGroup(Form home, KVGroup homeGroup)
        {

            Control.ControlCollection controlCollection = home.Controls;
            foreach (Control control in controlCollection)
            {
                //if (control.Controls != null)
                //{
                //    AddGroup(home, homeGroup);
                //}


                if (control.GetType().GetInterface("KVBox") != null)
                { 
                    foreach (ITag tag in ((KVBox)control).KVTags)
                    {
                        homeGroup.AddTag(tag);
                    }
                        
                }
                //KVBox box = control as KVBox;
                //if (box!=null)
                //{
                //    foreach(ITag tag in box.KVTags)
                //    {
                //        homeGroup.AddTag(tag);
                //    }
                    
                //}

            }
        }
        private bool HasProperty(object o,string property)
        {
            Type t = o.GetType();
            PropertyInfo propertyInfo = t.GetProperty(property);
            return o.GetType().GetProperty(property) != null;
        }
    }
}
