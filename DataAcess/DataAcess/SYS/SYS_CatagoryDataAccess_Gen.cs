using System;
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
        private SYS_Catagory _SYS_Catagory;

        private MSSqlHelper _DbHelper = new MSSqlHelper();

        public static string FIELD_ID = "ID";
        public static string FIELD_NAME = "Name";
        public static string FIELD_CODE = "Code";
        public static string FIELD_TABLENAME = "tableName";
        public static string FIELD_PARENTID = "ParentID";
        public static string FIELD_IDNHANSU = "IDNhanSu";


        #region Private methods

        private static void SetSYS_CatagoryInfo(DbDataReader reader, ref SYS_Catagory SYS_Catagory)
        {
            SYS_Catagory.ID = Convert.ToInt32("" + reader[FIELD_ID]);
            SYS_Catagory.Code = "" + reader[FIELD_CODE];
            SYS_Catagory.Name = "" + reader[FIELD_NAME];
            SYS_Catagory.ParentID = Convert.ToInt32("" + reader[FIELD_PARENTID]);
            if (reader.FieldCount > 4)
            {
                try
                {
                    SYS_Catagory.DonViTinh = "" + reader["DonViTinh"];
                }
                catch (Exception)
                { }

            }

        }

        public static void SetListSYS_CatagoryInfo(ref DbDataReader reader, ref List<SYS_Catagory> SYS_Catagorys)
        {
            SYS_Catagory SYS_Catagory = null;
            while (reader.Read())
            {
                SYS_Catagory = new SYS_Catagory();
                SYS_CatagoryDataAccess.SetSYS_CatagoryInfo(reader, ref SYS_Catagory);
                SYS_Catagorys.Add(SYS_Catagory);
            }
        }

        #endregion

        #region Static methods
        #endregion
        public int InsertSYS_Catagory(SYS_Catagory SYS_Catagory, string tableName, string Connection)
        {
            SYS_ConfigConnectionDataAccess connect = new SYS_ConfigConnectionDataAccess();
            Connection = connect.DecryptSYS_ConfigConnection(Connection);
            List<DbParameter> para = new List<DbParameter>();
            DbConnection conn = _DbHelper.CreateConnection(Connection);
            conn.Open();
            try
            {

                DbParameter ouput = _DbHelper.CreateParameter(FIELD_ID, DbType.Int32, true);
                para.Add(_DbHelper.CreateParameter(FIELD_NAME, SYS_Catagory.Name, false));
                para.Add(_DbHelper.CreateParameter(FIELD_CODE, SYS_Catagory.Code, false));
                para.Add(_DbHelper.CreateParameter(FIELD_TABLENAME, tableName, false));
                para.Add(_DbHelper.CreateParameter(FIELD_PARENTID, SYS_Catagory.ParentID, false));
                para.Add(ouput);
                _DbHelper.ExecuteNonQuery(conn, Common.DatabaseSchema + "[SYS_Catagory_Insert]", para.ToArray());
                return (int)ouput.Value;
            }
            catch (Exception ex)
            {
                throw new Exception(String.Format("SYS_CatagoryDataAccess.Insert: {0}", ex.Message));
            }
            finally
            {
                conn.Close();
            }
        }

        public int UpdateSYS_Catagory(List<SYS_Catagory> SYS_Catagorys, string tableName, string Connection)
        {
            SYS_ConfigConnectionDataAccess connectionDataAccess = new SYS_ConfigConnectionDataAccess();
            DbConnection connection = Common.CreateConnection(connectionDataAccess.DecryptSYS_ConfigConnection(Connection));
            connection.Open();
            int count = 0;
            try
            {

                foreach (SYS_Catagory SYS_Catagory in SYS_Catagorys)
                {
                    List<DbParameter> para = new List<DbParameter>();

                    para.Add(_DbHelper.CreateParameter(FIELD_ID, SYS_Catagory.ID, false));
                    para.Add(_DbHelper.CreateParameter(FIELD_NAME, SYS_Catagory.Name, false));
                    para.Add(_DbHelper.CreateParameter(FIELD_CODE, SYS_Catagory.Code, false));
                    para.Add(_DbHelper.CreateParameter(FIELD_TABLENAME, tableName, false));
                    para.Add(_DbHelper.CreateParameter(FIELD_PARENTID, SYS_Catagory.ParentID, false));
                    _DbHelper.ExecuteNonQuery(connection, Common.DatabaseSchema + "[SYS_Catagory_Update]", para.ToArray());
                    count++;
                }
            }
            catch (Exception ex)
            {
                throw new Exception(String.Format("SYS_CatagoryDataAccess.Update: {0}", ex.Message));
            }
            finally
            {
                connection.Close();
            }
            return count;
        }

        public void UpdateSYS_Catagory(SYS_Catagory SYS_Catagory, string tableName, string Connection)
        {
            SYS_ConfigConnectionDataAccess connect = new SYS_ConfigConnectionDataAccess();
            DbConnection conn = _DbHelper.CreateConnection(connect.DecryptSYS_ConfigConnection(Connection));
            conn.Open();

            try
            {

                //Connection = connect.DecryptSYS_ConfigConnection(Connection);
                List<DbParameter> para = new List<DbParameter>();

                para.Add(_DbHelper.CreateParameter(FIELD_ID, SYS_Catagory.ID, false));
                para.Add(_DbHelper.CreateParameter(FIELD_NAME, SYS_Catagory.Name, false));
                para.Add(_DbHelper.CreateParameter(FIELD_CODE, SYS_Catagory.Code, false));
                para.Add(_DbHelper.CreateParameter(FIELD_TABLENAME, tableName, false));
                para.Add(_DbHelper.CreateParameter(FIELD_PARENTID, SYS_Catagory.ParentID, false));

                _DbHelper.ExecuteNonQuery(conn, Common.DatabaseSchema + "[SYS_Catagory_Update]", para.ToArray());

            }
            catch (Exception ex)
            {
                throw new Exception(String.Format("SYS_CatagoryDataAccess.Update: {0}", ex.Message));
            }
            finally
            {
                conn.Close();
            }
        }

        public void DeleteSYS_Catagory(List<SYS_Catagory> SYS_Catagorys, string tableName, string Connection)
        {
            SYS_ConfigConnectionDataAccess connectionDataAccess = new SYS_ConfigConnectionDataAccess();
            DbConnection connection = Common.CreateConnection(connectionDataAccess.DecryptSYS_ConfigConnection(Connection));
            connection.Open();
            List<DbParameter> para = new List<DbParameter>();

            try
            {

                foreach (SYS_Catagory SYS_Catagory in SYS_Catagorys)
                {

                    para.Add(_DbHelper.CreateParameter(FIELD_ID, SYS_Catagory.ID, false));
                    para.Add(_DbHelper.CreateParameter(FIELD_TABLENAME, tableName, false));

                    _DbHelper.ExecuteNonQuery(connection, Common.DatabaseSchema + "[SYS_Catagory_Delete]", para.ToArray());
                    para.Clear();
                }
            }
            catch (Exception ex)
            {
                throw new Exception(String.Format("SYS_CatagoryDataAccess.Delete: {0}", ex.Message));
            }
            finally
            {
                connection.Close();
            }
        }

        public void DeleteSYS_Catagory(SYS_Catagory SYS_Catagory, string tableName, string Connection)
        {
            SYS_ConfigConnectionDataAccess connectionDataAccess = new SYS_ConfigConnectionDataAccess();
            DbConnection connection = Common.CreateConnection(connectionDataAccess.DecryptSYS_ConfigConnection(Connection));
            connection.Open();
            try
            {
                List<DbParameter> para = new List<DbParameter>();
                para.Add(_DbHelper.CreateParameter(FIELD_ID, SYS_Catagory.ID, false));
                para.Add(_DbHelper.CreateParameter(FIELD_TABLENAME, tableName, false));

                _DbHelper.ExecuteNonQuery(connection, Common.DatabaseSchema + "[SYS_Catagory_Delete]",
                                          para.ToArray());
            }
            catch (Exception ex)
            {
                throw new Exception(String.Format("SYS_CatagoryDataAccess.DeleteSYS_Catagory: {0}", ex.Message));
            }
            finally
            {
                connection.Close();
            }
        }






        public int InsertSYS_Catagory(DbTransaction transaction, SYS_Catagory SYS_Catagory, string tableName)
        {
            try
            {

                List<DbParameter> para = new List<DbParameter>();

                DbParameter ouput = _DbHelper.CreateParameter(FIELD_ID, DbType.Int32, true);
                para.Add(_DbHelper.CreateParameter(FIELD_NAME, SYS_Catagory.Name, false));
                para.Add(_DbHelper.CreateParameter(FIELD_CODE, SYS_Catagory.Code, false));
                para.Add(_DbHelper.CreateParameter(FIELD_TABLENAME, tableName, false));

                para.Add(ouput);

                _DbHelper.ExecuteNonQuery(transaction, Common.DatabaseSchema + "[SYS_Catagory_Insert]", para.ToArray());

                return (int)ouput.Value;
            }
            catch (Exception ex)
            {
                throw new Exception(String.Format("SYS_CatagoryDataAccess.Insert: {0}", ex.Message));
            }
        }



        public int UpdateSYS_Catagory(DbTransaction transaction, List<SYS_Catagory> SYS_Catagorys, string tableName)
        {

            int count = 0;
            try
            {

                foreach (SYS_Catagory SYS_Catagory in SYS_Catagorys)
                {
                    List<DbParameter> para = new List<DbParameter>();

                    para.Add(_DbHelper.CreateParameter(FIELD_ID, SYS_Catagory.ID, false));
                    para.Add(_DbHelper.CreateParameter(FIELD_NAME, SYS_Catagory.Name, false));
                    para.Add(_DbHelper.CreateParameter(FIELD_CODE, SYS_Catagory.Code, false));
                    para.Add(_DbHelper.CreateParameter(FIELD_TABLENAME, tableName, false));

                    _DbHelper.ExecuteNonQuery(transaction, Common.DatabaseSchema + "[SYS_Catagory_Update]", para.ToArray());
                    count++;
                }
            }

            catch (Exception ex)
            {
                throw new Exception(String.Format("SYS_CatagoryDataAccess.Update: {0}", ex.Message));
            }

            return count;
        }

        public void UpdateSYS_Catagory(DbTransaction transaction, SYS_Catagory SYS_Catagory, string tableName)
        {
            try
            {
                List<DbParameter> para = new List<DbParameter>();

                para.Add(_DbHelper.CreateParameter(FIELD_ID, SYS_Catagory.ID, false));
                para.Add(_DbHelper.CreateParameter(FIELD_NAME, SYS_Catagory.Name, false));
                para.Add(_DbHelper.CreateParameter(FIELD_CODE, SYS_Catagory.Code, false));
                para.Add(_DbHelper.CreateParameter(FIELD_TABLENAME, tableName, false));

                _DbHelper.ExecuteNonQuery(transaction, Common.DatabaseSchema + "[SYS_Catagory_Update]", para.ToArray());

            }
            catch (Exception ex)
            {
                throw new Exception(String.Format("SYS_CatagoryDataAccess.Update: {0}", ex.Message));
            }
        }

        public int DeleteSYS_Catagory(DbTransaction transaction, List<SYS_Catagory> SYS_Catagorys, string tableName)
        {
            int count = 0;
            try
            {
                List<DbParameter> para = new List<DbParameter>();
                foreach (SYS_Catagory SYS_Catagory in SYS_Catagorys)
                {
                    para.Add(_DbHelper.CreateParameter(FIELD_ID, DbType.Int32, false));
                    para.Add(_DbHelper.CreateParameter(FIELD_TABLENAME, tableName, false));

                    _DbHelper.ExecuteNonQuery(transaction, Common.DatabaseSchema + "[SYS_Catagory_Delete]", para.ToArray());
                    para.Clear();
                    count++;
                }
            }
            catch (Exception ex)
            {
                throw new Exception(String.Format("SYS_CatagoryDataAccess.Delete: {0}", ex.Message));
            }

            return count;
        }
    }
}

