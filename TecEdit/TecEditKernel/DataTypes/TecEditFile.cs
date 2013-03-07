using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace de.manawyrm.TecEdit.Kernel.DataTypes
{
  public class TecEditFile
  {
    private string mFileName;
    private string mFileContent;

    public TecEditFile(string filename, string fileContent)
    {
      mFileContent = fileContent;
      mFileName = filename;
    }

    public string FileName
    {
      get { return mFileName; }
    }

    public string FileContent
    {
      get { return mFileContent; }
    }

    public bool HasContent
    {
      get { return !string.IsNullOrEmpty(mFileContent); }
    }

    public bool HasFileName
    {
      get { return !string.IsNullOrEmpty(mFileName); }
    }
  }
}
