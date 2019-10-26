using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MainWindow
{
	public partial class SingInWindow : Form
	{
		public SingInWindow()
		{
			InitializeComponent();
		}

		private void closeButton_Click(object sender, EventArgs e)
		{
			this.Close();
		}

		private void closeButton_MouseEnter(object sender, EventArgs e)
		{
			this.closeButton.BackColor = Color.Red;
		}

		private void closeButton_MouseLeave(object sender, EventArgs e)
		{
			this.closeButton.BackColor = Color.FromArgb(62, 128, 182);
		}

		Point lastPoint;
		private void topblokAuth_MouseMove(object sender, MouseEventArgs e)
		{
			if (e.Button == MouseButtons.Left)
			{
				this.Left += e.X - lastPoint.X;
				this.Top += e.Y - lastPoint.Y;
			}
		}

		private void topblokAuth_MouseDown(object sender, MouseEventArgs e)
		{
			lastPoint = new Point(e.X, e.Y);
		}
	}
}
