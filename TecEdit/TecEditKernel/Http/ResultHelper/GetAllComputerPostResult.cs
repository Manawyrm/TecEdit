using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using de.manawyrm.TecEdit.Kernel.Http.Interface;
using de.manawyrm.TecEdit.Kernel.DataTypes;

namespace de.manawyrm.TecEdit.Kernel.Http.ResultHelper
{
  public class GetAllComputerPostResult : BaseEvent<List<Computer>>
  {
    private List<Computer> mResult;

    public GetAllComputerPostResult(PostEventArgs e)
      : base(e)
    {
      DecodeResult(e.PostResult);
    }

    public override List<Computer> Result
    {
      get { return mResult; }
    }

    private void DecodeResult(string httpPostResult)
    {
      if (ServerStatus == ServerRequestState.Success)
      {
        mResult = Computer.TryParse(httpPostResult);
      }
    }
  }
}