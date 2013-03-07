using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using de.manawyrm.TecEdit.Kernel.Http.Interface;
using de.manawyrm.TecEdit.Kernel.DataTypes;

namespace de.manawyrm.TecEdit.Kernel.Http.ResultHelper
{
  public class GetUserPostResult : BaseEvent<List<Account>>
  {
    private List<Account> mResult;

    public GetUserPostResult(string httpPostResult, string errorMessage, string postRequest)
      : base(errorMessage, postRequest)
    {
      DecodeResult(httpPostResult);
    }

    public override string Name
    {
      get { return RequestType.GetAllUserPC.ToString(); }
    }

    public override List<Account> Result
    {
      get { return mResult; }
    }

    private void DecodeResult(string httpPostResult)
    {
      mResult = new List<Account>();
      foreach (string user in httpPostResult.Split('\n'))
      {
        if(!string.IsNullOrEmpty(user))
          mResult.Add(new Account(Settings.AppSettings.Account.HostURL, user, ""));
      }
    }
  }
}
