namespace TP1_WForms_2208
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            button1.Enabled = false;
            AtivaFuncoes();
        }

        double receita = 30000,
            imposto = 12500,
            numFunc = 9,
            salario = 1775.25;

        private DateTime cronometro = new();

        private async Task<string> FolhaDePagamento()
        {
            await Task.Delay(TimeSpan.FromMilliseconds(2000));
            return $"Valor da folha de pagamento: R$ {(numFunc * salario).ToString("0.00")}";
        }

        private async Task<string> Impostos()
        {
            await Task.Delay(TimeSpan.FromMilliseconds(3000));
            return $"Valor dos impostos: R$ {imposto.ToString("0.00")}";
        }

        private async Task<string> Receitas()
        {
            await Task.Delay(TimeSpan.FromMilliseconds(4000));
            return $"Receita do mês: R$ {receita.ToString("0.00")}";
        }

        private async Task<string> Despesas()
        {
            await Task.Delay(TimeSpan.FromMilliseconds(5000));
            return $"Despesas do mês: R$ {(imposto + (numFunc * salario)).ToString("0.00")}";
        }

        private async Task<string> ReceitaLiquida()
        {
            await Task.Delay(TimeSpan.FromMilliseconds(6000));
            return $"Receita líquida: R$ {(receita - imposto - (numFunc * salario)).ToString("0.00")}";
        }

        private async void AtivaFuncoes()
        {
            listBox1.Items.Clear();
            timer1.Interval = 1000;
            cronometro = new();
            timer1.Start();
            label1.Visible = true;
            label2.Visible = true;
            label2.Text = "Tempo: 0 segundos";

            label1.Text = @$"Iniciando os cálculos. 
Aguarde o final do processamento...";
            listBox1.Items.Add(await FolhaDePagamento());
            listBox1.Items.Add(await Impostos());
            listBox1.Items.Add(await Receitas());
            listBox1.Items.Add(await Despesas());
            listBox1.Items.Add(await ReceitaLiquida());

            button1.Enabled = true;
            timer1.Stop();
            label1.Text = $"Cálculos concluídos.";
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            cronometro = cronometro.AddSeconds(1);
            label2.Text = $"Tempo: {cronometro.Second} segundos";
        }

        private void Form1_Load(object sender, EventArgs e)
        {
        }
    }
}