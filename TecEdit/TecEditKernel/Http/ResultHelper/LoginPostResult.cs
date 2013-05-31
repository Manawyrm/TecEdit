using de.manawyrm.TecEdit.Kernel.DataTypes;
using de.manawyrm.TecEdit.Kernel.Http.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace de.manawyrm.TecEdit.Kernel.Http.ResultHelper
{
  public class LoginPostResult : BaseEvent<ServerRequestState>
  {
    private ServerRequestState mResult;

    public LoginPostResult(PostEventArgs e)
      : base(e)
    {
      DecodeResult(e.PostResult);
    }

    public override ServerRequestState Result
    {
      get { return mResult; }
    }

    private void DecodeResult(string httpPostResult)
    {
      mResult = ServerStatus;
    }
  }
}
