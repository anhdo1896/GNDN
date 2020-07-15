using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Entity;

namespace SystemManageService
{
    public partial class SYS_RegionService
    {
        public List<SYS_Region> SelectAllSYS_RegionByIDRegion(int IDRegion)
        {
            return _sys_regionDataAccess.SelectAllSYS_RegionByIDRegion(IDRegion);
        }

        public List<SYS_Region> SelectAllSYS_RegionAddOrganization()
        {
            return _sys_regionDataAccess.SelectAllSYS_RegionAddOrganization();
        }
    }
}
