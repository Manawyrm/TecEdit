using de.manawyrm.TecEdit.Kernel;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Xml.Serialization;

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
      mAccount = new Account("http://teccraft.de/tecedit/", "", "");
    }

    private Account mAccount;
    public Account Account
    {
      get { return mAccount; }
      set { mAccount = value; }
    }
  }

  public class Account
  {
    private string mUsername;
    private string mPasswort;
    private string mHostURL;
    private bool mSaveAllowed;

    public Account()
    { }

    public Account(string url, string username, string passwort)
    {
      mUsername = username;
      mPasswort = passwort;
      mHostURL = url;
    }

    public string Username
    {
      get { return mUsername; }
      set { mUsername = value; }
    }

    public string Passwort
    {
      get { return mPasswort; }
      set { mPasswort = value; }
    }

    public string HostURL
    {
      get { return mHostURL; }
      set { mHostURL = value; }
    }

    public bool HasUser
    {
      get { return !string.IsNullOrEmpty(Username); }
    }

    public bool HasPassword
    {
      get { return !string.IsNullOrEmpty(Passwort); }
    }

    public bool HasLogin
    {
      get { return HasUser && HasPassword; }
    }

    public bool HasURL
    {
      get { return !string.IsNullOrEmpty(HostURL); }
    }

    public bool SaveAllowed
    {
      get { return mSaveAllowed; }
    }

    public void Reset()
    {
      Passwort = "";
      Username = "";
    }

    public void SetAccount(bool doSave, Account account)
    {
      SetAccount(account);
      mSaveAllowed = doSave;
    }

    private void SetAccount(Account account)
    {
      mUsername = account.Username;
      mPasswort = account.Passwort;
      mHostURL = account.HostURL;
    }
  }
}

