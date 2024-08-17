using GNForm3C.DAL;
using GNForm3C.ENT;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlTypes;
using System.Linq;
using System.Web;

namespace GNForm3C.BAL
{
    public abstract class MST_PatientBALBase
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

        //public Boolean Update(ACC_GNTransactionENT entACC_GNTransaction)
        //{
        //    ACC_GNTransactionDAL dalACC_GNTransaction = new ACC_GNTransactionDAL();
        //    if (dalACC_GNTransaction.Update(entACC_GNTransaction))
        //    {
        //        return true;
        //    }
        //    else
        //    {
        //        this.Message = dalACC_GNTransaction.Message;
        //        return false;
        //    }
        //}

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
    }
}
