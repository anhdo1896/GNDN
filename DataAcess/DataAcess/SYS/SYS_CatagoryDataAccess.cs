using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Linq;
using System.Text;
using Connection;
using Entity;

namespace DataAccess
{
    public partial class SYS_CatagoryDataAccess
    {
        public List<SYS_Catagory> SelectAllSYS_CatagoryByStrCn(string tableName, string connect)
        {
            List<SYS_Catagory> SYS_Catagory = new List<SYS_Catagory>();
            DbDataReader reader = null;
            DbConnection connection = _DbHelper.CreateConnection(connect);
            connection.Open();
            try
            {
                List<DbParameter> para = new List<DbParameter>();
                para.Add(_DbHelper.CreateParameter(FIELD_TABLENAME, tableName, false));

                reader = _DbHelper.ExecuteReader(connection, Common.DatabaseSchema + "[SYS_Catagory_SelectAll]", (DbParameter[])para.ToArray());
                if (reader.HasRows)
                    SYS_CatagoryDataAccess.SetListSYS_CatagoryInfo(ref reader, ref SYS_Catagory);

            }
            catch (Exception ex)
            {
                throw new Exception(String.Format(" SYS_CatagoryDataAccess.SelectAll: {0}", ex.Message));
            }
            finally
            {
                if (reader != null)
                    reader.Close();
                connection.Close();
            }
            return SYS_Catagory;
        }
        public SYS_Catagory SelectSYS_Catagory(string ID, string tableName, string Connection)
        {
            SYS_ConfigConnectionDataAccess connect = new SYS_ConfigConnectionDataAccess();
            Connection = connect.DecryptSYS_ConfigConnection(Connection);
            DbConnection connection = _DbHelper.CreateConnection(Connection);
            connection.Open();
            SYS_Catagory SYS_Catagory = new SYS_Catagory();
            DbDataReader reader = null;
            try
            {
                List<DbParameter> para = new List<DbParameter>();
                para.Add(_DbHelper.CreateParameter(FIELD_ID, ID, false));
                para.Add(_DbHelper.CreateParameter(FIELD_TABLENAME, tableName, false));

                reader = _DbHelper.ExecuteReader(connection, Common.DatabaseSchema + "[SYS_Catagory_SelectById]", para.ToArray());
                if (reader.HasRows && reader.Read())
                    SYS_CatagoryDataAccess.SetSYS_CatagoryInfo(reader, ref SYS_Catagory);

            }
            catch (Exception ex)
            {
                throw new Exception(String.Format("SYS_CatagoryDataAccess.SelectById: {0}", ex.Message));
            }
            finally
            {
                if (reader != null)
                    reader.Close();
                connection.Close();
            }
            return SYS_Catagory;
        }
        public List<SYS_Catagory> SelectSYS_CatagoryByParentID(string ParentID, string tableName, string Connection)
        {
            SYS_ConfigConnectionDataAccess connect = new SYS_ConfigConnectionDataAccess();
            Connection = connect.DecryptSYS_ConfigConnection(Connection);
            DbConnection connection = _DbHelper.CreateConnection(Connection);
            connection.Open();
            List<SYS_Catagory> SYS_Catagory = new List<SYS_Catagory>();
            DbDataReader reader = null;
            try
            {
                List<DbParameter> para = new List<DbParameter>();
                para.Add(_DbHelper.CreateParameter(FIELD_PARENTID, ParentID, false));
                para.Add(_DbHelper.CreateParameter(FIELD_TABLENAME, tableName, false));

                reader = _DbHelper.ExecuteReader(connection, Common.DatabaseSchema + "[SYS_Catagory_SelectByParentId]", para.ToArray());
                if (reader.HasRows)
                    SYS_CatagoryDataAccess.SetListSYS_CatagoryInfo(ref reader, ref SYS_Catagory);

            }
            catch (Exception ex)
            {
                throw new Exception(String.Format("SYS_CatagoryDataAccess.SelectById: {0}", ex.Message));
            }
            finally
            {
                if (reader != null)
                    reader.Close();
                connection.Close();
            }
            return SYS_Catagory;
        }

        /// <summary>
        /// Sử dụng cho các bảng về VTHCPD
        /// </summary>
        /// <param name="TableNotIn"></param>
        /// <param name="IDDonVi"></param>
        /// <param name="Year"></param>
        /// <param name="ParentID"></param>
        /// <param name="tableName"></param>
        /// <param name="Connection"></param>
        /// <returns></returns>
        public List<SYS_Catagory> SelectSYS_CatagoryByParentIDNotInTable(string TableNotIn, int IDDonVi, int IDChungLoai, int Year, string ParentID, string tableName, string Connection)
        {
            SYS_ConfigConnectionDataAccess connect = new SYS_ConfigConnectionDataAccess();
            Connection = connect.DecryptSYS_ConfigConnection(Connection);
            DbConnection connection = _DbHelper.CreateConnection(Connection);
            connection.Open();
            List<SYS_Catagory> SYS_Catagory = new List<SYS_Catagory>();
            DbDataReader reader = null;
            try
            {
                List<DbParameter> para = new List<DbParameter>();
                para.Add(_DbHelper.CreateParameter(FIELD_PARENTID, ParentID, false));
                para.Add(_DbHelper.CreateParameter(FIELD_TABLENAME, tableName, false));
                para.Add(_DbHelper.CreateParameter("TableNotIn", TableNotIn, false));
                para.Add(_DbHelper.CreateParameter("IDDonVi", IDDonVi, false));
                para.Add(_DbHelper.CreateParameter("DBYear", Year, false));
                para.Add(_DbHelper.CreateParameter("IDChungLoai", IDChungLoai, false));

                reader = _DbHelper.ExecuteReader(connection, Common.DatabaseSchema + "[SYS_Catagory_SelectByParentIdNotInTable]", para.ToArray());
                if (reader.HasRows)
                    SYS_CatagoryDataAccess.SetListSYS_CatagoryInfo(ref reader, ref SYS_Catagory);

            }
            catch (Exception ex)
            {
                throw new Exception(String.Format("SYS_CatagoryDataAccess.SelectByIdNotInTable: {0}", ex.Message));
            }
            finally
            {
                if (reader != null)
                    reader.Close();
                connection.Close();
            }
            return SYS_Catagory;
        }

        public List<SYS_Catagory> SelectAllSYS_Catagory(string tableName, string Connection)
        {
            SYS_ConfigConnectionDataAccess connect = new SYS_ConfigConnectionDataAccess();
            DbConnection connection = _DbHelper.CreateConnection(connect.DecryptSYS_ConfigConnection(Connection));
            connection.Open();
            List<SYS_Catagory> SYS_Catagory = new List<SYS_Catagory>();
            DbDataReader reader = null;
            try
            {
                List<DbParameter> para = new List<DbParameter>();
                para.Add(_DbHelper.CreateParameter(FIELD_TABLENAME, tableName, false));

                reader = _DbHelper.ExecuteReader(connection, Common.DatabaseSchema + "[SYS_Catagory_SelectAll]", (DbParameter[])para.ToArray());
                if (reader.HasRows)
                    SYS_CatagoryDataAccess.SetListSYS_CatagoryInfo(ref reader, ref SYS_Catagory);

            }
            catch (Exception ex)
            {
                throw new Exception(String.Format(" SYS_CatagoryDataAccess.SelectAll: {0}", ex.Message));
            }
            finally
            {
                if (reader != null)
                    reader.Close();
                connection.Close();
            }
            return SYS_Catagory;
        }

        public List<SYS_Catagory> SelectListCombo(string tableName, int ID, string Connection)
        {
            SYS_ConfigConnectionDataAccess connect = new SYS_ConfigConnectionDataAccess();
            DbConnection connection = _DbHelper.CreateConnection(connect.DecryptSYS_ConfigConnection(Connection));
            connection.Open();
            List<SYS_Catagory> SYS_Catagory = new List<SYS_Catagory>();
            DbDataReader reader = null;
            try
            {
                List<DbParameter> para = new List<DbParameter>();
                para.Add(_DbHelper.CreateParameter(FIELD_TABLENAME, tableName, false));
                para.Add(_DbHelper.CreateParameter(FIELD_ID, ID, false));

                reader = _DbHelper.ExecuteReader(connection, Common.DatabaseSchema + "[SYS_Catagory_SelectListCombo]", (DbParameter[])para.ToArray());
                if (reader.HasRows)
                    SYS_CatagoryDataAccess.SetListSYS_CatagoryInfo(ref reader, ref SYS_Catagory);

            }
            catch (Exception ex)
            {
                throw new Exception(String.Format(" SYS_CatagoryDataAccess.SelectListCombo: {0}", ex.Message));
            }
            finally
            {
                if (reader != null)
                    reader.Close();
                connection.Close();
            }
            return SYS_Catagory;
        }

        public SYS_Catagory SelectSYS_CatagoryById(int ID, string tableName)
        {
            SYS_ConfigConnectionDataAccess connect = new SYS_ConfigConnectionDataAccess();

            DbConnection connection = _DbHelper.CreateConnection(Common.ConnectionString);
            connection.Open();
            SYS_Catagory SYS_Catagory = new SYS_Catagory();
            DbDataReader reader = null;
            try
            {
                List<DbParameter> para = new List<DbParameter>();
                para.Add(_DbHelper.CreateParameter(FIELD_ID, ID, false));
                para.Add(_DbHelper.CreateParameter(FIELD_TABLENAME, tableName, false));

                reader = _DbHelper.ExecuteReader(connection, Common.DatabaseSchema + "[SYS_Catagory_SelectById]", para.ToArray());
                if (reader.HasRows && reader.Read())
                    SYS_CatagoryDataAccess.SetSYS_CatagoryInfo(reader, ref SYS_Catagory);

            }
            catch (Exception ex)
            {
                throw new Exception(String.Format("SYS_CatagoryDataAccess.SelectById: {0}", ex.Message));
            }
            finally
            {
                if (reader != null)
                    reader.Close();
                connection.Close();
            }
            return SYS_Catagory;
        }

        public List<SYS_Catagory> SelectSYS_CatagoryByIdNhanSu(int ID, DbConnection connection)
        {
            SYS_ConfigConnectionDataAccess connect = new SYS_ConfigConnectionDataAccess();
            List<SYS_Catagory> SYS_Catagory = new List<SYS_Catagory>();
            //DbConnection connection = _DbHelper.CreateConnection(Common.ConnectionString);


            DbDataReader reader = null;
            try
            {
                List<DbParameter> para = new List<DbParameter>();
                para.Add(_DbHelper.CreateParameter(FIELD_IDNHANSU, ID, false));


                reader = _DbHelper.ExecuteReader(connection, Common.DatabaseSchema + "[SYS_Catagory_SelectByIdNhanSu]", para.ToArray());
                if (reader.HasRows)
                    SYS_CatagoryDataAccess.SetListSYS_CatagoryInfo(ref reader, ref SYS_Catagory);

            }
            catch (Exception ex)
            {
                throw new Exception(String.Format("SYS_CatagoryDataAccess.SYS_Catagory_SelectByIdNhanSu: {0}", ex.Message));
            }
            //finally
            //{
            //    if (reader != null)
            //        reader.Close();
            //    connection.Close();
            //}
            return SYS_Catagory;
        }

        public List<SYS_Catagory> SelectSYS_CatagoryByIdNhanSuVien(int ID, DbConnection connection)
        {
            SYS_ConfigConnectionDataAccess connect = new SYS_ConfigConnectionDataAccess();
            List<SYS_Catagory> SYS_Catagory = new List<SYS_Catagory>();
            //DbConnection connection = _DbHelper.CreateConnection(Common.ConnectionString);


            DbDataReader reader = null;
            try
            {
                List<DbParameter> para = new List<DbParameter>();
                para.Add(_DbHelper.CreateParameter(FIELD_IDNHANSU, ID, false));


                reader = _DbHelper.ExecuteReader(connection, Common.DatabaseSchema + "[SYS_Catagory_SelectByIdNhanSuVien]", para.ToArray());
                if (reader.HasRows)
                    SYS_CatagoryDataAccess.SetListSYS_CatagoryInfo(ref reader, ref SYS_Catagory);

            }
            catch (Exception ex)
            {
                throw new Exception(String.Format("SYS_CatagoryDataAccess.SelectSYS_CatagoryByIdNhanSuVien: {0}", ex.Message));
            }
            //finally
            //{
            //    if (reader != null)
            //        reader.Close();
            //    connection.Close();
            //}
            return SYS_Catagory;
        }

        public List<SYS_Catagory> SelectSYS_CatagoryByIdNhanSuTTKDYTQT(int ID, DbConnection connection)
        {
            SYS_ConfigConnectionDataAccess connect = new SYS_ConfigConnectionDataAccess();
            List<SYS_Catagory> SYS_Catagory = new List<SYS_Catagory>();
            //DbConnection connection = _DbHelper.CreateConnection(Common.ConnectionString);


            DbDataReader reader = null;
            try
            {
                List<DbParameter> para = new List<DbParameter>();
                para.Add(_DbHelper.CreateParameter("IDNhanSu", ID, false));


                reader = _DbHelper.ExecuteReader(connection, Common.DatabaseSchema + "[SYS_Catagory_SelectByIdNhanSuTTKDYTQT]", para.ToArray());
                if (reader.HasRows)
                    SYS_CatagoryDataAccess.SetListSYS_CatagoryInfo(ref reader, ref SYS_Catagory);

            }
            catch (Exception ex)
            {
                throw new Exception(String.Format("SYS_CatagoryDataAccess.SelectSYS_CatagoryByIdNhanSuTinh: {0}", ex.Message));
            }

            //finally
            //{
            //    if (reader != null)
            //        reader.Close();
            //    connection.Close();
            //}
            return SYS_Catagory;
        }
        public List<SYS_Catagory> SelectSYS_CatagoryByIdNhanSuTTPCBXH(int ID, DbConnection connection)
        {
            SYS_ConfigConnectionDataAccess connect = new SYS_ConfigConnectionDataAccess();
            List<SYS_Catagory> SYS_Catagory = new List<SYS_Catagory>();
            //DbConnection connection = _DbHelper.CreateConnection(Common.ConnectionString);


            DbDataReader reader = null;
            try
            {
                List<DbParameter> para = new List<DbParameter>();
                para.Add(_DbHelper.CreateParameter("IDNhanSu", ID, false));


                reader = _DbHelper.ExecuteReader(connection, Common.DatabaseSchema + "[SYS_Catagory_SelectByIdNhanSuTTPCBXH]", para.ToArray());
                if (reader.HasRows)
                    SYS_CatagoryDataAccess.SetListSYS_CatagoryInfo(ref reader, ref SYS_Catagory);

            }
            catch (Exception ex)
            {
                throw new Exception(String.Format("SYS_CatagoryDataAccess.SelectSYS_CatagoryByIdNhanSuTinh: {0}", ex.Message));
            }

            //finally
            //{
            //    if (reader != null)
            //        reader.Close();
            //    connection.Close();
            //}
            return SYS_Catagory;
        }
        public List<SYS_Catagory> SelectSYS_CatagoryByIdNhanSuTTPCSR(int ID, DbConnection connection)
        {
            SYS_ConfigConnectionDataAccess connect = new SYS_ConfigConnectionDataAccess();
            List<SYS_Catagory> SYS_Catagory = new List<SYS_Catagory>();
            //DbConnection connection = _DbHelper.CreateConnection(Common.ConnectionString);


            DbDataReader reader = null;
            try
            {
                List<DbParameter> para = new List<DbParameter>();
                para.Add(_DbHelper.CreateParameter("IDNhanSu", ID, false));


                reader = _DbHelper.ExecuteReader(connection, Common.DatabaseSchema + "[SYS_Catagory_SelectByIdNhanSuTTPCSR]", para.ToArray());
                if (reader.HasRows)
                    SYS_CatagoryDataAccess.SetListSYS_CatagoryInfo(ref reader, ref SYS_Catagory);

            }
            catch (Exception ex)
            {
                throw new Exception(String.Format("SYS_CatagoryDataAccess.SelectSYS_CatagoryByIdNhanSuTinh: {0}", ex.Message));
            }

            //finally
            //{
            //    if (reader != null)
            //        reader.Close();
            //    connection.Close();
            //}
            return SYS_Catagory;
        }
        public List<SYS_Catagory> SelectSYS_CatagoryByIdNhanSuTinh(int ID, DbConnection connection)
        {
            SYS_ConfigConnectionDataAccess connect = new SYS_ConfigConnectionDataAccess();
            List<SYS_Catagory> SYS_Catagory = new List<SYS_Catagory>();
            //DbConnection connection = _DbHelper.CreateConnection(Common.ConnectionString);


            DbDataReader reader = null;
            try
            {
                List<DbParameter> para = new List<DbParameter>();
                para.Add(_DbHelper.CreateParameter("IDNhanSuTinh", ID, false));


                reader = _DbHelper.ExecuteReader(connection, Common.DatabaseSchema + "[SYS_Catagory_SelectByIdNhanSuTinh]", para.ToArray());
                if (reader.HasRows)
                    SYS_CatagoryDataAccess.SetListSYS_CatagoryInfo(ref reader, ref SYS_Catagory);

            }
            catch (Exception ex)
            {
                throw new Exception(String.Format("SYS_CatagoryDataAccess.SelectSYS_CatagoryByIdNhanSuTinh: {0}", ex.Message));
            }
            //finally
            //{
            //    if (reader != null)
            //        reader.Close();
            //    connection.Close();
            //}
            return SYS_Catagory;
        }


        public List<SYS_Catagory> SelectSYS_CatagoryByIdNhanSuHuyen(int ID, DbConnection connection)
        {
            SYS_ConfigConnectionDataAccess connect = new SYS_ConfigConnectionDataAccess();
            List<SYS_Catagory> SYS_Catagory = new List<SYS_Catagory>();
            //DbConnection connection = _DbHelper.CreateConnection(Common.ConnectionString);


            DbDataReader reader = null;
            try
            {
                List<DbParameter> para = new List<DbParameter>();
                para.Add(_DbHelper.CreateParameter("IDNhanSu", ID, false));


                reader = _DbHelper.ExecuteReader(connection, Common.DatabaseSchema + "[SYS_Catagory_SelectByIdNhanSuHuyen]", para.ToArray());
                if (reader.HasRows)
                    SYS_CatagoryDataAccess.SetListSYS_CatagoryInfo(ref reader, ref SYS_Catagory);

            }
            catch (Exception ex)
            {
                throw new Exception(String.Format("SYS_CatagoryDataAccess.SelectSYS_CatagoryByIdNhanSuHuyen: {0}", ex.Message));
            }
            //finally
            //{
            //    if (reader != null)
            //        reader.Close();
            //    connection.Close();
            //}
            return SYS_Catagory;
        }


        public List<SYS_Catagory> SelectSYS_CatagoryByIdNhanSuXa(int ID, DbConnection connection)
        {
            SYS_ConfigConnectionDataAccess connect = new SYS_ConfigConnectionDataAccess();
            List<SYS_Catagory> SYS_Catagory = new List<SYS_Catagory>();
            //DbConnection connection = _DbHelper.CreateConnection(Common.ConnectionString);


            DbDataReader reader = null;
            try
            {
                List<DbParameter> para = new List<DbParameter>();
                para.Add(_DbHelper.CreateParameter("IDNhanSu", ID, false));


                reader = _DbHelper.ExecuteReader(connection, Common.DatabaseSchema + "[SYS_Catagory_SelectByIdNhanSuXa]", para.ToArray());
                if (reader.HasRows)
                    SYS_CatagoryDataAccess.SetListSYS_CatagoryInfo(ref reader, ref SYS_Catagory);

            }
            catch (Exception ex)
            {
                throw new Exception(String.Format("SYS_CatagoryDataAccess.SelectSYS_CatagoryByIdNhanSuXáS: {0}", ex.Message));
            }
            //finally
            //{
            //    if (reader != null)
            //        reader.Close();
            //    connection.Close();
            //}
            return SYS_Catagory;
        }


        public DataTable SelectSYS_CatagoryById1(int ID, string tableName)
        {
            DataTable dt = new DataTable();

            DbConnection connection = _DbHelper.CreateConnection(Common.ConnectionString);
            connection.Open();
            ArrayList colParam = new ArrayList();
            colParam.Add(_DbHelper.CreateParam("tableName", SqlDbType.NVarChar, tableName));
            colParam.Add(_DbHelper.CreateParam("ID", SqlDbType.NVarChar, ID.ToString()));
            return _DbHelper.RunProcedureGet(connection, "SYS_Catagory_SelectById", colParam);
        }

        public List<SYS_Catagory> SelectAllSYS_Catagory(string tableName, DbConnection dbConnection)
        {
            List<SYS_Catagory> SYS_Catagory = new List<SYS_Catagory>();
            DbDataReader reader = null;
            try
            {
                List<DbParameter> para = new List<DbParameter>();
                para.Add(_DbHelper.CreateParameter(FIELD_TABLENAME, tableName, false));

                reader = _DbHelper.ExecuteReader(dbConnection, Common.DatabaseSchema + "[SYS_Catagory_SelectAll]", (DbParameter[])para.ToArray());
                if (reader.HasRows)
                    SYS_CatagoryDataAccess.SetListSYS_CatagoryInfo(ref reader, ref SYS_Catagory);

            }
            catch (Exception ex)
            {
                throw new Exception(String.Format(" SYS_CatagoryDataAccess.SelectAll: {0}", ex.Message));
            }
            finally
            {
                if (reader != null)
                    reader.Close();

            }
            return SYS_Catagory;
        }

        public List<SYS_Catagory> SelectAllSYS_Catagory(string tableName, DbTransaction dbTransaction)
        {
            List<SYS_Catagory> SYS_Catagory = new List<SYS_Catagory>();
            DbDataReader reader = null;
            try
            {
                List<DbParameter> para = new List<DbParameter>();
                para.Add(_DbHelper.CreateParameter(FIELD_TABLENAME, tableName, false));

                reader = _DbHelper.ExecuteReader(dbTransaction, Common.DatabaseSchema + "[SYS_Catagory_SelectAll]", (DbParameter[])para.ToArray());
                if (reader.HasRows)
                    SYS_CatagoryDataAccess.SetListSYS_CatagoryInfo(ref reader, ref SYS_Catagory);

            }
            catch (Exception ex)
            {
                throw new Exception(String.Format(" SYS_CatagoryDataAccess.SelectAll: {0}", ex.Message));
            }
            finally
            {
                if (reader != null)
                    reader.Close();

            }
            return SYS_Catagory;
        }

        public SYS_Catagory SelectSYS_CatagoryByName(string Name, string tableName)
        {
            SYS_ConfigConnectionDataAccess connect = new SYS_ConfigConnectionDataAccess();

            DbConnection connection = _DbHelper.CreateConnection(Common.ConnectionString);
            connection.Open();
            SYS_Catagory SYS_Catagory = new SYS_Catagory();
            DbDataReader reader = null;
            try
            {
                List<DbParameter> para = new List<DbParameter>();
                para.Add(_DbHelper.CreateParameter(FIELD_NAME, Name, false));
                para.Add(_DbHelper.CreateParameter(FIELD_TABLENAME, tableName, false));

                reader = _DbHelper.ExecuteReader(connection, Common.DatabaseSchema + "[SYS_Catagory_SelectByName]", para.ToArray());
                if (reader.HasRows && reader.Read())
                    SYS_CatagoryDataAccess.SetSYS_CatagoryInfo(reader, ref SYS_Catagory);

            }
            catch (Exception ex)
            {
                throw new Exception(String.Format("SYS_CatagoryDataAccess.SelectById: {0}", ex.Message));
            }
            finally
            {
                if (reader != null)
                    reader.Close();
                connection.Close();
            }
            return SYS_Catagory;
        }

        public int InsertDanhMuc(string TableName, string ParentName, string ChildName, string DonViTinh, string Connection)
        {
            SYS_ConfigConnectionDataAccess connect = new SYS_ConfigConnectionDataAccess();
            Connection = connect.DecryptSYS_ConfigConnection(Connection);
            DbConnection conn = _DbHelper.CreateConnection(Connection);
            conn.Open();
            try
            {

                List<DbParameter> para = new List<DbParameter>();
                DbParameter ouput = _DbHelper.CreateParameter(FIELD_ID, DbType.Int32, true);
                para.Add(_DbHelper.CreateParameter("ParentName", ParentName, false));
                para.Add(_DbHelper.CreateParameter("TableName", TableName, false));
                para.Add(_DbHelper.CreateParameter("ChildName", ChildName, false));
                para.Add(_DbHelper.CreateParameter("DonViTinh", DonViTinh, false));
                para.Add(ouput);
                _DbHelper.ExecuteNonQuery(conn, Common.DatabaseSchema + "[SYS_Catagory_InsertDanhMuc]", para.ToArray());
                return (int)ouput.Value;
            }
            catch (Exception ex)
            {
                throw new Exception(String.Format("SYS_CatagoryDataAccess.InsertDanhMuc: {0}", ex.Message));
            }
            finally
            {
                conn.Close();
            }
        }
    }
}

