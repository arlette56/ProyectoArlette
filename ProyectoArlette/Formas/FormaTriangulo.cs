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
    public partial class FormaTriangulo : Form
    {
        public FormaTriangulo()
        {
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (double.TryParse(textBox1.Text, out double baseTriangulo) && baseTriangulo >= 0 &&
    double.TryParse(textBox2.Text, out double alturaTriangulo) && alturaTriangulo >= 0)
            {
                
                double areaTriangulo = (baseTriangulo * alturaTriangulo) / 2;

                
                MessageBox.Show($"Área del triángulo: {areaTriangulo:F2}", "Resultado",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                
                MessageBox.Show("Ingrese valores validos.", "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}


