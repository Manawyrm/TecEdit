using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using de.manawyrm.TecEdit.Kernel.DataTypes;
using de.manawyrm.TecEdit.Kernel.Http.Interface;

namespace de.manawyrm.TecEdit.Kernel.Http.ResultHelper
{
  public class GetFolderContentPostResult : BaseEvent<TecEditFolder>
  {
    private TecEditFolder mResult;

    public GetFolderContentPostResult(PostEventArgs e)
      : base(e)
    {
      DecodeResult(e.PostResult);
    }

    public override TecEditFolder Result
    {
      get { return mResult; }
    }

    private void DecodeResult(string httpPostResult)
    {
      if (ServerStatus == ServerRequestState.Success)
      {
        mResult = TecEditFolder.TryParse(httpPostResult);
      }
    }
  }
}
