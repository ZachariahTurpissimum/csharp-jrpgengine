using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace csharp_jrpengine
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

            using (frmGame _fg = new frmGame())
            {
                _fg.Show();
                Game game = new Game(_fg);
                
                while (_fg.Visible)
                {
                    _fg.Update();
                    _fg.Draw();
                    Application.DoEvents();
                }
            }
        }
    }
}
