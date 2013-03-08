using de.manawyrm.TecEdit.Kernel.DataTypes.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace de.manawyrm.TecEdit.Kernel.DataTypes
{
  public class TecEditFile : IFileSystemObject
  {
    private string mFileName;
    private string mFileContent;
  
    public TecEditFile(string filename, string fileContent)
    {
      mFileContent = fileContent;
      mFileName = filename;
    }

    public string FileContent
    {
      get { return mFileContent; }
    }

    public bool HasContent
    {
      get { return !string.IsNullOrEmpty(mFileContent); }
    }

    public string Name
    {
      get { return mFileName; }
    }

    public FSObjectType FSType
    {
      get { return FSObjectType.File; }
    }

    public bool HasName
    {
      get { return !string.IsNullOrEmpty(mFileName); }
    }

    public long Size
    {
      get { return Utility.CalculateFileSize(FileContent); }
    }

    public string GetFormattedSizeString()
    {
      return Utility.BytesToFormattedString(Size);
    }
  }
}