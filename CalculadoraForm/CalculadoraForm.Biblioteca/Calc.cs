using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;

namespace CalculadoraForm.Biblioteca
{
    public class Calc
    {
        // ATRIBUTOS
        private double _valor1;
        private double _valor2;
        private double _resultado;
        private bool _resultadoActualizado;
        private string _error;


        // PROPIEDADES
        public double Valor1
        {
            get => _valor1;
            set
            {
                _valor1 = value;
                _resultadoActualizado = false;
                _error = "Se actualizaron los valores y el resultado está desactualizado";
            }
        }
        public double Valor2
        {
            get => _valor2;
            set
            {
                _valor2 = value;
                _resultadoActualizado = false;
                _error = "Se actualizaron los valores y el resultado está desactualizado";
            }
        }
        public double Resultado 
        {
            get
            {
                if (!_resultadoActualizado) return double.NaN;
                return _resultado;
            }
            private set 
            { 
                _resultado = value;
                _resultadoActualizado = true;
            } 
        }
        public string Error => _error;

        // MÉTODOS
        public Calc()
        {
            Valor1 = 0;
            Valor2 = 0;
            _resultadoActualizado = false;
            _error = "";
        }

        public double CalcularExpresion(string expresion)
        {
            string regex = @"^\s*(?<valA>-?\d+\.?\d*)\s*(?<op>[\+\*-/])\s*(?<valB>-?\d+\.?\d*)\s*$";

            Match match = System.Text.RegularExpressions.Regex.Match(expresion, regex);

            if (!match.Success)
            {
                _error = "La expresión de cálculo es incorrecta o no está soportada.";
                Resultado = double.NaN;
                return double.NaN;
            }
            else
            {
                if (!ValidarDouble(match.Groups["valA"].Value, out double v1) ||
                    !ValidarDouble(match.Groups["valB"].Value, out double v2))
                {
                    _error = "Los valores ingresados no se pueden convertir a números.";
                    Resultado = double.NaN;
                    return double.NaN;
                }

                // Camino feliz
                Valor1 = v1;
                Valor2 = v2;
                return Calcular(match.Groups["op"].Value);
            }
        }
        private double Calcular(string op)
        {
            switch (op)
            {
                case "+":
                    return Sumar();
                case "-":
                    return Restar();
                case "*":
                    return Multiplicar();
                case "/":
                    return Dividir();
                default:
                    return double.NaN;
            }
        }
        private bool ValidarDouble(string s, out double numero)
        {
            return double.TryParse(s, out numero);
        }
        public bool SetValor1(string s)
        {
            if( double.TryParse(s, out double valor))
            {
                Valor1 = valor;
                return true;
            }
            return false;
        }
        public bool SetValor2(string s)
        {
            if (double.TryParse(s, out double valor))
            {
                Valor2 = valor;
                return true;
            }
            return false;
        }
        public double Sumar()
        {
            Resultado = Valor1 + Valor2;
            return Resultado;
        }
        public double Restar()
        {
            Resultado = Valor1 - Valor2;
            return Resultado;
        }
        public double Multiplicar()
        {
            Resultado = Valor1 * Valor2;
            return Resultado;
        }
        public double Dividir()
        {
            if (_valor2 == 0)
            {
                _error = "No se puede dividir por cero.";
                return double.NaN;
            }

            Resultado = _valor1 / _valor2;

            return Resultado;
        }

    }
}
