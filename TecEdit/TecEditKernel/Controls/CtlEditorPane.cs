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
      CreateOpenFileTab(file);
    }

    private void CreateOpenFileTab(TecEditFile file)
    {
      string fileName = "Neues Script";

      if (file.HasName)
        fileName = file.Name;

      TabPage tabPage = new TabPage(fileName);

      Scintilla editorPane = CreateEditorPaneFormat(file.FileContent);
      tabPage.Controls.Add(editorPane);
      tCEditor.TabPages.Add(tabPage);
    }

    private Scintilla CreateEditorPaneFormat(string content)
    {
      Scintilla editorPane = new Scintilla();
      editorPane.CharAdded += editorPane_CharAdded;

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

    void editorPane_CharAdded(object sender, CharAddedEventArgs e)
    {
      Scintilla editor = sender as ScintillaNET.Scintilla;

      if (e.Ch == '.')
      {
        Timer t = new Timer();

        t.Interval = 10;
        t.Tag = editor;
        t.Tick += new EventHandler((obj, ev) =>
        {
          // make a new autocomplete list if needed
          List<string> s = new List<string>();
          s.Add("test");
          s.Add("test2");
          //s.Add("test3xxxxxxxxxxxxxxxxxxxxxxxxxxxxx");
          s.Sort(); // don't forget to sort it

          editor.AutoComplete.ShowUserList(0, s);
          ToolTip tt = new ToolTip();

          int cLine = editor.AutoComplete.LastStartPosition + 1;
          int cPos = editor.CurrentPos;

          int overAllPosition = editor.Caret.Position;
          int lineStartPosition = editor.Lines.Current.StartPosition;
          int yourAnswer = overAllPosition - lineStartPosition;

          int x = editor.PointXFromPosition(yourAnswer);
          int y = editor.PointYFromPosition(overAllPosition);

          x += 150;
          y += 40;

          if (editor.AutoComplete.IsActive)
          {
          }


          tt.Show("Test1234", this, x, y, 5000);

          t.Stop();
          t.Enabled = false;
          t.Dispose();
        });
        t.Start();
      }
    }

    private int TryGetlength(Scintilla s, List<string> d)
    {
      int l = 0;
      foreach (string ac in d)
      {
        if (ac.Length > l)
          l = ac.Length;
      }
      return l;
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
