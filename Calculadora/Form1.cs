using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Calculadora
{
    //Isel Metzí Carrillo Mejía, Carnet: CM240437
    public partial class Form1 : Form
    {
        public double num1, resultado, num2;
        public bool Is1, Is2, Es_op;
        int operacion;
        public Form1()
        {
            InitializeComponent();
            Pantalla.ReadOnly = true;
            Is1 = Is2 = false;
            
        }

        private void Num0_Click(object sender, EventArgs e)
        {
            actualizar_pantalla("0");
        }

        private void Num1_Click(object sender, EventArgs e)
        {
            actualizar_pantalla("1");
        }

        private void Num2_Click(object sender, EventArgs e)
        {
            actualizar_pantalla("2");
        }

        private void Num3_Click(object sender, EventArgs e)
        {
            actualizar_pantalla("3");
        }

        private void Num4_Click(object sender, EventArgs e)
        {
            actualizar_pantalla("4");
        }

        private void Num5_Click(object sender, EventArgs e)
        {
            actualizar_pantalla("5");
        }

        private void Num6_Click(object sender, EventArgs e)
        {
            actualizar_pantalla("6");
        }

        private void Num7_Click(object sender, EventArgs e)
        {
            actualizar_pantalla("7");
        }

        private void Num8_Click(object sender, EventArgs e)
        {
            actualizar_pantalla("8");
        }

        private void Num9_Click(object sender, EventArgs e)
        {
            actualizar_pantalla("9");
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (!Is1)
            {
                num1 = obtener_valor();
                Is1 = true;                     //Actualizamos el valor de la variable de control "0" indicará la operación matematica "suma"
                operacion = 0;
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            if (!Is1)
            {
                num1 = obtener_valor();
                Is1 = true;                     //Actualizamos el valor de la variable de control "0" indicará la operación matematica "resta"
                operacion = 1;
            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            if (!Is1)
            {
                num1 = obtener_valor();
                Is1 = true;                     //Actualizamos el valor de la variable de control "0" indicará la operación matematica "multiplicación"
                operacion = 2;
            }
        }

        private void button6_Click(object sender, EventArgs e)
        {
            if (!Is1)
            {
                num1 = obtener_valor();
                Is1 = true;                     //Actualizamos el valor de la variable de control "0" indicará la operación matematica "suma"
                operacion = 3;
            }
        }

        public double operar(double operador1,double operador2,string signo)
        {
            double Resultado = 0.0;
            switch (signo) {
                case "+":
                    Resultado=operador1 + operador2;
                    break;
                case "-":
                    Resultado=operador1 - operador2;
                    break;
                case "*":
                    Resultado=operador1 * operador2;
                    break;
                case "/":
                    if (operador2 == 0 || operador2 < 0)
                    {
                        MessageBox.Show("Error: No existe división por cero o menor a cero", "Calculadora", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else {
                        Resultado = operador1 / operador2;
                    }
                    break;
                case "log":
                       Resultado = Math.Log(operador1,10);

                    break;
            }
            return Resultado;
        }

        private void button24_Click(object sender, EventArgs e)
        {
            try {
                switch (operacion) { 
                    case 0:
                        if (Is1)
                        {
                            num2 = obtener_valor();
                            actualizar_pantalla(operar(num1, num2, "+").ToString());
                            Is1 = false;
                        }
                        else
                        {
                            MessageBox.Show("Seleccione una operación para realizar");
                        }
                    break;
                    case 1:
                        if (Is1)
                        {
                            num2 = obtener_valor();
                            actualizar_pantalla(operar(num1, num2, "-").ToString());
                            Is1 = false;
                        }
                        else
                        {
                            MessageBox.Show("Seleccione una operación para realizar");
                        }
                    break ;
                    case 2:
                        if (Is1)
                        {
                            num2 = obtener_valor();
                            actualizar_pantalla(operar(num1, num2, "*").ToString());
                            Is1 = false;
                        }
                        else
                        {
                            MessageBox.Show("Seleccione una operación para realizar");
                        }
                    break ;
                    case 3:
                        if (Is1)
                        {
                            num2 = obtener_valor();
                            actualizar_pantalla(operar(num1, num2, "/").ToString());
                            Is1 = false;
                        }
                        else
                        {
                            MessageBox.Show("Seleccione una operación para realizar");
                        }
                    break ;

                        case 4:
                        if (Is1) {
                            if (num1 <= 0) //control de datos, ubicado aqui para no tener problemas con el metodo operar, que siempre devuelve "resultado" de tipo double
                            {
                                limpiar_pantalla(); 
                                actualizar_pantalla("E"); //imprime en la pantalla E de error si el número es menor que 0
                            }
                            else
                            {
                                num2 = 0; //asigno un valor cualquiera a num 2 para poder enviar lo demas al metodo "operar" sin tener que crear una sobrecarga
                                actualizar_pantalla(operar(num1, num2, "log").ToString());
                                
                            }
                            Is1 = false;
                        }
                        else
                        {
                            MessageBox.Show("Seleccione una operación para realizar");
                        }
                        break;
                }
            } catch {
                MessageBox.Show("Esta operación requiere de dos operandos");
            }
           
        }

        private void button21_Click(object sender, EventArgs e) //click al boton "log"
        {
            if (!Is1)
            { 
                num1 = obtener_valor();
                Is1 = true;              //Actualizamos el valor de la variable de control "0" indicará la operación matematica "logaritmo base 10"
                operacion = 4;
            }
        }

        private void button7_Click(object sender, EventArgs e)
        {
            actualizar_pantalla("-");
        }

        public void limpiar_pantalla() { //Para limpiar el texbox llamado pantalla
            Pantalla.Text = "";
        }

        public double obtener_valor() { //Para transformar lo que se digite en el textbox a formato númerico
            double valor;
            try
            {
                 valor = Convert.ToDouble(Pantalla.Text);
                limpiar_pantalla();
                return valor;
            }
            catch
            {
                valor=0;
                return valor;
            }
            
        }

        public void actualizar_pantalla(string texto) { //Para actualizar lo que se visualiza en el textbox
            Pantalla.Text=Pantalla.Text+texto;
        }
        private void button2_Click(object sender, EventArgs e)
        {
            limpiar_pantalla();
        }
    }
}
