using Mtf.Core;
using System;
using System.Windows.Forms;

namespace HighLevelDesigner
{
    static class Program
    {
        private static ExceptionCatcher exceptionCatcher;

        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            exceptionCatcher = new ExceptionCatcher($"{Application.ProductName} - {Application.ProductVersion}", true, false, true);

            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new MainForm());
        }
    }
}
