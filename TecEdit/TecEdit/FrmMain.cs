using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace de.manawyrm.TecEdit
{
  public partial class FrmMain : Form
  {
    public FrmMain()
    {
      InitializeComponent();
    }

    private void btnDTLogut_Click(object sender, EventArgs e)
    {
      DialogResult = System.Windows.Forms.DialogResult.Retry;
    }

    private void btnDTExit_Click(object sender, EventArgs e)
    {
      DialogResult = System.Windows.Forms.DialogResult.Abort;
    }

    private void btnViewSymbol_Click(object sender, EventArgs e)
    {
      barSymbol.Visible = btnViewSymbol.Checked;
    }

    private void btnViewStatus_Click(object sender, EventArgs e)
    {
      barStatus.Visible = btnViewStatus.Checked;
    }

    private void btnTest_Click(object sender, EventArgs e)
    {
      //TestFunktion nicht benutzen ist in Arbeit
      //ctlFileExplorer1.LoadData(null);
    }  
  }
}
