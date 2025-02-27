using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using QLThuvien.GUI;

namespace QLThuvien
{
    public partial class Form1: Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void sachToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SachForm sachForm = new SachForm();
            sachForm.Show();
            this.Hide();
        }
    }
}
