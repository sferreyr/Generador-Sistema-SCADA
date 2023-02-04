using Newtonsoft.Json.Linq;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Serialization;

using WinFormsApp3.Models;
using System.Linq.Expressions;

namespace WinFormsApp3.Managers
{
    class GUIConfigurationManager
    {

        private MainForm _mainform;


        public GUIConfigurationManager(MainForm mainform)
        {
            this._mainform = mainform;
        }

        private Type GetTypeNameFromDomain(string typename)
        {
            return AppDomain.CurrentDomain.GetAssemblies().SelectMany(assembly => assembly.GetTypes().Where(type => type.FullName == typename)).FirstOrDefault();
        }

        public void LoadGUIConfig()
        {
            //Limpiamos Controles
            if (_mainform.Controls.Count > 0)
            {
                _mainform.MainForm_Panel.Controls.Clear();
                while (_mainform.MainForm_Panel.Controls.Count > 0)
                {
                    Control control = _mainform.MainForm_Panel.Controls[0];
                    _mainform.MainForm_Panel.Controls.Remove(control);
                    control.Dispose();
                }

            }


            // Crea una lista para almacenar los objetos de cada control
            List<JObject> controlObjects = new List<JObject>();

            // Abre el archivo JSON y carga su contenido en una cadena
            using (StreamReader file = File.OpenText("test.json"))
            {
                // Convierte la cadena en un objeto JObject
                JObject rootObject = (JObject)JToken.ReadFrom(new JsonTextReader(file));

                // Obtiene la lista de objetos de cada control del objeto JObject principal
                controlObjects = rootObject["Controls"].ToObject<List<JObject>>();
            }

            // Itera sobre cada objeto JSON del control y crea un nuevo control en el panel
            foreach (JObject controlObject in controlObjects)
            {
                // Obtiene el tipo de control a partir del nombre de la clase almacenado en el objeto JSON

                if (controlObject != null)
                {
                    // Type controlType = Type.GetType("System.Windows.Forms." + controlObject["Type"].ToString());

                    Type controlType = GetTypeNameFromDomain("System.Windows.Forms." + controlObject["Type"].ToString());

                    // Crea una nueva instancia del control a partir del tipo obtenido
                    Control control = (Control)Activator.CreateInstance(controlType);

                    // Establece las propiedades del control a partir de los valores almacenados en el objeto JSON
                    control.Name = controlObject["Name"].ToString();
                    control.Text = controlObject["Text"].ToString();
                    control.Location = new Point(controlObject["Location"]["X"].ToObject<int>(), controlObject["Location"]["Y"].ToObject<int>());
                    control.Size = new Size(controlObject["Size"]["Width"].ToObject<int>(), controlObject["Size"]["Height"].ToObject<int>());


                    if (!controlObject["Name"].ToString().Equals( "MainForm_Panel")) { 
                    //Mas opciones.
                    control.Draggable(true);
                    control.MouseDown += new MouseEventHandler(_mainform.control_MouseDown);
                    control.MouseMove += new MouseEventHandler(_mainform.control_MouseMove);
                    control.MouseUp += new MouseEventHandler(_mainform.control_MouseUp);
                    control.BringToFront();
               
                    // Agrega el control al panel
                    _mainform.MainForm_Panel.Controls.Add(control);


                        //Agregamos controles A sus respectivas listas, para poder actualizar valores plc.
                        switch (controlObject["Type"].ToString())
                        {
                            case "TextBox":
                                _mainform.TextboxControl.Add(control);
                                break;
                            case "Label":
                               _mainform.LabelControl.Add(control);
                                break;
                            default:
                                // code block
                                break;
                        }

                   
                    }
                }
            }

        }

        public void SaveGUIConfig()
        {
            if (_mainform.Controls.Count > 0)
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


    }


}

