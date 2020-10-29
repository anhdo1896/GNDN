using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.OracleClient;
namespace DataAccess
{
    public class ConnectString
    {
        private static string connectionString = null;
        public static String ConnectionString(string ma_dv)
        {
            try
            {
                return @"Data Source=(DESCRIPTION=(ADDRESS_LIST=(ADDRESS=(PROTOCOL=TCP)(HOST=10.21.18.1)(PORT=1522)))(CONNECT_DATA=(SERVER=DEDICATED)(SERVICE_NAME=cmis3)));User Id=PTKH_MTB;Password=ptkh123;";
                //return @"Data Source =(DESCRIPTION =(ADDRESS =(PROTOCOL = TCP)HOST = 10.21.52.1)(PORT = 1522)) (CONNECT_DATA =(SERVER = dedicated)(SERVICE_NAME = CMIS3)));User Id=SUPPORT;Password=SUPPORT_2020;";
            }
            catch
            {
                return null;
            }
        }

    }
}

