using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;

namespace TinhToanTBAUuTien
{
    public class clTinhTonThatKT
    {
        DataAccess.clTTTT dbTT = new DataAccess.clTTTT();
        public DataTable TTKyThuat(string ma_dviqlyDN, string maTram, ref string TonThat, int thang, int nam, int ngay, int chuky)
        {
            // int thang=DateTime.Now.Month-1;
            TonThat = "0";
            //tính toàn tổn thất kỹ thuật
            DataTable dtSLg_DD = dbTT.TTTT_SELECT_SLG_DUONGDAY_TRAM(ma_dviqlyDN, maTram, thang, nam, ngay, chuky);

            //dtSLg_DD.Columns.Add("Ngay", typeof(double));
            //dtSLg_DD.Columns.Add("ChuKy", typeof(double));
            //for (int i = 0; i < dtSLg_DD.Rows.Count; i++)
            //{
            //    DataRow[] dr = dtSLThang.Select("MACOT=" + dtSLg_DD.Rows[i]["DIEMCUOI"]);
            //    if (dr.Length > 0)
            //        dtSLg_DD.Rows[i]["SANLUONGTHANG"] = dr[0]["SANLUONGTHANG"];
            //    dtSLg_DD.Rows[i]["Ngay"] = ngay;
            //    dtSLg_DD.Rows[i]["ChuKy"] = chuky;
            //}

            dtSLg_DD.Columns.Add("P_BQ", typeof(double));
            dtSLg_DD.Columns.Add("Q_BQ", typeof(double));
            dtSLg_DD.Columns.Add("I_tt1", typeof(double));
            dtSLg_DD.Columns.Add("P_tt1", typeof(double));
            dtSLg_DD.Columns.Add("U_tt", typeof(double));
            dtSLg_DD.Columns.Add("I_tt2", typeof(double));
            dtSLg_DD.Columns.Add("P_tt2", typeof(double));

            //DataTable dtSLGNut = dtSLg_DD.Select("SANLUONGTHANG>0").CopyToDataTable();
            //DataTable dtSLGDay = dtSLg_DD.Select("SANLUONGTHANG =0 ").CopyToDataTable();
            int intRoWSum = 0;
            for (int i = 0; i < dtSLg_DD.Rows.Count; i++)
            {
                if (dtSLg_DD.Rows[i]["SANLUONGTHANG"] + "" == "0")
                {
                    intRoWSum++;
                    DataRow[] dr = dtSLg_DD.Select("DIEMDAU='" + dtSLg_DD.Rows[i]["DIEMCUOI"] + "'");
                    if (dr.Length > 0)
                    {
                        dtSLg_DD.Rows[i]["SANLUONGTHANG"] = dr.CopyToDataTable().Compute("SUM(SANLUONGTHANG)", "1=1");
                    }
                }

                //dtSLg_DD.Rows[i]["P_BQ"] = double.Parse(dtSLg_DD.Rows[i]["SANLUONGTHANG"] + "") / (double.Parse(dtSLg_DD.Rows[i]["DAYBYMONTH"] + "") * 24);
                //dtSLg_DD.Rows[i]["Q_BQ"] = Math.Sqrt(Math.Pow(double.Parse(dtSLg_DD.Rows[i]["SANLUONGTHANG"] + "") / (double.Parse(dtSLg_DD.Rows[i]["HESOCONGSUAT"] + "") / 100), 2) - Math.Pow(double.Parse(dtSLg_DD.Rows[i]["SANLUONGTHANG"] + ""), 2)) / (double.Parse(dtSLg_DD.Rows[i]["DAYBYMONTH"] + "") * 24);

                dtSLg_DD.Rows[i]["P_BQ"] = double.Parse(dtSLg_DD.Rows[i]["SANLUONGTHANG"] + "");
                dtSLg_DD.Rows[i]["Q_BQ"] = Math.Sqrt(Math.Pow(double.Parse(dtSLg_DD.Rows[i]["SANLUONGTHANG"] + "") / (double.Parse(dtSLg_DD.Rows[i]["HESOCONGSUAT"] + "") / 100), 2) - Math.Pow(double.Parse(dtSLg_DD.Rows[i]["SANLUONGTHANG"] + ""), 2));

                dtSLg_DD.Rows[i]["I_tt1"] = double.Parse(dtSLg_DD.Rows[i]["P_BQ"] + "") / (3 * double.Parse(dtSLg_DD.Rows[i]["TONGDIENAP"] + "") * (double.Parse(dtSLg_DD.Rows[i]["HESOCONGSUAT"] + "") / 100)) * 1000;
                dtSLg_DD.Rows[i]["P_tt1"] = 3 * Math.Pow(double.Parse(dtSLg_DD.Rows[i]["I_tt1"] + ""), 2) * double.Parse(dtSLg_DD.Rows[i]["DIENTROOM"] + "");


            }
            for (int i = dtSLg_DD.Rows.Count - 1; i >= 0; i--)
            {
                if (i == dtSLg_DD.Rows.Count - 1)
                {
                    dtSLg_DD.Rows[i]["U_tt"] = double.Parse(dtSLg_DD.Rows[i]["TONGDIENAP"] + "") - (double.Parse(dtSLg_DD.Rows[i]["I_tt1"] + "") * double.Parse(dtSLg_DD.Rows[i]["DIENTROOM"] + ""));
                }
                else
                {
                    dtSLg_DD.Rows[i]["U_tt"] = double.Parse(dtSLg_DD.Rows[i + 1]["U_tt"] + "") - double.Parse(dtSLg_DD.Rows[i]["I_tt1"] + "") * double.Parse(dtSLg_DD.Rows[i]["DIENTROOM"] + "");
                }

            }
            for (int i = 0; i < dtSLg_DD.Rows.Count; i++)
            {
                // if (dtSLg_DD.Rows[i]["DIEMDAU"]+"" == dtSLg_DD.Rows[i]["DIEMCUOI"]+"")
                if (intRoWSum >= i && i < dtSLg_DD.Rows.Count - 1)
                {
                    dtSLg_DD.Rows[i]["I_tt2"] = double.Parse(dtSLg_DD.Rows[i]["P_BQ"] + "") / (3 * double.Parse(dtSLg_DD.Rows[i + 1]["U_tt"] + "") * (double.Parse(dtSLg_DD.Rows[i]["HESOCONGSUAT"] + "") / 100)) * 1000;
                }
                else
                {
                    DataRow[] dr = dtSLg_DD.Select("DIEMDAU='" + dtSLg_DD.Rows[i]["DIEMCUOI"] + "'");
                    if (dr.Length > 0)
                    {
                        dtSLg_DD.Rows[i]["I_tt2"] = dr.CopyToDataTable().Compute("SUM(I_tt2)", "1=1");
                    }
                    else
                        dtSLg_DD.Rows[i]["I_tt2"] = 0;
                }
                dtSLg_DD.Rows[i]["P_tt2"] = 3 * Math.Pow(double.Parse(dtSLg_DD.Rows[i]["I_tt2"] + ""), 2) * double.Parse(dtSLg_DD.Rows[i]["DIENTROOM"] + "");

            }
            if (dtSLg_DD.Rows.Count > 0)
            {
                TonThat = (Math.Round(decimal.Parse(dtSLg_DD.Compute("SUM(P_tt2)", "1=1") + ""), 2)) + "";
                //insert tổn thất
                dbTT.Insert_TTTT_TONTHATKYTHUAT_THANG(0, ma_dviqlyDN, maTram, thang, nam, decimal.Parse(TonThat), DateTime.Now, ngay, chuky);
            }
            return dtSLg_DD;
        }
    }
}