using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using de.manawyrm.TecEdit.Kernel.DataTypes;

namespace de.manawyrm.TecEdit.Kernel.Http.Interface
{
  public abstract class BaseEvent<T> : EventArgs, IPostResult<T>
  {
    private string mPostRequest;
    private string mErrorMessage;
    private string mName;
    private string mRawResult;
    private ServerRequestState mState;
    private RequestType mType;

    public BaseEvent(RequestType type, string eventName, string httpPostResult, string errorMessage, string postRequest)
    {
      mPostRequest = postRequest;
      mErrorMessage = errorMessage;
      mName = eventName;
      mRawResult = httpPostResult;
      mType = type;
      GetServerRequestState();
    }

    public BaseEvent(PostEventArgs e)
    {
      mPostRequest = e.PostRequest;
      mErrorMessage = e.ErrorMessage;
      mName = e.Name;
      mRawResult = e.PostResult;
      mType = e.RequestType;
      GetServerRequestState();
    }

    public string Name
    {
      get { return mName; }
    }

    public RequestType HttpRequestType
    {
      get { return mType; }
    }

    public string RawData
    {
      get { return mRawResult; }
    }

    public string PostRequest
    {
      get { return mPostRequest; }
    }

    public string ErrorMessage
    {
      get { return mErrorMessage; }
    }

    public bool HasResult
    {
      get { return Result != null; }
    }

    public bool HasError
    {
      get { return !string.IsNullOrEmpty(mErrorMessage); }
    }

    public virtual T Result
    {
      get { return default(T); }
    }

    public ServerRequestState ServerStatus
    {
      get { return mState; }
    }

    private void GetServerRequestState()
    {
      try
      {
        if (string.IsNullOrEmpty(mRawResult))
          mState = ServerRequestState.Unknown;
        else
        {
          if (mRawResult.Length == 1)
            mState = (ServerRequestState)Enum.Parse(typeof(ServerRequestState), mRawResult);
          else
            mState = ServerRequestState.Success;
        }
      }
      catch (Exception ex)
      {
        ExeptionLogger.Log(ex);
        mState = ServerRequestState.Unknown;
      }

      if (mState == ServerRequestState.Denied && mErrorMessage.Contains(HttpRequestType.ToString()))
        mErrorMessage = "Server nicht erreichbar !";
    }
  }
}