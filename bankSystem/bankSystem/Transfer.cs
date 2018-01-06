using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace bankSystem
{
    public partial class Transfer : Form
    {
        public Transfer()
        {
            InitializeComponent();
        }

        private void Transfer_Load(object sender, EventArgs e)
        {

        }

        SqlConnection connection = new SqlConnection("Data Source=.;Initial Catalog=bank;Integrated Security=True");

        private void button1_Click(object sender, EventArgs e)
        {
            string fromAccount, toAccount, date;
            double amount;

            fromAccount = txtFrom.Text;
            toAccount = txtTo.Text;
            date = txtDate.Text;
            amount = Double.Parse(txtAmount.Text);

            connection.Open();
            SqlCommand SC = new SqlCommand();
            SqlTransaction transaction;

            transaction = connection.BeginTransaction();

            SC.Connection = connection;
            SC.Transaction = transaction;

            try
            {
                SC.CommandText = "update Account set Balance = Balance - '" + amount + "' where AccountId = '" + fromAccount + "'";
                SC.ExecuteNonQuery();

                SC.CommandText = "update Account set Balance = Balance + '" + amount + "' where AccountId = '" + toAccount + "'";
                SC.ExecuteNonQuery();

                SC.CommandText = "insert into Transfer (From_account, To_account, Date, Amount) values ('" + fromAccount + "', '" + toAccount + "', '" + date + "', '" + amount + "')";
                SC.ExecuteNonQuery();

                transaction.Commit();
                MessageBox.Show("Transaction success!");
            }

            catch (Exception ex)
            {
                transaction.Rollback();  //odrzuca zmiany wykonywane w obrębie transakcji
                MessageBox.Show(ex.ToString());
            }

            finally
            {
                connection.Close();
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Hide();
        }


    }
}
