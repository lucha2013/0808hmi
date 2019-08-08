using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using KVControl;

namespace hmi0807_2
{
    public partial class Home : Form
    {
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
        }
    }
}
