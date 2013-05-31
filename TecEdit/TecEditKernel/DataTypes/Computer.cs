using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using de.manawyrm.TecEdit.Kernel.Http.Interface;

namespace de.manawyrm.TecEdit.Kernel.DataTypes
{
  public class Computer : IDatabase
  {
    private int mID;
    private int mDBID;
    private Account mOwner;
    private string mComputerName;
    private ComputerType mPCType;

    public Computer(int internalID, int id, Account owner, string name, ComputerType pcType)
    {
      mID = id;
      mOwner = owner;
      mComputerName = name;
      mPCType = pcType;
      mDBID = internalID;
    }

    private static Computer Decode(string[] pcData)
    {
      Account ac = new Account(Settings.AppSettings.Account.HostURL, pcData[1], "");
      string name = pcData[2];
      int id = -1;
      int dbID = -1;
      ComputerType t = ComputerType.unknown;
      try
      {
        int.TryParse(pcData[3], out id);
        int.TryParse(pcData[0], out dbID);
        t = (ComputerType)Enum.Parse(typeof(ComputerType), pcData[4]);
      }
      catch (Exception ex)
      {
        ExeptionLogger.Log(ex);
      }
      return new Computer(dbID, id, ac, name, t);
    }

    public static List<Computer> TryParse(string rawResult)
    {
      List<Computer> output = new List<Computer>();
      try
      {
        foreach (string pcDataString in rawResult.Split('\n'))
        {
          string[] pcData = pcDataString.Split('|');
          if (pcData.Length == 5)
            output.Add(Decode(pcData));
        }
      }
      catch (Exception ex)
      {
        ExeptionLogger.Log(ex);
      }
      return output;
    }

    public int DBID
    {
      get { return mDBID; }
    }

    public int IngameID
    {
      get { return mID; }
    }

    public Account Owner
    {
      get { return mOwner; }
    }

    public ComputerType PCType
    {
      get { return mPCType; }
    }

    public string Name
    {
      get { return mComputerName; }
    }
  }
}