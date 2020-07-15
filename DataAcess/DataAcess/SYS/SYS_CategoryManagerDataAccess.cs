using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Linq;
using System.Text;
using Connection;
using Entity;

namespace DataAccess
{
    public partial class SYS_CategoryManagerDataAccess 
    {
        SYS_ConfigConnectionDataAccess sysConfigConnection = new SYS_ConfigConnectionDataAccess();

        public bool RunQuery(string Query, string Connection)
        {
            DbConnection sqlCn = Common.CreateConnection(Connection);
            sqlCn.Open();
            MSSqlHelper msSqlHelper = new MSSqlHelper();
            try
            {
                return msSqlHelper.RunQuery(sqlCn, Query);
            }
            catch (Exception ex)
            {
                throw new Exception(String.Format("SYS_CategoryManager RunQuery: {0}", ex.Message));
            }
            finally
            {
                sqlCn.Close();
            }
        }


        private static void SetListSYS_CategoryManagerInfoAddColumnCategory(ref DbDataReader reader, ref List<SYS_CategoryManager> sys_categorymanagers)
        {
            SYS_CategoryManager sys_categorymanager = null;
            SYS_ColumnCategoryDataAccess sysColumnCategoryDataAccess=new SYS_ColumnCategoryDataAccess();
            while (reader.Read())
            {
                sys_categorymanager = new SYS_CategoryManager();
                SYS_CategoryManagerDataAccess.SetSYS_CategoryManagerInfo(reader, ref sys_categorymanager);
                sys_categorymanager.LstColumnCategory =sysColumnCategoryDataAccess.SelectAllSYS_ColumnCategoryByIDCategoryManager(sys_categorymanager.ID);
                sys_categorymanagers.Add(sys_categorymanager);
            }
        }
    }
}
