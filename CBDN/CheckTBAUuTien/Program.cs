﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Web.UI;
using System.Windows.Forms;
using Entity;
using SystemManageService;
namespace CheckTBAUuTien
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new Form1());
            DataAccess.clTTTT db = new DataAccess.clTTTT();
        }
        static bool TinhChuKy(int thang, int nam, int Ngay, int ChuKy, int ngaysau, int chukysau, int kiemtra)
        {
           string ma_dviqlyDN="PA23MV";
            string MaTram = "MVCE00099";
            DataAccess.clTTTT db = new DataAccess.clTTTT();
            DataTable dt = db.SELECT_TONTHAT_CHUKY(ma_dviqlyDN,MaTram, thang, nam, Ngay, ChuKy, ngaysau, chukysau, kiemtra);
            if (dt.Rows.Count == 0)
                return false;
            if (dt.Rows[0]["CSUAT"] + "" == "0" || dt.Rows[0]["CSUAT"] + "" == "")
                return false;
            decimal sltinhCK = 0, sanluongtrc = 0;
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                if (i == 0)
                {
                    decimal slg = (decimal.Parse(dt.Rows[i]["SLGCOT"] + "") * decimal.Parse(dt.Rows[i]["CSUAT"] + "")) / decimal.Parse(dt.Rows[i]["SLDAUNGUONG"] + "");
                    sanluongtrc = decimal.Parse(dt.Rows[i]["SLGCOT"] + "");
                    sltinhCK = slg;
                    db.INSERT_TTTT_SLGNUT_CHUKY(ma_dviqlyDN, MaTram, dt.Rows[i]["MACOT"] + "", thang, nam, Math.Round(slg, 2), Ngay, ChuKy);

                }
                else
                {
                    decimal slg = sltinhCK * decimal.Parse(dt.Rows[i]["SLGCOT"] + "") / sanluongtrc;
                    sanluongtrc = decimal.Parse(dt.Rows[i]["SLGCOT"] + "");
                    sltinhCK = slg;
                    db.INSERT_TTTT_SLGNUT_CHUKY(ma_dviqlyDN, MaTram, dt.Rows[i]["MACOT"] + "", thang, nam, Math.Round(slg, 2), Ngay, ChuKy);
                }
            }
            return true;
        }
        static void tinhtonthat()
        {
            try
            {
                string ma_dviqlyDN = "PA23MV";
                string MaTram = "MVCE00099";
                int thang = 6;
                int nam = 2020;
                DataAccess.clTTTT db = new DataAccess.clTTTT();
                DataTable dtNew = new DataTable();
                db.Delete_TTTT_TRAM_CHUYKYTINH(ma_dviqlyDN, MaTram , thang, nam);

                DataTable dt = db.SELECT_TONTHATKD_BYTRAM(ma_dviqlyDN ,MaTram, thang, nam);
                string tonthatKyThat = "0";

                int ngay = 0, gio = 23, ngaysau = 0, giosau = 0, kiemtra;
                bool ktrMuc2 = false;
                int songay = DateTime.DaysInMonth(nam, thang);
                for (int i = songay * 24; i > 0; i--)
                {
                    if (i == 706)
                    {
                        string a = "1";
                    }
                    if (i == songay * 24)
                    {
                        kiemtra = 1;
                    }
                    else if (ktrMuc2)
                        kiemtra = 1;
                    else
                        kiemtra = 2;
                    ngaysau = ngay;
                    giosau = gio;
                    if (i % 24 == 0)
                    {
                        ngay = i / 24;
                        gio = 23;
                    }
                    else if (i != songay * 24)
                    {
                        gio = gio - 1;
                    }
                    //int strNgay = 0, strChuKy = 0;
                    //string ma_dviqlyDN, string maTram, ref string TonThat, int thang, int nam, int ngay, int chuky)
                    if (TinhChuKy(thang, nam, ngay, gio, ngaysau, giosau, kiemtra))
                    {
                        DataTable dtTTKT = clTinhTonThatKT.TTKyThuat(ma_dviqlyDN, MaTram, ref tonthatKyThat, thang, nam, ngay, gio);

                        ktrMuc2 = false;
                    }
                    else
                        ktrMuc2 = true;

                }
                dtNew.Columns.Add("TTDN");
                dtNew.Columns.Add("TTKT");
                dtNew.Columns.Add("TTKD");
                dtNew.Columns.Add("SoSanh");

                //dtNew.Rows.Add("ĐN tổn thất delta A", decimal.Parse(tonthatKyThat) * decimal.Parse("15"), dt.Rows[0]["TONTHAT"] + "", decimal.Parse(dt.Rows[0]["TONTHAT"] + "") - decimal.Parse(tonthatKyThat) * decimal.Parse("15"));
                //decimal phantramkt = Math.Round(decimal.Parse(tonthatKyThat) * decimal.Parse("15") / decimal.Parse(dt.Rows[0]["DAUNGUONTHANG"] + "") * 100, 2);
                //dtNew.Rows.Add("Tỉ lệ tổn thất delta A", phantramkt, decimal.Parse(dt.Rows[0]["PHANTRAMTT"] + ""), decimal.Parse(dt.Rows[0]["PHANTRAMTT"] + "") - phantramkt);

                DataTable dtTongKT = db.select_TTTT_TONTHATKYTHUAT_THANG(ma_dviqlyDN, MaTram, thang, nam, 1);

                if (dtTongKT.Rows.Count > 0)
                    tonthatKyThat = dtTongKT.Rows[0]["TONTHAT"] + "";

                dtNew.Rows.Add("ĐN tổn thất delta A", tonthatKyThat, dt.Rows[0]["TONTHAT"] + "", decimal.Parse(dt.Rows[0]["TONTHAT"] + "") - decimal.Parse(tonthatKyThat));
                decimal phantramkt = Math.Round(decimal.Parse(tonthatKyThat) / decimal.Parse(dt.Rows[0]["DAUNGUONTHANG"] + "") * 100, 2);
                dtNew.Rows.Add("Tỉ lệ tổn thất delta A", phantramkt, decimal.Parse(dt.Rows[0]["PHANTRAMTT"] + ""), decimal.Parse(dt.Rows[0]["PHANTRAMTT"] + "") - phantramkt);
                DataTable dtBD = new DataTable();
                dtBD = dtHienThiBanDo(dtNew);

                hienthiBanDo(dtBD, decimal.Parse(dt.Rows[0]["PHANTRAMTT"] + "") - phantramkt, decimal.Parse(dt.Rows[0]["PHANTRAMTT"] + ""), phantramkt);
                //grdDVT.Caption = "Tính toán tổn thất điện năng trạm " + MaTram.Text + " điện nhận tháng 6: " + dt.Rows[0]["DAUNGUONTHANG"] + " kwwh";
               // grdDVT.DataSource = dtNew;
               // grdDVT.DataBind();
               // ScriptManager.RegisterStartupScript(Page, Page.GetType(), "", "alert('Đã thực hiện tính xong tổn thật tại trạm');", true);
            }
            catch (Exception ex)
            {
                //ScriptManager.RegisterStartupScript(Page, Page.GetType(), "", "alert('Đã thực hiện tính xong tổn thật tại trạm');", true);
                //ScriptManager.RegisterStartupScript(Page, Page.GetType(), "", "alert('Lỗi thực hiện tính " + ex.Message + "');", true);
            }

        }
        static DataTable dtHienThiBanDo(DataTable dt)
        {
            DataTable dtBanDo = new DataTable();
            dtBanDo.Columns.AddRange(new DataColumn[] {
                new DataColumn("Region", typeof(string)),
                new DataColumn("Sales", typeof(decimal))
            });
            dtBanDo.Rows.Add("Kỹ thuật", decimal.Parse(dt.Rows[1][1] + ""));
            dtBanDo.Rows.Add("Kinh doanh", decimal.Parse(dt.Rows[1][2] + ""));
            dtBanDo.Rows.Add("Kế hoạch", 0);
            dtBanDo.Rows.Add("So sánh", decimal.Parse(dt.Rows[1][3] + ""));

            return dtBanDo;
        }

        static void hienthiBanDo(DataTable dt, decimal tyle, decimal TTKD, decimal TTKT)
        {
            DataTable souce = new DataTable();
            /*

            Series series = new Series("Tỉ lệ tổn thất", ViewType.Bar);
            souce = dt.Select("Region='Kỹ thuật'").CopyToDataTable();
            series.DataSource = souce;
            series.ArgumentDataMember = "Region";
            series.ValueDataMembers.AddRange(new string[] { "Sales" });
            WebChartControl1.Series.Add(series);

            series = new Series("Tỉ lệ thực hiện", ViewType.Bar);
            souce = dt.Select("Region='Kinh doanh'").CopyToDataTable();
            series.DataSource = souce;
            series.ArgumentDataMember = "Region";
            series.ValueDataMembers.AddRange(new string[] { "Sales" });
            WebChartControl1.Series.Add(series);

            series = new Series("Kế hoạch", ViewType.Bar);
            souce = dt.Select("Region='Kế hoạch'").CopyToDataTable();
            series.DataSource = souce;
            series.ArgumentDataMember = "Region";
            series.ValueDataMembers.AddRange(new string[] { "Sales" });
            WebChartControl1.Series.Add(series);

            series = new Series("Tỷ lệ So sánh", ViewType.Bar);
            souce = dt.Select("Region='So sánh'").CopyToDataTable();
            series.DataSource = souce;
            series.ArgumentDataMember = "Region";
            series.ValueDataMembers.AddRange(new string[] { "Sales" });
            WebChartControl1.Series.Add(series);

            ChartTitle ct = new ChartTitle();
            if (tyle > 1)
                ct.Text = "CẢNH BÁO CÓ TỔN THẤT BẤT THƯỜNG TRẠM " + MaTram.Text + " TRONG THÁNG " + cmbThang.Value;
            else
                ct.Text = "TỶ LỆ TỔN THẤT TRẠM " + MaTram.Text + " TRONG THÁNG " + cmbThang.Value + " BÌNH THƯỜNG";
            ct.Font = new System.Drawing.Font("Tahoma", 12, System.Drawing.FontStyle.Bold);
            WebChartControl1.Titles.Add(ct);

            decimal tyleChia = 30;

            if (TTKD > TTKT)
                tyleChia = TTKD + 5;
            else
                tyleChia = TTKT + 5;
            ((XYDiagram)WebChartControl1.Diagram).Rotated = false;
            ((XYDiagram)WebChartControl1.Diagram).AxisY.Range.SetMinMaxValues(0, tyleChia);
            ((XYDiagram)WebChartControl1.Diagram).AxisY.Label.EndText = "%";
            */
        }
    }
}
