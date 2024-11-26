using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ChillDeCojones
{
    internal static class Program
    {
        private static Precargador precargador;
        /// <summary>
        /// Punto de entrada principal para la aplicación.
        /// </summary>
        [STAThread]
        static void Main()
        {
            precargador = new Precargador();
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Common commonForm = new Common();
            Application.Run(commonForm);
        }
    }
}
