using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Linq;
using System.Text;
using System.Data.SqlClient;
using System.Collections;
using System.Threading;

namespace Connection
{
    public class MSSqlHelper 
    {
        #region public
        public int ExecuteNonQuery(DbTransaction transaction, string command, DbParameter[] parameters)
        {
            SqlCommand cmd = new SqlCommand();
            SqlTransaction trans = (SqlTransaction)transaction;

            PrepareCommand(cmd, trans, CommandType.StoredProcedure, command, ConvertPara(parameters));
            int result = cmd.ExecuteNonQuery();
            cmd.Parameters.Clear();
            return result;
        }

        //public int ExecuteNonQuery(string connectionString, string command, DbParameter[] parameters)
        //{
        //    int result = -1;
        //    SqlConnection conn = new SqlConnection(connectionString);
        //    try
        //    {
        //        conn.Open();
        //        result = ExecuteNonQuery(conn, command, ConvertPara(parameters));
        //    }
        //    catch (Exception ex)
        //    {
        //        throw new Exception(ex.Message,ex);
        //    }
        //    finally
        //    {
        //        conn.Close();
        //    }
        //    return result;
        //}

        public int ExecuteNonQuery(DbConnection connection, string command, DbParameter[] parameters)
        {
            SqlCommand cmd = new SqlCommand();
            SqlConnection conn = (SqlConnection)connection;
            int result = -1;
            if (connection.State == ConnectionState.Open)
            {
                PrepareCommand(cmd, conn, CommandType.StoredProcedure, command, ConvertPara(parameters));
                cmd.CommandTimeout = 120;
                result = cmd.ExecuteNonQuery();
                cmd.Parameters.Clear();
            }
            else
            {
                throw new Exception("Connection is not openning");
            }
            return result;    
        }

        public DataTable RunProcedureGet(DbConnection sqlCn, string ProcedureName, ArrayList colParam)
        {
            DataTable dtb = new DataTable();
            SqlCommand sqlCmd = new SqlCommand();
            sqlCmd.CommandTimeout = 0;
            SqlDataAdapter sqlDA = new SqlDataAdapter();
            try
            {
                sqlCmd.Connection = (SqlConnection)sqlCn;
                sqlDA.SelectCommand = sqlCmd;
                sqlCmd.CommandText = ProcedureName;
                sqlCmd.CommandType = CommandType.StoredProcedure;
                if (colParam != null)
                {
                    for (int i = 0; i < colParam.Count; i++)
                        sqlCmd.Parameters.Add((SqlParameter)colParam[i]);
                }
             
                sqlCmd.ExecuteNonQuery();
                sqlDA.Fill(dtb);
            }
            //catch(SqlException sqlEx) {
            //    strErrorMessage = sqlEx.Message;
            //    intErrorNumber = sqlEx.Number;            
            //}
            finally { }

            sqlDA.Dispose();
            sqlDA = null;
            sqlCmd.Dispose();
            sqlCmd = null;

            return dtb;
        }

        public DataSet RunProcedureGetDataSet(DbConnection sqlCn, string ProcedureName, ArrayList colParam)
        {
            DataSet ds = new DataSet();
            SqlCommand sqlCmd = new SqlCommand();
            sqlCmd.CommandTimeout = 0;
            SqlDataAdapter sqlDA = new SqlDataAdapter();
            try
            {
                sqlCmd.Connection = (SqlConnection)sqlCn;
                sqlDA.SelectCommand = sqlCmd;
                sqlCmd.CommandText = ProcedureName;
                sqlCmd.CommandType = CommandType.StoredProcedure;

                for (int i = 0; i < colParam.Count; i++)
                    sqlCmd.Parameters.Add((SqlParameter)colParam[i]);
                sqlCmd.ExecuteNonQuery();
                sqlDA.Fill(ds);
            }
            //catch(SqlException sqlEx) {
            //    strErrorMessage = sqlEx.Message;
            //    intErrorNumber = sqlEx.Number;            
            //}
            finally { }

            sqlDA.Dispose();
            sqlDA = null;
            sqlCmd.Dispose();
            sqlCmd = null;

            return ds;
        }

        public bool RunSQL(DbConnection sqlCn, string SQL)
        {
            SqlCommand sqlCmd = new SqlCommand();
            SqlConnection conn = (SqlConnection)sqlCn;
            try
            {
                if (sqlCn.State == ConnectionState.Closed)
                {
                    conn.Open();
                }
                sqlCmd.Connection = conn;
                string[] arrSQL = SQL.Split(new string[] { "GO" }, StringSplitOptions.RemoveEmptyEntries);
                for (int i = 0; i < arrSQL.Length; i++)
                {
                    sqlCmd.CommandText = arrSQL[i];
                    sqlCmd.CommandType = CommandType.Text;
                    sqlCmd.ExecuteNonQuery();
                }
                return true;
            }
                
            catch (SqlException sqlEx)
            {
                return false;
            }
            finally
            {
                sqlCmd.Dispose();
                conn.Close();
                SqlConnection.ClearAllPools();
            }
            

        }
        public bool RunQuery(DbConnection sqlCn, string Query)
        {
            SqlCommand sqlCmd = new SqlCommand();
            SqlConnection conn = (SqlConnection)sqlCn;
            try
            {
                if (sqlCn.State == ConnectionState.Closed)
                {
                    conn.Open();
                }
                
                sqlCmd.Connection = conn;
                sqlCmd.CommandText = Query;
                sqlCmd.CommandType = CommandType.Text;
                sqlCmd.ExecuteNonQuery();
                
                return true;
            }
            catch (SqlException sqlEx)
            {
                return false;
            }
            finally
            {
                conn.Close();
                SqlConnection.ClearAllPools();
            }
        }

        public DataTable RunQueryWriteXML(DbConnection sqlCn, string Query)
        {
            SqlCommand sqlCmd = new SqlCommand();
            SqlConnection conn = (SqlConnection)sqlCn;
            DataTable dtb=new DataTable();
            SqlDataAdapter sqlDA = new SqlDataAdapter();
            try
            {
                if (sqlCn.State == ConnectionState.Closed)
                {
                    conn.Open();
                }

                sqlCmd.Connection = conn;
                sqlDA.SelectCommand = sqlCmd;
                sqlCmd.CommandText = Query;
                sqlCmd.CommandType = CommandType.Text;
                sqlCmd.ExecuteNonQuery();
                sqlDA.Fill(dtb);
                return dtb;
                
            }
            catch (SqlException sqlEx)
            {
                return null;
            }
            finally
            {
                conn.Close();
                SqlConnection.ClearAllPools();
            }
        }

        public DbDataReader ExecuteReader(DbTransaction transaction, string command, DbParameter[] parameters)
        {
            SqlCommand cmd = new SqlCommand();
            SqlTransaction trans = (SqlTransaction)transaction;
            PrepareCommand(cmd, trans, CommandType.StoredProcedure, command, ConvertPara(parameters));
            SqlDataReader reader = cmd.ExecuteReader();
            cmd.Parameters.Clear();

            return reader;
        }

        //public DbDataReader ExecuteReader(string connectionString, string command, DbParameter[] parameters)
        //{
        //    DbDataReader result;
        //    SqlConnection conn = new SqlConnection(connectionString);
        //    try
        //    {
        //        conn.Open();
        //        result = ExecuteReader(conn, command, ConvertPara(parameters));
        //    }
        //    catch (Exception ex)
        //    {
        //        throw new Exception(ex.Message, ex);
        //    }

        //    return result;
        //}
        private void test(object sender, EventArgs ee)
        {
            int i = 0;
            i++;
            Console.WriteLine("Dispose:"+DateTime.Now);
        }

        public DataTable RunProcedureGetTable(DbConnection sqlCn, string ProcedureName, ArrayList colParam)
        {
            DataTable dtb = new DataTable();
            SqlCommand sqlCmd = new SqlCommand();
            sqlCmd.CommandTimeout = 0;
            SqlDataAdapter sqlDA = new SqlDataAdapter();
            try
            {
                sqlCmd.Connection = (SqlConnection)sqlCn;
                sqlDA.SelectCommand = sqlCmd;
                sqlCmd.CommandText = ProcedureName;
                sqlCmd.CommandType = CommandType.StoredProcedure;
                if (colParam != null)
                {
                    for (int i = 0; i < colParam.Count; i++)
                        sqlCmd.Parameters.Add((SqlParameter)colParam[i]);
                }

                sqlCmd.ExecuteNonQuery();
                sqlDA.Fill(dtb);
            }
            //catch(SqlException sqlEx) {
            //    strErrorMessage = sqlEx.Message;
            //    intErrorNumber = sqlEx.Number;            
            //}
            finally { }

            sqlDA.Dispose();
            sqlDA = null;
            sqlCmd.Dispose();
            sqlCmd = null;

            return dtb;
        }
        public DbDataReader ExecuteReader(DbConnection connection, string command, DbParameter[] parameters)
        {
            SqlCommand cmd = new SqlCommand();
            SqlConnection conn = (SqlConnection) connection;
            SqlDataReader reader = null;

            if (connection.State == ConnectionState.Open)
            {
                PrepareCommand(cmd, conn, CommandType.StoredProcedure, command,ConvertPara(parameters));
                reader = cmd.ExecuteReader();
                cmd.Parameters.Clear();
            }
            else
            {
                throw new Exception("Connection is not openning");
            }

            return  reader;
        }

        public DbDataReader ExecuteReader(DbConnection connection, string command)
        {
            SqlCommand cmd = new SqlCommand();
            SqlConnection conn = (SqlConnection)connection;
            SqlDataReader reader;

            if (connection.State == ConnectionState.Open)
            {
                //PrepareCommand(cmd, conn, CommandType.StoredProcedure, command, ConvertPara(parameters));
                cmd.CommandText = command;
                cmd.CommandType = CommandType.Text;
                cmd.Connection = (SqlConnection)connection;
                
                reader = cmd.ExecuteReader();
                
            }
            else
            {
                throw new Exception("Connection is not openning");
            }

            return reader;
        }
        
        public DbParameter CreateParameter(string name, object value, bool isOutput)
        {
            SqlParameter result = new SqlParameter(name,value);
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

        public DbParameter CreateParameter(string name, SqlDbType _KieuDuLieu)
        {
            SqlParameter result = new SqlParameter(name, _KieuDuLieu);
            result.Direction = ParameterDirection.Input;
            return result;
        }

        public SqlParameter CreateParam(string _TenThamSo, SqlDbType _KieuDuLieu, object _GiaTri)
        {
            SqlParameter sqlParam = new SqlParameter();
            sqlParam.ParameterName = _TenThamSo;
            sqlParam.SqlDbType = _KieuDuLieu;
            sqlParam.Value = _GiaTri;
            return sqlParam;
        }

        public SqlParameter CreateParamOut(string _TenThamSo, SqlDbType _KieuDuLieu)
        {
            SqlParameter sqlParam = new SqlParameter();
            sqlParam.ParameterName = _TenThamSo;
            sqlParam.SqlDbType = _KieuDuLieu;
            sqlParam.Direction = ParameterDirection.Output;
            return sqlParam;
        }

        public DbTransaction CreateTransaction(string connectionString)
        {
            SqlConnection connection = new SqlConnection(connectionString);
            try
            {
                connection.Open();
                return connection.BeginTransaction();
            }
            catch (Exception e)
            {

                throw e;
            }
            
        }

        public DbConnection CreateConnection(string connectionString)
        {
            return new SqlConnection(connectionString);
        }

        public DbDataAdapter CreateAdpter(string commandString,string connectionString)
        {
            return new SqlDataAdapter(commandString, connectionString);
        }

        #endregion

        #region private

        private void PrepareCommand(SqlCommand command, SqlTransaction transaction, CommandType commandType, String commandText, SqlParameter[] commandParameters)
        {
            if (transaction !=null)
            {
                command.Transaction = transaction;
                command.Connection = transaction.Connection;
            }
            
            command.CommandText = commandText;

            command.CommandType = commandType;
            if (commandParameters != null)
                AttachParameters(command, commandParameters);

            return;
        }
        private void PrepareCommand(SqlCommand command, SqlConnection connection, CommandType commandType, String commandText, SqlParameter[] commandParameters)
        {
            if (connection != null)
            {
                command.Connection = connection;
            }

            command.CommandText = commandText;

            command.CommandType = commandType;
            if (commandParameters != null)
                AttachParameters(command, commandParameters);

            return;
        }
        private void AttachParameters(SqlCommand command, SqlParameter[] parameters)
        {
            if (parameters == null)
            {
                return;
            }
            foreach (SqlParameter parameter in parameters)
            {
                command.Parameters.Add(parameter);
            }
        }
        private SqlParameter[] ConvertPara(DbParameter[] input)
        {
            SqlParameter[] result = null;
            if (input!=null)
            {
                result = new SqlParameter[input.Length];
                for (int i = 0; i < input.Length; i++)
                {
                    result[i] = (SqlParameter) input[i];
                }
            }
            return result;
        }
        #endregion

    }
}
