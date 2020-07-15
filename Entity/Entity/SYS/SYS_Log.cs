using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Entity
{
    partial class SYS_Log
    {
        private string _userName;
        private string _funcName;
        public string Username { get { return _userName; } set { _userName = value; } }
        public string FuncName { get { return _funcName; } set { _funcName = value; } }
    }
}
