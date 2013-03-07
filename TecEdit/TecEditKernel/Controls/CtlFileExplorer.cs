﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using de.manawyrm.TecEdit.Kernel.Properties;
using System.IO;
using de.manawyrm.TecEdit.Kernel.Http;
using de.manawyrm.TecEdit.Kernel.DataTypes;
namespace de.manawyrm.TecEdit.Kernel.Controls
{
  public partial class CtlFileExplorer : UserControl
  {
    public CtlFileExplorer()
    {
      InitializeComponent();
      Init();
    }

    private void Init()
    {
      ImageList twIcons = new ImageList();
      twIcons.Images.Add("folder", Resources.folder);
      twIcons.Images.Add("file", Resources.file_lua);
      tvFolderView.ImageList = twIcons;
      Account ac = new Account("http://dummy.no-ip.info/tekkit/", "Dummy", "dummy");
      HttpPostHelper h = new HttpPostHelper(ac);
      h.PostCompleteRaw += h_PostCompleteRaw;
      h.DoRequest(RequestType.GetFiles, "0", "", "");
    }

    void h_PostCompleteRaw(object sender, Http.Interface.BaseEvent<string> e)
    {
      DecodeData(e.Result);
    }

    private void DecodeData(string d)
    {
     
      LoadData(d);
    }

    public void LoadData(object data)
    {
      string fPath = @"C:\Temp";
      TreeNode fowner = CreateTreenode("fo", null, fPath);
      TreeNode n = CreateView(fowner, fPath);
      tvFolderView.Nodes.Add(n);
    }

    private TreeNode CreateView(TreeNode owner, string p)
    {
      foreach (string folder in Directory.GetDirectories(p))
      {
        TreeNode n = CreateTreenode("fo", owner, folder);
        CreateTreenode("fo", n, folder);
        owner = CreateView(n, folder);
      }

      foreach (string file in Directory.GetFiles(p))
      {
        TreeNode fi = CreateTreenode("fi", owner, file);
        string fName = Path.GetFileName(file);
      }
      return owner;
    }

    private TreeNode CreateTreenode(string nodeType, TreeNode root, string data)
    {
      TreeNode outputNode = null;

      if (nodeType == "fo")
      {
        outputNode = new TreeNode(Path.GetFileNameWithoutExtension(data), 0, 0);
        if (root == null)
          root = outputNode;
        else
          root.Nodes.Add(outputNode);

        outputNode = root;
      }
      else if (nodeType == "fi")
      {
        //outputNode = new TreeNode(Path.GetFileNameWithoutExtension(data), 0, 0);
        if (root != null)
          root.Nodes.Add(new TreeNode(Path.GetFileNameWithoutExtension(data), 1, 1));
        outputNode = root;
      }
      return outputNode;
    }
  }
}