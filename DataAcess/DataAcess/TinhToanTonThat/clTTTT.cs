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
    public class clTTTT
    {
        public DataTable SELECT_TTTT_DN_KEHOACH(string pMA_DVIQLY, string pMA_TRAM)
        {
            DataTable dt = new DataTable();
            OracleConnection objConn = new OracleConnection(ConnectString.ConnectionString(pMA_DVIQLY));
            OracleCommand objCmd = new OracleCommand();
            try
            {
                objConn.Open();
                objCmd.Connection = objConn;
                objCmd.CommandText = "PKG_TTTT.SELECT_TTTT_DN_KEHOACH";
                objCmd.CommandType = CommandType.StoredProcedure;
                objCmd.Parameters.Add("pMA_DVILQY", OracleType.VarChar).Value = pMA_DVIQLY;
                objCmd.Parameters.Add("pMA_TRAM", OracleType.VarChar).Value = pMA_TRAM;
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
        public void Insert_TTTT_DN_KEHOACH(string pMA_DVIQLY, string pMA_TRAM, int pKEHOACH, int pTHANG, int pNAM, DateTime pNGAYTAO)
        {
            DataTable dt = new DataTable();
            OracleConnection objConn = new OracleConnection(ConnectString.ConnectionString(pMA_DVIQLY));
            OracleCommand objCmd = new OracleCommand();
            try
            {
                objConn.Open();
                objCmd.Connection = objConn;
                objCmd.CommandText = "PKG_TTTT.INSERT_TTTT_DN_KEHOACH";
                objCmd.CommandType = CommandType.StoredProcedure;
                objCmd.Parameters.Add("pMA_DVILQY", OracleType.VarChar).Value = pMA_DVIQLY;
                objCmd.Parameters.Add("pMA_TRAM", OracleType.VarChar).Value = pMA_TRAM;
                objCmd.Parameters.Add("pKEHOACH", OracleType.Number).Value = pKEHOACH;
                objCmd.Parameters.Add("pTHANG", OracleType.Number).Value = pTHANG;
                objCmd.Parameters.Add("pNAM", OracleType.Number).Value = pNAM;
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
        public void Update_TTTT_DN_KEHOACH(string pMA_DVIQLY, string pMA_TRAM, int pKEHOACH, int pTHANG, int pNAM)
        {
            DataTable dt = new DataTable();
            OracleConnection objConn = new OracleConnection(ConnectString.ConnectionString(pMA_DVIQLY));
            OracleCommand objCmd = new OracleCommand();
            try
            {
                objConn.Open();
                objCmd.Connection = objConn;
                objCmd.CommandText = "PKG_TTTT.UPDATE_TTTT_DN_KEHOACH";
                objCmd.CommandType = CommandType.StoredProcedure;
                objCmd.Parameters.Add("pMA_DVILQY", OracleType.VarChar).Value = pMA_DVIQLY;
                objCmd.Parameters.Add("pMA_TRAM", OracleType.VarChar).Value = pMA_TRAM;
                objCmd.Parameters.Add("pKEHOACH", OracleType.Number).Value = pKEHOACH;
                objCmd.Parameters.Add("pTHANG", OracleType.Number).Value = pTHANG;
                objCmd.Parameters.Add("pNAM", OracleType.Number).Value = pNAM;
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
        public void DELETE_TTTT_DN_KEHOACH(string pMA_DVIQLY, string pMA_TRAM, int pKEHOACH, int pTHANG, int pNAM)
        {
            DataTable dt = new DataTable();
            OracleConnection objConn = new OracleConnection(ConnectString.ConnectionString(pMA_DVIQLY));
            OracleCommand objCmd = new OracleCommand();
            try
            {
                objConn.Open();
                objCmd.Connection = objConn;
                objCmd.CommandText = "PKG_TTTT.DELETE_TTTT_DN_KEHOACH";
                objCmd.CommandType = CommandType.StoredProcedure;
                objCmd.Parameters.Add("pMA_DVILQY", OracleType.VarChar).Value = pMA_DVIQLY;
                objCmd.Parameters.Add("pMA_TRAM", OracleType.VarChar).Value = pMA_TRAM;
                objCmd.Parameters.Add("pKEHOACH", OracleType.Number).Value = pKEHOACH;
                objCmd.Parameters.Add("pTHANG", OracleType.Number).Value = pTHANG;
                objCmd.Parameters.Add("pNAM", OracleType.Number).Value = pNAM;
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

        public DataTable select_TTTT_TONTHATKYTHUAT_THANG(string pMA_DVIQLY, string pMATRAM, int pTHANG, int pNAM, int kieudulieu)
        {
            DataTable dt = new DataTable();
            OracleConnection objConn = new OracleConnection(ConnectString.ConnectionString(""));
            OracleCommand objCmd = new OracleCommand();
            try
            {
                objConn.Open();
                objCmd.Connection = objConn;
                objCmd.CommandText = "PKG_TTTT.select_TTTT_CHUKYTAI_THANG";
                objCmd.CommandType = CommandType.StoredProcedure;
                objCmd.Parameters.Add("pMA_DVIQLY", OracleType.VarChar).Value = pMA_DVIQLY;
                objCmd.Parameters.Add("pMATRAM", OracleType.VarChar).Value = pMATRAM;
                objCmd.Parameters.Add("pTHANG", OracleType.Number).Value = pTHANG;
                objCmd.Parameters.Add("pNAM", OracleType.Number).Value = pNAM;
                objCmd.Parameters.Add("pKIEUDULIEU", OracleType.Number).Value = kieudulieu;

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

        public DataTable SELECT_TTTT_TONTHATKYTHUAT_TUTHANG_DENTHANG(string pMA_DVIQLY, string pMATRAM, int pTHANG, int pNAM, int pTUNGAY, int pDENNGAY, int kieudulieu)
        {
            DataTable dt = new DataTable();
            OracleConnection objConn = new OracleConnection(ConnectString.ConnectionString(""));
            OracleCommand objCmd = new OracleCommand();
            try
            {
                objConn.Open();
                objCmd.Connection = objConn;
                objCmd.CommandText = "PKG_TTTT.select_TTTT_CHUKYTAI_TUNGAY_DENNGAY";
                objCmd.CommandType = CommandType.StoredProcedure;
                objCmd.Parameters.Add("pMA_DVIQLY", OracleType.VarChar).Value = pMA_DVIQLY;
                objCmd.Parameters.Add("pMATRAM", OracleType.VarChar).Value = pMATRAM;
                objCmd.Parameters.Add("pTHANG", OracleType.Number).Value = pTHANG;
                objCmd.Parameters.Add("pNAM", OracleType.Number).Value = pNAM;
                objCmd.Parameters.Add("pTUNGAY", OracleType.Number).Value = pTUNGAY;
                objCmd.Parameters.Add("pDENNGAY", OracleType.Number).Value = pDENNGAY;
                objCmd.Parameters.Add("pKIEUDULIEU", OracleType.Number).Value = kieudulieu;

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
        public void INSERT_TTTT_SLGNUT_CHUKY(string pMA_DVIQLY, string pMATRAM, string pMACOT, int pTHANG, int pNAM, decimal pSANLUONG, int pNGAY, int ChuKy)
        {
            DataTable dt = new DataTable();
            OracleConnection objConn = new OracleConnection(ConnectString.ConnectionString(pMA_DVIQLY));
            OracleCommand objCmd = new OracleCommand();
            try
            {
                objConn.Open();
                objCmd.Connection = objConn;
                objCmd.CommandText = "PKG_TTTT.INSERT_TTTT_SLGNUT_CHUKY";
                objCmd.CommandType = CommandType.StoredProcedure;
                objCmd.Parameters.Add("pMA_DVIQLY", OracleType.NVarChar).Value = pMA_DVIQLY;
                objCmd.Parameters.Add("pMATRAM", OracleType.VarChar).Value = pMATRAM;
                objCmd.Parameters.Add("pMACOT", OracleType.VarChar).Value = pMACOT;
                objCmd.Parameters.Add("pTHANG", OracleType.Number).Value = pTHANG;
                objCmd.Parameters.Add("pNAM", OracleType.Number).Value = pNAM;
                objCmd.Parameters.Add("pSANLUONG", OracleType.Number).Value = pSANLUONG;
                objCmd.Parameters.Add("pNGAY", OracleType.Number).Value = pNGAY;
                objCmd.Parameters.Add("pCHUKY", OracleType.Number).Value = ChuKy;
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
        public DataTable SELECT_TONTHAT_CHUKY(string pMA_DVIQLY, string pMATRAM, int pTHANG, int pNAM, int pNGAYHT, int pGIOHT, int pNGAYCHUKYSAU, int pCHUKYSAU, int KIEMTRA)
        {
            DataTable dt = new DataTable();
            OracleConnection objConn = new OracleConnection(ConnectString.ConnectionString(""));
            OracleCommand objCmd = new OracleCommand();
            try
            {
                objConn.Open();
                objCmd.Connection = objConn;
                objCmd.CommandText = "PKG_TTTT.SELECT_TONTHAT_CHUKY";
                objCmd.CommandType = CommandType.StoredProcedure;
                objCmd.Parameters.Add("pMA_DVIQLY", OracleType.VarChar).Value = pMA_DVIQLY;
                objCmd.Parameters.Add("pMATRAM", OracleType.VarChar).Value = pMATRAM;
                objCmd.Parameters.Add("pTHANG", OracleType.Number).Value = pTHANG;
                objCmd.Parameters.Add("pNAM", OracleType.Number).Value = pNAM;
                objCmd.Parameters.Add("pNGAYHT", OracleType.Number).Value = pNGAYHT;
                objCmd.Parameters.Add("pGIOHT", OracleType.Number).Value = pGIOHT;
                objCmd.Parameters.Add("pNGAYCHUKYSAU", OracleType.Number).Value = pNGAYCHUKYSAU;
                objCmd.Parameters.Add("pCHUKYSAU", OracleType.Number).Value = pCHUKYSAU;
                objCmd.Parameters.Add("pKIEMTRA", OracleType.Number).Value = KIEMTRA;
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
        public void INSERT_TTTT_CHUKYSLG_THANG(string pMA_DVIQLY, string pMATRAM, int pTHANG, int pNAM, int pNGAY, int pGIO, decimal pCS)
        {
            OracleConnection objConn = new OracleConnection(ConnectString.ConnectionString(pMA_DVIQLY));
            OracleCommand objCmd = new OracleCommand();
            try
            {
                objConn.Open();
                objCmd.Connection = objConn;
                objCmd.CommandText = "PKG_TTTT.INSERT_TTTT_CHUKYSLG_THANG"; objCmd.CommandType = CommandType.StoredProcedure;
                objCmd.Parameters.Add("pMA_DVIQLY", OracleType.VarChar).Value = pMA_DVIQLY;
                objCmd.Parameters.Add("pMATRAM", OracleType.VarChar).Value = pMATRAM;
                objCmd.Parameters.Add("pTHANG", OracleType.Number).Value = pTHANG;
                objCmd.Parameters.Add("pNAM", OracleType.Number).Value = pNAM;
                objCmd.Parameters.Add("pNGAY", OracleType.Number).Value = pNGAY;
                objCmd.Parameters.Add("pGIO", OracleType.Number).Value = pGIO;
                objCmd.Parameters.Add("pCS", OracleType.Number).Value = pCS;
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
        public DataTable Get_SLKhang(string pMA_DVIQLY, string pMakhang, int pTHANG, int pNAM)
        {
            DataTable dt = new DataTable();
            OracleConnection objConn = new OracleConnection(ConnectString.ConnectionString(""));
            OracleCommand objCmd = new OracleCommand();
            try
            {
                objConn.Open();
                objCmd.Connection = objConn;
                objCmd.CommandText = "PKG_NPCTTTT.Get_SLKhang";
                objCmd.CommandType = CommandType.StoredProcedure;
                objCmd.Parameters.Add("pMA_DVIQLY", OracleType.VarChar).Value = pMA_DVIQLY;
                objCmd.Parameters.Add("pMakhang", OracleType.VarChar).Value = pMakhang;
                objCmd.Parameters.Add("pThang", OracleType.Number).Value = pTHANG;
                objCmd.Parameters.Add("pNam", OracleType.Number).Value = pNAM;
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
        public DataTable Get_Khang_byMaTBA(string pMA_DVIQLY, string pMA_TRAM, int pTHANG, int pNAM)
        {
            DataTable dt = new DataTable();
            OracleConnection objConn = new OracleConnection(ConnectString.ConnectionString(""));
            OracleCommand objCmd = new OracleCommand();
            try
            {
                objConn.Open();
                objCmd.Connection = objConn;
                objCmd.CommandText = "PKG_NPCTTTT.Get_Khang_byMaTBA";
                objCmd.CommandType = CommandType.StoredProcedure;
                objCmd.Parameters.Add("pMA_DVIQLY", OracleType.VarChar).Value = pMA_DVIQLY;
                objCmd.Parameters.Add("p_MaTram", OracleType.VarChar).Value = pMA_TRAM;
                objCmd.Parameters.Add("pThang", OracleType.Number).Value = pTHANG;
                objCmd.Parameters.Add("pNam", OracleType.Number).Value = pNAM;
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
        public DataTable SELECT_TONTHATKD_BYTRAM(string pMA_DVIQLY, string pMA_TRAM, int pTHANG, int pNAM)
        {
            DataTable dt = new DataTable();
            OracleConnection objConn = new OracleConnection(ConnectString.ConnectionString(""));
            OracleCommand objCmd = new OracleCommand();
            try
            {
                objConn.Open();
                objCmd.Connection = objConn;
                objCmd.CommandText = "PKG_TTTT.SELECT_TONTHATKD_BYTRAM";
                objCmd.CommandType = CommandType.StoredProcedure;
                objCmd.Parameters.Add("pMA_DVIQLY", OracleType.VarChar).Value = pMA_DVIQLY;
                objCmd.Parameters.Add("pMA_TRAM", OracleType.VarChar).Value = pMA_TRAM;
                objCmd.Parameters.Add("pTHANG", OracleType.Number).Value = pTHANG;
                objCmd.Parameters.Add("pNAM", OracleType.Number).Value = pNAM;
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
        public DataTable SELECT_TRAM_HATHE(string pMA_DVIQLY)
        {
            DataTable dt = new DataTable();
            OracleConnection objConn = new OracleConnection(ConnectString.ConnectionString(""));
            OracleCommand objCmd = new OracleCommand();
            try
            {
                objConn.Open();
                objCmd.Connection = objConn;
                objCmd.CommandText = "PKG_TTTT.SELECT_TRAM_HATHE";
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
        public DataTable SELECT_TTTT_TONTHATKYTHUAT_THANG(int pID)
        {
            DataTable dt = new DataTable();
            OracleConnection objConn = new OracleConnection(ConnectString.ConnectionString(""));
            OracleCommand objCmd = new OracleCommand();
            try
            {
                objConn.Open();
                objCmd.Connection = objConn;
                objCmd.CommandText = "PKG_TTTT.SELECT_TTTT_TONTHATKYTHUAT_THANG";
                objCmd.CommandType = CommandType.StoredProcedure;
                objCmd.Parameters.Add("ID", OracleType.Number).Value = pID;
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
        public void Delete_TTTT_TRAM_CHUYKYTINH(string pMA_DVIQLY, string pMATRAM, int pTHANG, int pNAM)
        {
            DataTable dt = new DataTable();
            OracleConnection objConn = new OracleConnection(ConnectString.ConnectionString(pMA_DVIQLY));
            OracleCommand objCmd = new OracleCommand();
            try
            {
                objConn.Open();
                objCmd.Connection = objConn;
                objCmd.CommandText = "PKG_TTTT.Delete_TTTT_TRAM_CHUYKYTINH";
                objCmd.CommandType = CommandType.StoredProcedure;
                objCmd.Parameters.Add("pMA_DVIQLY", OracleType.NVarChar).Value = pMA_DVIQLY;
                objCmd.Parameters.Add("pMATRAM", OracleType.VarChar).Value = pMATRAM;
                objCmd.Parameters.Add("pTHANG", OracleType.Number).Value = pTHANG;
                objCmd.Parameters.Add("pNAM", OracleType.Number).Value = pNAM;
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
        public void Insert_TTTT_TONTHATKYTHUAT_THANG(int pID, string pMA_DVIQLY, string pMATRAM, int pTHANG, int pNAM, decimal pTONTHAT, DateTime pNGAYTAO, int pNGAY, int ChuKy)
        {
            DataTable dt = new DataTable();
            OracleConnection objConn = new OracleConnection(ConnectString.ConnectionString(pMA_DVIQLY));
            OracleCommand objCmd = new OracleCommand();
            try
            {
                objConn.Open();
                objCmd.Connection = objConn;
                objCmd.CommandText = "PKG_TTTT.INSERT_TTTT_TONTHATKYTHUAT_THANG";
                objCmd.CommandType = CommandType.StoredProcedure;
                objCmd.Parameters.Add("pID", OracleType.Number).Value = pID;
                objCmd.Parameters.Add("pMA_DVIQLY", OracleType.NVarChar).Value = pMA_DVIQLY;
                objCmd.Parameters.Add("pMATRAM", OracleType.VarChar).Value = pMATRAM;
                objCmd.Parameters.Add("pTHANG", OracleType.Number).Value = pTHANG;
                objCmd.Parameters.Add("pNAM", OracleType.Number).Value = pNAM;
                objCmd.Parameters.Add("pTONTHAT", OracleType.Number).Value = pTONTHAT;
                objCmd.Parameters.Add("pNGAYTAO", OracleType.DateTime).Value = pNGAYTAO;
                objCmd.Parameters.Add("pNGAY", OracleType.Number).Value = pNGAY;
                objCmd.Parameters.Add("pCHUKY", OracleType.Number).Value = ChuKy;
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
        public void Update_TTTT_TONTHATKYTHUAT_THANG(int pID, string pMA_DVIQLY, string pMATRAM, int pTHANG, int pNAM, int pTONTHAT, DateTime pNGAYTAO)
        {
            DataTable dt = new DataTable();
            OracleConnection objConn = new OracleConnection(ConnectString.ConnectionString(pMA_DVIQLY));
            OracleCommand objCmd = new OracleCommand();
            try
            {
                objConn.Open();
                objCmd.Connection = objConn;
                objCmd.CommandText = "PKG_TTTT.UPDATE_TTTT_TONTHATKYTHUAT_THANG";
                objCmd.CommandType = CommandType.StoredProcedure;
                objCmd.Parameters.Add("ID", OracleType.Number).Value = pID;
                objCmd.Parameters.Add("MA_DVIQLY", OracleType.NVarChar).Value = pMA_DVIQLY;
                objCmd.Parameters.Add("MATRAM", OracleType.VarChar).Value = pMATRAM;
                objCmd.Parameters.Add("THANG", OracleType.Number).Value = pTHANG;
                objCmd.Parameters.Add("NAM", OracleType.Number).Value = pNAM;
                objCmd.Parameters.Add("TONTHAT", OracleType.Number).Value = pTONTHAT;
                objCmd.Parameters.Add("NGAYTAO", OracleType.DateTime).Value = pNGAYTAO;
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
        public void DELETE_TTTT_TONTHATKYTHUAT_THANG(int pID)
        {
            DataTable dt = new DataTable();
            OracleConnection objConn = new OracleConnection(ConnectString.ConnectionString(""));
            OracleCommand objCmd = new OracleCommand();
            try
            {
                objConn.Open();
                objCmd.Connection = objConn;
                objCmd.CommandText = "PKG_TTTT.DELETE_TTTT_TONTHATKYTHUAT_THANG";
                objCmd.CommandType = CommandType.StoredProcedure;
                objCmd.Parameters.Add("ID", OracleType.Number).Value = pID;
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

        public DataTable TTTT_SELECT_SLG_DUONGDAY_TRAM(string pMA_DVIQLY, string pMATRAM, int pTHANG, int pNAM, int Ngay, int Gio)
        {
            DataTable dt = new DataTable(); OracleConnection objConn = new OracleConnection(ConnectString.ConnectionString(pMA_DVIQLY));
            OracleCommand objCmd = new OracleCommand();
            try
            {
                objConn.Open();
                objCmd.Connection = objConn;
                objCmd.CommandText = "PKG_TTTT.TTTT_SELECT_SLG_DUONGDAY_TRAM";
                objCmd.CommandType = CommandType.StoredProcedure;
                objCmd.Parameters.Add("pMATRAM", OracleType.VarChar).Value = pMATRAM;
                objCmd.Parameters.Add("pMA_DVIQLY", OracleType.VarChar).Value = pMA_DVIQLY;
                objCmd.Parameters.Add("pTHANG", OracleType.Number).Value = pTHANG;
                objCmd.Parameters.Add("pNAM", OracleType.Number).Value = pNAM;
                objCmd.Parameters.Add("pNGAY", OracleType.Number).Value = Ngay;
                objCmd.Parameters.Add("pGIO", OracleType.Number).Value = Gio;
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
        public void DELETE_TTTT_DM_LOAIDUONGDAY(int PID)
        {
            OracleConnection objConn = new OracleConnection(ConnectString.ConnectionString(""));
            OracleCommand objCmd = new OracleCommand();
            try
            {
                objConn.Open();
                objCmd.Connection = objConn;
                objCmd.CommandText = "PKG_TTTT.DELETE_TTTT_DM_LOAIDUONGDAY"; objCmd.CommandType = CommandType.StoredProcedure;
                objCmd.Parameters.Add("pID", OracleType.Number).Value = PID;

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
        public void DELETE_TTTT_DUONGDAYTRAM_BYTRAM(string pMATRAM)
        {
            OracleConnection objConn = new OracleConnection(ConnectString.ConnectionString(""));
            OracleCommand objCmd = new OracleCommand();
            try
            {
                objConn.Open();
                objCmd.Connection = objConn;
                objCmd.CommandText = "PKG_TTTT.DELETE_TTTT_DUONGDAYTRAM_BYTRAM";
                objCmd.CommandType = CommandType.StoredProcedure;
                objCmd.Parameters.Add("pMATRAM", OracleType.VarChar).Value = pMATRAM;

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
        public void DELETE_TTTT_DUONGDAY_TRAM(int PID)
        {
            OracleConnection objConn = new OracleConnection(ConnectString.ConnectionString(""));
            OracleCommand objCmd = new OracleCommand();
            try
            {
                objConn.Open();
                objCmd.Connection = objConn;
                objCmd.CommandText = "PKG_TTTT.DELETE_TTTT_DUONGDAY_TRAM"; objCmd.CommandType = CommandType.StoredProcedure;
                objCmd.Parameters.Add("pID", OracleType.Number).Value = PID;

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
        public void INSERT_TTTT_DM_LOAIDUONGDAY(int PID, string pMA_DVIQLY, string PMALOAIDAY, int PLOAIDAY, int PDIENTROSUAT, DateTime PNGAYTAO, int PNGUOITAO)
        {
            OracleConnection objConn = new OracleConnection(ConnectString.ConnectionString(pMA_DVIQLY));
            OracleCommand objCmd = new OracleCommand();
            try
            {
                objConn.Open();
                objCmd.Connection = objConn;
                objCmd.CommandText = "PKG_TTTT.INSERT_TTTT_DM_LOAIDUONGDAY"; objCmd.CommandType = CommandType.StoredProcedure;
                objCmd.Parameters.Add("pID", OracleType.Number).Value = PID;
                objCmd.Parameters.Add("pMA_DVIQLY", OracleType.VarChar).Value = pMA_DVIQLY;
                objCmd.Parameters.Add("pMALOAIDAY", OracleType.VarChar).Value = PMALOAIDAY;
                objCmd.Parameters.Add("pLOAIDAY", OracleType.Number).Value = PLOAIDAY;
                objCmd.Parameters.Add("pDIENTROSUAT", OracleType.Number).Value = PDIENTROSUAT;
                objCmd.Parameters.Add("pNGAYTAO", OracleType.DateTime).Value = PNGAYTAO; objCmd.Parameters.Add("pNGUOITAO", OracleType.Number).Value = PNGUOITAO;

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
        public void INSERT_TTTT_DUONGDAY_TRAM(int PID, string PMATRAM, string PDIEMDAU, string PDIEMCUOI, string PIDLOAIDAY, DateTime PNGAYTAO, int PNGUOITAO, string pMA_DVIQLY, decimal pHESOCONGSUAT, decimal pCHIEUDAI, decimal pTongDienAP)
        {
            OracleConnection objConn = new OracleConnection(ConnectString.ConnectionString(pMA_DVIQLY));
            OracleCommand objCmd = new OracleCommand();
            try
            {
                objConn.Open();
                objCmd.Connection = objConn;
                objCmd.CommandText = "PKG_TTTT.INSERT_TTTT_DUONGDAY_TRAM"; objCmd.CommandType = CommandType.StoredProcedure;
                objCmd.Parameters.Add("pID", OracleType.Number).Value = PID;
                objCmd.Parameters.Add("pMATRAM", OracleType.VarChar).Value = PMATRAM;
                objCmd.Parameters.Add("pDIEMDAU", OracleType.VarChar).Value = PDIEMDAU;
                objCmd.Parameters.Add("pDIEMCUOI", OracleType.VarChar).Value = PDIEMCUOI;
                objCmd.Parameters.Add("pIDLOAIDAY", OracleType.VarChar).Value = PIDLOAIDAY;
                objCmd.Parameters.Add("pNGAYTAO", OracleType.DateTime).Value = PNGAYTAO; objCmd.Parameters.Add("pNGUOITAO", OracleType.Number).Value = PNGUOITAO;
                objCmd.Parameters.Add("pMA_DVIQLY", OracleType.VarChar).Value = pMA_DVIQLY;
                objCmd.Parameters.Add("pHESOCONGSUAT", OracleType.Number).Value = pHESOCONGSUAT;
                objCmd.Parameters.Add("pCHIEUDAI", OracleType.Number).Value = pCHIEUDAI;
                objCmd.Parameters.Add("pTONGDIENAP", OracleType.Number).Value = pTongDienAP;
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
        public DataTable SELECT_ALLDUONGDAY(string pMA_DVIQLY)
        {
            DataTable dt = new DataTable(); OracleConnection objConn = new OracleConnection(ConnectString.ConnectionString(pMA_DVIQLY));
            OracleCommand objCmd = new OracleCommand();
            try
            {
                objConn.Open();
                objCmd.Connection = objConn;
                objCmd.CommandText = "PKG_TTTT.SELECT_ALLDUONGDAY"; objCmd.CommandType = CommandType.StoredProcedure;
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
        public DataTable SELECT_TTTT_DM_LOAIDUONGDAY(int PID)
        {
            DataTable dt = new DataTable(); OracleConnection objConn = new OracleConnection(ConnectString.ConnectionString(""));
            OracleCommand objCmd = new OracleCommand();
            try
            {
                objConn.Open();
                objCmd.Connection = objConn;
                objCmd.CommandText = "PKG_TTTT.SELECT_TTTT_DM_LOAIDUONGDAY"; objCmd.CommandType = CommandType.StoredProcedure;
                objCmd.Parameters.Add("pID", OracleType.Number).Value = PID;
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
        public DataTable SELECT_TTTT_DUONGDAY_TRAM(int PID)
        {
            DataTable dt = new DataTable(); OracleConnection objConn = new OracleConnection(ConnectString.ConnectionString(""));
            OracleCommand objCmd = new OracleCommand();
            try
            {
                objConn.Open();
                objCmd.Connection = objConn;
                objCmd.CommandText = "PKG_TTTT.SELECT_TTTT_DUONGDAY_TRAM"; objCmd.CommandType = CommandType.StoredProcedure;
                objCmd.Parameters.Add("pID", OracleType.Number).Value = PID;
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
        public DataTable TTTT_DM_LOAIDUONGDAY_CHECKNAME(int PID, string pMA_DVIQLY, string PMALOAIDAY)
        {
            DataTable dt = new DataTable(); OracleConnection objConn = new OracleConnection(ConnectString.ConnectionString(pMA_DVIQLY));
            OracleCommand objCmd = new OracleCommand();
            try
            {
                objConn.Open();
                objCmd.Connection = objConn;
                objCmd.CommandText = "PKG_TTTT.TTTT_DM_LOAIDUONGDAY_CHECKNAME"; objCmd.CommandType = CommandType.StoredProcedure;
                objCmd.Parameters.Add("pID", OracleType.Number).Value = PID;
                objCmd.Parameters.Add("pMA_DVIQLY", OracleType.VarChar).Value = pMA_DVIQLY;
                objCmd.Parameters.Add("pMALOAIDAY", OracleType.VarChar).Value = PMALOAIDAY;
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
        public void UPDATE_TTTT_DM_LOAIDUONGDAY(int PID, string pMA_DVIQLY, string PMALOAIDAY, int PLOAIDAY, int PDIENTROSUAT, DateTime PNGAYTAO, int PNGUOITAO)
        {
            OracleConnection objConn = new OracleConnection(ConnectString.ConnectionString(pMA_DVIQLY));
            OracleCommand objCmd = new OracleCommand();
            try
            {
                objConn.Open();
                objCmd.Connection = objConn;
                objCmd.CommandText = "PKG_TTTT.UPDATE_TTTT_DM_LOAIDUONGDAY"; objCmd.CommandType = CommandType.StoredProcedure;
                objCmd.Parameters.Add("pID", OracleType.Number).Value = PID;
                objCmd.Parameters.Add("pMA_DVIQLY", OracleType.VarChar).Value = pMA_DVIQLY;
                objCmd.Parameters.Add("pMALOAIDAY", OracleType.VarChar).Value = PMALOAIDAY;
                objCmd.Parameters.Add("pLOAIDAY", OracleType.Number).Value = PLOAIDAY;
                objCmd.Parameters.Add("pDIENTROSUAT", OracleType.Number).Value = PDIENTROSUAT;
                objCmd.Parameters.Add("pNGAYTAO", OracleType.DateTime).Value = PNGAYTAO; objCmd.Parameters.Add("pNGUOITAO", OracleType.Number).Value = PNGUOITAO;

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
        public void UPDATE_TTTT_DUONGDAY_TRAM(int PID, string PMATRAM, string PDIEMDAU, string PDIEMCUOI, int PIDLOAIDAY, DateTime PNGAYTAO, int PNGUOITAO, string pMA_DVIQLY, int PHESOCONGSUAT)
        {
            OracleConnection objConn = new OracleConnection(ConnectString.ConnectionString(pMA_DVIQLY));
            OracleCommand objCmd = new OracleCommand();
            try
            {
                objConn.Open();
                objCmd.Connection = objConn;
                objCmd.CommandText = "PKG_TTTT.UPDATE_TTTT_DUONGDAY_TRAM"; objCmd.CommandType = CommandType.StoredProcedure;
                objCmd.Parameters.Add("pID", OracleType.Number).Value = PID;
                objCmd.Parameters.Add("pMATRAM", OracleType.VarChar).Value = PMATRAM;
                objCmd.Parameters.Add("pDIEMDAU", OracleType.VarChar).Value = PDIEMDAU;
                objCmd.Parameters.Add("pDIEMCUOI", OracleType.VarChar).Value = PDIEMCUOI;
                objCmd.Parameters.Add("pIDLOAIDAY", OracleType.Number).Value = PIDLOAIDAY;
                objCmd.Parameters.Add("pNGAYTAO", OracleType.DateTime).Value = PNGAYTAO; objCmd.Parameters.Add("pNGUOITAO", OracleType.Number).Value = PNGUOITAO;
                objCmd.Parameters.Add("pMA_DVIQLY", OracleType.VarChar).Value = pMA_DVIQLY;
                objCmd.Parameters.Add("pHESOCONGSUAT", OracleType.Number).Value = PHESOCONGSUAT;

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


        public DataTable SELECT_TTTT_DM_LOAIDUONGDAY(int pID, string pMA_DVIQLY)
        {
            DataTable dt = new DataTable();
            OracleConnection objConn = new OracleConnection(ConnectString.ConnectionString(pMA_DVIQLY));
            OracleCommand objCmd = new OracleCommand();
            try
            {
                objConn.Open();
                objCmd.Connection = objConn;
                objCmd.CommandText = "PKG_TTTT.SELECT_TTTT_DM_LOAIDUONGDAY";
                objCmd.CommandType = CommandType.StoredProcedure;
                objCmd.Parameters.Add("pID", OracleType.Number).Value = pID;
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
        public void Insert_TTTT_DM_LOAIDUONGDAY(int pID, string pMA_DVIQLY, string pMALOAIDAY, string pTENLOAIDAY, int pLOAIDAY, decimal pDIENTROSUAT, DateTime pNGAYTAO, int pNGUOITAO)
        {
            DataTable dt = new DataTable();
            OracleConnection objConn = new OracleConnection(ConnectString.ConnectionString(pMA_DVIQLY));
            OracleCommand objCmd = new OracleCommand();
            try
            {
                objConn.Open();
                objCmd.Connection = objConn;
                objCmd.CommandText = "PKG_TTTT.INSERT_TTTT_DM_LOAIDUONGDAY";
                objCmd.CommandType = CommandType.StoredProcedure;
                objCmd.Parameters.Add("pID", OracleType.Number).Value = pID;
                objCmd.Parameters.Add("pMA_DVIQLY", OracleType.VarChar).Value = pMA_DVIQLY;
                objCmd.Parameters.Add("pMALOAIDAY", OracleType.VarChar).Value = pMALOAIDAY;
                objCmd.Parameters.Add("pTENLOAIDAY", OracleType.NVarChar).Value = pTENLOAIDAY;
                objCmd.Parameters.Add("pLOAIDAY", OracleType.Number).Value = pLOAIDAY;
                objCmd.Parameters.Add("pDIENTROSUAT", OracleType.Number).Value = pDIENTROSUAT;
                objCmd.Parameters.Add("pNGAYTAO", OracleType.DateTime).Value = pNGAYTAO;
                objCmd.Parameters.Add("pNGUOITAO", OracleType.Number).Value = pNGUOITAO;
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
        public void Update_TTTT_DM_LOAIDUONGDAY(int pID, string pMA_DVIQLY, string pMALOAIDAY, string pTENLOAIDAY, int pLOAIDAY, decimal pDIENTROSUAT, DateTime pNGAYTAO, int pNGUOITAO)
        {
            DataTable dt = new DataTable();
            OracleConnection objConn = new OracleConnection(ConnectString.ConnectionString(pMA_DVIQLY));
            OracleCommand objCmd = new OracleCommand();
            try
            {
                objConn.Open();
                objCmd.Connection = objConn;
                objCmd.CommandText = "PKG_TTTT.UPDATE_TTTT_DM_LOAIDUONGDAY";
                objCmd.CommandType = CommandType.StoredProcedure;
                objCmd.Parameters.Add("pID", OracleType.Number).Value = pID;
                objCmd.Parameters.Add("pMA_DVIQLY", OracleType.VarChar).Value = pMA_DVIQLY;
                objCmd.Parameters.Add("pMALOAIDAY", OracleType.VarChar).Value = pMALOAIDAY;
                objCmd.Parameters.Add("pTENLOAIDAY", OracleType.NVarChar).Value = pTENLOAIDAY;
                objCmd.Parameters.Add("pLOAIDAY", OracleType.Number).Value = pLOAIDAY;
                objCmd.Parameters.Add("pDIENTROSUAT", OracleType.Number).Value = pDIENTROSUAT;
                objCmd.Parameters.Add("pNGAYTAO", OracleType.DateTime).Value = pNGAYTAO;
                objCmd.Parameters.Add("pNGUOITAO", OracleType.Number).Value = pNGUOITAO;
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
        public void DELETE_TTTT_DM_LOAIDUONGDAY(int pID, string pMA_DVIQLY)
        {
            DataTable dt = new DataTable();
            OracleConnection objConn = new OracleConnection(ConnectString.ConnectionString(pMA_DVIQLY));
            OracleCommand objCmd = new OracleCommand();
            try
            {
                objConn.Open();
                objCmd.Connection = objConn;
                objCmd.CommandText = "PKG_TTTT.DELETE_TTTT_DM_LOAIDUONGDAY";
                objCmd.CommandType = CommandType.StoredProcedure;
                objCmd.Parameters.Add("pID", OracleType.Number).Value = pID;
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
        public DataTable GET_TTTT_QUANLYCAD(string pMA_DVILQY)
        {
            DataTable dt = new DataTable(); OracleConnection objConn = new OracleConnection(ConnectString.ConnectionString(""));
            OracleCommand objCmd = new OracleCommand();
            try
            {
                objConn.Open();
                objCmd.Connection = objConn;
                objCmd.CommandText = "PKG_TTTT.GET_TTTT_QUANLYCAD"; objCmd.CommandType = CommandType.StoredProcedure;
                objCmd.Parameters.Add("pMA_DVILQY", OracleType.VarChar).Value = pMA_DVILQY;
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
        public void INSERT_TTTT_QUANLYCAD(string pMA_DVIQLY, string pMA_TRAM, string pDiaChi)
        {
            DataTable dt = new DataTable();
            OracleConnection objConn = new OracleConnection(ConnectString.ConnectionString(pMA_DVIQLY));
            OracleCommand objCmd = new OracleCommand();
            try
            {
                objConn.Open();
                objCmd.Connection = objConn;
                objCmd.CommandText = "PTKH_MTB.SP_INSERT_TTTT_QUANLYCAD";
                objCmd.CommandType = CommandType.StoredProcedure;
                objCmd.Parameters.Add("pMA_DVIQLY", OracleType.VarChar).Value = pMA_DVIQLY;
                objCmd.Parameters.Add("pMA_TRAM", OracleType.VarChar).Value = pMA_TRAM;
                objCmd.Parameters.Add("pDIACHI", OracleType.NVarChar).Value = pDiaChi;
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
        public void DELETE_TTTT_QUANLYCAD_MATRAM(string pMA_DVIQLY, string pMA_TRAM)
        {
            DataTable dt = new DataTable();
            OracleConnection objConn = new OracleConnection(ConnectString.ConnectionString(pMA_DVIQLY));
            OracleCommand objCmd = new OracleCommand();
            try
            {
                objConn.Open();
                objCmd.Connection = objConn;
                objCmd.CommandText = "PKG_TTTT_CTT.DELETE_TTTT_QUANLYCAD_MATRAM";
                objCmd.CommandType = CommandType.StoredProcedure;
                objCmd.Parameters.Add("pMA_DVIQLY", OracleType.VarChar).Value = pMA_DVIQLY;
                objCmd.Parameters.Add("pMA_TRAM", OracleType.VarChar).Value = pMA_TRAM;
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
        public DataTable CHECK_TTTT_QUANLYCAD_MATRAM(string pMA_DVIQLY, string pMA_TRAM)
        {
            DataTable dt = new DataTable(); OracleConnection objConn = new OracleConnection(ConnectString.ConnectionString(pMA_DVIQLY));
            OracleCommand objCmd = new OracleCommand();
            try
            {
                objConn.Open();
                objCmd.Connection = objConn;
                objCmd.CommandText = "PKG_TTTT_CTT.CHECK_TTTT_QUANLYCAD_MATRAM"; objCmd.CommandType = CommandType.StoredProcedure;
                objCmd.Parameters.Add("pMA_DVIQLY", OracleType.VarChar).Value = pMA_DVIQLY;
                objCmd.Parameters.Add("pMA_TRAM", OracleType.VarChar).Value = pMA_TRAM;
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
        public void UPDATE_TTTT_QUANLYCAD_MATRAM(string pMA_DVIQLY, string pMA_TRAM, string pDIACHI)
        {
            DataTable dt = new DataTable();
            OracleConnection objConn = new OracleConnection(ConnectString.ConnectionString(pMA_DVIQLY));
            OracleCommand objCmd = new OracleCommand();
            try
            {
                objConn.Open();
                objCmd.Connection = objConn;
                objCmd.CommandText = "PKG_TTTT.UPDATE_TTTT_QUANLYCAD_MATRAM";
                objCmd.CommandType = CommandType.StoredProcedure;
                objCmd.Parameters.Add("pMA_DVIQLY", OracleType.VarChar).Value = pMA_DVIQLY;
                objCmd.Parameters.Add("pMA_TRAM", OracleType.VarChar).Value = pMA_TRAM;
                objCmd.Parameters.Add("pDIACHI", OracleType.NVarChar).Value = pDIACHI;
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

        public void INSERT_TTTT_TRAM_UUTIEN(string pMA_DVIQLY, string pMA_TRAM)
        {
            DataTable dt = new DataTable();
            OracleConnection objConn = new OracleConnection(ConnectString.ConnectionString(pMA_DVIQLY));
            OracleCommand objCmd = new OracleCommand();
            try
            {
                objConn.Open();
                objCmd.Connection = objConn;
                objCmd.CommandText = "PKG_TTTT_CTT.INSERT_TTTT_TRAM_UUTIEN";
                objCmd.CommandType = CommandType.StoredProcedure;
                objCmd.Parameters.Add("pMA_DVIQLY", OracleType.VarChar).Value = pMA_DVIQLY;
                objCmd.Parameters.Add("pMA_TRAM", OracleType.VarChar).Value = pMA_TRAM;
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
        public void DELETE_TTTT_TRAM_UUTIEN(string pMA_DVIQLY, string pMA_TRAM)
        {
            DataTable dt = new DataTable();
            OracleConnection objConn = new OracleConnection(ConnectString.ConnectionString(pMA_DVIQLY));
            OracleCommand objCmd = new OracleCommand();
            try
            {
                objConn.Open();
                objCmd.Connection = objConn;
                objCmd.CommandText = "PKG_TTTT_CTT.DELETE_TTTT_TRAM_UUTIEN";
                objCmd.CommandType = CommandType.StoredProcedure;
                objCmd.Parameters.Add("pMA_DVIQLY", OracleType.VarChar).Value = pMA_DVIQLY;
                objCmd.Parameters.Add("pMA_TRAM", OracleType.VarChar).Value = pMA_TRAM;
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
        public DataTable SELECT_TTTT_TRAM_UUTIEN(string pMA_DVIQLY)
        {
            DataTable dt = new DataTable();
            OracleConnection objConn = new OracleConnection(ConnectString.ConnectionString(""));
            OracleCommand objCmd = new OracleCommand();
            try
            {
                objConn.Open();
                objCmd.Connection = objConn;
                objCmd.CommandText = "PKG_TTTT_CTT.SELECT_TTTT_TRAM_UUTIEN";
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
        public DataTable SELECT_TRAM(string pMA_DVIQLY)
        {
            DataTable dt = new DataTable();
            OracleConnection objConn = new OracleConnection(ConnectString.ConnectionString(""));
            OracleCommand objCmd = new OracleCommand();
            try
            {
                objConn.Open();
                objCmd.Connection = objConn;
                objCmd.CommandText = "PKG_TTTT_CTT.SELECT_TTTT_TRAM";
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
        public DataTable CHECK_TTTT_TRAM_UUTIEN(string pMA_DVIQLY, string pMA_TRAM)
        {
            DataTable dt = new DataTable(); OracleConnection objConn = new OracleConnection(ConnectString.ConnectionString(pMA_DVIQLY));
            OracleCommand objCmd = new OracleCommand();
            try
            {
                objConn.Open();
                objCmd.Connection = objConn;
                objCmd.CommandText = "PKG_TTTT_CTT.CHECK_TTTT_TRAM_UUTIEN"; objCmd.CommandType = CommandType.StoredProcedure;
                objCmd.Parameters.Add("pMA_DVIQLY", OracleType.VarChar).Value = pMA_DVIQLY;
                objCmd.Parameters.Add("pMA_TRAM", OracleType.VarChar).Value = pMA_TRAM;
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
        public void INSERT_TTTT_KHACHHANG_LUUY(string pMA_DVIQLY, string pMA_KHANG, string pMA_TRAM, string pTEN_KHANG, string pDIACHI, string pNoiDung, string pDate)
        {
            DataTable dt = new DataTable();
            OracleConnection objConn = new OracleConnection(ConnectString.ConnectionString(pMA_DVIQLY));
            OracleCommand objCmd = new OracleCommand();
            try
            {
                objConn.Open();
                objCmd.Connection = objConn;
                objCmd.CommandText = "PKG_TTTT_CTT.INSERT_TTTT_KHACHHANG_LUUY";
                objCmd.CommandType = CommandType.StoredProcedure;
                objCmd.Parameters.Add("pMA_DVIQLY", OracleType.VarChar).Value = pMA_DVIQLY;
                objCmd.Parameters.Add("pMA_KHANG", OracleType.VarChar).Value = pMA_KHANG;
                objCmd.Parameters.Add("pMA_TRAM", OracleType.VarChar).Value = pMA_TRAM;
                objCmd.Parameters.Add("pTEN_KHANG", OracleType.VarChar).Value = pTEN_KHANG;
                objCmd.Parameters.Add("pDIACHI", OracleType.VarChar).Value = pDIACHI;
                objCmd.Parameters.Add("pNoiDung", OracleType.VarChar).Value = pNoiDung;
                objCmd.Parameters.Add("pDate", OracleType.VarChar).Value = pDate;
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
        public DataTable SELECT_TTTT_KHACHHANG_LUUY(string pMA_DVIQLY)
        {
            DataTable dt = new DataTable();
            OracleConnection objConn = new OracleConnection(ConnectString.ConnectionString(""));
            OracleCommand objCmd = new OracleCommand();
            try
            {
                objConn.Open();
                objCmd.Connection = objConn;
                objCmd.CommandText = "PKG_TTTT_CTT.SELECT_TTTT_KHACHHANG_LUUY";
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
        public void DELETE_TTTT_KHACHHANG_LUUY(string pMA_DVIQLY, string pMA_KHANG)
        {
            DataTable dt = new DataTable();
            OracleConnection objConn = new OracleConnection(ConnectString.ConnectionString(pMA_DVIQLY));
            OracleCommand objCmd = new OracleCommand();
            try
            {
                objConn.Open();
                objCmd.Connection = objConn;
                objCmd.CommandText = "PKG_TTTT_CTT.DELETE_TTTT_KHACHHANG_LUUY";
                objCmd.CommandType = CommandType.StoredProcedure;
                objCmd.Parameters.Add("pMA_DVIQLY", OracleType.VarChar).Value = pMA_DVIQLY;
                objCmd.Parameters.Add("pMA_KHANG", OracleType.VarChar).Value = pMA_KHANG;
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
        public DataTable SELECT_TTTT_KHACHHANG_LUUY_INFO(string pMA_DVIQLY, string pMA_KHANG)
        {
            DataTable dt = new DataTable();
            OracleConnection objConn = new OracleConnection(ConnectString.ConnectionString(""));
            OracleCommand objCmd = new OracleCommand();
            try
            {
                objConn.Open();
                objCmd.Connection = objConn;
                objCmd.CommandText = "PKG_TTTT_CTT.SELECT_TTTT_KHACHHANG_LUUY_INFO";
                objCmd.CommandType = CommandType.StoredProcedure;
                objCmd.Parameters.Add("pMA_DVIQLY", OracleType.VarChar).Value = pMA_DVIQLY;
                objCmd.Parameters.Add("pMA_KHANG", OracleType.VarChar).Value = pMA_KHANG;
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
        public void DELETE_TTTT_KHACHHANG_LUUY_INFO(string pMA_TRAM, string pMA_KHANG, string pTHOIGIAN)
        {
            DataTable dt = new DataTable();
            OracleConnection objConn = new OracleConnection(ConnectString.ConnectionString(""));
            OracleCommand objCmd = new OracleCommand();
            try
            {
                objConn.Open();
                objCmd.Connection = objConn;
                objCmd.CommandText = "PKG_TTTT_CTT.DELETE_TTTT_KHACHHANG_LUUY_INFO";
                objCmd.CommandType = CommandType.StoredProcedure;
                objCmd.Parameters.Add("pMA_TRAM", OracleType.VarChar).Value = pMA_TRAM;
                objCmd.Parameters.Add("pMA_KHANG", OracleType.VarChar).Value = pMA_KHANG;
                objCmd.Parameters.Add("pTHOIGIAN", OracleType.VarChar).Value = pTHOIGIAN;
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
        public DataTable SELECT_TTTT_TRAM_CAD(string pMA_DVIQLY)
        {
            DataTable dt = new DataTable();
            OracleConnection objConn = new OracleConnection(ConnectString.ConnectionString(""));
            OracleCommand objCmd = new OracleCommand();
            try
            {
                objConn.Open();
                objCmd.Connection = objConn;
                objCmd.CommandText = "PKG_TTTT_CTT.SELECT_TTTT_TRAM_CAD";
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
        public DataTable SELECT_TTTT_TRAM_CAD_CHECK(string pMA_DVIQLY)
        {
            DataTable dt = new DataTable();
            OracleConnection objConn = new OracleConnection(ConnectString.ConnectionString(""));
            OracleCommand objCmd = new OracleCommand();
            try
            {
                objConn.Open();
                objCmd.Connection = objConn;
                objCmd.CommandText = "PKG_TTTT_CTT.SELECT_TTTT_TRAM_CAD_CHECK";
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
        public DataTable CHECK_TTTT_TRAM_CAD_CHECK(string pMA_DVIQLY, string pMA_TRAM)
        {
            DataTable dt = new DataTable(); OracleConnection objConn = new OracleConnection(ConnectString.ConnectionString(pMA_DVIQLY));
            OracleCommand objCmd = new OracleCommand();
            try
            {
                objConn.Open();
                objCmd.Connection = objConn;
                objCmd.CommandText = "PKG_TTTT_CTT.CHECK_TTTT_TRAM_CAD_CHECK"; objCmd.CommandType = CommandType.StoredProcedure;
                objCmd.Parameters.Add("pMA_DVIQLY", OracleType.VarChar).Value = pMA_DVIQLY;
                objCmd.Parameters.Add("pMA_TRAM", OracleType.VarChar).Value = pMA_TRAM;
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

        public DataTable CHECK_TTTT_TRAM_CAD_CHECK_CAD_CMIS(string pMA_DVIQLY, string pMA_TRAM)
        {
            DataTable dt = new DataTable(); OracleConnection objConn = new OracleConnection(ConnectString.ConnectionString(pMA_DVIQLY));
            OracleCommand objCmd = new OracleCommand();
            try
            {
                objConn.Open();
                objCmd.Connection = objConn;
                objCmd.CommandText = "PKG_TTTT_CTT.CHECK_TTTT_TRAM_CAD_CHECK_CAD_CMIS"; objCmd.CommandType = CommandType.StoredProcedure;
                objCmd.Parameters.Add("pMA_DVIQLY", OracleType.VarChar).Value = pMA_DVIQLY;
                objCmd.Parameters.Add("pMA_TRAM", OracleType.VarChar).Value = pMA_TRAM;
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
        public DataTable SELECT_TTTT_TRAM_UUTIEN_TT(int pTHANG, int pNAM)
        {
            DataTable dt = new DataTable();
            OracleConnection objConn = new OracleConnection(ConnectString.ConnectionString(""));
            OracleCommand objCmd = new OracleCommand();
            try
            {
                objConn.Open();
                objCmd.Connection = objConn;
                objCmd.CommandText = "PKG_TTTT_CTT.SELECT_TTTT_TRAM_UUTIEN_TT"; objCmd.CommandType = CommandType.StoredProcedure;
                objCmd.Parameters.Add("pThang", OracleType.Number).Value = pTHANG;
                objCmd.Parameters.Add("pnam", OracleType.Number).Value = pNAM;
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
        public void INSERT_TTTT_TRAM_UUTIEN_TINHTOAN(string pMA_DVIQLY, string pMA_TRAM, string pKyThuat, string pKinhDoanh, string pSoSanh, string pKyThuatTL, string pKinhDoanhTL, string pSoSanhTL, string pDate, string pNam, string pThang)
        {
            DataTable dt = new DataTable();
            OracleConnection objConn = new OracleConnection(ConnectString.ConnectionString(pMA_DVIQLY));
            OracleCommand objCmd = new OracleCommand();
            try
            {
                objConn.Open();
                objCmd.Connection = objConn;
                objCmd.CommandText = "PKG_TTTT_CTT.INSERT_TTTT_TRAM_UUTIEN_TINHTOAN";
                objCmd.CommandType = CommandType.StoredProcedure;
                objCmd.Parameters.Add("pMA_DVIQLY", OracleType.VarChar).Value = pMA_DVIQLY;
                objCmd.Parameters.Add("pMA_TRAM", OracleType.VarChar).Value = pMA_TRAM;
                objCmd.Parameters.Add("pKyThuat", OracleType.VarChar).Value = pKyThuat;
                objCmd.Parameters.Add("pKinhDoanh", OracleType.VarChar).Value = pKinhDoanh;
                objCmd.Parameters.Add("pSoSanh", OracleType.VarChar).Value = pSoSanh;
                objCmd.Parameters.Add("pKyThuatTL", OracleType.VarChar).Value = pKyThuatTL;
                objCmd.Parameters.Add("pKinhDoanhTL", OracleType.VarChar).Value = pKinhDoanhTL;
                objCmd.Parameters.Add("pSoSanhTL", OracleType.VarChar).Value = pSoSanhTL;
                objCmd.Parameters.Add("pDate", OracleType.VarChar).Value = pDate;
                objCmd.Parameters.Add("pNam", OracleType.VarChar).Value = pNam;
                objCmd.Parameters.Add("pThang", OracleType.VarChar).Value = pThang;
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
        public DataTable TTTT_SELECT_SLG_DUONGDAY_TRAM_CHECK(string pMA_DVIQLY, string pMATRAM, int pTHANG, int pNAM)
        {
            DataTable dt = new DataTable(); OracleConnection objConn = new OracleConnection(ConnectString.ConnectionString(pMA_DVIQLY));
            OracleCommand objCmd = new OracleCommand();
            try
            {
                objConn.Open();
                objCmd.Connection = objConn;
                objCmd.CommandText = "PKG_TTTT_CTT.TTTT_SELECT_SLG_DUONGDAY_TRAM_CHECK";
                objCmd.CommandType = CommandType.StoredProcedure;
                objCmd.Parameters.Add("pMATRAM", OracleType.VarChar).Value = pMATRAM;
                objCmd.Parameters.Add("pMA_DVIQLY", OracleType.VarChar).Value = pMA_DVIQLY;
                objCmd.Parameters.Add("pTHANG", OracleType.Number).Value = pTHANG;
                objCmd.Parameters.Add("pNAM", OracleType.Number).Value = pNAM;
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
        public DataTable SELECT_TRAM_HATHE_UT(string pMA_DVIQLY)
        {
            DataTable dt = new DataTable();
            OracleConnection objConn = new OracleConnection(ConnectString.ConnectionString(""));
            OracleCommand objCmd = new OracleCommand();
            try
            {
                objConn.Open();
                objCmd.Connection = objConn;
                objCmd.CommandText = "PKG_TTTT_CTT.SELECT_TRAM_HATHE_UT";
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
        public DataTable SELECT_TRAM_HATHE_UT_TT(string pMA_DVIQLY, string pMA_TRAM, string pTHANG, string pNAM)
        {
            DataTable dt = new DataTable();
            OracleConnection objConn = new OracleConnection(ConnectString.ConnectionString(""));
            OracleCommand objCmd = new OracleCommand();
            try
            {
                objConn.Open();
                objCmd.Connection = objConn;
                objCmd.CommandText = "PKG_TTTT_CTT.SELECT_TRAM_HATHE_UT_TT";
                objCmd.CommandType = CommandType.StoredProcedure;
                objCmd.Parameters.Add("pMA_DVIQLY", OracleType.VarChar).Value = pMA_DVIQLY;
                objCmd.Parameters.Add("pMA_TRAM", OracleType.VarChar).Value = pMA_TRAM;
                objCmd.Parameters.Add("pTHANG", OracleType.VarChar).Value = pTHANG;
                objCmd.Parameters.Add("pNAM", OracleType.VarChar).Value = pNAM;
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
        public DataTable SELECT_TRAM_HATHE_UT_TT_DS(string pMA_DVIQLY, string pTHANG, string pNAM)
        {
            DataTable dt = new DataTable();
            OracleConnection objConn = new OracleConnection(ConnectString.ConnectionString(""));
            OracleCommand objCmd = new OracleCommand();
            try
            {
                objConn.Open();
                objCmd.Connection = objConn;
                objCmd.CommandText = "PKG_TTTT_CTT.SELECT_TRAM_HATHE_UT_TT_DS";
                objCmd.CommandType = CommandType.StoredProcedure;
                objCmd.Parameters.Add("pMA_DVIQLY", OracleType.VarChar).Value = pMA_DVIQLY;
                objCmd.Parameters.Add("pTHANG", OracleType.VarChar).Value = pTHANG;
                objCmd.Parameters.Add("pNAM", OracleType.VarChar).Value = pNAM;
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

        public DataTable SELECT_TTTT_SANLUONG_TUTHANG_DENTHANG(string pMA_DVIQLY, string pMATRAM, int pTHANG, int pNAM, int pTUNGAY, int pDENNGAY, int kieudulieu)
        {
            DataTable dt = new DataTable();
            OracleConnection objConn = new OracleConnection(ConnectString.ConnectionString(""));
            OracleCommand objCmd = new OracleCommand();
            try
            {
                objConn.Open();
                objCmd.Connection = objConn;
                objCmd.CommandText = "PKG_TTTT.select_TTTT_SL_CHUKYTAI_TUNGAY_DENNGAY";
                objCmd.CommandType = CommandType.StoredProcedure;
                objCmd.Parameters.Add("pMA_DVIQLY", OracleType.VarChar).Value = pMA_DVIQLY;
                objCmd.Parameters.Add("pMATRAM", OracleType.VarChar).Value = pMATRAM;
                objCmd.Parameters.Add("pTHANG", OracleType.Number).Value = pTHANG;
                objCmd.Parameters.Add("pNAM", OracleType.Number).Value = pNAM;
                objCmd.Parameters.Add("pTUNGAY", OracleType.Number).Value = pTUNGAY;
                objCmd.Parameters.Add("pDENNGAY", OracleType.Number).Value = pDENNGAY;
                objCmd.Parameters.Add("pKIEUDULIEU", OracleType.Number).Value = kieudulieu;

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
        public DataTable SELECT_THONGTIN_TRAM_BCKD(string pMA_DVIQLY, string pMATRAM, int pTHANG, int pNAM, int pTHANG1, int pNAM1, int pTHANG2, int pNAM2, int pTHANG3, int pNAM3)
        {
            DataTable dt = new DataTable();
            OracleConnection objConn = new OracleConnection(ConnectString.ConnectionString(""));
            OracleCommand objCmd = new OracleCommand();
            try
            {
                objConn.Open();
                objCmd.Connection = objConn;
                objCmd.CommandText = "PKG_TTTT_CTT.SELECT_THONGTIN_TRAM_BCKD";
                objCmd.CommandType = CommandType.StoredProcedure;
                objCmd.Parameters.Add("pMA_DVIQLY", OracleType.VarChar).Value = pMA_DVIQLY;
                objCmd.Parameters.Add("pMATRAM", OracleType.VarChar).Value = pMATRAM;
                objCmd.Parameters.Add("pTHANG", OracleType.Number).Value = pTHANG;
                objCmd.Parameters.Add("pNAM", OracleType.Number).Value = pNAM;
                objCmd.Parameters.Add("pTHANG1", OracleType.Number).Value = pTHANG1;
                objCmd.Parameters.Add("pNAM1", OracleType.Number).Value = pNAM1;
                objCmd.Parameters.Add("pTHANG2", OracleType.Number).Value = pTHANG2;
                objCmd.Parameters.Add("pNAM2", OracleType.Number).Value = pNAM2;
                objCmd.Parameters.Add("pTHANG3", OracleType.Number).Value = pTHANG3;
                objCmd.Parameters.Add("pNAM3", OracleType.Number).Value = pNAM3;
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
        public DataTable SELECT_THONGTIN_KHANG_BCKD(string pMA_DVIQLY, string pMATRAM, int pTHANG, int pNAM)
        {
            DataTable dt = new DataTable();
            OracleConnection objConn = new OracleConnection(ConnectString.ConnectionString(""));
            OracleCommand objCmd = new OracleCommand();
            try
            {
                objConn.Open();
                objCmd.Connection = objConn;
                objCmd.CommandText = "PKG_TTTT_CTT.SELECT_THONGTIN_KHANG_BCKD";
                objCmd.CommandType = CommandType.StoredProcedure;
                objCmd.Parameters.Add("pMA_DVIQLY", OracleType.VarChar).Value = pMA_DVIQLY;
                objCmd.Parameters.Add("pMATRAM", OracleType.VarChar).Value = pMATRAM;
                objCmd.Parameters.Add("pTHANG", OracleType.Number).Value = pTHANG;
                objCmd.Parameters.Add("pNAM", OracleType.Number).Value = pNAM;
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
        public DataTable SELECT_TTTT_DM_TTKD()
        {
            DataTable dt = new DataTable(); OracleConnection objConn = new OracleConnection(ConnectString.ConnectionString(""));
            OracleCommand objCmd = new OracleCommand();
            try
            {
                objConn.Open();
                objCmd.Connection = objConn;
                objCmd.CommandText = "PKG_TTTT_CTT.SELECT_TTTT_DM_TTKD";
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
        public void UPDATE_TTTT_DM_TTKD(string pMA_CANHBAO, string pTT_CANHBAO, string pDX_CANHBAO)
        {
            DataTable dt = new DataTable();
            OracleConnection objConn = new OracleConnection(ConnectString.ConnectionString(""));
            OracleCommand objCmd = new OracleCommand();
            try
            {
                objConn.Open();
                objCmd.Connection = objConn;
                objCmd.CommandText = "PKG_TTTT_CTT.UPDATE_TTTT_DM_TTKD";
                objCmd.CommandType = CommandType.StoredProcedure;
                objCmd.Parameters.Add("pMA_CANHBAO", OracleType.VarChar).Value = pMA_CANHBAO;
                objCmd.Parameters.Add("pTT_CANHBAO", OracleType.VarChar).Value = pTT_CANHBAO;
                objCmd.Parameters.Add("pDX_CANHBAO", OracleType.NVarChar).Value = pDX_CANHBAO;
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
        public void INSERT_TTTT_DM_TTKD(string pMA_CANHBAO, string pTT_CANHBAO, string pDX_CANHBAO)
        {
            DataTable dt = new DataTable();
            OracleConnection objConn = new OracleConnection(ConnectString.ConnectionString(""));
            OracleCommand objCmd = new OracleCommand();
            try
            {
                objConn.Open();
                objCmd.Connection = objConn;
                objCmd.CommandText = "PKG_TTTT_CTT.INSERT_TTTT_DM_TTKD";
                objCmd.CommandType = CommandType.StoredProcedure;
                objCmd.Parameters.Add("pMA_CANHBAO", OracleType.VarChar).Value = pMA_CANHBAO;
                objCmd.Parameters.Add("pTT_CANHBAO", OracleType.VarChar).Value = pTT_CANHBAO;
                objCmd.Parameters.Add("pDX_CANHBAO", OracleType.NVarChar).Value = pDX_CANHBAO;
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
        public DataTable SELECT_CHECK_TTTT_DM_TTKD(string pMA_CANHBAO)
        {
            DataTable dt = new DataTable(); OracleConnection objConn = new OracleConnection(ConnectString.ConnectionString(""));
            OracleCommand objCmd = new OracleCommand();
            try
            {
                objConn.Open();
                objCmd.Connection = objConn;
                objCmd.CommandText = "PKG_TTTT_CTT.SELECT_CHECK_TTTT_DM_TTKD"; objCmd.CommandType = CommandType.StoredProcedure;
                objCmd.Parameters.Add("pMA_CANHBAO", OracleType.VarChar).Value = pMA_CANHBAO;
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
        public void DELETE_CHECK_TTTT_DM_TTKD(string pMA_CANHBAO)
        {
            DataTable dt = new DataTable();
            OracleConnection objConn = new OracleConnection(ConnectString.ConnectionString(""));
            OracleCommand objCmd = new OracleCommand();
            try
            {
                objConn.Open();
                objCmd.Connection = objConn;
                objCmd.CommandText = "PKG_TTTT_CTT.DELETE_CHECK_TTTT_DM_TTKD";
                objCmd.CommandType = CommandType.StoredProcedure;
                objCmd.Parameters.Add("pMA_CANHBAO", OracleType.VarChar).Value = pMA_CANHBAO;
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
        public DataTable SELECT_CHECK_TTTT_TTKD_TLTTTRAM(string pMA_DVIQLY)
        {
            DataTable dt = new DataTable(); OracleConnection objConn = new OracleConnection(ConnectString.ConnectionString(""));
            OracleCommand objCmd = new OracleCommand();
            try
            {
                objConn.Open();
                objCmd.Connection = objConn;
                objCmd.CommandText = "PKG_TTTT_CTT.SELECT_CHECK_TTTT_TTKD_TLTTTRAM";
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
        public void DELETE_CHECK_TTTT_TTKD_TLTTTRAM(int pID)
        {
            DataTable dt = new DataTable();
            OracleConnection objConn = new OracleConnection(ConnectString.ConnectionString(""));
            OracleCommand objCmd = new OracleCommand();
            try
            {
                objConn.Open();
                objCmd.Connection = objConn;
                objCmd.CommandText = "PKG_TTTT_CTT.DELETE_CHECK_TTTT_TTKD_TLTTTRAM";
                objCmd.CommandType = CommandType.StoredProcedure;
                objCmd.Parameters.Add("pID", OracleType.VarChar).Value = pID;
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
        public void INSERT_TTTT_TTKD_TLTTTRAM(string pMA_DVIQLY, float pTYLETT)
        {
            DataTable dt = new DataTable();
            OracleConnection objConn = new OracleConnection(ConnectString.ConnectionString(""));
            OracleCommand objCmd = new OracleCommand();
            try
            {
                objConn.Open();
                objCmd.Connection = objConn;
                objCmd.CommandText = "PKG_TTTT_CTT.INSERT_TTTT_TTKD_TLTTTRAM";
                objCmd.CommandType = CommandType.StoredProcedure;
                objCmd.Parameters.Add("pMA_DVIQLY", OracleType.VarChar).Value = pMA_DVIQLY;
                objCmd.Parameters.Add("pTYLETT", OracleType.Number).Value = pTYLETT;
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
        public DataTable SELECT_TRAM_HATHE_CTT(string pMA_DVIQLY, float pTT_PT, int pThang, int pNam)
        {
            DataTable dt = new DataTable();
            OracleConnection objConn = new OracleConnection(ConnectString.ConnectionString(""));
            OracleCommand objCmd = new OracleCommand();
            try
            {
                objConn.Open();
                objCmd.Connection = objConn;
                objCmd.CommandText = "PKG_TTTT_CTT.SELECT_TRAM_HATHE";
                objCmd.CommandType = CommandType.StoredProcedure;
                objCmd.Parameters.Add("pMA_DVIQLY", OracleType.VarChar).Value = pMA_DVIQLY;
                objCmd.Parameters.Add("pTT_PT", OracleType.Number).Value = pTT_PT;
                objCmd.Parameters.Add("pThang", OracleType.Number).Value = pThang;
                objCmd.Parameters.Add("pNam", OracleType.Number).Value = pNam;
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
        public DataTable SELECT_TTTT_PT_BT_KHANG(string pMA_DVIQLY, int pLoai)
        {
            DataTable dt = new DataTable(); OracleConnection objConn = new OracleConnection(ConnectString.ConnectionString(""));
            OracleCommand objCmd = new OracleCommand();
            try
            {
                objConn.Open();
                objCmd.Connection = objConn;
                objCmd.CommandText = "PKG_TTTT_CTT.SELECT_TTTT_PT_BT_KHANG";
                objCmd.CommandType = CommandType.StoredProcedure;
                objCmd.Parameters.Add("pMA_DVIQLY", OracleType.VarChar).Value = pMA_DVIQLY;
                objCmd.Parameters.Add("pLOAI", OracleType.Number).Value = pLoai;
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
        public void INSERT_TTTT_PT_BT_KHANG(string pMA_DVIQLY, float pPT_BT, int pLoai)
        {
            DataTable dt = new DataTable();
            OracleConnection objConn = new OracleConnection(ConnectString.ConnectionString(""));
            OracleCommand objCmd = new OracleCommand();
            try
            {
                objConn.Open();
                objCmd.Connection = objConn;
                objCmd.CommandText = "PKG_TTTT_CTT.INSERT_TTTT_PT_BT_KHANG";
                objCmd.CommandType = CommandType.StoredProcedure;
                objCmd.Parameters.Add("pMA_DVIQLY", OracleType.VarChar).Value = pMA_DVIQLY;
                objCmd.Parameters.Add("pPT_BT", OracleType.Number).Value = pPT_BT;
                objCmd.Parameters.Add("pLOAI", OracleType.Number).Value = pLoai;
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
        public void UPDATE_TTTT_PT_BT_KHANG(string pMA_DVIQLY, float pPT_BT, int pLoai)
        {
            DataTable dt = new DataTable();
            OracleConnection objConn = new OracleConnection(ConnectString.ConnectionString(""));
            OracleCommand objCmd = new OracleCommand();
            try
            {
                objConn.Open();
                objCmd.Connection = objConn;
                objCmd.CommandText = "PKG_TTTT_CTT.UPDATE_TTTT_PT_BT_KHANG";
                objCmd.CommandType = CommandType.StoredProcedure;
                objCmd.Parameters.Add("pMA_DVIQLY", OracleType.VarChar).Value = pMA_DVIQLY;
                objCmd.Parameters.Add("pPT_BT", OracleType.Number).Value = pPT_BT;
                objCmd.Parameters.Add("pLOAI", OracleType.Number).Value = pLoai;
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
        public DataTable SELECT_THONGTIN_TRAM_TLTT(string pMA_DVIQLY, int pTHANG, int pNAM, int pTHANG1, int pNAM1, int pTHANG2, int pNAM2, int pTHANG3, int pNAM3, float pTyLeSS)
        {
            DataTable dt = new DataTable();
            OracleConnection objConn = new OracleConnection(ConnectString.ConnectionString(""));
            OracleCommand objCmd = new OracleCommand();
            try
            {
                objConn.Open();
                objCmd.Connection = objConn;
                objCmd.CommandText = "PKG_TTTT_CTT.SELECT_THONGTIN_TRAM_TLTT";
                objCmd.CommandType = CommandType.StoredProcedure;
                objCmd.Parameters.Add("pMA_DVIQLY", OracleType.VarChar).Value = pMA_DVIQLY;
                objCmd.Parameters.Add("pTHANG", OracleType.Number).Value = pTHANG;
                objCmd.Parameters.Add("pNAM", OracleType.Number).Value = pNAM;
                objCmd.Parameters.Add("pTHANG1", OracleType.Number).Value = pTHANG1;
                objCmd.Parameters.Add("pNAM1", OracleType.Number).Value = pNAM1;
                objCmd.Parameters.Add("pTHANG2", OracleType.Number).Value = pTHANG2;
                objCmd.Parameters.Add("pNAM2", OracleType.Number).Value = pNAM2;
                objCmd.Parameters.Add("pTHANG3", OracleType.Number).Value = pTHANG3;
                objCmd.Parameters.Add("pNAM3", OracleType.Number).Value = pNAM3;
                objCmd.Parameters.Add("pTyLeSS", OracleType.Number).Value = pTyLeSS;
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

        public void INSERT_TBDD_PT_CHISO_KH(string pMA_DVIQLY, string pMATRAM, string pMAKHACHHANG, string pMA_NN, string pTENKHACHHANG, string pDIACHI, string pMA_TTCTO, string pCANH_BAO, string pDX_CANH_BAO, string pMA_CLOAI, string pSO_CTO, string pSAN_LUONG, string pSLUONG_1, string pSLUONG_2, string pSLUONG_3, string pSOHO, string pHANKD)
        {
            DataTable dt = new DataTable();
            OracleConnection objConn = new OracleConnection(ConnectString.ConnectionString(pMA_DVIQLY));
            OracleCommand objCmd = new OracleCommand();
            try
            {
                objConn.Open();
                objCmd.Connection = objConn;
                objCmd.CommandText = "PKG_TTTT.INSERT_TTTT_SLGNUT_CHUKY";
                objCmd.CommandType = CommandType.StoredProcedure;
                objCmd.Parameters.Add("pMA_DVIQLY", OracleType.VarChar).Value = pMA_DVIQLY;
                objCmd.Parameters.Add("pMATRAM", OracleType.VarChar).Value = pMATRAM;
                objCmd.Parameters.Add("pMAKHACHHANG", OracleType.VarChar).Value = pMAKHACHHANG;
                objCmd.Parameters.Add("pMA_NN", OracleType.VarChar).Value = pMA_NN;
                objCmd.Parameters.Add("pTENKHACHHANG", OracleType.VarChar).Value = pTENKHACHHANG;
                objCmd.Parameters.Add("pDIACHI", OracleType.VarChar).Value = pDIACHI;
                objCmd.Parameters.Add("pMA_TTCTO", OracleType.VarChar).Value = pMA_TTCTO;
                objCmd.Parameters.Add("pCANH_BAO", OracleType.VarChar).Value = pCANH_BAO;
                objCmd.Parameters.Add("pDX_CANH_BAO", OracleType.VarChar).Value = pDX_CANH_BAO;
                objCmd.Parameters.Add("pMA_CLOAI", OracleType.VarChar).Value = pMA_CLOAI;
                objCmd.Parameters.Add("pSO_CTO", OracleType.VarChar).Value = pSO_CTO;
                objCmd.Parameters.Add("pSAN_LUONG", OracleType.VarChar).Value = pSAN_LUONG;
                objCmd.Parameters.Add("pSLUONG_1", OracleType.VarChar).Value = pSLUONG_1;
                objCmd.Parameters.Add("pSLUONG_2", OracleType.VarChar).Value = pSLUONG_2;
                objCmd.Parameters.Add("pSLUONG_3", OracleType.VarChar).Value = pSLUONG_3;
                objCmd.Parameters.Add("pSLUONG_2", OracleType.VarChar).Value = pSLUONG_2;
                objCmd.Parameters.Add("pSLUONG_3", OracleType.VarChar).Value = pSLUONG_3;
                objCmd.Parameters.Add("pSOHO", OracleType.VarChar).Value = pSOHO;
                objCmd.Parameters.Add("pHANKD", OracleType.VarChar).Value = pHANKD;
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

        public void Insert_Khang_PhucTra(DataTable dsTem, int thang, int nam, string Ma_dvi)
        {
            DataTable dt = new DataTable();
            OracleConnection objConn = new OracleConnection(ConnectString.ConnectionString(""));
            OracleCommand objCmd = new OracleCommand();
            try
            {
                objConn.Open();
                objCmd.Connection = objConn;

                objCmd.CommandText = "PKG_TTTT_CTT.INSERT_TBDD_PHUCTRA_CS_TEM";
                objCmd.CommandType = CommandType.StoredProcedure;

                for (int i = 0; i < dsTem.Rows.Count; i++)
                {
                    dt = check_INSERT_TBDD_PT_CHISO_KH(Ma_dvi, dsTem.Rows[i]["SO_CTO"] + "", "DDK" , "0A", 0, thang, nam);
                    if (dt.Rows.Count == 0)
                    {
                        objCmd.Parameters.Clear();

                        objCmd.Parameters.Add("pDIA_CHI", OracleType.VarChar).Value = dsTem.Rows[i]["DIACHI"] + "";

                        objCmd.Parameters.Add("pMA_CTO", OracleType.VarChar).Value = dsTem.Rows[i]["SO_CTO"] + "";
                        objCmd.Parameters.Add("pMA_DVIQLY", OracleType.VarChar).Value = Ma_dvi;

                        objCmd.Parameters.Add("pMA_KHANG", OracleType.VarChar).Value = dsTem.Rows[i]["MAKHACHHANG"] + "";
                        if (dsTem.Columns.Contains("MA_NN"))
                            objCmd.Parameters.Add("pMA_NN", OracleType.VarChar).Value = dsTem.Rows[i]["MA_NN"] + "";
                        else
                            objCmd.Parameters.Add("pMA_NN", OracleType.VarChar).Value = "";

                        objCmd.Parameters.Add("pMA_TRAM", OracleType.VarChar).Value = "" + dsTem.Rows[i]["MATRAM"];
                        objCmd.Parameters.Add("pNAM", OracleType.Number).Value = nam;

                        // objCmd.Parameters.Add("pSAN_LUONG", OracleType.Number).Value = decimal.Parse("0" + dsTem.Rows[i]["SAN_LUONG"]);

                        objCmd.Parameters.Add("pSO_HO", OracleType.Number).Value = decimal.Parse("0" + dsTem.Rows[i]["SOHO"]);
                        objCmd.Parameters.Add("pTEN_KHANG", OracleType.VarChar).Value = "" + dsTem.Rows[i]["TENKHACHHANG"];
                        objCmd.Parameters.Add("pTHANG", OracleType.Number).Value = thang;
                        objCmd.Parameters.Add("pTTR_MOI", OracleType.VarChar).Value = dsTem.Rows[i]["MA_TTCTO"] + "";

                        objCmd.Parameters.Add("pSLUONG_1", OracleType.Number).Value = decimal.Parse("0" + dsTem.Rows[i]["SLUONG_1"]);
                        objCmd.Parameters.Add("pSLUONG_2", OracleType.Number).Value = decimal.Parse("0" + dsTem.Rows[i]["SLUONG_2"]);
                        objCmd.Parameters.Add("pSLUONG_3", OracleType.Number).Value = decimal.Parse("0" + dsTem.Rows[i]["SLUONG_3"]);


                        objCmd.Parameters.Add("pBOCSO_ID", OracleType.Number).Value = decimal.Parse("0");
                        if (dsTem.Columns.Contains("CHUOI_GIA"))
                            objCmd.Parameters.Add("pCHUOI_GIA", OracleType.VarChar).Value = "";
                        else
                            objCmd.Parameters.Add("pCHUOI_GIA", OracleType.VarChar).Value = "";
                        objCmd.Parameters.Add("pCS_CU", OracleType.Number).Value = decimal.Parse("0");
                        objCmd.Parameters.Add("pCS_MOI", OracleType.Number).Value = decimal.Parse("0");
                        objCmd.Parameters.Add("pHSN", OracleType.Number).Value = decimal.Parse("0");
                        objCmd.Parameters.Add("pKIMUA_CSPK", OracleType.Number).Value = decimal.Parse("0");
                        objCmd.Parameters.Add("pKY", OracleType.Number).Value = int.Parse("0");
                        objCmd.Parameters.Add("pLOAI_BCS", OracleType.VarChar).Value = "0A";
                        objCmd.Parameters.Add("pLOAI_CS", OracleType.VarChar).Value = "0A";
                        objCmd.Parameters.Add("pMA_COT", OracleType.VarChar).Value = "";
                        objCmd.Parameters.Add("pMA_DDO", OracleType.VarChar).Value = "000A";
                        objCmd.Parameters.Add("pMA_GC", OracleType.VarChar).Value = "";
                        objCmd.Parameters.Add("pMA_NVGCS", OracleType.VarChar).Value = "";
                        objCmd.Parameters.Add("pMA_QUYEN", OracleType.VarChar).Value = "00A";
                        objCmd.Parameters.Add("pNGAY_CU", OracleType.DateTime).Value = DateTime.Parse("1000-01-01");
                        objCmd.Parameters.Add("pNGAY_MOI", OracleType.DateTime).Value = DateTime.Parse("1000-01-01");
                        objCmd.Parameters.Add("pNGUOI_GCS", OracleType.VarChar).Value = "";
                        objCmd.Parameters.Add("pSERY_CTO", OracleType.VarChar).Value = "000A";
                        objCmd.Parameters.Add("pSL_MOI", OracleType.Number).Value = decimal.Parse("0");
                        objCmd.Parameters.Add("pSL_CU", OracleType.Number).Value = decimal.Parse("0");
                        objCmd.Parameters.Add("pSL_THAO", OracleType.Number).Value = decimal.Parse("0");
                        objCmd.Parameters.Add("pSL_TTIEP", OracleType.Number).Value = decimal.Parse("0");

                        if (dsTem.Columns.Contains("TTR_CU"))
                            objCmd.Parameters.Add("pTTR_CU", OracleType.VarChar).Value = "";
                        else
                            objCmd.Parameters.Add("pTTR_CU", OracleType.VarChar).Value = "";

                        if (dsTem.Columns.Contains("SO_HOM"))
                            objCmd.Parameters.Add("pSO_HOM", OracleType.VarChar).Value = "";
                        else
                            objCmd.Parameters.Add("pSO_HOM", OracleType.VarChar).Value = "";
                        objCmd.Parameters.Add("pTENFILE", OracleType.VarChar).Value = "";
                        OracleDataReader objReader = objCmd.ExecuteReader();
                    }
                }
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
        public DataTable check_INSERT_TBDD_PT_CHISO_KH(string Ma_dvi, string MA_CTO, string LOAI_CS, string LOAI_BCS, int ky, int thang, int nam)
        {
            DataTable dt = new DataTable(); OracleConnection objConn = new OracleConnection(ConnectString.ConnectionString(""));
            OracleCommand objCmd = new OracleCommand();
            try
            {
                objConn.Open();
                objCmd.Connection = objConn;
                objCmd.CommandText = "PKG_TTTT_CTT.check_INSERT_TBDD_PT_CHISO_KH";
                objCmd.CommandType = CommandType.StoredProcedure;
                objCmd.Parameters.Add("pMA_DVIQLY", OracleType.VarChar).Value = Ma_dvi;
                objCmd.Parameters.Add("pMA_CTO", OracleType.VarChar).Value = MA_CTO;
                objCmd.Parameters.Add("pLOAI_CS", OracleType.VarChar).Value = LOAI_CS;
                objCmd.Parameters.Add("pLOAI_BCS", OracleType.VarChar).Value = LOAI_BCS;
                objCmd.Parameters.Add("pKY", OracleType.Number).Value = ky;
                objCmd.Parameters.Add("pTHANG", OracleType.Number).Value = thang;
                objCmd.Parameters.Add("pNAM", OracleType.Number).Value = nam;
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

        public DataTable SELECT_THONGTIN_TRAM_TLTT_BT(string pMA_DVIQLY, int pTHANG, int pNAM, int pTHANG1, int pNAM1, int pTHANG2, int pNAM2, int pTHANG3, int pNAM3, float pTyLeSS)
        {
            DataTable dt = new DataTable();
            OracleConnection objConn = new OracleConnection(ConnectString.ConnectionString(""));
            OracleCommand objCmd = new OracleCommand();
            try
            {
                objConn.Open();
                objCmd.Connection = objConn;
                objCmd.CommandText = "PKG_TTTT_CTT.SELECT_THONGTIN_TRAM_TLTT_BT";
                objCmd.CommandType = CommandType.StoredProcedure;
                objCmd.Parameters.Add("pMA_DVIQLY", OracleType.VarChar).Value = pMA_DVIQLY;
                objCmd.Parameters.Add("pTHANG", OracleType.Number).Value = pTHANG;
                objCmd.Parameters.Add("pNAM", OracleType.Number).Value = pNAM;
                objCmd.Parameters.Add("pTHANG1", OracleType.Number).Value = pTHANG1;
                objCmd.Parameters.Add("pNAM1", OracleType.Number).Value = pNAM1;
                objCmd.Parameters.Add("pTHANG2", OracleType.Number).Value = pTHANG2;
                objCmd.Parameters.Add("pNAM2", OracleType.Number).Value = pNAM2;
                objCmd.Parameters.Add("pTHANG3", OracleType.Number).Value = pTHANG3;
                objCmd.Parameters.Add("pNAM3", OracleType.Number).Value = pNAM3;
                objCmd.Parameters.Add("pTyLeSS", OracleType.Number).Value = pTyLeSS;
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

        public DataTable SELECT_THONGTIN_TRAM_TLTT_SL(string pMA_DVIQLY, int pTHANG, int pNAM, int pTHANG1, int pNAM1, int pTHANG2, int pNAM2, int pTHANG3, int pNAM3, float pTyLeSS)
        {
            DataTable dt = new DataTable();
            OracleConnection objConn = new OracleConnection(ConnectString.ConnectionString(""));
            OracleCommand objCmd = new OracleCommand();
            try
            {
                objConn.Open();
                objCmd.Connection = objConn;
                objCmd.CommandText = "PKG_TTTT_CTT.SELECT_THONGTIN_TRAM_TLTT_SL";
                objCmd.CommandType = CommandType.StoredProcedure;
                objCmd.Parameters.Add("pMA_DVIQLY", OracleType.VarChar).Value = pMA_DVIQLY;
                objCmd.Parameters.Add("pTHANG", OracleType.Number).Value = pTHANG;
                objCmd.Parameters.Add("pNAM", OracleType.Number).Value = pNAM;
                objCmd.Parameters.Add("pTHANG1", OracleType.Number).Value = pTHANG1;
                objCmd.Parameters.Add("pNAM1", OracleType.Number).Value = pNAM1;
                objCmd.Parameters.Add("pTHANG2", OracleType.Number).Value = pTHANG2;
                objCmd.Parameters.Add("pNAM2", OracleType.Number).Value = pNAM2;
                objCmd.Parameters.Add("pTHANG3", OracleType.Number).Value = pTHANG3;
                objCmd.Parameters.Add("pNAM3", OracleType.Number).Value = pNAM3;
                objCmd.Parameters.Add("pTyLeSS", OracleType.Number).Value = pTyLeSS;
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
        public DataTable SELECT_THONGTIN_TRAM_TLTT_B10(string pMA_DVIQLY, int pTHANG, int pNAM)
        {
            DataTable dt = new DataTable();
            OracleConnection objConn = new OracleConnection(ConnectString.ConnectionString(""));
            OracleCommand objCmd = new OracleCommand();
            try
            {
                objConn.Open();
                objCmd.Connection = objConn;
                objCmd.CommandText = "PKG_TTTT_CTT.SELECT_THONGTIN_TRAM_TLTT_B10";
                objCmd.CommandType = CommandType.StoredProcedure;
                objCmd.Parameters.Add("pMA_DVIQLY", OracleType.VarChar).Value = pMA_DVIQLY;
                objCmd.Parameters.Add("pTHANG", OracleType.Number).Value = pTHANG;
                objCmd.Parameters.Add("pNAM", OracleType.Number).Value = pNAM;
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
        public DataTable SELECT_THONGTIN_TRAM_TLTT_2THANG(string pMA_DVIQLY, int pTHANG, int pNAM, int pTHANG1, int pNAM1)
        {
            DataTable dt = new DataTable();
            OracleConnection objConn = new OracleConnection(ConnectString.ConnectionString(""));
            OracleCommand objCmd = new OracleCommand();
            try
            {
                objConn.Open();
                objCmd.Connection = objConn;
                objCmd.CommandText = "PKG_TTTT_CTT.SELECT_THONGTIN_TRAM_TLTT_2THANG";
                objCmd.CommandType = CommandType.StoredProcedure;
                objCmd.Parameters.Add("pMA_DVIQLY", OracleType.VarChar).Value = pMA_DVIQLY;
                objCmd.Parameters.Add("pTHANG", OracleType.Number).Value = pTHANG;
                objCmd.Parameters.Add("pNAM", OracleType.Number).Value = pNAM;
                objCmd.Parameters.Add("pTHANG1", OracleType.Number).Value = pTHANG1;
                objCmd.Parameters.Add("pNAM1", OracleType.Number).Value = pNAM1;
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
        public DataTable SELECT_THONGTIN_TRAM_TLTT_2THANG_BT(string pMA_DVIQLY, int pTHANG, int pNAM, int pTHANG1, int pNAM1, float pTyLeSS, float tylebt, float SL)
        {
            DataTable dt = new DataTable();
            OracleConnection objConn = new OracleConnection(ConnectString.ConnectionString(""));
            OracleCommand objCmd = new OracleCommand();
            try
            {
                objConn.Open();
                objCmd.Connection = objConn;
                objCmd.CommandText = "PKG_TTTT_CTT.SELECT_THONGTIN_TRAM_TLTT_2THANG_BT";
                objCmd.CommandType = CommandType.StoredProcedure;
                objCmd.Parameters.Add("pMA_DVIQLY", OracleType.VarChar).Value = pMA_DVIQLY;
                objCmd.Parameters.Add("pTHANG", OracleType.Number).Value = pTHANG;
                objCmd.Parameters.Add("pNAM", OracleType.Number).Value = pNAM;
                objCmd.Parameters.Add("pTHANG1", OracleType.Number).Value = pTHANG1;
                objCmd.Parameters.Add("pNAM1", OracleType.Number).Value = pNAM1;
                objCmd.Parameters.Add("pTL", OracleType.Number).Value = pTyLeSS;
                objCmd.Parameters.Add("pBT", OracleType.Number).Value = tylebt;
                objCmd.Parameters.Add("pSL", OracleType.Number).Value = SL;
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

        public void INSERT_THONGTIN_TRAM_TLTT_B10(string pMA_DVIQLY, string pMA_TRAM, string pTEN_TRAM, int pCSUAT_TRAM, float pDNN, double pTT_LK,float DNTT,int pNGUYEN_NHAN, int pTinhTrang, int pTHANG, int pNAM, float pTL)
        {
            DataTable dt = new DataTable();
            OracleConnection objConn = new OracleConnection(ConnectString.ConnectionString(""));
            OracleCommand objCmd = new OracleCommand();
            try
            {
                objConn.Open();
                objCmd.Connection = objConn;
                objCmd.CommandText = "PKG_TTTT_CTT.INSERT_THONGTIN_TRAM_TLTT_B10";
                objCmd.CommandType = CommandType.StoredProcedure;
                objCmd.Parameters.Add("pMA_DVIQLY", OracleType.VarChar).Value = pMA_DVIQLY;
                objCmd.Parameters.Add("pMA_TRAM", OracleType.VarChar).Value = pMA_TRAM;
                objCmd.Parameters.Add("pTEN_TRAM", OracleType.VarChar).Value = pTEN_TRAM;
                objCmd.Parameters.Add("pCSUAT_TRAM", OracleType.Number).Value = pCSUAT_TRAM;
                objCmd.Parameters.Add("pTT_LK", OracleType.Number).Value = pTT_LK;
                objCmd.Parameters.Add("pDNN", OracleType.Number).Value = pDNN;
                objCmd.Parameters.Add("pNGUYEN_NHAN", OracleType.Number).Value = pNGUYEN_NHAN;
                objCmd.Parameters.Add("pDNTT", OracleType.Number).Value = DNTT;
                objCmd.Parameters.Add("pTINHTRANG", OracleType.Number).Value = pTinhTrang;
                objCmd.Parameters.Add("pTHANG", OracleType.Number).Value = pTHANG;
                objCmd.Parameters.Add("pNAM", OracleType.Number).Value = pNAM;
                objCmd.Parameters.Add("pTL", OracleType.Number).Value = pTL;
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
        public void UPDATE_THONGTIN_TRAM_TLTT_B10(string pMA_DVIQLY, string pMA_TRAM, int pTinhTrang, int pTHANG, int pNAM, float pTL)
        {
            DataTable dt = new DataTable();
            OracleConnection objConn = new OracleConnection(ConnectString.ConnectionString(""));
            OracleCommand objCmd = new OracleCommand();
            try
            {
                objConn.Open();
                objCmd.Connection = objConn;
                objCmd.CommandText = "PKG_TTTT_CTT.UPDATE_THONGTIN_TRAM_TLTT_B10";
                objCmd.CommandType = CommandType.StoredProcedure;
                objCmd.Parameters.Add("pMA_DVIQLY", OracleType.VarChar).Value = pMA_DVIQLY;
                objCmd.Parameters.Add("pMA_TRAM", OracleType.VarChar).Value = pMA_TRAM;
                objCmd.Parameters.Add("pTINHTRANG", OracleType.Number).Value = pTinhTrang;
                objCmd.Parameters.Add("pTHANG", OracleType.Number).Value = pTHANG;
                objCmd.Parameters.Add("pNAM", OracleType.Number).Value = pNAM;
                objCmd.Parameters.Add("pTL", OracleType.Number).Value = pTL;
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
        public DataTable SELECT_THONGTIN_TRAM_TLTT_B10_TEMP_Check(string pMA_DVIQLY, string pMA_TRAM, int pTHANG, int pNAM, float pTL)
        {
            DataTable dt = new DataTable();
            OracleConnection objConn = new OracleConnection(ConnectString.ConnectionString(""));
            OracleCommand objCmd = new OracleCommand();
            try
            {
                objConn.Open();
                objCmd.Connection = objConn;
                objCmd.CommandText = "PKG_TTTT_CTT.SELECT_THONGTIN_TRAM_TLTT_B10_TEMP_Check";
                objCmd.CommandType = CommandType.StoredProcedure;
                objCmd.Parameters.Add("pMA_DVIQLY", OracleType.VarChar).Value = pMA_DVIQLY;
                objCmd.Parameters.Add("pMA_TRAM", OracleType.VarChar).Value = pMA_TRAM;
                objCmd.Parameters.Add("pTHANG", OracleType.Number).Value = pTHANG;
                objCmd.Parameters.Add("pNAM", OracleType.Number).Value = pNAM;
                objCmd.Parameters.Add("pTL", OracleType.Number).Value = pTL;
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

        public DataTable SELECT_THONGTIN_TRAM_TLTT_B10_TEMP_BC(string pMA_DVIQLY, int pTHANG, int pNAM, float pTL)
        {
            DataTable dt = new DataTable();
            OracleConnection objConn = new OracleConnection(ConnectString.ConnectionString(""));
            OracleCommand objCmd = new OracleCommand();
            try
            {
                objConn.Open();
                objCmd.Connection = objConn;
                objCmd.CommandText = "PKG_TTTT_CTT.SELECT_THONGTIN_TRAM_TLTT_B10_TEMP_BC";
                objCmd.CommandType = CommandType.StoredProcedure;
                objCmd.Parameters.Add("pMA_DVIQLY", OracleType.VarChar).Value = pMA_DVIQLY;
                objCmd.Parameters.Add("pTHANG", OracleType.Number).Value = pTHANG;
                objCmd.Parameters.Add("pNAM", OracleType.Number).Value = pNAM;
                objCmd.Parameters.Add("pTL", OracleType.Number).Value = pTL;
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
        public DataTable SELECT_THONGTIN_TRAM_TLTT_B10_CHECK(string pMA_DVIQLY, string pMA_TRAM, int pTHANG, int pNAM)
        {
            DataTable dt = new DataTable();
            OracleConnection objConn = new OracleConnection(ConnectString.ConnectionString(""));
            OracleCommand objCmd = new OracleCommand();
            try
            {
                objConn.Open();
                objCmd.Connection = objConn;
                objCmd.CommandText = "PKG_TTTT_CTT.SELECT_THONGTIN_TRAM_TLTT_B10_CHECK";
                objCmd.CommandType = CommandType.StoredProcedure;
                objCmd.Parameters.Add("pMA_DVIQLY", OracleType.VarChar).Value = pMA_DVIQLY;
                objCmd.Parameters.Add("pMA_TRAM", OracleType.VarChar).Value = pMA_TRAM;
                objCmd.Parameters.Add("pTHANG", OracleType.Number).Value = pTHANG;
                objCmd.Parameters.Add("pNAM", OracleType.Number).Value = pNAM;
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

        public void DELETE_KHANG_PHUCTRA_TRAM(string pMA_DVIQLY, string pMA_TRAM, string pLOAI_CS, string pLOAI_BCS,int pTHANG, int pNAM, int pKY)
        {
            DataTable dt = new DataTable();
            OracleConnection objConn = new OracleConnection(ConnectString.ConnectionString(""));
            OracleCommand objCmd = new OracleCommand();
            try
            {
                objConn.Open();
                objCmd.Connection = objConn;
                objCmd.CommandText = "PKG_TTTT_CTT.DELETE_KHANG_PHUCTRA_TRAM";
                objCmd.CommandType = CommandType.StoredProcedure;
                objCmd.Parameters.Add("pMA_DVIQLY", OracleType.VarChar).Value = pMA_DVIQLY;
                objCmd.Parameters.Add("pMA_TRAM", OracleType.VarChar).Value = pMA_TRAM;
                objCmd.Parameters.Add("pLOAI_CS", OracleType.VarChar).Value = pLOAI_CS;
                objCmd.Parameters.Add("pLOAI_BCS", OracleType.VarChar).Value = pLOAI_BCS;
                objCmd.Parameters.Add("pTHANG", OracleType.Number).Value = pTHANG;
                objCmd.Parameters.Add("pNAM", OracleType.Number).Value = pNAM;
                objCmd.Parameters.Add("pKY", OracleType.Number).Value = pKY;
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
        public DataTable SELECT_THONGTIN_TRAM_TLTT_ALL(string pMA_DVIQLY, int pTHANG, int pNAM, int pTHANG1, int pNAM1, int pTHANG2, int pNAM2, int pTHANG3, int pNAM3, float pTyLeSS, float tylebt, float SL)
        {
            DataTable dt = new DataTable();
            OracleConnection objConn = new OracleConnection(ConnectString.ConnectionString(""));
            OracleCommand objCmd = new OracleCommand();
            try
            {
                objConn.Open();
                objCmd.Connection = objConn;
                objCmd.CommandText = "PKG_TTTT_CTT.SELECT_THONGTIN_TRAM_TLTT_ALL";
                objCmd.CommandType = CommandType.StoredProcedure;
                objCmd.Parameters.Add("pMA_DVIQLY", OracleType.VarChar).Value = pMA_DVIQLY;
                objCmd.Parameters.Add("pTHANG", OracleType.Number).Value = pTHANG;
                objCmd.Parameters.Add("pNAM", OracleType.Number).Value = pNAM;
                objCmd.Parameters.Add("pTHANG1", OracleType.Number).Value = pTHANG1;
                objCmd.Parameters.Add("pNAM1", OracleType.Number).Value = pNAM1;
                objCmd.Parameters.Add("pTHANG2", OracleType.Number).Value = pTHANG2;
                objCmd.Parameters.Add("pNAM2", OracleType.Number).Value = pNAM2;
                objCmd.Parameters.Add("pTHANG3", OracleType.Number).Value = pTHANG3;
                objCmd.Parameters.Add("pNAM3", OracleType.Number).Value = pNAM3;
                objCmd.Parameters.Add("pTyLeSS", OracleType.Number).Value = pTyLeSS;
                objCmd.Parameters.Add("pTYLEBT", OracleType.Number).Value = tylebt;
                objCmd.Parameters.Add("pSL", OracleType.Number).Value = SL;
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
        public void Insert_User_Login_Log(string pMA_DVIQLY, string pPHANLOAI, string pAPP_WEB, string pUSERDN, DateTime pTHOIGIANDN, int pTHANG, int pNAM)
        {
            DataTable dt = new DataTable();
            OracleConnection objConn = new OracleConnection(ConnectString.ConnectionString(pMA_DVIQLY));
            OracleCommand objCmd = new OracleCommand();
            try
            {
                objConn.Open();
                objCmd.Connection = objConn;
                objCmd.CommandText = "PKG_USER_GCS_UDHT.USER_LOGIN_LOG";
                objCmd.CommandType = CommandType.StoredProcedure;
                objCmd.Parameters.Add("pMA_DVIQLY", OracleType.VarChar).Value = pMA_DVIQLY;
                objCmd.Parameters.Add("pPHANLOAI", OracleType.VarChar).Value = pPHANLOAI;
                objCmd.Parameters.Add("pAPP_WEB", OracleType.VarChar).Value = pAPP_WEB;
                objCmd.Parameters.Add("pUSERDN", OracleType.VarChar).Value = pUSERDN;
                objCmd.Parameters.Add("pTHOIGIANDN", OracleType.DateTime).Value = pTHOIGIANDN;
                objCmd.Parameters.Add("pTHANG", OracleType.Number).Value = pTHANG;
                objCmd.Parameters.Add("pNAM", OracleType.Number).Value = pNAM;
                objCmd.ExecuteReader();
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

        }
    }
}
