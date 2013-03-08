using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace de.manawyrm.TecEdit.Kernel.DataTypes
{
  public enum LoginState
  {
    Denied = 0, Accepted, unknown
  }

  public enum FSObjectType
  {
    unknown, Folder, File
  }
}
