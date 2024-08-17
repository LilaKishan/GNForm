using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlTypes;
using GNForm3C;
using GNForm3C.DAL;
using GNForm3C.ENT;

namespace GNForm3C.BAL
{
    public abstract class ACC_GNTransactionBALBase
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

        public ACC_GNTransactionBALBase()
        {

        }

        #endregion Constructor

        #region InsertOperation

        public Boolean Insert(ACC_GNTransactionENT entACC_GNTransaction)
        {
            ACC_GNTransactionDAL dalACC_GNTransaction = new ACC_GNTransactionDAL();
            if (dalACC_GNTransaction.Insert(entACC_GNTransaction))
            {
                return true;
            }
            else
            {
                this.Message = dalACC_GNTransaction.Message;
                return false;
            }
        }

        //public SqlInt32 InsertPatient(MST_PatientENT entMST_Patient)
        //{
        //    ACC_GNTransactionDAL dalACC_GNTransaction = new ACC_GNTransactionDAL();
        //    SqlInt32 PatientID = dalACC_GNTransaction.InsertPatient(entMST_Patient);

        //    if (PatientID > 0)
        //    {
        //        return PatientID;
        //    }
        //    else
        //    {
        //        this.Message = dalACC_GNTransaction.Message;
        //        return PatientID;
        //    }
        //}

        #endregion InsertOperation

        #region UpdateOperation

        public Boolean Update(ACC_GNTransactionENT entACC_GNTransaction)
        {
            ACC_GNTransactionDAL dalACC_GNTransaction = new ACC_GNTransactionDAL();
            if (dalACC_GNTransaction.Update(entACC_GNTransaction))
            {
                return true;
            }
            else
            {
                this.Message = dalACC_GNTransaction.Message;
                return false;
            }
        }

        #endregion UpdateOperation

        #region Discharge patient
        public Boolean UpdateDischargeAndTotalDays(SqlInt32 TransactionID)
        {
            ACC_GNTransactionDAL dalACC_GNTransaction = new ACC_GNTransactionDAL();
            if (dalACC_GNTransaction.UpdateDischargeAndTotalDays(TransactionID))
            {
                return true;
            }
            else
            {
                this.Message = dalACC_GNTransaction.Message;
                return false;
            }
        }
        #endregion

        #region DeleteOperation

        public Boolean Delete(SqlInt32 TransactionID)
        {
            ACC_GNTransactionDAL dalACC_GNTransaction = new ACC_GNTransactionDAL();
            if (dalACC_GNTransaction.Delete(TransactionID))
            {
                return true;
            }
            else
            {
                this.Message = dalACC_GNTransaction.Message;
                return false;
            }
        }

        #endregion DeleteOperation

        #region SelectOperation

        public ACC_GNTransactionENT SelectPK(SqlInt32 TransactionID)
        {
            ACC_GNTransactionDAL dalACC_GNTransaction = new ACC_GNTransactionDAL();
            return dalACC_GNTransaction.SelectPK(TransactionID);
        }
        public DataTable SelectView(SqlInt32 TransactionID)
        {
            ACC_GNTransactionDAL dalACC_GNTransaction = new ACC_GNTransactionDAL();
            return dalACC_GNTransaction.SelectView(TransactionID);
        }
        public DataTable SelectAll()
        {
            ACC_GNTransactionDAL dalACC_GNTransaction = new ACC_GNTransactionDAL();
            return dalACC_GNTransaction.SelectAll();
        }
        public DataTable SelectPage(SqlInt32 PageOffset,SqlInt32 PageSize,out Int32 TotalRecords,SqlInt32 PatientID,SqlDecimal Amount,SqlString ReferenceDoctor,SqlInt32 Count,SqlInt32 ReceiptNo,SqlDateTime Date,SqlDateTime DateOfAdmission,SqlDateTime DateOfDischarge,SqlDecimal Deposite,SqlDecimal NetAmount,SqlInt32 NoOfDays,SqlInt32 HospitalID,SqlInt32 FinYearID,SqlInt32 ReceiptTypeID)
        {
            ACC_GNTransactionDAL dalACC_GNTransaction = new ACC_GNTransactionDAL();
            return dalACC_GNTransaction.SelectPage(PageOffset,PageSize,out TotalRecords,PatientID,Amount,ReferenceDoctor,Count,ReceiptNo,Date,DateOfAdmission,DateOfDischarge,Deposite,NetAmount,NoOfDays,HospitalID,FinYearID,ReceiptTypeID);
        }
        public DataTable SelectReportPage(SqlInt32 TransactionID)
        {
            ACC_GNTransactionDAL dalACC_GNTransaction = new ACC_GNTransactionDAL();
            return dalACC_GNTransaction.SelectReportPage(TransactionID);
        }

        #endregion SelectOperation		

        #region SelectComboBox
        public DataTable SelectComboBox()
        {
            ACC_GNTransactionDAL dalMST_FinYear = new ACC_GNTransactionDAL();
            return dalMST_FinYear.SelectComboBox();
        }
        #endregion
    }
}