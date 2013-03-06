using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

using de.manawyrm.TecEdit.Kernel;
using de.manawyrm.TecEdit.Kernel.Http;
using de.manawyrm.TecEdit.Kernel.Http.Interface;

namespace de.manawyrm.TecEdit
{
  public partial class FrmLogin : Form
  {
    private HttpPostHelper mLoginTester;

    public FrmLogin()
    {
      InitializeComponent();      
    }

    protected override void OnShown(EventArgs e)
    {
      base.OnShown(e);
      Init();
    }

    private void Init()
    {
      ctlLogin1.Focus();
      ctlLogin1.Init();
    }

    private void lltbSpace_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
    {
      Utility.OpenBrowser("http://tbspace.de");
    }

    private void llteccraft_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
    {
      Utility.OpenBrowser("http://teccraft.de");
    }

    private void btnCancel_Click(object sender, EventArgs e)
    {
      DeRegisterEvent(true);
    }

    private void btnOK_Click(object sender, EventArgs e)
    {
      if (ctlLogin1.ValidateForm())
      {
        Account ac = ctlLogin1.GetAccount();
        RegisterEvent(ac);
        mLoginTester.DoRequest(RequestType.Login, "", "", "");
      }
    }

    void mLoginTester_PostCompleteRaw(object sender, BaseEvent<string> e)
    {
      if (e.HasError)
        MessageBox.Show(e.ErrorMessage);

      if (e.Result == "1")
        Start();
    }

    private void Start()
    {
      Visible = false;
      FrmMain frmMain = new FrmMain();
      DialogResult dr = frmMain.ShowDialog();
      if (dr == System.Windows.Forms.DialogResult.Abort)
        DeRegisterEvent(true);
      else if (dr == System.Windows.Forms.DialogResult.Retry)
      {
        Settings.ResetAccount();
        Visible = true;
        Init();
      }
      else
        DeRegisterEvent(true);
    }

    private void RegisterEvent(Account ac)
    {
      DeRegisterEvent(false);
      if (mLoginTester == null)
      {
        mLoginTester = new HttpPostHelper(ac);
        mLoginTester.PostCompleteRaw += mLoginTester_PostCompleteRaw;
      }
    }

    private void DeRegisterEvent(bool closeApp)
    {
      if (mLoginTester != null)
      {
        mLoginTester.PostCompleteRaw -= mLoginTester_PostCompleteRaw;
        mLoginTester = null;
      }

      if(closeApp)
        Utility.CloseApplication();     
    }
  }
}