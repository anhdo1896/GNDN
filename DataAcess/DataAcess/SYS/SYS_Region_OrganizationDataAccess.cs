using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Linq;
using System.Text;
using Entity;

namespace DataAccess
{
    public partial class SYS_Region_OrganizationDataAccess
    {
        public void DeleteSYS_Region_OrganizationByIDOrganization(SYS_Region_Organization sys_region_organization)
        {
            DbConnection conn = _DbHelper.CreateConnection(Common.ConnectionString);
            conn.Open();
            try
            {
                List<DbParameter> para = new List<DbParameter>();
                para.Add(_DbHelper.CreateParameter(FIELD_IDORGANIZATION, sys_region_organization.IDOrganization, false));
                _DbHelper.ExecuteReader(conn, Common.DatabaseSchema + "[SYS_Organization_DeleteByIDOrganization]", para.ToArray());
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                conn.Close();
            }

        }
        public void Delete_SYS_Region_OrganizationByIDRegion(int IDRegion, int IDOrganization)
        {
            DbConnection conn = _DbHelper.CreateConnection(Common.ConnectionString);
            conn.Open();
            try
            {
                List<DbParameter> para = new List<DbParameter>();
                para.Add(_DbHelper.CreateParameter(FIELD_IDORGANIZATION, IDOrganization, false));
                para.Add(_DbHelper.CreateParameter(FIELD_IDREGION, IDRegion, false));
                _DbHelper.ExecuteReader(conn, Common.DatabaseSchema + "[Delete_SYS_Region_OrganizationByIDRegion]", para.ToArray());
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                conn.Close();
            }

        }
    }
}
