//------------------------------------------------------------------------------------------------------------------------
//-- Generated By:   TrungVK using CodeSmith 4.0.0.0
//-- Template:       Entity_Gen.cst
//-- Date Generated: Monday, September 29, 2014
//------------------------------------------------------------------------------------------------------------------------
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Entity
{
    public partial class DM_DVQLY
    {
        private int _IDMA_DVIQLY;
        private String _MA_DVIQLY;
        private string _TEN_DVIQLY;
        private int _ParentId;
        private string _NAME_DVIQLY;
        private int _Type;
        private string _TenVietTat;
        public int IDMA_DVIQLY { get { return _IDMA_DVIQLY; } set { _IDMA_DVIQLY = value; } }
        public String MA_DVIQLY { get { return _MA_DVIQLY; } set { _MA_DVIQLY = value; } }
        public string TEN_DVIQLY { get { return _TEN_DVIQLY; } set { _TEN_DVIQLY = value; } }
        public string NAME_DVIQLY { get { return _NAME_DVIQLY; } set { _NAME_DVIQLY = value; } }
        public int ParentId { get { return _ParentId; } set { _ParentId = value; } }
        public int Type { get { return _Type; } set { _Type = value; } }
        public string TenVietTat { get { return _TenVietTat; } set { _TenVietTat = value; } }
        public DM_DVQLY(int IDMA_DVIQLY, String MA_DVIQLY, string TEN_DVIQLY, int ParentId, int Type, string TenVietTat)
        {
            _IDMA_DVIQLY = IDMA_DVIQLY;
            _MA_DVIQLY = MA_DVIQLY;
            _TEN_DVIQLY = TEN_DVIQLY;
            _ParentId = ParentId;
            _Type = Type;
            _TenVietTat = TenVietTat;
        }
        public DM_DVQLY()
        {
            _IDMA_DVIQLY = 0;
            _MA_DVIQLY = String.Empty;
            _TEN_DVIQLY = String.Empty;
            _ParentId = 0;
            _Type = 0;
            TenVietTat = "";
        }

    }
}

