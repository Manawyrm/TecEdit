using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace de.manawyrm.TecEdit.Kernel.Http.Interface
{
  public abstract class BaseEvent<T> : EventArgs, IPostResult<T>
  {
    private string mPostRequest;
    private string mErrorMessage;

    public BaseEvent(string errorMessage, string postRequest)
    {
      mPostRequest = postRequest;
      mErrorMessage = errorMessage;
    }

    public virtual string Name
    {
      get { return ""; }
    }

    public string PostRequest
    {
      get { return mPostRequest; }
    }

    public string ErrorMessage
    {
      get { return mErrorMessage; }
    }

    public bool HasError
    {
      get { return !string.IsNullOrEmpty(mErrorMessage); }
    }

    public virtual T Result
    {
      get { return default(T); }
    }   

    public object GetGenericType()
    {
      return typeof(T);
    }
  }
}