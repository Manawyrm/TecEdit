using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace de.manawyrm.TecEdit.Kernel.Http.Interface
{
  public interface IPostResult<T>
  {
    string Name
    {
      get;
    }

    string PostRequest
    {
      get;
    }

    T Result
    {
      get;
    }

    bool HasError
    {
      get;
    }

    string ErrorMessage
    {
      get;
    }
  }
}
