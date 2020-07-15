using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Entity
{
    public partial class SYS_CategoryManager
    {
        private List<SYS_ColumnCategory> _lstColumnCategory;

        public List<SYS_ColumnCategory> LstColumnCategory { get { return _lstColumnCategory; } set { _lstColumnCategory = value; } }
    }
}
