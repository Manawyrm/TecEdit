using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace de.manawyrm.TecEdit.Kernel
{
  public static class Constants
  {
    #region Einstellungen
    public const string SettingsFileName = "conf";
    public const string DefaultURL = "http://teccraft.de/tecedit/";
    public const string DefaultReportURL = "http://tbspace.de/tecedit/" + php_ReportBug;
    #endregion

    #region phpTargetFileDefinitions
    public const string php_Login = "login.php";
    public const string php_SetPCDescription = "setdesc.php";
    public const string php_GetAllUserPC = "getuser.php";
    public const string php_RemovePCUser = "deregister.php";
    public const string php_GetAllComputer = "getcomputer.php";
    public const string php_ReportBug = "reportbug.php";
    public const string php_GetFiles = "getfiles.php";
    public const string php_SetContent = "setcontent.php";
    public const string php_RegisterUserToPC = "register_sec.php";
    public const string php_GetContent = "getcontent.php";
    #endregion

    #region ErrorCodes
    public const string EC_UserNotFound = "User nicht gesetzt in Config";
    #endregion

    #region Api
    private static Dictionary<string, string> mApis;
    public static Dictionary<string, string> Apis
    {
      get
      {
        if (mApis == null)
        {
          mApis = new Dictionary<string, string>(){
          {"Bit","http://computercraft.info/wiki/Bit_(API)"},
          {"Colors","http://computercraft.info/wiki/Colors_(API)"},
          {"Coroutine","http://computercraft.info/wiki/Coroutine_(API)"},
          {"Disk","http://computercraft.info/wiki/Disk_(API)"},
          {"Fs","http://computercraft.info/wiki/Fs_(API)"},
          {"Gps","http://computercraft.info/wiki/Gps_(API)"},
          {"Help","http://computercraft.info/wiki/Help_(API)"},
          {"HTTP","http://computercraft.info/wiki/HTTP_(API)"},
          {"IO","http://computercraft.info/wiki/IO_(API)"},
          {"Math","http://computercraft.info/wiki/Math_(API)"},
          {"OS","http://computercraft.info/wiki/OS_(API)"},
          {"Paintutils","http://computercraft.info/wiki/Paintutils_(API)"},
          {"Parallel","http://computercraft.info/wiki/Parallel_(API)"},
          {"Peripheral","http://computercraft.info/wiki/Peripheral_(API)"},
          {"Rednet","http://computercraft.info/wiki/Rednet_(API)"},
          {"Redstone","http://computercraft.info/wiki/Redstone_(API)"},
          {"Shell","http://computercraft.info/wiki/Shell_(API)"},
          {"String","http://computercraft.info/wiki/String_(API)"},
          {"Table","http://computercraft.info/wiki/Table_(API)"},
          {"Term","http://computercraft.info/wiki/Term_(API)"},
          {"Textutils","http://computercraft.info/wiki/Textutils_(API)"},
          {"Turtle","http://computercraft.info/wiki/Turtle_(API)"},
          {"Vector","http://computercraft.info/wiki/Vector_(API)"}
          };
        }
        return mApis;
      }
    }
    #endregion
  }
}