using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using DataAccess;
using Entity;
namespace SystemManageService
{
    public partial class SYS_ConfigConnectionServer 
    {
        private SYS_ConfigConnectionDataAccess _sys_configconnectdataaccess = new SYS_ConfigConnectionDataAccess();

        public string EncryptSYS_ConfigConnection(string connect)
        {
            return _sys_configconnectdataaccess.EncryptSYS_ConfigConnection(connect);
        }

        public string ConnectionString()
        {
            return _sys_configconnectdataaccess.ConnectionString();
        }
        
        public void SetDefaultConnectString(string connect )
        {
            
            _sys_configconnectdataaccess.SetDefaultConnectString(connect);
        }

        public Boolean TestConnectSYS_ConfigConnection(SYS_ConfigConnection sys_configconnection,string mahoa)
        {
            return _sys_configconnectdataaccess.TestConnectSYS_ConfigConnection(sys_configconnection,mahoa);
        }

        public string DecryptSYS_ConfigConnection(string connect)
        {
            return _sys_configconnectdataaccess.DecryptSYS_ConfigConnection(connect);
        }

        public void InsertSYS_ConfigConnection(SYS_ConfigConnection sys_configconnection)
        {
            _sys_configconnectdataaccess.InsertSYS_ConfigConnection(sys_configconnection);
        }

        

        public string GetSYS_ConfigConnection()
        {
            return _sys_configconnectdataaccess.GetSYS_ConfigConnection();
        }

    }
}