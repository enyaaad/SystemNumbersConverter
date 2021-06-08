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
	public partial class MainForm : Form
	{

		public MainForm()
		{
			InitializeComponent();
			
		}

		private void Form1_Load(object sender, EventArgs e)
		{

		}

		private static void textBox2_TextChanged(object sender, EventArgs e)
		{


		}

		private static void ShowMsg(string Msg)
		{
			MessageBox.Show(Msg);
		}
		private static int Error(string number,int xd, int currentns)
		{
			for (int i = 0; i < number.Length; i++)
			{
				xd = ConvertNS.CharToInt(number[i]);
				if (xd >= currentns)
				{
					return -1;
				}
			}
			return 0;
		}

		private void button1_Click(object sender, EventArgs e)
		{
			ConvertNS.Notify += ShowMsg;
			string number = "";
			int currentns = 0, futurens = 0;
			int xd = 0;
			int xz = 0;
			try
			{
				textBox4.Text = "";
				number = textBox2.Text;
				currentns = Convert.ToInt32(numericUpDown1.Value);
				futurens = Convert.ToInt32(numericUpDown2.Value);
				xz = Error(number, xd, currentns);
			}
			catch
			{
				if (number == "" && number == " ")
					MessageBox.Show("Enter Valid Value");
			}
			if (xz == -1)
			{
				MessageBox.Show("Enter Valid Value");
			}
			else
			{
				textBox4.Text = ConvertNS.Converting(currentns, futurens, number);
			}			
		}

	}
}
