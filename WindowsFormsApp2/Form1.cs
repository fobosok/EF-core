using Microsoft.EntityFrameworkCore;
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
	public partial class Form1 : Form
	{
		RegForm RegForm = null;
		public Form1()
		{
			InitializeComponent();
			AdminInStock();
			RefreshData();
		}

		private void RefreshData()
		{
			using (ApplicationContext db = new ApplicationContext())
			{
				db.Users.Load();
				dataGridView1.DataSource = null;
				dataGridView1.DataSource = db.Users.Local.ToBindingList();
				db.SaveChanges();
			}
		}

		private void AdminInStock()
		{
			using (ApplicationContext db = new ApplicationContext())
			{
				bool adminInStock = false;
				var users = db.Users.ToList();
				foreach (User us in users)
				{
					if (us.IsAdmin)
					{
						adminInStock = true;
						break;
					}
				}
				if (!adminInStock)
				{
					FillTable();
				}
			}
		}

		private void FillTable()
		{
			User user1 = new User { Log = "admin", Pass = "admin", Phone = "+380684696969",IsAdmin = true };
			using (ApplicationContext db = new ApplicationContext())
			{
				db.Users.Add(user1);
				db.SaveChanges();
			}
		}

		private void dataGridView1_CellMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
		{
			using (ApplicationContext db = new ApplicationContext())
			{
				var users = db.Users.ToList();
				foreach(User us in users)
				{
					if (Convert.ToInt32(dataGridView1.CurrentRow.Cells[0].Value) == us.Id)
					{
						RegForm = new RegForm(this,us);
						if (RegForm.ShowDialog(this) == DialogResult.OK)
						{
							us.Log = RegForm.UserProp.Log;
							us.Pass = RegForm.UserProp.Pass;
							us.Phone = RegForm.UserProp.Phone;
							db.SaveChanges();
							RefreshData();
						}
						break;
					}
				}
			}
		}
	}
}
