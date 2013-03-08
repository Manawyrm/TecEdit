using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

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
   */
  public class AutoCompleteUpdater
  {
  }
}
