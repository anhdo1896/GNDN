using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using Entity;

namespace SystemManageService
{
    public partial class SYS_ProvinceService
    {

        public SYS_Province SelectSYS_ProvinceByName(string name)
        {
            return _sys_provinceDataAccess.SelectSYS_ProvinceByName(name);
        }

        public List<SYS_Province> SelectAllSYS_ProvinceGetRegion()
        {
            return _sys_provinceDataAccess.SelectAllSYS_ProvinceGetRegion();
        }
        public DataTable SelectParentID_Provice(int IDBC)
        {
            return _sys_provinceDataAccess.SelectParentID_Provice(IDBC);
        }
    }
}
