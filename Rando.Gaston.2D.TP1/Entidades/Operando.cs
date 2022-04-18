using System;
using System.Text;

namespace Entidades
{
    public class Operando
    {   
        //Atributo
        private double numero;

        private string Numero
        {
            set { this.numero = ValidarOperando(value); }
        }

        /// <summary>
        /// Pasa el resultado de binario a decimal
        /// </summary> mide la longitud del numero para llevar a cabo la conversion, reversa el sentido de la cadena
        /// <param name="binario">La variable a transformar es string</param>
        /// <returns></returns> retorna un string del numero en binario, un mensaje o no hace nada si el numero no es binario.
        public string BinarioDecimal(string binario)
        {
            int tamanio = binario.Length;
            int calculo = 0;
            string retorno;

            if (EsBinario(binario))
            {
                foreach (char caracter in binario)
                {
                    tamanio--;

                    if (caracter == '1')
                    {
                        calculo += (int)Math.Pow(2, tamanio);
                    }
                }
                retorno = calculo.ToString();
            }
            else
            {
                retorno = "Valor invalido";
            }
            return retorno;
        }


        /// <summary>
        /// Si es posible, pasa de decimal a binario en double
        /// </summary>
        /// <param name="numero">Recibe el numero a convertir</param>
        /// <returns></returns>devuelve el numero en binario
        public string DecimalBinario(double numero)
        {
            int resto;
            int numeroAbosoluto = Math.Abs((int)numero);
            string resultado = "";

            if (numeroAbosoluto > 0)
            {
                while (numeroAbosoluto != 0)
                {
                    resto = numeroAbosoluto % 2;
                    numeroAbosoluto /= 2;
                    resultado += resto.ToString();
                }
                char[] arrayDeCaracteres = resultado.ToCharArray();
                Array.Reverse(arrayDeCaracteres);
                resultado = new string(arrayDeCaracteres);
            }
            else
            {
                resultado = "Valor Invalido";
            }
            return resultado;
        }

        /// <summary>
        /// Si es posible, pasa de decimal a binario en string
        /// </summary>
        /// <param name="numero"></param>
        /// <returns></returns>
        public string DecimalBinario(string numero)
        {
            string resultado = "";
            double retorno;

            if (double.TryParse(numero, out retorno) == true)
            {
                resultado = DecimalBinario(retorno);
            }
            return resultado;
        }

        //Constructor
        public Operando()
        {
            this.numero = 0;
        }
        
        //Constructor
        public Operando(double numero)
        {
            this.numero = numero;
        }

        public Operando(string strNumero)
        {
            Numero = strNumero;

        }
        public static double operator -(Operando n1, Operando n2)
        {
            return n1.numero - n2.numero;
        }
        public static double operator *(Operando n1, Operando n2)
        {
            return n1.numero * n2.numero;
        }
        public static double operator /(Operando n1, Operando n2)
        {
            double resultado;
            if (n2.numero != 0)
            {
                resultado = n1.numero / n2.numero;
            }
            else
            {
                resultado = double.MinValue;
            }
            return resultado;
        }
        public static double operator +(Operando n1, Operando n2)
        {
            return n1.numero + n2.numero;
        }

        /// <summary>
        /// revisa que el numero sea binario
        /// </summary>
        /// <param name="binario"></param>
        /// <returns></returns>
        private bool EsBinario(string binario)
        {
            bool retorno = true;
            for (int i = 0; i < binario.Length; i++)
            {
                if (binario[i] != '0' && binario[i] != '1')
                {
                    retorno = false;
                    break;
                }
            }
            return retorno;
        }
        /// <summary>
        /// valida los numeros ingresados para poder operar
        /// </summary>
        /// <param name="strNumero"></param>
        /// <returns></returns>
        private double ValidarOperando(string strNumero)
        {
            double retorno;
            
            strNumero = strNumero.Replace('.', ',');

            if (double.TryParse(strNumero, out retorno) == false)
            {
                retorno = 0;
            }
            
        return retorno;
        }


    }
}