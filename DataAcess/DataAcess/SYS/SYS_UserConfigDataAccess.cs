﻿//------------------------------------------------------------------------------------------------------------------------
//-- Generated By:   TrungVK using CodeSmith 5.0.0.0
//-- Template:       DataAcess.cst
//-- Date Generated: Monday, July 05, 2010
//------------------------------------------------------------------------------------------------------------------------
using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Linq;
using System.Text;
using Entity;

namespace DataAccess
{
    public partial class SYS_UserConfigDataAccess
    {
        public SYS_UserConfig SelectByUserID(int UserId)
        {
            DbConnection conn = _DbHelper.CreateConnection(Common.ConnectionString);
            conn.Open();
            SYS_UserConfig userConfig = new SYS_UserConfig();
            DbDataReader reader = null;

            List<DbParameter> para = new List<DbParameter>();
            para.Add(_DbHelper.CreateParameter(FIELD_USERID, UserId, false));
            try
            {
                reader = _DbHelper.ExecuteReader(conn, Common.DatabaseSchema + "[SYS_UserConfig_SelectByUserId]", para.ToArray());
                if (reader.HasRows)
                {

                    while (reader.Read())
                    {
                       SetSYS_UserConfigInfo(reader, ref userConfig);
                    }
                }

                return userConfig;
            }
            catch (Exception ex)
            {
                throw new Exception(String.Format(" SYS_UserConfigDataAccess.SYS_UserConfig_SelectByUserId: {0}", ex.Message));
            }
            finally
            {

                if (reader != null)
                    reader.Close();
                conn.Close();
            }
        }

        public SYS_UserConfig SelectByUserID(int UserId, string connect)
        {
            SYS_ConfigConnectionDataAccess connectionDataAccess = new SYS_ConfigConnectionDataAccess();
            connect = connectionDataAccess.DecryptSYS_ConfigConnection(connect);
            SYS_UserConfig userConfig = new SYS_UserConfig();
            DbDataReader reader = null;
            DbConnection dbConnection = Common.CreateConnection(connect);
            dbConnection.Open();
            List<DbParameter> para = new List<DbParameter>();
            para.Add(_DbHelper.CreateParameter(FIELD_USERID, UserId, false));
            try
            {
                reader = _DbHelper.ExecuteReader(dbConnection, Common.DatabaseSchema + "[SYS_UserConfig_SelectByUserId]", para.ToArray());
                if (reader.HasRows)
                {

                    while (reader.Read())
                    {
                        SetSYS_UserConfigInfo(reader, ref userConfig);
                    }
                }

                return userConfig;
            }
            catch (Exception ex)
            {
                throw new Exception(String.Format(" SYS_UserConfigDataAccess.SYS_UserConfig_SelectByUserId: {0}", ex.Message));
            }
            finally
            {

                if (reader != null)
                    reader.Close();
                dbConnection.Close();
            }
        }

        public SYS_UserConfig SelectByUserID_UserConfigByStrCn(string connect, int UserId)
        {
            SYS_ConfigConnectionDataAccess connectionDataAccess = new SYS_ConfigConnectionDataAccess();
            connect = connectionDataAccess.DecryptSYS_ConfigConnection(connect);
            DbConnection conn = _DbHelper.CreateConnection(connect);
            conn.Open();
            SYS_UserConfig userConfig = new SYS_UserConfig();
            DbDataReader reader = null;

            List<DbParameter> para = new List<DbParameter>();
            para.Add(_DbHelper.CreateParameter(FIELD_USERID, UserId, false));
            try
            {
                reader = _DbHelper.ExecuteReader(conn, Common.DatabaseSchema + "[SYS_UserConfig_SelectByUserId]", para.ToArray());
                if (reader.HasRows)
                {

                    while (reader.Read())
                    {
                       SetSYS_UserConfigInfo(reader, ref userConfig);
                    }
                }

                return userConfig;
            }
            catch (Exception ex)
            {
                throw new Exception(String.Format(" SYS_UserConfigDataAccess.SYS_UserConfig_SelectByUserId: {0}", ex.Message));
            }
            finally
            {

                if (reader != null)
                    reader.Close();
                conn.Close();
            }
        }
    }
}


