using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Entity
{
    public class SYS_Catagory
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public string Code { get; set; }
        public int ParentID { get; set; }
        public int OrganizationID { get; set; }
        public string DonViTinh { get; set; }
    }
}
