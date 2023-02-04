using EasyModbus;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Timers;

namespace WinFormsApp3.PLC
{
    class PlCBackgroundWorker : BackgroundWorker
    {

        // Diccionario que almacena las referencias a los TextBox dinámicos
        private Dictionary<string, TextBox> textBoxes = new Dictionary<string, TextBox>();

        // Objeto de la clase System.Timers.Timer que se encarga de ejecutar la conexión al PLC cada 10 segundos
        private System.Timers.Timer timer = new System.Timers.Timer();

        // Lista que almacena las referencias a los TextBox

        private List<TextBox> _textBoxes = new List<TextBox>();
        public MainForm _mainform;

        // Constructor de la clase PLCConnection
        public PlCBackgroundWorker(MainForm form)
        {
            // Establecemos el intervalo de tiempo en 10 segundos (10000 milisegundos)
            timer.Interval = 1000;
            _mainform = form;

            // Asignamos el método que se ejecutará cada vez que se cumpla el intervalo de tiempo
            timer.Elapsed += ConnectToPLC;



        }




        // Método que inicia la conexión al PLC
        public void Start()
        {
            // Iniciamos el temporizador
            timer.Start();
        }


        // Método que realiza la conexión al PLC
        private void ConnectToPLC(object sender, ElapsedEventArgs e)
        {
            // Creamos una nueva instancia de la clase ModbusClient
            ModbusClient modbusClient = new ModbusClient();

            // Establecemos la dirección IP y el puerto del PLC
            modbusClient.IPAddress = "192.168.100.5";
            modbusClient.Port = 502;

            // Realizamos la conexión al PLC
            try
            {
                modbusClient.Connect();

            }
            catch (Exception)
            {
                timer.Stop();
                MessageBox.Show("Imposible conectarse al PLC");
            }


            if (modbusClient.Connected)
            {

                _mainform.toolStrip_connectionStatus.Text = "ONLINE";
                _mainform.toolStrip_connectionStatus.ForeColor = Color.Green;
                // Expresión regular que busca el valor de la dirección de memoria del nombre del TextBox
                Regex regex = new Regex(@"Txb_\d+_(\d+)");

                // Recorremos todos los TextBox de la lista
                foreach (TextBox textBox in _mainform.TextboxControl)
                {
                    // Obtenemos el resultado del match de la expresión regular con el nombre del TextBox
                    Match match = regex.Match(textBox.Name);

                    // Si se encontró una coincidencia con la expresión regular o si el TextBox no tiene nombre
                    if (match.Success || string.IsNullOrEmpty(textBox.Name))
                    {
                        // Si se encontró una coincidencia con la expresión regular
                        if (match.Success)
                        {
                            // Obtenemos la dirección de memoria del TextBox
                            int address = int.Parse(match.Groups[1].Value);

                            // Leemos el valor de la dirección de memoria del PLC
                            int value = modbusClient.ReadHoldingRegisters(address, 1)[0];

                            // Actualizamos el valor del TextBox
                            UpdateTextBox(textBox, value.ToString());
                        }
                        // Si el TextBox no tiene nombre
                        else
                        {
                            // Establecemos el valor del TextBox en vacío
                            UpdateTextBox(textBox, string.Empty);
                        }
                    }
                }



            }
            else
            {
                _mainform.toolStrip_connectionStatus.Text = "Offline";
                _mainform.toolStrip_connectionStatus.ForeColor = Color.Red;
            }


            // Cerramos la conexión con el PLC
            modbusClient.Disconnect();


        }

        // Método que actualiza el valor de un TextBox
        private void UpdateTextBox(TextBox textBox, string value)
        {
            // Si la propiedad InvokeRequired es true, significa que el código se está ejecutando en un hilo diferente al hilo principal
            if (textBox.InvokeRequired)
            {
                // En este caso, invocamos al método UpdateTextBox utilizando la propiedad Invoke
                textBox.Invoke((MethodInvoker)delegate { UpdateTextBox(textBox, value); });
            }
            else
            {
                // Si no es necesario utilizar la propiedad Invoke, actualizamos el valor del TextBox directamente
                textBox.Text = value;
            }
        }





    }
}
