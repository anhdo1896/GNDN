using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DataAccess;


namespace SystemManageService
{
    public partial class SYS_CategoryManagerService 
    {
        public bool RunQuery(string Query)
        {
            return _sys_categorymanagerDataAccess.RunQuery(Query, Common.ConnectionString);
        }
    }
}
