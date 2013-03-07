using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace de.manawyrm.TecEdit.Kernel.DataTypes
{
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
