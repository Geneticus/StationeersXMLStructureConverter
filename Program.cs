using StationeersStructureXMLConverter;
using System;
using System.Windows.Forms;

namespace StationeersXMLStructureConverter
{
    static class Program
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
