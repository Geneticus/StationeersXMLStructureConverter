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

            // Types to process (exact from decompile/output)
            var typeNames = new[]
            {
                "Assets.Scripts.Serialization.XmlSaveLoad+WorldData",  // For World.xml
                "WorldSettingData"  // No prefix, as per match for worldsettings.xml
            };

            foreach (var typeName in typeNames)
            {
                Type type = gameAsm.GetType(typeName);
                if (type != null)
                {
                    Console.WriteLine($"Processing type: {type.FullName}");

                    try
                    {
                        // Generate XSD for this type
                        var importer = new XmlReflectionImporter();
                        var mapping = importer.ImportTypeMapping(type, "http://stationeers.com/data");  // Shared namespace
                        var schemas = new XmlSchemas();  // Create empty schemas first
                        var exporter = new XmlSchemaExporter(schemas);  // Pass schemas to exporter
                        exporter.ExportTypeMapping(mapping);  // Exports full graph (e.g., WorldData -> Things, WorldSettingData -> SpawnDatas)

                        string xsdName = type.Name.Contains("WorldData") ? "World.xsd" : "WorldSetting.xsd";
                        using (var writer = XmlWriter.Create(xsdName))
                        {
                            if (schemas.Count > 0)
                            {
                                schemas[0].Write(writer);  // Write the primary schema
                            }
                        }
                        Console.WriteLine($"XSD generated: {xsdName} (size: {new FileInfo(xsdName).Length} bytes)");
                    }
                    catch (Exception genEx)
                    {
                        Console.WriteLine($"Schema generation failed for {type.Name}: {genEx.Message}");
                    }
                }
                else
                {
                    Console.WriteLine($"Type not found: {typeName}");
                    // Fallback: Search for similar names
                    var matchingTypes = gameAsm.GetTypes().Where(t => t.Name.Contains("WorldSettingData")).ToList();
                    if (matchingTypes.Any())
                    {
                        Console.WriteLine("Matching types found:");
                        foreach (var match in matchingTypes)
                        {
                            Console.WriteLine($"  - {match.FullName}");
                        }
                    }
                    else
                    {
                        Console.WriteLine("No matching types found—search dotPeek for 'WorldSettingData' and copy full name.");
                    }
                }
            }

            Console.WriteLine("Press any key to exit...");
            Console.ReadKey();
        }
    }
}