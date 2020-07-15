using System;
using System.Collections;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Data.Common;
using System.Data;

namespace Connection
{
    public interface IDbHelper
    {
        int ExecuteNonQuery(DbTransaction transaction, string command, DbParameter[] parameters);
        int ExecuteNonQuery(string connectionString, string command, DbParameter[] parameters);
        int ExecuteNonQuery(DbConnection connection, string command, DbParameter[] parameters);

        DataTable RunProcedureGet(DbConnection sqlCn, string ProcedureName, ArrayList colParam);
        DataSet RunProcedureGetDataSet(DbConnection sqlCn, string ProcedureName, ArrayList colParam);
        
        bool RunQuery(DbConnection sqlCn, string Query);
        bool RunSQL(DbConnection sqlCn, string Query);
        DbDataReader ExecuteReader(DbTransaction transaction, string command, DbParameter[] parameters);
       // DbDataReader ExecuteReader(string connectionString, string command, DbParameter[] parameters);
        DbDataReader ExecuteReader(DbConnection connection, string command, DbParameter[] parameters);
        DbDataReader ExecuteReader(DbConnection connection, string command);

        DbParameter CreateParameter(string name, object value, bool isOutput);
        DbParameter CreateParameter(string name, SqlDbType _KieuDuLieu);

        SqlParameter CreateParam(string _TenThamSo, SqlDbType _KieuDuLieu, object _GiaTri);
        SqlParameter CreateParamOut(string _TenThamSo, SqlDbType _KieuDuLieu);

        DbTransaction CreateTransaction(string connectionString);
        DbConnection CreateConnection(string connectionString);
        DbDataAdapter CreateAdpter(string commandString, string connectionString);


    } 
}
