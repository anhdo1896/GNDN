//------------------------------------------------------------------------------------------------------------------------
//-- Generated By:   TrungVK using CodeSmith 4.0.0.0
//-- Template:       DataAcess.cst
//-- Date Generated: Friday, September 19, 2014
//------------------------------------------------------------------------------------------------------------------------
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Linq;
using System.Text;
using Connection;
using Entity;
using System.ComponentModel;
namespace DataAccess
{
    public partial class DM_MODULEDataAccess
    {
        public DM_MODULE DM_MODULE_Select_BYIDMADV(int IDMA_DVIQLY)
        {

            DM_MODULE dm_module = new DM_MODULE();
            DbDataReader reader = null;
            DbConnection conn = _DbHelper.CreateConnection(Common.ConnectionString);
            conn.Open();
            try
            {
                List<DbParameter> para = new List<DbParameter>();
                para.Add(_DbHelper.CreateParameter(FIELD_IDMA_DVIQLY, IDMA_DVIQLY, false));

                reader = _DbHelper.ExecuteReader(conn, Common.DatabaseSchema + "[DM_MODULE_Select_BYIDMADV]", para.ToArray());
                if (reader.HasRows && reader.Read())
                    DM_MODULEDataAccess.SetDM_MODULEInfo(reader, ref dm_module);
                return dm_module;
            }
            catch (Exception ex)
            {
                throw new Exception(String.Format("DM_MODULEDataAccess.SelectById: {0}", ex.Message));
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


