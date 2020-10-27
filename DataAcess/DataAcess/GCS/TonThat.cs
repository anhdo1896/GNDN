using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.OracleClient;
using System.Collections;
using System.Data.Common;
using Connection;

namespace DataAccess
{
    public class TonThat
    {
        private MSSqlHelper _DbHelper = new MSSqlHelper();

        public string INSERT_CTO_CHUANHOA(string pSOCONGTO, string pMA_DVIQLY, string pSOCOTMOI, string pLOAIHOM, string pTHUTUHOM, string pTHUTUPHA, string pTHUTULO, string pMANVIEN, string pANHHIENTRUONG, string pKINHDO, string pVIDO)
        {
            OracleConnection connection = new OracleConnection(ConnectString.ConnectionString("PA01"));
            connection.Open();
            bool result;
            try
            {
                OracleCommand cmd4 = new OracleCommand
                {
                    CommandText = "PTKH_MTB.PKG_CHUANHOA_CTO.INSERT_CTO_CHUANHOA",
                    CommandType = CommandType.StoredProcedure,
                    Connection = connection
                };
                cmd4.Parameters.Add("pSOCONGTO", OracleType.VarChar).Value = pSOCONGTO;
                cmd4.Parameters.Add("pMA_DVIQLY", OracleType.VarChar).Value = pMA_DVIQLY;
                cmd4.Parameters.Add("pSOCOTMOI", OracleType.VarChar).Value = pSOCOTMOI;
                cmd4.Parameters.Add("pLOAIHOM", OracleType.VarChar).Value = pLOAIHOM;
                cmd4.Parameters.Add("pTHUTUHOM", OracleType.VarChar).Value = pTHUTUHOM;
                cmd4.Parameters.Add("pTHUTUPHA", OracleType.VarChar).Value = pTHUTUPHA;
                cmd4.Parameters.Add("pTHUTULO", OracleType.VarChar).Value = pTHUTULO;
                cmd4.Parameters.Add("pMANVIEN", OracleType.VarChar).Value = pMANVIEN;
                cmd4.Parameters.Add("pANHHIENTRUONG", OracleType.VarChar).Value = pANHHIENTRUONG;
                cmd4.Parameters.Add("pKINHDO", OracleType.VarChar).Value = pKINHDO;
                cmd4.Parameters.Add("pVIDO", OracleType.VarChar).Value = pVIDO;
                cmd4.ExecuteNonQuery();

            }
            catch (Exception ex_623)
            {
                // result = false;
                return ex_623.Message;
            }
            finally
            {
                if (connection != null)
                {
                    if (connection.State == ConnectionState.Open)
                    {
                        connection.Close();
                    }
                    connection.Dispose();
                }
            }
            result = true;
            return result + "";
        }
        public DataTable DN_TK_ThucTeDonVi(int Ma_dviqly, int Thang, int Nam,int ThangN1,int NamN1, int ThangN2,int NamN2, int TuNgay,int DenNgay)
        {
            DbConnection connection = _DbHelper.CreateConnection(Common.ConnectionString);
            connection.Open();
            try
            {
                ArrayList para = new ArrayList();
                para.Add(_DbHelper.CreateParam("IDMA_DVIQLY", SqlDbType.Int, Ma_dviqly));
                para.Add(_DbHelper.CreateParam("ThangHT", SqlDbType.Int, Thang));
                para.Add(_DbHelper.CreateParam("NamHT", SqlDbType.Int, Nam));
                para.Add(_DbHelper.CreateParam("ThangN1", SqlDbType.Int, ThangN1));
                para.Add(_DbHelper.CreateParam("NamN1", SqlDbType.Int, NamN1));
                para.Add(_DbHelper.CreateParam("ThangN2", SqlDbType.Int, ThangN2));
                para.Add(_DbHelper.CreateParam("NamN2", SqlDbType.Int, NamN2));
                para.Add(_DbHelper.CreateParam("TuNgay", SqlDbType.Int, TuNgay));
                para.Add(_DbHelper.CreateParam("DenNgay", SqlDbType.Int, DenNgay));
                DataTable dt = _DbHelper.RunProcedureGetTable(connection, Common.DatabaseSchema + "[DN_TK_ThucTeDonVi]", para);
                return dt;
            }
            catch (Exception ex)
            {
                throw new Exception(String.Format("DN_TK_ThucTeDonVi: {0}", ex.Message));
            }
            finally
            {
                connection.Close();
            }

        }
        public DataTable DN_TK_ThucTeTCT(int Thang, int Nam, int ThangN1, int NamN1, int ThangN2, int NamN2, int TuNgay, int DenNgay)
        {
            DbConnection connection = _DbHelper.CreateConnection(Common.ConnectionString);
            connection.Open();
            try
            {
                ArrayList para = new ArrayList();
                para.Add(_DbHelper.CreateParam("ThangHT", SqlDbType.Int, Thang));
                para.Add(_DbHelper.CreateParam("NamHT", SqlDbType.Int, Nam));
                para.Add(_DbHelper.CreateParam("ThangN1", SqlDbType.Int, ThangN1));
                para.Add(_DbHelper.CreateParam("NamN1", SqlDbType.Int, NamN1));
                para.Add(_DbHelper.CreateParam("ThangN2", SqlDbType.Int, ThangN2));
                para.Add(_DbHelper.CreateParam("NamN2", SqlDbType.Int, NamN2));
                para.Add(_DbHelper.CreateParam("TuNgay", SqlDbType.Int, TuNgay));
                para.Add(_DbHelper.CreateParam("DenNgay", SqlDbType.Int, DenNgay));
                DataTable dt = _DbHelper.RunProcedureGetTable(connection, Common.DatabaseSchema + "[DN_TK_ThucTeTCT]", para);
                return dt;
            }
            catch (Exception ex)
            {
                throw new Exception(String.Format("DN_TK_ThucTeDonVi: {0}", ex.Message));
            }
            finally
            {
                connection.Close();
            }

        }
        public DataTable DN_TK_ThucTeDonVi_ByThangNam(int Ma_dviqly, int Thang, int Nam)
        {
            DbConnection connection = _DbHelper.CreateConnection(Common.ConnectionString);
            connection.Open();
            try
            {
                ArrayList para = new ArrayList();
                para.Add(_DbHelper.CreateParam("IDMA_DVIQLY", SqlDbType.Int, Ma_dviqly));
                para.Add(_DbHelper.CreateParam("Thang", SqlDbType.Int, Thang));
                para.Add(_DbHelper.CreateParam("Nam", SqlDbType.Int, Nam));
                DataTable dt = _DbHelper.RunProcedureGetTable(connection, Common.DatabaseSchema + "[DN_TK_ThucTeDonVi]", para);
                return dt;
            }
            catch (Exception ex)
            {
                throw new Exception(String.Format("DN_TK_ThucTeDonVi: {0}", ex.Message));
            }
            finally
            {
                connection.Close();
            }

        }
        public DataTable DN_TK_DNKeHoach(int Ma_dviqly, int Thang, int Nam, int Ngay)
        {
            DbConnection connection = _DbHelper.CreateConnection(Common.ConnectionString);
            connection.Open();
            try
            {
                ArrayList para = new ArrayList();
                para.Add(_DbHelper.CreateParam("IDMA_DVIQLY", SqlDbType.Int, Ma_dviqly));
                para.Add(_DbHelper.CreateParam("Thang", SqlDbType.Int, Thang));
                para.Add(_DbHelper.CreateParam("Nam", SqlDbType.Int, Nam));
                para.Add(_DbHelper.CreateParam("Ngay", SqlDbType.Int, Ngay));
                DataTable dt = _DbHelper.RunProcedureGetTable(connection, Common.DatabaseSchema + "[DN_TK_DNKeHoach]", para);
                return dt;
            }
            catch (Exception ex)
            {
                throw new Exception(String.Format("DN_TK_DNKeHoach: {0}", ex.Message));
            }
            finally
            {
                connection.Close();
            }

        }
        public DataTable Get_BCTT_TBACC(string pMA_DVIQLY, int pTHANG, int pNAM, string pLanBC, int LuyKe)
        {
            DataTable dt = new DataTable();
            OracleConnection objConn = new OracleConnection(ConnectString.ConnectionString(pMA_DVIQLY));
            OracleCommand objCmd = new OracleCommand();
            try
            {
                objConn.Open();
                objCmd.Connection = objConn;
                objCmd.CommandText = "PKG_NPCTTHAT.Get_BCTT_TBACC";
                objCmd.CommandType = CommandType.StoredProcedure;
                objCmd.Parameters.Add("pMA_DVIQLY", OracleType.VarChar).Value = pMA_DVIQLY;
                objCmd.Parameters.Add("pThang", OracleType.Number).Value = pTHANG;
                objCmd.Parameters.Add("pNam", OracleType.Number).Value = pNAM;
                objCmd.Parameters.Add("pLanBC", OracleType.VarChar).Value = pLanBC;
                objCmd.Parameters.Add("pLuyke", OracleType.Number).Value = LuyKe;
                objCmd.Parameters.Add("rs", OracleType.Cursor).Direction = ParameterDirection.Output;
                OracleDataReader objReader = objCmd.ExecuteReader();
                dt.Load(objReader);
                objConn.Close();
                objCmd.Dispose();
                objCmd = null;
            }

            catch (Exception ex)
            {
                System.Console.WriteLine("Exception: {0}", ex.ToString());
            }
            finally
            {
                objConn.Close();
                objConn.Dispose();
                objCmd = null;
            }
            return dt;

        }
        public DataTable Get_BCTT_LDD(string pMA_DVIQLY, int pTHANG, int pNAM, string pLanBC, int LuyKe)
        {
            DataTable dt = new DataTable();
            OracleConnection objConn = new OracleConnection(ConnectString.ConnectionString(pMA_DVIQLY));
            OracleCommand objCmd = new OracleCommand();
            try
            {
                objConn.Open();
                objCmd.Connection = objConn;
                objCmd.CommandText = " GNDN.PKG_NPCTTHAT.Get_BCTT_LDD";
                objCmd.CommandType = CommandType.StoredProcedure;
                objCmd.Parameters.Add("pMA_DVIQLY", OracleType.VarChar).Value = pMA_DVIQLY;
                objCmd.Parameters.Add("pThang", OracleType.Number).Value = pTHANG;
                objCmd.Parameters.Add("pNam", OracleType.Number).Value = pNAM;
                objCmd.Parameters.Add("pLanBC", OracleType.VarChar).Value = pLanBC;
                objCmd.Parameters.Add("pLuyke", OracleType.Number).Value = LuyKe;
                objCmd.Parameters.Add("rs", OracleType.Cursor).Direction = ParameterDirection.Output;
                OracleDataReader objReader = objCmd.ExecuteReader();
                dt.Load(objReader);
                objConn.Close();
                objCmd.Dispose();
                objCmd = null;
            }

            catch (Exception ex)
            {
                System.Console.WriteLine("Exception: {0}", ex.ToString());
            }
            finally
            {
                objConn.Close();
                objConn.Dispose();
                objCmd = null;
            }
            return dt;

        }
    }
}
