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
    public class clTaiNon
    {
        private MSSqlHelper _DbHelper = new MSSqlHelper();
        public DataTable SELECT_ALL_DVIQLY(string pMA_DVIQLY)
        {
            DataTable dt = new DataTable();
            OracleConnection objConn = new OracleConnection(ConnectString.ConnectionString(pMA_DVIQLY));
            OracleCommand objCmd = new OracleCommand();
            try
            {
                objConn.Open();

                objCmd.Connection = objConn;
                objCmd.CommandText = "PKG_TRUYTHUNONTAI.SELECT_ALL_DVIQLY";
                objCmd.CommandType = CommandType.StoredProcedure;
                objCmd.Parameters.Add("pMA_DVIQLY", OracleType.VarChar).Value = pMA_DVIQLY;
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
        public DataTable SELECT_MANHOMGIA(string pMA_DVIQLY, string pMA_NHOM)
        {
            DataTable dt = new DataTable();
            OracleConnection objConn = new OracleConnection(ConnectString.ConnectionString(pMA_DVIQLY));
            OracleCommand objCmd = new OracleCommand();
            try
            {
                objConn.Open();
                objCmd.Connection = objConn;
                objCmd.CommandText = "PKG_TRUYTHUNONTAI.SELECT_MANHOMGIA";
                objCmd.Parameters.Add("pMA_NHOM", OracleType.VarChar).Value = pMA_NHOM;
                objCmd.CommandType = CommandType.StoredProcedure;
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
        public DataTable SELECT_MANHOM_DINHMUC(string pMA_DVIQLY, string pMA_KHANG)
        {
            DataTable dt = new DataTable();
            OracleConnection objConn = new OracleConnection(ConnectString.ConnectionString(pMA_DVIQLY));
            OracleCommand objCmd = new OracleCommand();
            try
            {
                objConn.Open();
                objCmd.Connection = objConn;
                objCmd.CommandText = "PKG_TRUYTHUNONTAI.SELECT_MANHOM_DINHMUC";
                objCmd.Parameters.Add("pMA_DVIQLY", OracleType.VarChar).Value = pMA_DVIQLY;
                objCmd.Parameters.Add("pMA_KHANG", OracleType.VarChar).Value = pMA_KHANG;
                objCmd.CommandType = CommandType.StoredProcedure;
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
        public DataTable SELECT_KH_NONTAI(string pMA_DVIQLY,string ma_khang ,int Ploai)
        {
            DataTable dt = new DataTable();
            OracleConnection objConn = new OracleConnection(ConnectString.ConnectionString(pMA_DVIQLY));
            OracleCommand objCmd = new OracleCommand();
            try
            {
                objConn.Open();
                objCmd.Connection = objConn;
                objCmd.CommandText = "PKG_TRUYTHUNONTAI.SELECT_KH_NONTAI";
                
                objCmd.Parameters.Add("pMA_DVIQLY", OracleType.VarChar).Value = pMA_DVIQLY;
                objCmd.Parameters.Add("pMA_KHANG", OracleType.VarChar).Value = ma_khang;
                objCmd.Parameters.Add("pLOAI", OracleType.VarChar).Value = Ploai+"";

                objCmd.CommandType = CommandType.StoredProcedure;
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
        public DataTable SELECT_TRUYTHU_MBA(string pMA_DVIQLY)
        {
            DataTable dt = new DataTable();
            OracleConnection objConn = new OracleConnection(ConnectString.ConnectionString(pMA_DVIQLY));
            OracleCommand objCmd = new OracleCommand();
            try
            {
                objConn.Open();
                objCmd.Connection = objConn;
                objCmd.CommandText = "PKG_TRUYTHUNONTAI.SELECT_TRUYTHU_MBA";
                objCmd.Parameters.Add("pMA_DVIQLY", OracleType.VarChar).Value = pMA_DVIQLY;
                objCmd.CommandType = CommandType.StoredProcedure;
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
        public DataTable SELECT_TRUYTHU_BYIDMBA(string pMA_DVIQLY, int pIDMBA)
        {
            DataTable dt = new DataTable();
            OracleConnection objConn = new OracleConnection(ConnectString.ConnectionString(pMA_DVIQLY));
            OracleCommand objCmd = new OracleCommand();
            try
            {
                objConn.Open();
                objCmd.Connection = objConn;
                objCmd.CommandText = "PKG_TRUYTHUNONTAI.SELECT_TRUYTHU_BYIDMBA";
                objCmd.Parameters.Add("pMA_DVIQLY", OracleType.VarChar).Value = pMA_DVIQLY;
                objCmd.Parameters.Add("pIDMBA", OracleType.VarChar).Value = pIDMBA;
                objCmd.CommandType = CommandType.StoredProcedure;
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
        public DataTable SELECT_TRUYTHU_BYMBA(string pMA_DVIQLY, int pIDMBA)
        {
            DataTable dt = new DataTable();
            OracleConnection objConn = new OracleConnection(ConnectString.ConnectionString(pMA_DVIQLY));
            OracleCommand objCmd = new OracleCommand();
            try
            {
                objConn.Open();
                objCmd.Connection = objConn;
                objCmd.CommandText = "PKG_TRUYTHUNONTAI.SELECT_TRUYTHU_BYMBA";
                objCmd.Parameters.Add("pIDMBA", OracleType.VarChar).Value = pIDMBA;
                objCmd.CommandType = CommandType.StoredProcedure;
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
        public void Insert_TRUYTHU_MBA(int pIDMBA, string pMA_KHANG, string pMA_DVIQLY, int pCSTIEUTHU, DateTime pNGAYTAO,decimal CS_TONTHAT)
        {
            DataTable dt = new DataTable();
            OracleConnection objConn = new OracleConnection(ConnectString.ConnectionString(pMA_DVIQLY));
            OracleCommand objCmd = new OracleCommand();
            try
            {
                objConn.Open();
                objCmd.Connection = objConn;
                objCmd.CommandText = "PKG_TRUYTHUNONTAI.INSERT_TRUYTHU_MBA";
                objCmd.CommandType = CommandType.StoredProcedure;
                objCmd.Parameters.Add("pIDMBA", OracleType.Number).Value = pIDMBA;
                objCmd.Parameters.Add("pMA_KHANG", OracleType.VarChar).Value = pMA_KHANG;
                objCmd.Parameters.Add("pMA_DVIQLY", OracleType.VarChar).Value = pMA_DVIQLY;
                objCmd.Parameters.Add("pCSTIEUTHU", OracleType.Number).Value = pCSTIEUTHU;
                objCmd.Parameters.Add("pCS_TONTHAT", OracleType.Number).Value = CS_TONTHAT;
                objCmd.Parameters.Add("pNGAYTAO", OracleType.DateTime).Value = pNGAYTAO;
                OracleDataReader objReader = objCmd.ExecuteReader();
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
        }
        public void Update_TRUYTHU_MBA(int pIDMBA, string pMA_KHANG, string pMA_DVIQLY, int pCSTIEUTHU, DateTime pNGAYTAO,decimal CS_TONTHAT)
        {
            DataTable dt = new DataTable();
            OracleConnection objConn = new OracleConnection(ConnectString.ConnectionString(pMA_DVIQLY));
            OracleCommand objCmd = new OracleCommand();
            try
            {
                objConn.Open();
                objCmd.Connection = objConn;
                objCmd.CommandText = "PKG_TRUYTHUNONTAI.UPDATE_TRUYTHU_MBA";
                objCmd.CommandType = CommandType.StoredProcedure;
                objCmd.Parameters.Add("pIDMBA", OracleType.Number).Value = pIDMBA;
                objCmd.Parameters.Add("pMA_KHANG", OracleType.VarChar).Value = pMA_KHANG;
                objCmd.Parameters.Add("pMA_DVIQLY", OracleType.VarChar).Value = pMA_DVIQLY;
                objCmd.Parameters.Add("pCSTIEUTHU", OracleType.Number).Value = pCSTIEUTHU;
                objCmd.Parameters.Add("pNGAYTAO", OracleType.DateTime).Value = pNGAYTAO;
                objCmd.Parameters.Add("pCS_TONTHAT", OracleType.Number).Value = CS_TONTHAT;
                OracleDataReader objReader = objCmd.ExecuteReader();
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
        }
        public void DELETE_TRUYTHU_MBA(string pMA_DVIQLY,int IDMBA)
        {
            DataTable dt = new DataTable();
            OracleConnection objConn = new OracleConnection(ConnectString.ConnectionString(pMA_DVIQLY));
            OracleCommand objCmd = new OracleCommand();
            try
            {
                objConn.Open();
                objCmd.Connection = objConn;
                objCmd.Parameters.Add("pIDMBA", OracleType.VarChar).Value = IDMBA;
                objCmd.CommandText = "PKG_TRUYTHUNONTAI.DELETE_TRUYTHU_MBA";
                objCmd.CommandType = CommandType.StoredProcedure;
                OracleDataReader objReader = objCmd.ExecuteReader();
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
        }
        public DataTable SELECT_TRUYTHU_NONTAI(string pMA_DVIQLY)
        {
            DataTable dt = new DataTable();
            OracleConnection objConn = new OracleConnection(ConnectString.ConnectionString(pMA_DVIQLY));
            OracleCommand objCmd = new OracleCommand();
            try
            {
                objConn.Open();
                objCmd.Connection = objConn;
                objCmd.CommandText = "PKG_TRUYTHUNONTAI.SELECT_TRUYTHU_NONTAI";
                objCmd.CommandType = CommandType.StoredProcedure;
                objCmd.Parameters.Add("pMA_DVIQLY", OracleType.VarChar).Value = pMA_DVIQLY;
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
        public void Insert_TRUYTHU_NONTAI(int pID, int pIDMBA, string pMA_DVIQLY, string pMA_KHANG, int pTHANG, int pNAM, decimal pTHOIGIANSD, string pMA_NHOM)
        {
            DataTable dt = new DataTable();
            OracleConnection objConn = new OracleConnection(ConnectString.ConnectionString(pMA_DVIQLY));
            OracleCommand objCmd = new OracleCommand();
            try
            {
                objConn.Open();
                objCmd.Connection = objConn;
                objCmd.CommandText = "PKG_TRUYTHUNONTAI.INSERT_TRUYTHU_NONTAI";
                objCmd.CommandType = CommandType.StoredProcedure;
                objCmd.Parameters.Add("pID", OracleType.Number).Value = pID;
                objCmd.Parameters.Add("pIDMBA", OracleType.Number).Value = pIDMBA;
                objCmd.Parameters.Add("pMA_DVIQLY", OracleType.VarChar).Value = pMA_DVIQLY;
                objCmd.Parameters.Add("pMA_KHANG", OracleType.VarChar).Value = pMA_KHANG;
                objCmd.Parameters.Add("pTHANG", OracleType.Number).Value = pTHANG;
                objCmd.Parameters.Add("pNAM", OracleType.Number).Value = pNAM;
                objCmd.Parameters.Add("pTHOIGIANSD", OracleType.Number).Value = pTHOIGIANSD;
                objCmd.Parameters.Add("pMA_NHOM", OracleType.VarChar).Value = pMA_NHOM;
                OracleDataReader objReader = objCmd.ExecuteReader();
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
        }
        public void Update_TRUYTHU_NONTAI(int pID, int pIDMBA, string pMA_DVIQLY, string pMA_KHANG, int pTHANG, int pNAM, decimal pTHOIGIANSD, string pMA_NHOM)
        {
            DataTable dt = new DataTable();
            OracleConnection objConn = new OracleConnection(ConnectString.ConnectionString(pMA_DVIQLY));
            OracleCommand objCmd = new OracleCommand();
            try
            {
                objConn.Open();
                objCmd.Connection = objConn;
                objCmd.CommandText = "PKG_TRUYTHUNONTAI.UPDATE_TRUYTHU_NONTAI";
                objCmd.CommandType = CommandType.StoredProcedure;
                objCmd.Parameters.Add("pID", OracleType.Number).Value = pID;
                objCmd.Parameters.Add("pIDMBA", OracleType.Number).Value = pIDMBA;
                objCmd.Parameters.Add("pMA_DVIQLY", OracleType.VarChar).Value = pMA_DVIQLY;
                objCmd.Parameters.Add("pMA_KHANG", OracleType.VarChar).Value = pMA_KHANG;
                objCmd.Parameters.Add("pTHANG", OracleType.Number).Value = pTHANG;
                objCmd.Parameters.Add("pNAM", OracleType.Number).Value = pNAM;
                objCmd.Parameters.Add("pTHOIGIANSD", OracleType.Number).Value = pTHOIGIANSD;
                objCmd.Parameters.Add("pMA_NHOM", OracleType.VarChar).Value = pMA_NHOM;
                OracleDataReader objReader = objCmd.ExecuteReader();
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
        }
        public void DELETE_TRUYTHU_NONTAI(int ID, string pMA_DVIQLY)
        {
            DataTable dt = new DataTable();
            OracleConnection objConn = new OracleConnection(ConnectString.ConnectionString(pMA_DVIQLY));
            OracleCommand objCmd = new OracleCommand();
            try
            {
                objConn.Open();
                objCmd.Connection = objConn;
                objCmd.CommandText = "PKG_TRUYTHUNONTAI.DELETE_TRUYTHU_NONTAI";
                objCmd.Parameters.Add("pID", OracleType.VarChar).Value = ID;
                objCmd.CommandType = CommandType.StoredProcedure;
                OracleDataReader objReader = objCmd.ExecuteReader();
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
        }


    }
}
