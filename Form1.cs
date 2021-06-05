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
	public partial class Form1 : Form
	{

		public Form1()
		{
			InitializeComponent();
			
		}

		private void Form1_Load(object sender, EventArgs e)
		{

		}

		private static void textBox2_TextChanged(object sender, EventArgs e)
		{


		}

		private void button1_Click(object sender, EventArgs e)
		{
			string number= "";
			int currentns = 0, futurens = 0;

			number = textBox2.Text;
			currentns = Convert.ToInt32(textBox1.Text);
			futurens= Convert.ToInt32(textBox3.Text) ;
			textBox4.Text = ConvertNS.Converting(currentns, futurens, number); 
		}
	}
}
