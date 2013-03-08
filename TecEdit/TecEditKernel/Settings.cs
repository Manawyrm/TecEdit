using de.manawyrm.TecEdit.Kernel;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Xml.Serialization;
using de.manawyrm.TecEdit.Kernel.DataTypes;

namespace de.manawyrm.TecEdit.Kernel
{
  public static class Settings
  {
    public static SettingsFile mSettings;

    public static SettingsFile AppSettings
    {
      get
      {
        if (mSettings == null)
          Load();
        return mSettings;
      }
    }

    public static void ResetAccount()
    {
      AppSettings.Account.Reset();
      Settings.Save();
      Settings.Load();
    }

    /// <summary>
    /// Nur bei Programm Ende einmalig aufrufen
    /// </summary>
    public static void Save()
    {
      if (mSettings != null)
      {
        if (!mSettings.Account.SaveAllowed)
          mSettings.Account.Reset();
        try
        {
          XmlSerializer seria = new XmlSerializer(typeof(SettingsFile));
          using (StreamWriter fs = new StreamWriter(Utility.SettingsFilePath))
            seria.Serialize(fs, mSettings);
        }
        catch (Exception ex)
        {
          ExeptionLogger.Log(ex);
        }
      }
    }

    private static void Load()
    {
      if (!File.Exists(Utility.SettingsFilePath))
        CreateDefaultFile();
      else
      {
        XmlSerializer seria = new XmlSerializer(typeof(SettingsFile));

        using (StreamReader fs = new StreamReader(Utility.SettingsFilePath))
        {
          try
          {
            mSettings = (SettingsFile)seria.Deserialize(fs);
          }
          catch (SystemException ex)
          {
            ExeptionLogger.Log(ex);
          }
        }
      }
    }

    private static void CreateDefaultFile()
    {
      SettingsFile s = new SettingsFile();
      mSettings = s;
      Save();
    }
  }

  public class SettingsFile
  {
    public SettingsFile()
    {
      mAccount = new Account(Constants.DefaultURL, "", "");
      ShowStatusbar = true;
      ShowSymbolBar = true;
    }

    private bool mShowSymbolBar;
    public bool ShowSymbolBar
    {
      get { return mShowSymbolBar; }
      set { mShowSymbolBar = value; }
    }

    private bool mShowStatusbar;
    public bool ShowStatusbar
    {
      get { return mShowStatusbar; }
      set { mShowStatusbar = value; }
    }

    private Account mAccount;
    public Account Account
    {
      get { return mAccount; }
      set { mAccount = value; }
    }
  }
}