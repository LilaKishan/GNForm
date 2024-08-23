using GNForm3C.DAL;
using Microsoft.Practices.EnterpriseLibrary.Data.Sql;
using Microsoft.Practices.EnterpriseLibrary.Data;
using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.SqlTypes;


public class ACC_LedgerDALBase:DataBaseConfig
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

    public ACC_LedgerDALBase()
    {

    }

    #endregion Constructor

    #region Report
    public DataTable Report_FinYearWiseHospitalWiseIncomeExpenseList()
    {
        try
        {
            SqlDatabase sqlDB = new SqlDatabase(myConnectionString);
            DbCommand dbCMD = sqlDB.GetStoredProcCommand("PP_FinYearWiseHospitalWiseIncomeExpenseList");

            DataTable dtACC_Expense = new DataTable("PP_FinYearWiseHospitalWiseIncomeExpenseList");

            DataBaseHelper DBH = new DataBaseHelper();
            DBH.LoadDataTable(sqlDB, dbCMD, dtACC_Expense);

            return dtACC_Expense;
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
    #endregion 
   
    public DataTable Report_ACC_Ledger(SqlInt32 FinYearID, SqlInt32 HospitalID)
    {
        
        try
        {
            SqlDatabase sqlDB = new SqlDatabase(myConnectionString);
            DbCommand dbCMD = sqlDB.GetStoredProcCommand("PP_Ledger_Hospital_Income_Expense");
          
          
            sqlDB.AddInParameter(dbCMD, "@FinYearID", SqlDbType.Int, FinYearID);
            sqlDB.AddInParameter(dbCMD, "@HospitalID", SqlDbType.Int, HospitalID);
            //sqlDB.AddInParameter(dbCMD, "@LedgerType", SqlDbType.VarChar, LedgerType);

            DataTable dtACC_Ledger = new DataTable("PP_ACC_Ledger");

            DataBaseHelper DBH = new DataBaseHelper();
            DBH.LoadDataTable(sqlDB, dbCMD, dtACC_Ledger);

           

            return dtACC_Ledger;
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

}