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

    public GetUserPostResult(PostEventArgs e)
      : base(e)
    {
      DecodeResult(e.PostResult);
    }

    public override List<Account> Result
    {
      get { return mResult; }
    }

    private void DecodeResult(string httpPostResult)
    {
      mResult = new List<Account>();
      if (ServerStatus == ServerRequestState.Success)
      {
        foreach (string userString in httpPostResult.Split('\n'))
        {
          string[] uData = userString.Split('|');
          int uID;

          bool validID = int.TryParse(uData[0], out uID);

          if (validID && !string.IsNullOrEmpty(uData[1]))
            mResult.Add(new Account(Settings.AppSettings.Account.HostURL, uData[1], uID));
        }
      }
    }
  }
}