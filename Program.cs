using System;
using System.Drawing;
using System.Globalization;
using System.Windows.Forms;

namespace CalculadoraIMC
{
    public class FormIMC : Form
    {
        // Controlos da interface gráfica exigidos pelo enunciado
        private TextBox txtPeso;
        private TextBox txtAltura;
        private Button btnCalcular;
        private Label lblResultado;

        public FormIMC()
        {
            // Configurações da janela
            Text = "Calculadora de IMC";
            ClientSize = new Size(320, 210);
            FormBorderStyle = FormBorderStyle.FixedDialog;
            MaximizeBox = false;
            StartPosition = FormStartPosition.CenterScreen;

            // Rótulo e campo de texto para introduzir o peso em quilogramas
            var lblPeso = new Label { Text = "Peso (kg):", Location = new Point(20, 25), AutoSize = true };
            txtPeso = new TextBox { Name = "txtPeso", Location = new Point(140, 22), Width = 150 };

            // Rótulo e campo de texto para introduzir a altura em metros
            var lblAltura = new Label { Text = "Altura (m):", Location = new Point(20, 65), AutoSize = true };
            txtAltura = new TextBox { Name = "txtAltura", Location = new Point(140, 62), Width = 150 };

            // Botão para processar os dados
            btnCalcular = new Button
            {
                Name = "btnCalcular",
                Text = "Calcular",
                Location = new Point(20, 105),
                Size = new Size(270, 32)
            };
            btnCalcular.Click += btnCalcular_Click;

            // Etiqueta onde são apresentados o valor final do IMC e a respetiva classificação
            lblResultado = new Label
            {
                Name = "lblResultado",
                Text = "",
                Location = new Point(20, 150),
                Size = new Size(270, 45),
                Font = new Font("Segoe UI", 10F, FontStyle.Bold)
            };

            // Registo dos controlos no formulário
            Controls.AddRange(new Control[] { lblPeso, txtPeso, lblAltura, txtAltura, btnCalcular, lblResultado });
            AcceptButton = btnCalcular;
        }

        private void btnCalcular_Click(object? sender, EventArgs e)
        {
            // Conversão segura e validação do peso
            if (!TryParseNumero(txtPeso.Text, out double peso) || peso <= 0)
            {
                lblResultado.ForeColor = Color.DarkRed;
                lblResultado.Text = "Peso inválido. Introduza um número positivo (ex.: 70 ou 70,5).";
                txtPeso.Focus();
                return;
            }

            // Conversão segura e validação da altura
            if (!TryParseNumero(txtAltura.Text, out double altura) || altura <= 0)
            {
                lblResultado.ForeColor = Color.DarkRed;
                lblResultado.Text = "Altura inválida. Introduza um número positivo em metros (ex.: 1,75).";
                txtAltura.Focus();
                return;
            }

            // Fórmula padrão: peso dividido pelo quadrado da altura
            double imc = peso / (altura * altura);

            // Apresentação do valor final do IMC e respetiva classificação
            lblResultado.ForeColor = Color.Black;
            lblResultado.Text = $"IMC: {imc.ToString("F2", CultureInfo.GetCultureInfo("pt-PT"))}\nClassificação: {Classificar(imc)}";
        }

        /// <summary>
        /// Conversão segura de string para double:
        /// Suporta vírgula ou ponto decimal e garante validação estritamente numérica sem disparar exceções.
        /// </summary>
        private static bool TryParseNumero(string texto, out double valor)
        {
            texto = (texto ?? string.Empty).Trim().Replace(',', '.');
            return double.TryParse(texto, NumberStyles.AllowDecimalPoint,
                                   CultureInfo.InvariantCulture, out valor);
        }

        /// <summary>
        /// Classificação do IMC com base nas faixas da Organização Mundial da Saúde (OMS).
        /// </summary>
        private static string Classificar(double imc)
        {
            if (imc < 18.5) return "Abaixo do peso";
            if (imc < 25.0) return "Peso normal";
            if (imc < 30.0) return "Sobrepeso";
            if (imc < 35.0) return "Obesidade grau I";
            if (imc < 40.0) return "Obesidade grau II";
            return "Obesidade grau III";
        }

        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new FormIMC());
        }
    }
}
