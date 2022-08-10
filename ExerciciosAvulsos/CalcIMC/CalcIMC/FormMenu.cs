using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Calculadoras
{
    public partial class FormMenu : Form
    {
        public FormMenu()
        {
            InitializeComponent();
        }

        private void btnIMC_Click(object sender, EventArgs e)
        {
            this.Hide();
            FormIMC formIMC = new();
            formIMC.ShowDialog();
            this.Show();
        }

        private void btnCalc_Click(object sender, EventArgs e)
        {
            this.Hide();
            FormCalc formCalc = new();
            formCalc.ShowDialog();
            this.Show();
        }
    }
}
