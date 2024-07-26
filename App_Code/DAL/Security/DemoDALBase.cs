using GNForm3C.ENT;
using Microsoft.Practices.EnterpriseLibrary.Data.Sql;
using System;
using System.Data;
using System.Data.Common;
using System.Data.SqlClient;
using System.Data.SqlTypes;

namespace GNForm3C.DAL
{
    public abstract class DemoDALBase : DataBaseConfig
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

        public DemoDALBase()
        {

        }

        #endregion Constructor

        #region InsertOperation

        public Boolean Insert(DemoENT entDemo)
        {
            try
            {
                SqlDatabase sqlDB = new SqlDatabase(myConnectionString);
                DbCommand dbCMD = sqlDB.GetStoredProcCommand("PR_Demo_Table_Insert");

                //sqlDB.AddOutParameter(dbCMD, "@DemoID", SqlDbType.Int, 4);
                sqlDB.AddInParameter(dbCMD, "@DemoName", SqlDbType.NVarChar, entDemo.DemoName);
                sqlDB.AddInParameter(dbCMD, "@UserID", SqlDbType.Int, entDemo.UserID);
                sqlDB.AddInParameter(dbCMD, "@Created", SqlDbType.DateTime, entDemo.Created);
                sqlDB.AddInParameter(dbCMD, "@Modified", SqlDbType.DateTime, entDemo.Modified);

                DataBaseHelper DBH = new DataBaseHelper();
                DBH.ExecuteNonQuery(sqlDB, dbCMD);

                //entDemo.DemoID = (SqlInt32)Convert.ToInt32(dbCMD.Parameters["@DemoID"].Value);

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

        #endregion InsertOperation

        #region UpdateOperation

        public Boolean Update(DemoENT entDemo)
        {
            try
            {
                SqlDatabase sqlDB = new SqlDatabase(myConnectionString);
                DbCommand dbCMD = sqlDB.GetStoredProcCommand("PR_Demo_Table_Update");

                sqlDB.AddInParameter(dbCMD, "@DemoID", SqlDbType.Int, entDemo.DemoID);
                sqlDB.AddInParameter(dbCMD, "@DemoName", SqlDbType.NVarChar, entDemo.DemoName);
                sqlDB.AddInParameter(dbCMD, "@UserID", SqlDbType.Int, entDemo.UserID);
                sqlDB.AddInParameter(dbCMD, "@Created", SqlDbType.DateTime, entDemo.Created);
                sqlDB.AddInParameter(dbCMD, "@Modified", SqlDbType.DateTime, entDemo.Modified);

                DataBaseHelper DBH = new DataBaseHelper();
                DBH.ExecuteNonQuery(sqlDB, dbCMD);

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

        #endregion UpdateOperation

        #region DeleteOperation

        public Boolean Delete(SqlInt32 DemoID)
        {
            try
            {
                SqlDatabase sqlDB = new SqlDatabase(myConnectionString);
                DbCommand dbCMD = sqlDB.GetStoredProcCommand("PR_Demo_Table_Delete");

                sqlDB.AddInParameter(dbCMD, "@DemoID", SqlDbType.Int, DemoID);

                DataBaseHelper DBH = new DataBaseHelper();
                DBH.ExecuteNonQuery(sqlDB, dbCMD);

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

        #endregion DeleteOperation

        #region SelectOperation

        public DemoENT SelectPK(SqlInt32 DemoID)
        {
            try
            {
                SqlDatabase sqlDB = new SqlDatabase(myConnectionString);
                DbCommand dbCMD = sqlDB.GetStoredProcCommand("PR_Demo_Table_SelectPK");

                sqlDB.AddInParameter(dbCMD, "@DemoID", SqlDbType.Int, DemoID);

                DemoENT entDemo = new DemoENT();
                DataBaseHelper DBH = new DataBaseHelper();
                using (IDataReader dr = DBH.ExecuteReader(sqlDB, dbCMD))
                {
                    while (dr.Read())
                    {
                        if (!dr["DemoID"].Equals(System.DBNull.Value))
                            entDemo.DemoID = Convert.ToInt32(dr["DemoID"]);

                        
                        if (!dr["DemoName"].Equals(System.DBNull.Value))
                            entDemo.DemoName = Convert.ToString(dr["DemoName"]);

                        if (!dr["UserID"].Equals(System.DBNull.Value))
                            entDemo.UserID = Convert.ToInt32(dr["UserID"]);

                        if (!dr["Created"].Equals(System.DBNull.Value))
                            entDemo.Created = Convert.ToDateTime(dr["Created"]);

                        if (!dr["Modified"].Equals(System.DBNull.Value))
                            entDemo.Modified = Convert.ToDateTime(dr["Modified"]);

                    }
                }
                return entDemo;
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
        public DataTable SelectView(SqlInt32 DemoID)
        {
            try
            {
                SqlDatabase sqlDB = new SqlDatabase(myConnectionString);
                DbCommand dbCMD = sqlDB.GetStoredProcCommand("PR_Demo_Table_SelectView");

                sqlDB.AddInParameter(dbCMD, "@DemoID", SqlDbType.Int, DemoID);

                DataTable dtDemo = new DataTable("PR_Demo_Table_SelectView");

                DataBaseHelper DBH = new DataBaseHelper();
                DBH.LoadDataTable(sqlDB, dbCMD, dtDemo);

                return dtDemo;
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
        public DataTable SelectAll()
        {
            try
            {
                SqlDatabase sqlDB = new SqlDatabase(myConnectionString);
                DbCommand dbCMD = sqlDB.GetStoredProcCommand("PR_Demo_Table_SelectAll");

                DataTable dtDemo = new DataTable("PR_Demo_Table_SelectAll");

                DataBaseHelper DBH = new DataBaseHelper();
                DBH.LoadDataTable(sqlDB, dbCMD, dtDemo);

                return dtDemo;
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
        public DataTable SelectPage(SqlInt32 PageOffset, SqlInt32 PageSize, out Int32 TotalRecords, SqlString DemoName )
        {
            TotalRecords = 0;
            try
            {
                SqlDatabase sqlDB = new SqlDatabase(myConnectionString);
                DbCommand dbCMD = sqlDB.GetStoredProcCommand("PR_Demo_Table_SelectPage");
                sqlDB.AddInParameter(dbCMD, "@PageOffset", SqlDbType.Int, PageOffset);
                sqlDB.AddInParameter(dbCMD, "@PageSize", SqlDbType.Int, PageSize);
                sqlDB.AddOutParameter(dbCMD, "@TotalRecords", SqlDbType.Int, 4);
                sqlDB.AddInParameter(dbCMD, "@DemoName", SqlDbType.NVarChar, DemoName);
             

                DataTable dtDemo = new DataTable("PR_Demo_Table_SelectPage");

                DataBaseHelper DBH = new DataBaseHelper();
                DBH.LoadDataTable(sqlDB, dbCMD, dtDemo);

                TotalRecords = Convert.ToInt32(dbCMD.Parameters["@TotalRecords"].Value);

                return dtDemo;
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

        #endregion SelectOperation

        #region ComboBox

        //public DataTable SelectComboBox()
        //{
        //    try
        //    {
        //        SqlDatabase sqlDB = new SqlDatabase(myConnectionString);
        //        DbCommand dbCMD = sqlDB.GetStoredProcCommand("PR_MST_Hospital_SelectComboBox");

        //        DataTable dtMST_Hospital = new DataTable("PR_MST_Hospital_SelectComboBox");

        //        DataBaseHelper DBH = new DataBaseHelper();
        //        DBH.LoadDataTable(sqlDB, dbCMD, dtMST_Hospital);

        //        return dtMST_Hospital;
        //    }
        //    catch (SqlException sqlex)
        //    {
        //        Message = SQLDataExceptionMessage(sqlex);
        //        if (SQLDataExceptionHandler(sqlex))
        //            throw;
        //        return null;
        //    }
        //    catch (Exception ex)
        //    {
        //        Message = ExceptionMessage(ex);
        //        if (ExceptionHandler(ex))
        //            throw;
        //        return null;
        //    }
        //}

        #endregion ComboBox

        #region AutoComplete


        #endregion AutoComplete
    }
}