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
                string generatorPath = Path.Combine(Application.StartupPath, "StationeersXsdGenerator.exe");
                if (!File.Exists(generatorPath))
                {
                    conversionUserControl.AppendLog("XSD generator not found.");
                    return;
                }
                string assemblyPath = Path.Combine(stationeersPath ?? @"C:\Program Files (x86)\Steam\steamapps\common\Stationeers", "rocketstation.exe");
                Process.Start(generatorPath, $"--assembly \"{assemblyPath}\" --output \"{outputPath}\"");
                conversionUserControl.AppendLog("Running XSD generator...");
            }
            catch (Exception ex)
            {
                conversionUserControl.AppendLog($"Error running XSD generator: {ex.Message}");
            }
        }
    }
}