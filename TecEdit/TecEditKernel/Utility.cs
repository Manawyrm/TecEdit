using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using de.manawyrm.TecEdit.Kernel.DataTypes;

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
      if (!string.IsNullOrEmpty(fContent))
        return new ASCIIEncoding().GetBytes(fContent).Length;
      else
        return 0;
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

    static public string EncodeToB64(string toEncode)
    {
      byte[] toEncodeAsBytes = System.Text.ASCIIEncoding.Default.GetBytes(toEncode);
      return System.Convert.ToBase64String(toEncodeAsBytes);
    }

    static public string EncodeToB64(string toEncode, bool submitOverPHP)
    {
      string b64Data = EncodeToB64(toEncode);

      if (submitOverPHP)
        b64Data = b64Data.Replace('+', '|');

      return b64Data;
    }

    static public string DecodeFrom64(string encodedData)
    {
      byte[] encodedDataAsBytes = System.Convert.FromBase64String(encodedData);
      return System.Text.ASCIIEncoding.Default.GetString(encodedDataAsBytes);
    }
  }
}