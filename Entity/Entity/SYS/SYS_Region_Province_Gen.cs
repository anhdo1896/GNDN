﻿//------------------------------------------------------------------------------------------------------------------------
//-- Generated By:   TrungVK using CodeSmith 5.0.0.0
//-- Template:       Entity_Gen.cst
//-- Date Generated: Wednesday, October 05, 2011
//------------------------------------------------------------------------------------------------------------------------
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Entity
{
    public partial class SYS_Region_Province
    {
        private int _ID;
        private int _IDRegion;
        private int _IDProvince;

        public int ID { get { return _ID; } set { _ID = value; } }
        public int IDRegion { get { return _IDRegion; } set { _IDRegion = value; } }
        public int IDProvince { get { return _IDProvince; } set { _IDProvince = value; } }

        public SYS_Region_Province(int ID, int IDRegion, int IDProvince)
        {
            _ID = ID;
            _IDRegion = IDRegion;
            _IDProvince = IDProvince;
        }
        public SYS_Region_Province()
        {
            _ID = 0;
            _IDRegion = 0;
            _IDProvince = 0;
        }

    }
}


