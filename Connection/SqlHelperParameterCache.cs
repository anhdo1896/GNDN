using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Xml;

namespace Connection
{
    public sealed class SqlHelperParameterCache
    {
        #region Private methods, variables, and constructors

        private static Hashtable paramCache = Hashtable.Synchronized(new Hashtable());

        private SqlHelperParameterCache()
        { }

        /// <summary>
        /// resolve at run time the appropriate set of SqlParameters for a stored procedure
        /// </summary>
        /// <param name="connectionString">a valid connection string for a SqlConnection</param>
        /// <param name="storedProcedureName">the name of the stored procedure</param>
        /// <param name="includeReturnValueParameter">whether or not to include their return value parameter</param>
        private static SqlParameter[] DiscoverStoredProcedureParameterSet(String connectionString, String storedProcedureName, Boolean includeReturnValueParameter)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                using (SqlCommand cmd = new SqlCommand(storedProcedureName, connection))
                {
                    connection.Open();
                    cmd.CommandType = CommandType.StoredProcedure;

                    SqlCommandBuilder.DeriveParameters(cmd);
                    if (!includeReturnValueParameter)
                        cmd.Parameters.RemoveAt(0);

                    SqlParameter[] discoveredParameters = new SqlParameter[cmd.Parameters.Count];
                    cmd.Parameters.CopyTo(discoveredParameters, 0);

                    return discoveredParameters;
                }
            }
        }

        /// <summary>
        /// deep copy of cached SqlParameter array
        /// </summary>
        /// <param name="originalParameters">original parameter array</param>
        private static SqlParameter[] CloneParameters(SqlParameter[] originalParameters)
        {
            SqlParameter[] clonedParameters = new SqlParameter[originalParameters.Length];
            for (Int32 i = 0, j = originalParameters.Length; i < j; i++)
                clonedParameters[i] = (SqlParameter)((ICloneable)originalParameters[i]).Clone();

            return clonedParameters;
        }

        #endregion

        #region Caching functions

        /// <summary>
        /// add parameter array to the cache
        /// </summary>
        /// <param name="connectionString">a valid connection string for a SqlConnection</param>
        /// <param name="commandText">the stored procedure name or T-SQL command</param>
        /// <param name="commandParameters">an array of SqlParamters to be cached</param>
        public static void CacheParameterSet(String connectionString, String commandText, params SqlParameter[] commandParameters)
        {
            String hashKey = connectionString + ":" + commandText;
            paramCache[hashKey] = commandParameters;
        }

        /// <summary>
        /// retrieve a parameter array from the cache
        /// </summary>
        /// <param name="connectionString">a valid connection string for a SqlConnection</param>
        /// <param name="commandText">the stored procedure name or T-SQL command</param>
        /// <returns>an array of SqlParamters</returns>
        public static SqlParameter[] GetCachedParameterSet(String connectionString, String commandText)
        {
            String hashKey = connectionString + ":" + commandText;
            SqlParameter[] cachedParameters = (SqlParameter[])paramCache[hashKey];

            if (cachedParameters == null)
                return null;
            else
                return CloneParameters(cachedParameters);
        }

        #endregion

        #region Parameter discovery functions

        /// <summary>
        /// Retrieves the set of SqlParameters appropriate for the stored procedure
        /// </summary>
        /// <remarks>
        /// This method will query the database for this information, and then store it in a cache for future requests.
        /// </remarks>
        /// <param name="connectionString">a valid connection string for a SqlConnection</param>
        /// <param name="spName">the name of the stored procedure</param>
        /// <returns>an array of SqlParameters</returns>
        public static SqlParameter[] GetStoredProcedureParameterSet(String connectionString, String storedProcedureName)
        {
            return GetStoredProcedureParameterSet(connectionString, storedProcedureName, false);
        }

        /// <summary>
        /// Retrieves the set of SqlParameters appropriate for the stored procedure
        /// </summary>
        /// <remarks>
        /// This method will query the database for this information, and then store it in a cache for future requests.
        /// </remarks>
        /// <param name="connectionString">a valid connection string for a SqlConnection</param>
        /// <param name="spName">the name of the stored procedure</param>
        /// <param name="includeReturnValueParameter">a bool value indicating whether the return value parameter should be included in the results</param>
        /// <returns>an array of SqlParameters</returns>
        public static SqlParameter[] GetStoredProcedureParameterSet(String connectionString, String storedProcedureName, Boolean includeReturnValueParameter)
        {
            String hashKey = connectionString + ":" + storedProcedureName + (includeReturnValueParameter ? ":include ReturnValue Parameter" : String.Empty);
            SqlParameter[] cachedParameters;
            cachedParameters = (SqlParameter[])paramCache[hashKey];

            if (cachedParameters == null)
                cachedParameters = (SqlParameter[])(paramCache[hashKey] = SqlHelperParameterCache.DiscoverStoredProcedureParameterSet(connectionString, storedProcedureName, includeReturnValueParameter));

            return SqlHelperParameterCache.CloneParameters(cachedParameters);
        }

        #endregion
    }
}
