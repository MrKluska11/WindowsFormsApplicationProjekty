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
    public partial class Withdrew : Form
    {
        public Withdrew()
        {
            InitializeComponent();
        }

        private void Withdrew_Load(object sender, EventArgs e)
        {

        }

        SqlConnection connection = new SqlConnection("Data Source=.;Initial Catalog=bank;Integrated Security=True");

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                connection.Open();
                string query = "select * from Account where AccountId = '" + txtAccountNr.Text.ToString() + "'";

                SqlCommand SC = new SqlCommand(query, connection);
                SqlDataReader SDR = SC.ExecuteReader();

                while (SDR.Read())
                {
                    txtBallance.Text = SDR[4].ToString();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                connection.Close();
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            string accountId, date;
            double balance, withdraw;

            accountId = txtAccountNr.Text;
            date = txtDate.Text;
            balance = Double.Parse(txtBallance.Text);
            withdraw = Double.Parse(txtWithdraw.Text);

            connection.Open();
            SqlCommand SC = new SqlCommand();
            SqlTransaction transaction;

            transaction = connection.BeginTransaction();

            SC.Connection = connection;
            SC.Transaction = transaction;

            try
            {
                SC.CommandText = "insert into Transaction1 (AccountId, Date, Balance, Withdraw) values('" + accountId + "', '" + date + "', '" + balance + "', '" + withdraw + "')";
                SC.ExecuteNonQuery();

                SC.CommandText = "update Account set Balance = Balance - '" + withdraw + "' where AccountId = '" + accountId + "'";
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


    }
}
