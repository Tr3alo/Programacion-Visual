using System;
using System.Data; // para DataTable().Compute
using System.Globalization;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Calculator_Sixseven
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private bool IsPlainNumber(string s)
        {
            if (string.IsNullOrWhiteSpace(s)) return false;
            // intenta parsear con InvariantCulture para '.' como separador decimal
            return double.TryParse(s, NumberStyles.Number, CultureInfo.InvariantCulture, out _);
        }

        private void AppendOperatorToScreen(string op)
        {
            if (txtScreen.TextLength == 0)
            {
                // si está vacío y quieres permitir signos iniciales, podrías manejar +/-. Aquí no hacemos nada.
                return;
            }

            // si el último caracter ya es un operador, lo reemplazamos
            char last = txtScreen.Text[txtScreen.Text.Length - 1];
            if ("+-*/%^".Contains(last))
            {
                txtScreen.Text = txtScreen.Text.Substring(0, txtScreen.Text.Length - 1) + op;
            }
            else
            {
                txtScreen.Text += op;
            }
        }

        private bool TryGetScreenValue(out double value)
        {
            value = 0;
            string s = txtScreen.Text?.Trim() ?? "";

            // Primero intenta con la cultura actual (por si usas ',' como decimal)
            if (double.TryParse(s, NumberStyles.Number, CultureInfo.CurrentCulture, out value))
                return true;

            // Luego intenta con InvariantCulture (punto decimal)
            if (double.TryParse(s, NumberStyles.Number, CultureInfo.InvariantCulture, out value))
                return true;

            // No es un número "plano"
            return false;
        }



        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }
        //variables
        string operador = "";
        double num1 = 0;
        double num2 = 0;
        double memoria = 0;
        private void btnClear_Click(object sender, EventArgs e)
        {
            txtScreen.Text = "";
            num1 = 0;
            num2 = 0;
            operador = "";

        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            if (txtScreen.TextLength == 1) txtScreen.Text = "";
            else txtScreen.Text = txtScreen.Text.Substring(0, txtScreen.Text.Length - 1);

        }

        private void btnUno_Click(object sender, EventArgs e)
        {
            if(txtScreen.TextLength == 0) txtScreen.Text="";
            txtScreen.Text = txtScreen.Text + 1;
        }

        private void btnDos_Click(object sender, EventArgs e)
        {
            if (txtScreen.TextLength == 0) txtScreen.Text = "";
            txtScreen.Text = txtScreen.Text + 2;
        }

        private void btnTres_Click(object sender, EventArgs e)
        {
            if (txtScreen.TextLength == 0) txtScreen.Text = "";
            txtScreen.Text = txtScreen.Text + 3;
        }

        private void btnCuatro_Click(object sender, EventArgs e)
        {
            if (txtScreen.TextLength == 0) txtScreen.Text = "";
            txtScreen.Text = txtScreen.Text + 4;
        }

        private void btnCinco_Click(object sender, EventArgs e)
        {
            if (txtScreen.TextLength == 0) txtScreen.Text = "";
            txtScreen.Text = txtScreen.Text + 5;
        }

        private void btnSeis_Click(object sender, EventArgs e)
        {
            if (txtScreen.TextLength == 0) txtScreen.Text = "";
            txtScreen.Text = txtScreen.Text + 6;
        }

        private void btnSiete_Click(object sender, EventArgs e)
        {
            if (txtScreen.TextLength == 0) txtScreen.Text = "";
            txtScreen.Text = txtScreen.Text + 7;
        }

        private void btnOcho_Click(object sender, EventArgs e)
        {
            if (txtScreen.TextLength == 0) txtScreen.Text = "";
            txtScreen.Text = txtScreen.Text + 8;
        }

        private void btnNueve_Click(object sender, EventArgs e)
        {
            if (txtScreen.TextLength == 0) txtScreen.Text = "";
            txtScreen.Text = txtScreen.Text + 9;
        }

        private void btnCero_Click(object sender, EventArgs e)
        {
            txtScreen.Text = txtScreen.Text + "0";
        }

        private void btnPunto_Click(object sender, EventArgs e)
        {
            txtScreen.Text = txtScreen.Text + ".";
        }

        private void button1_Click(object sender, EventArgs e)
        {
            operador =  "+";
            num1 = Convert.ToDouble(txtScreen.Text);
            txtScreen.Text = "";

            if (IsPlainNumber(txtScreen.Text))
            {
                operador = "+";
                num1 = Convert.ToDouble(txtScreen.Text, CultureInfo.InvariantCulture);
                txtScreen.Text = "";
            }
            else
            {
                // estamos escribiendo una expresión (posiblemente con paréntesis), así que añadimos '+' al texto
                AppendOperatorToScreen("+");
            }
        }

        private void btnResta_Click(object sender, EventArgs e)
        {
            operador = "-";
            num1 = Convert.ToDouble(txtScreen.Text);
            txtScreen.Text = "";

            if (IsPlainNumber(txtScreen.Text))
            {
                operador = "-";
                num1 = Convert.ToDouble(txtScreen.Text, CultureInfo.InvariantCulture);
                txtScreen.Text = "";
            }
            else
            {
                // estamos escribiendo una expresión (posiblemente con paréntesis), así que añadimos '+' al texto
                AppendOperatorToScreen("-");
            }
        }

        private void btnMultiplicacion_Click(object sender, EventArgs e)
        {
            operador = "*";
            num1 = Convert.ToDouble(txtScreen.Text);
            txtScreen.Text = "";
            if (IsPlainNumber(txtScreen.Text))
            {
                operador = "*";
                num1 = Convert.ToDouble(txtScreen.Text, CultureInfo.InvariantCulture);
                txtScreen.Text = "";
            }
            else
            {
                // estamos escribiendo una expresión (posiblemente con paréntesis), así que añadimos '+' al texto
                AppendOperatorToScreen("*");
            }

            if (txtScreen.TextLength == 0) return;

            char last = txtScreen.Text[txtScreen.Text.Length - 1];
            if ("+-*/%^".Contains(last))
                txtScreen.Text = txtScreen.Text.Substring(0, txtScreen.Text.Length - 1) + "*";
            else
                txtScreen.Text += "*";
        }

        private void btnDivision_Click(object sender, EventArgs e)
        {
            operador = "/";
            num1 = Convert.ToDouble(txtScreen.Text);
            txtScreen.Text = "";

            if (IsPlainNumber(txtScreen.Text))
            {
                operador = "/";
                num1 = Convert.ToDouble(txtScreen.Text, CultureInfo.InvariantCulture);
                txtScreen.Text = "";
            }
            else
            {
                // estamos escribiendo una expresión (posiblemente con paréntesis), así que añadimos '+' al texto
                AppendOperatorToScreen("/");
            }
        }

        private void button18_Click(object sender, EventArgs e)
        {
            string expr = txtScreen.Text?.Trim() ?? "";

            // 1) Intentar evaluar la expresión con DataTable().Compute (soporta paréntesis y + - * / %).
            try
            {
                // Nota: DataTable.Compute NO interpreta '^' como potencia; lo trataríamos aparte si lo necesitas.
                var resultObj = new DataTable().Compute(expr, null);
                // Convertir a string respetando la cultura del usuario
                txtScreen.Text = Convert.ToString(resultObj, CultureInfo.CurrentCulture);
                return;
            }
            catch
            {
                // Si falla (sintaxis mixta o ^), caemos a la lógica tradicional.
            }

            // 2) Lógica clásica: num1 operador num2 (fallback)
            if (!TryGetScreenValue(out double v))
            {
                MessageBox.Show("Expresión incompleta o formato inválido.");
                return;
            }

            num2 = v;
            double resultOperation = 0;

            switch (operador)
            {
                case "+":
                    resultOperation = num1 + num2;
                    break;
                case "-":
                    resultOperation = num1 - num2;
                    break;
                case "*":
                    resultOperation = num1 * num2;
                    break;
                case "/":
                    if (num2 != 0) resultOperation = num1 / num2;
                    else { MessageBox.Show("No se puede dividir por cero."); return; }
                    break;
                case "%":
                    if (num2 != 0) resultOperation = num1 % num2;
                    else { MessageBox.Show("No se puede calcular el residuo con divisor cero."); return; }
                    break;
                case "^":
                    resultOperation = Math.Pow(num1, num2);
                    break;
                default:
                    MessageBox.Show("Operación no válida.");
                    return;
            }

            txtScreen.Text = resultOperation.ToString(CultureInfo.CurrentCulture);
        }


        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void btnMplus_Click(object sender, EventArgs e)
        {
            double current = Convert.ToDouble(txtScreen.Text); //toma el valor en la pantalla.
            memoria += current; //suma el valor del current a la memoria.
            txtScreen.Text = "0"; //opcional, mostrar por pantalla 0
        }

        private void btnMminus_Click(object sender, EventArgs e)
        {
            //aqui es lo contrario, en vez de sumar
            double current = Convert.ToDouble(txtScreen.Text); //toma el valor en la pantalla.
            memoria -= current; //se resta.
            txtScreen.Text = "0"; //opcional, mostrar por pantalla 0
        }

        private void btnMR_Click(object sender, EventArgs e)
        {
            txtScreen.Text = memoria.ToString(); //aqui se recupera el valor y lo muestra :D
        }

        private void btnMC_Click(object sender, EventArgs e)
        {
            memoria = 0; //limpiar la memoria, osea memory clear, (no sabia que significaba eso)
            txtScreen.Text = "0"; //opcional, mostrar por pantalla 0
        }

        private void btnPot_Click(object sender, EventArgs e)
        {
            operador = "^"; //se guarda el operador potencia
            num1 = Convert.ToDouble(txtScreen.Text); //aqui se guarda el primer operando
            txtScreen.Text = "0"; //se limpia la pantalla para que se lea la potencia.
        }

        private void btnPi_Click(object sender, EventArgs e)
        {
            txtScreen.Text = Math.PI.ToString(); //Escribirá el valor de PI en la pantalla.
        }

        private void btnPar1_Click(object sender, EventArgs e)
        {
            txtScreen.Text = txtScreen.Text + "(";
        }

        private void btnPar2_Click(object sender, EventArgs e)
        {
            txtScreen.Text = txtScreen.Text + ")";
        }

        private void btnLog_Click(object sender, EventArgs e)
        {
            double val = Convert.ToDouble(txtScreen.Text); //Obtiene el valor actual
            if (val > 0) //comprueba el dominio de log base 10
            {
                txtScreen.Text = Math.Log10(val).ToString(); //calcula el log base 10
            }
            else //si no cumple, error.
            {
                MessageBox.Show("Logaritmo solo definido para valores > 0.");
            }
        }

        private void btnRad_Click(object sender, EventArgs e)
        {
            double val = Convert.ToDouble(txtScreen.Text);
            if (val >= 0)
            {
                txtScreen.Text= Math.Sqrt(val).ToString(); //aqui se calcula la raiz CUADRADA de val si cumple la condicion. :D
            }
            else
            {
                MessageBox.Show("No se puede mostrar un radical de un número negativo");
            }
        }

        private void btnOver_Click(object sender, EventArgs e)
        {
            double val = Convert.ToDouble(txtScreen.Text);
            if (val != 0)
            {
                txtScreen.Text= (1.0 /val ).ToString(); //basicamente entra aca si el valor es distinto de 0
            }
            else
            {
                MessageBox.Show("No se puede hacer una division entre 0");
            }
        }

        private void btnFactorial_Click(object sender, EventArgs e)
        {
            double val = Convert.ToDouble(txtScreen.Text);
            if (val < 0 || Math.Floor(val) != val) //verificamos el entero a ver si no es negativo
            {
                MessageBox.Show("El Factorial esta definido solo para enteros, no para negativos");
                return;
            }
            if (val > 170)
            { 
                MessageBox.Show("El factorial es MUUUY grande para hacer un calculo con precision"); //evitar calculos erroneos pq eso es muucho
                return;
            }

            double result = 1; //si todo va bien, inicia un acumulador
            for (int i = 1; i <= (int)val; i++)  // calculo de factorial 
            {
                result *= i;
            
            }
            txtScreen.Text = result.ToString(); //resultado :DDDD
        }
    }
}
