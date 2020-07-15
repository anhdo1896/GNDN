using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Entity;

namespace SystemManageService
{
    public partial class SYS_Region_ProvinceService
    {
        public void DeleteSYS_Region_ProvinceByIDProvince(SYS_Region_Province sys_region_provinces)
        {
            _sys_region_provinceDataAccess.DeleteSYS_Region_OrganizationByIDProvince(sys_region_provinces);
        }
    }
}
