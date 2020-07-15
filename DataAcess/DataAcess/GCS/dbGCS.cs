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
    public class dbGCS
    {
        public DataTable SELECT_GCS_BYMASO(string pMA_DVIQLY, string MA_SOGCS, string KY, int pTHANG, int pNAM, string imei)
        {
            DataTable dt = new DataTable();
            OracleConnection objConn = new OracleConnection(ConnectString.ConnectionString(pMA_DVIQLY));
            OracleCommand objCmd = new OracleCommand();
            try
            {
                objConn.Open();
                objCmd.Connection = objConn;
                objCmd.CommandText = "PKG_GCS.SELECT_GCS_BYMASO";
                objCmd.CommandType = CommandType.StoredProcedure;
                objCmd.Parameters.Add("pMA_DVIQLY", OracleType.VarChar).Value = pMA_DVIQLY;
                objCmd.Parameters.Add("pMA_SOGCS", OracleType.VarChar).Value = MA_SOGCS;
                objCmd.Parameters.Add("pKY", OracleType.Number).Value = KY;
                objCmd.Parameters.Add("pTHANG", OracleType.Number).Value = pTHANG;
                objCmd.Parameters.Add("pNAM", OracleType.Number).Value = pNAM;
                objCmd.Parameters.Add("pIMEI", OracleType.VarChar).Value = imei;
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
        public DataTable Select_ByIDThietBiDD(string pMA_DVIQLY, string pIMEI)
        {
            DataTable dt = new DataTable();
            OracleConnection objConn = new OracleConnection(ConnectString.ConnectionString(pMA_DVIQLY));
            OracleCommand objCmd = new OracleCommand();
            try
            {
                objConn.Open();
                objCmd.Connection = objConn;
                objCmd.CommandText = "PKG_MV_HAMDLKHAC.Select_ByIDThietBiDD";
                objCmd.CommandType = CommandType.StoredProcedure;
                objCmd.Parameters.Add("pMA_DVIQLY", OracleType.VarChar).Value = pMA_DVIQLY;
                objCmd.Parameters.Add("pIMEI", OracleType.VarChar).Value = pIMEI;
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
        public void Update_ThietBiDD(string pMA_DVIQLY, string pIP, string pIMEI, string pTENDINHDANH, string pHANGSX, string pHEDIEUHANH, DateTime pNGAYCAPNHAT, string pCHUNGLOAI)
        {
            OracleConnection objConn = new OracleConnection(ConnectString.ConnectionString(pMA_DVIQLY));
            OracleCommand objCmd = new OracleCommand();
            try
            {
                objConn.Open();
                objCmd.Connection = objConn;
                objCmd.CommandText = "PKG_MV_HAMDLKHAC.Update_ThietBiDD";
                objCmd.CommandType = CommandType.StoredProcedure;
                objCmd.Parameters.Add("pMA_DVIQLY", OracleType.VarChar).Value = pMA_DVIQLY;
                objCmd.Parameters.Add("pIP", OracleType.VarChar).Value = pIP;
                objCmd.Parameters.Add("pIMEI", OracleType.VarChar).Value = pIMEI;
                objCmd.Parameters.Add("pTENDINHDANH", OracleType.VarChar).Value = pTENDINHDANH;
                objCmd.Parameters.Add("pNGAYCAPNHAT", OracleType.DateTime).Value = pNGAYCAPNHAT;
                objCmd.Parameters.Add("pHANGSX", OracleType.VarChar).Value = pHANGSX;
                objCmd.Parameters.Add("pHEDIEUHANH", OracleType.VarChar).Value = pHEDIEUHANH;
                objCmd.Parameters.Add("pCHUNGLOAI", OracleType.VarChar).Value = pCHUNGLOAI;
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
        public void Insert_ThietBiDD(string pMA_DVIQLY, string pIP, string pIMEI, string pTENDINHDANH, string pHANGSX, string pHEDIEUHANH, DateTime pNGAYCAPNHAT, string pCHUNGLOAI)
        {
            OracleConnection objConn = new OracleConnection(ConnectString.ConnectionString(pMA_DVIQLY));
            OracleCommand objCmd = new OracleCommand();
            try
            {
                objConn.Open();
                objCmd.Connection = objConn;
                objCmd.CommandText = "PKG_MV_HAMDLKHAC.Insert_ThietBiDD";
                objCmd.CommandType = CommandType.StoredProcedure;
                objCmd.Parameters.Add("pMA_DVIQLY", OracleType.VarChar).Value = pMA_DVIQLY;
                objCmd.Parameters.Add("pIP", OracleType.VarChar).Value = pIP;
                objCmd.Parameters.Add("pIMEI", OracleType.VarChar).Value = pIMEI;
                objCmd.Parameters.Add("pTENDINHDANH", OracleType.VarChar).Value = pTENDINHDANH;
                objCmd.Parameters.Add("pNGAYCAPNHAT", OracleType.DateTime).Value = pNGAYCAPNHAT;
                objCmd.Parameters.Add("pHANGSX", OracleType.VarChar).Value = pHANGSX;
                objCmd.Parameters.Add("pHEDIEUHANH", OracleType.VarChar).Value = pHEDIEUHANH;
                objCmd.Parameters.Add("pCHUNGLOAI", OracleType.VarChar).Value = pCHUNGLOAI;
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
        public void Delete_ThietBiDD(string pMA_DVIQLY, string pIMEI)
        {
            OracleConnection objConn = new OracleConnection(ConnectString.ConnectionString(pMA_DVIQLY));
            OracleCommand objCmd = new OracleCommand();
            try
            {
                objConn.Open();
                objCmd.Connection = objConn;
                objCmd.CommandText = "PKG_MV_HAMDLKHAC.Delete_ThietBiDD";
                objCmd.CommandType = CommandType.StoredProcedure;
                objCmd.Parameters.Add("pMA_DVIQLY", OracleType.VarChar).Value = pMA_DVIQLY;
                objCmd.Parameters.Add("pIMEI", OracleType.VarChar).Value = pIMEI;
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
        public void UpdateTrangThaiExportDuLieu(string pMA_DVIQLY, string MA_SOGCS, string KY, int pTHANG, int pNAM)
        {
            OracleConnection objConn = new OracleConnection(ConnectString.ConnectionString(pMA_DVIQLY));
            OracleCommand objCmd = new OracleCommand();
            try
            {
                objConn.Open();
                objCmd.Connection = objConn;
                objCmd.CommandText = "PKG_GCS.UpdateTrangThaiExportDuLieu";
                objCmd.CommandType = CommandType.StoredProcedure;
                objCmd.Parameters.Add("pMA_DVIQLY", OracleType.VarChar).Value = pMA_DVIQLY;
                objCmd.Parameters.Add("pMA_SOGCS", OracleType.VarChar).Value = MA_SOGCS;
                objCmd.Parameters.Add("pKY", OracleType.Number).Value = KY;
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
        public DataTable SelectAllThietBiDD(string pMA_DVIQLY)
        {
            DataTable dt = new DataTable();
            OracleConnection objConn = new OracleConnection(ConnectString.ConnectionString(pMA_DVIQLY));
            OracleCommand objCmd = new OracleCommand();
            try
            {
                objConn.Open();
                objCmd.Connection = objConn;
                objCmd.CommandText = "PKG_MV_HAMDLKHAC.SelectAllThietBiDD";
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
        public DataTable SELECT_KH_BYSOGCS(string pMA_DVIQLY, int KY, int pTHANG, int pNAM, string MA_SOGCS_TEN, string LOAIVIEW)
        {
            DataTable dt = new DataTable();
            OracleConnection objConn = new OracleConnection(ConnectString.ConnectionString(pMA_DVIQLY));
            OracleCommand objCmd = new OracleCommand();
            try
            {
                objConn.Open();

                objCmd.Connection = objConn;
                objCmd.CommandText = "PKG_GCS.SELECT_KH_BYSOGCS";
                objCmd.CommandType = CommandType.StoredProcedure;
                objCmd.Parameters.Add("pMA_DVIQLY", OracleType.VarChar).Value = pMA_DVIQLY;
                objCmd.Parameters.Add("pMA_SOGCS", OracleType.VarChar).Value = MA_SOGCS_TEN;
                objCmd.Parameters.Add("pKY", OracleType.Number).Value = KY;
                objCmd.Parameters.Add("pTHANG", OracleType.Number).Value = pTHANG;
                objCmd.Parameters.Add("pNAM", OracleType.Number).Value = pNAM;
                objCmd.Parameters.Add("pLOAIVIEW", OracleType.VarChar).Value = LOAIVIEW;
                objCmd.Parameters.Add("rs", OracleType.Cursor).Direction = ParameterDirection.Output;
                OracleDataReader objReader = objCmd.ExecuteReader();
                dt.Load(objReader);
                return dt;
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
        public DataTable SELECT_SANLUONG_BATTHUONG(string pMA_DVIQLY, int KY, int pTHANG, int pNAM, string pMA_SOGCS, string pLOAI_CHISO, int pPHANTRAM, int KIEUIN)
        {
            DataTable dt = new DataTable();
            OracleConnection objConn = new OracleConnection(ConnectString.ConnectionString(pMA_DVIQLY));
            OracleCommand objCmd = new OracleCommand();
            try
            {
                objConn.Open();

                objCmd.Connection = objConn;
                objCmd.CommandText = "PKG_GCS.SELECT_SANLUONG_BATTHUONG";
                objCmd.CommandType = CommandType.StoredProcedure;
                objCmd.Parameters.Add("pMA_DVIQLY", OracleType.VarChar).Value = pMA_DVIQLY;
                objCmd.Parameters.Add("pKY", OracleType.Number).Value = KY;
                objCmd.Parameters.Add("pTHANG", OracleType.Number).Value = pTHANG;
                objCmd.Parameters.Add("pNAM", OracleType.Number).Value = pNAM;
                objCmd.Parameters.Add("pMA_SOGCS", OracleType.VarChar).Value = pMA_SOGCS;
                objCmd.Parameters.Add("pLOAI_CHISO", OracleType.VarChar).Value = pLOAI_CHISO;
                objCmd.Parameters.Add("pPHANTRAM", OracleType.Number).Value = pPHANTRAM;
                objCmd.Parameters.Add("pKIEUIN", OracleType.Number).Value = KIEUIN;
                objCmd.Parameters.Add("rs", OracleType.Cursor).Direction = ParameterDirection.Output;

                OracleDataAdapter adapter = new OracleDataAdapter(objCmd);
                adapter.Fill(dt);

                //OracleDataReader objReader = objCmd.ExecuteReader();
                //dt.Load(objReader);
                objConn.Close();
                objCmd.Dispose();
                objCmd = null;
                return dt;
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
        public DataTable SELECT_NHANVIENGCS(string pMA_DVIQLY, int KY, int pTHANG, int pNAM, string pLOAI)
        {
            DataTable dt = new DataTable();
            OracleConnection objConn = new OracleConnection(ConnectString.ConnectionString(pMA_DVIQLY));
            OracleCommand objCmd = new OracleCommand();
            try
            {
                objConn.Open();

                objCmd.Connection = objConn;
                objCmd.CommandText = "PKG_GCS.SELECT_NHANVIENGCS";
                objCmd.CommandType = CommandType.StoredProcedure;
                objCmd.Parameters.Add("pMA_DVIQLY", OracleType.VarChar).Value = pMA_DVIQLY;
                objCmd.Parameters.Add("pKY", OracleType.Number).Value = KY;
                objCmd.Parameters.Add("pTHANG", OracleType.Number).Value = pTHANG;
                objCmd.Parameters.Add("pNAM", OracleType.Number).Value = pNAM;
                objCmd.Parameters.Add("pLOAI", OracleType.VarChar).Value = pLOAI;
                objCmd.Parameters.Add("rs", OracleType.Cursor).Direction = ParameterDirection.Output;
                OracleDataReader objReader = objCmd.ExecuteReader();
                dt.Load(objReader);
                objConn.Close();
                objCmd.Dispose();
                objCmd = null;
                return dt;
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

        public DataTable login(string pMA_DVIQLY, string u, string imei, string p, string pLOAI)
        {
            DataTable dt = new DataTable();
            OracleConnection objConn = new OracleConnection(ConnectString.ConnectionString(pMA_DVIQLY));
            OracleCommand objCmd = new OracleCommand();
            try
            {
                objConn.Open();

                objCmd.Connection = objConn;
                objCmd.CommandText = "PKG_GCS.SELECT_BYUSER_PASS_IMEI";
                objCmd.CommandType = CommandType.StoredProcedure;
                objCmd.Parameters.Add("pUSERNAME", OracleType.VarChar).Value = u;
                objCmd.Parameters.Add("pPASSWORD", OracleType.VarChar).Value = p;
                objCmd.Parameters.Add("pIMEI", OracleType.VarChar).Value = imei;
                objCmd.Parameters.Add("sTypeUserName", OracleType.VarChar).Value = pLOAI;
                objCmd.Parameters.Add("rs", OracleType.Cursor).Direction = ParameterDirection.Output;
                OracleDataReader objReader = objCmd.ExecuteReader();
                dt.Load(objReader);
                objConn.Close();
                objCmd.Dispose();
                objCmd = null;
                return dt;
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
        public DataTable SELECT_TENFILE_XN(string pMA_DVIQLY, int KY, int pTHANG, int pNAM, string pLOAI, string pIMEI)
        {
            DataTable dt = new DataTable();
            OracleConnection objConn = new OracleConnection(ConnectString.ConnectionString(pMA_DVIQLY));
            OracleCommand objCmd = new OracleCommand();
            try
            {
                objConn.Open();

                objCmd.Connection = objConn;
                objCmd.CommandText = "PKG_GCS.SELECT_TENFILE_XN";
                objCmd.CommandType = CommandType.StoredProcedure;
                objCmd.Parameters.Add("pMA_DVIQLY", OracleType.VarChar).Value = pMA_DVIQLY;
                objCmd.Parameters.Add("pKY", OracleType.Number).Value = KY;
                objCmd.Parameters.Add("pTHANG", OracleType.Number).Value = pTHANG;
                objCmd.Parameters.Add("pNAM", OracleType.Number).Value = pNAM;
                objCmd.Parameters.Add("pLOAI", OracleType.VarChar).Value = pLOAI;
                objCmd.Parameters.Add("pIMEI", OracleType.VarChar).Value = pIMEI;
                objCmd.Parameters.Add("rs", OracleType.Cursor).Direction = ParameterDirection.Output;
                OracleDataReader objReader = objCmd.ExecuteReader();
                dt.Load(objReader);
                objConn.Close();
                objCmd.Dispose();
                objCmd = null;
                return dt;
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
        public void DELETE_TENFILE_XN(string pMA_DVIQLY, int KY, int pTHANG, int pNAM, string TENFILE,string pLoai)
        {
            OracleConnection objConn = new OracleConnection(ConnectString.ConnectionString(pMA_DVIQLY));
            OracleCommand objCmd = new OracleCommand();
            try
            {
                objConn.Open();

                objCmd.Connection = objConn;
                objCmd.CommandText = "PKG_GCS.DELETE_TENFILE_XN";
                objCmd.CommandType = CommandType.StoredProcedure;
                objCmd.Parameters.Add("pMA_DVIQLY", OracleType.VarChar).Value = pMA_DVIQLY;
                objCmd.Parameters.Add("pKY", OracleType.Number).Value = KY;
                objCmd.Parameters.Add("pTHANG", OracleType.Number).Value = pTHANG;
                objCmd.Parameters.Add("pNAM", OracleType.Number).Value = pNAM;
                objCmd.Parameters.Add("pTENFILE", OracleType.VarChar).Value = TENFILE;
                objCmd.Parameters.Add("pLOAI", OracleType.VarChar).Value = pLoai;
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
        public void UPDATE_IMEI_PHANSOGCS(string pMA_DVIQLY, int KY, int pTHANG, int pNAM, string pMA_DDO, string IMEI)
        {
            OracleConnection objConn = new OracleConnection(ConnectString.ConnectionString(pMA_DVIQLY));
            OracleCommand objCmd = new OracleCommand();
            try
            {
                objConn.Open();

                objCmd.Connection = objConn;
                objCmd.CommandText = "PKG_GCS.UPDATE_IMEI_PHANSOGCS";
                objCmd.CommandType = CommandType.StoredProcedure;
                objCmd.Parameters.Add("pMA_DVIQLY", OracleType.VarChar).Value = pMA_DVIQLY;
                objCmd.Parameters.Add("pKY", OracleType.Number).Value = KY;
                objCmd.Parameters.Add("pTHANG", OracleType.Number).Value = pTHANG;
                objCmd.Parameters.Add("pNAM", OracleType.Number).Value = pNAM;
                objCmd.Parameters.Add("pMA_DDO", OracleType.VarChar).Value = pMA_DDO;
                objCmd.Parameters.Add("pIMEI", OracleType.VarChar).Value = IMEI;
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
        public void UpdateImeiGiao(string pMA_DVIQLY, int KY, int pTHANG, int pNAM, string pMA_SOGCS, string IMEI)
        {
            OracleConnection objConn = new OracleConnection(ConnectString.ConnectionString(pMA_DVIQLY));
            OracleCommand objCmd = new OracleCommand();
            try
            {
                objConn.Open();

                objCmd.Connection = objConn;
                objCmd.CommandText = "PKG_GCS.UPDATEIMEIGIAO";
                objCmd.CommandType = CommandType.StoredProcedure;
                objCmd.Parameters.Add("pMA_DVIQLY", OracleType.VarChar).Value = pMA_DVIQLY;
                objCmd.Parameters.Add("pKY", OracleType.Number).Value = KY;
                objCmd.Parameters.Add("pTHANG", OracleType.Number).Value = pTHANG;
                objCmd.Parameters.Add("pNAM", OracleType.Number).Value = pNAM;
                objCmd.Parameters.Add("pMA_SOGCS", OracleType.VarChar).Value = pMA_SOGCS;
                objCmd.Parameters.Add("pIMEI", OracleType.VarChar).Value = IMEI;
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
        //public DataTable SELECTNGAY_CN(string pMA_DVIQLY, string KY, int pTHANG, int pNAM, int pLOAI)
        //{
        //    DataTable dt = new DataTable();
        //    OracleConnection objConn = new OracleConnection(ConnectString.ConnectionString(pMA_DVIQLY));
        //    OracleCommand objCmd = new OracleCommand();
        //    try
        //    {
        //        objConn.Open();

        //        objCmd.Connection = objConn;
        //        objCmd.CommandText = "PKG_MV_XEMBAOCAO.SELECTNGAY_CN";
        //        objCmd.CommandType = CommandType.StoredProcedure;
        //        objCmd.Parameters.Add("pMA_DVIQLY", OracleType.VarChar).Value = pMA_DVIQLY;
        //        objCmd.Parameters.Add("pLOAI", OracleType.Number).Value = pLOAI;
        //        objCmd.Parameters.Add("pTHANG", OracleType.Number).Value = pTHANG;
        //        objCmd.Parameters.Add("pNAM", OracleType.Number).Value = pNAM;
        //        objCmd.Parameters.Add("pKY", OracleType.VarChar).Value = KY;

        //        objCmd.Parameters.Add("rs", OracleType.Cursor).Direction = ParameterDirection.Output;
        //        OracleDataReader objReader = objCmd.ExecuteReader();
        //        dt.Load(objReader);
        //        objConn.Close();
        //        objCmd.Dispose();
        //        objCmd = null;
        //    }

        //    catch (Exception ex)
        //    {
        //        System.Console.WriteLine("Exception: {0}", ex.ToString());
        //    }
        //    finally
        //    {
        //        objConn.Close();
        //        objConn.Dispose();

        //        objCmd = null;
        //    }
        //    return dt;
        //}
        public void INSERT_GHIDL(string pMA_DVIQLY, string pMA_NVIEN, string pIMEI, string pPASS, string pLOAI, int pID_USERTB, ref int pIDOUT, string pLOAIDN)
        {
            OracleConnection objConn = new OracleConnection(ConnectString.ConnectionString(pMA_DVIQLY));
            OracleCommand objCmd = new OracleCommand();
            try
            {

                DbParameter ID = CreateParameter("pIDOUT", DbType.Int32, true);
                objConn.Open();
                objCmd.Connection = objConn;
                objCmd.CommandText = "PKG_MV_HAMDLKHAC.INSERT_GHIDL";
                objCmd.CommandType = CommandType.StoredProcedure;
                objCmd.Parameters.Add("pMA_DVIQLY", OracleType.VarChar).Value = pMA_DVIQLY;
                objCmd.Parameters.Add("pIMEI", OracleType.VarChar).Value = pIMEI;
                objCmd.Parameters.Add("pMA_NVIEN", OracleType.VarChar).Value = pMA_NVIEN;
                objCmd.Parameters.Add("pPASS", OracleType.VarChar).Value = pPASS;
                objCmd.Parameters.Add("pLOAI", OracleType.VarChar).Value = pLOAI;
                objCmd.Parameters.Add("pID_USERTB", OracleType.Number).Value = pID_USERTB;
                //objCmd.Parameters.Add("pIDOUT", OracleType.Number).Direction = ParameterDirection.Output;
                objCmd.Parameters.Add(ID);
                objCmd.Parameters.Add("pLOAIDN", OracleType.VarChar).Value = pLOAIDN;
                OracleDataReader objReader = objCmd.ExecuteReader();
                pIDOUT = (int)ID.Value;
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
        //public DataTable SELECT_CN_TOANDV(string pMA_DVIQLY, string KY, int pTHANG, int pNAM, int pLOAI)
        //{
        //    DataTable dt = new DataTable();
        //    OracleConnection objConn = new OracleConnection(ConnectString.ConnectionString(pMA_DVIQLY));
        //    OracleCommand objCmd = new OracleCommand();
        //    try
        //    {
        //        objConn.Open();

        //        objCmd.Connection = objConn;
        //        objCmd.CommandText = "PKG_MV_XEMBAOCAO.SELECT_CN_TOANDV";
        //        objCmd.CommandType = CommandType.StoredProcedure;
        //        objCmd.Parameters.Add("pMA_DVIQLY", OracleType.VarChar).Value = pMA_DVIQLY;
        //        objCmd.Parameters.Add("pLOAI", OracleType.Number).Value = pLOAI;
        //        objCmd.Parameters.Add("pTHANG", OracleType.Number).Value = pTHANG;
        //        objCmd.Parameters.Add("pNAM", OracleType.Number).Value = pNAM;
        //        objCmd.Parameters.Add("pKY", OracleType.VarChar).Value = KY;

        //        objCmd.Parameters.Add("rs", OracleType.Cursor).Direction = ParameterDirection.Output;
        //        OracleDataReader objReader = objCmd.ExecuteReader();
        //        dt.Load(objReader);
        //        objConn.Close();
        //        objCmd.Dispose();
        //        objCmd = null;
        //        return dt;
        //    }

        //    catch (Exception ex)
        //    {
        //        System.Console.WriteLine("Exception: {0}", ex.ToString());
        //    }
        //    finally
        //    {
        //        objConn.Close();
        //        objConn.Dispose();

        //        objCmd = null;
        //    }
        //    return dt;
        //}
        public DataTable SELECT_BANGTAMMV(string pMA_DVIQLY, int KY, int pTHANG, int pNAM, string pLOAI)
        {
            DataTable dt = new DataTable();
            OracleConnection objConn = new OracleConnection(ConnectString.ConnectionString(pMA_DVIQLY));
            OracleCommand objCmd = new OracleCommand();
            try
            {
                objConn.Open();

                objCmd.Connection = objConn;
                objCmd.CommandText = "PKG_GCS.SELECT_BANGTAMMV";
                objCmd.CommandType = CommandType.StoredProcedure;
                objCmd.Parameters.Add("pMA_DVIQLY", OracleType.VarChar).Value = pMA_DVIQLY;
                objCmd.Parameters.Add("pLOAI", OracleType.VarChar).Value = pLOAI;
                objCmd.Parameters.Add("pTHANG", OracleType.Number).Value = pTHANG;
                objCmd.Parameters.Add("pNAM", OracleType.Number).Value = pNAM;
                objCmd.Parameters.Add("pKY", OracleType.Number).Value = KY;
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
        public void INSERTBANGTAM_SOGCS(string pMA_DVIQLY,string pMA_SOGCS, int pKY, int pTHANG, int pNAM, string pLOAI)
        {
            OracleConnection objConn = new OracleConnection(ConnectString.ConnectionString(pMA_DVIQLY));
            OracleCommand objCmd = new OracleCommand();
            try
            {
                objConn.Open();
                objCmd.Connection = objConn;
                objCmd.CommandText = "PKG_GCS.INSERTBANGTAM_SOGCS";
                objCmd.CommandType = CommandType.StoredProcedure;
                objCmd.Parameters.Add("pMA_DVIQLY", OracleType.VarChar).Value = pMA_DVIQLY;
                objCmd.Parameters.Add("pMA_SOGCS", OracleType.VarChar).Value = pMA_SOGCS;
                objCmd.Parameters.Add("pKY", OracleType.Number).Value = pKY;
                objCmd.Parameters.Add("pTHANG", OracleType.Number).Value = pTHANG;
                objCmd.Parameters.Add("pNAM", OracleType.Number).Value = pNAM;
                objCmd.Parameters.Add("pLOAI", OracleType.VarChar).Value = pLOAI;
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
        public void DELETE_GHIDL(string pMA_DVIQLY, int pID_USERTB, string pLOAIDN)
        {
            OracleConnection objConn = new OracleConnection(ConnectString.ConnectionString(pMA_DVIQLY));
            OracleCommand objCmd = new OracleCommand();
            try
            {
                objConn.Open();
                objCmd.Connection = objConn;
                objCmd.CommandText = "PKG_MV_HAMDLKHAC.DELETE_GHIDL";
                objCmd.CommandType = CommandType.StoredProcedure;
                objCmd.Parameters.Add("pMA_DVIQLY", OracleType.VarChar).Value = pMA_DVIQLY;
                objCmd.Parameters.Add("pID_USERTB", OracleType.Number).Value = pID_USERTB;
                objCmd.Parameters.Add("pLOAIDN", OracleType.VarChar).Value = pLOAIDN;
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
        public void CHECKPASSTRUNG(string pMA_DVIQLY, string pPASSWORD, ref int pTT)
        {
            OracleConnection objConn = new OracleConnection(ConnectString.ConnectionString(pMA_DVIQLY));
            OracleCommand objCmd = new OracleCommand();
            try
            {
                objConn.Open();
                objCmd.Connection = objConn;
                objCmd.CommandText = @"select count(*) from TBCD_USER_THIETBI where PASSWORD  = '" + pPASSWORD + "'";
                OracleDataReader objReader = objCmd.ExecuteReader();
                if (!objReader.HasRows)
                {
                    return;
                }
                using (objReader)
                {
                    objReader.Read();
                    OracleNumber tt = objReader.GetOracleNumber(0);
                    pTT = int.Parse(tt.Value + "");
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
        public DataTable SELECT_USER_TB_CS(string pMA_DVIQLY, int pTHANG, int pNAM, string pLOAI, string pIMEI, string pMA_NVIEN)
        {
            DataTable dt = new DataTable();
            OracleConnection objConn = new OracleConnection(ConnectString.ConnectionString(pMA_DVIQLY));
            OracleCommand objCmd = new OracleCommand();
            try
            {
                objConn.Open();
                objCmd.Connection = objConn;
                objCmd.CommandText = "PKG_GCS.SELEC_USER_TB_CS";
                objCmd.CommandType = CommandType.StoredProcedure;
                objCmd.Parameters.Add("pMA_DVIQLY", OracleType.VarChar).Value = pMA_DVIQLY;
                objCmd.Parameters.Add("pTHANG", OracleType.Number).Value = pTHANG;
                objCmd.Parameters.Add("pNAM", OracleType.Number).Value = pNAM;
                objCmd.Parameters.Add("pLOAI", OracleType.VarChar).Value = pLOAI;
                objCmd.Parameters.Add("pIMEI", OracleType.VarChar).Value = pIMEI;
                objCmd.Parameters.Add("pMA_NVIEN", OracleType.VarChar).Value = pMA_NVIEN;
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
        public DataTable SELECT_ALL_NHANVIEN_CD(string pMA_DVIQLY, string pLOAIDN)
        {
            DataTable dt = new DataTable();
            OracleConnection objConn = new OracleConnection(ConnectString.ConnectionString(pMA_DVIQLY));
            OracleCommand objCmd = new OracleCommand();
            try
            {
                objConn.Open();

                objCmd.Connection = objConn;
                objCmd.CommandText = "PKG_MV_HAMDLKHAC.SELECT_ALL_NHANVIEN_CD";
                objCmd.CommandType = CommandType.StoredProcedure;
                objCmd.Parameters.Add("pMA_DVIQLY", OracleType.VarChar).Value = pMA_DVIQLY;
                objCmd.Parameters.Add("pLOAIDN", OracleType.VarChar).Value = pLOAIDN;
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
        public DataTable SELECT_THIETBI_CHUASUDUNG(string pMA_DVIQLY, string pLOAIDN)
        {
            DataTable dt = new DataTable();
            OracleConnection objConn = new OracleConnection(ConnectString.ConnectionString(pMA_DVIQLY));
            OracleCommand objCmd = new OracleCommand();
            try
            {
                objConn.Open();

                objCmd.Connection = objConn;
                objCmd.CommandText = "PKG_GCS.SELECT_THIETBI_CHUASUDUNG";
                objCmd.CommandType = CommandType.StoredProcedure;
                objCmd.Parameters.Add("pMA_DVIQLY", OracleType.VarChar).Value = pMA_DVIQLY;
                objCmd.Parameters.Add("pLOAIDN", OracleType.VarChar).Value = pLOAIDN;
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

        public void UpdateGCS_MTB(string MA_DVIQLY, DataSet ds, int pthang, int pnam)
        {
            int count = 0;
            decimal tientamtinh = 0;
            decimal THUEVAT = 0;
            decimal KINHDO = 0;
            decimal VIDO = 0;
            decimal PMAX = 0;
            DateTime NGAY_PMAX = DateTime.Now;
            DateTime testDay = DateTime.Now;
            for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
            {
                //update chi so
                if (ds.Tables[0].Columns.Contains("TIENTAMTINH"))
                    if (ds.Tables[0].Rows[i]["TIENTAMTINH"] != null)
                        tientamtinh = decimal.Parse("0" + ds.Tables[0].Rows[i]["TIENTAMTINH"]);
                if (ds.Tables[0].Columns.Contains("THUEVAT"))
                    if (ds.Tables[0].Rows[i]["THUEVAT"] != null)
                        THUEVAT = decimal.Parse("0" + ds.Tables[0].Rows[i]["THUEVAT"]);
                if (ds.Tables[0].Columns.Contains("KINHDO"))
                    if (ds.Tables[0].Rows[i]["KINHDO"] != null)
                        KINHDO = decimal.Parse("0" + ds.Tables[0].Rows[i]["KINHDO"]);
                if (ds.Tables[0].Columns.Contains("VIDO"))
                    if (ds.Tables[0].Rows[i]["VIDO"] != null)
                        VIDO = decimal.Parse("0" + ds.Tables[0].Rows[i]["VIDO"]);

                if (ds.Tables[0].Rows[i]["LOAI_BCS"] + "" == "KT")
                {
                    PMAX = 0;
                    try
                    {
                        updateChiSo(MA_DVIQLY, decimal.Parse(ds.Tables[0].Rows[i]["BOCSO_ID"] + ""),

                             pthang,
                                                pnam, int.Parse("0" + ds.Tables[0].Rows[i]["KY"]), "",
                                                ds.Tables[0].Rows[i]["MA_DDO"] + "",
                                                decimal.Parse("0" + ds.Tables[0].Rows[i]["CS_MOI"]), ds.Tables[0].Rows[i]["TTR_MOI"] + "",
                                                "",
                                                ds.Tables[0].Rows[i]["GHICHU"] + "", ds.Tables[0].Rows[i]["LOAI_BCS"] + "",
                                                decimal.Parse("0" + ds.Tables[0].Rows[i]["SL_MOI"] + ""),
                                                 tientamtinh, THUEVAT, KINHDO, VIDO, 0, DateTime.Now);
                    }
                    catch (Exception ex)
                    {
                    }
                    finally
                    {
                    }
                }
                else
                {
                    if (ds.Tables[0].Columns.Contains("PMAX"))
                    {
                        if (ds.Tables[0].Rows[i]["PMAX"] != null)
                        {
                            if (ds.Tables[0].Rows[i]["PMAX"] + "" == "null")
                                PMAX = 0;
                            else
                                PMAX = decimal.Parse("0" + ds.Tables[0].Rows[i]["PMAX"]);
                        }
                    }

                    if (ds.Tables[0].Columns.Contains("NGAY_PMAX"))
                    {
                        if (ds.Tables[0].Rows[i]["NGAY_PMAX"] != null)
                        {
                            if (DateTime.TryParse(ds.Tables[0].Rows[i]["NGAY_PMAX"].ToString().Split('/')[1] + "/" + ds.Tables[0].Rows[i]["NGAY_PMAX"].ToString().Split('/')[0] + "/" + ds.Tables[0].Rows[i]["NGAY_PMAX"].ToString().Split('/')[2], out testDay))
                                NGAY_PMAX = DateTime.Parse(ds.Tables[0].Rows[i]["NGAY_PMAX"].ToString().Split('/')[1] + "/" + ds.Tables[0].Rows[i]["NGAY_PMAX"].ToString().Split('/')[0] + "/" + ds.Tables[0].Rows[i]["NGAY_PMAX"].ToString().Split('/')[2]);
                            else
                                NGAY_PMAX = DateTime.Parse("" + ds.Tables[0].Rows[i]["NGAY_PMAX"]);
                        }
                    }

                    try
                    {
                        updateChiSo(MA_DVIQLY, decimal.Parse(ds.Tables[0].Rows[i]["BOCSO_ID"] + ""),

                            pthang,
                                               pnam, int.Parse("0" + ds.Tables[0].Rows[i]["KY"]), "",
                                               ds.Tables[0].Rows[i]["MA_DDO"] + "",
                                               decimal.Parse("0" + ds.Tables[0].Rows[i]["CS_MOI"]), ds.Tables[0].Rows[i]["TTR_MOI"] + "",
                                               "",
                                               ds.Tables[0].Rows[i]["GHICHU"] + "", ds.Tables[0].Rows[i]["LOAI_BCS"] + "",
                                               decimal.Parse("0" + ds.Tables[0].Rows[i]["SL_MOI"] + ""),
                                                tientamtinh, THUEVAT, KINHDO, VIDO, PMAX, NGAY_PMAX);
                    }
                    catch (Exception ex)
                    {

                    }
                    finally
                    {

                    }


                }


            }

        }
        private void updateChiSo(string MA_DVIQLY, decimal pID_BCS, int pTHANG, int pNAM, int pKY, string pLOAI_CHISO, string pMA_DDO, decimal pCHISO_MOI, string pTT_TREO_THAO,
            string pMA_TTCTO
            , string pGHICHU, string pBCS, decimal pSANLUONG, decimal pTIENTAMTINH, decimal pTHUEVAT, decimal pKINHDO, decimal pVIDO, decimal pPMAX, DateTime pNGAY_PMAX)
        {
            OracleConnection objConn = new OracleConnection(ConnectString.ConnectionString(MA_DVIQLY));
            OracleCommand objCmd = new OracleCommand();
            try
            {
                objConn.Open();
                objCmd.Connection = objConn;
                objCmd.CommandText = "PKG_GCS.UPDATE_GCS_CHISO_MV";
                objCmd.CommandType = CommandType.StoredProcedure;
                objCmd.Parameters.Add("pMA_DVIQLY", OracleType.VarChar).Value = MA_DVIQLY;
                objCmd.Parameters.Add("pID_BCS", OracleType.Number).Value = pID_BCS;
                objCmd.Parameters.Add("pTHANG", OracleType.Number).Value = pTHANG;
                objCmd.Parameters.Add("pNAM", OracleType.Number).Value = pNAM;
                objCmd.Parameters.Add("pKY", OracleType.Number).Value = pKY;
                objCmd.Parameters.Add("pLOAI_CHISO", OracleType.VarChar).Value = pLOAI_CHISO;
                objCmd.Parameters.Add("pMA_DDO", OracleType.VarChar).Value = pMA_DDO;
                objCmd.Parameters.Add("pCHISO_MOI", OracleType.VarChar).Value = pCHISO_MOI;
                objCmd.Parameters.Add("pTT_TREO_THAO", OracleType.VarChar).Value = pTT_TREO_THAO;
                objCmd.Parameters.Add("pMA_TTCTO", OracleType.VarChar).Value = pMA_TTCTO;
                objCmd.Parameters.Add("pGHICHU", OracleType.VarChar).Value = pGHICHU;
                objCmd.Parameters.Add("pBCS", OracleType.VarChar).Value = pBCS;
                objCmd.Parameters.Add("pSANLUONG", OracleType.Number).Value = pSANLUONG;
                objCmd.Parameters.Add("pTIENTAMTINH", OracleType.Number).Value = pTIENTAMTINH;
                objCmd.Parameters.Add("pTHUEVAT", OracleType.Number).Value = pTHUEVAT;
                objCmd.Parameters.Add("pKINHDO", OracleType.Number).Value = pKINHDO;
                objCmd.Parameters.Add("pVIDO", OracleType.Number).Value = pVIDO;
                objCmd.Parameters.Add("pPMAX", OracleType.Number).Value = pPMAX;
                objCmd.Parameters.Add("pNGAY_PMAX", OracleType.DateTime).Value = pNGAY_PMAX;
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
        public void INSERTTHUNGANVIEN(string MA_DVIQLY, string MA_TENNGAN, string TEN_TNGAN)
        {

            OracleConnection objConn = new OracleConnection(ConnectString.ConnectionString(MA_DVIQLY));
            OracleCommand objCmd = new OracleCommand();
            try
            {
                objConn.Open();
                objCmd.Connection = objConn;
                objCmd.CommandText = "PKG_MV_HAMDLKHAC_NH.INSERTTHUNGANVIEN";
                objCmd.CommandType = CommandType.StoredProcedure;
                objCmd.Parameters.Add("pMA_DVIQLY", OracleType.VarChar).Value = MA_DVIQLY;
                objCmd.Parameters.Add("pMA_TNGAN", OracleType.VarChar).Value = MA_TENNGAN;
                objCmd.Parameters.Add("pTEN_TNGAN", OracleType.VarChar).Value = TEN_TNGAN;
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
        public void Insert_Khang_GCs(DataTable dsTem, string TenFile, string ma_dv)
        {

            OracleConnection connection = new OracleConnection(ConnectString.ConnectionString(ma_dv));
            connection.Open();
            OracleCommand command = connection.CreateCommand();
            OracleTransaction transaction = connection.BeginTransaction(IsolationLevel.ReadCommitted);
            command.Transaction = transaction;
            try
            {
                //command.Connection = connection;
                command.CommandText = "PKG_GCS.INSERT_TBDD_GCS_CS_TEM";
                command.CommandType = CommandType.StoredProcedure;

                for (int i = 0; i < dsTem.Rows.Count; i++)
                {
                    command.Parameters.Clear();
                    command.Parameters.Add("pBOCSO_ID", OracleType.Number).Value = decimal.Parse("0" + dsTem.Rows[i]["BOCSO_ID"]);
                    command.Parameters.Add("pCHUOI_GIA", OracleType.VarChar).Value = dsTem.Rows[i]["CHUOI_GIA"] + "";
                    command.Parameters.Add("pCS_CU", OracleType.Number).Value = decimal.Parse("0" + dsTem.Rows[i]["CS_CU"]);
                    command.Parameters.Add("pCS_MOI", OracleType.Number).Value = decimal.Parse("0" + dsTem.Rows[i]["CS_MOI"]);
                    command.Parameters.Add("pDIA_CHI", OracleType.VarChar).Value = dsTem.Rows[i]["DIA_CHI"] + "";
                    command.Parameters.Add("pHSN", OracleType.Number).Value = decimal.Parse("0" + dsTem.Rows[i]["HSN"]);
                    command.Parameters.Add("pKIMUA_CSPK", OracleType.Number).Value = decimal.Parse("0" + dsTem.Rows[i]["KIMUA_CSPK"]);
                    command.Parameters.Add("pKY", OracleType.Number).Value = int.Parse("0" + dsTem.Rows[i]["KY"]);
                    command.Parameters.Add("pLOAI_BCS", OracleType.VarChar).Value = dsTem.Rows[i]["LOAI_BCS"] + "";
                    command.Parameters.Add("pLOAI_CS", OracleType.VarChar).Value = dsTem.Rows[i]["LOAI_CS"] + "";
                    command.Parameters.Add("pMA_COT", OracleType.VarChar).Value = dsTem.Rows[i]["MA_COT"] + "";
                    command.Parameters.Add("pMA_CTO", OracleType.VarChar).Value = dsTem.Rows[i]["MA_CTO"] + "";
                    command.Parameters.Add("pMA_DDO", OracleType.VarChar).Value = dsTem.Rows[i]["MA_DDO"] + "";
                    command.Parameters.Add("pMA_DVIQLY", OracleType.VarChar).Value = dsTem.Rows[i]["MA_DVIQLY"] + "";
                    command.Parameters.Add("pMA_GC", OracleType.VarChar).Value = dsTem.Rows[i]["MA_GC"] + "";
                    command.Parameters.Add("pMA_KHANG", OracleType.VarChar).Value = dsTem.Rows[i]["MA_KHANG"] + "";
                    command.Parameters.Add("pMA_NN", OracleType.VarChar).Value = dsTem.Rows[i]["MA_NN"] + "";
                    command.Parameters.Add("pMA_NVGCS", OracleType.VarChar).Value = dsTem.Rows[i]["MA_NVGCS"] + "";
                    command.Parameters.Add("pMA_QUYEN", OracleType.VarChar).Value = dsTem.Rows[i]["MA_QUYEN"] + "";
                    command.Parameters.Add("pMA_TRAM", OracleType.VarChar).Value = "" + dsTem.Rows[i]["MA_TRAM"];
                    command.Parameters.Add("pNAM", OracleType.Number).Value = int.Parse("0" + dsTem.Rows[i]["NAM"]);
                    command.Parameters.Add("pNGAY_CU", OracleType.DateTime).Value = DateTime.Parse("" + dsTem.Rows[i]["NGAY_CU"]);
                    command.Parameters.Add("pNGAY_MOI", OracleType.DateTime).Value = DateTime.Parse("" + dsTem.Rows[i]["NGAY_MOI"]);
                    command.Parameters.Add("pNGUOI_GCS", OracleType.VarChar).Value = "" + dsTem.Rows[i]["NGUOI_GCS"];
                    command.Parameters.Add("pSERY_CTO", OracleType.VarChar).Value = "" + dsTem.Rows[i]["SERY_CTO"];
                    command.Parameters.Add("pSL_CU", OracleType.Number).Value = decimal.Parse("0" + dsTem.Rows[i]["SL_CU"]);
                    command.Parameters.Add("pSL_MOI", OracleType.Number).Value = decimal.Parse("0" + dsTem.Rows[i]["SL_MOI"]);
                    command.Parameters.Add("pSL_THAO", OracleType.Number).Value = decimal.Parse("0" + dsTem.Rows[i]["SL_THAO"]);
                    command.Parameters.Add("pSL_TTIEP", OracleType.Number).Value = decimal.Parse("0" + dsTem.Rows[i]["SL_TTIEP"]);
                    command.Parameters.Add("pSO_HO", OracleType.Number).Value = decimal.Parse("0" + dsTem.Rows[i]["SO_HO"]);
                    command.Parameters.Add("pTEN_KHANG", OracleType.VarChar).Value = "" + dsTem.Rows[i]["TEN_KHANG"];
                    command.Parameters.Add("pTHANG", OracleType.Number).Value = int.Parse("0" + dsTem.Rows[i]["THANG"]);
                    command.Parameters.Add("pTTR_MOI", OracleType.VarChar).Value = "";
                    command.Parameters.Add("pTTR_CU", OracleType.VarChar).Value = "" + dsTem.Rows[i]["TTR_CU"];
                    command.Parameters.Add("pSLUONG_1", OracleType.Number).Value = decimal.Parse("0" + dsTem.Rows[i]["SLUONG_1"]);
                    command.Parameters.Add("pSLUONG_2", OracleType.Number).Value = decimal.Parse("0" + dsTem.Rows[i]["SLUONG_2"]);
                    command.Parameters.Add("pSLUONG_3", OracleType.Number).Value = decimal.Parse("0" + dsTem.Rows[i]["SLUONG_3"]);
                    command.Parameters.Add("pSO_HOM", OracleType.VarChar).Value = dsTem.Rows[i]["SO_HOM"] + "";
                    command.Parameters.Add("pTENFILE", OracleType.VarChar).Value = TenFile;
                    OracleDataReader objReader = command.ExecuteReader();
                }

                transaction.Commit();
            }

            catch (Exception ex)
            {
                transaction.Rollback();
                System.Console.WriteLine("Exception: {0}", ex.ToString());
            }
            finally
            {
                transaction.Dispose();
                connection.Close();
                connection.Dispose();
                command = null;
            }

        }
        public string SELECT_LAYTHANGLAMVIECtest(string pMA_DVIQLY, ref int pTHANG, ref int pNAM, ref string loi)
        {
            OracleConnection objConn = new OracleConnection(ConnectString.ConnectionString(pMA_DVIQLY));
            OracleCommand objCmd = new OracleCommand();
            try
            {
                DbParameter Thang = CreateParameter("pTHANG", DbType.Int32, true);
                DbParameter Nam = CreateParameter("pNAM", DbType.Int32, true);
                objConn.Open();
                objCmd.Connection = objConn;
                objCmd.CommandText = "PKG_GCS.SELECT_LAYTHANGLAMVIEC";
                objCmd.CommandType = CommandType.StoredProcedure;
                objCmd.Parameters.Add("pMA_DVIQLY", OracleType.VarChar).Value = pMA_DVIQLY;
                objCmd.Parameters.Add(Thang);
                objCmd.Parameters.Add(Nam);
                OracleDataReader objReader = objCmd.ExecuteReader();
                pTHANG = (int)Thang.Value;
                pNAM = (int)Nam.Value;
            }

            catch (Exception ex)
            {
                loi = ex.Message;
                return ex.Message;
            }
            finally
            {
                objConn.Close();
                objConn.Dispose();
                objCmd = null;
            }
            return ConnectString.ConnectionString(pMA_DVIQLY);
        }
        public string SELECT_LAYTHANGLAMVIEC(string pMA_DVIQLY, ref int pTHANG, ref int pNAM)
        {
            OracleConnection objConn = new OracleConnection(ConnectString.ConnectionString(pMA_DVIQLY));
            OracleCommand objCmd = new OracleCommand();
            try
            {
                DbParameter Thang = CreateParameter("pTHANG", DbType.Int32, true);
                DbParameter Nam = CreateParameter("pNAM", DbType.Int32, true);
                objConn.Open();
                objCmd.Connection = objConn;
                objCmd.CommandText = "PKG_GCS.SELECT_LAYTHANGLAMVIEC";
                objCmd.CommandType = CommandType.StoredProcedure;
                objCmd.Parameters.Add("pMA_DVIQLY", OracleType.VarChar).Value = pMA_DVIQLY;
                objCmd.Parameters.Add(Thang);
                objCmd.Parameters.Add(Nam);
                OracleDataReader objReader = objCmd.ExecuteReader();
                pTHANG = (int)Thang.Value;
                pNAM = (int)Nam.Value;
            }

            catch (Exception ex)
            {
                return ex.Message;
            }
            finally
            {
                objConn.Close();
                objConn.Dispose();
                objCmd = null;
            }
            return ConnectString.ConnectionString(pMA_DVIQLY);
        }
        public DataTable SELECT_ALL_DVIQLY(string pMA_DVIQLY)
        {
            DataTable dt = new DataTable();
            OracleConnection objConn = new OracleConnection(ConnectString.ConnectionString(pMA_DVIQLY));
            OracleCommand objCmd = new OracleCommand();
            try
            {
                objConn.Open();

                objCmd.Connection = objConn;
                objCmd.CommandText = "PKG_MV_HAMDLKHAC.SELECT_ALL_DVIQLY";
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
        public OracleParameter CreateParameter(string name, object value, bool isOutput)
        {
            OracleParameter result = new OracleParameter(name, value);
            if (isOutput)
            {
                result.Direction = ParameterDirection.Output;
            }
            else
            {
                result.Direction = ParameterDirection.Input;
            }
            return result;
        }
    }
}
