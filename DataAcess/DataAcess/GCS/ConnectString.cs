using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.OracleClient;
using System.Security.Cryptography;
namespace DataAccess
{
    public class ConnectString
    {
        private static string connectionString = null;
        private static string strPath = "C:\\NPCUSConfig\\Servers.xml";
        public static String ConnectionString(string ma_dv)
        {
            try
            {
                return ReadConfig();
            }
            catch
            {
                return null;
            }
        }
        public static String ConnectionString2(string ma_dv)
        {
            try
            {
                return ReadConfig2();
            }
            catch
            {
                return null;
            }
        }


        protected static string ReadConfig()
        {
            try
            {
                var path = System.Web.HttpContext.Current.Server.MapPath("~/config.xml");
                var dataSet = new DataSet();
                dataSet.ReadXml(path);
                if (dataSet.Tables.Count <= 0)
                {
                    return "";
                }
                var table = dataSet.Tables[0];
                if (table.Rows.Count <= 0)
                {
                    return "";
                }
                string chuoi = table.Rows[0]["ConnectString"] + "";
                return chuoi;


            }
            catch (Exception exception)
            {
                //lbThongBao.Text = @"Đọc file lỗi: " + exception.Message;
                return "";
            }
        }
        protected static string ReadConfig2()
        {
            try
            {
                var path = System.Web.HttpContext.Current.Server.MapPath("~/config.xml");
                var dataSet = new DataSet();
                dataSet.ReadXml(path);
                if (dataSet.Tables.Count <= 0)
                {
                    return "";
                }
                var table = dataSet.Tables[0];
                if (table.Rows.Count <= 0)
                {
                    return "";
                }
                string chuoi = table.Rows[0]["ConnectString_2"] + "";
                return chuoi;


            }
            catch (Exception exception)
            {
                //lbThongBao.Text = @"Đọc file lỗi: " + exception.Message;
                return "";
            }
        }
        public static string DecryptSYS_ConfigConnection(string connect)
        {
            try
            {
                var toEncryptArray = Convert.FromBase64String(connect);
                var hashmd5 = new MD5CryptoServiceProvider();
                var keyArray = hashmd5.ComputeHash(Encoding.UTF8.GetBytes(" "));
                var tdes = new TripleDESCryptoServiceProvider
                {
                    Key = keyArray,
                    Mode = CipherMode.ECB,
                    Padding = PaddingMode.PKCS7
                };
                var cTransform = tdes.CreateDecryptor();
                var resultArray = cTransform.TransformFinalBlock(toEncryptArray, 0, toEncryptArray.Length);
                return Encoding.UTF8.GetString(resultArray);
            }
            catch (Exception ex)
            {
                throw new ArgumentException(String.Format("DecryptSYS_ConfigConnection"));
            }

        }

    }
}

