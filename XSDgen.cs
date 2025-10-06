using System;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Xml;
using System.Xml.Schema;
using System.Xml.Serialization;

namespace XsdGenerator
{
    class Program
    {
        static void Main(string[] args)
        {
            string dllPath = @"U:\SteamLibrary2\steamapps\common\Stationeers\rocketstation_Data\Managed\Assembly-CSharp.dll";
            if (!File.Exists(dllPath))
            {
                Console.WriteLine($"Game DLL not found at {dllPath}. Adjust path and retry.");
                return;
            }

            Assembly gameAsm = null;
            try
            {
                gameAsm = Assembly.LoadFrom(dllPath);
                Console.WriteLine("Game assembly loaded.");
            }
            catch (Exception loadEx)
            {
                Console.WriteLine($"Failed to load assembly: {loadEx.Message}");
                return;
            }

            // Reflect the world/save data type (exact from decompile: inner class on XmlSaveLoad)
            Type worldType = gameAsm.GetType("Assets.Scripts.Serialization.XmlSaveLoad+WorldData");
            if (worldType == null)
            {
                Console.WriteLine("WorldData type not found. Confirm namespace in dotPeek and update.");
                return;
            }
            Console.WriteLine($"Found type: {worldType.FullName}");

            try
            {
                // Generate XSD via XmlReflectionImporter + XmlSchemas + XmlSchemaExporter (infers from attributes)
                var importer = new XmlReflectionImporter();
                var mapping = importer.ImportTypeMapping(worldType, "http://stationeers.com/world");  // Namespace for schema
                var schemas = new XmlSchemas();  // Create empty schemas first
                var exporter = new XmlSchemaExporter(schemas);  // Pass schemas to exporter
                exporter.ExportTypeMapping(mapping);  // Exports full graph to schemas (WorldData -> Things -> AtmosphereSaveData, etc.)
                Console.WriteLine("Schema exported successfully.");

                string xsdPath = "World.xsd";
                using (var writer = XmlWriter.Create(xsdPath))
                {
                    if (schemas.Count > 0)
                    {
                        schemas[0].Write(writer);  // Write the primary schema
                    }
                }
                Console.WriteLine($"XSD generated: {xsdPath} (size: {new FileInfo(xsdPath).Length} bytes)");
            }
            catch (Exception genEx)
            {
                Console.WriteLine($"Schema generation failed: {genEx.Message}");
                return;
            }

            Console.WriteLine("Press any key to exit...");
            Console.ReadKey();
        }
    }
}