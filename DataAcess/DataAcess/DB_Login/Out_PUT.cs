using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DataAccess
{
    public static class Out_PUT
    {
        public class ISCHECK_LOGIN_OUT
        {
            public string ISCHECK_LOGIN { get; set; }
            public DateTime DATE_PASS { get; set; }
        }

        public class Getdate_Pass
        {
            public DateTime DATE_PASS { get; set; }
        }

        public class Checklogin_USER
        {
            public int IDMA_DVIQLY { get; set; }
            public string USERNAME { get; set; }
            public string PASSWORD { get; set; }
        }
    }
}
