using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Linq;
using System.Text;
using Entity;
using DataAccess;

namespace SystemManageService
{
    public partial class SYS_CatagoryService 
    {
        public SYS_CatagoryDataAccess _catagoryDataAccess = new SYS_CatagoryDataAccess();

        public int InsertSYS_Catagory(SYS_Catagory sys_catagory, string tableName,string Connection)
        {
            try
            {
                return _catagoryDataAccess.InsertSYS_Catagory(sys_catagory, tableName,Connection);
            }
            catch (Exception ex)
            {
                throw ex;
            }
           
        }

        public int UpdateSYS_Catagory(List<SYS_Catagory> sys_catagories, string tableName, string Connection)
        {

            return _catagoryDataAccess.UpdateSYS_Catagory(sys_catagories, tableName,Connection);
        }

        public void UpdateSYS_Catagory(SYS_Catagory sys_catagory, string tableName,string Connection)
        {

             _catagoryDataAccess.UpdateSYS_Catagory(sys_catagory, tableName,Connection);
        }

        public void DeleteSYS_Catagory(List<SYS_Catagory> sys_catagories, string tableName,string Connection)
        {
            _catagoryDataAccess.DeleteSYS_Catagory(sys_catagories, tableName,Connection);
        }

        public void DeleteSYS_Catagory(SYS_Catagory sys_catagories, string tableName, string Connection)
        {
            _catagoryDataAccess.DeleteSYS_Catagory(sys_catagories, tableName,Connection);
        }

        public SYS_Catagory SelectSYS_Catagory(string sys_CatagoryId, string tableName, string Connection)
        {
            return _catagoryDataAccess.SelectSYS_Catagory(sys_CatagoryId, tableName,Connection);
        }

        public List<SYS_Catagory> SelectAllSYS_Catagory(string tableName,string Connection)
        {
             return _catagoryDataAccess.SelectAllSYS_Catagory(tableName, Connection);
        }


        public int InsertSYS_Catagory(DbTransaction transaction, SYS_Catagory sys_catagory, string tableName)
        {
            throw new NotImplementedException();
        }

        public int UpdateSYS_Catagory(DbTransaction transaction, List<SYS_Catagory> sys_catagories, string tableName)
        {
            throw new NotImplementedException();
        }

        public void UpdateSYS_Catagory(DbTransaction transaction, SYS_Catagory sys_catagory, string tableName)
        {
            throw new NotImplementedException();
        }

        public int DeleteSYS_Catagory(DbTransaction transaction, List<SYS_Catagory> sys_catagories, string tableName)
        {
            throw new NotImplementedException();
        }
    }
}
