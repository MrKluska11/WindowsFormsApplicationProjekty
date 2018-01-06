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
    public partial class AccountCreation : Form
    {
        public AccountCreation()
        {
            InitializeComponent();
        }

        SqlConnection connection = new SqlConnection("Data Source=.;Initial Catalog=bank;Integrated Security=True");

        public void customerId()
        {
            connection.Open();
            string query = "select max(CustomerId) from Customer";
            SqlDataAdapter SDA = new SqlDataAdapter(query, connection);
            SqlDataReader SDR;
            SDR = SDA.SelectCommand.ExecuteReader();

            if(SDR.Read())
            {
                string valuee = SDR[0].ToString();

                if(valuee == "")
                {
                    label13.Text = "10000";
                }
                else
                {
                    int a;
                    a = int.Parse(SDR[0].ToString());
                    a = a + 1;  // +1 ponieważ wartości id mają być auto-inkrementowane
                    label13.Text = a.ToString();
                }
            }
            connection.Close();

        }

        private void AccountCreation_Load(object sender, EventArgs e)
        {
            customerId();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            tabControl1.SelectedTab = tabPage1;
            button3.BackColor = ColorTranslator.FromHtml("#d90a0a");
            button4.BackColor = ColorTranslator.FromHtml("#12b4cc");
        }

        private void button4_Click(object sender, EventArgs e)
        {
            tabControl1.SelectedTab = tabPage2;
            button4.BackColor = ColorTranslator.FromHtml("#12b4cc");
            button3.BackColor = ColorTranslator.FromHtml("#d90a0a");
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string customerId, lastName, firstName, street, city, phone, date, email, accountNr, accountType, description, balance;

            customerId = label13.Text;
            lastName = txtLastName.Text;
            firstName = txtFirstName.Text;
            street = txtStreet.Text;
            city = txtCity.Text;
            phone = txtPhone.Text;
            date = txtDate.Text;
            email = txtEmail.Text;

            accountNr = txtAccountNr.Text;
            accountType = txtAccountType.Text;
            description = txtDescription.Text;
            balance = txtBalance.Text;

            connection.Open();
            SqlCommand SC = new SqlCommand();
            SqlTransaction transaction;

            transaction = connection.BeginTransaction();

            SC.Connection = connection;
            SC.Transaction = transaction;

            try
            {
                SC.CommandText = "insert into Customer (CustomerId, LastName, FirstName, Street, City, Phone, Date, Email) values('" + customerId + "', '" + lastName + "', '" + firstName + "', '" + street + "', '" + city + "', '" + phone + "', '" + date + "', '" + email + "')";
                SC.ExecuteNonQuery();

                SC.CommandText = "insert into Account (AccountId, CustomerId, AccountType, Description, Balance) values('" + accountNr + "', '" + customerId + "', '" + accountType + "', '" + description + "', '" + balance + "')";
                SC.ExecuteNonQuery();

                transaction.Commit();
                MessageBox.Show("Records have been added!");
            }

            catch(Exception ex)
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
            this.Close();
        }
    }
}
