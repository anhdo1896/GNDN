//------------------------------------------------------------------------------------------------------------------------
//-- CREATE By:   TrungVK
//-- Date CREATE: Monday, July 12, 2010
//------------------------------------------------------------------------------------------------------------------------
using System;
using DataAccess;

namespace SystemManageService
{
    public class SYS_DBManager 
    {
        public SYS_DBManagerDataAccess _SysDbManagerDataAccess = new SYS_DBManagerDataAccess();
        public bool BackupDataBase(string fileName)
        {
            return _SysDbManagerDataAccess.BackupDB(fileName);
        }

        public bool RestoreDataBase(string fileName)
        {
            return _SysDbManagerDataAccess.RestoreDB(fileName);
        }
    }
}


