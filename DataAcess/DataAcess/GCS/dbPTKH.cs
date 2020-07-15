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
    public class dbPTKH
    {

        public DataTable CHECKSOMOI(string pMA_DVIQLY, string PUSERNAME, DateTime PNGAYTH, int PTHANG, int PNGAY, int PNAM, string PIMEI, string PLOAI)
        {
            DataTable dt = new DataTable(); OracleConnection objConn = new OracleConnection(ConnectString.ConnectionString(pMA_DVIQLY));
            OracleCommand objCmd = new OracleCommand();
            try
            {
                objConn.Open();
                objCmd.Connection = objConn;
                objCmd.CommandText = "PKG_TBDD_PTKH.CHECKSOMOI"; objCmd.CommandType = CommandType.StoredProcedure;
                objCmd.Parameters.Add("pMA_DVIQLY", OracleType.VarChar).Value = pMA_DVIQLY;
                objCmd.Parameters.Add("pUSERNAME", OracleType.VarChar).Value = PUSERNAME;
                objCmd.Parameters.Add("pNGAYTH", OracleType.DateTime).Value = PNGAYTH; objCmd.Parameters.Add("pTHANG", OracleType.Number).Value = PTHANG;
                objCmd.Parameters.Add("pNGAY", OracleType.Number).Value = PNGAY;
                objCmd.Parameters.Add("pNAM", OracleType.Number).Value = PNAM;
                objCmd.Parameters.Add("pIMEI", OracleType.VarChar).Value = PIMEI;
                objCmd.Parameters.Add("pLOAI", OracleType.VarChar).Value = PLOAI;
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
        public void CHOT_EVN(string pMA_DVIQLY, string PMA_YCAU_KNAI)
        {
            OracleConnection objConn = new OracleConnection(ConnectString.ConnectionString(pMA_DVIQLY));
            OracleCommand objCmd = new OracleCommand();
            try
            {
                objConn.Open();
                objCmd.Connection = objConn;
                objCmd.CommandText = "PKG_TBDD_PTKH.CHOT_EVN"; objCmd.CommandType = CommandType.StoredProcedure;
                objCmd.Parameters.Add("pMA_DVIQLY", OracleType.VarChar).Value = pMA_DVIQLY;
                objCmd.Parameters.Add("pMA_YCAU_KNAI", OracleType.VarChar).Value = PMA_YCAU_KNAI;

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
        public void CHOT_KHANG(string pMA_DVIQLY, int PSOLUONG)
        {
            OracleConnection objConn = new OracleConnection(ConnectString.ConnectionString(pMA_DVIQLY));
            OracleCommand objCmd = new OracleCommand();
            try
            {
                objConn.Open();
                objCmd.Connection = objConn;
                objCmd.CommandText = "PKG_TBDD_PTKH.CHOT_KHANG"; objCmd.CommandType = CommandType.StoredProcedure;
                objCmd.Parameters.Add("pMA_DVIQLY", OracleType.VarChar).Value = pMA_DVIQLY;
                objCmd.Parameters.Add("pSOLUONG", OracleType.Number).Value = PSOLUONG;

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
        public void CHUYEN_DL_CMIS(string pMA_DVIQLY, string PMA_KHANG_ID, DateTime PNGAY_KS)
        {
            OracleConnection objConn = new OracleConnection(ConnectString.ConnectionString(pMA_DVIQLY));
            OracleCommand objCmd = new OracleCommand();
            try
            {
                objConn.Open();
                objCmd.Connection = objConn;
                objCmd.CommandText = "PKG_TBDD_PTKH.CHUYEN_DL_CMIS"; objCmd.CommandType = CommandType.StoredProcedure;
                objCmd.Parameters.Add("pMA_DVIQLY", OracleType.VarChar).Value = pMA_DVIQLY;
                objCmd.Parameters.Add("pMA_KHANG_ID", OracleType.VarChar).Value = PMA_KHANG_ID;
                objCmd.Parameters.Add("pNGAY_KS", OracleType.DateTime).Value = PNGAY_KS;
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
        public void CHUYEN_NHOMDM_DV(string pMA_DVIQLY, string PMA_NHOM)
        {
            OracleConnection objConn = new OracleConnection(ConnectString.ConnectionString(pMA_DVIQLY));
            OracleCommand objCmd = new OracleCommand();
            try
            {
                objConn.Open();
                objCmd.Connection = objConn;
                objCmd.CommandText = "PKG_TBDD_PTKH.CHUYEN_NHOMDM_DV"; objCmd.CommandType = CommandType.StoredProcedure;
                objCmd.Parameters.Add("pMA_DVIQLY", OracleType.VarChar).Value = pMA_DVIQLY;
                objCmd.Parameters.Add("pMA_NHOM", OracleType.VarChar).Value = PMA_NHOM;

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
        public void DELETE_KH_MDICH_SD(string pMA_DVIQLY, string PMA_KHANG_ID)
        {
            OracleConnection objConn = new OracleConnection(ConnectString.ConnectionString(pMA_DVIQLY));
            OracleCommand objCmd = new OracleCommand();
            try
            {
                objConn.Open();
                objCmd.Connection = objConn;
                objCmd.CommandText = "PKG_TBDD_PTKH.DELETE_KH_MDICH_SD"; objCmd.CommandType = CommandType.StoredProcedure;
                objCmd.Parameters.Add("pMA_DVIQLY", OracleType.VarChar).Value = pMA_DVIQLY;
                objCmd.Parameters.Add("pMA_KHANG_ID", OracleType.VarChar).Value = PMA_KHANG_ID;

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
        public void DELETE_KH_MDICH_SD_BYID(string pMA_DVIQLY, string PMA_KHANG_ID, int PID)
        {
            OracleConnection objConn = new OracleConnection(ConnectString.ConnectionString(pMA_DVIQLY));
            OracleCommand objCmd = new OracleCommand();
            try
            {
                objConn.Open();
                objCmd.Connection = objConn;
                objCmd.CommandText = "PKG_TBDD_PTKH.DELETE_KH_MDICH_SD_BYID"; objCmd.CommandType = CommandType.StoredProcedure;
                objCmd.Parameters.Add("pMA_DVIQLY", OracleType.VarChar).Value = pMA_DVIQLY;
                objCmd.Parameters.Add("pMA_KHANG_ID", OracleType.VarChar).Value = PMA_KHANG_ID;
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
        public void DELETE_KH_PHAN_NV(string pMA_DVIQLY, string PIDKH)
        {
            OracleConnection objConn = new OracleConnection(ConnectString.ConnectionString(pMA_DVIQLY));
            OracleCommand objCmd = new OracleCommand();
            try
            {
                objConn.Open();
                objCmd.Connection = objConn;
                objCmd.CommandText = "PKG_TBDD_PTKH.DELETE_KH_PHAN_NV"; objCmd.CommandType = CommandType.StoredProcedure;
                objCmd.Parameters.Add("pMA_DVIQLY", OracleType.VarChar).Value = pMA_DVIQLY;
                objCmd.Parameters.Add("pIDKH", OracleType.VarChar).Value = PIDKH;

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
        public void DELETE_KH_VATTU(string PMA_KHANG_ID, string pMA_DVIQLY)
        {
            OracleConnection objConn = new OracleConnection(ConnectString.ConnectionString(pMA_DVIQLY));
            OracleCommand objCmd = new OracleCommand();
            try
            {
                objConn.Open();
                objCmd.Connection = objConn;
                objCmd.CommandText = "PKG_TBDD_PTKH.DELETE_KH_VATTU"; objCmd.CommandType = CommandType.StoredProcedure;
                objCmd.Parameters.Add("pMA_KHANG_ID", OracleType.VarChar).Value = PMA_KHANG_ID;
                objCmd.Parameters.Add("pMA_DVIQLY", OracleType.VarChar).Value = pMA_DVIQLY;

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
        public void DELETE_KH_VATTU_BYID(string PMA_KHANG_ID, string pMA_DVIQLY, int PID)
        {
            OracleConnection objConn = new OracleConnection(ConnectString.ConnectionString(pMA_DVIQLY));
            OracleCommand objCmd = new OracleCommand();
            try
            {
                objConn.Open();
                objCmd.Connection = objConn;
                objCmd.CommandText = "PKG_TBDD_PTKH.DELETE_KH_VATTU_BYID"; objCmd.CommandType = CommandType.StoredProcedure;
                objCmd.Parameters.Add("pMA_KHANG_ID", OracleType.VarChar).Value = PMA_KHANG_ID;
                objCmd.Parameters.Add("pMA_DVIQLY", OracleType.VarChar).Value = pMA_DVIQLY;
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
        public void DELETE_NHOMVATU(string pMA_DVIQLY, string PMA_NHOM)
        {
            OracleConnection objConn = new OracleConnection(ConnectString.ConnectionString(pMA_DVIQLY));
            OracleCommand objCmd = new OracleCommand();
            try
            {
                objConn.Open();
                objCmd.Connection = objConn;
                objCmd.CommandText = "PKG_TBDD_PTKH.DELETE_NHOMVATU"; objCmd.CommandType = CommandType.StoredProcedure;
                objCmd.Parameters.Add("pMA_DVIQLY", OracleType.VarChar).Value = pMA_DVIQLY;
                objCmd.Parameters.Add("pMA_NHOM", OracleType.VarChar).Value = PMA_NHOM;

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
        public void DELETE_NHOMVATU_SD(string pMA_DVIQLY, int PID)
        {
            OracleConnection objConn = new OracleConnection(ConnectString.ConnectionString(pMA_DVIQLY));
            OracleCommand objCmd = new OracleCommand();
            try
            {
                objConn.Open();
                objCmd.Connection = objConn;
                objCmd.CommandText = "PKG_TBDD_PTKH.DELETE_NHOMVATU_SD"; objCmd.CommandType = CommandType.StoredProcedure;
                objCmd.Parameters.Add("pMA_DVIQLY", OracleType.VarChar).Value = pMA_DVIQLY;
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
        public void DELETE_TBDD_PTKH_KH_SDDIEN(string PMA_KHANG_ID, string pMA_DVIQLY)
        {
            OracleConnection objConn = new OracleConnection(ConnectString.ConnectionString(pMA_DVIQLY));
            OracleCommand objCmd = new OracleCommand();
            try
            {
                objConn.Open();
                objCmd.Connection = objConn;
                objCmd.CommandText = "PKG_TBDD_PTKH.DELETE_TBDD_PTKH_KH_SDDIEN"; objCmd.CommandType = CommandType.StoredProcedure;
                objCmd.Parameters.Add("pMA_KHANG_ID", OracleType.VarChar).Value = PMA_KHANG_ID;
                objCmd.Parameters.Add("pMA_DVIQLY", OracleType.VarChar).Value = pMA_DVIQLY;

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
        public void DELETE_TBDD_PTKH_SAMPLE(string pMA_DVIQLY, string PLOAICT, string PMDICH_SDUNG)
        {
            OracleConnection objConn = new OracleConnection(ConnectString.ConnectionString(pMA_DVIQLY));
            OracleCommand objCmd = new OracleCommand();
            try
            {
                objConn.Open();
                objCmd.Connection = objConn;
                objCmd.CommandText = "PKG_TBDD_PTKH.DELETE_TBDD_PTKH_SAMPLE"; objCmd.CommandType = CommandType.StoredProcedure;
                objCmd.Parameters.Add("pMA_DVIQLY", OracleType.VarChar).Value = pMA_DVIQLY;
                objCmd.Parameters.Add("pLOAICT", OracleType.VarChar).Value = PLOAICT;
                objCmd.Parameters.Add("pMDICH_SDUNG", OracleType.VarChar).Value = PMDICH_SDUNG;

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
        public void DELETE_TBDD_PTKH_SAMPLE_TBSDD(string pMA_DVIQLY, string PLOAICT, string PMA_VT)
        {
            OracleConnection objConn = new OracleConnection(ConnectString.ConnectionString(pMA_DVIQLY));
            OracleCommand objCmd = new OracleCommand();
            try
            {
                objConn.Open();
                objCmd.Connection = objConn;
                objCmd.CommandText = "PKG_TBDD_PTKH.DELETE_TBDD_PTKH_SAMPLE_TBSDD"; objCmd.CommandType = CommandType.StoredProcedure;
                objCmd.Parameters.Add("pMA_DVIQLY", OracleType.VarChar).Value = pMA_DVIQLY;
                objCmd.Parameters.Add("pLOAICT", OracleType.VarChar).Value = PLOAICT;
                objCmd.Parameters.Add("pMA_VT", OracleType.VarChar).Value = PMA_VT;

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
        public void DELETE_TBDD_PTKH_SAMPLE_VATTU(string pMA_DVIQLY, string PLOAICT, string PMA_VT, string PCAPTRUOC_CTO)
        {
            OracleConnection objConn = new OracleConnection(ConnectString.ConnectionString(pMA_DVIQLY));
            OracleCommand objCmd = new OracleCommand();
            try
            {
                objConn.Open();
                objCmd.Connection = objConn;
                objCmd.CommandText = "PKG_TBDD_PTKH.DELETE_TBDD_PTKH_SAMPLE_VATTU"; objCmd.CommandType = CommandType.StoredProcedure;
                objCmd.Parameters.Add("pMA_DVIQLY", OracleType.VarChar).Value = pMA_DVIQLY;
                objCmd.Parameters.Add("pLOAICT", OracleType.VarChar).Value = PLOAICT;
                objCmd.Parameters.Add("pMA_VT", OracleType.VarChar).Value = PMA_VT;
                objCmd.Parameters.Add("pCAPTRUOC_CTO", OracleType.VarChar).Value = PCAPTRUOC_CTO;

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
        public void DELETE_TBDD_PTKH_VATTU_FMIS(string pMA_DVIQLY, string PIN)
        {
            OracleConnection objConn = new OracleConnection(ConnectString.ConnectionString(pMA_DVIQLY));
            OracleCommand objCmd = new OracleCommand();
            try
            {
                objConn.Open();
                objCmd.Connection = objConn;
                objCmd.CommandText = "PKG_TBDD_PTKH.DELETE_TBDD_PTKH_VATTU_FMIS"; objCmd.CommandType = CommandType.StoredProcedure;
                objCmd.Parameters.Add("pIN", OracleType.VarChar).Value = PIN;

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
        public void DELETE_TBDD_PTKH_YCAU_VT(string pMA_DVIQLY, string PSO_YCAU)
        {
            OracleConnection objConn = new OracleConnection(ConnectString.ConnectionString(pMA_DVIQLY));
            OracleCommand objCmd = new OracleCommand();
            try
            {
                objConn.Open();
                objCmd.Connection = objConn;
                objCmd.CommandText = "PKG_TBDD_PTKH.DELETE_TBDD_PTKH_YCAU_VT"; objCmd.CommandType = CommandType.StoredProcedure;
                objCmd.Parameters.Add("pMA_DVIQLY", OracleType.VarChar).Value = pMA_DVIQLY;
                objCmd.Parameters.Add("pSO_YCAU", OracleType.VarChar).Value = PSO_YCAU;

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
        public void DELETE_TB_NV(string pMA_DVIQLY, int PTHANG, int PNAM, int PNGAY, string PMA_NVIEN, string PLOAI_DN)
        {
            OracleConnection objConn = new OracleConnection(ConnectString.ConnectionString(pMA_DVIQLY));
            OracleCommand objCmd = new OracleCommand();
            try
            {
                objConn.Open();
                objCmd.Connection = objConn;
                objCmd.CommandText = "PKG_TBDD_PTKH.DELETE_TB_NV"; objCmd.CommandType = CommandType.StoredProcedure;
                objCmd.Parameters.Add("pMA_DVIQLY", OracleType.VarChar).Value = pMA_DVIQLY;
                objCmd.Parameters.Add("pTHANG", OracleType.Number).Value = PTHANG;
                objCmd.Parameters.Add("pNAM", OracleType.Number).Value = PNAM;
                objCmd.Parameters.Add("pNGAY", OracleType.Number).Value = PNGAY;
                objCmd.Parameters.Add("pMA_NVIEN", OracleType.VarChar).Value = PMA_NVIEN;
                objCmd.Parameters.Add("pLOAI_DN", OracleType.VarChar).Value = PLOAI_DN;

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
        public void DELETE_VATTU_BY_IDVT(string PMA_KHANG_ID, string pMA_DVIQLY, int PID_VTKHANG, string PIS_TRUOC)
        {
            OracleConnection objConn = new OracleConnection(ConnectString.ConnectionString(pMA_DVIQLY));
            OracleCommand objCmd = new OracleCommand();
            try
            {
                objConn.Open();
                objCmd.Connection = objConn;
                objCmd.CommandText = "PKG_TBDD_PTKH.DELETE_VATTU_BY_IDVT"; objCmd.CommandType = CommandType.StoredProcedure;
                objCmd.Parameters.Add("pMA_KHANG_ID", OracleType.VarChar).Value = PMA_KHANG_ID;
                objCmd.Parameters.Add("pMA_DVIQLY", OracleType.VarChar).Value = pMA_DVIQLY;
                objCmd.Parameters.Add("pID_VTKHANG", OracleType.Number).Value = PID_VTKHANG;
                objCmd.Parameters.Add("pIS_TRUOC", OracleType.VarChar).Value = PIS_TRUOC;

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
        public void DELETE_VATU(string pMA_DVIQLY, string PMA_VT, string PMA_NHOM, string PID, string PMANSX)
        {
            OracleConnection objConn = new OracleConnection(ConnectString.ConnectionString(pMA_DVIQLY));
            OracleCommand objCmd = new OracleCommand();
            try
            {
                objConn.Open();
                objCmd.Connection = objConn;
                objCmd.CommandText = "PKG_TBDD_PTKH.DELETE_VATU"; objCmd.CommandType = CommandType.StoredProcedure;
                objCmd.Parameters.Add("pMA_DVIQLY", OracleType.VarChar).Value = pMA_DVIQLY;
                objCmd.Parameters.Add("pMA_VT", OracleType.VarChar).Value = PMA_VT;
                objCmd.Parameters.Add("pMA_NHOM", OracleType.VarChar).Value = PMA_NHOM;
                objCmd.Parameters.Add("pID", OracleType.VarChar).Value = PID;
                objCmd.Parameters.Add("pMANSX", OracleType.VarChar).Value = PMANSX;

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
        public void DELETE_VATU_SD(string pMA_DVIQLY, string PID)
        {
            OracleConnection objConn = new OracleConnection(ConnectString.ConnectionString(pMA_DVIQLY));
            OracleCommand objCmd = new OracleCommand();
            try
            {
                objConn.Open();
                objCmd.Connection = objConn;
                objCmd.CommandText = "PKG_TBDD_PTKH.DELETE_VATU_SD"; objCmd.CommandType = CommandType.StoredProcedure;
                objCmd.Parameters.Add("pMA_DVIQLY", OracleType.VarChar).Value = pMA_DVIQLY;
                objCmd.Parameters.Add("pID", OracleType.VarChar).Value = PID;

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
        public void GET_KH_FROMCMIS(string pMA_DVIQLY, string PMA_YCAU_KNAI, string PMA_LOAI_YCAU, int PTINH_TRANG, string PMA_LOAIHD, string PNGAY_GCS, string PMASO_THUE, string PTLE_THUE, string PLOAI_KHANG, string PLOAI_DDO, string PTAI_KHOAN, string PNGAN_HANG, string PMA_CAPDA, string PMA_SOGCS, string PSTT, string PKIMUA_CSPK, string PCSUAT, int PSO_PHA, string PSO_HO, string PSO_CMT, DateTime PNGAY_CAP, string PDTHOAI_DD, string PDTHOAI_CD, string PFAX, string PEMAIL, string PWEBSITE, string PUSER, DateTime PNGAYHEN_KSAT, string PNOI_CAP)
        {
            OracleConnection objConn = new OracleConnection(ConnectString.ConnectionString(pMA_DVIQLY));
            OracleCommand objCmd = new OracleCommand();
            try
            {
                objConn.Open();
                objCmd.Connection = objConn;
                objCmd.CommandText = "PKG_TBDD_PTKH.GET_KH_FROMCMIS"; objCmd.CommandType = CommandType.StoredProcedure;
                objCmd.Parameters.Add("pMA_DVIQLY", OracleType.VarChar).Value = pMA_DVIQLY;
                objCmd.Parameters.Add("pMA_YCAU_KNAI", OracleType.VarChar).Value = PMA_YCAU_KNAI;
                objCmd.Parameters.Add("pMA_LOAI_YCAU", OracleType.VarChar).Value = PMA_LOAI_YCAU;
                objCmd.Parameters.Add("pTINH_TRANG", OracleType.Number).Value = PTINH_TRANG;
                objCmd.Parameters.Add("pMA_LOAIHD", OracleType.VarChar).Value = PMA_LOAIHD;
                objCmd.Parameters.Add("pNGAY_GCS", OracleType.VarChar).Value = PNGAY_GCS;
                objCmd.Parameters.Add("pMASO_THUE", OracleType.VarChar).Value = PMASO_THUE;
                objCmd.Parameters.Add("pTLE_THUE", OracleType.VarChar).Value = PTLE_THUE;
                objCmd.Parameters.Add("pLOAI_KHANG", OracleType.VarChar).Value = PLOAI_KHANG;
                objCmd.Parameters.Add("pLOAI_DDO", OracleType.VarChar).Value = PLOAI_DDO;
                objCmd.Parameters.Add("pTAI_KHOAN", OracleType.VarChar).Value = PTAI_KHOAN;
                objCmd.Parameters.Add("pNGAN_HANG", OracleType.VarChar).Value = PNGAN_HANG;
                objCmd.Parameters.Add("pMA_CAPDA", OracleType.VarChar).Value = PMA_CAPDA;
                objCmd.Parameters.Add("pMA_SOGCS", OracleType.VarChar).Value = PMA_SOGCS;
                objCmd.Parameters.Add("pSTT", OracleType.VarChar).Value = PSTT;
                objCmd.Parameters.Add("pKIMUA_CSPK", OracleType.VarChar).Value = PKIMUA_CSPK;
                objCmd.Parameters.Add("pCSUAT", OracleType.VarChar).Value = PCSUAT;
                objCmd.Parameters.Add("pSO_PHA", OracleType.Number).Value = PSO_PHA;
                objCmd.Parameters.Add("pSO_HO", OracleType.VarChar).Value = PSO_HO;
                objCmd.Parameters.Add("pSO_CMT", OracleType.VarChar).Value = PSO_CMT;
                objCmd.Parameters.Add("pNGAY_CAP", OracleType.DateTime).Value = PNGAY_CAP; objCmd.Parameters.Add("pDTHOAI_DD", OracleType.VarChar).Value = PDTHOAI_DD;
                objCmd.Parameters.Add("pDTHOAI_CD", OracleType.VarChar).Value = PDTHOAI_CD;
                objCmd.Parameters.Add("pFAX", OracleType.VarChar).Value = PFAX;
                objCmd.Parameters.Add("pEMAIL", OracleType.VarChar).Value = PEMAIL;
                objCmd.Parameters.Add("pWEBSITE", OracleType.VarChar).Value = PWEBSITE;
                objCmd.Parameters.Add("pUSER", OracleType.VarChar).Value = PUSER;
                objCmd.Parameters.Add("pNGAYHEN_KSAT", OracleType.DateTime).Value = PNGAYHEN_KSAT; objCmd.Parameters.Add("pNOI_CAP", OracleType.VarChar).Value = PNOI_CAP;

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
        public DataTable GET_KH_FROMNPCUS(string pMA_DVIQLY, string PMA_YCAU_KNAI)
        {
            DataTable dt = new DataTable(); OracleConnection objConn = new OracleConnection(ConnectString.ConnectionString(pMA_DVIQLY));
            OracleCommand objCmd = new OracleCommand();
            try
            {
                objConn.Open();
                objCmd.Connection = objConn;
                objCmd.CommandText = "PKG_TBDD_PTKH.GET_KH_FROMNPCUS"; objCmd.CommandType = CommandType.StoredProcedure;
                objCmd.Parameters.Add("pMA_DVIQLY", OracleType.VarChar).Value = pMA_DVIQLY;
                objCmd.Parameters.Add("pMA_YCAU_KNAI", OracleType.VarChar).Value = PMA_YCAU_KNAI;
                objCmd.Parameters.Add("RS1", OracleType.Cursor).Direction = ParameterDirection.Output; objCmd.Parameters.Add("RS2", OracleType.Cursor).Direction = ParameterDirection.Output;
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
        public DataTable GET_REPLACE(string pMA_DVIQLY, string PMA_YCAU_KNAI)
        {
            DataTable dt = new DataTable(); OracleConnection objConn = new OracleConnection(ConnectString.ConnectionString(pMA_DVIQLY));
            OracleCommand objCmd = new OracleCommand();
            try
            {
                objConn.Open();
                objCmd.Connection = objConn;
                objCmd.CommandText = "PKG_TBDD_PTKH.GET_REPLACE"; objCmd.CommandType = CommandType.StoredProcedure;
                objCmd.Parameters.Add("pMA_DVIQLY", OracleType.VarChar).Value = pMA_DVIQLY;
                objCmd.Parameters.Add("pMA_YCAU_KNAI", OracleType.VarChar).Value = PMA_YCAU_KNAI;
                objCmd.Parameters.Add("rs", OracleType.Cursor).Direction = ParameterDirection.Output; objCmd.Parameters.Add("RS2", OracleType.Cursor).Direction = ParameterDirection.Output;
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
        public void INSERT_CONGTHUC(string pMA_DVIQLY, string PMA_CT, string PTEN_CT, string PCONG_THUC, int PVITRI_ORDER, int PSO_PHA)
        {
            OracleConnection objConn = new OracleConnection(ConnectString.ConnectionString(pMA_DVIQLY));
            OracleCommand objCmd = new OracleCommand();
            try
            {
                objConn.Open();
                objCmd.Connection = objConn;
                objCmd.CommandText = "PKG_TBDD_PTKH.INSERT_CONGTHUC"; objCmd.CommandType = CommandType.StoredProcedure;
                objCmd.Parameters.Add("pMA_DVIQLY", OracleType.VarChar).Value = pMA_DVIQLY;
                objCmd.Parameters.Add("pMA_CT", OracleType.VarChar).Value = PMA_CT;
                objCmd.Parameters.Add("pTEN_CT", OracleType.VarChar).Value = PTEN_CT;
                objCmd.Parameters.Add("pCONG_THUC", OracleType.VarChar).Value = PCONG_THUC;
                objCmd.Parameters.Add("pVITRI_ORDER", OracleType.Number).Value = PVITRI_ORDER;
                objCmd.Parameters.Add("pSO_PHA", OracleType.Number).Value = PSO_PHA;

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
        public void INSERT_KH_MDICH_SD(string pMA_DVIQLY, string PMA_KHANG_ID, int PCONG_SUAT, int PTY_LE, string PMDICH_SDUNG, string PLOAI_TYLE)
        {
            OracleConnection objConn = new OracleConnection(ConnectString.ConnectionString(pMA_DVIQLY));
            OracleCommand objCmd = new OracleCommand();
            try
            {
                objConn.Open();
                objCmd.Connection = objConn;
                objCmd.CommandText = "PKG_TBDD_PTKH.INSERT_KH_MDICH_SD"; objCmd.CommandType = CommandType.StoredProcedure;
                objCmd.Parameters.Add("pMA_DVIQLY", OracleType.VarChar).Value = pMA_DVIQLY;
                objCmd.Parameters.Add("pMA_KHANG_ID", OracleType.VarChar).Value = PMA_KHANG_ID;
                objCmd.Parameters.Add("pCONG_SUAT", OracleType.Number).Value = PCONG_SUAT;
                objCmd.Parameters.Add("pTY_LE", OracleType.Number).Value = PTY_LE;
                objCmd.Parameters.Add("pMDICH_SDUNG", OracleType.VarChar).Value = PMDICH_SDUNG;
                objCmd.Parameters.Add("pLOAI_TYLE", OracleType.VarChar).Value = PLOAI_TYLE;

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
        public void INSERT_KH_PHAN_NV(string pMA_DVIQLY, string PIDKH, string PMA_NVIEN, string PTEN_NVIEN, DateTime PNGAY_KS)
        {
            OracleConnection objConn = new OracleConnection(ConnectString.ConnectionString(pMA_DVIQLY));
            OracleCommand objCmd = new OracleCommand();
            try
            {
                objConn.Open();
                objCmd.Connection = objConn;
                objCmd.CommandText = "PKG_TBDD_PTKH.INSERT_KH_PHAN_NV"; objCmd.CommandType = CommandType.StoredProcedure;
                objCmd.Parameters.Add("pMA_DVIQLY", OracleType.VarChar).Value = pMA_DVIQLY;
                objCmd.Parameters.Add("pIDKH", OracleType.VarChar).Value = PIDKH;
                objCmd.Parameters.Add("pMA_NVIEN", OracleType.VarChar).Value = PMA_NVIEN;
                objCmd.Parameters.Add("pTEN_NVIEN", OracleType.VarChar).Value = PTEN_NVIEN;
                objCmd.Parameters.Add("pNGAY_KS", OracleType.DateTime).Value = PNGAY_KS;
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
        public void INSERT_KH_SAU_KS(string pMA_DVIQLY, string PMA_KHANG_ID, string PTEN_KHANG, string PDIACHI, string PEMAIL, string PDIEN_THOAI, int PCONG_SUAT, string PLOAI_CT, string PDONG_DIEN, string PDIEN_AP, string PCOT, string PLO, string PTBA, string PHOP_LAP, string PDIEU_KIEN, string PMA_NVIEN, string PSO_HO, DateTime PNGAY_KS, string PID_KH_INSERT, string PLOAI, DateTime PNGAY_LAP_KYHD, string PLOAISODO_CAPDIEN)
        {
            OracleConnection objConn = new OracleConnection(ConnectString.ConnectionString(pMA_DVIQLY));
            OracleCommand objCmd = new OracleCommand();
            try
            {
                objConn.Open();
                objCmd.Connection = objConn;
                objCmd.CommandText = "PKG_TBDD_PTKH.INSERT_KH_SAU_KS"; objCmd.CommandType = CommandType.StoredProcedure;
                objCmd.Parameters.Add("pMA_DVIQLY", OracleType.VarChar).Value = pMA_DVIQLY;
                objCmd.Parameters.Add("pMA_KHANG_ID", OracleType.VarChar).Value = PMA_KHANG_ID;
                objCmd.Parameters.Add("pTEN_KHANG", OracleType.VarChar).Value = PTEN_KHANG;
                objCmd.Parameters.Add("pDIACHI", OracleType.VarChar).Value = PDIACHI;
                objCmd.Parameters.Add("pEMAIL", OracleType.VarChar).Value = PEMAIL;
                objCmd.Parameters.Add("pDIEN_THOAI", OracleType.VarChar).Value = PDIEN_THOAI;
                objCmd.Parameters.Add("pCONG_SUAT", OracleType.Number).Value = PCONG_SUAT;
                objCmd.Parameters.Add("pLOAI_CT", OracleType.VarChar).Value = PLOAI_CT;
                objCmd.Parameters.Add("pDONG_DIEN", OracleType.VarChar).Value = PDONG_DIEN;
                objCmd.Parameters.Add("pDIEN_AP", OracleType.VarChar).Value = PDIEN_AP;
                objCmd.Parameters.Add("pCOT", OracleType.VarChar).Value = PCOT;
                objCmd.Parameters.Add("pLO", OracleType.VarChar).Value = PLO;
                objCmd.Parameters.Add("pTBA", OracleType.VarChar).Value = PTBA;
                objCmd.Parameters.Add("pHOP_LAP", OracleType.VarChar).Value = PHOP_LAP;
                objCmd.Parameters.Add("pDIEU_KIEN", OracleType.VarChar).Value = PDIEU_KIEN;
                objCmd.Parameters.Add("pMA_NVIEN", OracleType.VarChar).Value = PMA_NVIEN;
                objCmd.Parameters.Add("pSO_HO", OracleType.VarChar).Value = PSO_HO;
                objCmd.Parameters.Add("pNGAY_KS", OracleType.DateTime).Value = PNGAY_KS; objCmd.Parameters.Add("pID_KH_INSERT", OracleType.VarChar).Value = PID_KH_INSERT;
                objCmd.Parameters.Add("pLOAI", OracleType.VarChar).Value = PLOAI;
                objCmd.Parameters.Add("pNGAY_LAP_KYHD", OracleType.DateTime).Value = PNGAY_LAP_KYHD; objCmd.Parameters.Add("pLOAISODO_CAPDIEN", OracleType.VarChar).Value = PLOAISODO_CAPDIEN;

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
        public void INSERT_KH_SAU_KS_VA(string pMA_DVIQLY, string PMA_KHANG_ID, string PTEN_KHANG, string PDIACHI, string PEMAIL, string PDIEN_THOAI, int PCONG_SUAT, string PLOAI_CT, string PDONG_DIEN, string PDIEN_AP, string PCOT, string PLO, string PTBA, string PHOP_LAP, string PDIEU_KIEN, string PMA_NVIEN, string PSO_HO, DateTime PNGAY_KS, string PID_KH_INSERT, string PLOAI, DateTime PNGAY_LAP_KYHD, string PLOAISODO_CAPDIEN)
        {
            OracleConnection objConn = new OracleConnection(ConnectString.ConnectionString(pMA_DVIQLY));
            OracleCommand objCmd = new OracleCommand();
            try
            {
                objConn.Open();
                objCmd.Connection = objConn;
                objCmd.CommandText = "PKG_TBDD_PTKH.INSERT_KH_SAU_KS_VA"; objCmd.CommandType = CommandType.StoredProcedure;
                objCmd.Parameters.Add("pMA_DVIQLY", OracleType.VarChar).Value = pMA_DVIQLY;
                objCmd.Parameters.Add("pMA_KHANG_ID", OracleType.VarChar).Value = PMA_KHANG_ID;
                objCmd.Parameters.Add("pTEN_KHANG", OracleType.VarChar).Value = PTEN_KHANG;
                objCmd.Parameters.Add("pDIACHI", OracleType.VarChar).Value = PDIACHI;
                objCmd.Parameters.Add("pEMAIL", OracleType.VarChar).Value = PEMAIL;
                objCmd.Parameters.Add("pDIEN_THOAI", OracleType.VarChar).Value = PDIEN_THOAI;
                objCmd.Parameters.Add("pCONG_SUAT", OracleType.Number).Value = PCONG_SUAT;
                objCmd.Parameters.Add("pLOAI_CT", OracleType.VarChar).Value = PLOAI_CT;
                objCmd.Parameters.Add("pDONG_DIEN", OracleType.VarChar).Value = PDONG_DIEN;
                objCmd.Parameters.Add("pDIEN_AP", OracleType.VarChar).Value = PDIEN_AP;
                objCmd.Parameters.Add("pCOT", OracleType.VarChar).Value = PCOT;
                objCmd.Parameters.Add("pLO", OracleType.VarChar).Value = PLO;
                objCmd.Parameters.Add("pTBA", OracleType.VarChar).Value = PTBA;
                objCmd.Parameters.Add("pHOP_LAP", OracleType.VarChar).Value = PHOP_LAP;
                objCmd.Parameters.Add("pDIEU_KIEN", OracleType.VarChar).Value = PDIEU_KIEN;
                objCmd.Parameters.Add("pMA_NVIEN", OracleType.VarChar).Value = PMA_NVIEN;
                objCmd.Parameters.Add("pSO_HO", OracleType.VarChar).Value = PSO_HO;
                objCmd.Parameters.Add("pNGAY_KS", OracleType.DateTime).Value = PNGAY_KS; objCmd.Parameters.Add("pID_KH_INSERT", OracleType.VarChar).Value = PID_KH_INSERT;
                objCmd.Parameters.Add("pLOAI", OracleType.VarChar).Value = PLOAI;
                objCmd.Parameters.Add("pNGAY_LAP_KYHD", OracleType.DateTime).Value = PNGAY_LAP_KYHD; objCmd.Parameters.Add("pLOAISODO_CAPDIEN", OracleType.VarChar).Value = PLOAISODO_CAPDIEN;

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
        public void INSERT_KH_VATTU(string PMA_KHANG_ID, string pMA_DVIQLY, string PMA_VT, int PSO_LUONG, string PIS_THUHOI, string PIS_TRUOC, string PMANSX, string PID)
        {
            OracleConnection objConn = new OracleConnection(ConnectString.ConnectionString(pMA_DVIQLY));
            OracleCommand objCmd = new OracleCommand();
            try
            {
                objConn.Open();
                objCmd.Connection = objConn;
                objCmd.CommandText = "PKG_TBDD_PTKH.INSERT_KH_VATTU"; objCmd.CommandType = CommandType.StoredProcedure;
                objCmd.Parameters.Add("pMA_KHANG_ID", OracleType.VarChar).Value = PMA_KHANG_ID;
                objCmd.Parameters.Add("pMA_DVIQLY", OracleType.VarChar).Value = pMA_DVIQLY;
                objCmd.Parameters.Add("pMA_VT", OracleType.VarChar).Value = PMA_VT;
                objCmd.Parameters.Add("pSO_LUONG", OracleType.Number).Value = PSO_LUONG;
                objCmd.Parameters.Add("pIS_THUHOI", OracleType.VarChar).Value = PIS_THUHOI;
                objCmd.Parameters.Add("pIS_TRUOC", OracleType.VarChar).Value = PIS_TRUOC;
                objCmd.Parameters.Add("pMANSX", OracleType.VarChar).Value = PMANSX;
                objCmd.Parameters.Add("pID", OracleType.VarChar).Value = PID;

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
        public void INSERT_NHOMVATU(string pMA_DVIQLY, string PMA_NHOM, string PTEN_NHOM, string PMO_TA)
        {
            OracleConnection objConn = new OracleConnection(ConnectString.ConnectionString(pMA_DVIQLY));
            OracleCommand objCmd = new OracleCommand();
            try
            {
                objConn.Open();
                objCmd.Connection = objConn;
                objCmd.CommandText = "PKG_TBDD_PTKH.INSERT_NHOMVATU"; objCmd.CommandType = CommandType.StoredProcedure;
                objCmd.Parameters.Add("pMA_DVIQLY", OracleType.VarChar).Value = pMA_DVIQLY;
                objCmd.Parameters.Add("pMA_NHOM", OracleType.VarChar).Value = PMA_NHOM;
                objCmd.Parameters.Add("pTEN_NHOM", OracleType.VarChar).Value = PTEN_NHOM;
                objCmd.Parameters.Add("pMO_TA", OracleType.VarChar).Value = PMO_TA;

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
        public void INSERT_NHOMVATU_SD(string pMA_DVIQLY, string PMA_NHOM, string PTEN_NHOM, string PMO_TA)
        {
            OracleConnection objConn = new OracleConnection(ConnectString.ConnectionString(pMA_DVIQLY));
            OracleCommand objCmd = new OracleCommand();
            try
            {
                objConn.Open();
                objCmd.Connection = objConn;
                objCmd.CommandText = "PKG_TBDD_PTKH.INSERT_NHOMVATU_SD"; objCmd.CommandType = CommandType.StoredProcedure;
                objCmd.Parameters.Add("pMA_DVIQLY", OracleType.VarChar).Value = pMA_DVIQLY.Substring(0, 4);
                objCmd.Parameters.Add("pMA_NHOM", OracleType.VarChar).Value = PMA_NHOM;
                objCmd.Parameters.Add("pTEN_NHOM", OracleType.VarChar).Value = PTEN_NHOM;
                objCmd.Parameters.Add("pMO_TA", OracleType.VarChar).Value = PMO_TA;

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
        public void INSERT_TBDD_PTKH_KH_SDDIEN(string PMA_KHANG_ID, string pMA_DVIQLY, string PMUC_DICH, int PCONG_XUAT, int PSO_LUONG, int PDAY_SD, int PMONTH_SD, int PHOUR_SD, string PMA_VT)
        {
            OracleConnection objConn = new OracleConnection(ConnectString.ConnectionString(pMA_DVIQLY));
            OracleCommand objCmd = new OracleCommand();
            try
            {
                objConn.Open();
                objCmd.Connection = objConn;
                objCmd.CommandText = "PKG_TBDD_PTKH.INSERT_TBDD_PTKH_KH_SDDIEN"; objCmd.CommandType = CommandType.StoredProcedure;
                objCmd.Parameters.Add("pMA_KHANG_ID", OracleType.VarChar).Value = PMA_KHANG_ID;
                objCmd.Parameters.Add("pMA_DVIQLY", OracleType.VarChar).Value = pMA_DVIQLY;
                objCmd.Parameters.Add("pMUC_DICH", OracleType.VarChar).Value = PMUC_DICH;
                objCmd.Parameters.Add("pCONG_XUAT", OracleType.Number).Value = PCONG_XUAT;
                objCmd.Parameters.Add("pSO_LUONG", OracleType.Number).Value = PSO_LUONG;
                objCmd.Parameters.Add("pDAY_SD", OracleType.Number).Value = PDAY_SD;
                objCmd.Parameters.Add("pMONTH_SD", OracleType.Number).Value = PMONTH_SD;
                objCmd.Parameters.Add("pHOUR_SD", OracleType.Number).Value = PHOUR_SD;
                objCmd.Parameters.Add("pMA_VT", OracleType.VarChar).Value = PMA_VT;

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
        public void INSERT_TBDD_PTKH_SAMPLE(string pMA_DVIQLY, string PTEN_MAU, string PLOAICT, string PMDICH_SDUNG, string PGIA_BDIEN, string PCAPTRUOC_CTO, string PLOAI_CAPTRUOC, string PCAPSAU_CTO, string PLOAI_CAPSAU, string PLOAI_HOPCTO, string PHOPCTO_TINHCHAT, string PLOAI_CTO, string PYKIEN_TRO_NGAI, string PNGUOI_TAO)
        {
            OracleConnection objConn = new OracleConnection(ConnectString.ConnectionString(pMA_DVIQLY));
            OracleCommand objCmd = new OracleCommand();
            try
            {
                objConn.Open();
                objCmd.Connection = objConn;
                objCmd.CommandText = "PKG_TBDD_PTKH.INSERT_TBDD_PTKH_SAMPLE"; objCmd.CommandType = CommandType.StoredProcedure;
                objCmd.Parameters.Add("pMA_DVIQLY", OracleType.VarChar).Value = pMA_DVIQLY;
                objCmd.Parameters.Add("pTEN_MAU", OracleType.VarChar).Value = PTEN_MAU;
                objCmd.Parameters.Add("pLOAICT", OracleType.VarChar).Value = PLOAICT;
                objCmd.Parameters.Add("pMDICH_SDUNG", OracleType.VarChar).Value = PMDICH_SDUNG;
                objCmd.Parameters.Add("pGIA_BDIEN", OracleType.VarChar).Value = PGIA_BDIEN;
                objCmd.Parameters.Add("pCAPTRUOC_CTO", OracleType.VarChar).Value = PCAPTRUOC_CTO;
                objCmd.Parameters.Add("pLOAI_CAPTRUOC", OracleType.VarChar).Value = PLOAI_CAPTRUOC;
                objCmd.Parameters.Add("pCAPSAU_CTO", OracleType.VarChar).Value = PCAPSAU_CTO;
                objCmd.Parameters.Add("pLOAI_CAPSAU", OracleType.VarChar).Value = PLOAI_CAPSAU;
                objCmd.Parameters.Add("pLOAI_HOPCTO", OracleType.VarChar).Value = PLOAI_HOPCTO;
                objCmd.Parameters.Add("pHOPCTO_TINHCHAT", OracleType.VarChar).Value = PHOPCTO_TINHCHAT;
                objCmd.Parameters.Add("pLOAI_CTO", OracleType.VarChar).Value = PLOAI_CTO;
                objCmd.Parameters.Add("pYKIEN_TRO_NGAI", OracleType.VarChar).Value = PYKIEN_TRO_NGAI;
                objCmd.Parameters.Add("pNGUOI_TAO", OracleType.VarChar).Value = PNGUOI_TAO;

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
        public void INSERT_TBDD_PTKH_SAMPLE_TBSDD(string pMA_DVIQLY, string PLOAICT, string PMA_VT, string PMDICH_SDUNG, int PSOLUONG, string PTYLE_MDSD, string PNGUOI_TAO)
        {
            OracleConnection objConn = new OracleConnection(ConnectString.ConnectionString(pMA_DVIQLY));
            OracleCommand objCmd = new OracleCommand();
            try
            {
                objConn.Open();
                objCmd.Connection = objConn;
                objCmd.CommandText = "PKG_TBDD_PTKH.INSERT_TBDD_PTKH_SAMPLE_TBSDD"; objCmd.CommandType = CommandType.StoredProcedure;
                objCmd.Parameters.Add("pMA_DVIQLY", OracleType.VarChar).Value = pMA_DVIQLY;
                objCmd.Parameters.Add("pLOAICT", OracleType.VarChar).Value = PLOAICT;
                objCmd.Parameters.Add("pMA_VT", OracleType.VarChar).Value = PMA_VT;
                objCmd.Parameters.Add("pMDICH_SDUNG", OracleType.VarChar).Value = PMDICH_SDUNG;
                objCmd.Parameters.Add("pSOLUONG", OracleType.Number).Value = PSOLUONG;
                objCmd.Parameters.Add("pTYLE_MDSD", OracleType.VarChar).Value = PTYLE_MDSD;
                objCmd.Parameters.Add("pNGUOI_TAO", OracleType.VarChar).Value = PNGUOI_TAO;

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
        public void INSERT_TBDD_PTKH_SAMPLE_VATTU(string pMA_DVIQLY, string PLOAICT, string PMA_VT, int PSO_LUONG, string PNGUOI_TAO, string PCAPTRUOC_CTO, string PIS_TRUOC, string PMANSX)
        {
            OracleConnection objConn = new OracleConnection(ConnectString.ConnectionString(pMA_DVIQLY));
            OracleCommand objCmd = new OracleCommand();
            try
            {
                objConn.Open();
                objCmd.Connection = objConn;
                objCmd.CommandText = "PKG_TBDD_PTKH.INSERT_TBDD_PTKH_SAMPLE_VATTU"; objCmd.CommandType = CommandType.StoredProcedure;
                objCmd.Parameters.Add("pMA_DVIQLY", OracleType.VarChar).Value = pMA_DVIQLY;
                objCmd.Parameters.Add("pLOAICT", OracleType.VarChar).Value = PLOAICT;
                objCmd.Parameters.Add("pMA_VT", OracleType.VarChar).Value = PMA_VT;
                objCmd.Parameters.Add("pSO_LUONG", OracleType.Number).Value = PSO_LUONG;
                objCmd.Parameters.Add("pNGUOI_TAO", OracleType.VarChar).Value = PNGUOI_TAO;
                objCmd.Parameters.Add("pCAPTRUOC_CTO", OracleType.VarChar).Value = PCAPTRUOC_CTO;
                objCmd.Parameters.Add("pIS_TRUOC", OracleType.VarChar).Value = PIS_TRUOC;
                objCmd.Parameters.Add("pMANSX", OracleType.VarChar).Value = PMANSX;

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
        public void INSERT_TBDD_PTKH_VATTU_FMIS(string pMA_DVIQLY, string PMAVT, string PMANSX, string PTENVT, string PDVT)
        {
            OracleConnection objConn = new OracleConnection(ConnectString.ConnectionString(pMA_DVIQLY));
            OracleCommand objCmd = new OracleCommand();
            try
            {
                objConn.Open();
                objCmd.Connection = objConn;
                objCmd.CommandText = "PKG_TBDD_PTKH.INSERT_TBDD_PTKH_VATTU_FMIS"; objCmd.CommandType = CommandType.StoredProcedure;
                objCmd.Parameters.Add("pMAVT", OracleType.VarChar).Value = PMAVT;
                objCmd.Parameters.Add("pMANSX", OracleType.VarChar).Value = PMANSX;
                objCmd.Parameters.Add("pTENVT", OracleType.VarChar).Value = PTENVT;
                objCmd.Parameters.Add("pDVT", OracleType.VarChar).Value = PDVT;

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
        public void INSERT_TBDD_PTKH_VT_PHIEU_YCAU(string pMA_DVIQLY, string PSO_YCAU, string PNGUOI_TAO)
        {
            OracleConnection objConn = new OracleConnection(ConnectString.ConnectionString(pMA_DVIQLY));
            OracleCommand objCmd = new OracleCommand();
            try
            {
                objConn.Open();
                objCmd.Connection = objConn;
                objCmd.CommandText = "PKG_TBDD_PTKH.INSERT_TBDD_PTKH_VT_PHIEU_YCAU"; objCmd.CommandType = CommandType.StoredProcedure;
                objCmd.Parameters.Add("pMA_DVIQLY", OracleType.VarChar).Value = pMA_DVIQLY;
                objCmd.Parameters.Add("pSO_YCAU", OracleType.VarChar).Value = PSO_YCAU;
                objCmd.Parameters.Add("pNGUOI_TAO", OracleType.VarChar).Value = PNGUOI_TAO;

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
        public void INSERT_TBDD_PTKH_YCAU_VT(string pMA_DVIQLY, string PSO_YCAU, string PMA_KHANG_ID, string PNGUOI_TAO)
        {
            OracleConnection objConn = new OracleConnection(ConnectString.ConnectionString(pMA_DVIQLY));
            OracleCommand objCmd = new OracleCommand();
            try
            {
                objConn.Open();
                objCmd.Connection = objConn;
                objCmd.CommandText = "PKG_TBDD_PTKH.INSERT_TBDD_PTKH_YCAU_VT"; objCmd.CommandType = CommandType.StoredProcedure;
                objCmd.Parameters.Add("pMA_DVIQLY", OracleType.VarChar).Value = pMA_DVIQLY;
                objCmd.Parameters.Add("pSO_YCAU", OracleType.VarChar).Value = PSO_YCAU;
                objCmd.Parameters.Add("pMA_KHANG_ID", OracleType.VarChar).Value = PMA_KHANG_ID;
                objCmd.Parameters.Add("pNGUOI_TAO", OracleType.VarChar).Value = PNGUOI_TAO;

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
        public void INSERT_VATTU_DONVI(string pMA_DVIQLY, string PMA_VT, int PDG_VATTU, int PDG_NHANCONG, string PHAYDUNG, string PMANSX, string PID)
        {
            OracleConnection objConn = new OracleConnection(ConnectString.ConnectionString(pMA_DVIQLY));
            OracleCommand objCmd = new OracleCommand();
            try
            {
                objConn.Open();
                objCmd.Connection = objConn;
                objCmd.CommandText = "PKG_TBDD_PTKH.INSERT_VATTU_DONVI"; objCmd.CommandType = CommandType.StoredProcedure;
                objCmd.Parameters.Add("pMA_DVIQLY", OracleType.VarChar).Value = pMA_DVIQLY;
                objCmd.Parameters.Add("pMA_VT", OracleType.VarChar).Value = PMA_VT;
                objCmd.Parameters.Add("pDG_VATTU", OracleType.Number).Value = PDG_VATTU;
                objCmd.Parameters.Add("pDG_NHANCONG", OracleType.Number).Value = PDG_NHANCONG;
                objCmd.Parameters.Add("pHAYDUNG", OracleType.VarChar).Value = PHAYDUNG;
                objCmd.Parameters.Add("pMANSX", OracleType.VarChar).Value = PMANSX;
                objCmd.Parameters.Add("pID", OracleType.VarChar).Value = PID;

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
        public void INSERT_VATU(string PMA_VT, string PMA_NHOM, string pMA_DVIQLY, string PTEN_VT, string PMO_TA, string PDONG_DIEN, string PDIEN_AP, string PDONVITINH, int PSO_CONG, string PTINHCHAT_RIENG, string PMANSX, string PID)
        {
            OracleConnection objConn = new OracleConnection(ConnectString.ConnectionString(pMA_DVIQLY));
            OracleCommand objCmd = new OracleCommand();
            try
            {
                objConn.Open();
                objCmd.Connection = objConn;
                objCmd.CommandText = "PKG_TBDD_PTKH.INSERT_VATU"; objCmd.CommandType = CommandType.StoredProcedure;
                objCmd.Parameters.Add("pMA_VT", OracleType.VarChar).Value = PMA_VT;
                objCmd.Parameters.Add("pMA_NHOM", OracleType.VarChar).Value = PMA_NHOM;
                objCmd.Parameters.Add("pMA_DVIQLY", OracleType.VarChar).Value = pMA_DVIQLY;
                objCmd.Parameters.Add("pTEN_VT", OracleType.VarChar).Value = PTEN_VT;
                objCmd.Parameters.Add("pMO_TA", OracleType.VarChar).Value = PMO_TA;
                objCmd.Parameters.Add("pDONG_DIEN", OracleType.VarChar).Value = PDONG_DIEN;
                objCmd.Parameters.Add("pDIEN_AP", OracleType.VarChar).Value = PDIEN_AP;
                objCmd.Parameters.Add("pDONVITINH", OracleType.VarChar).Value = PDONVITINH;
                objCmd.Parameters.Add("pSO_CONG", OracleType.Number).Value = PSO_CONG;
                objCmd.Parameters.Add("pTINHCHAT_RIENG", OracleType.VarChar).Value = PTINHCHAT_RIENG;
                objCmd.Parameters.Add("pMANSX", OracleType.VarChar).Value = PMANSX;
                objCmd.Parameters.Add("pID", OracleType.VarChar).Value = PID;

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
        public void INSERT_VATU_SD(string PMA_VT, string PMA_NHOM, string pMA_DVIQLY, string PTEN_VT, string PMO_TA, int PHOUR_SD, int PDAY_SD, int PMONTH_SD, int PCONG_XUAT)
        {
            OracleConnection objConn = new OracleConnection(ConnectString.ConnectionString(pMA_DVIQLY));
            OracleCommand objCmd = new OracleCommand();
            try
            {
                objConn.Open();
                objCmd.Connection = objConn;
                objCmd.CommandText = "PKG_TBDD_PTKH.INSERT_VATU_SD"; objCmd.CommandType = CommandType.StoredProcedure;
                objCmd.Parameters.Add("pMA_VT", OracleType.VarChar).Value = PMA_VT;
                objCmd.Parameters.Add("pMA_NHOM", OracleType.VarChar).Value = PMA_NHOM;
                objCmd.Parameters.Add("pMA_DVIQLY", OracleType.VarChar).Value = pMA_DVIQLY;
                objCmd.Parameters.Add("pTEN_VT", OracleType.VarChar).Value = PTEN_VT;
                objCmd.Parameters.Add("pMO_TA", OracleType.VarChar).Value = PMO_TA;
                objCmd.Parameters.Add("pHOUR_SD", OracleType.Number).Value = PHOUR_SD;
                objCmd.Parameters.Add("pDAY_SD", OracleType.Number).Value = PDAY_SD;
                objCmd.Parameters.Add("pMONTH_SD", OracleType.Number).Value = PMONTH_SD;
                objCmd.Parameters.Add("pCONG_XUAT", OracleType.Number).Value = PCONG_XUAT;

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
        public void INSERT_VT_CHITIET_PHIEUYC(string pMA_DVIQLY, string PSO_YCAU, string PNGUOI_TAO)
        {
            OracleConnection objConn = new OracleConnection(ConnectString.ConnectionString(pMA_DVIQLY));
            OracleCommand objCmd = new OracleCommand();
            try
            {
                objConn.Open();
                objCmd.Connection = objConn;
                objCmd.CommandText = "PKG_TBDD_PTKH.INSERT_VT_CHITIET_PHIEUYC"; objCmd.CommandType = CommandType.StoredProcedure;
                objCmd.Parameters.Add("pMA_DVIQLY", OracleType.VarChar).Value = pMA_DVIQLY;
                objCmd.Parameters.Add("pSO_YCAU", OracleType.VarChar).Value = PSO_YCAU;
                objCmd.Parameters.Add("pNGUOI_TAO", OracleType.VarChar).Value = PNGUOI_TAO;

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
        public void LAY_CTO_CMIS(string pMA_DVIQLY)
        {
            OracleConnection objConn = new OracleConnection(ConnectString.ConnectionString(pMA_DVIQLY));
            OracleCommand objCmd = new OracleCommand();
            try
            {
                objConn.Open();
                objCmd.Connection = objConn;
                objCmd.CommandText = "PKG_TBDD_PTKH.LAY_CTO_CMIS"; objCmd.CommandType = CommandType.StoredProcedure;
                objCmd.Parameters.Add("pMA_DVIQLY", OracleType.VarChar).Value = pMA_DVIQLY;

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
        public void LAY_DL_KHANGCMIS(string pMA_DVIQLY)
        {
            OracleConnection objConn = new OracleConnection(ConnectString.ConnectionString(pMA_DVIQLY));
            OracleCommand objCmd = new OracleCommand();
            try
            {
                objConn.Open();
                objCmd.Connection = objConn;
                objCmd.CommandText = "PKG_TBDD_PTKH.LAY_DL_KHANGCMIS"; objCmd.CommandType = CommandType.StoredProcedure;
                objCmd.Parameters.Add("pMA_DVIQLY", OracleType.VarChar).Value = pMA_DVIQLY;

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
        public DataTable LAY_LO_TRAM_CMIS(string pMA_DVIQLY, string PLOAI)
        {
            DataTable dt = new DataTable(); OracleConnection objConn = new OracleConnection(ConnectString.ConnectionString(pMA_DVIQLY));
            OracleCommand objCmd = new OracleCommand();
            try
            {
                objConn.Open();
                objCmd.Connection = objConn;
                objCmd.CommandText = "PKG_TBDD_PTKH.LAY_LO_TRAM_CMIS"; objCmd.CommandType = CommandType.StoredProcedure;
                objCmd.Parameters.Add("pMA_DVIQLY", OracleType.VarChar).Value = pMA_DVIQLY;
                objCmd.Parameters.Add("pLOAI", OracleType.VarChar).Value = PLOAI;
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
        public DataTable SELECTALL_VATTU_DONVI(string pMA_DVIQLY)
        {
            DataTable dt = new DataTable(); OracleConnection objConn = new OracleConnection(ConnectString.ConnectionString(pMA_DVIQLY));
            OracleCommand objCmd = new OracleCommand();
            try
            {
                objConn.Open();
                objCmd.Connection = objConn;
                objCmd.CommandText = "PKG_TBDD_PTKH.SELECTALL_VATTU_DONVI"; objCmd.CommandType = CommandType.StoredProcedure;
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
        public DataTable SELECT_ALL_CAPSAU(string pMA_DVIQLY)
        {
            DataTable dt = new DataTable(); OracleConnection objConn = new OracleConnection(ConnectString.ConnectionString(pMA_DVIQLY));
            OracleCommand objCmd = new OracleCommand();
            try
            {
                objConn.Open();
                objCmd.Connection = objConn;
                objCmd.CommandText = "PKG_TBDD_PTKH.SELECT_ALL_CAPSAU"; objCmd.CommandType = CommandType.StoredProcedure;
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
        public DataTable SELECT_ALL_CAPTRUOC(string pMA_DVIQLY)
        {
            DataTable dt = new DataTable(); OracleConnection objConn = new OracleConnection(ConnectString.ConnectionString(pMA_DVIQLY));
            OracleCommand objCmd = new OracleCommand();
            try
            {
                objConn.Open();
                objCmd.Connection = objConn;
                objCmd.CommandText = "PKG_TBDD_PTKH.SELECT_ALL_CAPTRUOC"; objCmd.CommandType = CommandType.StoredProcedure;
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
        public DataTable SELECT_ALL_CSSD_BYNAMEKH(string pMA_DVIQLY, string PMA_KHANG_ID)
        {
            DataTable dt = new DataTable(); OracleConnection objConn = new OracleConnection(ConnectString.ConnectionString(pMA_DVIQLY));
            OracleCommand objCmd = new OracleCommand();
            try
            {
                objConn.Open();
                objCmd.Connection = objConn;
                objCmd.CommandText = "PKG_TBDD_PTKH.SELECT_ALL_CSSD_BYNAMEKH"; objCmd.CommandType = CommandType.StoredProcedure;
                objCmd.Parameters.Add("pMA_DVIQLY", OracleType.VarChar).Value = pMA_DVIQLY;
                objCmd.Parameters.Add("pMA_KHANG_ID", OracleType.VarChar).Value = PMA_KHANG_ID;
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
        public DataTable SELECT_ALL_CTO(string pMA_DVIQLY)
        {
            DataTable dt = new DataTable(); OracleConnection objConn = new OracleConnection(ConnectString.ConnectionString(pMA_DVIQLY));
            OracleCommand objCmd = new OracleCommand();
            try
            {
                objConn.Open();
                objCmd.Connection = objConn;
                objCmd.CommandText = "PKG_TBDD_PTKH.SELECT_ALL_CTO"; objCmd.CommandType = CommandType.StoredProcedure;
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
        public DataTable SELECT_ALL_KHACHHANG(string pMA_DVIQLY, string PLOAI_KH)
        {
            DataTable dt = new DataTable(); OracleConnection objConn = new OracleConnection(ConnectString.ConnectionString(pMA_DVIQLY));
            OracleCommand objCmd = new OracleCommand();
            try
            {
                objConn.Open();
                objCmd.Connection = objConn;
                objCmd.CommandText = "PKG_TBDD_PTKH.SELECT_ALL_KHACHHANG"; objCmd.CommandType = CommandType.StoredProcedure;
                objCmd.Parameters.Add("pMA_DVIQLY", OracleType.VarChar).Value = pMA_DVIQLY;
                objCmd.Parameters.Add("pLOAI_KH", OracleType.VarChar).Value = PLOAI_KH;
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
        public DataTable SELECT_ALL_KH_BY_MAKHANG(string pMA_DVIQLY, string PMA_KHANG_ID)
        {
            DataTable dt = new DataTable(); OracleConnection objConn = new OracleConnection(ConnectString.ConnectionString(pMA_DVIQLY));
            OracleCommand objCmd = new OracleCommand();
            try
            {
                objConn.Open();
                objCmd.Connection = objConn;
                objCmd.CommandText = "PKG_TBDD_PTKH.SELECT_ALL_KH_BY_MAKHANG"; objCmd.CommandType = CommandType.StoredProcedure;
                objCmd.Parameters.Add("pMA_DVIQLY", OracleType.VarChar).Value = pMA_DVIQLY;
                objCmd.Parameters.Add("pMA_KHANG_ID", OracleType.VarChar).Value = PMA_KHANG_ID;
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
        public DataTable SELECT_ALL_KH_PHAN_NV(string pMA_DVIQLY, string PLOAI_KH)
        {
            DataTable dt = new DataTable(); OracleConnection objConn = new OracleConnection(ConnectString.ConnectionString(pMA_DVIQLY));
            OracleCommand objCmd = new OracleCommand();
            try
            {
                objConn.Open();
                objCmd.Connection = objConn;
                objCmd.CommandText = "PKG_TBDD_PTKH.SELECT_ALL_KH_PHAN_NV"; objCmd.CommandType = CommandType.StoredProcedure;
                objCmd.Parameters.Add("pMA_DVIQLY", OracleType.VarChar).Value = pMA_DVIQLY;
                objCmd.Parameters.Add("pLOAI_KH", OracleType.VarChar).Value = PLOAI_KH;
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
        public DataTable SELECT_ALL_KH_SDUNG_BYIDKH(string pMA_DVIQLY, string PMA_KHANG_ID)
        {
            DataTable dt = new DataTable(); OracleConnection objConn = new OracleConnection(ConnectString.ConnectionString(pMA_DVIQLY));
            OracleCommand objCmd = new OracleCommand();
            try
            {
                objConn.Open();
                objCmd.Connection = objConn;
                objCmd.CommandText = "PKG_TBDD_PTKH.SELECT_ALL_KH_SDUNG_BYIDKH"; objCmd.CommandType = CommandType.StoredProcedure;
                objCmd.Parameters.Add("pMA_DVIQLY", OracleType.VarChar).Value = pMA_DVIQLY;
                objCmd.Parameters.Add("pMA_KHANG_ID", OracleType.VarChar).Value = PMA_KHANG_ID;
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
        public DataTable SELECT_ALL_KH_VT_BYIDKH(string pMA_DVIQLY, string PMA_KHANG_ID)
        {
            DataTable dt = new DataTable(); OracleConnection objConn = new OracleConnection(ConnectString.ConnectionString(pMA_DVIQLY));
            OracleCommand objCmd = new OracleCommand();
            try
            {
                objConn.Open();
                objCmd.Connection = objConn;
                objCmd.CommandText = "PKG_TBDD_PTKH.SELECT_ALL_KH_VT_BYIDKH"; objCmd.CommandType = CommandType.StoredProcedure;
                objCmd.Parameters.Add("pMA_DVIQLY", OracleType.VarChar).Value = pMA_DVIQLY;
                objCmd.Parameters.Add("pMA_KHANG_ID", OracleType.VarChar).Value = PMA_KHANG_ID;
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
        public DataTable SELECT_ALL_NHANVIEN_KS(string pMA_DVIQLY)
        {
            DataTable dt = new DataTable(); OracleConnection objConn = new OracleConnection(ConnectString.ConnectionString(pMA_DVIQLY));
            OracleCommand objCmd = new OracleCommand();
            try
            {
                objConn.Open();
                objCmd.Connection = objConn;
                objCmd.CommandText = "PKG_TBDD_PTKH.SELECT_ALL_NHANVIEN_KS"; objCmd.CommandType = CommandType.StoredProcedure;
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
        public DataTable SELECT_ALL_NHOMVATU(string pMA_DVIQLY)
        {
            DataTable dt = new DataTable(); OracleConnection objConn = new OracleConnection(ConnectString.ConnectionString(pMA_DVIQLY));
            OracleCommand objCmd = new OracleCommand();
            try
            {
                objConn.Open();
                objCmd.Connection = objConn;
                objCmd.CommandText = "PKG_TBDD_PTKH.SELECT_ALL_NHOMVATU"; objCmd.CommandType = CommandType.StoredProcedure;
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
        public DataTable SELECT_ALL_NHOMVATU_SD(string pMA_DVIQLY)
        {
            DataTable dt = new DataTable(); OracleConnection objConn = new OracleConnection(ConnectString.ConnectionString(pMA_DVIQLY));
            OracleCommand objCmd = new OracleCommand();
            try
            {
                objConn.Open();
                objCmd.Connection = objConn;
                objCmd.CommandText = "PKG_TBDD_PTKH.SELECT_ALL_NHOMVATU_SD";
                objCmd.CommandType = CommandType.StoredProcedure;
                objCmd.Parameters.Add("pMA_DVIQLY", OracleType.VarChar).Value = pMA_DVIQLY.Substring(0, 4);
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
        public DataTable SELECT_ALL_VATU(string pMA_DVIQLY)
        {
            DataTable dt = new DataTable(); OracleConnection objConn = new OracleConnection(ConnectString.ConnectionString(pMA_DVIQLY));
            OracleCommand objCmd = new OracleCommand();
            try
            {
                objConn.Open();
                objCmd.Connection = objConn;
                objCmd.CommandText = "PKG_TBDD_PTKH.SELECT_ALL_VATU"; objCmd.CommandType = CommandType.StoredProcedure;
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
        public DataTable SELECT_ALL_VATU_BY_NHOMVT(string pMA_DVIQLY, string PMA_NHOM)
        {
            DataTable dt = new DataTable(); OracleConnection objConn = new OracleConnection(ConnectString.ConnectionString(pMA_DVIQLY));
            OracleCommand objCmd = new OracleCommand();
            try
            {
                objConn.Open();
                objCmd.Connection = objConn;
                objCmd.CommandText = "PKG_TBDD_PTKH.SELECT_ALL_VATU_BY_NHOMVT"; objCmd.CommandType = CommandType.StoredProcedure;
                objCmd.Parameters.Add("pMA_DVIQLY", OracleType.VarChar).Value = pMA_DVIQLY;
                objCmd.Parameters.Add("pMA_NHOM", OracleType.VarChar).Value = PMA_NHOM;
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
        public DataTable SELECT_ALL_VATU_BY_NHOMVT_SD(string pMA_DVIQLY, string PMA_NHOM)
        {
            DataTable dt = new DataTable(); OracleConnection objConn = new OracleConnection(ConnectString.ConnectionString(pMA_DVIQLY));
            OracleCommand objCmd = new OracleCommand();
            try
            {
                objConn.Open();
                objCmd.Connection = objConn;
                objCmd.CommandText = "PKG_TBDD_PTKH.SELECT_ALL_VATU_BY_NHOMVT_SD"; objCmd.CommandType = CommandType.StoredProcedure;
                objCmd.Parameters.Add("pMA_DVIQLY", OracleType.VarChar).Value = pMA_DVIQLY;
                objCmd.Parameters.Add("pMA_NHOM", OracleType.VarChar).Value = PMA_NHOM;
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
        public DataTable SELECT_ALL_VATU_SD(string pMA_DVIQLY)
        {
            DataTable dt = new DataTable(); OracleConnection objConn = new OracleConnection(ConnectString.ConnectionString(pMA_DVIQLY));
            OracleCommand objCmd = new OracleCommand();
            try
            {
                objConn.Open();
                objCmd.Connection = objConn;
                objCmd.CommandText = "PKG_TBDD_PTKH.SELECT_ALL_VATU_SD"; objCmd.CommandType = CommandType.StoredProcedure;
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
        public DataTable SELECT_ALL_VT_KHBY_NAMEKH(string pMA_DVIQLY, string PMA_KHANG_ID)
        {
            DataTable dt = new DataTable(); OracleConnection objConn = new OracleConnection(ConnectString.ConnectionString(pMA_DVIQLY));
            OracleCommand objCmd = new OracleCommand();
            try
            {
                objConn.Open();
                objCmd.Connection = objConn;
                objCmd.CommandText = "PKG_TBDD_PTKH.SELECT_ALL_VT_KHBY_NAMEKH"; objCmd.CommandType = CommandType.StoredProcedure;
                objCmd.Parameters.Add("pMA_DVIQLY", OracleType.VarChar).Value = pMA_DVIQLY;
                objCmd.Parameters.Add("pMA_KHANG_ID", OracleType.VarChar).Value = PMA_KHANG_ID;
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
        public DataTable SELECT_CONGTHUC(string pMA_DVIQLY, int PSO_PHA)
        {
            DataTable dt = new DataTable(); OracleConnection objConn = new OracleConnection(ConnectString.ConnectionString(pMA_DVIQLY));
            OracleCommand objCmd = new OracleCommand();
            try
            {
                objConn.Open();
                objCmd.Connection = objConn;
                objCmd.CommandText = "PKG_TBDD_PTKH.SELECT_CONGTHUC"; objCmd.CommandType = CommandType.StoredProcedure;
                objCmd.Parameters.Add("pMA_DVIQLY", OracleType.VarChar).Value = pMA_DVIQLY;
                objCmd.Parameters.Add("pSO_PHA", OracleType.Number).Value = PSO_PHA;
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
        public DataTable SELECT_KHANG_CHUAYCAU_VATTU(string pMA_DVIQLY)
        {
            DataTable dt = new DataTable(); OracleConnection objConn = new OracleConnection(ConnectString.ConnectionString(pMA_DVIQLY));
            OracleCommand objCmd = new OracleCommand();
            try
            {
                objConn.Open();
                objCmd.Connection = objConn;
                objCmd.CommandText = "PKG_TBDD_PTKH.SELECT_KHANG_CHUAYCAU_VATTU"; objCmd.CommandType = CommandType.StoredProcedure;
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
        public DataTable SELECT_KHANG_DAKHAOSAT(string pMA_DVIQLY, int PTHANG, int PNAM)
        {
            DataTable dt = new DataTable(); OracleConnection objConn = new OracleConnection(ConnectString.ConnectionString(pMA_DVIQLY));
            OracleCommand objCmd = new OracleCommand();
            try
            {
                objConn.Open();
                objCmd.Connection = objConn;
                objCmd.CommandText = "PKG_TBDD_PTKH.SELECT_KHANG_DAKHAOSAT"; objCmd.CommandType = CommandType.StoredProcedure;
                objCmd.Parameters.Add("pMA_DVIQLY", OracleType.VarChar).Value = pMA_DVIQLY;
                objCmd.Parameters.Add("pTHANG", OracleType.Number).Value = PTHANG;
                objCmd.Parameters.Add("pNAM", OracleType.Number).Value = PNAM;
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
        public DataTable SELECT_KH_TBDD(string pMA_DVIQLY, string PMA_NVIEN, DateTime PNGAY_KS)
        {
            DataTable dt = new DataTable(); OracleConnection objConn = new OracleConnection(ConnectString.ConnectionString(pMA_DVIQLY));
            OracleCommand objCmd = new OracleCommand();
            try
            {
                objConn.Open();
                objCmd.Connection = objConn;
                objCmd.CommandText = "PKG_TBDD_PTKH.SELECT_KH_TBDD"; objCmd.CommandType = CommandType.StoredProcedure;
                objCmd.Parameters.Add("pMA_DVIQLY", OracleType.VarChar).Value = pMA_DVIQLY;
                objCmd.Parameters.Add("pMA_NVIEN", OracleType.VarChar).Value = PMA_NVIEN;
                objCmd.Parameters.Add("pNGAY_KS", OracleType.DateTime).Value = PNGAY_KS; objCmd.Parameters.Add("rs", OracleType.Cursor).Direction = ParameterDirection.Output;
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
        public DataTable SELECT_NHOMVT_DONVI(string pMA_DVIQLY)
        {
            DataTable dt = new DataTable(); OracleConnection objConn = new OracleConnection(ConnectString.ConnectionString(pMA_DVIQLY));
            OracleCommand objCmd = new OracleCommand();
            try
            {
                objConn.Open();
                objCmd.Connection = objConn;
                objCmd.CommandText = "PKG_TBDD_PTKH.SELECT_NHOMVT_DONVI"; objCmd.CommandType = CommandType.StoredProcedure;
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
        public DataTable SELECT_TBDD_PTKH_SAMPLE(string pMA_DVIQLY)
        {
            DataTable dt = new DataTable(); OracleConnection objConn = new OracleConnection(ConnectString.ConnectionString(pMA_DVIQLY));
            OracleCommand objCmd = new OracleCommand();
            try
            {
                objConn.Open();
                objCmd.Connection = objConn;
                objCmd.CommandText = "PKG_TBDD_PTKH.SELECT_TBDD_PTKH_SAMPLE"; objCmd.CommandType = CommandType.StoredProcedure;
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
        public DataTable SELECT_TBDD_PTKH_SAMPLE_TBSDD(string pMA_DVIQLY, string PLOAICT)
        {
            DataTable dt = new DataTable(); OracleConnection objConn = new OracleConnection(ConnectString.ConnectionString(pMA_DVIQLY));
            OracleCommand objCmd = new OracleCommand();
            try
            {
                objConn.Open();
                objCmd.Connection = objConn;
                objCmd.CommandText = "PKG_TBDD_PTKH.SELECT_TBDD_PTKH_SAMPLE_TBSDD"; objCmd.CommandType = CommandType.StoredProcedure;
                objCmd.Parameters.Add("pMA_DVIQLY", OracleType.VarChar).Value = pMA_DVIQLY;
                objCmd.Parameters.Add("pLOAICT", OracleType.VarChar).Value = PLOAICT;
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
        public DataTable SELECT_TBDD_PTKH_SAMPLE_VATTU(string pMA_DVIQLY, string PLOAICT)
        {
            DataTable dt = new DataTable(); OracleConnection objConn = new OracleConnection(ConnectString.ConnectionString(pMA_DVIQLY));
            OracleCommand objCmd = new OracleCommand();
            try
            {
                objConn.Open();
                objCmd.Connection = objConn;
                objCmd.CommandText = "PKG_TBDD_PTKH.SELECT_TBDD_PTKH_SAMPLE_VATTU"; objCmd.CommandType = CommandType.StoredProcedure;
                objCmd.Parameters.Add("pMA_DVIQLY", OracleType.VarChar).Value = pMA_DVIQLY;
                objCmd.Parameters.Add("pLOAICT", OracleType.VarChar).Value = PLOAICT;
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
        public DataTable SELECT_TBDD_PTKH_VATTU_FMIS(string pMA_DVIQLY, string PSEARCH)
        {
            DataTable dt = new DataTable(); OracleConnection objConn = new OracleConnection(ConnectString.ConnectionString(pMA_DVIQLY));
            OracleCommand objCmd = new OracleCommand();
            try
            {
                objConn.Open();
                objCmd.Connection = objConn;
                objCmd.CommandText = "PKG_TBDD_PTKH.SELECT_TBDD_PTKH_VATTU_FMIS"; objCmd.CommandType = CommandType.StoredProcedure;
                objCmd.Parameters.Add("pSEARCH", OracleType.VarChar).Value = PSEARCH;
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
        public DataTable SELECT_TBDD_PTKH_VT_PHIEU_YCAU(string pMA_DVIQLY, string PSO_YCAU)
        {
            DataTable dt = new DataTable(); OracleConnection objConn = new OracleConnection(ConnectString.ConnectionString(pMA_DVIQLY));
            OracleCommand objCmd = new OracleCommand();
            try
            {
                objConn.Open();
                objCmd.Connection = objConn;
                objCmd.CommandText = "PKG_TBDD_PTKH.SELECT_TBDD_PTKH_VT_PHIEU_YCAU"; objCmd.CommandType = CommandType.StoredProcedure;
                objCmd.Parameters.Add("pMA_DVIQLY", OracleType.VarChar).Value = pMA_DVIQLY;
                objCmd.Parameters.Add("pSO_YCAU", OracleType.VarChar).Value = PSO_YCAU;
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
        public DataTable SELECT_TBDD_PTKH_YCAU_VT(string pMA_DVIQLY, string PSO_YCAU)
        {
            DataTable dt = new DataTable(); OracleConnection objConn = new OracleConnection(ConnectString.ConnectionString(pMA_DVIQLY));
            OracleCommand objCmd = new OracleCommand();
            try
            {
                objConn.Open();
                objCmd.Connection = objConn;
                objCmd.CommandText = "PKG_TBDD_PTKH.SELECT_TBDD_PTKH_YCAU_VT"; objCmd.CommandType = CommandType.StoredProcedure;
                objCmd.Parameters.Add("pMA_DVIQLY", OracleType.VarChar).Value = pMA_DVIQLY;
                objCmd.Parameters.Add("pSO_YCAU", OracleType.VarChar).Value = PSO_YCAU;
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
        public DataTable SELECT_TBDD_PTKH_YCAU_VT_BYKH(string pMA_DVIQLY, string PMA_KHANG_ID)
        {
            DataTable dt = new DataTable(); OracleConnection objConn = new OracleConnection(ConnectString.ConnectionString(pMA_DVIQLY));
            OracleCommand objCmd = new OracleCommand();
            try
            {
                objConn.Open();
                objCmd.Connection = objConn;
                objCmd.CommandText = "PKG_TBDD_PTKH.SELECT_TBDD_PTKH_YCAU_VT_BYKH"; objCmd.CommandType = CommandType.StoredProcedure;
                objCmd.Parameters.Add("pMA_DVIQLY", OracleType.VarChar).Value = pMA_DVIQLY;
                objCmd.Parameters.Add("pMA_KHANG_ID", OracleType.VarChar).Value = PMA_KHANG_ID;
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
        public DataTable SELECT_TB_NV(string pMA_DVIQLY, int PTHANG, int PNAM, int PNGAY, string PMA_NVIEN, string PLOAI_DN)
        {
            DataTable dt = new DataTable(); OracleConnection objConn = new OracleConnection(ConnectString.ConnectionString(pMA_DVIQLY));
            OracleCommand objCmd = new OracleCommand();
            try
            {
                objConn.Open();
                objCmd.Connection = objConn;
                objCmd.CommandText = "PKG_TBDD_PTKH.SELECT_TB_NV"; objCmd.CommandType = CommandType.StoredProcedure;
                objCmd.Parameters.Add("pMA_DVIQLY", OracleType.VarChar).Value = pMA_DVIQLY;
                objCmd.Parameters.Add("pTHANG", OracleType.Number).Value = PTHANG;
                objCmd.Parameters.Add("pNAM", OracleType.Number).Value = PNAM;
                objCmd.Parameters.Add("pNGAY", OracleType.Number).Value = PNGAY;
                objCmd.Parameters.Add("pMA_NVIEN", OracleType.VarChar).Value = PMA_NVIEN;
                objCmd.Parameters.Add("pLOAI_DN", OracleType.VarChar).Value = PLOAI_DN;
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
        public DataTable SELECT_VT_CHITIET_PHIEUYC(string pMA_DVIQLY, string PSO_YCAU)
        {
            DataTable dt = new DataTable(); OracleConnection objConn = new OracleConnection(ConnectString.ConnectionString(pMA_DVIQLY));
            OracleCommand objCmd = new OracleCommand();
            try
            {
                objConn.Open();
                objCmd.Connection = objConn;
                objCmd.CommandText = "PKG_TBDD_PTKH.SELECT_VT_CHITIET_PHIEUYC"; objCmd.CommandType = CommandType.StoredProcedure;
                objCmd.Parameters.Add("pMA_DVIQLY", OracleType.VarChar).Value = pMA_DVIQLY;
                objCmd.Parameters.Add("pSO_YCAU", OracleType.VarChar).Value = PSO_YCAU;
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
        public DataTable SELECT_VT_NOTIN_DV(string pMA_DVIQLY)
        {
            DataTable dt = new DataTable(); OracleConnection objConn = new OracleConnection(ConnectString.ConnectionString(pMA_DVIQLY));
            OracleCommand objCmd = new OracleCommand();
            try
            {
                objConn.Open();
                objCmd.Connection = objConn;
                objCmd.CommandText = "PKG_TBDD_PTKH.SELECT_VT_NOTIN_DV"; objCmd.CommandType = CommandType.StoredProcedure;
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
        public void SET_KH_NEW_TOCMIS(string pMA_DVIQLY, string PMA_KHANG_ID, string PMA_YCAU_KNAI, string PNGUOI_TAO, string PNOI_DUNG)
        {
            OracleConnection objConn = new OracleConnection(ConnectString.ConnectionString(pMA_DVIQLY));
            OracleCommand objCmd = new OracleCommand();
            try
            {
                objConn.Open();
                objCmd.Connection = objConn;
                objCmd.CommandText = "PKG_TBDD_PTKH.SET_KH_NEW_TOCMIS"; objCmd.CommandType = CommandType.StoredProcedure;
                objCmd.Parameters.Add("pMA_DVIQLY", OracleType.VarChar).Value = pMA_DVIQLY;
                objCmd.Parameters.Add("pMA_KHANG_ID", OracleType.VarChar).Value = PMA_KHANG_ID;
                objCmd.Parameters.Add("pMA_YCAU_KNAI", OracleType.VarChar).Value = PMA_YCAU_KNAI;
                objCmd.Parameters.Add("pNGUOI_TAO", OracleType.VarChar).Value = PNGUOI_TAO;
                objCmd.Parameters.Add("pNOI_DUNG", OracleType.VarChar).Value = PNOI_DUNG;

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
        public void UPDATE_CONGTHUC(string pMA_DVIQLY, string PMA_CT, string PTEN_CT, string PCONG_THUC, int PID, int PVITRI_ORDER, int PSO_PHA)
        {
            OracleConnection objConn = new OracleConnection(ConnectString.ConnectionString(pMA_DVIQLY));
            OracleCommand objCmd = new OracleCommand();
            try
            {
                objConn.Open();
                objCmd.Connection = objConn;
                objCmd.CommandText = "PKG_TBDD_PTKH.UPDATE_CONGTHUC"; objCmd.CommandType = CommandType.StoredProcedure;
                objCmd.Parameters.Add("pMA_DVIQLY", OracleType.VarChar).Value = pMA_DVIQLY;
                objCmd.Parameters.Add("pMA_CT", OracleType.VarChar).Value = PMA_CT;
                objCmd.Parameters.Add("pTEN_CT", OracleType.VarChar).Value = PTEN_CT;
                objCmd.Parameters.Add("pCONG_THUC", OracleType.VarChar).Value = PCONG_THUC;
                objCmd.Parameters.Add("pID", OracleType.Number).Value = PID;
                objCmd.Parameters.Add("pVITRI_ORDER", OracleType.Number).Value = PVITRI_ORDER;
                objCmd.Parameters.Add("pSO_PHA", OracleType.Number).Value = PSO_PHA;

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
        public void UPDATE_NHOMVATU(string pMA_DVIQLY, string PMA_NHOM, string PTEN_NHOM, string PMO_TA, int PID)
        {
            OracleConnection objConn = new OracleConnection(ConnectString.ConnectionString(pMA_DVIQLY));
            OracleCommand objCmd = new OracleCommand();
            try
            {
                objConn.Open();
                objCmd.Connection = objConn;
                objCmd.CommandText = "PKG_TBDD_PTKH.UPDATE_NHOMVATU"; objCmd.CommandType = CommandType.StoredProcedure;
                objCmd.Parameters.Add("pMA_DVIQLY", OracleType.VarChar).Value = pMA_DVIQLY;
                objCmd.Parameters.Add("pMA_NHOM", OracleType.VarChar).Value = PMA_NHOM;
                objCmd.Parameters.Add("pTEN_NHOM", OracleType.VarChar).Value = PTEN_NHOM;
                objCmd.Parameters.Add("pMO_TA", OracleType.VarChar).Value = PMO_TA;
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
        public void UPDATE_NHOMVATU_SD(string pMA_DVIQLY, string PMA_NHOM, string PTEN_NHOM, string PMO_TA, int PID)
        {
            OracleConnection objConn = new OracleConnection(ConnectString.ConnectionString(pMA_DVIQLY));
            OracleCommand objCmd = new OracleCommand();
            try
            {
                objConn.Open();
                objCmd.Connection = objConn;
                objCmd.CommandText = "PKG_TBDD_PTKH.UPDATE_NHOMVATU_SD"; objCmd.CommandType = CommandType.StoredProcedure;
                objCmd.Parameters.Add("pMA_DVIQLY", OracleType.VarChar).Value = pMA_DVIQLY;
                objCmd.Parameters.Add("pMA_NHOM", OracleType.VarChar).Value = PMA_NHOM;
                objCmd.Parameters.Add("pTEN_NHOM", OracleType.VarChar).Value = PTEN_NHOM;
                objCmd.Parameters.Add("pMO_TA", OracleType.VarChar).Value = PMO_TA;
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
        public void UPDATE_TBDD_PTKH_SAMPLE(string pMA_DVIQLY, string PTEN_MAU, string PLOAICT, string PMDICH_SDUNG, string PGIA_BDIEN, string PCAPTRUOC_CTO, string PLOAI_CAPTRUOC, string PCAPSAU_CTO, string PLOAI_CAPSAU, string PLOAI_HOPCTO, string PHOPCTO_TINHCHAT, string PLOAI_CTO, string PYKIEN_TRO_NGAI, string PNGUOI_TAO)
        {
            OracleConnection objConn = new OracleConnection(ConnectString.ConnectionString(pMA_DVIQLY));
            OracleCommand objCmd = new OracleCommand();
            try
            {
                objConn.Open();
                objCmd.Connection = objConn;
                objCmd.CommandText = "PKG_TBDD_PTKH.UPDATE_TBDD_PTKH_SAMPLE"; objCmd.CommandType = CommandType.StoredProcedure;
                objCmd.Parameters.Add("pMA_DVIQLY", OracleType.VarChar).Value = pMA_DVIQLY;
                objCmd.Parameters.Add("pTEN_MAU", OracleType.VarChar).Value = PTEN_MAU;
                objCmd.Parameters.Add("pLOAICT", OracleType.VarChar).Value = PLOAICT;
                objCmd.Parameters.Add("pMDICH_SDUNG", OracleType.VarChar).Value = PMDICH_SDUNG;
                objCmd.Parameters.Add("pGIA_BDIEN", OracleType.VarChar).Value = PGIA_BDIEN;
                objCmd.Parameters.Add("pCAPTRUOC_CTO", OracleType.VarChar).Value = PCAPTRUOC_CTO;
                objCmd.Parameters.Add("pLOAI_CAPTRUOC", OracleType.VarChar).Value = PLOAI_CAPTRUOC;
                objCmd.Parameters.Add("pCAPSAU_CTO", OracleType.VarChar).Value = PCAPSAU_CTO;
                objCmd.Parameters.Add("pLOAI_CAPSAU", OracleType.VarChar).Value = PLOAI_CAPSAU;
                objCmd.Parameters.Add("pLOAI_HOPCTO", OracleType.VarChar).Value = PLOAI_HOPCTO;
                objCmd.Parameters.Add("pHOPCTO_TINHCHAT", OracleType.VarChar).Value = PHOPCTO_TINHCHAT;
                objCmd.Parameters.Add("pLOAI_CTO", OracleType.VarChar).Value = PLOAI_CTO;
                objCmd.Parameters.Add("pYKIEN_TRO_NGAI", OracleType.VarChar).Value = PYKIEN_TRO_NGAI;
                objCmd.Parameters.Add("pNGUOI_TAO", OracleType.VarChar).Value = PNGUOI_TAO;

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
        public void UPDATE_TT_KH_TBDD(string pMA_DVIQLY, string PMA_NVIEN, DateTime PNGAY_KS, string PLOAI_UPDATE, string PMA_KHANG_ID)
        {
            OracleConnection objConn = new OracleConnection(ConnectString.ConnectionString(pMA_DVIQLY));
            OracleCommand objCmd = new OracleCommand();
            try
            {
                objConn.Open();
                objCmd.Connection = objConn;
                objCmd.CommandText = "PKG_TBDD_PTKH.UPDATE_TT_KH_TBDD"; objCmd.CommandType = CommandType.StoredProcedure;
                objCmd.Parameters.Add("pMA_DVIQLY", OracleType.VarChar).Value = pMA_DVIQLY;
                objCmd.Parameters.Add("pMA_NVIEN", OracleType.VarChar).Value = PMA_NVIEN;
                objCmd.Parameters.Add("pNGAY_KS", OracleType.DateTime).Value = PNGAY_KS; objCmd.Parameters.Add("pLOAI_UPDATE", OracleType.VarChar).Value = PLOAI_UPDATE;
                objCmd.Parameters.Add("pMA_KHANG_ID", OracleType.VarChar).Value = PMA_KHANG_ID;

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
        public void UPDATE_VATTU_DONVI(string pMA_DVIQLY, string PMA_VT, int PDG_VATTU, int PDG_NHANCONG, string PHAYDUNG, string PMANSX, string PID)
        {
            OracleConnection objConn = new OracleConnection(ConnectString.ConnectionString(pMA_DVIQLY));
            OracleCommand objCmd = new OracleCommand();
            try
            {
                objConn.Open();
                objCmd.Connection = objConn;
                objCmd.CommandText = "PKG_TBDD_PTKH.UPDATE_VATTU_DONVI"; objCmd.CommandType = CommandType.StoredProcedure;
                objCmd.Parameters.Add("pMA_DVIQLY", OracleType.VarChar).Value = pMA_DVIQLY;
                objCmd.Parameters.Add("pMA_VT", OracleType.VarChar).Value = PMA_VT;
                objCmd.Parameters.Add("pDG_VATTU", OracleType.Number).Value = PDG_VATTU;
                objCmd.Parameters.Add("pDG_NHANCONG", OracleType.Number).Value = PDG_NHANCONG;
                objCmd.Parameters.Add("pHAYDUNG", OracleType.VarChar).Value = PHAYDUNG;
                objCmd.Parameters.Add("pMANSX", OracleType.VarChar).Value = PMANSX;
                objCmd.Parameters.Add("pID", OracleType.VarChar).Value = PID;

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
        public void UPDATE_VATU(string PMA_VT, string PMA_NHOM, string pMA_DVIQLY, string PTEN_VT, string PMO_TA, string PID, string PDONG_DIEN, string PDIEN_AP, string PDONVITINH, int PSO_CONG, string PTINHCHAT_RIENG, string PMANSX)
        {
            OracleConnection objConn = new OracleConnection(ConnectString.ConnectionString(pMA_DVIQLY));
            OracleCommand objCmd = new OracleCommand();
            try
            {
                objConn.Open();
                objCmd.Connection = objConn;
                objCmd.CommandText = "PKG_TBDD_PTKH.UPDATE_VATU"; objCmd.CommandType = CommandType.StoredProcedure;
                objCmd.Parameters.Add("pMA_VT", OracleType.VarChar).Value = PMA_VT;
                objCmd.Parameters.Add("pMA_NHOM", OracleType.VarChar).Value = PMA_NHOM;
                objCmd.Parameters.Add("pMA_DVIQLY", OracleType.VarChar).Value = pMA_DVIQLY;
                objCmd.Parameters.Add("pTEN_VT", OracleType.VarChar).Value = PTEN_VT;
                objCmd.Parameters.Add("pMO_TA", OracleType.VarChar).Value = PMO_TA;
                objCmd.Parameters.Add("pID", OracleType.VarChar).Value = PID;
                objCmd.Parameters.Add("pDONG_DIEN", OracleType.VarChar).Value = PDONG_DIEN;
                objCmd.Parameters.Add("pDIEN_AP", OracleType.VarChar).Value = PDIEN_AP;
                objCmd.Parameters.Add("pDONVITINH", OracleType.VarChar).Value = PDONVITINH;
                objCmd.Parameters.Add("pSO_CONG", OracleType.Number).Value = PSO_CONG;
                objCmd.Parameters.Add("pTINHCHAT_RIENG", OracleType.VarChar).Value = PTINHCHAT_RIENG;
                objCmd.Parameters.Add("pMANSX", OracleType.VarChar).Value = PMANSX;

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
        public void UPDATE_VATU_SD(string PMA_VT, string PMA_NHOM, string pMA_DVIQLY, string PTEN_VT, string PMO_TA, int PID, int PHOUR_SD, int PDAY_SD, int PCONG_XUAT)
        {
            OracleConnection objConn = new OracleConnection(ConnectString.ConnectionString(pMA_DVIQLY));
            OracleCommand objCmd = new OracleCommand();
            try
            {
                objConn.Open();
                objCmd.Connection = objConn;
                objCmd.CommandText = "PKG_TBDD_PTKH.UPDATE_VATU_SD"; objCmd.CommandType = CommandType.StoredProcedure;
                objCmd.Parameters.Add("pMA_VT", OracleType.VarChar).Value = PMA_VT;
                objCmd.Parameters.Add("pMA_NHOM", OracleType.VarChar).Value = PMA_NHOM;
                objCmd.Parameters.Add("pMA_DVIQLY", OracleType.VarChar).Value = pMA_DVIQLY;
                objCmd.Parameters.Add("pTEN_VT", OracleType.VarChar).Value = PTEN_VT;
                objCmd.Parameters.Add("pMO_TA", OracleType.VarChar).Value = PMO_TA;
                objCmd.Parameters.Add("pID", OracleType.Number).Value = PID;
                objCmd.Parameters.Add("pHOUR_SD", OracleType.Number).Value = PHOUR_SD;
                objCmd.Parameters.Add("pDAY_SD", OracleType.Number).Value = PDAY_SD;
                objCmd.Parameters.Add("pCONG_XUAT", OracleType.Number).Value = PCONG_XUAT;

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
        public void XOA_CONGTHUC(string pMA_DVIQLY, int PID)
        {
            OracleConnection objConn = new OracleConnection(ConnectString.ConnectionString(pMA_DVIQLY));
            OracleCommand objCmd = new OracleCommand();
            try
            {
                objConn.Open();
                objCmd.Connection = objConn;
                objCmd.CommandText = "PKG_TBDD_PTKH.XOA_CONGTHUC"; objCmd.CommandType = CommandType.StoredProcedure;
                objCmd.Parameters.Add("pMA_DVIQLY", OracleType.VarChar).Value = pMA_DVIQLY;
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
        public void XOA_VATTU_DONVI(string pMA_DVIQLY, string PMA_VT, string PMANSX, string PID)
        {
            OracleConnection objConn = new OracleConnection(ConnectString.ConnectionString(pMA_DVIQLY));
            OracleCommand objCmd = new OracleCommand();
            try
            {
                objConn.Open();
                objCmd.Connection = objConn;
                objCmd.CommandText = "PKG_TBDD_PTKH.XOA_VATTU_DONVI"; objCmd.CommandType = CommandType.StoredProcedure;
                objCmd.Parameters.Add("pMA_DVIQLY", OracleType.VarChar).Value = pMA_DVIQLY;
                objCmd.Parameters.Add("pMA_VT", OracleType.VarChar).Value = PMA_VT;
                objCmd.Parameters.Add("pMANSX", OracleType.VarChar).Value = PMANSX;
                objCmd.Parameters.Add("pID", OracleType.VarChar).Value = PID;

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
