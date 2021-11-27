using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Calculadora
{
    public partial class Form1 : Form
    {
        private string operador, mem_a, mem_b;
        public Form1()
        {
            InitializeComponent();
            Calculadora();
        }
        private void Calculadora()
        {
            textBox1.Enabled = false;
        }

        private Boolean TextBoxMaxLenght(string text)
        {
            if (text.Length > 27)
                return false;
            else
                return true;
        }

        private Boolean haveAnActiveOperation(string text)
        {
            if (text.Contains("% de "))
                return false;
            else if (text.Contains(" ÷ "))
                return false;
            else if (text.Contains(" * "))
                return false;
            else if (text.Contains(" - "))
                return false;
            else if (text.Contains(" + "))
                return false;

            return true;
        }

        private void button5_Click(object sender, EventArgs e)
        {
            if (resultWasClicked)
                CleanScreen();

            if(TextBoxMaxLenght(textBox1.Text))
                textBox1.Text += "1";
        }

        private void button6_Click(object sender, EventArgs e)
        {
            if (resultWasClicked)
                CleanScreen();

            if (TextBoxMaxLenght(textBox1.Text))
                textBox1.Text += "2";
        }

        private void button7_Click(object sender, EventArgs e)
        {
            if (resultWasClicked)
                CleanScreen();

            if (TextBoxMaxLenght(textBox1.Text))
                textBox1.Text += "3";
        }

        private void button9_Click(object sender, EventArgs e)
        {
            if (resultWasClicked)
                CleanScreen();

            if (TextBoxMaxLenght(textBox1.Text))
                textBox1.Text += "4";
        }

        private void button10_Click(object sender, EventArgs e)
        {
            if (resultWasClicked)
                CleanScreen();

            if (TextBoxMaxLenght(textBox1.Text))
                textBox1.Text += "5";
        }

        private void button11_Click(object sender, EventArgs e)
        {
            if (resultWasClicked)
                CleanScreen();

            if (TextBoxMaxLenght(textBox1.Text))
                textBox1.Text += "6";
        }

        private void button13_Click(object sender, EventArgs e)
        {
            if (resultWasClicked)
                CleanScreen();

            if (TextBoxMaxLenght(textBox1.Text))
                textBox1.Text += "7";
        }

        private void button14_Click(object sender, EventArgs e)
        {
            if (resultWasClicked)
                CleanScreen();

            if (TextBoxMaxLenght(textBox1.Text))
                textBox1.Text += "8";
        }

        private void button15_Click(object sender, EventArgs e)
        {
            if (resultWasClicked)
                CleanScreen();

            if (TextBoxMaxLenght(textBox1.Text))
                textBox1.Text += "9";
        }

        private void button1_Click(object sender, EventArgs e)
        {
            textBox1.Text = textBox1.Text.Remove(textBox1.Text.Length - 1);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            textBox1.Text = textBox1.Text.Remove(0);
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (resultWasClicked)
                resultWasClicked = !resultWasClicked;

            if (textBox1.Text.Length > 0 && haveAnActiveOperation(textBox1.Text))
                textBox1.Text += "% de "; operador = "% de ";
        }
        private void button12_Click(object sender, EventArgs e)
        {
            if (resultWasClicked)
                resultWasClicked = !resultWasClicked;

            if (textBox1.Text.Length > 0 && haveAnActiveOperation(textBox1.Text))
                textBox1.Text += " * "; operador = " * ";
        }

        private void button16_Click(object sender, EventArgs e)
        {
            if (textBox1.Text.Length > 0 && haveAnActiveOperation(textBox1.Text) && !textBox1.Text.Substring(textBox1.Text.Length - 1, 1).Contains("-") || textBox1.Text.Length == 1 && !textBox1.Text.Contains('-'))
            {
                if (resultWasClicked)
                    resultWasClicked = !resultWasClicked;

                textBox1.Text += " - ";
                operador = " - ";
            }
            else if (textBox1.Text.Length == 0 || textBox1.Text.Substring(textBox1.Text.Length - 1, 1).Contains(" "))
            {
                textBox1.Text += "-";
            }
        }

        private void button20_Click(object sender, EventArgs e)
        {
            if (resultWasClicked)
                resultWasClicked = !resultWasClicked;

            if (textBox1.Text.Length > 0 && haveAnActiveOperation(textBox1.Text))
                textBox1.Text += " + "; operador = " + ";
        }

        private void button8_Click(object sender, EventArgs e)
        {
            if (resultWasClicked)
                resultWasClicked = !resultWasClicked;

            if (textBox1.Text.Length > 0 && haveAnActiveOperation(textBox1.Text))
                textBox1.Text += " ÷ "; operador = " ÷ ";
        }
        Boolean toggle_mem_a = false, toggle_mem_b = false;
        private void button17_Click(object sender, EventArgs e)
        {
            if (!toggle_mem_a)
            {
                mem_a = textBox1.Text;
                toggle_mem_a = !toggle_mem_a;
            } else
            {
                textBox1.Text += mem_a;
                toggle_mem_a = !toggle_mem_a;
            }
        }

        private void button18_Click(object sender, EventArgs e)
        {
            if (!toggle_mem_b)
            {
                mem_b = textBox1.Text;
                toggle_mem_b = !toggle_mem_b;
            }
            else
            {
                textBox1.Text += mem_b;
                toggle_mem_b = !toggle_mem_b;
            }
        }

        private void button19_Click(object sender, EventArgs e)
        {
            if (resultWasClicked)
                CleanScreen();

            if (TextBoxMaxLenght(textBox1.Text))
                textBox1.Text += "0";
        }

        private string[] divideCaracteres;
        private int num1, num2, result;

        Boolean resultWasClicked = false;
        private void button4_Click(object sender, EventArgs e)
        {
            if(!resultWasClicked)
            {
                resultWasClicked = !resultWasClicked;
            }

            divideCaracteres = textBox1.Text.Split(operador);
            num1 = Convert.ToInt32(divideCaracteres[0]);
            num2 = Convert.ToInt32(divideCaracteres[1]);

            if (textBox1.Text.Contains(" % "))
            {
                result = (num1 * num2) / 100;
                textBox1.Text = result.ToString();
            }
            else if (textBox1.Text.Contains(" ÷ "))
            {
                result = num1 / num2;
                textBox1.Text = result.ToString();
            }
            else if (textBox1.Text.Contains(" * "))
            {
                result = num1 * num2;
                textBox1.Text = result.ToString();
            }
            else if (textBox1.Text.Contains(" - "))
            {
                result = num1 - num2;
                textBox1.Text = result.ToString();
            }
            else if (textBox1.Text.Contains(" + "))
            {
                result = num1 + num2;
                textBox1.Text = result.ToString();
            }
        }
        private void CleanScreen()
        {
            textBox1.Text = "";
        }
    }
}
