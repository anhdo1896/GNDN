using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Xml;
using Entity;
using System.Data.Common;
using System.Data.SqlClient;
using Entity;

namespace DataAccess
{
    public partial class SYS_ConfigConnectionDataAccess
    {

        public bool TestConnectSYS_ConfigConnection(SYS_ConfigConnection stringconnect, string mahoa)
        {
            SqlConnection sqlCn = null;
            if (mahoa == "MH")
                sqlCn = new SqlConnection(DecryptSYS_ConfigConnection(stringconnect.connection));
            else
                sqlCn = new SqlConnection(stringconnect.connection);
            bool result = false;
            try
            {
                sqlCn.Open();
                result = true;

            }
            catch (Exception)
            {
                return result;
            }
            finally
            {
                sqlCn.Close();
            }
            return result;
        }

        public string DecryptSYS_ConfigConnection(string connect)
        {
            try
            {
                byte[] keyArray;
                byte[] toEncryptArray = Convert.FromBase64String(connect);
                MD5CryptoServiceProvider hashmd5 = new MD5CryptoServiceProvider();
                keyArray = hashmd5.ComputeHash(UTF8Encoding.UTF8.GetBytes(" "));
                TripleDESCryptoServiceProvider tdes = new TripleDESCryptoServiceProvider();
                tdes.Key = keyArray;
                tdes.Mode = CipherMode.ECB;
                tdes.Padding = PaddingMode.PKCS7;
                ICryptoTransform cTransform = tdes.CreateDecryptor();
                byte[] resultArray = cTransform.TransformFinalBlock(toEncryptArray, 0, toEncryptArray.Length);
                return UTF8Encoding.UTF8.GetString(resultArray);
            }
            catch (Exception ex)
            {
                throw new ArgumentException(String.Format("DecryptSYS_ConfigConnection"));

            }

        }

        public void InsertSYS_ConfigConnection(SYS_ConfigConnection sys_configconnection)
        {
            Common.SetSectionValue("appSettings", "ConnectionInfo", sys_configconnection.connection);
        }

        public string GetSYS_ConfigConnection()
        {
            return Common.GetSectionValue("connectionStrings", "connectionString");
        }
        public string ConnectionString()
        {
            return Common.ConnectionString;
        }

        public string EncryptSYS_ConfigConnection(string connect)
        {
            byte[] keyArray;
            byte[] toEncryptArray = UTF8Encoding.UTF8.GetBytes(connect);
            MD5CryptoServiceProvider hashmd5 = new MD5CryptoServiceProvider();
            keyArray = hashmd5.ComputeHash(UTF8Encoding.UTF8.GetBytes(" "));
            TripleDESCryptoServiceProvider tdes = new TripleDESCryptoServiceProvider();
            tdes.Key = keyArray;
            tdes.Mode = CipherMode.ECB;
            tdes.Padding = PaddingMode.PKCS7;
            ICryptoTransform cTransform = tdes.CreateEncryptor();
            byte[] resultArray = cTransform.TransformFinalBlock(toEncryptArray, 0, toEncryptArray.Length);
            return Convert.ToBase64String(resultArray, 0, resultArray.Length);
        }

        public void SetDefaultConnectString(string connect)
        {
            Common.ConnectionString = DecryptSYS_ConfigConnection(connect);
        }
    }
}