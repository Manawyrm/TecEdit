using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using de.manawyrm.TecEdit.Kernel.Http.Interface;
using de.manawyrm.TecEdit.Kernel.Http.ResultHelper;

namespace de.manawyrm.TecEdit.Kernel.Http
{
  public enum RequestType
  {
    // "" bedeutet nicht benutzt
    unknown,          // Sicherheit falls kein Wert
    Login,            // Logt den User ein                p1 = "",    p2 = "",        p3 = ""               login.php
    SetPCDescription, // Setzt PC Name                    p1 = pcID,  p2 = pcName,    p3 = ""               setdesc.php
    GetAllUserPC,     // Gibt alle User für den PC        p1 = pcID,  p2 = "",        p3 = ""               getuser.php
    RemovePCUser,     // Entfernt User von PC             p1 = pcID,  p2 = user,      p3 = ""               deregister.php
    GetAllComputer,   // Liefert alle Computer von User   p1 = "",    p2 = "",        p3 = ""               getcomputer.php
    xx,               // xxxxxxxxxxxxxxxxxxxx             p1 = "",    p2 = "",        p3 = ""               register_sec.php
    ReportBug,        // Übermittelt den BugReport        siehe ReportBug(name,bugDescription,mail,type)    reportbug.php
    GetFiles,         // Liefert alle Datein von PC       p1 = pcID,  p2 = "",        p3 = ""               getfiles.php
    SetContent,       // Übermittelt ein File auf den PC  p1 = pcID,  p2 = filename,  p3 = b64Daten         setcontent.php
    GetContent        // Holt ein File vom PC             p1 = pcID,  p2 = filename,  p3 = ""               getcontent.php
  }

  public class HttpPostHelper
  {
    private Account mAccount;

    public event EventHandler<BaseEvent<string>> PostCompleteRaw;

    public event EventHandler<BaseEvent<List<Account>>> PostCompleteGetAllUser;
    public event EventHandler<BaseEvent<string>> PostCompleteGetPCDescription;

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
        case RequestType.Login:
          DoLogin(parameters);
          break;
        case RequestType.GetAllComputer:
          DoGetComputerFromUser(parameters);
          break;
        case RequestType.SetPCDescription:
          DoSetDescription(parameters, p1, p2);
          break;
        case RequestType.GetAllUserPC:
          DoGetPCUsers(parameters, p1);
          break;
        case RequestType.RemovePCUser:
          DoRemovePCUser(parameters, p1, p2);
          break;
        case RequestType.GetFiles:
          DoGetFiles(parameters, p1);
          break;
        case RequestType.SetContent:
          DoUploadFileContent(parameters, p1, p2, p3);
          break;
        case RequestType.GetContent:
          DoDownloadFileContent(parameters, p1, p2);
          break;
      }
    }

    public void ReportBug(string name, string bugDescription, string mail, string type)
    {
      HttpPost p = new HttpPost("http://tbspace.de/tecedit/reportbug.php");
      RegisterEventHandler(p);
      PostParamCollection col = new PostParamCollection();
      col.Add(new PostParameters("name", name));
      col.Add(new PostParameters("bug", bugDescription));
      col.Add(new PostParameters("mail", mail));
      col.Add(new PostParameters("type", type));
      p.Post(RequestType.ReportBug.ToString(), col);
    }

    private void DoLogin(PostParamCollection parameters)
    {
      HttpPost p = CreatePostHandler("login.php");
      p.Post(RequestType.Login.ToString(), parameters);
    }

    private void DoSetDescription(PostParamCollection parameters, string pcID, string desc)
    {
      HttpPost p = CreatePostHandler("setdesc.php");
      parameters.Add(new PostParameters("id", pcID));
      parameters.Add(new PostParameters("desc", desc));
      p.Post(RequestType.SetPCDescription.ToString(), parameters);
    }

    private void DoGetPCUsers(PostParamCollection parameters, string pcID)
    {
      HttpPost p = CreatePostHandler("getuser.php");
      parameters.Add(new PostParameters("id", pcID));
      p.Post(RequestType.GetAllUserPC.ToString(), parameters);
    }

    private void DoRemovePCUser(PostParamCollection parameters, string pcID, string user)
    {
      HttpPost p = CreatePostHandler("deregister.php");
      parameters.Add(new PostParameters("id", pcID));
      parameters.Add(new PostParameters("target", user));
      p.Post(RequestType.RemovePCUser.ToString(), parameters);
    }

    private void DoGetComputerFromUser(PostParamCollection parameters)
    {
      HttpPost p = CreatePostHandler("getcomputer.php");
      p.Post(RequestType.GetAllComputer.ToString(), parameters);
    }

    private void DoGetFiles(PostParamCollection parameters, string pcID)
    {
      HttpPost p = CreatePostHandler("getfiles.php");
      parameters.Add(new PostParameters("id", pcID));
      p.Post(RequestType.GetFiles.ToString(), parameters);
    }

    private void DoUploadFileContent(PostParamCollection parameters, string pcID, string file, string b64Data)
    {
      HttpPost p = CreatePostHandler("setcontent.php");
      parameters.Add(new PostParameters("id", pcID));
      parameters.Add(new PostParameters("file", file));
      parameters.Add(new PostParameters("content", b64Data));
      p.Post(RequestType.SetContent.ToString(), parameters);
    }

    private void DoDownloadFileContent(PostParamCollection parameters, string pcID, string file)
    {
      HttpPost p = CreatePostHandler("setcontent.php");
      parameters.Add(new PostParameters("id", pcID));
      parameters.Add(new PostParameters("file", file));
      p.Post(RequestType.GetContent.ToString(), parameters);
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

    void httpHandler_PostComplete(object sender, PostEventArgs e)
    {
      try
      {
        RawResult r = new RawResult((RequestType)Enum.Parse(typeof(RequestType), e.Name), e.PostResult, e.ErrorMessage, "");
        RaiseAll(r);
      }
      catch (Exception ex)
      {
        ExeptionLogger.Log(ex);
      }
    }

    private void RaiseAll(RawResult r)
    {
      OnPostCompleteRaw(r);
      switch (r.RequestTyp)
      {
        case RequestType.Login:

          break;
        case RequestType.GetAllComputer:

          break;
        case RequestType.SetPCDescription:

          break;
        case RequestType.GetAllUserPC:
          OnPostCompleteGetAllUserPC(new GetUserPostResult(r.Result, r.ErrorMessage, r.PostRequest));
          break;
        case RequestType.RemovePCUser:

          break;
        case RequestType.GetFiles:

          break;
        case RequestType.SetContent:

          break;
        case RequestType.GetContent:

          break;
      }
    }

    protected virtual void OnPostCompleteGetAllUserPC(BaseEvent<List<Account>> result)
    {
      if (PostCompleteGetAllUser != null)
        PostCompleteGetAllUser(this, result);
    }
    protected virtual void OnPostCompleteGetPCDescription(BaseEvent<string> result)
    {
        if (PostCompleteGetPCDescription != null)
            PostCompleteGetPCDescription(this, result);
    }

    private PostParamCollection GetLoginParams(Account ac)
    {
      PostParamCollection col = new PostParamCollection();
      col.Add(new PostParameters("user", ac.Username));
      col.Add(new PostParameters("pass", ac.Passwort));
      return col;
    }
  }
}