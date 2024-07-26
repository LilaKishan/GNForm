using System;
using System.Collections.Generic;
using System.Data.SqlTypes;
using System.Linq;
using System.Web;

namespace GNForm3C.ENT
{
    public abstract class DemoENTBase
    {
        #region Properties


        protected SqlInt32 _DemoID;
        public SqlInt32 DemoID
        {
            get
            {
                return _DemoID;
            }
            set
            {
                _DemoID = value;
            }
        }

        protected SqlString _DemoName;
        public SqlString DemoName
        {
            get
            {
                return _DemoName;
            }
            set
            {
                _DemoName = value;
            }
        }


        protected SqlInt32 _UserID;
        public SqlInt32 UserID
        {
            get
            {
                return _UserID;
            }
            set
            {
                _UserID = value;
            }
        }

        protected SqlDateTime _Created;
        public SqlDateTime Created
        {
            get
            {
                return _Created;
            }
            set
            {
                _Created = value;
            }
        }

        protected SqlDateTime _Modified;
        public SqlDateTime Modified
        {
            get
            {
                return _Modified;
            }
            set
            {
                _Modified = value;
            }
        }

        #endregion Properties

        #region Constructor

        public DemoENTBase()
        {

        }

        #endregion Constructor

        #region ToString

        public override String ToString()
        {
            String DemoENT_String = String.Empty;

            if (!DemoID.IsNull)
                DemoENT_String += " DemoID = " + DemoID.Value.ToString();

            if (!DemoName.IsNull)
                DemoENT_String += "| Demo = " + DemoName.Value;

            if (!UserID.IsNull)
                DemoENT_String += "| UserID = " + UserID.Value.ToString();

            if (!Created.IsNull)
                DemoENT_String += "| Created = " + Created.Value.ToString("dd-MM-yyyy");

            if (!Modified.IsNull)
                DemoENT_String += "| Modified = " + Modified.Value.ToString("dd-MM-yyyy");


            DemoENT_String = DemoENT_String.Trim();

            return DemoENT_String;
        }

        #endregion ToString

    }
}