using de.manawyrm.TecEdit.Kernel.DataTypes;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace de.manawyrm.TecEdit
{
  public partial class FrmTest : Form
  {
    public FrmTest()
    {
      InitializeComponent();
    }

    protected override void OnShown(EventArgs e)
    {
      base.OnShown(e);
      //TecEditFile f = new TecEditFile("huhu", File.ReadAllText(@"C:\Users\Christian\Desktop\pastebin"));
      ////string d = f.GetFormattedSizeString();
      //ctlEditorPane1.OpenFile(f);
    }

    private void ctlEditorPane1_Click(object sender, EventArgs e)
    {
      TecEditFile f = new TecEditFile("huhu", File.ReadAllText(@"C:\Users\Christian\Desktop\pastebin"));
      string d = f.GetFormattedSizeString();
      ctlEditorPane1.OpenFile(f);
    }
  }
}