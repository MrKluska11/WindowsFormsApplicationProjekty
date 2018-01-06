using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace bankSystem
{
    public partial class progressBar : Form
    {
        public progressBar()
        {
            InitializeComponent();
        }

        //Project ---> Add Windows Form

        private void timer1_Tick(object sender, EventArgs e)
        {
            progressBar1.Value = progressBar1.Value + 1;

            if(progressBar1.Value > 99)
            {
                Main main = new Main();
                this.Hide();
                main.Show();

                timer1.Enabled = false;
            }
        }

        private void progressBar_Load(object sender, EventArgs e)
        {

        }
    }
}
