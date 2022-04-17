using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Entidades;

namespace MiCalculadora
{
    public partial class FormCalculadora : Form
    {
        
        public FormCalculadora()
        {
            InitializeComponent();
        }
        /// <summary>
        /// Llama a la funcion limpiar
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnLimpiar_Click(object sender, EventArgs e)
        {
            Limpiar();
            // Desactivo los botones de binario/decimal
            this.btnConvertirABinario.Enabled = false;
            this.btnConvertirADecimal.Enabled = false;
        }
        /// <summary>
        /// Pone en "vacio" los campos del formulario
        /// </summary>
        private void Limpiar()
        {
            this.txtNumero1.Text = "";
            this.txtNumero2.Text = "";
            this.lblResultado.Text = "";
            //this.cmbOperador.Text = "";
            this.cmbOperador.SelectedIndex = this.cmbOperador.FindStringExact(" ");
            this.lstOperaciones.Items.Clear();
        }
        /// <summary>
        /// Al iniciar el formulario deshabilita los botones para vonertir decimal-binario y pone el operador en blanco
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void FormCalculadora_Load(object sender, EventArgs e)
        {
            Limpiar();
            // cargo en el combo de operador el primer valor " "
            this.cmbOperador.SelectedIndex = this.cmbOperador.FindStringExact(" ");
            // Desactivo los botones de binario/decimal
            this.btnConvertirABinario.Enabled = false;
            this.btnConvertirADecimal.Enabled = false;
        }
        /// <summary>
        /// Es la funcion que se llama al cerrar el form, pide confirmacion para cerrar
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>        
        private void FormCalculadora_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (e.CloseReason == CloseReason.UserClosing)
            {
                DialogResult resultado = MessageBox.Show("¿Seguro de querer salir?", "Salir", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (resultado != DialogResult.Yes)
                {
                    e.Cancel = true;
                }
            }
        }
        /// <summary>
        /// Llama a la funcion para cerrar, pide confirmacion
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnCerrar_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        /// <summary>
        /// Valida si se va a dividir por cero, llama a la funcion operar
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnOperar_Click(object sender, EventArgs e)
        {
            // si no se cargó nada en los operandos y el operador, muestro 0 + 0
            if (this.txtNumero1.Text == "")
            {
                this.txtNumero1.Text = "0";
            }
            if (this.txtNumero2.Text == "")
            {
                this.txtNumero2.Text = "0";
            }
            if (this.cmbOperador.SelectedIndex == 0)
            {
                this.cmbOperador.SelectedIndex = 1;
            }
            // tomo los valores de los operandos
            string numero1 = this.txtNumero1.Text;
            string numero2 = this.txtNumero2.Text;
            // tomo el valor del operador
            string operador = this.cmbOperador.GetItemText(this.cmbOperador.SelectedItem);
            // si quiere dividir por cero mando alerta de error al label de resultado
            if (numero2 == "0" && operador == "/")
            {
                this.lblResultado.Text = "No se puede dividir por cero";
                this.btnConvertirABinario.Enabled = false;
                this.btnConvertirADecimal.Enabled = false;
            }
            else // si no, opero normal
            {

                // mando a operar
                double resultado = Operar(numero1, numero2, operador);
                // Mando el resultado al label de resultado
                this.lblResultado.Text = resultado.ToString();
                // Agrego al historial de operaciones            
                this.lstOperaciones.Items.Insert(0, $"{this.txtNumero1.Text} {operador} {this.txtNumero2.Text} = {resultado}");
                // Activo los botones de binario/decimal
                this.btnConvertirABinario.Enabled = true;
                this.btnConvertirADecimal.Enabled = true;
            }
        }
        /// <summary>
        /// Recibe operandos y operador , y usa la funcion operar de la clase calculadora
        /// </summary>
        /// <param name="numero1"></param>
        /// <param name="numero2"></param>
        /// <param name="operador"></param>
        /// <returns></returns>
        private static double Operar(string numero1, string numero2, string operador)
        {
            Operando n1 = new Operando(numero1);
            Operando n2 = new Operando(numero2);
            char operadorChar = char.Parse(operador);
            double resultado = Calculadora.Operar(n1, n2, operadorChar);
            return resultado;
        }
        /// <summary>
        /// Llama a la funcion para convertir de decimal a binario, avisa que no se puede en caso que no se pueda
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnConvertirABinario_Click(object sender, EventArgs e)
        {
            if (this.lblResultado.Text != "")
            {
                string numeroBinario;
                string numeroStr = this.lblResultado.Text;
                bool resultado = double.TryParse(numeroStr, out double numero);
                if (resultado)
                {
                    Operando numeroAConvertir = new Operando();
                    numeroBinario = numeroAConvertir.DecimalBinario(numero);

                }
                else
                {
                    numeroBinario = "No se puede convertir";
                }
                this.lblResultado.Text = numeroBinario;
            }
        }
        /// <summary>
        /// Llama a la funcion para convertir de binario a decimal
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnConvertirADecimal_Click(object sender, EventArgs e)
        {
            if (this.lblResultado.Text != "")
            {
                string numero = this.lblResultado.Text;
                Operando numeroAConvertir = new Operando();
                string numeroDecimal = numeroAConvertir.BinarioDecimal(numero);
                this.lblResultado.Text = numeroDecimal;
            }
        }
    }
}