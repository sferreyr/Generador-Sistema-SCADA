using System.Reflection.Emit;
using System.Windows.Forms;
using System.Xml.Serialization;
using WinFormsApp3.Managers;
using WinFormsApp3.Models;
using WinFormsApp3.WidgetsTools;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using EasyModbus;
using System;
using System.Security.Claims;

using Microsoft.VisualBasic.Devices;
using System.Threading;
using System.Xml;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System.Reflection;
using WinFormsApp3.PLC;

using System.Drawing;
using System.Runtime.CompilerServices;

namespace WinFormsApp3
{
    public partial class MainForm : Form
    {

        public List<System.Windows.Forms.Control> LabelControl = new List<System.Windows.Forms.Control>();
        public List<System.Windows.Forms.Control> TextboxControl = new List<System.Windows.Forms.Control>();
        public List<System.Windows.Forms.Control> PictureBoxControl = new List<System.Windows.Forms.Control>();

        //Variable modo edicion
        private bool _EditorMode = false;
        private bool _PanelGrid = false;



        List<Control> controls = new List<Control>();


        public int LabelUserCounter = 0;
        public int TextboxUserCounter = 0;
        public int ImageUserCounter = 0;

        public MainForm()
        {

            InitializeComponent();


        }

        private void toolStripButton1_Click(object sender, EventArgs e)
        {

        }

        private void toolStripProgressBar1_Click(object sender, EventArgs e)
        {

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void cargarConfiguracionToolStripMenuItem_Click(object sender, EventArgs e, PlcConfiguration plcConfiguration)
        {




        }





        private void new_label_Click(object sender, EventArgs e)
        {
            /*
                        NewLabelForm newLabel = new NewLabelForm(this);
                        newLabel.ShowDialog();*/
            Random rnd = new Random();
            int randNumber = rnd.Next(1, 1000);
            String LableName = "Lbl_" + randNumber;
            System.Windows.Forms.Label ctrl = new System.Windows.Forms.Label();
            ctrl.Location = new Point(30, 130);
            ctrl.Name = LableName;
            ctrl.Font = new System.Drawing.Font("NativePrinterFontA", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            ctrl.Text = "Nuevo Texto";
            ctrl.AutoSize = true;
            ctrl.Draggable(true);
            ctrl.MouseDown += new MouseEventHandler(control_MouseDown);
            ctrl.MouseMove += new MouseEventHandler(control_MouseMove);
            ctrl.MouseUp += new MouseEventHandler(control_MouseUp);
            ctrl.BringToFront();


            // Agrega el label al panel del formulario
            MainForm_Panel.Controls.Add((System.Windows.Forms.Label)ctrl);
            LabelControl.Add(ctrl);

            LabelUserCounter = LabelUserCounter + 1;



        }



        private void new_textbox_Click(object sender, EventArgs e)
        {
            NewTextBoxForm newTextbox = new NewTextBoxForm(this);
            newTextbox.ShowDialog();


        }



        //cargar configuracion
        private void cargarConfiguracionToolStripMenuItem_Click(object sender, EventArgs e)
        {

            GUIConfigurationManager manager = new GUIConfigurationManager(this);
            manager.LoadGUIConfig();

            //Desactivamos el modo editor, para cargar correctamente todo.
            DisableEditorMode();

        }

        private void MainForm_Load(object sender, EventArgs e)
        {


            /*   EasyModbus.ModbusClient plc = new EasyModbus.ModbusClient();
               plc.Connect("192.168.100.5", 502);
            */
            //   TextboxUserCounter = TextboxArray.Count;

        }

        private void button1_Click(object sender, EventArgs e)
        {

            // Creamos una nueva instancia de la clase PLCConnection
            PlCBackgroundWorker plcConnection = new PlCBackgroundWorker(this);

            // Iniciamos la conexión al PLC
            plcConnection.Start();



        }

        private void guardarConfiguraciónToolStripMenuItem_Click(object sender, EventArgs e)
        {
            GUIConfigurationManager manager = new GUIConfigurationManager(this);
            manager.SaveGUIConfig();
            //Desactivamos el modo editor, para cargar correctamente todo.
            DisableEditorMode();
        }
        private void MainForm_Panel_Paint(object sender, PaintEventArgs e)
        {

        }


        //////////////////////////////////
        /// <summary>
        /// RUN time Control Mouse Down Event used for Control Move
        /// </summary>
        /// <returns></returns>
        /// 
        public void control_MouseDown(object sender, MouseEventArgs e)
        {
            //Si el modoe ditor esta activado
            if (_EditorMode == true)
            {
                if (e.Button == MouseButtons.Left)
                {
                    MainForm_Panel.Invalidate();  //unselect other control
                    SelectedControl = (Control)sender;
                    Control control = (Control)sender;
                    mouseX = -e.X;
                    mouseY = -e.Y;
                    control.Invalidate();
                    DrawControlBorder(sender);
                    MainForm_Panel_propertyGrid.SelectedObject = SelectedControl;

                }
            }
        }

        //////////////////////////////////
        /// <summary>
        /// RUN time Control Mouse Up Event used for Control Move
        /// </summary>
        /// <returns></returns>
        /// 
        public void control_MouseUp(object sender, MouseEventArgs e)
        {
            //Si el modoe ditor esta activado
            if (_EditorMode == true)
            {
                if (e.Button == MouseButtons.Left)
                {
                    Control control = (Control)sender;
                    Cursor.Clip = System.Drawing.Rectangle.Empty;
                    control.Invalidate();
                    DrawControlBorder(control);
                }
            }
        }

        //////////////////////////////////
        /// <summary>
        /// RUN time Control Mouse Move Event used for Control Move
        /// </summary>
        /// <returns></returns>
        /// 
        public void control_MouseMove(object sender, MouseEventArgs e)
        {
            //Si el modoe ditor esta activado
            if (_EditorMode == true)
            {
                if (e.Button == MouseButtons.Left)
                {
                    Control control = (Control)sender;
                    Point nextPosition = new Point();
                    nextPosition = MainForm_Panel.PointToClient(MousePosition);
                    nextPosition.Offset(mouseX, mouseY);
                    control.Location = nextPosition;
                    Invalidate();
                }
            }
        }



        /// <summary>   
        /// Draw a border and drag handles around the control, on mouse down and up.
        /// </summary>
        /// <param name="sender"></param>
        public void DrawControlBorder(object sender)
        {
            //Si el modoe ditor esta activado, remarcamos
            if (_EditorMode == true)
            {
                Control control = (Control)sender;
                //define the border to be drawn, it will be offset by DRAG_HANDLE_SIZE / 2
                //around the control, so when the drag handles are drawn they will be seem
                //connected in the middle.
                Rectangle Border = new Rectangle(
                    new Point(control.Location.X - DRAG_HANDLE_SIZE / 2,
                        control.Location.Y - DRAG_HANDLE_SIZE / 2),
                    new Size(control.Size.Width + DRAG_HANDLE_SIZE,
                        control.Size.Height + DRAG_HANDLE_SIZE));
                //define the 8 drag handles, that has the size of DRAG_HANDLE_SIZE
                Rectangle NW = new Rectangle(
                    new Point(control.Location.X - DRAG_HANDLE_SIZE,
                        control.Location.Y - DRAG_HANDLE_SIZE),
                    new Size(DRAG_HANDLE_SIZE, DRAG_HANDLE_SIZE));
                Rectangle N = new Rectangle(
                    new Point(control.Location.X + control.Width / 2 - DRAG_HANDLE_SIZE / 2,
                        control.Location.Y - DRAG_HANDLE_SIZE),
                    new Size(DRAG_HANDLE_SIZE, DRAG_HANDLE_SIZE));
                Rectangle NE = new Rectangle(
                    new Point(control.Location.X + control.Width,
                        control.Location.Y - DRAG_HANDLE_SIZE),
                    new Size(DRAG_HANDLE_SIZE, DRAG_HANDLE_SIZE));
                Rectangle W = new Rectangle(
                    new Point(control.Location.X - DRAG_HANDLE_SIZE,
                        control.Location.Y + control.Height / 2 - DRAG_HANDLE_SIZE / 2),
                    new Size(DRAG_HANDLE_SIZE, DRAG_HANDLE_SIZE));
                Rectangle E = new Rectangle(
                    new Point(control.Location.X + control.Width,
                        control.Location.Y + control.Height / 2 - DRAG_HANDLE_SIZE / 2),
                    new Size(DRAG_HANDLE_SIZE, DRAG_HANDLE_SIZE));
                Rectangle SW = new Rectangle(
                    new Point(control.Location.X - DRAG_HANDLE_SIZE,
                        control.Location.Y + control.Height),
                    new Size(DRAG_HANDLE_SIZE, DRAG_HANDLE_SIZE));
                Rectangle S = new Rectangle(
                    new Point(control.Location.X + control.Width / 2 - DRAG_HANDLE_SIZE / 2,
                        control.Location.Y + control.Height),
                    new Size(DRAG_HANDLE_SIZE, DRAG_HANDLE_SIZE));
                Rectangle SE = new Rectangle(
                    new Point(control.Location.X + control.Width,
                        control.Location.Y + control.Height),
                    new Size(DRAG_HANDLE_SIZE, DRAG_HANDLE_SIZE));

                //get the form graphic
                Graphics g = MainForm_Panel.CreateGraphics();
                //draw the border and drag handles
                ControlPaint.DrawBorder(g, Border, Color.Gray, ButtonBorderStyle.Dotted);
                ControlPaint.DrawGrabHandle(g, NW, true, true);
                ControlPaint.DrawGrabHandle(g, N, true, true);
                ControlPaint.DrawGrabHandle(g, NE, true, true);
                ControlPaint.DrawGrabHandle(g, W, true, true);
                ControlPaint.DrawGrabHandle(g, E, true, true);
                ControlPaint.DrawGrabHandle(g, SW, true, true);
                ControlPaint.DrawGrabHandle(g, S, true, true);
                ControlPaint.DrawGrabHandle(g, SE, true, true);
                g.Dispose();
            }
        }

        private void statusStrip1_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {

        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void datosPLCToolStripMenuItem_Click(object sender, EventArgs e)
        {
            newPlcConfigForm form = new newPlcConfigForm(this);
            form.ShowDialog();
        }

        private void habilitarModoEdicionToolStripMenuItem_Click(object sender, EventArgs e)
        {

            if (habilitarModoEdicionToolStripMenuItem.Text.Equals("Habilitar Modo Edicion"))
            {
                EnableEditorMode();

            }
            else if (habilitarModoEdicionToolStripMenuItem.Text.Equals("Deshabilitar Modo Edicion"))
            {
                DisableEditorMode();
            }
        }

        private void EnableEditorMode()
        {
            _EditorMode = true;
            _PanelGrid = true;
            //Actualizamos visualmente el Panel
            MainForm_Panel.Refresh();

            //Habilitamos Visualizador de Propiedades
            MainForm_Panel_propertyGrid.Enabled = true;
            MainForm_Panel_propertyGrid.Visible = true;

            //Habilitamos Barra de edicion
            MainForm_Panel_topPanel.Enabled = true;
            //Cambiamos Texto del Tooltip
            habilitarModoEdicionToolStripMenuItem.Text = "Deshabilitar Modo Edicion";
        }



        private void DisableEditorMode()
        {

            //Cambiamos Texto del Tooltip
            _EditorMode = false;
            _PanelGrid = false;

            //Actualizamos visualmente el Panel
            MainForm_Panel.Refresh();

            //Habilitamos Visualizador de Propiedades
            MainForm_Panel_propertyGrid.Enabled = false;
            MainForm_Panel_propertyGrid.Visible = false;

            //Habilitamos Barra de edicion
            MainForm_Panel_topPanel.Enabled = false;
            //Cambiamos Texto del Tooltip
            habilitarModoEdicionToolStripMenuItem.Text = "Habilitar Modo Edicion";

            // Desactivamos el Draggable.
            foreach (Control control in MainForm_Panel.Controls)
            {
                // Verifica que el control sea del tipo que deseas modificar
                if (control is System.Windows.Forms.Button || control is System.Windows.Forms.CheckBox || control is System.Windows.Forms.TextBox
                    || control is System.Windows.Forms.Label)
                {
                    control.Draggable(false);
                }
            }
        }



        private void MainForm_Panel_Paint_1(object sender, PaintEventArgs e)
        {

            if (_PanelGrid == true)
            {
                //Dibujamos Grid para mejor posicion de elementos
                int numHorisontal = MainForm_Panel.Width;
                int numVertical = MainForm_Panel.Height;
                int squareDim = 30;
                int xOffset = 0;
                int yOffset = 0;

                for (int i = 0; i <= numVertical; i++)
                {
                    e.Graphics.DrawLine(Pens.Black, new Point(xOffset, yOffset + i * squareDim), new Point(xOffset + numHorisontal * squareDim, yOffset + i * squareDim));
                }
                for (int i = 0; i < numHorisontal; i++)
                {
                    e.Graphics.DrawLine(Pens.Black, new Point(xOffset + i * squareDim, yOffset), new Point(xOffset + i * squareDim, yOffset + numVertical * squareDim));
                }
            }

        }

        private void new_image_Click(object sender, EventArgs e)
        {


            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "Image Files (*.jpg;*.jpeg;*.gif;*.bmp;*.png)|*.jpg;*.jpeg;*.gif;*.bmp;*.png";
            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
             
                Random rnd = new Random();
                int randNumber = rnd.Next(1, 1000);
                String imgName = "picbox_" + randNumber;
                System.Windows.Forms.PictureBox ctrl = new System.Windows.Forms.PictureBox();
                ctrl.Image = Image.FromFile(openFileDialog.FileName);
                ctrl.Location = new Point(30, 130);
                ctrl.Name = imgName;
              
                ctrl.AutoSize = true;
                ctrl.Draggable(true);
                ctrl.Size = new Size((int)(100), (int)(100));
                ctrl.MouseDown += new MouseEventHandler(control_MouseDown);
                ctrl.MouseMove += new MouseEventHandler(control_MouseMove);
                ctrl.MouseUp += new MouseEventHandler(control_MouseUp);
                ctrl.BringToFront();


                // Agrega el PictureBox al panel del formulario
                MainForm_Panel.Controls.Add((System.Windows.Forms.PictureBox)ctrl);
                PictureBoxControl.Add(ctrl);

                ImageUserCounter = ImageUserCounter + 1;

            }


          

        }
    }
}