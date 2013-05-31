using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ScintillaNET;

namespace de.manawyrm.TecEdit.Kernel.ScintillaUtils
{
  //GedankenHilfe

  /*
   * Step 1
   * Bei erstem Init und InternetVerbindung alle internen Apis + alle Userangebe nen Apis laden
   * alle geladenen daten in eigenem Format sichern evt möglichkeit zur update 
   * 
   * Step 2
   * Immer eigenes Format laden und prüfen bei autoComplete
   * autocomplete liste api getrennt
   * 
   * Step 3
   * Tooltip richtig positionieren und mit dem akktuellen api befehl füllen
   * 
   * Step 4
   * restliche positions Hilfen einbauen zum setzen der tooltip stelle
   * Mousepos
   * MouseClick (falls click auf dem autocomplete feld für update des neuen api befehls
   * KeyPress(falls up oder down auf dem ""
   * 
   * Optional
   * erkennen von var definitionen für autocomplete
   * 
   *  void editorPane_CharAdded(object sender, CharAddedEventArgs e)
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
   * 
   * 
   */

  public class AutoCompleteHelper
  {
    public AutoCompleteHelper(Scintilla scintilla)
    {
    }

    private void RegisterHandler(Scintilla scintilla)
    {

    }
  }
}
