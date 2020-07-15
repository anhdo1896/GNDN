using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Linq;
using System.Text;
using Entity;

namespace DataAccess
{
    public partial class SYS_RegionDataAccess 
    {

        public List<SYS_Region> SelectAllSYS_RegionByIDRegion(int IDRegion)
        {
            List<SYS_Region> sys_region = new List<SYS_Region>();
            DbDataReader reader = null;
            DbConnection conn = _DbHelper.CreateConnection(Common.ConnectionString);
            conn.Open();
            try
            {
                List<DbParameter> para = new List<DbParameter>();
                para.Add(_DbHelper.CreateParameter(FIELD_ID, IDRegion, false));
                reader = _DbHelper.ExecuteReader(conn, Common.DatabaseSchema + "[SYS_Region_SelectAllByIDRegion]", para.ToArray());
                if (reader.HasRows)
                    SYS_RegionDataAccess.SetListSYS_RegionInfo(ref reader, ref sys_region);
                return sys_region;
            }
            catch (Exception ex)
            {
                throw new Exception(String.Format(" SelectAllSYS_RegionByIDRegion: {0}", ex.Message));
            }
            finally
            {
                if (reader != null)
                    reader.Close();
                conn.Close();
            }
        }

        private static void SetListSYS_RegionInfoAddOrganization(ref DbDataReader reader, ref List<SYS_Region> lstRegion)
        {
            SYS_Region sysRegion=null;
            SYS_OrganizationDataAccess sysOrganizationDataAccess=new SYS_OrganizationDataAccess();
            SYS_ProvinceDataAccess sysProvinceDataAccess=new SYS_ProvinceDataAccess();
            while (reader.Read())
            {
                sysRegion=new SYS_Region();
                SYS_RegionDataAccess.SetSYS_RegionInfo(reader,ref sysRegion);
                sysRegion.LstOrganization = sysOrganizationDataAccess.SelectAllSYS_RegionByIDRegion(sysRegion.ID);
                sysRegion.LstProvince = sysProvinceDataAccess.SelectAllSYS_RegionByIDRegion_Province(sysRegion.ID);
                lstRegion.Add(sysRegion);
            }

        }

        public List<SYS_Region> SelectAllSYS_RegionAddOrganization()
        {
            List<SYS_Region> sys_region = new List<SYS_Region>();
            DbDataReader reader = null;
            DbConnection conn = _DbHelper.CreateConnection(Common.ConnectionString);
            conn.Open();
            try
            {
                reader = _DbHelper.ExecuteReader(conn, Common.DatabaseSchema + "[SYS_Region_SelectAll]", (DbParameter[])null);
                if (reader.HasRows)
                    SYS_RegionDataAccess.SetListSYS_RegionInfoAddOrganization(ref reader, ref sys_region);
                return sys_region;
            }
            catch (Exception ex)
            {
                throw new Exception(String.Format(" SYS_RegionDataAccess.SelectAll: {0}", ex.Message));
            }
            finally
            {
                if (reader != null)
                    reader.Close();
                conn.Close();
            }
        }
        
    }
}
