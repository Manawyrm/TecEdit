using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

using de.manawyrm.TecEdit.Kernel;

namespace de.manawyrm.TecEdit
{
  public partial class FrmMain : Form
  {
    public FrmMain()
    {
      InitializeComponent();
      Init();
    }

    private void Init()
    {
      //Load Settings
      btnViewSymbolBar.Checked = Settings.AppSettings.ShowSymbolBar;
      barSymbol.Visible = Settings.AppSettings.ShowSymbolBar;
      btnViewStateBar.Checked = Settings.AppSettings.ShowStatusbar;
      barStatus.Visible = Settings.AppSettings.ShowStatusbar;

      InitAPIMenu();

      //Set Status
      lblStatus.Text = string.Format("{0} angemeldet ...", Settings.AppSettings.Account.Username);
    }

    private void btnDTLogut_Click(object sender, EventArgs e)
    {
      DialogResult = System.Windows.Forms.DialogResult.Retry;
    }

    private void btnDTExit_Click(object sender, EventArgs e)
    {
      DialogResult = System.Windows.Forms.DialogResult.Abort;
    }

    private void InitAPIMenu()
    {
      APIMenuItem.MenuItems.Clear();
      foreach (string apiName in Constants.Apis.Keys)
      {
        MenuItem newitem = new MenuItem(apiName);
        newitem.Click += ApiMenuItem_Click;
        APIMenuItem.MenuItems.Add(newitem);
      }
    }

    void ApiMenuItem_Click(object sender, EventArgs e)
    {
      MenuItem i = sender as MenuItem;
      if (i != null)
        Utility.OpenBrowser(Constants.Apis[i.Text]);
    }

    private void btnViewSymbolBar_Click(object sender, EventArgs e)
    {
      btnViewSymbolBar.Checked = !btnViewSymbolBar.Checked;
      barSymbol.Visible = btnViewSymbolBar.Checked;
      Settings.AppSettings.ShowSymbolBar = barSymbol.Visible;
    }

    private void btnViewStatebar_Click(object sender, EventArgs e)
    {
      btnViewStateBar.Checked = !btnViewStateBar.Checked;
      barStatus.Visible = btnViewStateBar.Checked;
      Settings.AppSettings.ShowStatusbar = barStatus.Visible;
    }
  }
}
