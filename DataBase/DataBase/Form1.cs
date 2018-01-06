using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;   //dodana przestrzeń nazw

namespace DataBase
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        SqlConnection connection = new SqlConnection("Data Source=.;Initial Catalog=DataEntry;Integrated Security=True");  //parametrem jest connection string

        private void button1_Click(object sender, EventArgs e)
        {
            connection.Open();
            SqlDataAdapter SDA = new SqlDataAdapter("INSERT INTO Register (Id, Name, Gender, Age, Salary, Tax) Values('" + textBox1.Text + "', '" + textBox2.Text + "', '" + comboBox1.Text + "', '" + textBox4.Text + "', '" + textBox5.Text + "', '" + textBox6.Text +"')", connection);
            SDA.SelectCommand.ExecuteNonQuery();
            connection.Close();

            MessageBox.Show("SAVED SUCCESFULLY!");
        }

        private void button4_Click(object sender, EventArgs e)
        {
            connection.Open();
            SqlDataAdapter SDA = new SqlDataAdapter("SELECT * FROM Register", connection);
            DataTable Data = new DataTable();
            SDA.Fill(Data);
            dataGridView1.DataSource = Data;
            connection.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            connection.Open();
            SqlDataAdapter SDA = new SqlDataAdapter("UPDATE Register SET Name='" + textBox2.Text + "', Gender='" + comboBox1.Text + "', Age='" + textBox4.Text + "', Salary='" + textBox5.Text + "', Tax='" + textBox6.Text +"' WHERE Id='" + textBox1.Text + "'", connection);
            SDA.SelectCommand.ExecuteNonQuery();
            connection.Close();

            MessageBox.Show("UPDATED SUCCESFULLY!");
        }

        private void dataGridView1_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            textBox1.Text = dataGridView1.SelectedRows[0].Cells[0].Value.ToString();
            textBox2.Text = dataGridView1.SelectedRows[0].Cells[1].Value.ToString();
            comboBox1.Text = dataGridView1.SelectedRows[0].Cells[2].Value.ToString();
            textBox4.Text = dataGridView1.SelectedRows[0].Cells[3].Value.ToString();
            textBox5.Text = dataGridView1.SelectedRows[0].Cells[4].Value.ToString();
            textBox6.Text = dataGridView1.SelectedRows[0].Cells[5].Value.ToString();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            connection.Open();
            string id = dataGridView1.SelectedRows[0].Cells[0].Value.ToString();
            SqlDataAdapter SDA = new SqlDataAdapter("DELETE FROM Register WHERE Id='" + id +"'", connection);
            SDA.SelectCommand.ExecuteNonQuery();
            connection.Close();

            MessageBox.Show("DELETED SUCCESFULLY!");
        }
    }
}
