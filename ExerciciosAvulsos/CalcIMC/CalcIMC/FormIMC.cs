namespace Calculadoras
{
    public partial class FormIMC : Form
    {
        public FormIMC()
        {
            InitializeComponent();
        }
        private void CalcIMC_Load(object sender, EventArgs e)
        { 

        }

        private void FormIMC_Load(object sender, EventArgs e)
        {
            lblResultado.Text = "teste";
            //lblResultado.Visible = true;
        }

        private void btnCalcular_Click(object sender, EventArgs e)
        {
            double peso, altura;
            peso = Convert.ToDouble(txtPeso.Text);
            altura = Convert.ToDouble(txtAltura.Text) / 100;
            var(descricaoIMC, resultadoIMC) = CalcularIMC(peso, altura);
            lblResultado.Visible = true;
            lblResultado.Text = $"{descricaoIMC}\nSeu IMC é de {resultadoIMC}";
        }

        private (string, double) CalcularIMC (double p, double a)
        {
            double imc = p / (a * a);
            var resultado = imc switch
            {
                < 20 => "Abaixo do peso",
                >= 20 and < 25 => "Peso normal",
                >= 25 and < 30 => "Sobre peso",
                >= 30 and < 40 => "Obeso",
                _ => "Obeso mórbido"
            };

            return (resultado, imc);
        }

        private void btnLimpar_Click(object sender, EventArgs e)
        {
            txtAltura.Clear();
            txtPeso.Clear();
            lblResultado.Text = "";
            lblResultado.Visible = false;
            txtAltura.Focus();
        }

        private void btnVoltar_Click(object sender, EventArgs e)
        {
            this.Hide();
            FormMenu f = new();
            f.Show();
            this.Close();
        }
    }
}