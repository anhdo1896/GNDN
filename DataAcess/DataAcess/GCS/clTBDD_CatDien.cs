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
    public class clTBDD_CatDien
    {
        private MSSqlHelper _DbHelper = new MSSqlHelper();
        public DataTable SelectAllDDo_TT(string pLOAI_LK)
        {
            DataTable dt = new DataTable();
           // return dt;
            OracleConnection objConn = new OracleConnection(ConnectString.ConnectionString("PA01"));
            OracleCommand objCmd = new OracleCommand();

            objConn.Open();
            objCmd.Connection = objConn;
            objCmd.CommandText = "PKG_PhanQuyen.SelectAllDDo_TT";
            objCmd.CommandType = CommandType.StoredProcedure;
            objCmd.Parameters.Add("pLOAI_LK", OracleType.VarChar).Value = pLOAI_LK;
            objCmd.Parameters.Add("rs", OracleType.Cursor).Direction = ParameterDirection.Output;

            OracleDataReader objReader = objCmd.ExecuteReader();
            dt.Load(objReader);
            objConn.Close();
            objCmd.Dispose();
            objCmd = null;
            // return dt;

            //objConn.Close();

            //objConn.Dispose();

            //objCmd = null;

            return dt;
        }
        public DataTable SelectAllCongTo(string pMA_DDO)
        {
            DataTable dt = new DataTable();
            OracleConnection objConn = new OracleConnection(ConnectString.ConnectionString(""));
            OracleCommand objCmd = new OracleCommand();
            try
            {
                objConn.Open();

                objCmd.Connection = objConn;
                objCmd.CommandText = "PKG_PhanQuyen.SelectAllCongTo";
                objCmd.CommandType = CommandType.StoredProcedure;
                objCmd.Parameters.Add("pMA_DDO", OracleType.VarChar).Value = pMA_DDO;
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
                objCmd.CommandText = "PKG_PhanQuyen.SELECT_LAYTHANGLAMVIEC";
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
        public DataTable SELECT_VIEW_THONGTIN_HUY(string pMA_DVIQLY, string pMA_KHANG)
        {
            DataTable dt = new DataTable();
            OracleConnection objConn = new OracleConnection(ConnectString.ConnectionString(pMA_DVIQLY));
            OracleCommand objCmd = new OracleCommand();
            try
            {
                objConn.Open();

                objCmd.Connection = objConn;
                objCmd.CommandText = "PKG_MV_XEMBAOCAO.SELECT_VIEW_THONGTIN_HUY";
                objCmd.CommandType = CommandType.StoredProcedure;
                objCmd.Parameters.Add("pMA_DVIQLY", OracleType.VarChar).Value = pMA_DVIQLY;
                objCmd.Parameters.Add("pMA_KHANG", OracleType.VarChar).Value = pMA_KHANG;
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
        public DataTable SELECT_VIEW_THONGTIN_LS(string pMA_DVIQLY, string pMA_KHANG)
        {
            DataTable dt = new DataTable();
            OracleConnection objConn = new OracleConnection(ConnectString.ConnectionString(pMA_DVIQLY));
            OracleCommand objCmd = new OracleCommand();
            try
            {
                objConn.Open();

                objCmd.Connection = objConn;
                objCmd.CommandText = "PKG_MV_XEMBAOCAO.SELECT_VIEW_THONGTIN_LS";
                objCmd.CommandType = CommandType.StoredProcedure;
                objCmd.Parameters.Add("pMA_DVIQLY", OracleType.VarChar).Value = pMA_DVIQLY;
                objCmd.Parameters.Add("pMA_KHANG", OracleType.VarChar).Value = pMA_KHANG;
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
        public DataTable SELECT_VIEW_THONGTIN_KH(string pMA_DVIQLY, string pMA_KHANG)
        {
            DataTable dt = new DataTable();
            OracleConnection objConn = new OracleConnection(ConnectString.ConnectionString(pMA_DVIQLY));
            OracleCommand objCmd = new OracleCommand();
            try
            {
                objConn.Open();

                objCmd.Connection = objConn;
                objCmd.CommandText = "PKG_MV_XEMBAOCAO.SELECT_VIEW_THONGTIN_KH";
                objCmd.CommandType = CommandType.StoredProcedure;
                objCmd.Parameters.Add("pMA_DVIQLY", OracleType.VarChar).Value = pMA_DVIQLY;
                objCmd.Parameters.Add("pMA_KHANG", OracleType.VarChar).Value = pMA_KHANG;
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
        public DataTable SELECT_VIEW_THONGTIN_HT(string pMA_DVIQLY, string pMA_KHANG)
        {
            DataTable dt = new DataTable();
            OracleConnection objConn = new OracleConnection(ConnectString.ConnectionString(pMA_DVIQLY));
            OracleCommand objCmd = new OracleCommand();
            try
            {
                objConn.Open();

                objCmd.Connection = objConn;
                objCmd.CommandText = "PKG_MV_XEMBAOCAO.SELECT_VIEW_THONGTIN_HT";
                objCmd.CommandType = CommandType.StoredProcedure;
                objCmd.Parameters.Add("pMA_DVIQLY", OracleType.VarChar).Value = pMA_DVIQLY;
                objCmd.Parameters.Add("pMA_KHANG", OracleType.VarChar).Value = pMA_KHANG;
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
        public DataTable SS_LECH(string pMA_DVIQLY, int pTHANG, int pNAM, string pLOAI)
        {
            DataTable dt = new DataTable();
            OracleConnection objConn = new OracleConnection(ConnectString.ConnectionString(pMA_DVIQLY));
            OracleCommand objCmd = new OracleCommand();
            try
            {
                objConn.Open();

                objCmd.Connection = objConn;
                objCmd.CommandText = "PKG_MV_XEMBAOCAO.SS_LECH";
                objCmd.CommandType = CommandType.StoredProcedure;
                objCmd.Parameters.Add("pMA_DVIQLY", OracleType.VarChar).Value = pMA_DVIQLY;
                objCmd.Parameters.Add("pTHANG", OracleType.Number).Value = pTHANG;
                objCmd.Parameters.Add("pNAM", OracleType.Number).Value = pNAM;
                objCmd.Parameters.Add("pLOAI", OracleType.Number).Value = pLOAI;
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
        public int InsertLogsql(string ChucNang, string ThaoTac, decimal ID_HDON, int TINHTRANG, string UserName, string MA_DVIQLY, string MA_KHANG, int THANG, int NAM)
        {
            DbConnection conn = _DbHelper.CreateConnection(Common.ConnectionString);
            conn.Open();
            try
            {
                List<DbParameter> para = new List<DbParameter>();
                DbParameter ouput = _DbHelper.CreateParameter("ID", DbType.Int32, true);
                para.Add(_DbHelper.CreateParameter("ChucNang", ChucNang, false));
                para.Add(_DbHelper.CreateParameter("ThaoTac", ThaoTac, false));
                para.Add(_DbHelper.CreateParameter("Ngay_Tao", DateTime.Now, false));
                para.Add(_DbHelper.CreateParameter("TINHTRANG", TINHTRANG, false));
                para.Add(_DbHelper.CreateParameter("ID_HDON", ID_HDON, false));
                para.Add(_DbHelper.CreateParameter("UserName", UserName, false));
                para.Add(_DbHelper.CreateParameter("MA_DVIQLY", MA_DVIQLY, false));
                para.Add(_DbHelper.CreateParameter("MA_KHANG", MA_KHANG, false));
                para.Add(_DbHelper.CreateParameter("THANG", THANG, false));
                para.Add(_DbHelper.CreateParameter("NAM", NAM, false));

                para.Add(ouput);
                _DbHelper.ExecuteReader(conn, Common.DatabaseSchema + "[Log_HDON_Insert_1]", para.ToArray());
                return (int)ouput.Value;
            }
            catch (Exception ex)
            {
                throw new Exception(String.Format("Log_HDon.Insert: {0}", ex.Message));
            }
            finally
            {
                conn.Close();
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
                command.CommandText = "PKG_CHAMNO_MAVACH.INSERT_TBDD_GCS_CS_TEM";
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
        //public DataTable data_ngc(string strorcl)
        //{
        //    DataTable dt = new DataTable();
        //    try
        //    {

        //        connOrcl.Open();
        //        OracleDataAdapter adapter = new OracleDataAdapter(strorcl, connOrcl);
        //        adapter.Fill(dt);
        //        connOrcl.Close();

        //    }
        //    catch (Exception e)
        //    {
        //        StreamWriter file = new StreamWriter(@logpath + DateTime.Now.ToString("yyyy-MM-dd") + "_MDMS2MRIS_ERR.txt", true);
        //        file.WriteLine(" get data ngc err \n" + e);
        //        file.Close();
        //        return null;

        //    }
        //    return dt;
        //}

        public DataTable SELECT_SANLUONG_BATTHUONG(string pMA_DVIQLY, int KY, int pTHANG, int pNAM, string pMA_SOGCS, string pLOAI_CHISO, int pPHANTRAM, int KIEUIN)
        {
            DataTable dt = new DataTable();
            OracleConnection objConn = new OracleConnection(ConnectString.ConnectionString(pMA_DVIQLY));
            OracleCommand objCmd = new OracleCommand();
            try
            {
                objConn.Open();

                objCmd.Connection = objConn;
                objCmd.CommandText = "PKG_CHAMNO_MAVACH.SELECT_SANLUONG_BATTHUONG";
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

        public DataTable SelectALL_UserName(string pMA_DVIQLY)
        {
            DataTable dt = new DataTable();
            OracleConnection objConn = new OracleConnection(ConnectString.ConnectionString(pMA_DVIQLY));
            OracleCommand objCmd = new OracleCommand();
            try
            {
                objConn.Open();

                objCmd.Connection = objConn;
                objCmd.CommandText = "PKG_CHAMNO_MAVACH.SelectALL_UserName";
                objCmd.CommandType = CommandType.StoredProcedure;
                objCmd.Parameters.Add("pMA_DVIQLY", OracleType.VarChar).Value = pMA_DVIQLY;
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
        public DataTable SELECT_TENFILE_XN(string pMA_DVIQLY, int KY, int pTHANG, int pNAM, string pLOAI)
        {
            DataTable dt = new DataTable();
            OracleConnection objConn = new OracleConnection(ConnectString.ConnectionString(pMA_DVIQLY));
            OracleCommand objCmd = new OracleCommand();
            try
            {
                objConn.Open();

                objCmd.Connection = objConn;
                objCmd.CommandText = "PKG_CHAMNO_MAVACH.SELECT_TENFILE_XN";
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
        public DataTable SELECT_KH_BYSOGCS(string pMA_DVIQLY, int KY, int pTHANG, int pNAM, string MA_SOGCS_TEN, string LOAIVIEW)
        {
            DataTable dt = new DataTable();
            OracleConnection objConn = new OracleConnection(ConnectString.ConnectionString(pMA_DVIQLY));
            OracleCommand objCmd = new OracleCommand();
            try
            {
                objConn.Open();

                objCmd.Connection = objConn;
                objCmd.CommandText = "PKG_CHAMNO_MAVACH.SELECT_KH_BYSOGCS";
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

        public void DELETE_TENFILE_XN(string pMA_DVIQLY, int KY, int pTHANG, int pNAM, string TENFILE)
        {
            OracleConnection objConn = new OracleConnection(ConnectString.ConnectionString(pMA_DVIQLY));
            OracleCommand objCmd = new OracleCommand();
            try
            {
                objConn.Open();

                objCmd.Connection = objConn;
                objCmd.CommandText = "PKG_CHAMNO_MAVACH.DELETE_TENFILE_XN";
                objCmd.CommandType = CommandType.StoredProcedure;
                objCmd.Parameters.Add("pMA_DVIQLY", OracleType.VarChar).Value = pMA_DVIQLY;
                objCmd.Parameters.Add("pKY", OracleType.Number).Value = KY;
                objCmd.Parameters.Add("pTHANG", OracleType.Number).Value = pTHANG;
                objCmd.Parameters.Add("pNAM", OracleType.Number).Value = pNAM;
                objCmd.Parameters.Add("pTENFILE", OracleType.VarChar).Value = TENFILE;
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

        public DataTable SelectKhachHang(string pMA_DVIQLY, string pMA_LO, string pLOAI, string pMA_TRAM)
        {
            DataTable dt = new DataTable();
            OracleConnection objConn = new OracleConnection(ConnectString.ConnectionString(pMA_DVIQLY));
            OracleCommand objCmd = new OracleCommand();
            try
            {
                objConn.Open();

                objCmd.Connection = objConn;
                objCmd.CommandText = "PKG_TBDD_CD.SELECT_KH_CATDIEN";
                objCmd.CommandType = CommandType.StoredProcedure;
                objCmd.Parameters.Add("pMA_DVIQLY", OracleType.VarChar).Value = pMA_DVIQLY;
                objCmd.Parameters.Add("pMA_LO", OracleType.VarChar).Value = pMA_LO;
                objCmd.Parameters.Add("pLOAI", OracleType.VarChar).Value = pLOAI;
                objCmd.Parameters.Add("pMA_TRAM", OracleType.VarChar).Value = pMA_TRAM;
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
            #region
            //OracleDataAdapter oraDA = new OracleDataAdapter();
            //DataTable dt = new DataTable();
            //OracleConnection objConn = new OracleConnection(ConnectString.ConnectionString(pMA_DVIQLY));
            //OracleCommand objCmd = new OracleCommand();
            //try
            //{
            //    objConn.Open();

            //    objCmd.Connection = objConn;
            //    objCmd.CommandText = "PKG_TBDD_CD.SELECT_KH_CATDIEN";
            //    objCmd.CommandType = CommandType.StoredProcedure;
            //    objCmd.Parameters.Add("pMA_DVIQLY", OracleType.VarChar).Value = pMA_DVIQLY;
            //    objCmd.Parameters.Add("pMA_LO", OracleType.VarChar).Value = pMA_LO;
            //    objCmd.Parameters.Add("pLOAI", OracleType.VarChar).Value = pLOAI;
            //    objCmd.Parameters.Add("rs", OracleType.Cursor).Direction = ParameterDirection.Output;
            //    oraDA.SelectCommand = objCmd;
            //    //objCmd.ExecuteNonQuery();
            //    OracleDataReader objReader = objCmd.ExecuteReader();
            //    dt.Load(objReader);
            //    return dt;

            //    // oraDA.Fill(dt);
            //}

            //catch (Exception ex)
            //{
            //    System.Console.WriteLine("Exception: {0}", ex.ToString());
            //}
            //finally
            //{
            //    oraDA.Dispose();
            //    oraDA = null;
            //    objCmd.Dispose();
            //    objCmd = null;
            //}

            //objConn.Close();

            //return dt;
            #endregion

        }

        public DataTable SELECT_KHCHUANOP(string pMA_DVIQLY)
        {
            DataTable dt = new DataTable();
            OracleConnection objConn = new OracleConnection(ConnectString.ConnectionString(pMA_DVIQLY));
            OracleCommand objCmd = new OracleCommand();
            try
            {
                objConn.Open();
                objCmd.Connection = objConn;
                objCmd.CommandText = "PKG_MV_XEMBAOCAO.SELECT_KHCHUANOP";
                objCmd.CommandType = CommandType.StoredProcedure;
                objCmd.Parameters.Add("pMA_DVIQLY", OracleType.VarChar).Value = pMA_DVIQLY;
                objCmd.Parameters.Add("rs", OracleType.Cursor).Direction = ParameterDirection.Output;
                OracleDataAdapter adapter = new OracleDataAdapter(objCmd);
                adapter.Fill(dt);
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

        public DataTable SELECT_CHECKKHACHHANG(string pMA_DVIQLY)
        {
            DataTable dt = new DataTable();
            OracleConnection objConn = new OracleConnection(ConnectString.ConnectionString(pMA_DVIQLY));
            OracleCommand objCmd = new OracleCommand();
            try
            {
                objConn.Open();
                objCmd.Connection = objConn;
                objCmd.CommandText = "PKG_CHAMNO_MAVACH.SELECT_CHECKKHACHHANG";
                objCmd.CommandType = CommandType.StoredProcedure;
                objCmd.Parameters.Add("pMA_DVIQLY", OracleType.VarChar).Value = pMA_DVIQLY;
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
        public DataTable CHECK_KHCHAMNO_DV(string pMA_DVIQLY, decimal pID_HDON)
        {
            DataTable dt = new DataTable();
            OracleConnection objConn = new OracleConnection(ConnectString.ConnectionString(pMA_DVIQLY));
            OracleCommand objCmd = new OracleCommand();
            try
            {
                objConn.Open();

                objCmd.Connection = objConn;
                objCmd.CommandText = "PKG_MV_SELECT_HD.CHECK_KHCHAMNO_DV";
                objCmd.CommandType = CommandType.StoredProcedure;
                objCmd.Parameters.Add("pMA_DVIQLY", OracleType.VarChar).Value = pMA_DVIQLY;
                objCmd.Parameters.Add("pID_HDON", OracleType.Number).Value = pID_HDON;
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
        public DataTable SELECT_KHCHUANOP_USER(string pMA_DVIQLY, string pMA_TNGAN)
        {
            DataTable dt = new DataTable();
            OracleConnection objConn = new OracleConnection(ConnectString.ConnectionString(pMA_DVIQLY));
            OracleCommand objCmd = new OracleCommand();
            try
            {
                objConn.Open();

                objCmd.Connection = objConn;
                objCmd.CommandText = "PKG_MV_XEMBAOCAO.SELECT_KHCHUANOP_USER";
                objCmd.CommandType = CommandType.StoredProcedure;
                objCmd.Parameters.Add("pMA_DVIQLY", OracleType.VarChar).Value = pMA_DVIQLY;
                objCmd.Parameters.Add("pMA_TNGAN", OracleType.VarChar).Value = pMA_TNGAN;
                objCmd.Parameters.Add("rs", OracleType.Cursor).Direction = ParameterDirection.Output;
                OracleDataAdapter adapter = new OracleDataAdapter(objCmd);
                adapter.Fill(dt);
                objConn.Close();
                objCmd.Dispose();
                adapter.Dispose();
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
        public DataTable SELECT_KH_PHAN_NV(string pMA_DVIQLY, string pLOAI_KH, string pMA_NVIEN, string pMA_LO, string pMA_TRAM)
        {
            DataTable dt = new DataTable();
            OracleConnection objConn = new OracleConnection(ConnectString.ConnectionString(pMA_DVIQLY));
            OracleCommand objCmd = new OracleCommand();
            try
            {
                objConn.Open();
                objCmd.Connection = objConn;
                objCmd.CommandText = "PKG_TBDD_CD.SELECT_KH_PHAN_NV";
                objCmd.CommandType = CommandType.StoredProcedure;
                objCmd.Parameters.Add("pMA_DVIQLY", OracleType.VarChar).Value = pMA_DVIQLY;
                objCmd.Parameters.Add("pLOAI_KH", OracleType.VarChar).Value = pLOAI_KH;
                objCmd.Parameters.Add("pMA_NVIEN", OracleType.VarChar).Value = pMA_NVIEN;
                objCmd.Parameters.Add("pMA_LO", OracleType.VarChar).Value = pMA_LO;
                objCmd.Parameters.Add("pMA_TRAM", OracleType.VarChar).Value = pMA_TRAM;
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

        public DataTable SELECT_ThongTinBoSung(string pMA_DVIQLY, int idHdon)
        {
            var dt = new DataTable();
            var objConn = new OracleConnection(ConnectString.ConnectionString(pMA_DVIQLY));
            var objCmd = new OracleCommand();
            try
            {
                objConn.Open();
                objCmd.Connection = objConn;
                objCmd.CommandText = "spSELECT_THONGTIN";
                objCmd.CommandType = CommandType.StoredProcedure;
                objCmd.Parameters.Add("pMA_DVIQLY", OracleType.VarChar).Value = pMA_DVIQLY;
                objCmd.Parameters.Add("pID_HDON", OracleType.Int32).Value = idHdon;
                objCmd.Parameters.Add("O_CURSOR", OracleType.Cursor).Direction = ParameterDirection.Output;
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

        public DataTable SelectKhHuyDuyet(int loai, string maDvql, string maKh, int thang, int nam, string maTngan, DateTime ngayCham)
        {
            var dt = new DataTable();
            var objConn = new OracleConnection(ConnectString.ConnectionString(maDvql));
            var objCmd = new OracleCommand();
            try
            {
                objConn.Open();
                objCmd.Connection = objConn;
                objCmd.CommandText = "spSELECT_KH_HUYDUYET";
                objCmd.CommandType = CommandType.StoredProcedure;
                objCmd.Parameters.Add("pMA_DVIQLY", OracleType.VarChar).Value = maDvql;
                objCmd.Parameters.Add("pLOAI", OracleType.Int32).Value = loai;
                objCmd.Parameters.Add("pMA_KHANG", OracleType.VarChar).Value = maKh;
                objCmd.Parameters.Add("pTHANG", OracleType.Int32).Value = thang;
                objCmd.Parameters.Add("pNAM", OracleType.Int32).Value = nam;
                objCmd.Parameters.Add("pMA_TNGAN", OracleType.VarChar).Value = maTngan;
                objCmd.Parameters.Add("pNGAY", OracleType.VarChar).Value = ngayCham.ToString("MM/dd/yyyy");
                objCmd.Parameters.Add("O_CURSOR", OracleType.Cursor).Direction = ParameterDirection.Output;
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

        public DataTable LoadDsThuNgan(string maDvql)
        {
            var dt = new DataTable();
            var objConn = new OracleConnection(ConnectString.ConnectionString(maDvql));
            var objCmd = new OracleCommand();
            try
            {
                objConn.Open();
                objCmd.Connection = objConn;
                objCmd.CommandText = "spSELECT_TNGAN";
                objCmd.CommandType = CommandType.StoredProcedure;
                objCmd.Parameters.Add("pMA_DVIQLY", OracleType.VarChar).Value = maDvql;
                objCmd.Parameters.Add("O_CURSOR", OracleType.Cursor).Direction = ParameterDirection.Output;
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

        public DataTable SELECT_KHCHUANOP(string pMA_DVIQLY, string pMA_TNGAN)
        {
            DataTable dt = new DataTable();
            OracleConnection objConn = new OracleConnection(ConnectString.ConnectionString(pMA_DVIQLY));
            OracleCommand objCmd = new OracleCommand();
            try
            {
                objConn.Open();
                objCmd.Connection = objConn;
                objCmd.CommandText = "spSELECT_KHCHUANOP_USER";
                objCmd.CommandType = CommandType.StoredProcedure;
                objCmd.Parameters.Add("pMA_DVIQLY", OracleType.VarChar).Value = pMA_DVIQLY;
                objCmd.Parameters.Add("pMA_TNGAN", OracleType.VarChar).Value = pMA_TNGAN;
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

        public bool HuyDuyetChamNo(int idHdon, string maDvql)
        {
            var objConn = new OracleConnection(ConnectString.ConnectionString(maDvql));
            var objCmd = new OracleCommand();
            try
            {
                objConn.Open();
                objCmd.Connection = objConn;
                objCmd.CommandText = "spHuyDuyetChamNo";
                objCmd.CommandType = CommandType.StoredProcedure;
                objCmd.Parameters.Add("pID_HDON", OracleType.Int32).Value = idHdon;
                OracleDataReader objReader = objCmd.ExecuteReader();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
            finally
            {
                objConn.Close();
                objConn.Dispose();
                objCmd = null;
            }
        }

        public DataTable RunProcedureGetTable(DbConnection sqlCn, string ProcedureName, ArrayList colParam)
        {
            DataTable dtb = new DataTable();
            OracleCommand orCmd = new OracleCommand();
            OracleDataAdapter oraDA = new OracleDataAdapter();
            try
            {
                orCmd.Connection = (OracleConnection)sqlCn;
                oraDA.SelectCommand = orCmd;
                orCmd.CommandText = ProcedureName;
                orCmd.CommandType = CommandType.StoredProcedure;
                if (colParam != null)
                {
                    for (int i = 0; i < colParam.Count; i++)
                        orCmd.Parameters.Add((OracleParameter)colParam[i]);
                }

                orCmd.ExecuteNonQuery();
                oraDA.Fill(dtb);
            }

            finally
            {
                oraDA.Dispose();
                orCmd.Clone();
                oraDA = null;

                orCmd = null;
            }



            return dtb;
        }

        #region Chấm nợ
        public DataTable SELECT_CN_TOANDV(string pMA_DVIQLY, string KY, int pTHANG, int pNAM, int pLOAI)
        {
            DataTable dt = new DataTable();
            OracleConnection objConn = new OracleConnection(ConnectString.ConnectionString(pMA_DVIQLY));
            OracleCommand objCmd = new OracleCommand();
            try
            {
                objConn.Open();

                objCmd.Connection = objConn;
                objCmd.CommandText = "PKG_MV_XEMBAOCAO.SELECT_CN_TOANDV";
                objCmd.CommandType = CommandType.StoredProcedure;
                objCmd.Parameters.Add("pMA_DVIQLY", OracleType.VarChar).Value = pMA_DVIQLY;
                objCmd.Parameters.Add("pLOAI", OracleType.Number).Value = pLOAI;
                objCmd.Parameters.Add("pTHANG", OracleType.Number).Value = pTHANG;
                objCmd.Parameters.Add("pNAM", OracleType.Number).Value = pNAM;
                objCmd.Parameters.Add("pKY", OracleType.VarChar).Value = KY;

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

        public DataTable SELECT_KH_CHAMCHEO(string pMA_DVIQLY, string KY, int pTHANG, int pNAM, int pLOAI, string pMA_TNGAN, string pNGAYCHAM, string MA_NVIENGIAO)
        {
            DataTable dt = new DataTable();
            OracleConnection objConn = new OracleConnection(ConnectString.ConnectionString(pMA_DVIQLY));
            OracleCommand objCmd = new OracleCommand();
            try
            {
                objConn.Open();

                objCmd.Connection = objConn;
                objCmd.CommandText = "PKG_MV_XEMBAOCAO.SELECT_KH_CHAMCHEO";
                objCmd.CommandType = CommandType.StoredProcedure;
                objCmd.Parameters.Add("pMA_DVIQLY", OracleType.VarChar).Value = pMA_DVIQLY;
                objCmd.Parameters.Add("pKY", OracleType.VarChar).Value = KY;
                objCmd.Parameters.Add("pTHANG", OracleType.Number).Value = pTHANG;
                objCmd.Parameters.Add("pNAM", OracleType.Number).Value = pNAM;
                objCmd.Parameters.Add("pLOAI", OracleType.Number).Value = pLOAI;
                objCmd.Parameters.Add("pMA_TNGAN", OracleType.VarChar).Value = pMA_TNGAN;
                objCmd.Parameters.Add("pNGAYCHAM", OracleType.VarChar).Value = pNGAYCHAM;
                objCmd.Parameters.Add("pMA_NVIENGIAO", OracleType.VarChar).Value = MA_NVIENGIAO;
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
        public DataTable SELECT_KH_CHAMCHEO_DVI(string pMA_DVIQLY, string KY, int pTHANG, int pNAM, int pLOAI, string pNGAYCHAM)
        {
            DataTable dt = new DataTable();
            OracleConnection objConn = new OracleConnection(ConnectString.ConnectionString(pMA_DVIQLY));
            OracleCommand objCmd = new OracleCommand();
            try
            {
                objConn.Open();

                objCmd.Connection = objConn;
                objCmd.CommandText = "PKG_CHAMNO_MAVACH.SELECT_KH_CHAMCHEO_DVI";
                objCmd.CommandType = CommandType.StoredProcedure;
                objCmd.Parameters.Add("pMA_DVIQLY", OracleType.VarChar).Value = pMA_DVIQLY;
                objCmd.Parameters.Add("pKY", OracleType.VarChar).Value = KY;
                objCmd.Parameters.Add("pTHANG", OracleType.Number).Value = pTHANG;
                objCmd.Parameters.Add("pNAM", OracleType.Number).Value = pNAM;
                objCmd.Parameters.Add("pLOAI", OracleType.Number).Value = pLOAI;
                objCmd.Parameters.Add("pNGAYCHAM", OracleType.VarChar).Value = pNGAYCHAM;
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
        public DataTable CHECKDULIEUMOICN(string pMA_DVIQLY, string pUSERNAME, string pIMEI, int pTHANG, int pNAM, string pLOAI_GIAONHAN, string pNGAY)
        {
            DataTable dt = new DataTable();
            OracleConnection objConn = new OracleConnection(ConnectString.ConnectionString(pMA_DVIQLY));
            OracleCommand objCmd = new OracleCommand();
            try
            {
                objConn.Open();

                objCmd.Connection = objConn;
                objCmd.CommandText = "PKG_CHAMNO_MAVACH.CHECKDULIEUMOICN";
                objCmd.CommandType = CommandType.StoredProcedure;
                objCmd.Parameters.Add("pMA_DVIQLY", OracleType.VarChar).Value = pMA_DVIQLY;
                objCmd.Parameters.Add("pUSERNAME", OracleType.VarChar).Value = pUSERNAME;
                objCmd.Parameters.Add("pTHANG", OracleType.Number).Value = pTHANG;
                objCmd.Parameters.Add("pNAM", OracleType.Number).Value = pNAM;
                objCmd.Parameters.Add("pIMEI", OracleType.VarChar).Value = pIMEI;
                objCmd.Parameters.Add("pLOAI_GIAONHAN", OracleType.VarChar).Value = pLOAI_GIAONHAN;
                objCmd.Parameters.Add("pNGAY", OracleType.VarChar).Value = pNGAY;
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

        public DataTable CHECKKHANG_MV(string pMA_DVIQLY, string pMA_KHANG, int pTHANG, int pNAM)
        {
            DataTable dt = new DataTable();
            OracleConnection objConn = new OracleConnection(ConnectString.ConnectionString(pMA_DVIQLY));
            OracleCommand objCmd = new OracleCommand();
            try
            {
                objConn.Open();

                objCmd.Connection = objConn;
                objCmd.CommandText = "PKG_MV_SELECT_HD.CHECKKHANG_MV";
                objCmd.CommandType = CommandType.StoredProcedure;
                objCmd.Parameters.Add("pMA_DVIQLY", OracleType.VarChar).Value = pMA_DVIQLY;
                objCmd.Parameters.Add("pMA_KHANG", OracleType.VarChar).Value = pMA_KHANG;
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
        public DataTable TEST_KHANG(string pMA_DVIQLY, string pMA_KHANG, int pTHANG, int pNAM)
        {
            DataTable dt = new DataTable();
            OracleConnection objConn = new OracleConnection(ConnectString.ConnectionString(pMA_DVIQLY));
            OracleCommand objCmd = new OracleCommand();
            try
            {
                objConn.Open();

                objCmd.Connection = objConn;
                objCmd.CommandText = "PKG_CHAMNO_MAVACH.TEST_KHANG";
                objCmd.CommandType = CommandType.StoredProcedure;
                objCmd.Parameters.Add("pMA_DVIQLY", OracleType.VarChar).Value = pMA_DVIQLY;
                objCmd.Parameters.Add("pMA_KHANG", OracleType.VarChar).Value = pMA_KHANG;
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
        public DataTable IN_HD_BY_IDHDON(string pMA_DVIQLY, decimal pID_HDON, int pTHANG, int pNAM)
        {
            DataTable dt = new DataTable();
            OracleConnection objConn = new OracleConnection(ConnectString.ConnectionString(pMA_DVIQLY));
            OracleCommand objCmd = new OracleCommand();
            try
            {
                objConn.Open();

                objCmd.Connection = objConn;
                objCmd.CommandText = "PKG_MV_SELECT_HDCTIET.IN_HD_BY_IDHDON";
                objCmd.CommandType = CommandType.StoredProcedure;
                objCmd.Parameters.Add("pMA_DVIQLY", OracleType.VarChar).Value = pMA_DVIQLY;
                objCmd.Parameters.Add("pID_HDON", OracleType.VarChar).Value = pID_HDON;
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
        public DataTable IN_HD_TEST(string pMA_DVIQLY, decimal pID_HDON, int pTHANG, int pNAM)
        {
            DataTable dt = new DataTable();
            OracleConnection objConn = new OracleConnection(ConnectString.ConnectionString(pMA_DVIQLY));
            OracleCommand objCmd = new OracleCommand();
            try
            {
                objConn.Open();

                objCmd.Connection = objConn;
                objCmd.CommandText = "PKG_CHAMNO_MAVACH.IN_HD_TEST";
                objCmd.CommandType = CommandType.StoredProcedure;
                objCmd.Parameters.Add("pMA_DVIQLY", OracleType.VarChar).Value = pMA_DVIQLY;
                objCmd.Parameters.Add("pID_HDON", OracleType.VarChar).Value = pID_HDON;
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
        public DataTable CHAMNO_KH_TAIQUAY(string pMA_DVIQLY, string pMA_KHANG, int pTHANG, int pNAM)
        {
            DataTable dt = new DataTable();
            OracleConnection objConn = new OracleConnection(ConnectString.ConnectionString(pMA_DVIQLY));
            OracleCommand objCmd = new OracleCommand();
            try
            {
                objConn.Open();

                objCmd.Connection = objConn;
                objCmd.CommandText = "PKG_MV_SELECT_HD.CHAMNO_KH_TAIQUAY";
                objCmd.CommandType = CommandType.StoredProcedure;
                objCmd.Parameters.Add("pMA_DVIQLY", OracleType.VarChar).Value = pMA_DVIQLY;
                objCmd.Parameters.Add("pMA_KHANG", OracleType.VarChar).Value = pMA_KHANG;
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
        public DataTable HUY_CHAMNO_KH_TAIQUAY(string pMA_DVIQLY, string pMA_KHANG, int pTHANG, int pNAM)
        {
            DataTable dt = new DataTable();
            OracleConnection objConn = new OracleConnection(ConnectString.ConnectionString(pMA_DVIQLY));
            OracleCommand objCmd = new OracleCommand();
            try
            {
                objConn.Open();

                objCmd.Connection = objConn;
                objCmd.CommandText = "PKG_MV_CAPNHATNO.HUY_CHAMNO_KH_TAIQUAY";
                objCmd.CommandType = CommandType.StoredProcedure;
                objCmd.Parameters.Add("pMA_DVIQLY", OracleType.VarChar).Value = pMA_DVIQLY;
                objCmd.Parameters.Add("pMA_KHANG", OracleType.VarChar).Value = pMA_KHANG;
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

        public DataTable CHECKDL_KHANG(string pMA_DVIQLY, string pMA_KHANG)
        {
            DataTable dt = new DataTable();
            OracleConnection objConn = new OracleConnection(ConnectString.ConnectionString(pMA_DVIQLY));
            OracleCommand objCmd = new OracleCommand();
            try
            {
                objConn.Open();

                objCmd.Connection = objConn;
                objCmd.CommandText = "PKG_MV_SELECT_HD.CHECKDL_KHANG";
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

        public DataTable CHECK_KHCHAMNO(string pMA_DVIQLY, decimal pID_HDON)
        {
            DataTable dt = new DataTable();
            OracleConnection objConn = new OracleConnection(ConnectString.ConnectionString(pMA_DVIQLY));
            OracleCommand objCmd = new OracleCommand();
            try
            {
                objConn.Open();

                objCmd.Connection = objConn;
                objCmd.CommandText = "PKG_MV_SELECT_HD.CHECK_KHCHAMNO";
                objCmd.CommandType = CommandType.StoredProcedure;
                objCmd.Parameters.Add("pMA_DVIQLY", OracleType.VarChar).Value = pID_HDON;
                objCmd.Parameters.Add("pID_HDON", OracleType.Number).Value = pID_HDON;
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

        public DataTable SELECTKHANG_CN(string pMA_DVIQLY, string pMA_TNGAN, string KY, int pTHANG, int pNAM, string pNGAY_CHAMNO, int pLOAI)
        {
            DataTable dt = new DataTable();
            OracleConnection objConn = new OracleConnection(ConnectString.ConnectionString(pMA_DVIQLY));
            OracleCommand objCmd = new OracleCommand();
            try
            {
                objConn.Open();

                objCmd.Connection = objConn;
                objCmd.CommandText = "PKG_MV_XEMBAOCAO.SELECTKHANG_CN";
                objCmd.CommandType = CommandType.StoredProcedure;
                objCmd.Parameters.Add("pMA_DVIQLY", OracleType.VarChar).Value = pMA_DVIQLY;
                objCmd.Parameters.Add("pMA_TNGAN", OracleType.VarChar).Value = pMA_TNGAN;
                objCmd.Parameters.Add("pNGAY_CHAMNO", OracleType.VarChar).Value = pNGAY_CHAMNO;
                objCmd.Parameters.Add("pLOAI", OracleType.Number).Value = pLOAI;
                objCmd.Parameters.Add("pTHANG", OracleType.Number).Value = pTHANG;
                objCmd.Parameters.Add("pNAM", OracleType.Number).Value = pNAM;
                objCmd.Parameters.Add("pKY", OracleType.VarChar).Value = KY;

                objCmd.Parameters.Add("rs", OracleType.Cursor).Direction = ParameterDirection.Output;
                OracleDataAdapter adapter = new OracleDataAdapter(objCmd);
                adapter.Fill(dt);
                objConn.Close();
                adapter.Dispose();
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
        public DataTable XemDuLieuLS(string pMA_DVIQLY, string pMA_TNGAN, string KY, int pTHANG, int pNAM, string pNGAY_CHAMNO, int pLOAI)
        {
            DataTable dt = new DataTable();
            OracleConnection objConn = new OracleConnection(ConnectString.ConnectionString(pMA_DVIQLY));
            OracleCommand objCmd = new OracleCommand();
            try
            {
                objConn.Open();

                objCmd.Connection = objConn;
                objCmd.CommandText = "PKG_MV_XEMBAOCAO.XemDuLieuLS";
                objCmd.CommandType = CommandType.StoredProcedure;
                objCmd.Parameters.Add("pMA_DVIQLY", OracleType.VarChar).Value = pMA_DVIQLY;
                objCmd.Parameters.Add("pMA_TNGAN", OracleType.VarChar).Value = pMA_TNGAN;
                objCmd.Parameters.Add("pNGAY_CHAMNO", OracleType.VarChar).Value = pNGAY_CHAMNO;
                objCmd.Parameters.Add("pLOAI", OracleType.Number).Value = pLOAI;
                objCmd.Parameters.Add("pTHANG", OracleType.Number).Value = pTHANG;
                objCmd.Parameters.Add("pNAM", OracleType.Number).Value = pNAM;
                objCmd.Parameters.Add("pKY", OracleType.VarChar).Value = KY;

                objCmd.Parameters.Add("rs", OracleType.Cursor).Direction = ParameterDirection.Output;
                OracleDataAdapter adapter = new OracleDataAdapter(objCmd);
                adapter.Fill(dt);
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
        public DataTable SELECTKHANG_TAIQUAY(string pMA_DVIQLY, string pMA_TNGAN, string KY, int pTHANG, int pNAM, string pNGAY_CHAMNO, int pLOAI)
        {
            DataTable dt = new DataTable();
            OracleConnection objConn = new OracleConnection(ConnectString.ConnectionString(pMA_DVIQLY));
            OracleCommand objCmd = new OracleCommand();
            try
            {
                objConn.Open();

                objCmd.Connection = objConn;
                objCmd.CommandText = "PKG_MV_XEMBAOCAO.SELECTKHANG_TAIQUAY";
                objCmd.CommandType = CommandType.StoredProcedure;
                objCmd.Parameters.Add("pMA_DVIQLY", OracleType.VarChar).Value = pMA_DVIQLY;
                objCmd.Parameters.Add("pMA_TNGAN", OracleType.VarChar).Value = pMA_TNGAN;
                objCmd.Parameters.Add("pNGAY_CHAMNO", OracleType.VarChar).Value = pNGAY_CHAMNO;
                objCmd.Parameters.Add("pLOAI", OracleType.Number).Value = pLOAI;
                objCmd.Parameters.Add("pTHANG", OracleType.Number).Value = pTHANG;
                objCmd.Parameters.Add("pNAM", OracleType.Number).Value = pNAM;
                objCmd.Parameters.Add("pKY", OracleType.VarChar).Value = KY;

                objCmd.Parameters.Add("rs", OracleType.Cursor).Direction = ParameterDirection.Output;
                OracleDataAdapter adapter = new OracleDataAdapter(objCmd);
                adapter.Fill(dt);
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
        public DataTable CHECKKHANG_MV_BYTEN(string pMA_DVIQLY, string pMA_SOGCS, string pIMEI, int KY, int pTHANG, int pNAM, string pTEN_KHANG, string pLOAI)
        {
            DataTable dt = new DataTable();
            OracleConnection objConn = new OracleConnection(ConnectString.ConnectionString(pMA_DVIQLY));
            OracleCommand objCmd = new OracleCommand();
            try
            {
                objConn.Open();

                objCmd.Connection = objConn;
                objCmd.CommandText = "PKG_MV_SELECT_HD.CHECKKHANG_MV_BYTEN";
                objCmd.CommandType = CommandType.StoredProcedure;
                objCmd.Parameters.Add("pMA_DVIQLY", OracleType.VarChar).Value = pMA_DVIQLY;
                objCmd.Parameters.Add("pMA_SOGCS", OracleType.VarChar).Value = pMA_SOGCS;
                objCmd.Parameters.Add("pIMEI", OracleType.VarChar).Value = pIMEI;
                objCmd.Parameters.Add("pTEN_KHANG", OracleType.VarChar).Value = pTEN_KHANG;
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

        public DataTable SELECTNGAY_CN(string pMA_DVIQLY, string KY, int pTHANG, int pNAM, int pLOAI)
        {
            DataTable dt = new DataTable();
            OracleConnection objConn = new OracleConnection(ConnectString.ConnectionString(pMA_DVIQLY));
            OracleCommand objCmd = new OracleCommand();
            try
            {
                objConn.Open();

                objCmd.Connection = objConn;
                objCmd.CommandText = "PKG_MV_XEMBAOCAO.SELECTNGAY_CN";
                objCmd.CommandType = CommandType.StoredProcedure;
                objCmd.Parameters.Add("pMA_DVIQLY", OracleType.VarChar).Value = pMA_DVIQLY;
                objCmd.Parameters.Add("pLOAI", OracleType.Number).Value = pLOAI;
                objCmd.Parameters.Add("pTHANG", OracleType.Number).Value = pTHANG;
                objCmd.Parameters.Add("pNAM", OracleType.Number).Value = pNAM;
                objCmd.Parameters.Add("pKY", OracleType.VarChar).Value = KY;

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
        public DataTable SELECTNGAY_NH(string pMA_DVIQLY, string KY, int pTHANG, int pNAM, int pLOAI, string NganHang)
        {
            DataTable dt = new DataTable();
            OracleConnection objConn = new OracleConnection(ConnectString.ConnectionString(pMA_DVIQLY));
            OracleCommand objCmd = new OracleCommand();
            try
            {
                objConn.Open();

                objCmd.Connection = objConn;
                objCmd.CommandText = "PKG_MV_HAMDLKHAC_NH.SELECTNGAY_CN";
                objCmd.CommandType = CommandType.StoredProcedure;
                objCmd.Parameters.Add("pMA_DVIQLY", OracleType.VarChar).Value = pMA_DVIQLY;
                objCmd.Parameters.Add("pLOAI", OracleType.Number).Value = pLOAI;
                objCmd.Parameters.Add("pTHANG", OracleType.Number).Value = pTHANG;
                objCmd.Parameters.Add("pNAM", OracleType.Number).Value = pNAM;
                objCmd.Parameters.Add("pKY", OracleType.VarChar).Value = KY;
                objCmd.Parameters.Add("pNH", OracleType.VarChar).Value = NganHang;
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
        public DataTable SELECTNGAY_TAIQUAY(string pMA_DVIQLY, string KY, int pTHANG, int pNAM, int pLOAI)
        {
            DataTable dt = new DataTable();
            OracleConnection objConn = new OracleConnection(ConnectString.ConnectionString(pMA_DVIQLY));
            OracleCommand objCmd = new OracleCommand();
            try
            {
                objConn.Open();

                objCmd.Connection = objConn;
                objCmd.CommandText = "PKG_MV_XEMBAOCAO.SELECTNGAY_TAIQUAY";
                objCmd.CommandType = CommandType.StoredProcedure;
                objCmd.Parameters.Add("pMA_DVIQLY", OracleType.VarChar).Value = pMA_DVIQLY;
                objCmd.Parameters.Add("pLOAI", OracleType.Number).Value = pLOAI;
                objCmd.Parameters.Add("pTHANG", OracleType.Number).Value = pTHANG;
                objCmd.Parameters.Add("pNAM", OracleType.Number).Value = pNAM;
                objCmd.Parameters.Add("pKY", OracleType.VarChar).Value = KY;

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
        public DataTable SELEC_USER_TB(string pMA_DVIQLY, int pTHANG, int pNAM)
        {
            DataTable dt = new DataTable();
            OracleConnection objConn = new OracleConnection(ConnectString.ConnectionString(pMA_DVIQLY));
            OracleCommand objCmd = new OracleCommand();
            try
            {
                objConn.Open();
                objCmd.Connection = objConn;
                objCmd.CommandText = "PKG_MV_HAMDLKHAC.SELEC_USER_TB";
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

        public DataTable SELEC_USER_TB_CS(string pMA_DVIQLY, int pTHANG, int pNAM, string pLOAI)
        {
            DataTable dt = new DataTable();
            OracleConnection objConn = new OracleConnection(ConnectString.ConnectionString(pMA_DVIQLY));
            OracleCommand objCmd = new OracleCommand();
            try
            {
                objConn.Open();
                objCmd.Connection = objConn;
                objCmd.CommandText = "PKG_MV_HAMDLKHAC.SELEC_USER_TB_CS";
                objCmd.CommandType = CommandType.StoredProcedure;
                objCmd.Parameters.Add("pMA_DVIQLY", OracleType.VarChar).Value = pMA_DVIQLY;
                objCmd.Parameters.Add("pTHANG", OracleType.Number).Value = pTHANG;
                objCmd.Parameters.Add("pNAM", OracleType.Number).Value = pNAM;
                objCmd.Parameters.Add("pLOAI", OracleType.Number).Value = pLOAI;

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
        public DataTable SELEC_USER_TB_NH(string pMA_DVIQLY, int pTHANG, int pNAM)
        {
            DataTable dt = new DataTable();
            OracleConnection objConn = new OracleConnection(ConnectString.ConnectionString(pMA_DVIQLY));
            OracleCommand objCmd = new OracleCommand();
            try
            {
                objConn.Open();
                objCmd.Connection = objConn;
                objCmd.CommandText = "PKG_MV_HAMDLKHAC_NH.SELEC_USER_TB";
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

        public DataTable CHECK_LOGIN(string pMA_DVIQLY, string pUSERNAME, int pIMEI, int pPASS, string pLOAIDN)
        {
            DataTable dt = new DataTable();
            OracleConnection objConn = new OracleConnection(ConnectString.ConnectionString(pMA_DVIQLY));
            OracleCommand objCmd = new OracleCommand();
            try
            {
                objConn.Open();
                objCmd.Connection = objConn;
                objCmd.CommandText = "PKG_MV_HAMDLKHAC.CHECK_LOGIN";
                objCmd.CommandType = CommandType.StoredProcedure;
                objCmd.Parameters.Add("pMA_DVIQLY", OracleType.VarChar).Value = pMA_DVIQLY;
                objCmd.Parameters.Add("pUSERNAME", OracleType.VarChar).Value = pUSERNAME;
                objCmd.Parameters.Add("pIMEI", OracleType.Number).Value = pIMEI;
                objCmd.Parameters.Add("pPASS", OracleType.Number).Value = pPASS;
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

        public DataTable SELECT_KH_TUDONG(string pMA_DVIQLY, int pTHANG, int pNAM)
        {
            DataTable dt = new DataTable();
            OracleConnection objConn = new OracleConnection(ConnectString.ConnectionString(pMA_DVIQLY));
            OracleCommand objCmd = new OracleCommand();
            try
            {
                objConn.Open();
                objCmd.Connection = objConn;
                objCmd.CommandText = "PKG_MV_XEMBAOCAO.SELECT_KH_TUDONG";
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
        public DataTable SelectAllThietBiDD_NH(string pMA_DVIQLY)
        {
            DataTable dt = new DataTable();
            OracleConnection objConn = new OracleConnection(ConnectString.ConnectionString(pMA_DVIQLY));
            OracleCommand objCmd = new OracleCommand();
            try
            {
                objConn.Open();
                objCmd.Connection = objConn;
                objCmd.CommandText = "PKG_MV_HAMDLKHAC_NH.SelectAllThietBiDD";
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
        public DataTable Select_ByIDThietBiDD_NH(string pMA_DVIQLY, string pIMEI)
        {
            DataTable dt = new DataTable();
            OracleConnection objConn = new OracleConnection(ConnectString.ConnectionString(pMA_DVIQLY));
            OracleCommand objCmd = new OracleCommand();
            try
            {
                objConn.Open();
                objCmd.Connection = objConn;
                objCmd.CommandText = "PKG_MV_HAMDLKHAC_NH.Select_ByIDThietBiDD";
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

        public DataTable SELECT_CTIET_HDON_DV(string pMA_DVIQLY, string KY, int pTHANG, int pNAM, decimal pID_HDON)
        {
            DataTable dt = new DataTable();
            OracleConnection objConn = new OracleConnection(ConnectString.ConnectionString(pMA_DVIQLY));
            OracleCommand objCmd = new OracleCommand();
            try
            {
                objConn.Open();

                objCmd.Connection = objConn;
                objCmd.CommandText = "PKG_MV_SELECT_HDCTIET.SELECT_CTIET_HDON_DV";
                objCmd.CommandType = CommandType.StoredProcedure;
                objCmd.Parameters.Add("pMA_DVIQLY", OracleType.VarChar).Value = pMA_DVIQLY;
                objCmd.Parameters.Add("pID_HDON", OracleType.Number).Value = pID_HDON;
                objCmd.Parameters.Add("pTHANG", OracleType.Number).Value = pTHANG;
                objCmd.Parameters.Add("pNAM", OracleType.Number).Value = pNAM;
                objCmd.Parameters.Add("pKY", OracleType.VarChar).Value = KY;
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

        public DataTable SELECT_BANGTAMMV(string pMA_DVIQLY, int KY, int pTHANG, int pNAM, string pLOAI)
        {
            DataTable dt = new DataTable();
            OracleConnection objConn = new OracleConnection(ConnectString.ConnectionString(pMA_DVIQLY));
            OracleCommand objCmd = new OracleCommand();
            try
            {
                objConn.Open();

                objCmd.Connection = objConn;
                objCmd.CommandText = "PKG_CHAMNO_MAVACH.SELECT_BANGTAMMV";
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

        public DataTable SELECT_CTIET_HDON_BYMS_DV(string pMA_DVIQLY, int KY, int pTHANG, int pNAM, string pMA_SOGCS)
        {
            DataTable dt = new DataTable();
            OracleConnection objConn = new OracleConnection(ConnectString.ConnectionString(pMA_DVIQLY));
            OracleCommand objCmd = new OracleCommand();
            try
            {
                objConn.Open();

                objCmd.Connection = objConn;
                objCmd.CommandText = "PKG_MV_SELECT_HDCTIET.SELECT_CTIET_HDON_BYMS_DV";
                objCmd.CommandType = CommandType.StoredProcedure;
                objCmd.Parameters.Add("pMA_DVIQLY", OracleType.VarChar).Value = pMA_DVIQLY;
                objCmd.Parameters.Add("pMA_SOGCS", OracleType.VarChar).Value = pMA_SOGCS;
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


        public DataTable SELECT_GCS_BYMASO(string pMA_DVIQLY, int KY, int pTHANG, int pNAM, string pMA_SOGCS, string pIMEI)
        {
            DataTable dt = new DataTable();
            OracleConnection objConn = new OracleConnection(ConnectString.ConnectionString(pMA_DVIQLY));
            OracleCommand objCmd = new OracleCommand();
            try
            {
                objConn.Open();

                objCmd.Connection = objConn;
                objCmd.CommandText = "PKG_CHAMNO_MAVACH.SELECT_GCS_BYMASO";
                objCmd.CommandType = CommandType.StoredProcedure;
                objCmd.Parameters.Add("pMA_DVIQLY", OracleType.VarChar).Value = pMA_DVIQLY;
                objCmd.Parameters.Add("pMA_SOGCS", OracleType.VarChar).Value = pMA_SOGCS;
                objCmd.Parameters.Add("pIMEI", OracleType.VarChar).Value = pIMEI;
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

        public DataTable SELECT_GCS_BYMA_KH(string pMA_DVIQLY, int KY, int pTHANG, int pNAM, string pMA_KHANG, string pIMEI)
        {
            DataTable dt = new DataTable();
            OracleConnection objConn = new OracleConnection(ConnectString.ConnectionString(pMA_DVIQLY));
            OracleCommand objCmd = new OracleCommand();
            try
            {
                objConn.Open();

                objCmd.Connection = objConn;
                objCmd.CommandText = "PKG_CHAMNO_MAVACH.SELECT_GCS_BYMA_KH";
                objCmd.CommandType = CommandType.StoredProcedure;
                objCmd.Parameters.Add("pMA_DVIQLY", OracleType.VarChar).Value = pMA_DVIQLY;
                objCmd.Parameters.Add("pMA_KHANG", OracleType.VarChar).Value = pMA_KHANG;
                objCmd.Parameters.Add("pIMEI", OracleType.VarChar).Value = pIMEI;
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

        public DataTable SELECT_ALL_DVIQLY(string pMA_DVIQLY)
        {
            DataTable dt = new DataTable();
            OracleConnection objConn = new OracleConnection(ConnectString.ConnectionString(pMA_DVIQLY));
            OracleCommand objCmd = new OracleCommand();
            try
            {
                objConn.Open();

                objCmd.Connection = objConn;
                objCmd.CommandText = "PKG_MV_XEMBAOCAO.SELECT_ALL_DVIQLY";
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
        public DataTable SELECT_THIETBI_CHUASUDUNG(string pMA_DVIQLY, string pLOAIDN)
        {
            DataTable dt = new DataTable();
            OracleConnection objConn = new OracleConnection(ConnectString.ConnectionString(pMA_DVIQLY));
            OracleCommand objCmd = new OracleCommand();
            try
            {
                objConn.Open();

                objCmd.Connection = objConn;
                objCmd.CommandText = "PKG_MV_HAMDLKHAC.SELECT_THIETBI_CHUASUDUNG";
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
        public DataTable SELECT_THIETBI_CHUASUDUNG_NH(string pMA_DVIQLY, string pLOAIDN)
        {
            DataTable dt = new DataTable();
            OracleConnection objConn = new OracleConnection(ConnectString.ConnectionString(pMA_DVIQLY));
            OracleCommand objCmd = new OracleCommand();
            try
            {
                objConn.Open();

                objCmd.Connection = objConn;
                objCmd.CommandText = "PKG_MV_HAMDLKHAC_NH.SELECT_THIETBI_CHUASUDUNG";
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
        public DataTable SELECT_ALL_NHANVIEN_NH(string pMA_DVIQLY, string pLOAIDN)
        {
            DataTable dt = new DataTable();
            OracleConnection objConn = new OracleConnection(ConnectString.ConnectionString(pMA_DVIQLY));
            OracleCommand objCmd = new OracleCommand();
            try
            {
                objConn.Open();

                objCmd.Connection = objConn;
                objCmd.CommandText = "PKG_MV_HAMDLKHAC_NH.SELECT_ALL_NHANVIEN_CD";
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

        public DataTable SELECT_THUNGANVIEN(string pMA_DVIQLY, string pMA_TNGAN)
        {
            DataTable dt = new DataTable();
            OracleConnection objConn = new OracleConnection(ConnectString.ConnectionString(pMA_DVIQLY));
            OracleCommand objCmd = new OracleCommand();
            try
            {
                objConn.Open();

                objCmd.Connection = objConn;
                objCmd.CommandText = "PKG_MV_HAMDLKHAC.SELECT_THUNGANVIEN";
                objCmd.CommandType = CommandType.StoredProcedure;
                objCmd.Parameters.Add("pMA_DVIQLY", OracleType.VarChar).Value = pMA_DVIQLY;
                objCmd.Parameters.Add("pMA_TNGAN", OracleType.VarChar).Value = pMA_TNGAN;
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

        public void DOWNLOAD_DATA_CN_DV(string pMA_DVIQLY, string pUSERNAME, string pIMEI, int pTHANG, int pNAM, decimal pID_HDON, DateTime pNGAY_CHAMNO, string pISDOW)
        {
            OracleConnection objConn = new OracleConnection(ConnectString.ConnectionString(pMA_DVIQLY));
            OracleCommand objCmd = new OracleCommand();
            try
            {
                objConn.Open();
                objCmd.Connection = objConn;
                objCmd.CommandText = "PKG_MV_CAPNHATNO.DOWNLOAD_DATA_CN_DV";
                objCmd.CommandType = CommandType.StoredProcedure;
                objCmd.Parameters.Add("pMA_DVIQLY", OracleType.VarChar).Value = pMA_DVIQLY;
                objCmd.Parameters.Add("pUSERNAME", OracleType.VarChar).Value = pUSERNAME;
                objCmd.Parameters.Add("pIMEI", OracleType.VarChar).Value = pIMEI;
                objCmd.Parameters.Add("pID_HDON", OracleType.Number).Value = pID_HDON;
                objCmd.Parameters.Add("pNGAY_CHAMNO", OracleType.DateTime).Value = pNGAY_CHAMNO;
                objCmd.Parameters.Add("pTHANG", OracleType.Number).Value = pTHANG;
                objCmd.Parameters.Add("pNAM", OracleType.Number).Value = pNAM;
                objCmd.Parameters.Add("pISDOW", OracleType.VarChar).Value = pISDOW;
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
        public void CAPNHATCHAMNO(string pMA_DVIQLY, string pUSERNAME, string pIMEI, int pTHANG, int pNAM, string pMA_KHANG, DateTime pNGAY_CHAMNO, string pISDOW)
        {
            OracleConnection objConn = new OracleConnection(ConnectString.ConnectionString(pMA_DVIQLY));
            OracleCommand objCmd = new OracleCommand();
            try
            {
                objConn.Open();
                objCmd.Connection = objConn;
                objCmd.CommandText = "PKG_MV_CAPNHATNO.CAPNHATCHAMNO";
                objCmd.CommandType = CommandType.StoredProcedure;
                objCmd.Parameters.Add("pMA_DVIQLY", OracleType.VarChar).Value = pMA_DVIQLY;
                objCmd.Parameters.Add("pUSERNAME", OracleType.VarChar).Value = pUSERNAME;
                objCmd.Parameters.Add("pIMEI", OracleType.VarChar).Value = pIMEI;
                objCmd.Parameters.Add("pMA_KHANG", OracleType.VarChar).Value = pMA_KHANG;
                objCmd.Parameters.Add("pNGAY_CHAMNO", OracleType.DateTime).Value = pNGAY_CHAMNO;
                objCmd.Parameters.Add("pTHANG", OracleType.Number).Value = pTHANG;
                objCmd.Parameters.Add("pNAM", OracleType.Number).Value = pNAM;
                objCmd.Parameters.Add("pISDOW", OracleType.VarChar).Value = pISDOW;
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
        public void CN_CAPNHATNOCMIS(string pMA_DVIQLY, string v_MaTNgan, int pTHANG, int pNAM, decimal pID_HDON)
        {
            OracleConnection objConn = new OracleConnection(ConnectString.ConnectionString(pMA_DVIQLY));
            OracleCommand objCmd = new OracleCommand();
            try
            {
                objConn.Open();
                objCmd.Connection = objConn;
                objCmd.CommandText = "PKG_MV_DUYETNO.CN_CAPNHATNOCMIS";
                objCmd.CommandType = CommandType.StoredProcedure;
                objCmd.Parameters.Add("v_MaDViQLy", OracleType.VarChar).Value = pMA_DVIQLY;
                objCmd.Parameters.Add("v_Idhdon", OracleType.Number).Value = pID_HDON;
                objCmd.Parameters.Add("v_thang", OracleType.Number).Value = pTHANG;
                objCmd.Parameters.Add("v_nam", OracleType.Number).Value = pNAM;
                objCmd.Parameters.Add("v_MaTNgan", OracleType.VarChar).Value = v_MaTNgan;
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
        public void CN_CAPNHATNOCMIS_KOHT(string pMA_DVIQLY, string v_MaTNgan, int pTHANG, int pNAM, decimal pID_HDON)
        {
            OracleConnection objConn = new OracleConnection(ConnectString.ConnectionString(pMA_DVIQLY));
            OracleCommand objCmd = new OracleCommand();
            try
            {
                objConn.Open();
                objCmd.Connection = objConn;
                objCmd.CommandText = "PKG_MV_DUYETNO.CN_CAPNHATNOCMIS_KOHT";
                objCmd.CommandType = CommandType.StoredProcedure;
                objCmd.Parameters.Add("v_MaDViQLy", OracleType.VarChar).Value = pMA_DVIQLY;
                objCmd.Parameters.Add("v_Idhdon", OracleType.Number).Value = pID_HDON;
                objCmd.Parameters.Add("v_thang", OracleType.Number).Value = pTHANG;
                objCmd.Parameters.Add("v_nam", OracleType.Number).Value = pNAM;
                objCmd.Parameters.Add("v_MaTNgan", OracleType.VarChar).Value = v_MaTNgan;
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
        public void Delete_ThietBiDD_NH(string pMA_DVIQLY, string pIMEI)
        {
            OracleConnection objConn = new OracleConnection(ConnectString.ConnectionString(pMA_DVIQLY));
            OracleCommand objCmd = new OracleCommand();
            try
            {
                objConn.Open();
                objCmd.Connection = objConn;
                objCmd.CommandText = "PKG_MV_HAMDLKHAC_NH.Delete_ThietBiDD";
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
        public void Insert_ThietBiDD_NH(string pMA_DVIQLY, string pIP, string pIMEI, string pTENDINHDANH, string pHANGSX, string pHEDIEUHANH, DateTime pNGAYCAPNHAT, string pCHUNGLOAI)
        {
            OracleConnection objConn = new OracleConnection(ConnectString.ConnectionString(pMA_DVIQLY));
            OracleCommand objCmd = new OracleCommand();
            try
            {
                objConn.Open();
                objCmd.Connection = objConn;
                objCmd.CommandText = "PKG_MV_HAMDLKHAC_NH.Insert_ThietBiDD";
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
        public void Update_ThietBiDD_NH(string pMA_DVIQLY, string pIP, string pIMEI, string pTENDINHDANH, string pHANGSX, string pHEDIEUHANH, DateTime pNGAYCAPNHAT, string pCHUNGLOAI)
        {
            OracleConnection objConn = new OracleConnection(ConnectString.ConnectionString(pMA_DVIQLY));
            OracleCommand objCmd = new OracleCommand();
            try
            {
                objConn.Open();
                objCmd.Connection = objConn;
                objCmd.CommandText = "PKG_MV_HAMDLKHAC_NH.Update_ThietBiDD";
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
        public void HUY_IDHDON(string pMA_DVIQLY, decimal pID_HDON, string pLOAI)
        {
            OracleConnection objConn = new OracleConnection(ConnectString.ConnectionString(pMA_DVIQLY));
            OracleCommand objCmd = new OracleCommand();
            try
            {
                objConn.Open();
                objCmd.Connection = objConn;
                objCmd.CommandText = "PKG_MV_CAPNHATNO.HUY_IDHDON_MV";
                objCmd.CommandType = CommandType.StoredProcedure;
                objCmd.Parameters.Add("pMA_DVIQLY", OracleType.VarChar).Value = pMA_DVIQLY;
                objCmd.Parameters.Add("pID_HDON", OracleType.Number).Value = pID_HDON;
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
        public void DELETE_GHIDL_NH(string pMA_DVIQLY, int pID_USERTB, string pLOAIDN)
        {
            OracleConnection objConn = new OracleConnection(ConnectString.ConnectionString(pMA_DVIQLY));
            OracleCommand objCmd = new OracleCommand();
            try
            {
                objConn.Open();
                objCmd.Connection = objConn;
                objCmd.CommandText = "PKG_MV_HAMDLKHAC_NH.DELETE_GHIDL";
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
        public void INSERTBANGTAM_SOGCS(string pMA_DVIQLY, string pIMEI, string pMA_SOGCS, int pKY, int pTHANG, int pNAM, string pUSERNAME, string pLOAI)
        {
            OracleConnection objConn = new OracleConnection(ConnectString.ConnectionString(pMA_DVIQLY));
            OracleCommand objCmd = new OracleCommand();
            try
            {
                objConn.Open();
                objCmd.Connection = objConn;
                objCmd.CommandText = "PKG_CHAMNO_MAVACH.INSERTBANGTAM_SOGCS";
                objCmd.CommandType = CommandType.StoredProcedure;
                objCmd.Parameters.Add("pMA_DVIQLY", OracleType.VarChar).Value = pMA_DVIQLY;
                objCmd.Parameters.Add("pIMEI", OracleType.VarChar).Value = pIMEI;
                objCmd.Parameters.Add("pMA_SOGCS", OracleType.VarChar).Value = pMA_SOGCS;
                objCmd.Parameters.Add("pKY", OracleType.Number).Value = pKY;
                objCmd.Parameters.Add("pTHANG", OracleType.Number).Value = pTHANG;
                objCmd.Parameters.Add("pNAM", OracleType.Number).Value = pNAM;
                objCmd.Parameters.Add("pUSERNAME", OracleType.VarChar).Value = pUSERNAME;
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
        public void INSERT_GHIDL_NH(string pMA_DVIQLY, string pMA_NVIEN, string pIMEI, string pPASS, string pLOAI, int pID_USERTB, ref int pIDOUT, string pLOAIDN)
        {
            OracleConnection objConn = new OracleConnection(ConnectString.ConnectionString(pMA_DVIQLY));
            OracleCommand objCmd = new OracleCommand();
            try
            {

                DbParameter ID = CreateParameter("pIDOUT", DbType.Int32, true);
                objConn.Open();
                objCmd.Connection = objConn;
                objCmd.CommandText = "PKG_MV_HAMDLKHAC_NH.INSERT_GHIDL";
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
        public void InsertLog(string ChucNang, string ThaoTac, decimal ID_HDON, int TINHTRANG, string UserName, string MA_DVIQLY, string MA_KHANG, int THANG, int NAM)
        {

            OracleConnection objConn = new OracleConnection(ConnectString.ConnectionString(MA_DVIQLY));
            OracleCommand objCmd = new OracleCommand();
            try
            {
                objConn.Open();
                objCmd.Connection = objConn;
                objCmd.CommandText = "PKG_MV_XEMBAOCAO.Log_HDON_Insert_1";
                objCmd.CommandType = CommandType.StoredProcedure;
                objCmd.Parameters.Add("pMA_DVIQLY", OracleType.VarChar).Value = MA_DVIQLY;
                objCmd.Parameters.Add("pChucNang", OracleType.VarChar).Value = ChucNang;
                objCmd.Parameters.Add("pThaoTac", OracleType.VarChar).Value = ThaoTac;
                objCmd.Parameters.Add("pID_HDON", OracleType.Number).Value = ID_HDON;
                objCmd.Parameters.Add("pTINHTRANG", OracleType.Number).Value = TINHTRANG;
                objCmd.Parameters.Add("pUserName", OracleType.VarChar).Value = UserName;
                objCmd.Parameters.Add("pMA_KHANG", OracleType.VarChar).Value = MA_KHANG;
                objCmd.Parameters.Add("pTHANG", OracleType.Number).Value = THANG;
                objCmd.Parameters.Add("pNAM", OracleType.Number).Value = NAM;
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
        #endregion
    }
}


