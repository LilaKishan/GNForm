using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;

namespace GNForm3C
{
    public class MST_BranchIntakeBALBase
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
        public MST_BranchIntakeBALBase()
        {

        }
        #endregion Constructor

        #region Select BranchIntake Data
        public DataTable GetBranchIntakeData()
        {
            MST_BranchIntakeDAL dalMST_BranchIntake = new MST_BranchIntakeDAL();

            return dalMST_BranchIntake.GetBranchIntakeData();
        }


        #endregion Select BranchIntake Data

        #region Insert/Update Intake DATA

        public bool SaveBranchIntakeData(DataTable branchIntakeTable)
        {
            try
            {
                MST_BranchIntakeDAL dalMST_BranchIntake = new MST_BranchIntakeDAL();
                dalMST_BranchIntake.SaveBranchIntakeData(branchIntakeTable);
                return true;
            }
            catch (Exception ex){
                throw;
                return false;
            }
       
            
        }


        #endregion Insert/Update Intake DATA

        #region Delete BranchIntake Data
        public void DeleteBranchIntakeData(string branch)
        {
            MST_BranchIntakeDAL dalMST_BranchIntake = new MST_BranchIntakeDAL();

            dalMST_BranchIntake.DeleteBranchIntakeData(branch);
        }

        #endregion Delete BranchIntake Data



    }
}