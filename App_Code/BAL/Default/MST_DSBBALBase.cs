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
    public class MST_DSBBALBase
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

        public MST_DSBBALBase()
        {

        }

        #endregion Constructor

        #region Select
        public DataTable SelectDayWiseMonthWiseIncome(SqlInt32 HospitalID)
        {
            MST_DSBDAL dalMST_DSB = new MST_DSBDAL();
            return dalMST_DSB.SelectDayWiseMonthWiseIncome(HospitalID);
        }
        public DataTable SelectDayWiseMonthWiseExpense(SqlInt32 HospitalID)
        {
            MST_DSBDAL dalMST_DSB = new MST_DSBDAL();
            return dalMST_DSB.SelectDayWiseMonthWiseExpense(HospitalID);
        }
        public DataTable SelectTreatmentWiseSummary(SqlInt32 HospitalID)
        {
            MST_DSBDAL dalMST_DSB = new MST_DSBDAL();
            return dalMST_DSB.SelectTreatmentWiseSummary(HospitalID);
        }

        #region Total Income/Expense
        public DataTable SelectTotalIncomeExpense(SqlInt32 HositalID)
        {
            MST_DSBDAL dalMST_DSB = new MST_DSBDAL();
            return dalMST_DSB.SelectTotalIncomeExpense(HositalID);
        }
        #endregion Total Income/Expense

        #endregion Select

    }
}