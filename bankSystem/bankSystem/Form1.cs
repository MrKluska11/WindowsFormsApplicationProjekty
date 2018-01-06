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
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        int count = 0;

        private void button1_Click(object sender, EventArgs e)
        {
            string username, password;

            username = txtUsername.Text;
            password = txtPassword.Text;

            if(username == "" && password == "")
            {
                label4.Text = "Blank is not allowed!";
                count++;

                if (count > 2)
                {
                    MessageBox.Show("System has been blocked!");
                    Application.Exit();
                }
            }
            else if(username.Length > 10 || password.Length > 10)
            {
                label4.Text = "Username and password must have max 10 characters!";
                txtPassword.Clear();
                txtUsername.Clear();

                count++;

                if (count > 2)
                {
                    MessageBox.Show("System has been blocked!");
                    Application.Exit();
                }
            }
            else
            {
                if (username == "user" && password == "1234")
                {
                    //label4.Text = "Login Succesfully!";

                    progressBar progress = new progressBar();  
                    this.Hide();   // ukrywa okno wyswietlanego formularza
                    progress.Show();
                }
                else
                {
                    label4.Text = "Invalid username or password!";
                    txtPassword.Clear();
                    txtUsername.Clear();
                    count++;

                    if (count > 2)
                    {
                        MessageBox.Show("System has been blocked!");
                        Application.Exit();
                    }
                }
            }
        }  

        private void timer1_Tick(object sender, EventArgs e)
        {
            label4.Text = "";
            timer1.Enabled = false;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
