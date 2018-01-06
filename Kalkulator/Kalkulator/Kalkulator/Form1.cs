using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Kalkulator
{
    public partial class Form1 : Form
    {
        Double resultValue = 0;
        string operationPerformed = "";
        bool isOperationPerformed = false;

        public Form1()
        {
            InitializeComponent();
        }

        private void button_click(object sender, EventArgs e)
        {
            if (textBox_Result.Text == "0" || (isOperationPerformed))
                textBox_Result.Clear();

            isOperationPerformed = false;
            Button button = (Button)sender;

            if(button.Text == ",")
            {
                if(!textBox_Result.Text.Contains(","))
                {
                    textBox_Result.Text = textBox_Result.Text + button.Text;
                }

            }
            else
            {
                textBox_Result.Text = textBox_Result.Text + button.Text;
            }
            
        }

        private void operator_click(object sender, EventArgs e)
        {
            Button button = (Button)sender;


                operationPerformed = button.Text;
                resultValue = Double.Parse(textBox_Result.Text);
                label1.Text = resultValue + " " + operationPerformed;
                isOperationPerformed = true;
        }

        private void button6_Click(object sender, EventArgs e)
        {
            textBox_Result.Text = "0";
        }

        private void button11_Click(object sender, EventArgs e)
        {
            textBox_Result.Text = "0";
            resultValue = 0;
            label1.Text = "";
        }

        private void button21_Click(object sender, EventArgs e)
        {
            switch(operationPerformed)
            {
                case "+":
                    textBox_Result.Text = (resultValue + Double.Parse(textBox_Result.Text)).ToString();
                    break;
                case "-":
                    textBox_Result.Text = (resultValue - Double.Parse(textBox_Result.Text)).ToString();
                    break;
                case "*":
                    textBox_Result.Text = (resultValue * Double.Parse(textBox_Result.Text)).ToString();
                    break;
                case "/":
                    textBox_Result.Text = (resultValue / Double.Parse(textBox_Result.Text)).ToString();
                    break;
                default:
                    break;
            }

            label1.Text = "";
            resultValue = Double.Parse(textBox_Result.Text);
        }
    }
}
