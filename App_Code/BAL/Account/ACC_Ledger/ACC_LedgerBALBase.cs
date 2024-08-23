using GNForm3C.DAL;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlTypes;
using System.Linq;
using System.Web;

namespace GNForm3C.BAL
{
    public class ACC_LedgerBALBase
    {
        #region Report
        public DataTable Report_FinYearWiseHospitalWiseIncomeExpenseList()
        {
            ACC_LedgerDAL dalACC_Ledger = new ACC_LedgerDAL();
            return dalACC_Ledger.Report_FinYearWiseHospitalWiseIncomeExpenseList();
        }
        #endregion 
        public DataTable Report_ACC_Ledger(SqlInt32 FinYearID, SqlInt32 HospitalID)
        {
            ACC_LedgerDAL dalACC_Ledger = new ACC_LedgerDAL();
            return dalACC_Ledger.Report_ACC_Ledger(FinYearID, HospitalID);
        }
    }
}
