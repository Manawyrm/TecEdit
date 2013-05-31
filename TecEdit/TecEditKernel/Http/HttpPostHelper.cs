using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using de.manawyrm.TecEdit.Kernel.Http.Interface;
using de.manawyrm.TecEdit.Kernel.Http.ResultHelper;
using de.manawyrm.TecEdit.Kernel.DataTypes;
using System.Xml.Linq;
using System.IO;
using System.Xml;

namespace de.manawyrm.TecEdit.Kernel.Http
{
  public enum RequestType
  {
    // "" bedeutet nicht benutzt
    unknown,                // Sicherheit falls kein Wert
    CheckLogin,             // Logt den User ein                p1 = "",    p2 = "",        p3 = ""               checkLogin.php
    SetPCDescription,       // Setzt PC Beschreibung            p1 = pcID,  p2 = pcName,    p3 = ""               setPCDescription.php
    GetUsersFromComputer,   // Gibt alle User für den PC        p1 = pcID,  p2 = "",        p3 = ""               getUsersFromComputer.php
    RemovePCUser,           // Entfernt User von PC             p1 = pcID,  p2 = user,      p3 = ""               .php
    GetComputersFromUser,   // Liefert alle Computer von User   p1 = "",    p2 = "",        p3 = ""               getComputersFromUser.php
    xx,                     // xxxxxxxxxxxxxxxxxxxx             p1 = "",    p2 = "",        p3 = ""               .php
    ReportBug,              // Übermittelt den BugReport        siehe ReportBug(name,bugDescription,mail,type)    reportbug.php
    GetFolderContent,       // Liefert alle FSStruktur von PC   p1 = pcID,  p2 = "",        p3 = ""               getFolderContent.php    p2 = optional (gibt inhalt von subfolder)
    SetFileContent,         // Übermittelt ein File auf den PC  p1 = pcID,  p2 = filename,  p3 = FileBytes        setFileContent.php
    GetFileContent          // Holt ein File vom PC             p1 = pcID,  p2 = filename,  p3 = ""               getFileContent.php
  }

  public class HttpPostHelper
  {
    private Account mAccount;

    public event EventHandler<BaseEvent<string>> PostCompleteRaw;

    public event EventHandler<BaseEvent<List<Account>>> PostCompleteGetAllUser;
    public event EventHandler<BaseEvent<ServerRequestState>> PostCompleteLogin;
    public event EventHandler<BaseEvent<List<Computer>>> PostCompleteGetAllComputer;
    public event EventHandler<BaseEvent<TecEditFile>> PostCompleteGetFileContent;
    public event EventHandler<BaseEvent<TecEditFolder>> PostCompleteGetFolderContent;

    protected virtual void OnPostCompleteRaw(BaseEvent<string> result)
    {
      if (PostCompleteRaw != null)
        PostCompleteRaw(this, result);
    }

    public HttpPostHelper(Account ac)
    {
      mAccount = ac;
    }

    /// <summary>
    /// Parameter Beschreibung in "RequestType" beschrieben
    /// </summary>
    /// <param name="requestType"></param>
    /// <param name="p1"></param>
    /// <param name="p2"></param>
    /// <param name="p3"></param>
    public void DoRequest(RequestType requestType, string p1, string p2, string p3)
    {
      if (requestType == RequestType.unknown)
        return;

      if (requestType == RequestType.ReportBug)
        throw new NotSupportedException("Benutze ReportBug statt DoRequest");

      PostParamCollection parameters = GetLoginParams(mAccount);

      switch (requestType)
      {
        case RequestType.CheckLogin:
          DoLogin(parameters);
          break;
        case RequestType.GetComputersFromUser:
          DoGetComputerFromUser(parameters);
          break;
        case RequestType.SetPCDescription:
          DoSetDescription(parameters, p1, p2);
          break;
        case RequestType.GetUsersFromComputer:
          DoGetPCUsers(parameters, p1);
          break;
        case RequestType.RemovePCUser:
          DoRemovePCUser(parameters, p1, p2);
          break;
        case RequestType.GetFolderContent:
          DoGetFiles(parameters, p1, p2);
          break;
        case RequestType.SetFileContent:
          DoUploadFileContent(parameters, p1, p2, p3);
          break;
        case RequestType.GetFileContent:
          DoDownloadFileContent(parameters, p1, p2);
          break;
      }
    }

    public void ReportBug(string name, string bugDescription, string mail, string type)
    {
      HttpPost p = new HttpPost(Constants.DefaultReportURL);
      RegisterEventHandler(p);
      PostParamCollection col = new PostParamCollection();
      col.Add(new PostParameters("name", name));
      col.Add(new PostParameters("bug", bugDescription));
      col.Add(new PostParameters("mail", mail));
      col.Add(new PostParameters("type", type));
      p.Post(RequestType.ReportBug, col);
    }

    #region Build Http Requests
    private void DoLogin(PostParamCollection parameters)
    {
      HttpPost p = CreatePostHandler(Constants.php_Login);
      p.Post(RequestType.CheckLogin, parameters);
    }

    private void DoSetDescription(PostParamCollection parameters, string pcID, string desc)
    {
      HttpPost p = CreatePostHandler(Constants.php_setPCDescription);
      parameters.Add(new PostParameters("id", pcID));
      parameters.Add(new PostParameters("desc", desc));
      p.Post(RequestType.SetPCDescription, parameters);
    }

    private void DoGetPCUsers(PostParamCollection parameters, string pcID)
    {
      HttpPost p = CreatePostHandler(Constants.php_GetUsersFromComputer);
      parameters.Add(new PostParameters("id", pcID));
      p.Post(RequestType.GetUsersFromComputer, parameters);
    }

    private void DoRemovePCUser(PostParamCollection parameters, string pcID, string user)
    {
      HttpPost p = CreatePostHandler(Constants.php_RemovePCUser);
      parameters.Add(new PostParameters("id", pcID));
      parameters.Add(new PostParameters("target", user));
      p.Post(RequestType.RemovePCUser, parameters);
    }

    private void DoGetComputerFromUser(PostParamCollection parameters)
    {
      HttpPost p = CreatePostHandler(Constants.php_GetComputersFromUser);
      p.Post(RequestType.GetComputersFromUser, parameters);
    }

    private void DoGetFiles(PostParamCollection parameters, string pcID, string folder)
    {
      HttpPost p = CreatePostHandler(Constants.php_getFolderContent);

      PostParamCollection xmlArgs = new PostParamCollection();
      xmlArgs.Add(new PostParameters("ComputerID", pcID));
      xmlArgs.Add(new PostParameters("FolderPath", folder));
      parameters = AddAsArgs(parameters, xmlArgs);
     
      p.Post(RequestType.GetFolderContent, parameters);
    }

    private void DoUploadFileContent(PostParamCollection parameters, string pcID, string file, string b64Data)
    {
      HttpPost p = CreatePostHandler(Constants.php_setFileContent);

      PostParamCollection xmlArgs = new PostParamCollection();
      xmlArgs.Add(new PostParameters("ComputerID", pcID));
      xmlArgs.Add(new PostParameters("FilePath", file));
      xmlArgs.Add(new PostParameters("content", b64Data));
      parameters = AddAsArgs(parameters, xmlArgs);

      p.Post(RequestType.SetFileContent, parameters);
    }

    private void DoDownloadFileContent(PostParamCollection parameters, string pcID, string file)
    {
      HttpPost p = CreatePostHandler(Constants.php_getFileContent);

      PostParamCollection xmlArgs = new PostParamCollection();
      xmlArgs.Add(new PostParameters("ComputerID", pcID));
      xmlArgs.Add(new PostParameters("FilePath", file));
      parameters = AddAsArgs(parameters, xmlArgs);

      p.Post(RequestType.GetFileContent, parameters);
    }

    private HttpPost CreatePostHandler(string targetFile)
    {
      HttpPost p = new HttpPost(mAccount.HostURL + targetFile);
      RegisterEventHandler(p);
      return p;
    }

    private void RegisterEventHandler(HttpPost httpHandler)
    {
      httpHandler.PostComplete += new EventHandler<PostEventArgs>(httpHandler_PostComplete);
    }
    #endregion

    #region Raise Events
    void httpHandler_PostComplete(object sender, PostEventArgs e)
    {
      try
      {
        RaiseAll(e);
      }
      catch (Exception ex)
      {
        ExeptionLogger.Log(ex);
      }
    }

    private void RaiseAll(PostEventArgs e)
    {
      OnPostCompleteRaw(new RawResult(e));
      switch (e.RequestType)
      {
        case RequestType.CheckLogin:
          OnPostCompleteLogin(new LoginPostResult(e));
          break;
        case RequestType.GetComputersFromUser:
          OnPostCompleteGetAllComputer(new GetAllComputerPostResult(e));
          break;
        case RequestType.SetPCDescription:

          break;
        case RequestType.GetUsersFromComputer:
          OnPostCompleteGetAllUserPC(new GetUserPostResult(e));
          break;
        case RequestType.RemovePCUser:

          break;
        case RequestType.GetFolderContent:
          OnPostCompleteGetFolderContent(new GetFolderContentPostResult(e));
          break;
        case RequestType.SetFileContent:

          break;
        case RequestType.GetFileContent:
          OnPostCompleteGetFileContent(new GetFileContentPostResult(e));
          break;
      }
    }
    #endregion

    #region EventHandler
    protected virtual void OnPostCompleteGetFileContent(BaseEvent<TecEditFile> result)
    {
      if (PostCompleteGetFileContent != null)
        PostCompleteGetFileContent(this, result);
    }
    protected virtual void OnPostCompleteGetAllUserPC(BaseEvent<List<Account>> result)
    {
      if (PostCompleteGetAllUser != null)
        PostCompleteGetAllUser(this, result);
    }
    protected virtual void OnPostCompleteLogin(BaseEvent<ServerRequestState> result)
    {
      if (PostCompleteLogin != null)
        PostCompleteLogin(this, result);
    }
    protected virtual void OnPostCompleteGetAllComputer(BaseEvent<List<Computer>> result)
    {
      if (PostCompleteGetAllComputer != null)
        PostCompleteGetAllComputer(this, result);
    }
    protected virtual void OnPostCompleteGetFolderContent(BaseEvent<TecEditFolder> result)
    {
      if (PostCompleteGetFolderContent != null)
        PostCompleteGetFolderContent(this, result);
    }
    #endregion

    #region Help Functions
    private PostParamCollection GetLoginParams(Account ac)
    {
      PostParamCollection col = new PostParamCollection();
      col.Add(new PostParameters("user", ac.Username));
      col.Add(new PostParameters("pass", ac.Passwort));
      return col;
    }

    private PostParamCollection AddAsArgs(PostParamCollection postParams, PostParamCollection xmlArgs)
    {
      string xmlData = Utility.EncodeToB64(GetXmlArgs(xmlArgs), true);
      postParams.Add(new PostParameters("args", xmlData));
      return postParams;
    }

    private string GetXmlArgs(PostParamCollection coll)
    {
      XDocument doc = new XDocument(new XDeclaration("1.0", "utf-16", "yes"));
      XElement commandArgs = new XElement("CommandArgs");
      foreach (PostParameters p in coll)
      {
        XElement parameter = new XElement(p.Paramter);
        parameter.Value = p.Value;
        commandArgs.Add(parameter);
      }
      doc.Add(commandArgs);
      
      using (StringWriter sw = new StringWriter())
      {
        using (XmlTextWriter tx = new XmlTextWriter(sw))
        {
          doc.WriteTo(tx);
          return sw.ToString();
        }
      }
    }
    #endregion
  }
}