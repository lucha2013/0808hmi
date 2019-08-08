using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace hmi0807_2
{
    public partial class ParaSetting : Form
    {
        public Form FromWindow { get; set; }
        public ParaSetting()
        {
            InitializeComponent();
        }

        private void Button1_Click(object sender, EventArgs e)
        {
            if (FromWindow != null)
            {
                this.Hide();
                FromWindow.Show();
            }
        }

        private void ParaSetting_Load(object sender, EventArgs e)
        {

        }
    }
}
