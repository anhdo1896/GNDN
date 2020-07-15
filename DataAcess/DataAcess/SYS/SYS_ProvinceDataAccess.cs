using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Linq;
using System.Text;
using Entity;

namespace DataAccess
{
    public partial class SYS_ProvinceDataAccess
    {
        public DataTable SelectParentID_Provice(int IDBC)
        {
            DbConnection connection = _DbHelper.CreateConnection(Common.ConnectionString);
            connection.Open();
            try
            {
                ArrayList para = new ArrayList();
                para.Add(_DbHelper.CreateParam("ID", SqlDbType.Int, IDBC));
                return _DbHelper.RunProcedureGetTable(connection, Common.DatabaseSchema + "[SelectParentID_Provice]",
                                                      para);
            }
            catch (Exception ex)
            {
                throw new Exception(String.Format("KetQuaQTMT_KT_LoDotByIDBC_PhanLoai.SelectById: {0}", ex.Message));
            }
            finally
            {
                connection.Close();
            }
        }
        public SYS_Province SelectSYS_ProvinceByName(string name)
        {
            DbConnection conn = _DbHelper.CreateConnection(Common.ConnectionString);
            conn.Open();
            SYS_Province sys_province = new SYS_Province();
            DbDataReader reader = null;
            try
            {
                List<DbParameter> para = new List<DbParameter>();
                para.Add(_DbHelper.CreateParameter(FIELD_NAME, name, false));

                reader = _DbHelper.ExecuteReader(conn, Common.DatabaseSchema + "[SYS_Province_SelectByName]", para.ToArray());
                if (reader.HasRows && reader.Read())
                    SYS_ProvinceDataAccess.SetSYS_ProvinceInfo(reader, ref sys_province);
                return sys_province;
            }
            catch (Exception ex)
            {
                throw new Exception(String.Format("SYS_RolesDataAccess.SelectSYS_ProvinceByName: {0}", ex.Message));
            }
            finally
            {
                if (reader != null)
                    reader.Close();
                conn.Close();
            }

        }

        public List<SYS_Province> SelectAllSYS_RegionByIDRegion_Province(int IDRegion)
        {
            List<SYS_Province> sys_Province = new List<SYS_Province>();
            DbDataReader reader = null;
            DbConnection conn = _DbHelper.CreateConnection(Common.ConnectionString);
            conn.Open();
            try
            {
                List<DbParameter> para = new List<DbParameter>();
                para.Add(_DbHelper.CreateParameter(FIELD_ID, IDRegion, false));
                reader = _DbHelper.ExecuteReader(conn, Common.DatabaseSchema + "[SYS_Region_SelectAllByIDRegion_Province]", para.ToArray());
                if (reader.HasRows)
                    SYS_ProvinceDataAccess.SetListSYS_ProvinceInfo(ref reader, ref sys_Province);
                return sys_Province;
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


        public List<SYS_Province> SelectAllSYS_ProvinceGetRegion()
        {
            List<SYS_Province> sys_province = new List<SYS_Province>();
            DbDataReader reader = null;
            DbConnection conn = _DbHelper.CreateConnection(Common.ConnectionString);
            conn.Open();
            try
            {
                reader = _DbHelper.ExecuteReader(conn, Common.DatabaseSchema + "[SYS_Province_GetRegion]", (DbParameter[])null);
                if (reader.HasRows)
                    SYS_ProvinceDataAccess.SetListSYS_ProvinceInfo(ref reader, ref sys_province);
                return sys_province;
            }
            catch (Exception ex)
            {
                throw new Exception(String.Format(" SYS_ProvinceDataAccess.SelectAll: {0}", ex.Message));
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
