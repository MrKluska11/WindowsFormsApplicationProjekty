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
    public partial class Main : Form
    {
        public Main()
        {
            InitializeComponent();
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            AccountCreation accontCreation = new AccountCreation();
            accontCreation.Show();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            Transfer transfer = new Transfer();
            transfer.Show();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            Deposit deposit = new Deposit();
            deposit.Show();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Withdrew withdraw = new Withdrew();
            withdraw.Show();
        }
    }
}
