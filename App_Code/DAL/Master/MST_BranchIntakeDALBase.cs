using GNForm3C.DAL;
using Microsoft.Practices.EnterpriseLibrary.Data;
using Microsoft.Practices.EnterpriseLibrary.Data.Sql;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace GNForm3C
{
    public class MST_BranchIntakeDALBase : DataBaseConfig
    {
        #region Properties

        private string _Message;
        public string Message
        {
            get
            {
                return _Message;
            }
            set
            {
                _Message = value;
            }
        }

        #endregion Properties

        #region Constructor

        public MST_BranchIntakeDALBase()
        {
            //
            // TODO: Add constructor logic here
            //
        }

        #endregion Constructor

        #region GetBranchIntake Data

        public DataTable GetBranchIntakeData()
        {
            try
            {
                SqlDatabase sqlDB = new SqlDatabase(myConnectionString);
                DbCommand dbCMD = sqlDB.GetStoredProcCommand("PR_MST_BranchIntake_SelectAll");
                DataSet ds = sqlDB.ExecuteDataSet(dbCMD);
                DataTable dt = ds.Tables[0];
                return dt;
            }
            catch (SqlException sqlex)
            {
                Message = SQLDataExceptionMessage(sqlex);
                if (SQLDataExceptionHandler(sqlex))
                    throw;
                return null;
            }
            catch (Exception ex)
            {
                Message = ExceptionMessage(ex);
                if (ExceptionHandler(ex))
                    throw;
                return null;
            }
        }

        #endregion GetBranchIntake DATA

        #region SaveBranchIntake Data
        public bool SaveBranchIntakeData(DataTable branchIntakeTable)
        {
            try
            {
                SqlDatabase sqlDB = new SqlDatabase(myConnectionString);
                DbCommand dbCMD = sqlDB.GetStoredProcCommand("PR_MST_BranchIntake_InsertUpdate");

                SqlParameter tvpParam = new SqlParameter
                {
                    ParameterName = "@BranchIntakeData",
                    SqlDbType = SqlDbType.Structured,
                    Value = branchIntakeTable,
                    TypeName = "dbo.BranchIntakeType"
                };
                dbCMD.Parameters.Add(tvpParam);

                sqlDB.ExecuteNonQuery(dbCMD);
                return true;
            }
            catch (SqlException sqlex)
            {
                Message = SQLDataExceptionMessage(sqlex);
                if (SQLDataExceptionHandler(sqlex))
                    throw;
                return false;
            }
            catch (Exception ex)
            {
                Message = ExceptionMessage(ex);
                if (ExceptionHandler(ex))
                    throw;
                return false;
            }
        }
      
        #endregion SaveBranchIntake Data

        #region Delete BranchIntake Data
        public Boolean DeleteBranchIntakeData(string branch)
        {
            try
            {
                // Initialize the SqlDatabase object with the connection string
                SqlDatabase sqlDB = new SqlDatabase(myConnectionString);

                // Create a command object with the stored procedure name
                DbCommand dbCMD = sqlDB.GetStoredProcCommand("PR_MST_BranchIntake_Delete");

                // Add the branch parameter to the command
                sqlDB.AddInParameter(dbCMD, "@Branch", SqlDbType.NVarChar, branch);

                // Initialize the helper class for database operations
                DataBaseHelper DBH = new DataBaseHelper();

                // Execute the command
                DBH.ExecuteNonQuery(sqlDB, dbCMD);

                return true;
            }
            catch (SqlException sqlex)
            {
                // Handle SQL exceptions
                Message = SQLDataExceptionMessage(sqlex);
                if (SQLDataExceptionHandler(sqlex))
                    throw;
                return false;
            }
            catch (Exception ex)
            {
                // Handle general exceptions
                Message = ExceptionMessage(ex);
                if (ExceptionHandler(ex))
                    throw;
                return false;
            }
        }

        #endregion Delete BranchIntake Data

    }
}