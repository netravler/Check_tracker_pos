using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace Check_tracker_pos
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new check_tracker_pos());
        }
    }
}
