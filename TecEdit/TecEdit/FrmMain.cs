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
    }

    private void btnDTLogut_Click(object sender, EventArgs e)
    {
      DialogResult = System.Windows.Forms.DialogResult.Retry;
    }

    private void btnDTExit_Click(object sender, EventArgs e)
    {
      DialogResult = System.Windows.Forms.DialogResult.Abort;
    }

    private void FrmMain_Load(object sender, EventArgs e)
    {
        BuildAPIMenu();
    }

    Dictionary<String, String> APIs = new Dictionary<string, string>()
    {
        {"Bit","http://computercraft.info/wiki/Bit_(API)"},
        {"Colors","http://computercraft.info/wiki/Colors_(API)"},
        {"Coroutine","http://computercraft.info/wiki/Coroutine_(API)"},
        {"Disk","http://computercraft.info/wiki/Disk_(API)"},
        {"Fs","http://computercraft.info/wiki/Fs_(API)"},
        {"Gps","http://computercraft.info/wiki/Gps_(API)"},
        {"Help","http://computercraft.info/wiki/Help_(API)"},
        {"HTTP","http://computercraft.info/wiki/HTTP_(API)"},
        {"IO","http://computercraft.info/wiki/IO_(API)"},
        {"Math","http://computercraft.info/wiki/Math_(API)"},
        {"OS","http://computercraft.info/wiki/OS_(API)"},
        {"Paintutils","http://computercraft.info/wiki/Paintutils_(API)"},
        {"Parallel","http://computercraft.info/wiki/Parallel_(API)"},
        {"Peripheral","http://computercraft.info/wiki/Peripheral_(API)"},
        {"Rednet","http://computercraft.info/wiki/Rednet_(API)"},
        {"Redstone","http://computercraft.info/wiki/Redstone_(API)"},
        {"Shell","http://computercraft.info/wiki/Shell_(API)"},
        {"String","http://computercraft.info/wiki/String_(API)"},
        {"Table","http://computercraft.info/wiki/Table_(API)"},
        {"Term","http://computercraft.info/wiki/Term_(API)"},
        {"Textutils","http://computercraft.info/wiki/Textutils_(API)"},
        {"Turtle","http://computercraft.info/wiki/Turtle_(API)"},
        {"Vector","http://computercraft.info/wiki/Vector_(API)"}
    };
    void BuildAPIMenu()
    {
        APIMenuItem.MenuItems.Clear();
        foreach (var item in APIs)
	    {
            MenuItem newitem = new MenuItem(item.Key, Utility.APIHelpClicked);
            newitem.Tag = item.Value;
            APIMenuItem.MenuItems.Add(newitem);
	    }
    }

    private void btnViewSymbolBar_Click(object sender, EventArgs e)
    {
        btnViewSymbolBar.Checked = !btnViewSymbolBar.Checked;
        tsMain.Visible = btnViewSymbolBar.Checked;
    }

    private void btnViewStatebar_Click(object sender, EventArgs e)
    {
        btnViewStatebar.Checked = !btnViewStatebar.Checked;
        ssMain.Visible = btnViewStatebar.Checked;
    }
  }
}
