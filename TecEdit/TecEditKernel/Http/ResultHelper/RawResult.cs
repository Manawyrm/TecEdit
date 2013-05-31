using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using de.manawyrm.TecEdit.Kernel.Http.Interface;

namespace de.manawyrm.TecEdit.Kernel.Http.ResultHelper
{
  public class RawResult : BaseEvent<string>
  {
    public RawResult(PostEventArgs e)
      : base(e)
    {
    } 
  }
}
