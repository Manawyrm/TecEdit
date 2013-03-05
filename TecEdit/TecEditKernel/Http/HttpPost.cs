using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.ComponentModel;

namespace de.manawyrm.TecEdit.Kernel.Http
{
  public class HttpPost
  {
    public event EventHandler<PostEventArgs> PostComplete;

    protected virtual void OnPostComplete(PostEventArgs e)
    {
      if (PostComplete != null)
        PostComplete(this, e);
    }
  
    private string mPostUri;
    private string mRequestID;
    private BackgroundWorker mRequestHandler;

    public HttpPost(string postUri)
    {
      mPostUri = postUri;
      Init();
    }

    public string PostUri
    {
      get { return mPostUri; }
    }

    public bool Post(string eventName, PostParamCollection postParamCollection)
    {
      if (!mRequestHandler.IsBusy)
      {
        mRequestHandler.RunWorkerAsync(postParamCollection);
        mRequestID = eventName;
      }
      return !mRequestHandler.IsBusy;
    }

    private void Init()
    {
      System.Net.WebRequest.DefaultWebProxy = null;
      if (mRequestHandler == null)
      {
        mRequestHandler = new BackgroundWorker();
        mRequestHandler.WorkerSupportsCancellation = true;
        mRequestHandler.WorkerReportsProgress = true;
        mRequestHandler.DoWork += new DoWorkEventHandler(mRequestHandler_DoWork);
        mRequestHandler.ProgressChanged += new ProgressChangedEventHandler(mRequestHandler_ProgressChanged);
      }
    }

    private void Raise(string message, string errorCode)
    {
      mRequestHandler.ReportProgress(0, new PostEventArgs(mRequestID, message, errorCode));      
    }

    void mRequestHandler_DoWork(object sender, DoWorkEventArgs e)
    {
      string responseStream ="";
      string parameterString = "";

      try
      {
        Uri uri = new Uri(mPostUri);
        WebRequest webRequest = WebRequest.Create(uri);
        webRequest.Headers.Add(HttpRequestHeader.AcceptLanguage, "");

        webRequest.Method = "POST";
        webRequest.ContentType = "application/x-www-form-urlencoded";

        foreach (PostParameters parameter in (PostParamCollection)e.Argument)
        {
          parameterString += parameter.Paramter + "=" + parameter.Value + "&";
        }

        byte[] byteArray = Encoding.UTF8.GetBytes(parameterString);
        webRequest.ContentLength = byteArray.Length;

        Stream stream = webRequest.GetRequestStream();
        stream.Write(byteArray, 0, byteArray.Length);
        stream.Close();

        WebResponse webResponse = webRequest.GetResponse();
        stream = webResponse.GetResponseStream();

        StreamReader streamReader = new StreamReader(stream);
        responseStream = streamReader.ReadToEnd();

        webResponse.Close();
        streamReader.Close();

        Raise(responseStream, "");
      }
      catch (Exception ex)
      {
        ExeptionLogger.Log(ex);
        Raise(responseStream, ex.ToString());
      }
    }

    void mRequestHandler_ProgressChanged(object sender, ProgressChangedEventArgs e)
    {
      OnPostComplete((PostEventArgs)e.UserState);
    }
  }

  public class PostEventArgs : EventArgs
  {
    private string mMessageResult;
    private string mErrorResult;
    private string mEventName;

    /// <summary>
    /// eventName zum abfragen im EventResult
    /// message der PostResult
    /// errorResult wenn kein error leer string
    /// </summary>
    /// <param name="eventName"></param>
    /// <param name="message"></param>
    /// <param name="errorResult"></param>
    public PostEventArgs(string eventName, string message, string errorResult)
    {
      mMessageResult = message;
      mErrorResult = errorResult;
      mEventName = eventName;
    }

    public string ErrorMessage
    {
      get { return mErrorResult; }
    }

    public string Name
    {
      get { return mEventName; }
    }

    public string PostResult
    {
      get { return mMessageResult; }
    }

    public bool HasError
    {
      get { return !string.IsNullOrEmpty(mErrorResult); }
    }
  }

  public class PostParameters
  {
    public PostParameters(string paramter, string value)
    {
      Paramter = paramter;
      Value = value;
    }

    private string mParameter;
    public string Paramter
    {
      get { return mParameter; }
      set { mParameter = value; }
    }

    private string mValue;
    public string Value
    {
      get { return mValue; ; }
      set { mValue = value; }
    }
  }

  public class PostParamCollection : List<PostParameters>
  {
  }
}