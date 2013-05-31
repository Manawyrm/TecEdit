using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

using de.manawyrm.TecEdit.Kernel;
using de.manawyrm.TecEdit.Kernel.DataTypes.Interface;
using de.manawyrm.TecEdit.Kernel.DataTypes;

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
      //Init Events
      ctlFileExplorer1.NodeMouseDoubleClick += new EventHandler<GenericEventArgs<IFileSystemObject>>(ctlFileExplorer1_NodeMouseDoubleClick);

      //Load Settings
      btnViewSymbolBar.Checked = Settings.AppSettings.ShowSymbolBar;
      barSymbol.Visible = Settings.AppSettings.ShowSymbolBar;
      btnViewStateBar.Checked = Settings.AppSettings.ShowStatusbar;
      barStatus.Visible = Settings.AppSettings.ShowStatusbar;

      InitAPIMenu();

      //Set Status
      lblStatus.Text = string.Format("{0} angemeldet ...", Settings.AppSettings.Account.Username);
    }    

    public void SetLoginState(bool isOfflineMode)
    {
      if (isOfflineMode)
      {
        lblStatus.Text = string.Format("Offline: {0} angemeldet ...", Settings.AppSettings.Account.Username);
        TecEdit.Kernel.DataTypes.TecEditFolder f = new Kernel.DataTypes.TecEditFolder(@"C:\Server", true);
        ctlFileExplorer1.LoadData(f);
      }
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
        newitem.Click += apiMenuItem_Click;
        APIMenuItem.MenuItems.Add(newitem);
      }
    }

    void apiMenuItem_Click(object sender, EventArgs e)
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

    private void btnViewFolderBar_Click(object sender, EventArgs e)
    {
      btnViewFolderBar.Checked = !btnViewFolderBar.Checked;
      splitContainer1.Panel1Collapsed = !btnViewFolderBar.Checked;
      Settings.AppSettings.ShowFolderbar = !splitContainer1.Panel1Collapsed;
    }

    void ctlFileExplorer1_NodeMouseDoubleClick(object sender, GenericEventArgs<IFileSystemObject> e)
    {
      if (e.Result.FSType == FSObjectType.File)
      {
        TecEditFile f = (TecEditFile)e.Result;
        f.LoadContent();
        ctlEditorPane1.OpenFile(f);
      }
    }
  }
}
