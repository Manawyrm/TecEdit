using System;
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
using de.manawyrm.TecEdit.Kernel.DataTypes.Interface;
namespace de.manawyrm.TecEdit.Kernel.Controls
{
  public partial class CtlFileExplorer : UserControl
  {
    public CtlFileExplorer()
    {
      InitializeComponent();
      Init();
    }

    public event EventHandler<GenericEventArgs<IFileSystemObject>> NodeMouseClick;
    public event EventHandler<GenericEventArgs<IFileSystemObject>> NodeMouseDoubleClick;

    private void Init()
    {
      ImageList twIcons = new ImageList();
      twIcons.Images.Add("folder", Resources.folder);
      twIcons.Images.Add("file", Resources.file_lua);
      tvFolderView.ImageList = twIcons;

      tvFolderView.Nodes.Add("KEYLoad", "Bitte warten Daten werden geladen !");

      tvFolderView.NodeMouseClick += new TreeNodeMouseClickEventHandler(tvFolderView_NodeMouseClick);
      tvFolderView.NodeMouseDoubleClick += new TreeNodeMouseClickEventHandler(tvFolderView_NodeMouseDoubleClick);
    }

    public void LoadData(TecEditFolder folder)
    {
      tvFolderView.BeginUpdate();

      TreeNode searchedNode = null;
      TreeNode newNode = CreateView(folder);

      foreach (TreeNode currentNode in tvFolderView.Nodes)
      {
        if (currentNode.Text == newNode.Text)
        {
          searchedNode = currentNode;
          break;
        }
      }

      if (tvFolderView.Nodes.ContainsKey("KEYLoad"))
        tvFolderView.Nodes.RemoveByKey("KEYLoad");

      if (searchedNode != null && tvFolderView.Nodes.Contains(searchedNode))
        tvFolderView.Nodes.Remove(searchedNode);

      tvFolderView.Nodes.Add(newNode);
      tvFolderView.Sort();
      tvFolderView.ExpandAll();

      tvFolderView.EndUpdate();
    }

    private void tvFolderView_NodeMouseDoubleClick(object sender, TreeNodeMouseClickEventArgs e)
    {
      OnClickRecieved(e.Node, true);
    }

    private void tvFolderView_NodeMouseClick(object sender, TreeNodeMouseClickEventArgs e)
    {
      OnClickRecieved(e.Node, false);
    }

    private TreeNode CreateView(TecEditFolder folder)
    {
      TreeNode rootNode = new TreeNode(folder.Name, 0, 0);
      CreateTreeView(folder, rootNode);
      return rootNode;
    }

    private void CreateTreeView(IFileSystemObject fsObject, TreeNode node)
    {
      if (fsObject.FSType == FSObjectType.Folder)
      {
        foreach (TecEditFolder folder in ((TecEditFolder)fsObject).Folders)
        {
          TreeNode folderNode = new TreeNode(folder.Name, 0, 0);
          folderNode.Tag = folder;
          node.Nodes.Add(folderNode);
          CreateTreeView(folder, folderNode);
        }

        foreach (TecEditFile file in ((TecEditFolder)fsObject).Files)
        {
          TreeNode fileNode = new TreeNode(file.Name, 1, 1);
          fileNode.Tag = file;
          node.Nodes.Add(fileNode);
        }
      }
    }

    protected virtual void OnClickRecieved(TreeNode node, bool isDoubleClick)
    {
      if (!isDoubleClick)
      {
        if (NodeMouseClick != null)
          NodeMouseClick(this, new GenericEventArgs<IFileSystemObject>((IFileSystemObject)node.Tag));
      }
      else
      {
        if (NodeMouseDoubleClick != null)
          NodeMouseDoubleClick(this, new GenericEventArgs<IFileSystemObject>((IFileSystemObject)node.Tag));
      }
    }

    public void UpdateFile(TecEditFile file)
    {
      SearchNode(tvFolderView.Nodes, file);
    }

    private bool SearchNode(TreeNodeCollection nodes, TecEditFile file)
    {
      bool dataFound = false;

      foreach (TreeNode n in nodes)
      {
        if (n.Nodes.Count > 0)
          dataFound = SearchNode(n.Nodes, file);

        if (dataFound)
          break;

        if (n.Text == file.Name)
        {
          IFileSystemObject nodeData = (IFileSystemObject)n.Tag;
          if (nodeData.FSType == FSObjectType.File)
          {
            TecEditFile nodeFile = (TecEditFile)nodeData;
            if (nodeFile.Path == file.Path)
            {
              n.Tag = file;
              dataFound = true;
              break;
            }
          }
        }        
      }
      return dataFound;
    }
  }
}