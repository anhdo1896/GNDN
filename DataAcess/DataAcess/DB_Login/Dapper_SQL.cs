using Dapper;
using DataAccess;
using Entity;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using static DataAccess.Out_PUT;

namespace DataAccess
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

        public static List<ISCHECK_LOGIN_OUT>SELECT_ISCHECK_LOGIN_FAIL(int IDMA_DVIQLY, string USERNAME)
        {
            IDbConnection db = new SqlConnection(Common.ConnectionString);
            try
            {
                db.Open();
                string query = @"select ISCHECK_LOGIN, DATE_PASS from  DM_USER where IDMA_DVIQLY = @IDMA_DVIQLY and USERNAME = @USERNAME";
                 var ds = db.Query<ISCHECK_LOGIN_OUT>(query, new { IDMA_DVIQLY = @IDMA_DVIQLY, USERNAME = @USERNAME });
                db.Close();
                db.Dispose();
                return (List<ISCHECK_LOGIN_OUT>)ds;
            }
            catch
            {
                return null; ;
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
                var check = SELECT_ISCHECK_LOGIN_FAIL(IDMA_DVIQLY, USERNAME);
                int a = 0;
                if (check[0].ISCHECK_LOGIN != "" || check[0].ISCHECK_LOGIN != null)
                {
                    a = int.Parse(check[0].ISCHECK_LOGIN);
                }
                UPDATEISCHECK_MK(IDMA_DVIQLY, USERNAME, a + 1);
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

        public static List<Checklogin_USER> Checklogin(int IDMA_DVIQLY, string USERNAME, string passWord)
        {
            IDbConnection db = new SqlConnection(Common.ConnectionString);
            try
            {
                string pass = "";
                db.Open();
                string query = @"select IDMA_DVIQLY,USERNAME,PASSWORD from DM_USER where IDMA_DVIQLY = @IDMA_DVIQLY and  USERNAME = @USERNAME";
                var ds = db.Query<Checklogin_USER>(query, new {IDMA_DVIQLY = @IDMA_DVIQLY, USERNAME = @USERNAME });
                foreach(var item in ds)
                {
                    pass = item.PASSWORD;
                }
                if (pass == DM_USER.Encrypt(passWord))
                {
                    return (List<Checklogin_USER>)ds;
                }
                db.Close();
                db.Dispose();
                return null;
            }
            catch(Exception ex)
            {
                string loi = ex + "";
                return null;

            }
            finally
            {
                db.Close();
                db.Dispose();
            }
        }
        public static void updatePass_DMUSER(int IDMA_DVIQLY, string USERNAME, string PASSWORD)
        {
            IDbConnection db = new SqlConnection(Common.ConnectionString);
            try
            {
                db.Open();
                string query = @"update DM_USER set PASSWORD =  @PASSWORD, DATE_PASS = getdate() where IDMA_DVIQLY = @IDMA_DVIQLY and USERNAME = @USERNAME  ";
                db.Query(query, new { PASSWORD = PASSWORD, IDMA_DVIQLY = @IDMA_DVIQLY, USERNAME = @USERNAME });
                db.Close();
                db.Dispose();
            }
            catch
            {
                //string loi = ex + "";
            }
            finally
            {
                db.Close();
                db.Dispose();
            }
        }
    }
}
