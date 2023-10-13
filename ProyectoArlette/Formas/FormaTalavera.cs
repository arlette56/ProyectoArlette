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
    public partial class FormaTalavera : Form
    {
        public FormaTalavera()
        {
            InitializeComponent();
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (double.TryParse(txtSalarioActual.Text, out double salarioActual) && salarioActual >= 0)
            {
                // Calcular el nuevo salario con el aumento del 25%
                double nuevoSalario = salarioActual + (salarioActual * 0.25);

                // Mostrar el nuevo salario en un MessageBox
                MessageBox.Show($"Nuevo salario: {nuevoSalario:C}", "Resultado");
            }
            else
            {
                MessageBox.Show("Ingresa un salario válido.", "Error de Entrada");
            }
        }
    }
}


