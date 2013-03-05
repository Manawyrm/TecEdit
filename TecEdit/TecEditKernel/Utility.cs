﻿using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace de.manawyrm.TecEdit.Kernel
{
  public static class Utility
  {
    public static void OpenBrowser(string url)
    {
      try
      {
        if (Uri.IsWellFormedUriString(url, UriKind.Absolute))
          Process.Start(url);
      }
      catch (Exception ex)
      {
        ExeptionLogger.Log(ex);
      }
    }

    public static void CloseApplication()
    {
      Settings.Save();
      Application.Exit();
    }

    public static string SettingsFilePath
    {
      get { return Path.Combine(Application.StartupPath, "conf"); }
    }
  }
}