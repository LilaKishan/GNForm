using GNForm3C.DAL;
using GNForm3C.ENT;
using Microsoft.Practices.EnterpriseLibrary.Data.Sql;
using Microsoft.Practices.EnterpriseLibrary.Data;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Data.SqlClient;
using System.Data.SqlTypes;
using System.Linq;
using System.Web;

namespace GNForm3C.BAL
{
    public abstract class MST_PatientBALBase:DataBaseConfig
    {

        #region Private Fields

        private string _Message;

        #endregion Private Fields

        #region Public Properties

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

        #endregion Public Properties

        #region Constructor

        public MST_PatientBALBase()
        {

        }

        #endregion Constructor

        #region InsertOperation

        public SqlInt32 InsertPatient(MST_PatientENT entMST_Patient)
        {
            MST_PatientDAL dalMST_Patient = new MST_PatientDAL();
            SqlInt32 PatientID = dalMST_Patient.InsertPatient(entMST_Patient);

            if (PatientID > 0)
            {
                return PatientID;
            }
            else
            {
                this.Message = dalMST_Patient.Message;
                return PatientID;
            }
        }

        #endregion InsertOperation

        #region UpdateOperation

        #region Update

        public Boolean Update(MST_PatientENT entMST_GNPatient)
        {
            try
            {
                SqlDatabase sqlDB = new SqlDatabase(myConnectionString);
                DbCommand dbCMD = sqlDB.GetStoredProcCommand("PR_MST_Patient_Update");

                sqlDB.AddInParameter(dbCMD, "@PatientID", SqlDbType.Int, entMST_GNPatient.PatientID);
                sqlDB.AddInParameter(dbCMD, "@PatientName", SqlDbType.NVarChar, entMST_GNPatient.PatientName);
                sqlDB.AddInParameter(dbCMD, "@Age", SqlDbType.Int, entMST_GNPatient.Age);
                sqlDB.AddInParameter(dbCMD, "@MobileNo", SqlDbType.NVarChar, entMST_GNPatient.MobileNo);
                sqlDB.AddInParameter(dbCMD, "@DOB", SqlDbType.DateTime, entMST_GNPatient.DOB);
                sqlDB.AddInParameter(dbCMD, "@PrimaryDesc", SqlDbType.NVarChar, entMST_GNPatient.PrimaryDesc);
                sqlDB.AddInParameter(dbCMD, "@UserID", SqlDbType.Int, entMST_GNPatient.UserID);
                sqlDB.AddInParameter(dbCMD, "@PatientPhotoPath", SqlDbType.NVarChar, entMST_GNPatient.PatientPhotoPath);
                sqlDB.AddInParameter(dbCMD, "@Modified", SqlDbType.DateTime, entMST_GNPatient.Modified);

                DataBaseHelper DBH = new DataBaseHelper();
                DBH.ExecuteNonQuery(sqlDB, dbCMD);

                //PatientID = entMST_GNPatient.PatientID;

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

        #endregion Update
        #endregion UpdateOperation



        #region DeleteOperation

        //public Boolean Delete(SqlInt32 TransactionID)
        //{
        //    MST_PatientDAL dalMST_Patient = new MST_PatientDAL();
        //    if (dalMST_Patient.Delete(TransactionID))
        //    {
        //        return true;
        //    }
        //    else
        //    {
        //        this.Message = dalMST_Patient.Message;
        //        return false;
        //    }
        //}

        #endregion DeleteOperation
        #region AutoComplete
        public DataTable AutoComplete(SqlString prefixText, SqlString contextText)
        {
            MST_PatientDAL dalMST_Patient = new MST_PatientDAL();
            return dalMST_Patient.AutoComplete(prefixText, contextText);
        }
        #endregion AutoComplete
        #region SelectOperation

        public MST_PatientENT SelectPK(SqlInt32 PatientID)
        {
            MST_PatientDAL dalMST_Patient = new MST_PatientDAL();
            return dalMST_Patient.SelectPK(PatientID);
        }
        public DataTable SelectView(SqlInt32 PatientID)
        {
            MST_PatientDAL dalMST_Patient= new MST_PatientDAL();
            return dalMST_Patient.SelectView(PatientID);
        }
        //public DataTable SelectAll()
        //{
        //    ACC_GNTransactionDAL dalACC_GNTransaction = new ACC_GNTransactionDAL();
        //    return dalACC_GNTransaction.SelectAll();
        //}
        //        public DataTable SelectPage(
        //            SqlInt32 PageOffset,
        //            SqlInt32 PageSize,
        //            out Int32 TotalRecords,
        //            SqlInt32 PatientID,
        //            SqlDecimal Amount,
        //            SqlString ReferenceDoctor,
        //            SqlInt32 Count,
        //            SqlInt32 ReceiptNo,
        //            SqlDateTime Date,
        //            SqlDateTime DateOfAdmission,
        //            SqlDateTime DateOfDischarge,
        //            SqlDecimal Deposite,
        //            SqlDecimal NetAmount,
        //            SqlInt32 NoOfDays,
        //            SqlInt32 HospitalID,
        //            SqlInt32 FinYearID,
        //            SqlInt32 ReceiptTypeID
        //)
        //        {
        //            ACC_GNTransactionDAL dalACC_GNTransaction = new ACC_GNTransactionDAL();
        //            return dalACC_GNTransaction.SelectPage(
        //                PageOffset,
        //                PageSize,
        //                out TotalRecords,
        //                PatientID,
        //                Amount,
        //                ReferenceDoctor,
        //                Count,
        //                ReceiptNo,
        //                Date,
        //                DateOfAdmission,
        //                DateOfDischarge,
        //                Deposite,
        //                NetAmount,
        //                NoOfDays,
        //                HospitalID,
        //                FinYearID,
        //                ReceiptTypeID
        //            );
        //        }


        #endregion SelectOperation		

        #region SelectComboBox
        //public DataTable SelectComboBox()
        //{
        //    ACC_GNTransactionDAL dalMST_FinYear = new ACC_GNTransactionDAL();
        //    return dalMST_FinYear.SelectComboBox();
        //}
        #endregion

        #region Report

        public DataTable RPT_PatientIDCard()
        {
            MST_PatientDAL dalMST_Patient = new MST_PatientDAL();
            return dalMST_Patient.RPT_PatientIDCard();
        }

        #endregion Report
    }
}
