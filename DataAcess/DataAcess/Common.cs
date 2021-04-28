using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Data.Common;
using System.Configuration;
using System.Text;
using System.Data.SqlClient;
using System.Data;
using Connection;
using Entity;




namespace DataAccess
{
    public static class Common
    {
        private static SYS_ConfigConnectionDataAccess _SYS_ConfigConnectionDataAccess = new SYS_ConfigConnectionDataAccess();
        private static Entity.SYS_ConfigConnection _SYS_ConfigConnection = new SYS_ConfigConnection();
        private static string connectionString = null;


        public static String ConnectionString
        {

            get
            {
                if (connectionString == null)
                {
                    string connect = ConfigurationSettings.AppSettings["ConnectionInfo"];
                    connectionString = connect;
                }
                return connectionString;
            }
            set
            {
                connectionString = value;
            }
        }

        private static MSSqlHelper _dbHelper = new MSSqlHelper();
        public static String DatabaseSchema = "[dbo].";

        public static DbTransaction BeginTransaction()
        {
            DbTransaction tran = _dbHelper.CreateTransaction(ConnectionString);
            return tran;
        }

        public static DbTransaction BeginTransaction(string connectionStrng)
        {
            DbTransaction tran = _dbHelper.CreateTransaction(connectionStrng);
            return tran;
        }

        public static void EndTransaction(DbTransaction sqlTransaction)
        {
            sqlTransaction.Commit();
        }
        public static DbConnection CreateConnection()
        {
            DbConnection connection = _dbHelper.CreateConnection(ConnectionString);
            return connection;
        }
        public static DbDataAdapter CreateAdpter(string commandString)
        {
            DbDataAdapter adapter = _dbHelper.CreateAdpter(commandString, ConnectionString);
            return adapter;
        }
        public static DbDataAdapter CreateAdpter(string commandString, string connect)
        {
            DbDataAdapter adapter = _dbHelper.CreateAdpter(commandString, _SYS_ConfigConnectionDataAccess.DecryptSYS_ConfigConnection(connect));
            return adapter;
        }
        public static DbConnection CreateConnection(string connectionStrng)
        {
            DbConnection connection = _dbHelper.CreateConnection(connectionStrng);
            return connection;
        }

        public static string GetSectionValue(string SectionName, string SettingName)
        {
            string returnValue = null;
            object section = ConfigurationManager.GetSection(SectionName);

            if (section is NameValueCollection)
            {
                //get the value
                returnValue = (string)(section as NameValueCollection).Get(SettingName);

                if (returnValue == null) throw new ConfigurationErrorsException("Unable to open setting \"" + SettingName + "\" in section \"" + SectionName + "\" in config file");
            }
            else if (section is ClientSettingsSection)
            {
                SettingElement item = (section as ClientSettingsSection).Settings.Get(SettingName);
                if (item == null) throw new ConfigurationErrorsException("Unable to open setting \"" + SettingName + "\" in section \"" + SectionName + "\" in config file");

                //get the value
                returnValue = item.Value.ValueXml.InnerText;
            }
            else
            {
                throw (new ConfigurationErrorsException("Unable to open section " + section + " in configuration file"));
            }

            return returnValue;
        }

        public static void SetSectionValue(string SectionName, string SettingName, string value)
        {
            SYS_ConfigConnection.AppSettingsKeys appSettingsKeys = new SYS_ConfigConnection.AppSettingsKeys();
            appSettingsKeys.ConfigName = "ConnectionInfo";
            appSettingsKeys.ConfigValue = value;
            ModifyKey(appSettingsKeys);
            connectionString = _SYS_ConfigConnectionDataAccess.DecryptSYS_ConfigConnection(value);
        }

        public static bool ModifyKey(SYS_ConfigConnection.AppSettingsKeys appSettingsKeys)
        {
            try
            {
                //WebConfigurationManager.OpenWebConfiguration("~");
                Configuration configuration = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);

                AppSettingsSection appSettingsSection = (AppSettingsSection)configuration.GetSection("appSettings");

                if (appSettingsSection != null)
                {

                    appSettingsSection.Settings[appSettingsKeys.ConfigName].Value = appSettingsKeys.ConfigValue;

                    configuration.Save(ConfigurationSaveMode.Modified);

                }


            }
            catch (Exception ex)
            {
                return false;

            }
            return true;

        }

    }

}