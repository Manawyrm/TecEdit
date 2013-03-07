using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using ScintillaNET;
using de.manawyrm.TecEdit.Kernel.Properties;
using de.manawyrm.TecEdit.Kernel.DataTypes;

namespace de.manawyrm.TecEdit.Kernel.Controls
{
  public partial class CtlEditorPane : UserControl
  {
    public CtlEditorPane()
    {
      InitializeComponent();
    }

    public void OpenFile(TecEditFile file)
    {
     
    }    

    private void CreateOpenFileTab(TecEditFile file)
    {
      string fileName = "Neues Script";

      if (file.HasFileName)
        fileName = file.FileName;

      TabPage tabPage = new TabPage(fileName);

      Scintilla editorPane = CreateEditorPaneFormat(file.FileContent);
      tabPage.Controls.Add(editorPane);
      tCEditor.TabPages.Add(tabPage);
    }

    private Scintilla CreateEditorPaneFormat(string content)
    {
      Scintilla editorPane = new Scintilla();
      editorPane.Dock = DockStyle.Fill;

      //Display Line Numbers
      editorPane.Margins[0].Width = 20;
      editorPane.Margins[1].Width = 0;
      editorPane.Margins[2].Width = 20;
      //

      editorPane.ConfigurationManager.CustomLocation = "lua.xml";
      editorPane.ConfigurationManager.Language = "lua";
      editorPane.NativeInterface.UsePopUp(false);
      editorPane.ContextMenuStrip = CreateContextMenu();
      editorPane.ConfigurationManager.Configure();
      editorPane.Commands.AddBinding(Keys.X,Keys.Control, BindableCommand.Cut);
      editorPane.Text = content;
      return editorPane;
    }

    private ContextMenuStrip CreateContextMenu()
    {
      ContextMenuStrip editorMenu = new ContextMenuStrip();
      editorMenu.Items.Add(CreateContextMenuItem("Ausschneiden", Resources.file_lua));
      editorMenu.Items.Add(CreateContextMenuItem("Kopieren", Resources.file_lua));
      editorMenu.Items.Add(CreateContextMenuItem("Einfügen", Resources.file_lua));
      return editorMenu;
    }

    private ToolStripMenuItem CreateContextMenuItem(string name, Image icon)
    {
      return new ToolStripMenuItem(name, icon);
    }

    private void tCEditor_SelectedIndexChanged(object sender, EventArgs e)
    {

    }
  }
}
