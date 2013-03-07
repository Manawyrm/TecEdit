using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace de.manawyrm.TecEdit
{
  static class Program
  {
    /// <summary>
    /// Der Haupteinstiegspunkt für die Anwendung.
    /// </summary>
    [STAThread]
    static void Main(string[] args)
    {
      Application.EnableVisualStyles();
      Application.SetCompatibleTextRenderingDefault(false);

      if (args != null && args.Length > 0 && args[0] == "-tester")
        Application.Run(new FrmTest());
      else
        Application.Run(new FrmLogin());
    }
  }
}
