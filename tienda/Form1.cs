using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace tienda
{
    public partial class Form1 : Form
    {        
        private int Cantidad;
        private double SubTotal;
        private double Total;
        private double DescuentoTotal;
        private String cadena;
        private double[] precios = new double[6];
        public Form1()
        {
            InitializeComponent();
            this.Cantidad = 0;
            this.SubTotal = 0.0;
            this.Total = 0;
            precios[0] = 25;
            precios[1] = 43;
            precios[2] = 15;
            precios[3] = 15;
            precios[4] = 10;
            precios[5] = 10;

            /*LLenar el combobox
             * cmbOpcion.Items.Add("afasdf");
            cmbOpcion.Items.Add("afasdf");
            cmbOpcion.Items.Add("afasdf");
            cmbOpcion.Items.Add("afasdf");
            cmbOpcion.Items.Add("afasdf");*/
        }

        public int sumar(int parametro1, int parametro2)
        {
            int suma = parametro1 + parametro2;
            return suma;
        }

        private void cmbOpcion_SelectedIndexChanged(object sender, EventArgs e)
        {
            //MessageBox.Show(cmbOpcion.SelectedItem.ToString());//
            
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {            

            if (txbCantidad.Text.Equals(""))
            {
                //Si esta vacio retorna true
                MessageBox.Show("Ingrese una cantidad porfavor");
            }
            else
            {
                //retorna false aqui tiene datos 
                int indice = cmbOpcion.SelectedIndex;
                double precio = precios[indice];
                int cantidad = int.Parse(txbCantidad.Text);
                //Subtotal es el precio total sin descuento
                double subtotal = precio * cantidad;
                double descuento = 0;
                double descuentoMostrar = 0;
                
                //Validar los descuentos
                if (cantidad <= 5)
                {
                    //la cantidad es menor a 5
                    //Aplicamos el descuento respectivo de 10%
                    descuentoMostrar = 0.10;
                    //Descuento es el precio total con descuento
                    double descontar = (subtotal * descuentoMostrar);
                    //total con descuento
                    descuento = (subtotal - descontar);
                    
                }
                else if (cantidad > 5 && cantidad <= 10)
                {
                    //Aplicamos el descuento respectivo
                    descuentoMostrar = 0.15;
                    double descontar = (subtotal * descuentoMostrar);
                    //total con descuento
                    descuento = subtotal - descontar;
                }
                else if (cantidad > 10)
                {
                    //Aplicamos el descuento respectivo
                    descuentoMostrar = 0.2;
                    double descontar = (subtotal * descuentoMostrar);
                    //total con descuento
                    descuento = subtotal - descontar;
                }
                //Descuento total que se operar
                this.DescuentoTotal = descuentoMostrar*cantidad;

                //Almacenamos el total con descuento
                this.Total = descuento;                
                
                lblProductos.Text = cmbOpcion.SelectedItem+ " cant: " + cantidad.ToString()
                    + " total sin descuento: $" + subtotal + " total con descuento: $" + descuento;
                this.Cantidad = Cantidad + cantidad;
               
            }           
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            int num1 = 20;
            int num2 = 3;
            int resultado=sumar(num1, num2);
            //MessageBox.Show(resultado.ToString());
        }

        private void btnPagar_Click(object sender, EventArgs e)
        {
            Boolean traspaso = ValidarCampos();
            //validar si traspaso es verdadera o falsa, si es verdadero todos los campos tienen datos, si no no tienen
            if (traspaso == true)
            {
                //trapaso es true
                //Hay quemostrar los datos
                //+= concatenacion, ir poniendo datos ala par de otro
                this.cadena += "Cliente: " + txbNombre.Text + " Direccion: " + txbDireccion.Text + " Telefono: " + txbTelefono.Text
                + " Descripcion: " + cmbOpcion.SelectedItem + " Cantidad: " + txbCantidad.Text + "\n Precio unitario: "
                + precios[cmbOpcion.SelectedIndex].ToString()//precios requiere un indice para mostrar su valor
                + " Descuento Total: " + this.DescuentoTotal
                + " Total: " + this.Total + "\n";
                lblResultado.Text = cadena;
            }
            else
            {
                MessageBox.Show("No deje ningun campo vacio","Error",MessageBoxButtons.OK,MessageBoxIcon.Error);
            }            
        }

       

        private Boolean ValidarCampos()
        {            
            //Si los textbox son vacios nos retorna verdadero, pero si tienen un dato es false
            //retornaran true si no tienen datos, pero si tienen retornan false
            Boolean nombre = txbNombre.Text.Equals("");//true, false
            Boolean direccion = txbDireccion.Text.Equals("");//true, false
            Boolean telefono = txbTelefono.Text.Equals("");//true, false
            Boolean cantidad = txbCantidad.Text.Equals("");//true, false
            Boolean resultado;
            
            //Todas tienen que ser falsas para que puedan estar llenas de datos los textbox
            if(nombre==false && direccion==false && telefono == false && cantidad==false)
            {
                //Textbox tienen datos
                resultado = true;
            }
            else
            {
                //textbox no tienen datos
                resultado = false;
            }            
            return resultado;            
        }

        private void txbCantidad_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
