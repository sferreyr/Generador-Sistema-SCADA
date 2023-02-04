using Newtonsoft.Json.Linq;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;
using WinFormsApp3.Models;
using System.Windows.Forms;
using WinFormsApp3.WidgetsTools;

namespace WinFormsApp3.Managers
{

    class PLCConfigurationManager
    {

        //  private MainForm _mainform;


        List<PlcConfiguration> PlcConfigurations = new List<PlcConfiguration>();
        private newPlcConfigForm _configForm;
        private NewTextBoxForm _textboxForm;


        public PLCConfigurationManager(newPlcConfigForm newPlcConfigForm)
        {
            this._configForm = newPlcConfigForm;
        }


        public PLCConfigurationManager(NewTextBoxForm newtextboxform)
        {
            this._textboxForm = newtextboxform;
        }


        private Type GetTypeNameFromDomain(string typename)
        {
            return AppDomain.CurrentDomain.GetAssemblies().SelectMany(assembly => assembly.GetTypes().Where(type => type.FullName == typename)).FirstOrDefault();
        }

        public void LoadPLCConfiguration()
        {


            string json = File.ReadAllText("configurations.json");
            PlcConfigurations = JsonConvert.DeserializeObject<List<PlcConfiguration>>(json);

            //Load Configuration 
            if (PlcConfigurations != null)
            {
                //New Textbox PLC

                if (_configForm != null)
                {

                    //add Info to NewPLcConfigForm
                    foreach (var item in PlcConfigurations)
                    {
                        _configForm.dataGridView1.Rows.Add(item.id, item.SignalName, item.MemoryAddress, item.Description);
                    }

                    // _configForm.dataGridView1.DataSource = PlcConfigurations;
                    _configForm.lastId = PlcConfigurations.Count();
                }
                if (_textboxForm != null) {

                    //add Info to NewPLcConfigForm
                    foreach (var item in PlcConfigurations)
                    {
                        //_textboxForm.listBox1.Items.Clear();
                        _textboxForm.listBox1.Items.Add(item);
                        _textboxForm.listBox1.DisplayMember = "SignalName";


                    }




                }




            }
        }


        public void SavePLCConfiguration()
        {
            // Crea una lista de objetos PlcConfiguration
            List<PlcConfiguration> Plc = new List<PlcConfiguration>();
            List<PlcConfiguration> configurations = new List<PlcConfiguration>();

            // Recorre las filas del DataGridView y añade los valores a la lista
            foreach (DataGridViewRow row in _configForm.dataGridView1.Rows)
            {
                // Crea un objeto PlcConfiguration con los valores de la fila actual
                // Salta las filas de encabezado y las filas vacías
                if (row.IsNewRow
                    || row.Cells["DataSignalName"].Value == null
                    || row.Cells["MemoryAddress"].Value == null
                    || row.Cells["Description"].Value == null
                    )
                    continue;

                PlcConfiguration configuration = new PlcConfiguration
                {
                    id = (int)row.Cells["Id"].Value,
                    //    PlcIpAddress = (string)row.Cells["DataSignalName"].Value,
                    SignalName = (string)row.Cells["DataSignalName"].Value,
                    MemoryAddress = (string)row.Cells["MemoryAddress"].Value,
                    Description = (string)row.Cells["Description"].Value


                };

                // Añade el objeto a la lista
                Plc.Add(configuration);
            }



            // Convertir la lista de objetos PlcConfiguration a una cadena de texto en formato JSON
            string json = JsonConvert.SerializeObject(Plc);

            // Mostrar un cuadro de diálogo de guardado de archivo y obtener la ruta seleccionada por el usuario
            SaveFileDialog saveFileDialog = new SaveFileDialog();
            saveFileDialog.Filter = "Archivo JSON|*.json";
            saveFileDialog.Title = "Guardar configuraciones";
            saveFileDialog.ShowDialog();

            // Si el usuario seleccionó una ruta de archivo válida, escribir la cadena de texto en el archivo
            if (saveFileDialog.FileName != "")
            {
                File.WriteAllText(saveFileDialog.FileName, json);
            }

            /*   if (_mainform.Controls.Count > 0)
               {

                   // Obtiene todos los controles del panel
                   Control[] controls = _mainform.MainForm_Panel.Controls.Cast<Control>().ToArray();

                   // Crea una lista para almacenar los objetos JSON de cada control
                   List<JObject> controlObjects = new List<JObject>();

                   // Itera sobre cada control y crea un objeto JSON para él
                   foreach (Control control in controls)
                   {
                       // Crea un objeto JSON para el control
                       JObject controlObject = new JObject
                       {
                           // Agrega las propiedades del control al objeto JSON
                           ["Name"] = control.Name,
                           ["Text"] = control.Text,
                           ["Location"] = new JObject
                           {
                               ["X"] = control.Location.X,
                               ["Y"] = control.Location.Y
                           },
                           ["Size"] = new JObject
                           {
                               ["Width"] = control.Size.Width,
                               ["Height"] = control.Size.Height
                           },
                           // ["Type"] = "System.Windows.Forms." + control.GetType().Name
                           ["Type"] = control.GetType().Name
                       };

                       // Agrega el objeto JSON del control a la lista
                       controlObjects.Add(controlObject);
                   }

                   // Crea un objeto JSON principal que almacenará la lista de objetos de cada control
                   JObject rootObject = new JObject
                   {
                       // Agrega la lista de objetos de cada control al objeto principal
                       ["Controls"] = new JArray(controlObjects)
                   };

                   // Serializa el objeto principal a una cadena JSON y la guarda en el archivo
                   File.WriteAllText("test.json", rootObject.ToString());

               }
           }

           */
        }
    }
}
