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
        
        public KVGroup[]  Groups=new KVGroup[20];

        public ParaSetting ParaSettingForm{ get; set; }
        
       
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
            KeyencePlcDrive kvPLCDrive = new KeyencePlcDrive(1, "KeyencePLCDrive", "192.168.50.211", 5000);
            //将窗口内的 TAG 加到相应的 Group 里面
            AddTags2Group(this, Groups[0] = new KVGroup(true, 1, "homeGroup", 50, new List<ITag>()),kvPLCDrive);
            AddTags2Group(ParaSettingForm, Groups[1] = new KVGroup(false, 2, "paraSettingGroup", 50, new List<ITag>()),kvPLCDrive);           

            kvPLCDrive.Groups = Groups;
            kvPLCDrive.init();
        }

        private void AddTags2Group(Form home, KVGroup homeGroup, KeyencePlcDrive kVDrive)
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
                        tag.ValueChangeEvent += ((KVBox)control).ValueChange;
                        tag.Parent = kVDrive;
                        tag.Address = ((KVBox)control).KVMemAddr;
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

        private void kvFloatText1_TextChanged(object sender, EventArgs e)
        {
            //KeyencePlcDrive.eventRead.WaitOne();
            //foreach (ITag tag in ((KVBox)kvFloatText1).KVTags)
            //{
            //    tag.UpdatePLC();
            //}
            //KeyencePlcDrive.eventRead.Set();
        }


    }
}
