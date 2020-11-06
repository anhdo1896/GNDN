using Castle.DynamicProxy.Generators.Emitters.CodeBuilders;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;

namespace CBDN.TonThatKyThuatReport
{
    public class DuyetTTTramTB
    {
            public DataTable DCB_TKD(DataTable ds, float tylebt)
        {

            DataTable dt = new DataTable();
            dt.Columns.Add("MA_DVIQLY");
            dt.Columns.Add("MA_TRAM");
            dt.Columns.Add("TEN_TRAM");
            dt.Columns.Add("CSUAT_TRAM");
            dt.Columns.Add("TT_PT");
            dt.Columns.Add("TT_TL1");
            dt.Columns.Add("TT_TL2");
            dt.Columns.Add("TT_TL3");
            int j = 0;
            int a = ds.Rows.Count;
            for(int i = 0; i<a; i++)
            {
                float tonthat = 0, tonthat1 = 0, tonthat2 = 0, tonthat3 = 0;
                if (ds.Rows[i]["TT_PT"] + "" != "")
                {
                    tonthat = float.Parse(ds.Rows[i]["TT_PT"] + "");
                }
                if (ds.Rows[i]["TT_TL1"] + "" != "")
                {
                    tonthat1 = float.Parse(ds.Rows[i]["TT_TL1"] + "");
                }
                if (ds.Rows[i]["TT_TL2"] + "" != "")
                {
                    tonthat2 = float.Parse(ds.Rows[i]["TT_TL2"] + "");
                }
                if (ds.Rows[i]["TT_TL3"] + "" != "")
                {
                    tonthat3 = float.Parse(ds.Rows[i]["TT_TL3"] + "");
                }
                float tb = (tonthat + tonthat1 + tonthat2 + tonthat3) / 4;
                if(tb>= tylebt)
                {
                    dt.Rows.Add(ds.Rows[i]["MA_DVIQLY"], ds.Rows[i]["MA_TRAM"], ds.Rows[i]["TEN_TRAM"], ds.Rows[i]["CSUAT_TRAM"],
                       ds.Rows[i]["TT_PT"], ds.Rows[i]["TT_TL1"], ds.Rows[i]["TT_TL2"], ds.Rows[i]["TT_TL3"]);
                    j++;
                }    
            }
            return dt;

        }
    }
}