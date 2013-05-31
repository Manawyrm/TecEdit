using de.manawyrm.TecEdit.Kernel.DataTypes;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using de.manawyrm.TecEdit.Kernel.Http;
using de.manawyrm.TecEdit.Kernel;
using de.manawyrm.TecEdit.Kernel.DataTypes.Interface;

namespace de.manawyrm.TecEdit
{
  public partial class FrmTest : Form
  {
    public FrmTest()
    {
      InitializeComponent();
    }

    HttpPostHelper mHelper;

    protected override void OnShown(EventArgs e)
    {
      base.OnShown(e);
      Init();
    }

    private void Init()
    {      
      ctlFileExplorer1.NodeMouseClick += new EventHandler<GenericEventArgs<IFileSystemObject>>(ctlFileExplorer1_NodeMouseClick);
      ctlFileExplorer1.NodeMouseDoubleClick += new EventHandler<GenericEventArgs<IFileSystemObject>>(ctlFileExplorer1_NodeMouseDoubleClick);
      mHelper = new HttpPostHelper(new Account("http://localhost/Test/", "Opachl", "tesz"));
      mHelper.PostCompleteGetFolderContent += new EventHandler<Kernel.Http.Interface.BaseEvent<TecEditFolder>>(mHelper_PostCompleteGetFolderContent);
      mHelper.PostCompleteGetFileContent += new EventHandler<Kernel.Http.Interface.BaseEvent<TecEditFile>>(mHelper_PostCompleteGetFileContent);
      mHelper.PostCompleteGetAllComputer += new EventHandler<Kernel.Http.Interface.BaseEvent<List<Computer>>>(mHelper_PostCompleteGetAllComputer);
    }

    void ctlFileExplorer1_NodeMouseDoubleClick(object sender, GenericEventArgs<IFileSystemObject> e)
    {
      if (e.HasResult && e.Result.FSType == FSObjectType.File)
      {
        TecEditFile file = (TecEditFile)e.Result;
        if (!file.HasContent)
          mHelper.DoRequest(RequestType.GetFileContent, file.PCID, file.Path, "");
        else
          LoadFile(file);
      }
    }

    void ctlFileExplorer1_NodeMouseClick(object sender, GenericEventArgs<IFileSystemObject> e)
    {
      if (e.HasResult)
        label1.Text = e.Result.GetFormattedSizeString();
    }

    void mHelper_PostCompleteGetFolderContent(object sender, Kernel.Http.Interface.BaseEvent<TecEditFolder> e)
    {
      if (!e.HasError && e.HasResult)
        ctlFileExplorer1.LoadData(e.Result);
    }

    void mHelper_PostCompleteGetFileContent(object sender, Kernel.Http.Interface.BaseEvent<TecEditFile> e)
    {
      if (!e.HasError && e.HasResult)
        LoadFile(e.Result);
    }

    void mHelper_PostCompleteGetAllComputer(object sender, Kernel.Http.Interface.BaseEvent<List<Computer>> e)
    {
      if (!e.HasError && e.HasResult)
      {
        foreach (Computer c in e.Result)
        {
          mHelper.DoRequest(RequestType.GetFolderContent, c.IngameID.ToString(), "", "");
        }
      }
    }   

    private void LoadFile(TecEditFile file)
    {
      label1.Text = file.GetFormattedSizeString();
      ctlFileExplorer1.UpdateFile(file);
      ctlEditorPane1.OpenFile(file);
    }

    private void button1_Click(object sender, EventArgs e)
    {
      mHelper.DoRequest(RequestType.GetComputersFromUser, "", "", "");
      //mHelper.DoRequest(RequestType.GetFolderContent, "0", "", "");
      //mHelper.DoRequest(RequestType.GetFolderContent, "1", "", "");
    }
  }
}