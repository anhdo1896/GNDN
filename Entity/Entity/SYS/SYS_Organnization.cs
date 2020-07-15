using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Entity
{
    public partial class SYS_Organization
    {
        private int _IdOrgannization;
        public int IdOrgannization { get { return _IdOrgannization; } set { _IdOrgannization = value; } }

        public bool _IsFinish;
        public bool IsFinish { get { return _IsFinish; } set { _IsFinish = value; } }

        public bool _IsLock;
        public bool IsLock { get { return _IsLock; } set { _IsLock = value; } }
  
        private DateTime _Date;
        public DateTime Date { get { return _Date; } set { _Date = value; } }

        

        private string _Detail;
        public string Detail { get { return _Detail; } set { _Detail = value; } }

        public int _STT;
        public int STT { get { return _STT; } set { _STT = value; } }

        public int _GroupMonth;
        public int GroupMonth { get { return _GroupMonth; } set { _GroupMonth = value; } }

        private int _levelReport;

        private string _NumberPhone;
        public string NumberPhone { get { return _NumberPhone; } set { _NumberPhone = value; } }


        private string _UserName;
        public string UserName { get { return _UserName; } set { _UserName = value; } }
        private string _Email;
        public string Email { get { return _Email; } set { _Email = value; } }

        public int LevelReport
        {
            get { return _levelReport; }
            set { _levelReport = value; }
        }
    }
}
