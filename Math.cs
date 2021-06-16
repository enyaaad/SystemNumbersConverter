using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ConvertSN;

namespace convertionsystemnumbers
{
    public partial class Math : Form
    {
        public Math()
        {
            InitializeComponent();
        }

        private void Math_Load(object sender, EventArgs e)
        {

        }
        private static int Error(string number, int xd, int currentns)
        {
            for (int i = 0; i < number.Length; i++)
            {
                xd = ConvertNS.CharToInt(number[i]);
                if (xd >= currentns)
                {
                    return -1;
                }

            }
            if (number == "" || number == " ")
            {
                return -1;
            }

            return 0;
        }
        private void button1_Click(object sender, EventArgs e)
        {

            string numberfirst = "";
            string numbersecond = "";
            int numsys = 0;
            int xd = 0, errorcheck = 0;
            int firstresult = 0;
            string temps1, temps2, temps3 ;
            try
            {
                textBox4.Text = "";
                numberfirst = textBox1.Text;
                numbersecond = textBox2.Text;
                numsys = Convert.ToInt32(numericUpDown1.Value);
                errorcheck = Error(numberfirst, xd, numsys);

            }
            catch
            {
                MessageBox.Show("Enter Valid Value");
            }
            if (errorcheck == -1)
            {
                MessageBox.Show("Enter Valid Value");
            }
            else
            {
                try
                {
                    string comboboxstate = comboBox1.Text;
                    if (comboBox1.Text == "Сложение")
                    {
                        temps1 = ConvertNS.Converting(numsys, 10, numberfirst);
                        temps2 = ConvertNS.Converting(numsys, 10, numbersecond);
                        firstresult = Convert.ToInt32(temps1) + Convert.ToInt32(temps2);
                    }
                    else if (comboBox1.Text == "Вычитание")
                    {
                        temps1 = ConvertNS.Converting(numsys, 10, numberfirst);
                        temps2 = ConvertNS.Converting(numsys, 10, numbersecond);
                        firstresult = Convert.ToInt32(temps1) - Convert.ToInt32(temps2);
                        if (Convert.ToInt32(temps1) < Convert.ToInt32(temps2))
                        {
                            MessageBox.Show("we don't work with negative numbers yet");

                        }
                        temps3 = ConvertNS.Converting(10, numsys, firstresult.ToString());
                        if (Convert.ToInt32(temps3) > 1000000)
                            MessageBox.Show("Too Big Value to display");
                    }             
                    else
                    {
                        MessageBox.Show("Enter Valid Action");
                    }
                    textBox4.Text = ConvertNS.Converting(10, numsys, firstresult.ToString());

                }
                catch
                {
                    MessageBox.Show("Error while counting ");
                }
            }


        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Hide();
            MainForm Mainf = new MainForm();
            Mainf.ShowDialog();
        }
    }
}
