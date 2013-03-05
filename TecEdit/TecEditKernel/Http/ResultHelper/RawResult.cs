using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using de.manawyrm.TecEdit.Kernel.Http.Interface;

namespace de.manawyrm.TecEdit.Kernel.Http.ResultHelper
{
  public class RawResult : BaseEvent<string>
  {
    private string mResult;
    private RequestType mType;

    public RawResult(RequestType requestType, string httpPostResult, string errorMessage, string postRequest)
      : base(errorMessage, postRequest)
    {
      mResult = httpPostResult;
      mType = requestType;
    }

    public RequestType RequestTyp
    {
      get { return mType; }
    }

    public override string Name
    {
      get { return mType.ToString(); }
    }

    public override string Result
    {
      get { return mResult; }
    }
  }
}
