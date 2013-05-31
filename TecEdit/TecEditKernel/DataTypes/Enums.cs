using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace de.manawyrm.TecEdit.Kernel.DataTypes
{
  public enum ComputerType
  {
    unknown, ColoredPC, Console, Turtle
  }

  public enum ServerRequestState
  {
    Unknown, Success, Denied
  }

  public enum FSObjectType
  {
    unknown, Folder, File
  }
}
