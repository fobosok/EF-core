using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp2
{
	public partial class RegForm : Form
	{
		User user;
		public User UserProp
		{
			get
			{
				return user;
			}
		}
		public RegForm(Form1 form1, User us)
		{
			user = us;
			InitializeComponent();
			button1.DialogResult = DialogResult.OK;
			button2.DialogResult = DialogResult.Cancel;
			textBox1.Text = us.Log;
			textBox2.Text = us.Pass;
			textBox3.Text = us.Phone;
		}

		private void button1_Click(object sender, EventArgs e)
		{
			user = new User { Log = textBox1.Text, Pass = textBox2.Text, Phone = textBox3.Text, IsAdmin = false };
		}
	}
}
