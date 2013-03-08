using System;
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
      get { return Path.Combine(Application.StartupPath, Constants.SettingsFileName); }
    }

    public static long CalculateFileSize(string fContent)
    {
      return new ASCIIEncoding().GetBytes(fContent).Length;
    }

    public static string BytesToFormattedString(long bytes)
    {
      double s = bytes;
      string[] format = new string[]
                  {
                      "{0} bytes", "{0} KB",  
                      "{0} MB", "{0} GB", "{0} TB", "{0} PB", "{0} EB"
                  };

      int i = 0;
      while (i < format.Length && s >= 1024)
      {
        s = (long)(100 * s / 1024) / 100.0;
        i++;
      }
      return string.Format(format[i], s);
    }
  }
}