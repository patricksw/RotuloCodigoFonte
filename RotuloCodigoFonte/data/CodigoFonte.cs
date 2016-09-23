using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace RotuloCodigoFonte
{
    public class CodigoFonte
    {
        public double calcularSoma(double x, double y)
        {
            double result = 0;
            // double result1 = 9 + 8 / teste();
            result = x + y;
            return result;
        }

        public double calcularMultiplicacao(double x, double y)
        {
            double result = 0;
            result = x * y;
            return result;
        }

        public string executaCalculo(double n)
        {
            double valueSoma = 0;
            double valueMulti = 0;

            for (int i = 0; i < n; i++)
            {
                valueSoma += calcularSoma(valueSoma, n);
                double temp = calcularMultiplicacao(valueMulti, n);
                if (temp <= 0)
                    valueMulti += 1;
                else
                    valueMulti += temp;
            }

            return "O Valor da Soma eh: " + valueSoma + " O Valor da Multiplicacao eh: " + valueMulti;
        }
    }
}