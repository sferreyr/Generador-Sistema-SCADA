using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using static System.Windows.Forms.DataFormats;

namespace WinFormsApp3.WidgetsTools
{
    public partial class NewLabelForm : Form
    {

        MainForm mainform;

        public NewLabelForm(MainForm fmain)
        {
            InitializeComponent();
            mainform = fmain;
        }

        private void NewLabelForm_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            /*  String NameGenerator = "labelUser_" + mainform.LabelUserCounter;

              // Crea un nuevo label
              LabelControl newLabel = new LabelControl();

              // Establece el texto del label
              newLabel.Text = textBox1.Text;
              newLabel.Name = NameGenerator;

              // Establece la ubicación y el tamaño del label
              newLabel.Location = new System.Drawing.Point(200, 200);
              newLabel.Size = new System.Drawing.Size(100, 50);
              newLabel.Draggable(true);

              // Agregamos el nuevo Label a la lista labelArray
              mainform.labelArray.Add(newLabel);
              */

            Random rnd = new Random();
            int randNumber = rnd.Next(1, 1000);
            String LableName = "Lbl_" + randNumber;
            Label ctrl = new Label();
            ctrl.Location = new Point(30, 130);
            ctrl.Name = LableName;
            ctrl.Font = new System.Drawing.Font("NativePrinterFontA", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            ctrl.Text = "Shanu";
           // ctrl.MouseDown += new MouseEventHandler(MainForm.control_MouseDown);
            ctrl.Draggable(true);

            ctrl.BringToFront();


            // Agrega el label al panel del formulario
            mainform.MainForm_Panel.Controls.Add((Label)ctrl);

            mainform.LabelUserCounter = mainform.LabelUserCounter + 1;



            //Cerramos form
            this.Close();
        }
    }
}
