using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using System.Runtime.InteropServices;
namespace Acertijo_MU
{
    
    public partial class form : Form
    {

        [DllImport("user32.DLL", EntryPoint = "ReleaseCapture")]
        private extern static void ReleaseCapture();
        [DllImport("user32.DLL", EntryPoint = "SendMessage")]
        private extern static void SendMessage(System.IntPtr hWnd, int wMsg, int wParam, int lParam);

        String[] arrcadenas = new String[100000]; 
        int mindice = 0;
        public form()
        {
            InitializeComponent();
        }
        private void Form1_Load(object sender, EventArgs e)
        {
        }
        public string Regla1(String cadena)
        {
            cadena = cadena + 'U';
            return cadena;
        }
        public string Regla2(String cadena)
        {
            cadena = cadena + cadena.Substring(1); 
            return cadena;
        } 
        public string Regla3(String cadena)
        {
            cadena = cadena.Replace("III", "U");
            return cadena;
        }
        public string Regla4(String cadena)
        {
            cadena = cadena.Replace("UU", ""); 
            return cadena;
        }
        
        void buscarmu(String cadena, String cadenasal)
        {
           
            if (cadenasal != cadena)
            {
              
            }
            if(cadenasal != "MU"){
                mindice++;
                arrcadenas[mindice] = cadenasal;

            }
            else
            {
                MessageBox.Show("Encontrado");
            }
        }
       public void generarMU(String cadena)
        {
            String cad;
            int longitud;
            String cadenasal1, cadenasal2, cadenasal3, cadenasal4;
            longitud = cadena.Length;
            cad = cadena.Substring(longitud-1);
            
            if(cad == "I")
            {
                cadenasal1 = Regla1(cadena);
                buscarmu(cadena, cadenasal1);   
            }
            cadenasal2 = Regla2(cadena);  
            buscarmu(cadena, cadenasal2); 
            if (cadena.IndexOf("III") == 1)
            {
                cadenasal3 = Regla3(cadena);      
                buscarmu(cadena, cadenasal3);    
            }
            if (cadena.IndexOf("UU") == 1)
            {
                cadenasal4 = Regla4(cadena);
                buscarmu(cadena, cadenasal4);   
            }
            
        }
        private void btn_Click(object sender, EventArgs e)
        {
        


        }

        private void button1_Click(object sender, EventArgs e)
        {

            arrcadenas[0] = "MI"; 
            list.Items.Add("MI");
            int i = 0;
            while (i < 50000) 
            {
                generarMU(arrcadenas[i]);
                if (arrcadenas[i] == "M" || arrcadenas[i].Contains("III") || arrcadenas[i].Contains("UU"))
                {
                }
                else
                {
                    list.Items.Add(arrcadenas[i]);

                }

                i++;
            }





            String buscar = txtbuscar.Text; 
            ListViewItem item1 = list.FindItemWithText(buscar);
            if (item1 != null && buscar != "MU" && buscar != "" && buscar != " ")
            {
                MessageBox.Show("Se ha encontrado el Teorema '"+buscar+"' entre las iteraciones");
            }
            else
            {
                MessageBox.Show("NO se ha encontrado el Teorema '" + buscar + "' entre las iteraciones, por lo que no es un teorema");
            }

        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void panel1_MouseDown(object sender, MouseEventArgs e)
        {
            ReleaseCapture();
            SendMessage(this.Handle, 0x112, 0xf012, 0);
        }
    }
}
