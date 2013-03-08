using de.manawyrm.TecEdit.Kernel.DataTypes.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace de.manawyrm.TecEdit.Kernel.DataTypes
{
  public class TecEditFolder : IFileSystemObject
  {
    public string Name
    {
      get { throw new NotImplementedException(); }
    }

    public FSObjectType FSType
    {
      get { throw new NotImplementedException(); }
    }

    public bool HasName
    {
      get { throw new NotImplementedException(); }
    }

    public long Size
    {
      get { throw new NotImplementedException(); }
    }

    public string GetFormattedSizeString()
    {
      throw new NotImplementedException();
    }
  }
}
