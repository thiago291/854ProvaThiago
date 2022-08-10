using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Calculadoras
{
    public partial class FormCalc : Form
    {
        public FormCalc()
        {
            InitializeComponent();
        }

        private void FormCalc_Load(object sender, EventArgs e)
        {

        }

        private void btn1_Click(object sender, EventArgs e)
        {
            if (lblTela.Text.Length == 1 && lblTela.Text == "0")

                lblTela.Text = "1";
            else
                lblTela.Text += '1';
        }

        private void btn2_Click(object sender, EventArgs e)
        {
            if (lblTela.Text.Length == 1 && lblTela.Text == "0")

                lblTela.Text = "2";
            else
                lblTela.Text += '2';
        }

        private void btn3_Click(object sender, EventArgs e)
        {
            if (lblTela.Text.Length == 1 && lblTela.Text == "0")

                lblTela.Text = "3";
            else
                lblTela.Text += '3';
        }

        private void btn4_Click(object sender, EventArgs e)
        {
            if (lblTela.Text.Length == 1 && lblTela.Text == "0")

                lblTela.Text = "4";
            else
                lblTela.Text += '4';
        }
        private void btn5_Click(object sender, EventArgs e)
        {
            if (lblTela.Text.Length == 1 && lblTela.Text == "0")

                lblTela.Text = "5";
            else
                lblTela.Text += '5';
        }
        private void btn6_Click(object sender, EventArgs e)
        {
            if (lblTela.Text.Length == 1 && lblTela.Text == "0")

                lblTela.Text = "6";
            else
                lblTela.Text += '6';
        }
        private void btn7_Click(object sender, EventArgs e)
        {
            if (lblTela.Text.Length == 1 && lblTela.Text == "0")

                lblTela.Text = "7";
            else
                lblTela.Text += '7';
        }
        private void btn8_Click(object sender, EventArgs e)
        {
            if (lblTela.Text.Length == 1 && lblTela.Text == "0")

                lblTela.Text = "8";
            else
                lblTela.Text += '8';
        }
        private void btn9_Click(object sender, EventArgs e)
        {
            if (lblTela.Text.Length == 1 && lblTela.Text == "0")

                lblTela.Text = "9";
            else
                lblTela.Text += '9';
        }
        private void btn0_Click(object sender, EventArgs e)
        {
            if (lblTela.Text.Length != 1 || lblTela.Text != "0")
                lblTela.Text += '0';
        }

        private void btnLimpar_Click(object sender, EventArgs e)
        {
            lblTela.Text = "0";
            lblInputsSalvos.Text = "";
        }

        private void btnMais_Click(object sender, EventArgs e)
        {
            if (lblInputsSalvos.Text != "" && lblInputsSalvos.Text[lblInputsSalvos.Text.Length - 1] == '=')
                lblInputsSalvos.Text = lblTela.Text + '+';
            else
                lblInputsSalvos.Text += lblTela.Text + '+';
            lblTela.Text = "0";
        }

        private void btnMenos_Click(object sender, EventArgs e)
        {
            if (lblInputsSalvos.Text != "" && lblInputsSalvos.Text[lblInputsSalvos.Text.Length - 1] == '=')
                lblInputsSalvos.Text = lblTela.Text + '-';
            else
                lblInputsSalvos.Text += lblTela.Text + '-';
            lblTela.Text = "0";
        }

        private void btnVezes_Click(object sender, EventArgs e)
        {
            if (lblInputsSalvos.Text != "" && lblInputsSalvos.Text[lblInputsSalvos.Text.Length - 1] == '=')
                lblInputsSalvos.Text = lblTela.Text + '*';
            else
                lblInputsSalvos.Text += lblTela.Text + '*';
            lblTela.Text = "0";

        }

        private void btnDiv_Click(object sender, EventArgs e)
        {
            if (lblInputsSalvos.Text != "" && lblInputsSalvos.Text[lblInputsSalvos.Text.Length - 1] == '=')
                lblInputsSalvos.Text = lblTela.Text + '/';
            else
                lblInputsSalvos.Text += lblTela.Text + '/';
            lblTela.Text = "0";
        }

        private void btnIgual_Click(object sender, EventArgs e)
        {
            if (lblInputsSalvos.Text[lblInputsSalvos.Text.Length - 1] != '=')
            {
                lblInputsSalvos.Text += lblTela.Text;
                lblInputsSalvos.Text = Regex.Replace(lblInputsSalvos.Text,",",".");
                DataTable Calc = new DataTable();
                var result = Calc.Compute(lblInputsSalvos.Text, "");
                lblTela.Text = result.ToString();
                lblInputsSalvos.Text += '=';
            }
        }

        private void btnVoltar_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
