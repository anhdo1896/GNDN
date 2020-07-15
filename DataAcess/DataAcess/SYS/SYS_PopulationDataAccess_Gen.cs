using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Linq;
using System.Text;
using Connection;
using Entity;

namespace DataAccess
{
    public partial class SYS_PopulationDataAccess
    {
        private SYS_Population _sys_population;

        private MSSqlHelper _DbHelper = new MSSqlHelper();

        public static string FIELD_ID = "ID";
        public static string FIELD_IDORGANIZATION = "IDOrganization";
        public static string FIELD_TOTAL = "Total";
        public static string FIELD_MALE = "Male";
        public static string FIELD_FEMALE = "Female";


        #region Private methods

        private static void SetSYS_PopulationInfo(DbDataReader reader, ref SYS_Population sys_population)
        {
            sys_population.ID = int.Parse("0" + reader[FIELD_ID]);
            sys_population.IDOrganization = int.Parse("0" + reader[FIELD_IDORGANIZATION]);
            sys_population.Total = int.Parse("0" + reader[FIELD_TOTAL]);
            sys_population.Male = int.Parse("0" + reader[FIELD_MALE]);
            sys_population.Female = int.Parse("0" + reader[FIELD_FEMALE]);
        }

        private static void SetListSYS_PopulationInfo(ref DbDataReader reader, ref List<SYS_Population> sys_populations)
        {
            SYS_Population sys_population = null;
            int count = 0;
            while (reader.Read())
            {
                sys_population = new SYS_Population();
                SYS_PopulationDataAccess.SetSYS_PopulationInfo(reader, ref sys_population);
                sys_population.STT = count + 1;
                sys_populations.Add(sys_population);
            }
        }

        #endregion

        #region Static methods
        #endregion
        public int InsertSYS_Population(SYS_Population sys_population)
        {
            DbConnection conn = _DbHelper.CreateConnection(Common.ConnectionString);
            conn.Open();
            try
            {
                List<DbParameter> para = new List<DbParameter>();
                DbParameter ouput = _DbHelper.CreateParameter(FIELD_ID, DbType.Int32, true);
                para.Add(_DbHelper.CreateParameter(FIELD_IDORGANIZATION, sys_population.IDOrganization, false));
                para.Add(_DbHelper.CreateParameter(FIELD_TOTAL, sys_population.Total, false));
                para.Add(_DbHelper.CreateParameter(FIELD_MALE, sys_population.Male, false));
                para.Add(_DbHelper.CreateParameter(FIELD_FEMALE, sys_population.Female, false));
                para.Add(ouput);
                _DbHelper.ExecuteReader(conn, Common.DatabaseSchema + "[SYS_Population_Insert]", para.ToArray());
                return (int)ouput.Value;
            }
            catch (Exception ex)
            {
                throw new Exception(String.Format("SYS_PopulationDataAccess.Insert: {0}", ex.Message));
            }
            finally
            {
                conn.Close();
            }
        }

        public int UpdateSYS_Population(List<SYS_Population> sys_populations)
        {
            DbConnection conn = _DbHelper.CreateConnection(Common.ConnectionString);
            conn.Open();
            int count = 0;
            try
            {

                foreach (SYS_Population sys_population in sys_populations)
                {
                    List<DbParameter> para = new List<DbParameter>();

                    para.Add(_DbHelper.CreateParameter(FIELD_ID, sys_population.ID, false));
                    para.Add(_DbHelper.CreateParameter(FIELD_IDORGANIZATION, sys_population.IDOrganization, false));
                    para.Add(_DbHelper.CreateParameter(FIELD_TOTAL, sys_population.Total, false));
                    para.Add(_DbHelper.CreateParameter(FIELD_MALE, sys_population.Male, false));
                    para.Add(_DbHelper.CreateParameter(FIELD_FEMALE, sys_population.Female, false));

                    _DbHelper.ExecuteNonQuery(conn, Common.DatabaseSchema + "[sys_population_Update]", para.ToArray());
                    count++;
                }
            }
            catch (Exception ex)
            {
                throw new Exception(String.Format("SYS_PopulationDataAccess.Update: {0}", ex.Message));
            }
            finally
            {
                conn.Close();
            }
            return count;
        }

        public void UpdateSYS_Population(SYS_Population sys_population)
        {
            DbConnection conn = _DbHelper.CreateConnection(Common.ConnectionString);
            conn.Open();
            try
            {
                List<DbParameter> para = new List<DbParameter>();

                para.Add(_DbHelper.CreateParameter(FIELD_ID, sys_population.ID, false));
                para.Add(_DbHelper.CreateParameter(FIELD_IDORGANIZATION, sys_population.IDOrganization, false));
                para.Add(_DbHelper.CreateParameter(FIELD_TOTAL, sys_population.Total, false));
                para.Add(_DbHelper.CreateParameter(FIELD_MALE, sys_population.Male, false));
                para.Add(_DbHelper.CreateParameter(FIELD_FEMALE, sys_population.Female, false));

                _DbHelper.ExecuteReader(conn, Common.DatabaseSchema + "[SYS_Population_Update]", para.ToArray());

            }
            catch (Exception ex)
            {
                throw new Exception(String.Format("SYS_PopulationDataAccess.Update: {0}", ex.Message));
            }
            finally
            {
                conn.Close();
            }
        }

        public void DeleteSYS_Population(List<SYS_Population> sys_populations)
        {
            DbConnection conn = _DbHelper.CreateConnection(Common.ConnectionString);
            conn.Open();
            List<DbParameter> para = new List<DbParameter>();

            try
            {

                foreach (SYS_Population sys_population in sys_populations)
                {

                    para.Add(_DbHelper.CreateParameter(FIELD_ID, sys_population.ID, false));

                    _DbHelper.ExecuteNonQuery(conn, Common.DatabaseSchema + "[SYS_Population_Delete]", para.ToArray());
                    para.Clear();
                }
            }
            catch (Exception ex)
            {
                throw new Exception(String.Format("SYS_PopulationDataAccess.Delete: {0}", ex.Message));
            }
            finally
            {
                conn.Close();
            }
        }

        public void DeleteSYS_Population(SYS_Population sys_population)
        {
            DbConnection conn = _DbHelper.CreateConnection(Common.ConnectionString);
            conn.Open();
            try
            {
                List<DbParameter> para = new List<DbParameter>();
                para.Add(_DbHelper.CreateParameter(FIELD_ID, sys_population.ID, false));
                _DbHelper.ExecuteReader(conn, Common.DatabaseSchema + "[SYS_Population_Delete]", para.ToArray());
            }
            catch (Exception)
            {


                throw;
            }
            finally
            { conn.Close(); }

        }

        public SYS_Population SelectSYS_Population(int ID)
        {

            SYS_Population sys_population = new SYS_Population();
            DbDataReader reader = null;
            DbConnection conn = _DbHelper.CreateConnection(Common.ConnectionString);
            conn.Open();
            try
            {
                List<DbParameter> para = new List<DbParameter>();
                para.Add(_DbHelper.CreateParameter(FIELD_ID, ID, false));

                reader = _DbHelper.ExecuteReader(conn, Common.DatabaseSchema + "[SYS_Population_SelectById]", para.ToArray());
                if (reader.HasRows && reader.Read())
                    SYS_PopulationDataAccess.SetSYS_PopulationInfo(reader, ref sys_population);
                return sys_population;
            }
            catch (Exception ex)
            {
                throw new Exception(String.Format("SYS_PopulationDataAccess.SelectById: {0}", ex.Message));
            }
            finally
            {
                if (reader != null)
                    reader.Close();
                conn.Close();
            }

        }


        public List<SYS_Population> SelectAllSYS_Population()
        {
            List<SYS_Population> sys_population = new List<SYS_Population>();
            DbDataReader reader = null;
            DbConnection conn = _DbHelper.CreateConnection(Common.ConnectionString);
            conn.Open();
            try
            {
                reader = _DbHelper.ExecuteReader(conn, Common.DatabaseSchema + "[SYS_Population_SelectAll]", (DbParameter[])null);
                if (reader.HasRows)
                    SYS_PopulationDataAccess.SetListSYS_PopulationInfo(ref reader, ref sys_population);
                return sys_population;
            }
            catch (Exception ex)
            {
                throw new Exception(String.Format(" SYS_PopulationDataAccess.SelectAll: {0}", ex.Message));
            }
            finally
            {
                if (reader != null)
                    reader.Close();
                conn.Close();
            }
        }

        public int InsertSYS_Population(DbTransaction transaction, SYS_Population sys_population)
        {
            try
            {
                List<DbParameter> para = new List<DbParameter>();

                DbParameter ouput = _DbHelper.CreateParameter(FIELD_ID, DbType.Int32, true);
                para.Add(_DbHelper.CreateParameter(FIELD_IDORGANIZATION, sys_population.IDOrganization, false));
                para.Add(_DbHelper.CreateParameter(FIELD_TOTAL, sys_population.Total, false));
                para.Add(_DbHelper.CreateParameter(FIELD_MALE, sys_population.Male, false));
                para.Add(_DbHelper.CreateParameter(FIELD_FEMALE, sys_population.Female, false));

                para.Add(ouput);

                _DbHelper.ExecuteNonQuery(transaction, Common.DatabaseSchema + "[SYS_Population_Insert]", para.ToArray());

                return (int)ouput.Value;
            }
            catch (Exception ex)
            {
                throw new Exception(String.Format("SYS_PopulationDataAccess.Insert: {0}", ex.Message));
            }
        }



        public int UpdateSYS_Population(DbTransaction transaction, List<SYS_Population> sys_populations)
        {

            int count = 0;
            try
            {

                foreach (SYS_Population sys_population in sys_populations)
                {
                    List<DbParameter> para = new List<DbParameter>();

                    para.Add(_DbHelper.CreateParameter(FIELD_ID, sys_population.ID, false));
                    para.Add(_DbHelper.CreateParameter(FIELD_IDORGANIZATION, sys_population.IDOrganization, false));
                    para.Add(_DbHelper.CreateParameter(FIELD_TOTAL, sys_population.Total, false));
                    para.Add(_DbHelper.CreateParameter(FIELD_MALE, sys_population.Male, false));
                    para.Add(_DbHelper.CreateParameter(FIELD_FEMALE, sys_population.Female, false));

                    _DbHelper.ExecuteNonQuery(transaction, Common.DatabaseSchema + "[SYS_Population_Update]", para.ToArray());
                    count++;
                }
            }

            catch (Exception ex)
            {
                throw new Exception(String.Format("SYS_PopulationDataAccess.Update: {0}", ex.Message));
            }

            return count;
        }

        public void UpdateSYS_Population(DbTransaction transaction, SYS_Population sys_population)
        {
            try
            {
                List<DbParameter> para = new List<DbParameter>();

                para.Add(_DbHelper.CreateParameter(FIELD_ID, sys_population.ID, false));
                para.Add(_DbHelper.CreateParameter(FIELD_IDORGANIZATION, sys_population.IDOrganization, false));
                para.Add(_DbHelper.CreateParameter(FIELD_TOTAL, sys_population.Total, false));
                para.Add(_DbHelper.CreateParameter(FIELD_MALE, sys_population.Male, false));
                para.Add(_DbHelper.CreateParameter(FIELD_FEMALE, sys_population.Female, false));

                _DbHelper.ExecuteNonQuery(transaction, Common.DatabaseSchema + "[SYS_Population_Update]", para.ToArray());

            }
            catch (Exception ex)
            {
                throw new Exception(String.Format("SYS_PopulationDataAccess.Update: {0}", ex.Message));
            }
        }

        public int DeleteSYS_Population(DbTransaction transaction, List<SYS_Population> sys_populations)
        {
            int count = 0;
            try
            {
                List<DbParameter> para = new List<DbParameter>();
                foreach (SYS_Population sys_population in sys_populations)
                {
                    para.Add(_DbHelper.CreateParameter(FIELD_ID, DbType.Int32, false));

                    _DbHelper.ExecuteNonQuery(transaction, Common.DatabaseSchema + "[SYS_Population_Delete]", para.ToArray());
                    para.Clear();
                    count++;
                }
            }
            catch (Exception ex)
            {
                throw new Exception(String.Format("SYS_PopulationDataAccess.Delete: {0}", ex.Message));
            }

            return count;
        }
    }
}
