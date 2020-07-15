using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Linq;
using System.Text;
using Entity;

namespace DataAccess
{
    public partial class SYS_Region_ProvinceDataAccess
    {
        public void DeleteSYS_Region_OrganizationByIDProvince(SYS_Region_Province sys_region_province)
        {
            DbConnection conn = _DbHelper.CreateConnection(Common.ConnectionString);
            conn.Open();
            try
            {
                List<DbParameter> para = new List<DbParameter>();
                para.Add(_DbHelper.CreateParameter(FIELD_IDPROVINCE, sys_region_province.IDProvince, false));
                _DbHelper.ExecuteReader(conn, Common.DatabaseSchema + "[SYS_Organization_DeleteByIDProvince]", para.ToArray());
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
