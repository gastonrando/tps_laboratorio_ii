using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public static class Calculadora
    {
        /// <summary>
        /// Valida que el operando sea -, *, /, por defecto esta el +
        /// </summary>
        /// <param name="operador"></param>
        /// <returns></returns>
        private static char ValidarOperador(char operador)
        {
            if (operador != '-' && operador != '*' && operador != '/')
            {
                operador = '+';
            }
            return operador;
        }
        /// <summary>
        /// recibe los operando y operadores y realiza las operaciones
        /// </summary>
        /// <param name="num1"></param>
        /// <param name="num2"></param>
        /// <param name="operador"></param>
        /// <returns></returns>
        public static double Operar(Operando num1, Operando num2, char operador)
        {
            double resultado = 0;
            switch (ValidarOperador(operador))
            {
                case '+':
                    resultado = num1 + num2;
                    break;
                case '-':
                    resultado = num1 - num2;
                    break;
                case '*':
                    resultado = num1 * num2;
                    break;
                case '/':
                    resultado = num1 / num2;
                    break;
            }
            return resultado;
        }
    }
}
