using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Entity
{
    public partial class SYS_Right
    {
        public bool IsCreate { get; set; }
        public bool IsUpdate { get; set; }
        public bool IsDelete { get; set; }
        public bool IsApprove { get; set; }
        public SYS_Modun SysModun { get; set; }
        public string ModuleName { get; set; }
        //
        public string ConnectString { get; set; }

        //public override bool Equals(object obj)
        //{
        //    if (obj == null)
        //    {
        //        return false;
        //    }
        //    return this.Tag == ((SYS_Right)obj).Tag;
        //}
        //public static bool operator ==(SYS_Right obj1, SYS_Right obj2)
        //{
        //    if ((object)obj1 == null)
        //    {
        //        return (object)obj2 == null;
        //    }

        //    if ((object)obj2 == null)
        //    {
        //        return false;
        //    }

        //    return obj2.Tag == obj1.Tag;
        //}

        //public static bool operator !=(SYS_Right obj1, SYS_Right obj2)
        //{
        //    if ((object)obj1 == null)
        //    {
        //        return (object)obj2 != null;
        //    }

        //    if ((object)obj2 == null)
        //    {
        //        return true;
        //    }

        //    return obj2.Tag != obj1.Tag;
        //}

    }
}
