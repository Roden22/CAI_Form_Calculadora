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
        // ATRIBUTOS
        private readonly Calc calc;

        public Form1()
        {
            InitializeComponent();
            calc = new Calc();
        }


        private void BtnCalcularExpr_Click(object sender, EventArgs e)
        {
            calc.CalcularExpresion(txtExpresion.Text);

            if (double.IsNaN(calc.Resultado))
            {
                lblResultado.Text = "";
                PopMensaje(calc.Error);
            }
            else
            {
                lblResultado.Text = calc.Resultado.ToString();
            }
        }

        private void BtnRestar_Click(object sender, EventArgs e)
        {
            if (calc.SetValor1(txtN1.Text) && calc.SetValor2(txtN2.Text))
            {
                lblResultado.Text = calc.Restar().ToString();
            }
            else
            {
                lblResultado.Text = "";
                PopMensaje("Operación inválida.");
            }
            
        }

        private void BtnSumar_Click(object sender, EventArgs e)
        {
            if (calc.SetValor1(txtN1.Text) && calc.SetValor2(txtN2.Text))
            {
                lblResultado.Text = calc.Sumar().ToString();
            }
            else
            {
                lblResultado.Text = "";
                PopMensaje("Operación inválida.");
            }
        }

        private void BtnMultiplicar_Click(object sender, EventArgs e)
        {
            if (calc.SetValor1(txtN1.Text) && calc.SetValor2(txtN2.Text))
            {
                lblResultado.Text = calc.Multiplicar().ToString();
            }
            else
            {
                lblResultado.Text = "";
                PopMensaje("Operación inválida.");
            }
        }

        private void BtnDividir_Click(object sender, EventArgs e)
        {
            double res;

            if (calc.SetValor1(txtN1.Text) && calc.SetValor2(txtN2.Text))
            {

                res = calc.Dividir();
                if (double.IsNaN(res))
                {
                    lblResultado.Text = "";
                    PopMensaje(calc.Error);
                }
                else
                {
                    lblResultado.Text = calc.Resultado.ToString();
                }
            }
            else
            {
                lblResultado.Text = "";
                PopMensaje("Operación inválida.");
            }
        }


        private void TxtExpr_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13) {
                BtnCalcularExpr_Click(sender, e);
            }
        }

        private void PopMensaje(string s)
        {
            MessageBox.Show(s);
        }

    }
}
