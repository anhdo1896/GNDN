using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Entity
{
    partial class SYS_Roles
    {
        #region private
        List<SYS_Right> _rights = new List<SYS_Right>();
        #endregion

        #region Public
        public List<SYS_Right> Right { get { return _rights; } set { _rights = value; } }
        #endregion
    }
}
