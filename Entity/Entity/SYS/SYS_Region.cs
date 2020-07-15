using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Entity
{
    public partial class SYS_Region
    {
        private List<SYS_Organization> _lstOrganization;
        private List<SYS_Province> _lstProvince;

        public List<SYS_Organization> LstOrganization { get { return _lstOrganization; } set { _lstOrganization = value; } }
        public List<SYS_Province> LstProvince { get { return _lstProvince; } set { _lstProvince = value; } }

    }
}
