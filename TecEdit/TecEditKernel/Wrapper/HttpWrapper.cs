using HttpPostRequestLib.Net;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;

namespace de.manawyrm.TecEdit.Kernel.Wrapper
{
  public class HttpWrapper
  {
    private Account mAccount;

    public HttpWrapper(Account ac)
    {
      mAccount = ac;
    }

    public void DoLogin()
    {
      PostParamCollection postParamCollection = new PostParamCollection();
      postParamCollection.Add(new PostParam("user", mAccount.Username));
      postParamCollection.Add(new PostParam("pass", mAccount.Passwort));
      HttpPost httpPost = new HttpPost(mAccount.HostURL + "login.php");
      httpPost.doPost(postParamCollection);
      httpPost.PostComplete += httpPost_PostComplete;

      //HTTPPostRequest request = new HTTPPostRequest(mAccount.HostURL + "login.php");
      //request.Post.Add("user", mAccount.Username);
      //request.Post.Add("pass", mAccount.Passwort);
      //RegisterEventHandler(request);
    }

    void httpPost_PostComplete(object sender, EventArgs e)
    {
      
    }

    private void RegisterEventHandler(HTTPPostRequest request)
    {
      request.ProgressChanged += request_ProgressChanged;
      request.SubmitComplete += request_SubmitComplete;
      request.SubmitCancel += request_SubmitCancel;
      request.SubmitASync();
    }

    void request_SubmitCancel(object sender, EventArgs e)
    {
      try
      {
      }
      catch (Exception ex)
      {
        ExeptionLogger.Log(ex);
      }
    }

    private void DeRegisterEventHandler()
    {
    }

    void request_SubmitComplete(object sender, SubmitEventArgs e)
    {
      try
      {
      }
      catch (Exception ex)
      {
        ExeptionLogger.Log(ex);
      }
    }

    void request_ProgressChanged(object sender, ProgressEventArgs e)
    {
      try
      {
      }
      catch (Exception ex)
      {
        ExeptionLogger.Log(ex);
      }
    }

    public event EventHandler<EventArgs> UNUSED;
    protected virtual void OnUNUSED(EventArgs e)
    {
      if (UNUSED != null)
      {
        foreach (EventHandler singleCast in UNUSED.GetInvocationList())
        {
          ISynchronizeInvoke syncInvoke = singleCast.Target as ISynchronizeInvoke;
          try
          {
            if (syncInvoke != null && syncInvoke.InvokeRequired)
              syncInvoke.Invoke(UNUSED, new object[] { this, e });
            else
              singleCast(this, e);
          }
          catch (Exception ex)
          {
            ExeptionLogger.Log(ex);
          }
        }
      }
    }

    private void RaiseEvent()
    {
      OnUNUSED(new EventArgs());
    }
  }
}
