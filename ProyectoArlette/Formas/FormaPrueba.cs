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
    public partial class FormaPrueba : Form
    {
        private Button addTimeButton1; // Definir addTimeButton a nivel de clase
        private int timeLeft = 30;

        public FormaPrueba()
        {
            InitializeComponent();
            InicializarBotonAgregarTiempo();

        }

        private void InicializarBotonAgregarTiempo()
        {
            this.Controls.Add(addTimeButton1);
        }
        private void ActualizarTextoTiempo()
        {
            timeLabel.Text = $"{timeLeft} segundos";
        }

        private void timer2_Tick(object sender, EventArgs e)
        {
            if (timeLeft > 0)
            {
                timeLeft--;
                ActualizarTextoTiempo();
            }
            else
            {
                timer1.Stop();
                timeLabel.Text = "¡Tiempo agotado!";
                MessageBox.Show("No terminaste a tiempo.", "Lo siento");
                startButton.Enabled = true;
            }
        }
        Random randomizer = new Random();
        int addend1;
        int addend2;

        int minuend;
        int subtrahend;

        int multiplicand;
        int multiplier;

        int dividend;
        int divisor;


        public void StartTheQuiz()
        {

            addend1 = randomizer.Next(51);
            addend2 = randomizer.Next(51);
            plusLeftLabel.Text = addend1.ToString();
            plusRightLabel.Text = addend2.ToString();
            sum.Value = 0;

            minuend = randomizer.Next(1, 101);
            subtrahend = randomizer.Next(1, minuend);
            minusLeftLabel.Text = minuend.ToString();
            minusRightLabel.Text = subtrahend.ToString();
            difference.Value = 0;

            multiplicand = randomizer.Next(2, 11);
            multiplier = randomizer.Next(2, 11);
            timesLeftLabel.Text = multiplicand.ToString();
            timesRightLabel.Text = multiplier.ToString();
            product.Value = 0;

            divisor = randomizer.Next(2, 11);
            int temporaryQuotient = randomizer.Next(2, 11);
            dividend = divisor * temporaryQuotient;
            dividedLeftLabel.Text = dividend.ToString();
            dividedRightLabel.Text = divisor.ToString();
            quotient.Value = 0;

            timeLeft = 30;
            timeLabel.Text = "30 seconds";
            timer1.Start();
        }

        private bool CheckTheAnswer()
        {
            if ((addend1 + addend2 == sum.Value)
                && (minuend - subtrahend == difference.Value)
                && (multiplicand * multiplier == product.Value)
                && (dividend / divisor == quotient.Value))
                return true;
            else
                return false;
        }

        private void FormaPrueba_Load(object sender, EventArgs e)
        {
            
        }

        private void startButton_Click(object sender, EventArgs e)
        {
            StartTheQuiz();
            startButton.Enabled = false;
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            if (CheckTheAnswer())
            {
                timer1.Stop();
                MessageBox.Show("You got all the answers right!",
                                "Congratulations!");
                startButton.Enabled = true;
            }
            else if (timeLeft > 0)
            {
                if (timeLeft > 5)
                {
                    timeLabel.BackColor = Color.Green;   
                }
                else
                {
                    timeLabel.BackColor = Color.Red;    
                }

                timeLeft = timeLeft - 1;
                timeLabel.Text = timeLeft + " seconds";

            }
            else
            {
                timer1.Stop();
                timeLabel.Text = "Time's up!";
                MessageBox.Show("You didn't finish in time.", "Sorry!");
                sum.Value = addend1 + addend2;
                difference.Value = minuend - subtrahend;
                product.Value = multiplicand * multiplier;
                quotient.Value = dividend / divisor;
                startButton.Enabled = true;
            }
        }

        private void answer_Enter(object sender, EventArgs e)
        {

            NumericUpDown answerBox = sender as NumericUpDown; 
            if (answerBox != null)
            {
                int lengthOfAnswer = answerBox.Value.ToString().Length;
                answerBox.Select(0, lengthOfAnswer);
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            timeLeft += 15;
            ActualizarTextoTiempo();


            addend1 = randomizer.Next(101, 201);
            addend2 = randomizer.Next(101, 201);
            plusLeftLabel.Text = addend1.ToString();
            plusRightLabel.Text = addend2.ToString();

            minuend = randomizer.Next(50, 101);
            subtrahend = randomizer.Next(1, minuend);
            minusLeftLabel.Text = minuend.ToString();
            minusRightLabel.Text = subtrahend.ToString();

            multiplicand = randomizer.Next(11, 21);
            multiplier = randomizer.Next(11, 21);
            timesLeftLabel.Text = multiplicand.ToString();
            timesRightLabel.Text = multiplier.ToString();

            divisor = randomizer.Next(6, 11);
            int temporaryQuotient = randomizer.Next(6, 11);
            dividend = divisor * temporaryQuotient;
            dividedLeftLabel.Text = dividend.ToString();
            dividedRightLabel.Text = divisor.ToString();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            timeLeft += 15;
            ActualizarTextoTiempo();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            FormaHome regreso = new FormaHome();
            regreso.Show();
            Hide();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            addend1 = randomizer.Next(21, 51);
            addend2 = randomizer.Next(21, 51);
            plusLeftLabel.Text = addend1.ToString();
            plusRightLabel.Text = addend2.ToString();

            minuend = randomizer.Next(11, 51);
            subtrahend = randomizer.Next(1, minuend);
            minusLeftLabel.Text = minuend.ToString();
            minusRightLabel.Text = subtrahend.ToString();

            multiplicand = randomizer.Next(3, 11);
            multiplier = randomizer.Next(3, 11);
            timesLeftLabel.Text = multiplicand.ToString();
            timesRightLabel.Text = multiplier.ToString();

            divisor = randomizer.Next(2, 6);
            int temporaryQuotient = randomizer.Next(2, 6);
            dividend = divisor * temporaryQuotient;
            dividedLeftLabel.Text = dividend.ToString();
            dividedRightLabel.Text = divisor.ToString();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            timeLeft -= 5;
            ActualizarTextoTiempo();
        }
    }
}
