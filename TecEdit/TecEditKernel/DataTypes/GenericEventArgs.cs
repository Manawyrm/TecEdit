using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace de.manawyrm.TecEdit.Kernel.DataTypes
{
  public class GenericEventArgs<T> : EventArgs
  {
    private T mResult;

    public GenericEventArgs(T result)
    {
      mResult = result;
    }

    public bool HasResult
    {
      get { return mResult != null; }
    }

    public virtual T Result
    {
      get { return mResult; }
    }
  }
}
