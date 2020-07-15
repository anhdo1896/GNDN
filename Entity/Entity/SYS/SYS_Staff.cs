using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Entity
{
    partial class SYS_Staff
    {
        private SYS_Organization _organization;
        private SYS_Position _position;
        private string _FullName;

        public SYS_Organization Organization { get { return _organization; } set { _organization = value; } }
        public SYS_Position Position { get { return _position; } set { _position = value; } }
        public string FullName { get { return _FullName; } set { _FullName = value; } }
    }
}
