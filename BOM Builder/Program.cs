using BOM_Builder.Controllers;
using BOM_Builder.Models;
using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace BOM_Builder
{
   static class Program
   {
        
      /// <summary>
      /// Punto de entrada principal para la aplicación.
      /// </summary>
      [STAThread]
      static void Main()
      {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new frmMenu());//frmLogin());
      }

   }
}
