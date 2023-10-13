using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ProyectoArlette.Formas
{
    public partial class FormaPesos : Form
    {
        public FormaPesos()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {

        }

        private void Calcular_Click(object sender, EventArgs e)
        {
            double tasaDolar = 0.051; // Tasa de cambio de 1 peso mexicano a dólar
            double tasaEuro = 0.046;  // Tasa de cambio de 1 peso mexicano a euro

            if (double.TryParse(textPesos.Text, out double pesos) && pesos >= 0)
            {
                // Calcular la mitad de la cantidad ingresada
                double mitadPesos = pesos / 2;

                // Calcular el equivalente en dólares y euros para la mitad
                double mitadDolares = mitadPesos * tasaDolar;
                double mitadEuros = mitadPesos * tasaEuro;

                // Mostrar el resultado en un MessageBox
                string mensaje = $"Mitad en dólares: {mitadDolares:F2}\n" +
                                 $"Mitad en euros: {mitadEuros:F2}";

                MessageBox.Show(mensaje, "Conversión de Moneda");
            }
            else
            {
                MessageBox.Show("Por favor, ingrese una cantidad valida.", "Error de Entrada");
            }
        }
    }
}



