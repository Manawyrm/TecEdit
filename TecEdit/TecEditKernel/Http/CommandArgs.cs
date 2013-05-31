using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace de.manawyrm.TecEdit.Kernel.Http
{
  public class CommandArgs
  {
    public CommandArgs(PostParamCollection commandList)
    {
      mCommands = commandList;
    }

    private PostParamCollection mCommands;
    public PostParamCollection Commands
    {
      get { return mCommands; }
      set { mCommands = value; }
    }
  }
}
