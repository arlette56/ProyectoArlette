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
    public partial class FormaEcuacion : Form
    {
        public FormaEcuacion()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            double a, b, c;

            if (double.TryParse(textBox1.Text, out a) && double.TryParse(textBox2.Text, out b) && double.TryParse(textBox3.Text, out c))
            {
                if (a == 0)
                {
                    MessageBox.Show("El coeficiente 'a' no puede ser igual a cero (a = 0).", "Error");
                }
                else
                {
                    double discriminante = b * b - 4 * a * c;

                    if (discriminante > 0)
                    {
                        double x1 = (-b + Math.Sqrt(discriminante)) / (2 * a);
                        double x2 = (-b - Math.Sqrt(discriminante)) / (2 * a);
                        MessageBox.Show($"Raíces reales: x1 = {x1}, x2 = {x2}", "Resultado");
                    }
                    else if (discriminante == 0)
                    {
                        double x1 = -b / (2 * a);
                        MessageBox.Show($"Raíz real (raíz doble): x1 = {x1}", "Resultado");
                    }
                    else
                    {
                        double realPart = -b / (2 * a);
                        double imaginaryPart = Math.Sqrt(-discriminante) / (2 * a);
                        MessageBox.Show($"Raíces imaginarias: x1 = {realPart} + {imaginaryPart}i, x2 = {realPart} - {imaginaryPart}i", "Resultado");
                    }
                }
            }
            else
            {
                MessageBox.Show("Por favor, ingrese valores válidos para 'a', 'b' y 'c'.");
            }
         }

        private void label1_Click(object sender, EventArgs e)
        {

        }
    }
}
