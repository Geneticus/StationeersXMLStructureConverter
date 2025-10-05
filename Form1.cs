using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml;
using System.Xml.Linq;
using System.Xml.Serialization;
using static StationeersStructureXMLConverter.SaveFileClass;


namespace StationeersStructureXMLConverter
{
    
    
    public partial class Form1 : Form
    {

        private bool convertComplete = false;
        private string results;
        public static string parsingErrors;
        private WorldData serialObject = new WorldData();


        //public static parseWorldData DeserializeXMLFileToObject<parseWorldData>(string XmlFilename)
        //{
        //    parseWorldData returnObject = default(parseWorldData);
        //    if (string.IsNullOrEmpty(XmlFilename)) return default(parseWorldData);

        //    try
        //    {

        //        StreamReader xmlStream = new StreamReader(XmlFilename);
        //        XmlSerializer serializer = new XmlSerializer(typeof(WorldData));
        //        returnObject = (parseWorldData)serializer.Deserialize(xmlStream);
        //    }
        //    catch (Exception ex)
        //    {
        //        parsingErrors += "/n " + ex.Message + " , " + ex.InnerException;
        //    }
        //    return returnObject;
        //}
        public static WorldData DeserializeXMLFileToObject(string XmlFilename)
        {
            WorldData returnObject = default(WorldData);
            if (!File.Exists(XmlFilename))
            {
                throw new FileNotFoundException($"The file {XmlFilename} was not found.");
            }

            
                using (StreamReader xmlStream = new StreamReader(XmlFilename))
                {
                    // Create an XmlReader to manually step through the XML
                    XmlReaderSettings settings = new XmlReaderSettings { DtdProcessing = DtdProcessing.Parse };
                    using (XmlReader reader = XmlReader.Create(xmlStream, settings))
                    {
                        using (StreamReader sr = new StreamReader(XmlFilename))
                        {
                            string xmlContent = sr.ReadToEnd();
                            Console.WriteLine("XML Content:");
                            Console.WriteLine(xmlContent);
                        }
                        while (reader.Read())
                        {
                            Console.WriteLine(value: $"Node Type: {reader.NodeType}, Name: {reader.Name}, Value: {reader.Value} , Line: {((IXmlLineInfo)reader).LineNumber}");
                            // Manually step through and break if needed
                        }
                    try
                    {
                        // Set a breakpoint here to monitor deserialization progress
                        XmlSerializer serializer = new XmlSerializer(typeof(WorldData));
                        serializer.UnknownElement += (sender, e) =>
                        {
                            Console.WriteLine($"Unknown element: {e.Element.Name}");
                        };
                        WorldData result = null;
                        using (StreamReader file = new StreamReader(XmlFilename))
                        {
                            result = (WorldData)serializer.Deserialize(file);
                        }  // Step into this to see the details
                        Console.WriteLine($"Deserialized result: {result}");
                        if (result != null)
                        {
                            Console.WriteLine("Deserialization successful.");
                        }
                    }
                    catch(Exception ex)
                    {
                        Console.WriteLine($"Deserialization failed: {ex.Message}");
                        if (ex.InnerException != null)
                        {
                            Console.WriteLine($"Inner exception: {ex.InnerException.Message}");
                        }
                    }
                }
                }
            
            
            return returnObject;
        }



        public Form1()
        {
            InitializeComponent();
        }

        private void sourceButton_Click_1(object sender, EventArgs e)
        {
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                sourceFile_TextBox.Text = openFileDialog1.InitialDirectory += openFileDialog1.FileName;
                
            }
        }

        private void DestinationButton_Click(object sender, EventArgs e)
        {
            if(saveFileDialog1.ShowDialog() == DialogResult.OK)
            {
                //destinationFile_TextBox.Text = saveFileDialog1.InitialDirectory += saveFileDialog1.FileName;
                
            }
            
        }

        private void Convert_Click(object sender, EventArgs e)
        {
            sourceFile_TextBox.Text = "U:\\SteamLibrary2\\steamapps\\common\\Stationeers\\rocketstation_Data\\StreamingAssets\\Scenario\\EscapeFromMars\\Things.xml";
            //sourceFile_TextBox.Text = "U:\\Repos\\StationeersStructureXMLConverter\\ThingsTest.xml";
            destinationFile_TextBox.Text = "C:\\Users\\Geneticus\\Documents\\My Games\\Stationeers\\saves\\EscapeFromMars\\Things.xml";
            //if (saveFileDialog1.FileName != null && openFileDialog1.FileName != null)
            if (sourceFile_TextBox.Text != null)
            {
                string path = sourceFile_TextBox.Text;
                List<SaveFileClass.ThingSaveDataBase> thingsObject = new List<ThingSaveDataBase>();
                

                try
                {
                    if (File.Exists(path))
                    {
                        
                        serialObject  = DeserializeXMLFileToObject(path);

                        List <ThingSaveDataBase> thingsList = new List<ThingSaveDataBase>();

                        try
                        {
                            foreach (ThingSaveDataBase thingData in serialObject.Things)
                            {
                                thingsList.Add(thingData);
                            }
                        }
                        catch (Exception ex)
                        {
                            parsingErrors += "/n " + ex.Message + " , " + ex.InnerException;
                        }


                    }

                    
                }
                catch (Exception ex)
                {

                    Console.WriteLine("The process failed: {0}", ex.ToString());
                }
            }
            
            //if (!convertComplete) 
            //{
            //    string message = "You did not enter a server name. Cancel this operation?";
            //    string caption = "Error Detected in Input";
            //    MessageBoxButtons buttons = MessageBoxButtons.YesNo;
            //    DialogResult result;

            //    // Displays the MessageBox.
            //    result = MessageBox.Show(message, caption, buttons);
            //    if (result == System.Windows.Forms.DialogResult.Yes)
            //    {
            //        // Closes the parent form.
            //        this.Close();
            //    }
            //}
        }

        private void output_textBox_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
