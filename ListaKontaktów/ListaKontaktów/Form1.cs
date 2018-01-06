using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;  //dodana przestrzeń nazw

namespace ListaKontaktów
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            btnAddContact.Enabled = false;
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            Read();
            Display();
        }

        //zmienna globalna
        private Contact[] phoneBook = new Contact[1];
        
        private void Write(Contact obiekt)
        {
            StreamWriter sw = new StreamWriter("Kontakty.txt");  //plik Kontakty.txt został umieszczony w folderze: bin ---> Debug
            sw.WriteLine(phoneBook.Length + 1);

            sw.WriteLine(obiekt.FirstName);
            sw.WriteLine(obiekt.LastName);
            sw.WriteLine(obiekt.Phone);

            for(int i = 0; i < phoneBook.Length; i++)
            {
                sw.WriteLine(phoneBook[i].FirstName);
                sw.WriteLine(phoneBook[i].LastName);
                sw.WriteLine(phoneBook[i].Phone);
            }

            sw.Close();

        }

        private void Read()
        {
            StreamReader sr = new StreamReader("Kontakty.txt");
            phoneBook = new Contact[Convert.ToInt32(sr.ReadLine())];

            for(int i = 0; i < phoneBook.Length; i++)
            {
                phoneBook[i] = new Contact();
                phoneBook[i].FirstName = sr.ReadLine();
                phoneBook[i].LastName = sr.ReadLine();
                phoneBook[i].Phone = sr.ReadLine();
            }

            sr.Close();
        }

        private void Display()
        {
            listContacts.Items.Clear();

            for (int i = 0; i < phoneBook.Length; i++)
            {
                listContacts.Items.Add(phoneBook[i].ToString());
            }
        }

        private void ClearForm()
        {
            txtFirstName.Text = string.Empty;
            txtLastName.Text = string.Empty;
            txtPhone.Text = "";
        }

        private void btnAddContact_Click(object sender, EventArgs e)
        {
            Contact obiekt = new Contact();
            
            obiekt.FirstName = txtFirstName.Text;
            obiekt.LastName = txtLastName.Text;
            obiekt.Phone = txtPhone.Text;

            Write(obiekt);
            Read();
            Display();
            ClearForm();
        }
        private void button1_Click(object sender, EventArgs e)
        {
            Sort();
            Display();
        }

        private void Sort()
        {
            Contact temp;
            bool swap;

            do
            {
                swap = false;

                for(int i = 0; i < phoneBook.Length - 1; i++)
                {
                    if(phoneBook[i].LastName.CompareTo(phoneBook[i+1].LastName) > 0)   //jeśli wynik > 0 to wtedy phonebook[i] jest większe od phonebook[i+1]
                    {
                        temp = phoneBook[i];
                        phoneBook[i] = phoneBook[i+1];
                        phoneBook[i+1] = temp;
                        swap = true;
                    }
                    
                }

            } while(swap == true);

            
        }

        private void txtFirstName_TextChanged(object sender, EventArgs e)
        {
            btnAddContact.Enabled = (txtFirstName.Text.Length > 0) && (txtLastName.Text.Length > 0) && (txtPhone.Text.Length > 0);
        }

        private void txtLastName_TextChanged(object sender, EventArgs e)
        {
            btnAddContact.Enabled = (txtFirstName.Text.Length > 0) && (txtLastName.Text.Length > 0) && (txtPhone.Text.Length > 0);
        }

        private void txtPhone_TextChanged(object sender, EventArgs e)
        {
            btnAddContact.Enabled = (txtFirstName.Text.Length > 0) && (txtLastName.Text.Length > 0) && (txtPhone.Text.Length > 0);
        }


        
    }
}
