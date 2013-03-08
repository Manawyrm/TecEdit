using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using de.manawyrm.TecEdit.Kernel.DataTypes;

namespace de.manawyrm.TecEdit.Kernel
{
  public class Server
  {
    private Account mAccount;

    public Server(Account ac)
    {
      if (ac != null && ac.HasLogin && ac.HasURL)
        mAccount = ac;
      else
        throw new InvalidOperationException(Constants.EC_UserNotFound);
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