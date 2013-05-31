using de.manawyrm.TecEdit.Kernel.DataTypes.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Serialization;
using de.manawyrm.TecEdit.Kernel.Http;
using de.manawyrm.TecEdit.Kernel.Http.Interface;

namespace de.manawyrm.TecEdit.Kernel.DataTypes
{
  public class TecEditFile : IFileSystemObject
  {
    private string mFileContent;
    private string mFilePath;
    private string mPCID;

    public TecEditFile()
    { }

    public TecEditFile(string filePath, string fileContent)
    {
      mFileContent = fileContent;
      mFilePath = filePath;
    }

    [XmlIgnore]
    public string FileContent
    {
      get { return mFileContent; }
    }

    [XmlIgnore]
    public bool HasContent
    {
      get { return !string.IsNullOrEmpty(mFileContent); }
    }

    [XmlIgnore]
    public string Name
    {
      get { return System.IO.Path.GetFileName(Path); }
    }

    public string Path
    {
      get { return mFilePath; }
      set { mFilePath = value; }
    }

    [XmlIgnore]
    public bool IsLocalPath
    {
      get { return System.IO.File.Exists(Path); }
    }

    [XmlIgnore]
    public FSObjectType FSType
    {
      get { return FSObjectType.File; }
    }

    [XmlIgnore]
    public string PCID
    {
      get { return mPCID; }
    }

    [XmlIgnore]
    public bool HasName
    {
      get { return !string.IsNullOrEmpty(Name); }
    }

    [XmlIgnore]
    public long Size
    {
      get { return Utility.CalculateFileSize(FileContent); }
    }

    public string GetFormattedSizeString()
    {
      return Utility.BytesToFormattedString(Size);
    }

    public void UdateID(string id)
    {
      mPCID = id;
    }

    public void LoadContent()
    {
      if (IsLocalPath)
      {
        mFileContent = System.IO.File.ReadAllText(Path);
      }
    }

    public static bool IsValidExtension(string path)
    {
      string ext = System.IO.Path.GetExtension(path);
      return Constants.ExtFilters.Contains(ext);
    }
  }
}