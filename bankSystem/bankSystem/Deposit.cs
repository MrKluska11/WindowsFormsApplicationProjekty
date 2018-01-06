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
    public partial class Deposit : Form
    {
        public Deposit()
        {
            InitializeComponent();
        }

        private void Deposit_Load(object sender, EventArgs e)
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
            catch(Exception ex)
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
            double balance, deposit;

            accountId = txtAccountNr.Text;
            date = txtDate.Text;
            balance = Double.Parse(txtBallance.Text);
            deposit = Double.Parse(txtDeposit.Text);

            connection.Open();
            SqlCommand SC = new SqlCommand();
            SqlTransaction transaction;

            transaction = connection.BeginTransaction();

            SC.Connection = connection;
            SC.Transaction = transaction;

            try
            {
                SC.CommandText = "insert into Transaction1 (AccountId, Date, Balance, Deposit) values('" + accountId + "', '" + date + "', '" + balance + "', '" + deposit + "')";
                SC.ExecuteNonQuery();

                SC.CommandText = "update Account set Balance = Balance + '" + deposit + "' where AccountId = '" + accountId + "'";
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
