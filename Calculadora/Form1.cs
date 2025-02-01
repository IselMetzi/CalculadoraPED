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
    //Javier Enrique Monge Argueta, Carnet: MA240490
    //Anderson Isaac Aguilar Ramos, Carnet: AR240256
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

       

        private double GradosARadianes(double grados)
        {
            double result = grados * Math.PI / 180;
            return result;
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
                    //En este caso se evalua la funcion logaritmo agregandole un 10 que es la base del logaritmo
                    Resultado = Math.Log(operador1,10);

                    break;
                case "sin":
                    Resultado = Math.Sin(GradosARadianes(operador1)); // Se asigna el valor del sen del dato ingresado a resultado con el ángulo en grados
                    break;
                case "cos":
                    Resultado = Math.Cos(GradosARadianes(operador1));// Se asigna el valor del cos del dato ingresado a resultado con el ángulo en grados
                    break;
                case "tan":
                    
                    Resultado = Math.Tan(GradosARadianes(operador1)); // Se asigna el valor del tan del dato ingresado a resultado con el ángulo en grados
                    break;
                case "pow":
                    try
                    {
                        // Calculamos x elevado a y usando Math.Pow
                        Resultado = Math.Pow(operador1, operador2);
                    }
                    catch (Exception)
                    {
                        MessageBox.Show("Error: Operación no válida", "Calculadora", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        return 0;
                    }
                    break;
                case "ln":
                    //En este caso se evalua al no agregarle valor de cual sera la base del logaritmo
                    //Por defecto toma al logaritmo con base e que seria un logaritmo natural
                    Resultado = Math.Round( Math.Log(operador1),4);
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
                                
                                actualizar_pantalla(operar(num1, 0, "log").ToString());
                                
                            }
                            Is1 = false;
                        }
                        else
                        {
                            MessageBox.Show("Seleccione una operación para realizar");
                        }
                        break;
                    case 5: // Seno
                        if (Is1)
                        {
                            actualizar_pantalla(operar(num1, 0, "sin").ToString());
                            Is1 = false;
                        }
                        break;

                    case 6: // Coseno
                        if (Is1)
                        {
                            actualizar_pantalla(operar(num1, 0, "cos").ToString());
                            Is1 = false;
                        }
                        break;

                    case 7: // Tangente
                        if (Is1)
                        {
                            if (Math.Round(Math.Cos(GradosARadianes(num1))) == 0)
                            {
                                limpiar_pantalla();
                                actualizar_pantalla("E");

                            }
                            else
                            {
                                actualizar_pantalla(operar(num1, 0, "tan").ToString());
                            }
                            
                            Is1 = false;
                        }
                        break;

                    case 8: // Potencia
                        if (Is1)
                        {
                            num2 = obtener_valor();
                            actualizar_pantalla(operar(num1, num2, "pow").ToString());
                            Is1 = false;
                        }
                        break;
                    //Se programa para la funcion de poder calcular un logaritmo natural de un numero
                    case 9:
                        if (Is1)
                        {
                            if (num1 <= 0)
                            {
                                limpiar_pantalla();
                                actualizar_pantalla("E");
                            }
                            else
                            {
                                num2 = 0;
                                actualizar_pantalla(operar(num1, num2, "ln").ToString());
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

        private void button18_Click(object sender, EventArgs e) // Click al boton "sen"
        {
            if (!Is1)
            {
                num1 = obtener_valor(); // Se obtiene el valor en radianes de la pantalla
                Is1 = true;
                operacion = 5; // Operación para seno
            }
        }

        private void button19_Click(object sender, EventArgs e) // Click al boton "cos"
        {
            if (!Is1)
            {
                num1 = obtener_valor(); // Se obtiene el valor en radianes de la pantalla
                Is1 = true;
                operacion = 6; // Operación para coseno
            }
        }

        private void button20_Click(object sender, EventArgs e) // Click al boton "tan"
        {
            if (!Is1)
            {
                num1 = obtener_valor(); // Se obtiene el valor en radianes de la pantalla
                Is1 = true;
                operacion = 7; // Operación para tangente
            }
        }

        private void button23_Click(object sender, EventArgs e) // Click al boton "X^n"
        {
            if (!Is1)
            {
                num1 = obtener_valor(); // Se obtiene la base de la potencia
                Is1 = true;
                operacion = 8; // Operación para potencia
            }
        }

        private void button22_Click(object sender, EventArgs e)
        {
            if (!Is1)
            {
                num1 = obtener_valor();
                Is1 = true;              //Actualizamos el valor de la variable de control "0" indicará la operación matematica "logaritmo base e ó logaritmo natural"
                operacion = 9;
            }
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
