using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.Common;
using System.Linq;
using System.Text;
using Entity;
using DataAccess;

namespace SystemManageService
{
    public partial class SYS_CatagoryService
    {
        public List<SYS_Catagory> SelectAllSYS_Catagory(string tableName, DbConnection dbConnection)
        {
            return _catagoryDataAccess.SelectAllSYS_Catagory(tableName, dbConnection);
        }
        public List<SYS_Catagory> SelectSYS_CatagoryByParentID(string ParentID, string tableName, string Connection)
        {
            return _catagoryDataAccess.SelectSYS_CatagoryByParentID(ParentID,tableName, Connection);
        }

        public SYS_Catagory SelectSYS_CatagoryById(int ID, string tableName)
        {
            return _catagoryDataAccess.SelectSYS_CatagoryById(ID, tableName);
        }
        public DataTable SelectSYS_CatagoryById1(int ID, string tableName)
        {
            return _catagoryDataAccess.SelectSYS_CatagoryById1(ID, tableName);
        }

        public SYS_Catagory SelectSYS_CatagoryByName(string Name, string tableName)
        {
            return _catagoryDataAccess.SelectSYS_CatagoryByName(Name, tableName);
        }

        /// <summary>
        /// Sử dụng cho các bảng về VTHCPD
        /// </summary>
        /// <param name="TableNotIn"></param>
        /// <param name="IDDonVi"></param>
        /// <param name="Year"></param>
        /// <param name="ParentID"></param>
        /// <param name="tableName"></param>
        /// <param name="Connection"></param>
        /// <returns></returns>
        public List<SYS_Catagory> SelectSYS_CatagoryByParentIDNotInTable(string TableNotIn, int IDDonVi, int IDChungLoai, int Year, string ParentID, string tableName, string Connection)
        {
            return _catagoryDataAccess.SelectSYS_CatagoryByParentIDNotInTable(TableNotIn, IDDonVi, IDChungLoai, Year, ParentID, tableName, Connection);
        }

        public List<SYS_Catagory> SelectListCombo(string tableName, int ID, string Connection)
        {
            List<SYS_Catagory> lst = _catagoryDataAccess.SelectListCombo(tableName, ID, Connection);
            SYS_Catagory cat = new SYS_Catagory();
               cat.ID = 0;
               cat.Name = "--- Không chọn ---";
               lst.Insert(0,cat);

            return lst;
        }
    }
}
