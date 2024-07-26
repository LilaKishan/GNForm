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
    public abstract class DemoBALBase
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

        public DemoBALBase()
        {

        }

        #endregion Constructor

        #region InsertOperation

        public Boolean Insert(DemoENT entDemo)
        {
            DemoDAL dalDemoDAL= new DemoDAL();
            if (dalDemoDAL.Insert(entDemo))
            {
                return true;
            }
            else
            {
                this.Message = dalDemoDAL.Message;
                return false;
            }
        }

        #endregion InsertOperation

        #region UpdateOperation

        public Boolean Update(DemoENT entDemo)
        {
            DemoDAL dalDemoDAL = new DemoDAL();
            if (dalDemoDAL.Update(entDemo))
            {
                return true;
            }
            else
            {
                this.Message = dalDemoDAL.Message;
                return false;
            }
        }

        #endregion UpdateOperation

        #region DeleteOperation

        public Boolean Delete(SqlInt32 DemoID)
        {
            DemoDAL dalDemoDAL = new DemoDAL();
            if (dalDemoDAL.Delete(DemoID))
            {
                return true;
            }
            else
            {
                this.Message = dalDemoDAL.Message;
                return false;
            }
        }

        #endregion DeleteOperation

        #region SelectOperation

        public DemoENT SelectPK(SqlInt32 DemoID)
        {
            DemoDAL dalDemoDAL = new DemoDAL();
            return dalDemoDAL.SelectPK(DemoID);
        }
        public DataTable SelectView(SqlInt32 DemoID)
        {
            DemoDAL dalDemoDAL = new DemoDAL();
            return dalDemoDAL.SelectView(DemoID);
        }
        public DataTable SelectAll()
        {
            DemoDAL dalDemoDAL = new DemoDAL();
            return dalDemoDAL.SelectAll();
        }
        public DataTable SelectPage(SqlInt32 PageOffset, SqlInt32 PageSize, out Int32 TotalRecords,  SqlString DemoName)
        {
            DemoDAL dalDemoDAL = new DemoDAL();
            return dalDemoDAL.SelectPage(PageOffset, PageSize, out TotalRecords, DemoName);
        }

        #endregion SelectOperation

        #region ComboBox

        //public DataTable SelecComboBox()
        //{
        //    DemoDAL dalDemoDAL = new DemoDAL();
        //    return dalDemoDAL.SelectComboBox();
        //}

        #endregion ComboBox

    }

}