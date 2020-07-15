using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Linq;
using System.Text;
using Entity;

namespace DataAccess
{
    public partial class SYS_ColumnCategoryDataAccess
    {

        public List<SYS_ColumnCategory> SelectAllSYS_ColumnCategoryByIDCategoryManager(int IDCategoryManager)
        {
            List<SYS_ColumnCategory> sys_columncategory = new List<SYS_ColumnCategory>();
            DbDataReader reader = null;
            DbConnection conn = _DbHelper.CreateConnection(Common.ConnectionString);
            conn.Open();
            try
            {
                List<DbParameter> para = new List<DbParameter>();
                para.Add(_DbHelper.CreateParameter(FIELD_IDCATEGORYMANAGER, IDCategoryManager, false));
                reader = _DbHelper.ExecuteReader(conn, Common.DatabaseSchema + "[SYS_SYS_ColumnCategory_SelectByIDCategoryManager]", para.ToArray());
                if (reader.HasRows)
                    SYS_ColumnCategoryDataAccess.SetListSYS_ColumnCategoryInfo(ref reader, ref sys_columncategory);
                return sys_columncategory;
            }
            catch (Exception ex)
            {
                throw new Exception(String.Format(" SYS_ColumnCategoryDataAccess.SelectAll: {0}", ex.Message));
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
