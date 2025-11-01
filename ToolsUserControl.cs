using System;
using System.Diagnostics;
using System.IO;
using System.Windows.Forms;

namespace StationeersStructureXMLConverter
{
    public partial class ToolsUserControl : UserControl
    {
        private string outputPath;
        private string stationeersPath;
        private ConversionUserControl conversionUserControl;

        public ToolsUserControl()
        {
            InitializeComponent();
        }

        public string OutputPath
        {
            get => outputPath;
            set => outputPath = value;
        }

        public string StationeersPath
        {
            get => stationeersPath;
            set => stationeersPath = value;
        }

        public ConversionUserControl ConversionUserControl
        {
            get => conversionUserControl;
            set => conversionUserControl = value;
        }

        private void btnRunXsdGenerator_Click(object sender, EventArgs e)
        {
            try
            {
                // Point to the DLL instead of EXE
                string generatorDllPath = Path.Combine(Application.StartupPath, "StationeersXsdGenerator.dll");
                if (!File.Exists(generatorDllPath))
                {
                    conversionUserControl.AppendLog("XSD generator DLL not found.");
                    return;
                }

                // Ensure runtime config is present (optional safety check)
                string runtimeConfigPath = Path.Combine(Application.StartupPath, "StationeersXsdGenerator.runtimeconfig.json");
                if (!File.Exists(runtimeConfigPath))
                {
                    conversionUserControl.AppendLog("Missing runtimeconfig.json for XSD generator.");
                    return;
                }

                // Build the assembly path (same as before)
                string assemblyPath = Path.Combine(
                    stationeersPath ?? @"C:\Program Files (x86)\Steam\steamapps\common\Stationeers",
                    "rocketstation.exe");

                // Build arguments exactly as before
                string arguments = $"--assembly \"{assemblyPath}\" --output \"{outputPath}\"";

                // Start via 'dotnet' with the DLL
                var startInfo = new ProcessStartInfo
                {
                    FileName = "dotnet",
                    Arguments = $"\"{generatorDllPath}\" {arguments}",
                    UseShellExecute = false,
                    RedirectStandardOutput = true,
                    RedirectStandardError = true,
                    CreateNoWindow = true,
                    WorkingDirectory = Application.StartupPath
                };

                using (var process = Process.Start(startInfo))
                {
                    // Optional: capture output for logging
                    string output = process.StandardOutput.ReadToEnd();
                    string error = process.StandardError.ReadToEnd();

                    process.WaitForExit();

                    if (process.ExitCode == 0)
                    {
                        conversionUserControl.AppendLog("XSD generator completed successfully.");
                        if (!string.IsNullOrWhiteSpace(output))
                            conversionUserControl.AppendLog(output);
                    }
                    else
                    {
                        conversionUserControl.AppendLog($"XSD generator failed (Exit Code: {process.ExitCode}).");
                        if (!string.IsNullOrWhiteSpace(error))
                            conversionUserControl.AppendLog($"Error: {error}");
                    }
                }
            }
            catch (Exception ex)
            {
                conversionUserControl.AppendLog($"Error running XSD generator: {ex.Message}");
            }
        }
    }
}