using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ProyectoArlette.Formas;

namespace ProyectoArlette.Formas
{
    public partial class FormaHome : Form
    {
        public FormaHome()
        {
            InitializeComponent();
        }

        private void salirToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void areaDelTrianguloToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FormaTriangulo triangulo = new FormaTriangulo();
            triangulo.Show();

        }

        private void pesosAEurosYDolaresToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FormaPesos pesos = new FormaPesos();
            pesos.Show();
        }

        private void FormaHome_Load(object sender, EventArgs e)
        {

        }

        private void numeroDeLatidosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FormaLatidos latidos = new FormaLatidos();
            latidos.Show();
            Hide();
        }

        private void fabricaDeTalaveraToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FormaTalavera talavera = new FormaTalavera();
            talavera.Show();
        }

        private void ecuacionDeSegundoGradoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FormaEcuacion ecuacion = new FormaEcuacion();
            ecuacion.Show();
        }

        private void visorDeImagenesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FormaImagenes imagenes = new FormaImagenes();
            imagenes.Show();
        }

        private void calculadoraToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FormaCalculadora forma = new FormaCalculadora();
            forma.Show();
        }
    }
    }

