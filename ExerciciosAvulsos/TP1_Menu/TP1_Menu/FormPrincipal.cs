using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TP1_Menu
{
    public partial class FormPrincipal : Form
    {
        public FormPrincipal()
        {
            InitializeComponent();
        }

        private void item1ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form1 f1 = new();
            f1.ShowDialog();
        }

        private void item2ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form2 f2 = new();
            f2.ShowDialog();
        }
    }
}
