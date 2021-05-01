using CalculadoraForm.Biblioteca;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CalculadoraForm.Formulario
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }


        private void btnCalcularExpr_Click(object sender, EventArgs e)
        {
            decimal resultado;

            Calc.CalcularExpresion(txtExpresion.Text, out resultado);

            lblResultado.Text = resultado.ToString();
        }

        private void BtnRestar_Click(object sender, EventArgs e)
        {
            decimal n1;
            decimal n2;

            if (Calc.ValidarDecimal(txtN1.Text, out n1) && Calc.ValidarDecimal(txtN2.Text, out n2))
            {
                lblResultado.Text = Calc.Restar(n1,n2).ToString();
            }
        }

        private void BtnSumar_Click(object sender, EventArgs e)
        {
            decimal n1;
            decimal n2;

            if (Calc.ValidarDecimal(txtN1.Text, out n1) && Calc.ValidarDecimal(txtN2.Text, out n2))
            {
                lblResultado.Text = Calc.Sumar(n1, n2).ToString();
            }
        }

        private void BtnMultiplicar_Click(object sender, EventArgs e)
        {
            decimal n1;
            decimal n2;

            if (Calc.ValidarDecimal(txtN1.Text, out n1) && Calc.ValidarDecimal(txtN2.Text, out n2))
            {
                lblResultado.Text = Calc.Multiplicar(n1, n2).ToString();
            }
        }

        private void BtnDividir_Click(object sender, EventArgs e)
        {
            decimal n1;
            decimal n2;

            if (Calc.ValidarDecimal(txtN1.Text, out n1) && Calc.ValidarDecimal(txtN2.Text, out n2))
            {
                lblResultado.Text = Calc.Dividir(n1, n2).ToString();
            }
        }


        private void TxtExpr_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13) {
                btnCalcularExpr_Click(sender, e);
            }
            
        }
    }
}
