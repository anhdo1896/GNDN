using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Entity;

namespace SystemManageService
{
    public partial class SYS_Region_OrganizationService 
    {
        public void DeleteSYS_Region_OrganizationByIDOrganization(SYS_Region_Organization sys_region_organizations)
        {
            _sys_region_organizationDataAccess.DeleteSYS_Region_OrganizationByIDOrganization(sys_region_organizations);
        }
        public void Delete_SYS_Region_OrganizationByIDRegion(int IDRegion, int IDOrganization)
        {
            _sys_region_organizationDataAccess.Delete_SYS_Region_OrganizationByIDRegion(IDRegion,IDOrganization);
        }
    }
}
