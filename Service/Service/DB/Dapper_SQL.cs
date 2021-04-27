using Dapper;
using DataAccess;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using static Service.DB.Out_PUT;

namespace Service.DB
{
    public static class Dapper_SQL
    {
        public static void ISCHECK_MK(int IDMA_DVIQLY, string USERNAME, int ISCHECK_MK)
        {
            IDbConnection db = new SqlConnection(Common.ConnectionString);
            try
            {
                db.Open();
                string query = @"update DM_USER set ISCHECK_MK =  @ISCHECK_MK,  ISCHECK_LOGIN = 0 where IDMA_DVIQLY = @IDMA_DVIQLY and USERNAME = @USERNAME  ";
                db.Query(query, new { ISCHECK_MK = @ISCHECK_MK, IDMA_DVIQLY = @IDMA_DVIQLY, USERNAME = @USERNAME });
                db.Close();
                db.Dispose();
            }
            catch(Exception ex)
            {
                string loi = ex + "";
            }
            finally
            {
                db.Close();
                db.Dispose();
            }
        }

        public static int SELECT_ISCHECK_LOGIN_FAIL(int IDMA_DVIQLY, string USERNAME)
        {
            IDbConnection db = new SqlConnection(Common.ConnectionString);
            int ISCHECK_LOGIN = 1;
            try
            {
                db.Open();
                string query = @"select ISCHECK_LOGIN from  DM_USER where IDMA_DVIQLY = @IDMA_DVIQLY and USERNAME = @USERNAME";
                 var ds = db.Query<ISCHECK_LOGIN_OUT>(query, new { IDMA_DVIQLY = @IDMA_DVIQLY, USERNAME = @USERNAME });
                string ISCHECK_LOGIN_String = "";
                foreach (var prop in ds)
                {
                    ISCHECK_LOGIN_String = prop.ISCHECK_LOGIN + "";
                }
                if (ISCHECK_LOGIN_String != "")
                { ISCHECK_LOGIN = int.Parse(ISCHECK_LOGIN_String) + 1; }
                db.Close();
                db.Dispose();
                return ISCHECK_LOGIN;
            }
            catch
            {
                return ISCHECK_LOGIN;
            }
            finally
            {
                db.Close();
                db.Dispose();
            }
        }
        public static void ISCHECK_LOGIN(int IDMA_DVIQLY, string USERNAME)
        {
            try
            {
                int check = SELECT_ISCHECK_LOGIN_FAIL(IDMA_DVIQLY, USERNAME);

                UPDATEISCHECK_MK(IDMA_DVIQLY, USERNAME, check);
            }
            catch
            {

            }
        }
        public static void UPDATEISCHECK_MK(int IDMA_DVIQLY, string USERNAME, int ISCHECK_LOGIN)
        {
            IDbConnection db = new SqlConnection(Common.ConnectionString);
            try
            {
                db.Open();
                string query = @"update DM_USER set ISCHECK_LOGIN =  @ISCHECK_LOGIN where IDMA_DVIQLY = @IDMA_DVIQLY and USERNAME = @USERNAME  ";
                db.Query(query, new { ISCHECK_LOGIN = @ISCHECK_LOGIN, IDMA_DVIQLY = @IDMA_DVIQLY, USERNAME = @USERNAME });
                db.Close();
                db.Dispose();
            }
            catch (Exception ex)
            {
                string loi = ex + "";
            }
            finally
            {
                db.Close();
                db.Dispose();
            }
        }
    }
}
