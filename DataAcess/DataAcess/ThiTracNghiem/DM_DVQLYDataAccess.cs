//------------------------------------------------------------------------------------------------------------------------
//-- Generated By:   TrungVK using CodeSmith 4.0.0.0
//-- Template:       DataAcess.cst
//-- Date Generated: Friday, September 19, 2014
//------------------------------------------------------------------------------------------------------------------------
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Linq;
using System.Text;
using Entity;
using System.Data.SqlClient;

namespace DataAccess
{
    public partial class DM_DVQLYDataAccess
    {
        public DataTable DM_DVQLY_SelectByLever(int Ma_dviqly,int Level)
        {
            DbConnection connection = _DbHelper.CreateConnection(Common.ConnectionString);
            connection.Open();
            try
            {
                ArrayList para = new ArrayList();
                para.Add(_DbHelper.CreateParam("IDMA_DVIQLY", SqlDbType.Int, Ma_dviqly));
                para.Add(_DbHelper.CreateParam("Level", SqlDbType.Int, Level));
                DataTable dt = _DbHelper.RunProcedureGetTable(connection, Common.DatabaseSchema + "[DM_DVQLY_SelectByLever]", para);
                return dt;
            }
            catch (Exception ex)
            {
                throw new Exception(String.Format("DM_DVQLY_SelectByLever: {0}", ex.Message));
            }
            finally
            {
                connection.Close();
            }

        }
        public DataTable DM_DVQLY_SelectReturnCha(string Ma_dviqly)
        {
            DbConnection connection = _DbHelper.CreateConnection(Common.ConnectionString);
            connection.Open();
            try
            {
                ArrayList para = new ArrayList();
                para.Add(_DbHelper.CreateParam("IDMA_DVIQLY", SqlDbType.VarChar, Ma_dviqly));
                DataTable dt = _DbHelper.RunProcedureGetTable(connection, Common.DatabaseSchema + "[DM_DVQLY_SelectReturnCha]", para);
                return dt;
            }
            catch (Exception ex)
            {
                throw new Exception(String.Format("DM_DVQLY_SelectReturnCha.SelectAll_DVI_ByChild: {0}", ex.Message));
            }
            finally
            {
                connection.Close();
            }

        }
        public List<DM_DVQLY> DM_DVQLYandLEVER_BYDV(string Ma_dv)
        {
            List<DM_DVQLY> dm_dvqly = new List<DM_DVQLY>();
            DbDataReader reader = null;
            DbConnection conn = _DbHelper.CreateConnection(Common.ConnectionString);
            conn.Open();
            try
            {
                List<DbParameter> para = new List<DbParameter>();

                para.Add(_DbHelper.CreateParameter("MA_DVIQLY", Ma_dv, false));
                reader = _DbHelper.ExecuteReader(conn, Common.DatabaseSchema + "[DM_DVQLYandLEVER_BYDV]", para.ToArray());
                if (reader.HasRows)
                    DM_DVQLYDataAccess.SetListDM_DVQLYInfo(ref reader, ref dm_dvqly);
                return dm_dvqly;
            }
            catch (Exception ex)
            {
                throw new Exception(String.Format(" DM_DVQLYandLEVER_BYDV.SelectAll: {0}", ex.Message));
            }
            finally
            {
                if (reader != null)
                    reader.Close();
                conn.Close();
            }
        }
        public DataTable SelectAll_DVI_ByChild(int Ma_dviqly)
        {
            DbConnection connection = _DbHelper.CreateConnection(Common.ConnectionString);
            connection.Open();
            try
            {
                ArrayList para = new ArrayList();
                para.Add(_DbHelper.CreateParam("IDMA_DVIQLY", SqlDbType.Int, Ma_dviqly));
                DataTable dt = _DbHelper.RunProcedureGetTable(connection, Common.DatabaseSchema + "[SelectAll_DVI_ByChild]", para);
                return dt;
            }
            catch (Exception ex)
            {
                throw new Exception(String.Format("BV_CTR_ByIDBC.SelectAll_DVI_ByChild: {0}", ex.Message));
            }
            finally
            {
                connection.Close();
            }

        }
        public DataTable DM_DVQLY_SelectAllCapCha()
        {
            DbConnection connection = _DbHelper.CreateConnection(Common.ConnectionString);
            connection.Open();
            try
            {
                DataTable dt = _DbHelper.RunProcedureGetTable(connection, Common.DatabaseSchema + "[DM_DVQLY_SelectAllCapCha]", null);
                return dt;
            }
            catch (Exception ex)
            {
                throw new Exception(String.Format("BV_CTR_ByIDBC.DM_DVQLY_SelectAllCapCha: {0}", ex.Message));
            }
            finally
            {
                connection.Close();
            }

        }
        public DM_DVQLY DM_DVQLY_SelectAll_byMaDVi(string Ma_DVi)
        {

            DM_DVQLY dm_dvqly = new DM_DVQLY();
            DbDataReader reader = null;
            DbConnection conn = _DbHelper.CreateConnection(Common.ConnectionString);
            conn.Open();
            try
            {
                List<DbParameter> para = new List<DbParameter>();
                para.Add(_DbHelper.CreateParameter(FIELD_MA_DVIQLY, Ma_DVi, false));

                reader = _DbHelper.ExecuteReader(conn, Common.DatabaseSchema + "[DM_DVQLY_SelectAll_byMaDVi]", para.ToArray());
                if (reader.HasRows && reader.Read())
                    DM_DVQLYDataAccess.SetDM_DVQLYInfo(reader, ref dm_dvqly);
                return dm_dvqly;
            }
            catch (Exception ex)
            {
                throw new Exception(String.Format("DM_DVQLYDataAccess.DM_DVQLY_SelectAll_byMaDVi: {0}", ex.Message));
            }
            finally
            {
                if (reader != null)
                    reader.Close();
                conn.Close();
            }

        }
        public DataTable Select_DVI_Cha_ByChild(int Ma_dviqly)
        {
            DbConnection connection = _DbHelper.CreateConnection(Common.ConnectionString);
            connection.Open();
            try
            {
                ArrayList para = new ArrayList();
                para.Add(_DbHelper.CreateParam("IDMA_DVIQLY", SqlDbType.Int, Ma_dviqly));
                DataTable dt = _DbHelper.RunProcedureGetTable(connection, Common.DatabaseSchema + "[Select_DVI_Cha_ByChild]", para);
                return dt;
            }
            catch (Exception ex)
            {
                throw new Exception(String.Format("BV_CTR_ByIDBC.Select_DVI_Cha_ByChild: {0}", ex.Message));
            }
            finally
            {
                connection.Close();
            }

        }
    }
}


