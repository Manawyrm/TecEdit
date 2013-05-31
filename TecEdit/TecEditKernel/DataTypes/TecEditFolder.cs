using de.manawyrm.TecEdit.Kernel.DataTypes.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Serialization;
using System.IO;
using System.ComponentModel;

namespace de.manawyrm.TecEdit.Kernel.DataTypes
{
  public class TecEditFolder : IFileSystemObject
  {
    private List<TecEditFile> mFiles;
    private List<TecEditFolder> mFolder;
    private string mFilePath;

    public TecEditFolder()
    { }

    public TecEditFolder(string path)
    {
      mFiles = new List<TecEditFile>();
      mFolder = new List<TecEditFolder>();
      mFilePath = path;
    }

    public TecEditFolder(string path, bool createStructure)
    {
      mFiles = new List<TecEditFile>();
      mFolder = new List<TecEditFolder>();
      mFilePath = path;
      if (createStructure)
        RecrusiveFolderBuilder(path, this);
    }

    public void Add(IFileSystemObject file)
    {
      if (file.FSType == FSObjectType.File)
        mFiles.Add((TecEditFile)file);
      else if (file.FSType == FSObjectType.Folder)
        mFolder.Add((TecEditFolder)file);
    }

    public void Remove(IFileSystemObject file)
    {
      if (file.FSType == FSObjectType.File)
        mFiles.Remove((TecEditFile)file);
      else if (file.FSType == FSObjectType.Folder)
        mFolder.Remove((TecEditFolder)file);
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
    public FSObjectType FSType
    {
      get { return FSObjectType.Folder; }
    }

    [XmlIgnore]
    public bool HasName
    {
      get { return !string.IsNullOrEmpty(Name); }
    }

    [XmlIgnore]
    public long Size
    {
      get { return 0; }
    }

    public string GetFormattedSizeString()
    {
      return Utility.BytesToFormattedString(Size);
    }

    public List<TecEditFile> Files
    {
      get { return mFiles; }
      set { mFiles = value; }
    }

    public List<TecEditFolder> Folders
    {
      get { return mFolder; }
      set { mFolder = value; }
    }

    public static TecEditFolder TryParse(string httpPostResult)
    {
      TecEditFolder result = null;

      XmlSerializer seria = new XmlSerializer(typeof(TecEditFolder));
      using (MemoryStream ms = new MemoryStream(new UTF8Encoding().GetBytes(httpPostResult)))
      {
        try
        {
          result = (TecEditFolder)seria.Deserialize(ms);
        }
        catch (SystemException ex)
        {
          ExeptionLogger.Log(ex);
        }

        if (result != null && result.HasName)
          UpdatePCID(result, result.Name);
        return result;
      }
    }

    private static void UpdatePCID(TecEditFolder folder, string pcID)
    {
      if (folder != null)
      {
        foreach (TecEditFolder currentFolder in folder.Folders)
        {
          UpdatePCID(currentFolder, pcID);
        }

        foreach (TecEditFile currentFile in folder.Files)
        {
          currentFile.UdateID(pcID);
        }
      }
    }

    private void RecrusiveFolderBuilder(string path, TecEditFolder folder)
    {
      foreach (string currentFolder in Directory.GetDirectories(path))
      {
        TecEditFolder subFolder = new TecEditFolder(currentFolder);
        folder.Add(subFolder);
        RecrusiveFolderBuilder(currentFolder, subFolder);
      }

      foreach (string currentFile in Directory.GetFiles(path))
      {
        if(TecEditFile.IsValidExtension(currentFile))
          folder.Add(new TecEditFile(currentFile, ""));
      }
    }
  }
}
