using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ListaKontaktów
{
    public class Contact
    {
        private string firstName;
        private string lastName;
        private string phone;

        public string FirstName
        {
            get { return firstName; }
            set { firstName = value; }
        }

        public string LastName
        {
            get { return lastName; }
            set { lastName = value; }
        }

        public string Phone
        {
            get { return phone; }

            set
            {
                if(value.Length == 10)
                {
                    phone = value;
                }
                else
                {
                    phone = "000000000";
                }
            }
        }

        public Contact()    //konstruktor bezparametrowy
        {
            FirstName = "Ryszard";
            LastName = "Cebula";
            Phone = "111111111";
        }

        public Contact(string firstName, string lastName, string phone)
        {
            FirstName = firstName;
            LastName = lastName;
            Phone = phone;

        }

        public override string ToString()  //nadpisuje (przeciąża) metodę ToString
        {
            string output = string.Empty;

            output += string.Format("{0}, {1}", FirstName, LastName) + ", tel: ";
            output += string.Format("({0}) {1}-{2}", Phone.Substring(0, 3), Phone.Substring(3, 4), Phone.Substring(7, 3));  //nr tel np. (043)8866-147

            return output;
        }
    }
}
