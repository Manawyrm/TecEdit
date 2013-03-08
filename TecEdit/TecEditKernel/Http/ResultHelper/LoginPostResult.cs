using de.manawyrm.TecEdit.Kernel.DataTypes;
using de.manawyrm.TecEdit.Kernel.Http.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace de.manawyrm.TecEdit.Kernel.Http.ResultHelper
{
  public class LoginPostResult : BaseEvent<LoginState>
  {
    private LoginState mResult;

    public LoginPostResult(string httpPostResult, string errorMessage, string postRequest)
      : base(errorMessage, postRequest)
    {
      DecodeResult(httpPostResult);
    }

    public override string Name
    {
      get { return RequestType.Login.ToString(); }
    }

    public override LoginState Result
    {
      get { return mResult; }
    }

    private void DecodeResult(string httpPostResult)
    {
      if (!string.IsNullOrEmpty(httpPostResult))
        mResult = (LoginState)Enum.Parse(typeof(LoginState), httpPostResult);
      else
        mResult = LoginState.unknown;
    }
  }
}
