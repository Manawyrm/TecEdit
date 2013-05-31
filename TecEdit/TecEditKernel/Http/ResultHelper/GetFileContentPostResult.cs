using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using de.manawyrm.TecEdit.Kernel.Http.Interface;
using de.manawyrm.TecEdit.Kernel.DataTypes;

namespace de.manawyrm.TecEdit.Kernel.Http.ResultHelper
{
  public class GetFileContentPostResult : BaseEvent<TecEditFile>
  {
    private TecEditFile mResult;

    public GetFileContentPostResult(PostEventArgs e)
      : base(e)
    {
      DecodeResult(e.PostResult);
    }

    public override TecEditFile Result
    {
      get { return mResult; }
    }

    private void DecodeResult(string httpPostResult)
    {
      if (ServerStatus == ServerRequestState.Success)
      {
        string[] data = httpPostResult.Split('|');
        if (data.Length == 2)
          mResult = new TecEditFile(data[0], Utility.DecodeFrom64(data[1]));
      }
    }
  }
}
