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
using de.manawyrm.TecEdit.Kernel.ScintillaUtils;

namespace de.manawyrm.TecEdit.Kernel.Controls
{
  public partial class CtlEditorPane : UserControl
  {
    public CtlEditorPane()
    {
      InitializeComponent();
      Init();
    }

    public void OpenFile(TecEditFile file)
    {
      CreateOpenFileTab(file);
    }

    private void Init()
    {
      
    }

    private void CreateOpenFileTab(TecEditFile file)
    {
      TabPage page = GetTabpage(file);

      if (!tCEditor.TabPages.Contains(page))
        tCEditor.TabPages.Add(page);

      tCEditor.SelectedTab = page;
    }

    private TabPage GetTabpage(TecEditFile file)
    {
      string fileName = "Neues Script";

      if (file.HasName)
        fileName = file.Name;

      TabPage tabPage = new TabPage(fileName);
      tabPage.Tag = file;

      foreach (TabPage currentPage in tCEditor.TabPages)
      {
        if (currentPage.Text == tabPage.Text)
        {
          TecEditFile tabFile = (TecEditFile)currentPage.Tag;
          if (tabFile.Path == file.Path)
          {
            return currentPage;            
          }
        }
      }

      Scintilla editorPane = CreateEditorPaneFormat(file.FileContent);
      tabPage.Controls.Add(editorPane);
      return tabPage;
    }

    private Scintilla CreateEditorPaneFormat(string content)
    {
      Scintilla editorPane = new Scintilla();
      AutoCompleteHelper autoComplete = new AutoCompleteHelper(editorPane);
      
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
      editorPane.Commands.AddBinding(Keys.X, Keys.Control, BindableCommand.Cut);
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
  }
}
