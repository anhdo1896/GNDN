//------------------------------------------------------------------------------------------------------------------------
//-- Generated By:   TrungVK using CodeSmith 5.0.0.0
//-- Template:       ServiceGen.cst
//-- Date Generated: Monday, July 12, 2010
//------------------------------------------------------------------------------------------------------------------------
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using Connection;
using DataAccess;
using Entity;
namespace SystemManageService
{
	public partial class SYS_UserConfigService
    {
		
        public SYS_UserConfig SelectByUserID_UserConfig(int UserId)
        {
            return _sys_UserConfigDataAccess.SelectByUserID(UserId);
        }

	    public SYS_UserConfig SelectByUserID_UserConfig(int UserId, string connect)
	    {
            return _sys_UserConfigDataAccess.SelectByUserID(UserId,connect);
	    }

	    public SYS_UserConfig SelectByUserID_UserConfigByStrCn(int UserId)
	    {
            int moduleID = int.Parse(ConfigurationSettings.AppSettings["DocumentManagement"]);
           // return _sys_UserConfigDataAccess.SelectByUserID_UserConfigByStrCn(GetConnectStringByModule(moduleID), UserId);
	        return null;
	    }
    }
}



