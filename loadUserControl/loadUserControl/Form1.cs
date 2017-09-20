using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace loadUserControl
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void btnModule1_Click(object sender, EventArgs e)
        {
            if (!panel1.Controls.Contains(ucModule1.Instance))
            {
                panel1.Controls.Add(ucModule1.Instance);
                ucModule1.Instance.Dock = DockStyle.Fill;
                ucModule1.Instance.BringToFront();
            }
            else
            {
                ucModule1.Instance.BringToFront();
            }
        }

        private void btnModule2_Click(object sender, EventArgs e)
        {
            if (!panel1.Controls.Contains(ucModule2.Instance))
            {
                panel1.Controls.Add(ucModule2.Instance);
                ucModule2.Instance.Dock = DockStyle.Fill;
                ucModule2.Instance.BringToFront();
            }
            else
            {
                ucModule2.Instance.BringToFront();
            }
        }

        private void btnModule3_Click(object sender, EventArgs e)
        {
            if (!panel1.Controls.Contains(ucModule3.Instance))
            {
                panel1.Controls.Add(ucModule3.Instance);
                ucModule3.Instance.Dock = DockStyle.Fill;
                ucModule3.Instance.BringToFront();
            }
            else
            {
                ucModule3.Instance.BringToFront();
            }
        }
    }
}
