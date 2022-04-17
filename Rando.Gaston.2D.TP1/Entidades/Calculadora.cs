using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public static class Calculadora
    {
        private static char ValidarOperador(char operador)
        {
            if (operador != '-' && operador != '*' && operador != '/')
            {
                operador = '+';
            }
            return operador;
        }
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
