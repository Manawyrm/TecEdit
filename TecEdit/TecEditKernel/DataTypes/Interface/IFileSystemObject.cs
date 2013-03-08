using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace de.manawyrm.TecEdit.Kernel.DataTypes.Interface
{
  public interface IFileSystemObject
  {
    string Name
    {
      get;
    }

    FSObjectType FSType
    {
      get;
    }

    bool HasName
    {
      get;
    }

    long Size
    {
      get;
    }

    string GetFormattedSizeString();
  }
}
