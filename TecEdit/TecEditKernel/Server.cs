using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace de.manawyrm.TecEdit.Kernel
{
  public class Server
  {
    public event EventHandler<EventArgs> UNUSED;
    protected virtual void OnUNUSED(EventArgs e)
    {
      if (UNUSED != null)
      {
        foreach (EventHandler singleCast in UNUSED.GetInvocationList())
        {
          ISynchronizeInvoke syncInvoke = singleCast.Target as ISynchronizeInvoke;
          try
          {
            if (syncInvoke != null && syncInvoke.InvokeRequired)
              syncInvoke.Invoke(UNUSED, new object[] { this, e });
            else
              singleCast(this, e);
          }
          catch (Exception ex)
          {
            ExeptionLogger.Log(ex);
          }
        }
      }
    }

    private void RaiseEvent()
    {
      OnUNUSED(new EventArgs());
    }

    private Account mAccount;

    public Server(Account ac)
    {
      if (ac != null && ac.HasLogin && ac.HasURL)
        mAccount = ac;
      else
        throw new InvalidOperationException("User nicht gesetzt in Config");
    }

    public bool ServerIsOnline
    {
      get { return true; }
    }

    public bool UserAccountExists
    {
      get { return true; }
    }
  }
}