using GNForm3C.ENT;
using Microsoft.Practices.EnterpriseLibrary.Data.Sql;
using Microsoft.Practices.EnterpriseLibrary.Data;
using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Data.SqlClient;
using System.Data.SqlTypes;
using System.Data;
using System.Linq;
using System.Web;

namespace GNForm3C.DAL
{
    public abstract class  MST_PatientDALBase: DataBaseConfig
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

        public MST_PatientDALBase()
        {

        }

        #endregion Constructor

        #region InsertOperation
        public SqlInt32 InsertPatient(MST_PatientENTBase entMST_Patient)
        {
            SqlInt32 PatientID = -1;

            try
            {
                SqlDatabase sqlDB = new SqlDatabase(myConnectionString);
                DbCommand dbCMD = sqlDB.GetStoredProcCommand("PR_MST_Patient_Insert");

                sqlDB.AddOutParameter(dbCMD, "@PatientID", SqlDbType.Int, 4);
                sqlDB.AddInParameter(dbCMD, "@PatientName", SqlDbType.NVarChar, entMST_Patient.PatientName);
                sqlDB.AddInParameter(dbCMD, "@Age", SqlDbType.Int, entMST_Patient.Age);
                sqlDB.AddInParameter(dbCMD, "@MobileNo", SqlDbType.NVarChar, entMST_Patient.MobileNo);
                sqlDB.AddInParameter(dbCMD, "@DOB", SqlDbType.DateTime, entMST_Patient.DOB);
                sqlDB.AddInParameter(dbCMD, "@PrimaryDesc", SqlDbType.NVarChar, entMST_Patient.PrimaryDesc);
                sqlDB.AddInParameter(dbCMD, "@PatientPhotoPath", SqlDbType.NVarChar, entMST_Patient.PatientPhotoPath);
                sqlDB.AddInParameter(dbCMD, "@UserID", SqlDbType.Int, entMST_Patient.UserID);
                sqlDB.AddInParameter(dbCMD, "@Created", SqlDbType.DateTime, entMST_Patient.Created);
                sqlDB.AddInParameter(dbCMD, "@Modified", SqlDbType.DateTime, entMST_Patient.Modified);

                DataBaseHelper DBH = new DataBaseHelper();
                DBH.ExecuteNonQuery(sqlDB, dbCMD);

                if (!(dbCMD.Parameters["@PatientID"].Value).Equals(DBNull.Value))
                {
                    entMST_Patient.PatientID = (SqlInt32)Convert.ToInt32(dbCMD.Parameters["@PatientID"].Value);
                    PatientID = entMST_Patient.PatientID;
                }

                return PatientID;
            }
            catch (SqlException sqlex)
            {
                Message = SQLDataExceptionMessage(sqlex);
                if (SQLDataExceptionHandler(sqlex))
                    throw;
                return PatientID;
            }
            catch (Exception ex)
            {
                Message = ExceptionMessage(ex);
                if (ExceptionHandler(ex))
                    throw;
                return PatientID;
            }
        }

        #endregion InsertOperation

        #region UpdateOperation

        //public Boolean Update(ACC_GNTransactionENT entACC_GNTransaction)
        //{
        //    try
        //    {
        //        SqlDatabase sqlDB = new SqlDatabase(myConnectionString);
        //        DbCommand dbCMD = sqlDB.GetStoredProcCommand("PR_ACC_GNTransaction_Update");

        //        sqlDB.AddInParameter(dbCMD, "@TransactionID", SqlDbType.Int, entACC_GNTransaction.TransactionID);
        //        sqlDB.AddInParameter(dbCMD, "@PatientID", SqlDbType.Int, entACC_GNTransaction.PatientID);
        //        sqlDB.AddInParameter(dbCMD, "@Amount", SqlDbType.Decimal, entACC_GNTransaction.Amount);
        //        sqlDB.AddInParameter(dbCMD, "@ReferenceDoctor", SqlDbType.NVarChar, entACC_GNTransaction.ReferenceDoctor);
        //        sqlDB.AddInParameter(dbCMD, "@Count", SqlDbType.Int, entACC_GNTransaction.Count);
        //        sqlDB.AddInParameter(dbCMD, "@ReceiptNo", SqlDbType.Int, entACC_GNTransaction.ReceiptNo);
        //        sqlDB.AddInParameter(dbCMD, "@Date", SqlDbType.DateTime, entACC_GNTransaction.Date);
        //        sqlDB.AddInParameter(dbCMD, "@DateOfAdmission", SqlDbType.DateTime, entACC_GNTransaction.DateOfAdmission);
        //        sqlDB.AddInParameter(dbCMD, "@DateOfDischarge", SqlDbType.DateTime, entACC_GNTransaction.DateOfDischarge);
        //        sqlDB.AddInParameter(dbCMD, "@Deposite", SqlDbType.Decimal, entACC_GNTransaction.Deposite);
        //        sqlDB.AddInParameter(dbCMD, "@NetAmount", SqlDbType.Decimal, entACC_GNTransaction.NetAmount);
        //        sqlDB.AddInParameter(dbCMD, "@NoOfDays", SqlDbType.Int, entACC_GNTransaction.NoOfDays);
        //        sqlDB.AddInParameter(dbCMD, "@Remarks", SqlDbType.NVarChar, entACC_GNTransaction.Remarks);
        //        sqlDB.AddInParameter(dbCMD, "@HospitalID", SqlDbType.Int, entACC_GNTransaction.HospitalID);
        //        sqlDB.AddInParameter(dbCMD, "@FinYearID", SqlDbType.Int, entACC_GNTransaction.FinYearID);
        //        sqlDB.AddInParameter(dbCMD, "@ReceiptTypeID", SqlDbType.Int, entACC_GNTransaction.ReceiptTypeID);
        //        sqlDB.AddInParameter(dbCMD, "@UserID", SqlDbType.Int, entACC_GNTransaction.UserID);
        //        sqlDB.AddInParameter(dbCMD, "@Created", SqlDbType.DateTime, entACC_GNTransaction.Created);
        //        sqlDB.AddInParameter(dbCMD, "@Modified", SqlDbType.DateTime, entACC_GNTransaction.Modified);

        //        DataBaseHelper DBH = new DataBaseHelper();
        //        DBH.ExecuteNonQuery(sqlDB, dbCMD);

        //        return true;
        //    }
        //    catch (SqlException sqlex)
        //    {
        //        Message = SQLDataExceptionMessage(sqlex);
        //        if (SQLDataExceptionHandler(sqlex))
        //            throw;
        //        return false;
        //    }
        //    catch (Exception ex)
        //    {
        //        Message = ExceptionMessage(ex);
        //        if (ExceptionHandler(ex))
        //            throw;
        //        return false;
        //    }
        //}


        #region Discharge patient
        public Boolean UpdateDischargeAndTotalDays(SqlInt32 TransactionID)
        {
            try
            {
                // Create a new SqlDatabase instance
                SqlDatabase sqlDB = new SqlDatabase(myConnectionString);

                // Create a new DbCommand instance for the stored procedure
                DbCommand dbCMD = sqlDB.GetStoredProcCommand("PR_ACC_GNTransaction_Discharge");

                // Add input parameters
                sqlDB.AddInParameter(dbCMD, "@TransactionID", SqlDbType.Int, TransactionID);

                // Execute the stored procedure
                DataBaseHelper DBH = new DataBaseHelper();
                DBH.ExecuteNonQuery(sqlDB, dbCMD);

                // Return true if successful
                return true;
            }
            catch (SqlException sqlex)
            {
                // Capture SQL exception message
                Message = SQLDataExceptionMessage(sqlex);

                // Handle SQL exception
                if (SQLDataExceptionHandler(sqlex))
                    throw;

                // Return false in case of failure
                return false;
            }
            catch (Exception ex)
            {
                // Capture general exception message
                Message = ExceptionMessage(ex);

                // Handle general exception
                if (ExceptionHandler(ex))
                    throw;

                // Return false in case of failure
                return false;
            }
        }
        #endregion

        #endregion UpdateOperation

        #region DeleteOperation

        //public Boolean Delete(SqlInt32 TransactionID)
        //{
        //    try
        //    {
        //        SqlDatabase sqlDB = new SqlDatabase(myConnectionString);
        //        DbCommand dbCMD = sqlDB.GetStoredProcCommand("PR_ACC_GNTransaction_Delete");

        //        sqlDB.AddInParameter(dbCMD, "@TransactionID", SqlDbType.Int, TransactionID);

        //        DataBaseHelper DBH = new DataBaseHelper();
        //        DBH.ExecuteNonQuery(sqlDB, dbCMD);

        //        return true;
        //    }
        //    catch (SqlException sqlex)
        //    {
        //        Message = SQLDataExceptionMessage(sqlex);
        //        if (SQLDataExceptionHandler(sqlex))
        //            throw;
        //        return false;
        //    }
        //    catch (Exception ex)
        //    {
        //        Message = ExceptionMessage(ex);
        //        if (ExceptionHandler(ex))
        //            throw;
        //        return false;
        //    }
        //}

        #endregion DeleteOperation

        #region SelectOperation

        public MST_PatientENT SelectPK(SqlInt32 PatientID)
        {
            try
            {
                SqlDatabase sqlDB = new SqlDatabase(myConnectionString);
                DbCommand dbCMD = sqlDB.GetStoredProcCommand("PR_MST_Patient_SelectPK");

                sqlDB.AddInParameter(dbCMD, "@PatientID", SqlDbType.Int, PatientID);

                MST_PatientENT entMST_Patient = new MST_PatientENT();
                DataBaseHelper DBH = new DataBaseHelper();
                using (IDataReader dr = DBH.ExecuteReader(sqlDB, dbCMD))
                {
                    while (dr.Read())
                    {
                        if (!dr["PatientID"].Equals(System.DBNull.Value))
                            entMST_Patient.PatientID = Convert.ToInt32(dr["PatientID"]);

                    
                        if (!dr["PatientName"].Equals(System.DBNull.Value))
                            entMST_Patient.PatientName = Convert.ToString(dr["PatientName"]);

                        if (!dr["Age"].Equals(System.DBNull.Value))
                            entMST_Patient.Age = Convert.ToInt32(dr["Age"]);

                        if (!dr["DOB"].Equals(System.DBNull.Value))
                            entMST_Patient.DOB = Convert.ToDateTime(dr["DOB"]);

                        if (!dr["MobileNo"].Equals(System.DBNull.Value))
                            entMST_Patient.MobileNo = Convert.ToString(dr["MobileNo"]);

                        if (!dr["PrimaryDesc"].Equals(System.DBNull.Value))
                            entMST_Patient.PrimaryDesc = Convert.ToString(dr["PrimaryDesc"]);

                        
                        if (!dr["UserID"].Equals(System.DBNull.Value))
                            entMST_Patient.UserID = Convert.ToInt32(dr["UserID"]);

                        if (!dr["Created"].Equals(System.DBNull.Value))
                            entMST_Patient.Created = Convert.ToDateTime(dr["Created"]);

                        if (!dr["Modified"].Equals(System.DBNull.Value))
                            entMST_Patient.Modified = Convert.ToDateTime(dr["Modified"]);

                    }
                }
                return entMST_Patient;
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
        public DataTable SelectView(SqlInt32 PatientID)
        {
            try
            {
                SqlDatabase sqlDB = new SqlDatabase(myConnectionString);
                DbCommand dbCMD = sqlDB.GetStoredProcCommand("PR_MST_Patient_SelectView");

                sqlDB.AddInParameter(dbCMD, "@PatientID", SqlDbType.Int, PatientID);

                DataTable dtMST_Patient = new DataTable("PR_MST_Patient_SelectView");

                DataBaseHelper DBH = new DataBaseHelper();
                DBH.LoadDataTable(sqlDB, dbCMD, dtMST_Patient);

                return dtMST_Patient;
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
        //        public DataTable SelectAll()
        //        {
        //            try
        //            {
        //                SqlDatabase sqlDB = new SqlDatabase(myConnectionString);
        //                DbCommand dbCMD = sqlDB.GetStoredProcCommand("PR_ACC_GNTransaction_SelectAll");

        //                DataTable dtACC_GNTransaction = new DataTable("PR_ACC_GNTransaction_SelectAll");

        //                DataBaseHelper DBH = new DataBaseHelper();
        //                DBH.LoadDataTable(sqlDB, dbCMD, dtACC_GNTransaction);

        //                return dtACC_GNTransaction;
        //            }
        //            catch (SqlException sqlex)
        //            {
        //                Message = SQLDataExceptionMessage(sqlex);
        //                if (SQLDataExceptionHandler(sqlex))
        //                    throw;
        //                return null;
        //            }
        //            catch (Exception ex)
        //            {
        //                Message = ExceptionMessage(ex);
        //                if (ExceptionHandler(ex))
        //                    throw;
        //                return null;
        //            }
        //        }
        //        public DataTable SelectPage(
        //    SqlInt32 PageOffset,
        //    SqlInt32 PageSize,
        //    out Int32 TotalRecords,
        //    SqlInt32 PatientID,
        //    SqlDecimal Amount,
        //    SqlString ReferenceDoctor,
        //    SqlInt32 Count,
        //    SqlInt32 ReceiptNo,
        //    SqlDateTime Date,
        //    SqlDateTime DateOfAdmission,
        //    SqlDateTime DateOfDischarge,
        //        SqlDecimal Deposite,
        //        SqlDecimal NetAmount,
        //    SqlInt32 NoOfDays,
        //    SqlInt32 HospitalID,
        //    SqlInt32 FinYearID,
        //    SqlInt32 ReceiptTypeID
        //)
        //        {
        //            TotalRecords = 0;
        //            try
        //            {
        //                SqlDatabase sqlDB = new SqlDatabase(myConnectionString);
        //                DbCommand dbCMD = sqlDB.GetStoredProcCommand("PR_ACC_GNTransaction_SelectPage");

        //                // Add parameters
        //                sqlDB.AddInParameter(dbCMD, "@PageOffset", SqlDbType.Int, PageOffset);
        //                sqlDB.AddInParameter(dbCMD, "@PageSize", SqlDbType.Int, PageSize);
        //                sqlDB.AddOutParameter(dbCMD, "@TotalRecords", SqlDbType.Int, 4);

        //                sqlDB.AddInParameter(dbCMD, "@PatientID", SqlDbType.Int, PatientID);
        //                sqlDB.AddInParameter(dbCMD, "@Amount", SqlDbType.Decimal, Amount);
        //                sqlDB.AddInParameter(dbCMD, "@ReferenceDoctor", SqlDbType.VarChar, ReferenceDoctor);
        //                sqlDB.AddInParameter(dbCMD, "@Count", SqlDbType.Int, Count);
        //                sqlDB.AddInParameter(dbCMD, "@ReceiptNo", SqlDbType.Int, ReceiptNo);
        //                sqlDB.AddInParameter(dbCMD, "@Date", SqlDbType.DateTime, Date);
        //                sqlDB.AddInParameter(dbCMD, "@DateOfAdmission", SqlDbType.DateTime, DateOfAdmission);
        //                sqlDB.AddInParameter(dbCMD, "@DateOfDischarge", SqlDbType.DateTime, DateOfDischarge);
        //                sqlDB.AddInParameter(dbCMD, "@Deposite", SqlDbType.Decimal, Deposite);
        //                sqlDB.AddInParameter(dbCMD, "@NetAmount", SqlDbType.Decimal, NetAmount);
        //                sqlDB.AddInParameter(dbCMD, "@NoOfDays", SqlDbType.Int, NoOfDays);
        //                sqlDB.AddInParameter(dbCMD, "@HospitalID", SqlDbType.Int, HospitalID);
        //                sqlDB.AddInParameter(dbCMD, "@FinYearID", SqlDbType.Int, FinYearID);
        //                sqlDB.AddInParameter(dbCMD, "@ReceiptTypeID", SqlDbType.Int, ReceiptTypeID);

        //                DataTable dtACC_GNTransaction = new DataTable("PR_ACC_GNTransaction_SelectPage");

        //                DataBaseHelper DBH = new DataBaseHelper();
        //                DBH.LoadDataTable(sqlDB, dbCMD, dtACC_GNTransaction);

        //                TotalRecords = Convert.ToInt32(dbCMD.Parameters["@TotalRecords"].Value);

        //                return dtACC_GNTransaction;
        //            }
        //            catch (SqlException sqlex)
        //            {
        //                Message = SQLDataExceptionMessage(sqlex);
        //                if (SQLDataExceptionHandler(sqlex))
        //                    throw;
        //                return null;
        //            }
        //            catch (Exception ex)
        //            {
        //                Message = ExceptionMessage(ex);
        //                if (ExceptionHandler(ex))
        //                    throw;
        //                return null;
        //            }
        //        }


        #endregion SelectOperation

        #region SelectCombobox

        #region ComboBox

        public DataTable SelectComboBox()
        {
            try
            {
                SqlDatabase sqlDB = new SqlDatabase(myConnectionString);
                DbCommand dbCMD = sqlDB.GetStoredProcCommand("PR_MST_Patient_SelectComboBox");

                DataTable dtMST_Patient = new DataTable("PR_MST_Patient_SelectComboBox");

                DataBaseHelper DBH = new DataBaseHelper();
                DBH.LoadDataTable(sqlDB, dbCMD, dtMST_Patient);

                return dtMST_Patient;
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

        #endregion ComboBox

        #endregion

    }
}
