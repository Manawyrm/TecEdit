using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using de.manawyrm.TecEdit.Kernel;
using de.manawyrm.TecEdit.Kernel.DataTypes;

namespace de.manawyrm.TecEdit.Kernel.Controls
{
  public partial class CtlLogin : UserControl
  {
    public CtlLogin()
    {
      InitializeComponent();
    }

    /// <summary>
    /// Lädt die gesicherten Login Daten in die Maske
    /// </summary>
    public void Init()
    {
      ResetLabel();

      if (Settings.AppSettings.Account.HasURL)
        tbxHost.Text = Settings.AppSettings.Account.HostURL;

      if (Settings.AppSettings.Account.HasLogin)
      {
        tbxUser.Text = Settings.AppSettings.Account.Username;
        tbxPassw.Text = Settings.AppSettings.Account.Passwort;
      }
      else
        tbxUser.Focus();
    }

    private void ResetLabel()
    {
      tbxUser.Text = "";
      tbxPassw.Text = "";
      tbxHost.Text = "";
    }

    private void tbxHost_Validating(object sender, CancelEventArgs e)
    {
      if (!tbxHost.Text.StartsWith("http://") || !tbxHost.Text.EndsWith("/") || Uri.IsWellFormedUriString(tbxHost.Text, UriKind.Relative))
        eProvider.SetError(tbxHost, "Der Hostname muss eine valide HTTP-URL sein.\r\n"
          + "Sie muss mit http:// beginnen, und sollte, wenn man sie in einem WebBrowser eingibt, eine TecEdit Infoseite darstellen.\r\n"
          + "Der Hostname muss mit einem Slash (/) aufhören!");
      else
        eProvider.SetError(tbxHost, "");
    }

    private void tbxUser_Validating(object sender, CancelEventArgs e)
    {
      if (string.IsNullOrEmpty(tbxUser.Text))
        eProvider.SetError(tbxUser, "Es muss ein valider Nutzername eingegeben werden!\r\n"
          + "Im Normalfall ist das dein Minecraft Nickname.");
      else
        eProvider.SetError(tbxUser, "");
    }

    private void tbxPassw_Validating(object sender, CancelEventArgs e)
    {
      if (string.IsNullOrEmpty(tbxPassw.Text))
        eProvider.SetError(tbxPassw, "Es muss ein valides Kennwort eingegeben werden!\r\n"
          + "Im Normalfall ist das dein Minecraft Nickname.");
      else
        eProvider.SetError(tbxPassw, "");
    }

    /// <summary>
    /// Liefert die AccountDaten der Login Form
    /// Falls speichern angeharkt ist werden die Daten gleich gesichert
    /// </summary>
    /// <returns></returns>
    public Account GetAccount()
    {
      if (ValidateForm())
      {
        Account ac = new Account(tbxHost.Text, tbxUser.Text, tbxPassw.Text);
        Settings.AppSettings.Account.SetAccount(true, ac);
        Settings.Save();
        return ac;
      }
      else
        return null;
    }

    /// <summary>
    /// Liefert True wenn Login Control richtig befüllt ist ansonsten false
    /// </summary>
    /// <returns></returns>
    public bool ValidateForm()
    {
      bool state = true;

      if (!string.IsNullOrEmpty(eProvider.GetError(tbxHost)))
        state = false;
      else if (!string.IsNullOrEmpty(eProvider.GetError(tbxUser)))
        state = false;
      else if (!string.IsNullOrEmpty(eProvider.GetError(tbxPassw)))
        state = false;
      return state;
    }

    private void CtlLogin_Load(object sender, EventArgs e)
    {

    }
  }
}
