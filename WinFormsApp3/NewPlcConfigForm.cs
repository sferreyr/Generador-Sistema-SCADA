using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml;
using System.Xml.Linq;
using System.Xml.Serialization;
using WinFormsApp3.Managers;
using WinFormsApp3.Models;
using static System.Net.Mime.MediaTypeNames;



namespace WinFormsApp3
{
    public partial class newPlcConfigForm : Form
    {


        //Partimos desde el ultimo ID de configuracion.
        public int lastId = 0;

        // Propiedad donde quieres almacenar el valor
        // public List<PlcConfiguration> plc { get; set; }
        MainForm _mainform;

        public newPlcConfigForm(MainForm mainform)
        {
            _mainform = mainform;
            InitializeComponent();

        }

    

        private void button2_Click(object sender, EventArgs e)
        {
            // Muestra una alerta con un mensaje y un botón "Aceptar"
            DialogResult result = MessageBox.Show("Mensaje de alerta", "Estado de Conexion", MessageBoxButtons.OK);

            // Si el usuario hace clic en "Aceptar", se cierra la alerta y se muestra un mensaje por consola
            if (result == DialogResult.OK)
            {
                Console.WriteLine("El usuario hizo clic en Aceptar");
            }
        }



        //Generar configuracion btn
        private void button1_Click(object sender, EventArgs e)
        {
            PLCConfigurationManager manager = new PLCConfigurationManager(this);

            manager.SavePLCConfiguration();

        }


        private void newPlcConfigForm_Load(object sender, EventArgs e)
        {
            PLCConfigurationManager manager = new PLCConfigurationManager(this);
            manager.LoadPLCConfiguration();

        }
        private void newPlcConfigForm_Close(object sender, EventArgs e)
        {
         

        }




        //Nuevo dato
        private void button3_Click(object sender, EventArgs e)
        {


            // Agrega una fila al control DataGridView y asigna el nuevo valor a la celda de la columna de ID de la fila agregada
            int rowIndex = dataGridView1.Rows.Add();
           
                dataGridView1.Rows[rowIndex].Cells["Id"].Value = ++lastId;
          
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
