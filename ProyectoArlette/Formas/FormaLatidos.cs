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
    public partial class FormaLatidos : Form
    {
        public FormaLatidos()
        {
            InitializeComponent();
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (int.TryParse(textEdad.Text, out int edad) && edad >= 0)
            {
                
                int fcm = 220 - edad;

                
                MessageBox.Show($"Su frecuencia máxima por minuto (FCM) es: {fcm} latidos por minuto.", "Resultado");
            }
            else
            {
                MessageBox.Show("Por favor, ingrese una edad válida y no negativa.", "Error de Entrada");
            }
        }
    }
}