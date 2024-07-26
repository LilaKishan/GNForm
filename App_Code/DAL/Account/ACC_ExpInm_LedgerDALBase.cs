﻿using GNForm3C.ENT;
using Microsoft.Practices.EnterpriseLibrary.Data.Sql;
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
    public abstract class ACC_ExpInm_LedgerDALBase:DataBaseConfig
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

        public ACC_ExpInm_LedgerDALBase()
        {

        }

        #endregion Constructor

        #region SelectOperation

        
        public DataTable SelectPage(SqlInt32 PageOffset, SqlInt32 PageSize, out Int32 TotalRecords, SqlDateTime FromDate, SqlDateTime ToDate,SqlString LedgerType)
        {
            TotalRecords = 0;
            try
            {
                SqlDatabase sqlDB = new SqlDatabase(myConnectionString);
                DbCommand dbCMD = sqlDB.GetStoredProcCommand("PR_ACC_ExpInm_LedgerSelectPage");
                sqlDB.AddInParameter(dbCMD, "@PageOffset", SqlDbType.Int, PageOffset);
                sqlDB.AddInParameter(dbCMD, "@PageSize", SqlDbType.Int, PageSize);
                sqlDB.AddOutParameter(dbCMD, "@TotalRecords", SqlDbType.Int, 4);
                sqlDB.AddInParameter(dbCMD, "@FromDate", SqlDbType.DateTime, FromDate);
                sqlDB.AddInParameter(dbCMD, "@ToDate", SqlDbType.DateTime, ToDate);
                sqlDB.AddInParameter(dbCMD, "@LedgerType", SqlDbType.VarChar, LedgerType);

                DataTable dtACC_ExpInm_Ledger = new DataTable("PR_ACC_ExpInm_LedgerSelectPage");

                DataBaseHelper DBH = new DataBaseHelper();
                DBH.LoadDataTable(sqlDB, dbCMD, dtACC_ExpInm_Ledger);

                TotalRecords = Convert.ToInt32(dbCMD.Parameters["@TotalRecords"].Value);

                return dtACC_ExpInm_Ledger;
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

        public DataTable SelectComboBox()
        {
            try
            {
                SqlDatabase sqlDB = new SqlDatabase(myConnectionString);
                DbCommand dbCMD = sqlDB.GetStoredProcCommand("PR_ACC_Expense_SelectComboBox");

                DataTable dtACC_ExpInm_Ledger = new DataTable("PR_ACC_Expense_SelectComboBox");

                DataBaseHelper DBH = new DataBaseHelper();
                DBH.LoadDataTable(sqlDB, dbCMD, dtACC_ExpInm_Ledger);

                return dtACC_ExpInm_Ledger;
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

        #region AutoComplete


        #endregion AutoComplete

    }
}