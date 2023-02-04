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
using WinFormsApp3.Managers;
using WinFormsApp3.Models;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace WinFormsApp3.WidgetsTools
{
    public partial class NewTextBoxForm : Form
    {

        MainForm _mainform;



        public NewTextBoxForm(MainForm mainform)
        {
            InitializeComponent();
            _mainform = mainform;

        }

        private void NewTextBoxForm_Load(object sender, EventArgs e)
        {
            PLCConfigurationManager manager = new PLCConfigurationManager(this);
            manager.LoadPLCConfiguration();

        }

        private void button1_Click(object sender, EventArgs e)
        {

            PlcConfiguration value = (PlcConfiguration)listBox1.SelectedItem;
            System.Windows.Forms.TextBox newTextBox = new System.Windows.Forms.TextBox();

            Random rnd = new Random();
            int randNumber = rnd.Next(1, 1000);
            String Name = "Txb_" + randNumber + "_" + value.MemoryAddress;
            System.Windows.Forms.TextBox ctrl = new System.Windows.Forms.TextBox();
            ctrl.Location = new Point(30, 130);
            ctrl.Name = Name;
            ctrl.Font = new System.Drawing.Font("NativePrinterFontA", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            ctrl.Text = Name;//value.MemoryAddress;
            ctrl.Draggable(true);
            ctrl.MouseDown += new MouseEventHandler(_mainform.control_MouseDown);
            ctrl.MouseMove += new MouseEventHandler(_mainform.control_MouseMove);
            ctrl.MouseUp += new MouseEventHandler(_mainform.control_MouseUp);
            ctrl.BringToFront();

            // Agrega el label al panel del formulario
            _mainform.MainForm_Panel.Controls.Add((System.Windows.Forms.TextBox)ctrl);
            _mainform.TextboxControl.Add(ctrl);

            //Cerramos form
            this.Close();
        }
    }
}
