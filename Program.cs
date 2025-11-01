using StationeersStructureXMLConverter;
using System;
using System.Windows.Forms;

namespace StationeersStructureXMLConverter
{
    internal static class Program
    {
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new Main_Form());
        }
    
    }
}
