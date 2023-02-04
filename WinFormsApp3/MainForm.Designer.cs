namespace WinFormsApp3
{
    partial class MainForm
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.toolStripStatusLabel1 = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolStrip_connectionStatus = new System.Windows.Forms.ToolStripStatusLabel();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.inicioToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.cargarConfiguracionToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.guardarConfiguraciónToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.configuracionesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.nuevaConexionPLCToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.datosPLCToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.administracionToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.habilitarModoEdicionToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.MainForm_Panel_topPanel = new System.Windows.Forms.Panel();
            this.new_image = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.new_textbox = new System.Windows.Forms.Button();
            this.new_label = new System.Windows.Forms.Button();
            this.MainForm_Panel = new System.Windows.Forms.Panel();
            this.MainForm_Panel_propertyGrid = new System.Windows.Forms.PropertyGrid();
            this.statusStrip1.SuspendLayout();
            this.menuStrip1.SuspendLayout();
            this.MainForm_Panel_topPanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // statusStrip1
            // 
            this.statusStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripStatusLabel1,
            this.toolStrip_connectionStatus});
            this.statusStrip1.Location = new System.Drawing.Point(0, 582);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Padding = new System.Windows.Forms.Padding(1, 0, 12, 0);
            this.statusStrip1.RenderMode = System.Windows.Forms.ToolStripRenderMode.Professional;
            this.statusStrip1.Size = new System.Drawing.Size(1239, 24);
            this.statusStrip1.TabIndex = 0;
            this.statusStrip1.Text = "statusStrip1";
            this.statusStrip1.ItemClicked += new System.Windows.Forms.ToolStripItemClickedEventHandler(this.statusStrip1_ItemClicked);
            // 
            // toolStripStatusLabel1
            // 
            this.toolStripStatusLabel1.Name = "toolStripStatusLabel1";
            this.toolStripStatusLabel1.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.toolStripStatusLabel1.Size = new System.Drawing.Size(42, 19);
            this.toolStripStatusLabel1.Text = "Status:";
            // 
            // toolStrip_connectionStatus
            // 
            this.toolStrip_connectionStatus.BorderSides = ((System.Windows.Forms.ToolStripStatusLabelBorderSides)((((System.Windows.Forms.ToolStripStatusLabelBorderSides.Left | System.Windows.Forms.ToolStripStatusLabelBorderSides.Top) 
            | System.Windows.Forms.ToolStripStatusLabelBorderSides.Right) 
            | System.Windows.Forms.ToolStripStatusLabelBorderSides.Bottom)));
            this.toolStrip_connectionStatus.Name = "toolStrip_connectionStatus";
            this.toolStrip_connectionStatus.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.toolStrip_connectionStatus.Size = new System.Drawing.Size(56, 19);
            this.toolStrip_connectionStatus.Text = "OFFLINE";
            // 
            // menuStrip1
            // 
            this.menuStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.inicioToolStripMenuItem,
            this.configuracionesToolStripMenuItem,
            this.administracionToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Padding = new System.Windows.Forms.Padding(5, 2, 0, 2);
            this.menuStrip1.Size = new System.Drawing.Size(1239, 24);
            this.menuStrip1.TabIndex = 1;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // inicioToolStripMenuItem
            // 
            this.inicioToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.cargarConfiguracionToolStripMenuItem,
            this.guardarConfiguraciónToolStripMenuItem});
            this.inicioToolStripMenuItem.Name = "inicioToolStripMenuItem";
            this.inicioToolStripMenuItem.Size = new System.Drawing.Size(48, 20);
            this.inicioToolStripMenuItem.Text = "Inicio";
            // 
            // cargarConfiguracionToolStripMenuItem
            // 
            this.cargarConfiguracionToolStripMenuItem.Name = "cargarConfiguracionToolStripMenuItem";
            this.cargarConfiguracionToolStripMenuItem.Size = new System.Drawing.Size(195, 22);
            this.cargarConfiguracionToolStripMenuItem.Text = "Cargar Configuración";
            this.cargarConfiguracionToolStripMenuItem.Click += new System.EventHandler(this.cargarConfiguracionToolStripMenuItem_Click);
            // 
            // guardarConfiguraciónToolStripMenuItem
            // 
            this.guardarConfiguraciónToolStripMenuItem.Name = "guardarConfiguraciónToolStripMenuItem";
            this.guardarConfiguraciónToolStripMenuItem.Size = new System.Drawing.Size(195, 22);
            this.guardarConfiguraciónToolStripMenuItem.Text = "Guardar Configuración";
            this.guardarConfiguraciónToolStripMenuItem.Click += new System.EventHandler(this.guardarConfiguraciónToolStripMenuItem_Click);
            // 
            // configuracionesToolStripMenuItem
            // 
            this.configuracionesToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.nuevaConexionPLCToolStripMenuItem,
            this.datosPLCToolStripMenuItem});
            this.configuracionesToolStripMenuItem.Name = "configuracionesToolStripMenuItem";
            this.configuracionesToolStripMenuItem.Size = new System.Drawing.Size(106, 20);
            this.configuracionesToolStripMenuItem.Text = "Configuraciones";
            // 
            // nuevaConexionPLCToolStripMenuItem
            // 
            this.nuevaConexionPLCToolStripMenuItem.Name = "nuevaConexionPLCToolStripMenuItem";
            this.nuevaConexionPLCToolStripMenuItem.Size = new System.Drawing.Size(186, 22);
            this.nuevaConexionPLCToolStripMenuItem.Text = "Nueva Conexion PLC";
            // 
            // datosPLCToolStripMenuItem
            // 
            this.datosPLCToolStripMenuItem.Image = global::WinFormsApp3.Properties.Resources.new_datagrid_plc;
            this.datosPLCToolStripMenuItem.Name = "datosPLCToolStripMenuItem";
            this.datosPLCToolStripMenuItem.Size = new System.Drawing.Size(186, 22);
            this.datosPLCToolStripMenuItem.Text = "Datos PLC";
            this.datosPLCToolStripMenuItem.Click += new System.EventHandler(this.datosPLCToolStripMenuItem_Click);
            // 
            // administracionToolStripMenuItem
            // 
            this.administracionToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.habilitarModoEdicionToolStripMenuItem});
            this.administracionToolStripMenuItem.Name = "administracionToolStripMenuItem";
            this.administracionToolStripMenuItem.Size = new System.Drawing.Size(100, 20);
            this.administracionToolStripMenuItem.Text = "Administracion";
            // 
            // habilitarModoEdicionToolStripMenuItem
            // 
            this.habilitarModoEdicionToolStripMenuItem.Name = "habilitarModoEdicionToolStripMenuItem";
            this.habilitarModoEdicionToolStripMenuItem.Size = new System.Drawing.Size(196, 22);
            this.habilitarModoEdicionToolStripMenuItem.Text = "Habilitar Modo Edicion";
            this.habilitarModoEdicionToolStripMenuItem.Click += new System.EventHandler(this.habilitarModoEdicionToolStripMenuItem_Click);
            // 
            // MainForm_Panel_topPanel
            // 
            this.MainForm_Panel_topPanel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.MainForm_Panel_topPanel.Controls.Add(this.new_image);
            this.MainForm_Panel_topPanel.Controls.Add(this.button1);
            this.MainForm_Panel_topPanel.Controls.Add(this.new_textbox);
            this.MainForm_Panel_topPanel.Controls.Add(this.new_label);
            this.MainForm_Panel_topPanel.Dock = System.Windows.Forms.DockStyle.Top;
            this.MainForm_Panel_topPanel.Enabled = false;
            this.MainForm_Panel_topPanel.Location = new System.Drawing.Point(0, 24);
            this.MainForm_Panel_topPanel.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.MainForm_Panel_topPanel.Name = "MainForm_Panel_topPanel";
            this.MainForm_Panel_topPanel.Size = new System.Drawing.Size(1239, 50);
            this.MainForm_Panel_topPanel.TabIndex = 2;
            this.MainForm_Panel_topPanel.Paint += new System.Windows.Forms.PaintEventHandler(this.panel1_Paint);
            // 
            // new_image
            // 
            this.new_image.AutoSize = true;
            this.new_image.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.new_image.Image = ((System.Drawing.Image)(resources.GetObject("new_image.Image")));
            this.new_image.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.new_image.Location = new System.Drawing.Point(170, 14);
            this.new_image.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.new_image.Name = "new_image";
            this.new_image.Size = new System.Drawing.Size(84, 33);
            this.new_image.TabIndex = 5;
            this.new_image.Text = "Imagen";
            this.new_image.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.new_image.UseVisualStyleBackColor = true;
            this.new_image.Click += new System.EventHandler(this.new_image_Click);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(1022, 14);
            this.button1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(82, 22);
            this.button1.TabIndex = 4;
            this.button1.Text = "conectar plc";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // new_textbox
            // 
            this.new_textbox.AutoSize = true;
            this.new_textbox.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.new_textbox.Image = global::WinFormsApp3.Properties.Resources.new_plc_data;
            this.new_textbox.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.new_textbox.Location = new System.Drawing.Point(80, 14);
            this.new_textbox.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.new_textbox.Name = "new_textbox";
            this.new_textbox.Size = new System.Drawing.Size(84, 32);
            this.new_textbox.TabIndex = 1;
            this.new_textbox.Text = "PlcData";
            this.new_textbox.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.new_textbox.UseVisualStyleBackColor = true;
            this.new_textbox.Click += new System.EventHandler(this.new_textbox_Click);
            // 
            // new_label
            // 
            this.new_label.AutoSize = true;
            this.new_label.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.new_label.Image = global::WinFormsApp3.Properties.Resources.new_label;
            this.new_label.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.new_label.Location = new System.Drawing.Point(3, 14);
            this.new_label.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.new_label.Name = "new_label";
            this.new_label.Size = new System.Drawing.Size(72, 33);
            this.new_label.TabIndex = 0;
            this.new_label.Text = "Texto";
            this.new_label.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.new_label.UseVisualStyleBackColor = true;
            this.new_label.Click += new System.EventHandler(this.new_label_Click);
            // 
            // MainForm_Panel
            // 
            this.MainForm_Panel.BackColor = System.Drawing.SystemColors.AppWorkspace;
            this.MainForm_Panel.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.MainForm_Panel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.MainForm_Panel.Location = new System.Drawing.Point(0, 74);
            this.MainForm_Panel.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.MainForm_Panel.Name = "MainForm_Panel";
            this.MainForm_Panel.Size = new System.Drawing.Size(1239, 508);
            this.MainForm_Panel.TabIndex = 3;
            this.MainForm_Panel.Paint += new System.Windows.Forms.PaintEventHandler(this.MainForm_Panel_Paint_1);
            // 
            // MainForm_Panel_propertyGrid
            // 
            this.MainForm_Panel_propertyGrid.Dock = System.Windows.Forms.DockStyle.Right;
            this.MainForm_Panel_propertyGrid.Enabled = false;
            this.MainForm_Panel_propertyGrid.Location = new System.Drawing.Point(978, 74);
            this.MainForm_Panel_propertyGrid.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.MainForm_Panel_propertyGrid.Name = "MainForm_Panel_propertyGrid";
            this.MainForm_Panel_propertyGrid.Size = new System.Drawing.Size(261, 508);
            this.MainForm_Panel_propertyGrid.TabIndex = 4;
            this.MainForm_Panel_propertyGrid.Visible = false;
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1239, 606);
            this.Controls.Add(this.MainForm_Panel_propertyGrid);
            this.Controls.Add(this.MainForm_Panel);
            this.Controls.Add(this.MainForm_Panel_topPanel);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Name = "MainForm";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.MainForm_Load);
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.MainForm_Panel_topPanel.ResumeLayout(false);
            this.MainForm_Panel_topPanel.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private StatusStrip statusStrip1;
        private MenuStrip menuStrip1;
        private ToolStripStatusLabel toolStripStatusLabel1;
        public ToolStripStatusLabel toolStrip_connectionStatus;
        private ToolStripMenuItem inicioToolStripMenuItem;
        private Panel MainForm_Panel_topPanel;
        private ToolStripMenuItem cargarConfiguracionToolStripMenuItem;
        private ToolStripMenuItem guardarConfiguraciónToolStripMenuItem;
        private Button new_textbox;
        private Button new_label;
        private Button button1;
        public Panel MainForm_Panel;
        private PropertyGrid MainForm_Panel_propertyGrid;
        Control SelectedControl;
        const int DRAG_HANDLE_SIZE = 7;
        int mouseX, mouseY;
        private ToolStripMenuItem configuracionesToolStripMenuItem;
        private ToolStripMenuItem datosPLCToolStripMenuItem;
        private ToolStripMenuItem administracionToolStripMenuItem;
        private ToolStripMenuItem habilitarModoEdicionToolStripMenuItem;
        private ToolStripMenuItem nuevaConexionPLCToolStripMenuItem;
        private Button new_image;
    }
}