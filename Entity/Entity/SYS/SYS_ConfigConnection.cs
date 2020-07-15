using System;
using System.Collections.Generic;
using System.Security.Cryptography;
using System.Text;

namespace Entity
{
    public partial class SYS_ConfigConnection
    {
        #region private

        private string _encrypt;
        private string _decrypt;
        private string _connection;

        private string _connect;
        private string _key;
        private bool _useHashing;

        #endregion

        #region public
        public string connect
        {
            get { return _connect; }
            set { _connect = value; }
        }

        public string key
        {
            get { return _key; }
            set { _key = value; }
        }

        public bool useHashing
        {
            get { return _useHashing; }
            set { _useHashing = value; }
        }
        
        public string encrypt
        {
            get { return _encrypt; }
            set { _encrypt = value; }
        }

        public string connection
        {
            get { return _connection; }
            set { _connection = value; }
        }

        public string decrypt
        {
            get { return _decrypt; }
            set { _decrypt = value; }
        }
        public class AppSettingsKeys
        {
            private int _configID;
            private string _configName;
            private string _configValue;


            public int ConfigID
            {
                get { return _configID; }
                set { _configID = value; }
            }
            public string ConfigName
            {
                get { return _configName; }
                set { _configName = value; }
            }
            public string ConfigValue
            {
                get { return _configValue; }
                set { _configValue = value; }
            }

            public AppSettingsKeys()
            {

                _configID = 0;
                _configName = string.Empty;
                _configValue = string.Empty;

            }

            public void SetInfo(int id, string configName, string configValue)
            {
                this._configID = id;
                this._configName = configName;
                this._configValue = configValue;
            }
        }
        

        #endregion
    }
}