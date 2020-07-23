using System;
using System.Collections.Generic;
using DevExpress.Web;
using Entity;
using SystemManageService;
using System.Web.UI;
using System.Linq;
using System.Data;
using DevExpress.XtraCharts;
using DevExpress.XtraCharts.Web;
namespace MTCSYT
{
    public partial class SoSanhTonThat : BasePage
    {
        DataAccess.clTTTT db = new DataAccess.clTTTT();
        // CBDN.DB_CBDNDataContext db = new CBDN.DB_CBDNDataContext(new CBDN.ADOController().strcn());
        private SYS_Right rightOfUser = null;
        private const string funcid = "57";
        protected void Page_Load(object sender, EventArgs e)
        {
            #region PhanQuyen
            MTCSYT.SYS_Session session = (MTCSYT.SYS_Session)Session["SYS_Session"];
            if (session == null || session.User.USERNAME == "Guest")
            {
                Response.Redirect("~\\Login.aspx");
            }
            else
            {
                //if (Request.Cookies["IDUSER"].Value != "1")
                //{
                //    List<SYS_Right> right = session.User.Rights;
                //    foreach (SYS_Right sysRight in right)
                //    {
                //        if (sysRight.FuncId == funcid)
                //        {
                //            rightOfUser = sysRight;
                //            Session["Right"] = sysRight;
                //            Session["UserId"] = session.User.IDUSER;
                //            Session["FunctionId"] = sysRight.FuncId;
                //            break;
                //        }
                //    }

                //    if (rightOfUser == null)
                //    {
                //        Session["Status"] = "0";
                //        Response.Redirect("~\\HeThong\\Default.aspx");

                //    }
                //}
            }
            Session["SYS_Session"] = session;
            #endregion
            _DataBind();

        }

        private void _DataBind()
        {
            int thang = DateTime.Now.Month - 1;
            cmbThang.Value = thang;
            cmbNam.Value = DateTime.Now.Year;

            MTCSYT.SYS_Session session = (MTCSYT.SYS_Session)Session["SYS_Session"];
            cmbMaTram.DataSource = db.SELECT_TRAM_HATHE(session.User.ma_dviqlyDN);
            cmbMaTram.ValueField = "MA_TRAM";
            cmbMaTram.TextField = "STRTEN";
            cmbMaTram.DataBind();



            // var cv = (DataRowView)grdDVT.GetRow(grdDVT.FocusedRowIndex);
            //if (cmbMaTram.Value != null)
            //{
            //    DataTable dt = db.SELECT_TONTHATKD_BYTRAM(session.User.ma_dviqlyDN, cmbMaTram.Value + "", thang, DateTime.Now.Year);
            //    if (dt.Rows.Count > 0)
            //        lbTonThatKD.Text = dt.Rows[0]["TONTHAT"] + "";
            //}

        }

        protected void grdDVT_CustomColumnDisplayText(object sender, ASPxGridViewColumnDisplayTextEventArgs e)
        {
            if (e.Column.Caption == "STT")
            {
                e.DisplayText = (e.VisibleRowIndex + 1).ToString();
            }
        }
        private bool TinhChuKy(int thang, int nam, int Ngay, int ChuKy, int ngaysau, int chukysau, int kiemtra)
        {
            SYS_Session session = (SYS_Session)Session["SYS_Session"];
            DataTable dt = db.SELECT_TONTHAT_CHUKY(session.User.ma_dviqlyDN, cmbMaTram.Value + "", thang, nam, Ngay, ChuKy, ngaysau, chukysau, kiemtra);
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
                    db.INSERT_TTTT_SLGNUT_CHUKY(session.User.ma_dviqlyDN, cmbMaTram.Value + "", dt.Rows[i]["MACOT"] + "", thang, nam, Math.Round(slg, 2), Ngay, ChuKy);

                }
                else
                {
                    decimal slg = sltinhCK * decimal.Parse(dt.Rows[i]["SLGCOT"] + "") / sanluongtrc;
                    sanluongtrc = decimal.Parse(dt.Rows[i]["SLGCOT"] + "");
                    sltinhCK = slg;
                    db.INSERT_TTTT_SLGNUT_CHUKY(session.User.ma_dviqlyDN, cmbMaTram.Value + "", dt.Rows[i]["MACOT"] + "", thang, nam, Math.Round(slg, 2), Ngay, ChuKy);
                }
            }
            return true;
        }
        protected void btnThem_Click(object sender, EventArgs e)
        {
            SYS_Session session = (SYS_Session)Session["SYS_Session"];

            if (cmbMaTram.Value != null)
            {
                if (int.Parse(rdTinhToan.Value + "") == 0)
                {

                    DataTable dtTongKT = db.select_TTTT_TONTHATKYTHUAT_THANG(session.User.ma_dviqlyDN, cmbMaTram.Value + "", int.Parse(cmbThang.Value + ""), int.Parse(cmbNam.Value + ""), 1);
                    string tonthatKyThat = "2609";
                    if (dtTongKT.Rows.Count > 0)
                    {
                        tonthatKyThat = dtTongKT.Rows[0]["TONTHAT"] + "";
                    }
                    else
                    {
                        ScriptManager.RegisterStartupScript(Page, Page.GetType(), "", "alert('Chưa thực hiện tính tổn thật tại trạm này');", true);
                        return;
                    }

                    DataTable dt = db.SELECT_TONTHATKD_BYTRAM(session.User.ma_dviqlyDN, cmbMaTram.Value + "", int.Parse(cmbThang.Value + ""), int.Parse(cmbNam.Value + ""));
                    DataTable dtNew = new DataTable();
                    dtNew.Columns.Add("TTDN");
                    dtNew.Columns.Add("TTKT");
                    dtNew.Columns.Add("TTKD");
                    dtNew.Columns.Add("SoSanh");

                    dtNew.Rows.Add("ĐN tổn thất delta A", tonthatKyThat, dt.Rows[0]["TONTHAT"] + "", decimal.Parse(dt.Rows[0]["TONTHAT"] + "") - decimal.Parse(tonthatKyThat));
                    decimal phantramkt = Math.Round(decimal.Parse(tonthatKyThat) / decimal.Parse(dt.Rows[0]["DAUNGUONTHANG"] + "") * 100, 2);
                    dtNew.Rows.Add("Tỉ lệ tổn thất delta A", phantramkt, decimal.Parse(dt.Rows[0]["PHANTRAMTT"] + ""), decimal.Parse(dt.Rows[0]["PHANTRAMTT"] + "") - phantramkt);
                    dtNew.Rows.Add("Lũy kế", phantramkt, decimal.Parse(dt.Rows[0]["PHANTRAMTT"] + ""), decimal.Parse(dt.Rows[0]["PHANTRAMTT"] + "") - phantramkt);

                    DataTable dtBD = new DataTable();
                    dtBD = dtHienThiBanDo(dtNew);

                    hienthiBanDo(dtBD, decimal.Parse(dt.Rows[0]["PHANTRAMTT"] + "") - phantramkt, decimal.Parse(dt.Rows[0]["PHANTRAMTT"] + ""), phantramkt);
                    grdDVT.Caption = "Tính toán tổn thất điện năng trạm " + cmbMaTram.Text + " điện nhận tháng 6: " + dt.Rows[0]["DAUNGUONTHANG"] + " kwwh";
                    grdDVT.DataSource = dtNew;
                    grdDVT.DataBind();
                }
                else
                {
                    tinhtonthat();
                }
            }


            btnDanhSanhKH.Enabled = true;
        }
        private void tinhtonthat()
        {
            try
            {
                SYS_Session session = (SYS_Session)Session["SYS_Session"];
                CBDN.clTinhTonThatKT clTT = new CBDN.clTinhTonThatKT();

                DataTable dtNew = new DataTable();
                db.Delete_TTTT_TRAM_CHUYKYTINH(session.User.ma_dviqlyDN, cmbMaTram.Value + "", int.Parse(cmbThang.Value + ""), int.Parse(cmbNam.Value + ""));

                DataTable dt = db.SELECT_TONTHATKD_BYTRAM(session.User.ma_dviqlyDN, cmbMaTram.Value + "", int.Parse(cmbThang.Value + ""), int.Parse(cmbNam.Value + ""));
                string tonthatKyThat = "0";

                int ngay = 0, gio = 23, ngaysau = 0, giosau = 0, kiemtra;
                bool ktrMuc2 = false;
                int songay = DateTime.DaysInMonth(int.Parse(cmbNam.Value + ""), int.Parse(cmbThang.Value + ""));
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
                    if (TinhChuKy(int.Parse(cmbThang.Value + ""), int.Parse("" + cmbNam.Value), ngay, gio, ngaysau, giosau, kiemtra))
                    {
                        DataTable dtTTKT = clTT.TTKyThuat(session.User.ma_dviqlyDN, cmbMaTram.Value + "", ref tonthatKyThat, int.Parse(cmbThang.Value + ""), int.Parse("" + cmbNam.Value), ngay, gio);

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

                DataTable dtTongKT = db.select_TTTT_TONTHATKYTHUAT_THANG(session.User.ma_dviqlyDN, Request["MA_TRAM"] + "", int.Parse(Request["Thang"] + ""), int.Parse(Request["Nam"] + ""), 1);

                if (dtTongKT.Rows.Count > 0)
                    tonthatKyThat = dtTongKT.Rows[0]["TONTHAT"] + "";

                dtNew.Rows.Add("ĐN tổn thất delta A", tonthatKyThat, dt.Rows[0]["TONTHAT"] + "", decimal.Parse(dt.Rows[0]["TONTHAT"] + "") - decimal.Parse(tonthatKyThat));
                decimal phantramkt = Math.Round(decimal.Parse(tonthatKyThat) / decimal.Parse(dt.Rows[0]["DAUNGUONTHANG"] + "") * 100, 2);
                dtNew.Rows.Add("Tỉ lệ tổn thất delta A", phantramkt, decimal.Parse(dt.Rows[0]["PHANTRAMTT"] + ""), decimal.Parse(dt.Rows[0]["PHANTRAMTT"] + "") - phantramkt);
                DataTable dtBD = new DataTable();
                dtBD = dtHienThiBanDo(dtNew);

                hienthiBanDo(dtBD, decimal.Parse(dt.Rows[0]["PHANTRAMTT"] + "") - phantramkt, decimal.Parse(dt.Rows[0]["PHANTRAMTT"] + ""), phantramkt);
                grdDVT.Caption = "Tính toán tổn thất điện năng trạm " + cmbMaTram.Text + " điện nhận tháng 6: " + dt.Rows[0]["DAUNGUONTHANG"] + " kwwh";
                grdDVT.DataSource = dtNew;
                grdDVT.DataBind();
                ScriptManager.RegisterStartupScript(Page, Page.GetType(), "", "alert('Đã thực hiện tính xong tổn thật tại trạm');", true);
            }
            catch (Exception ex)
            {
                ScriptManager.RegisterStartupScript(Page, Page.GetType(), "", "alert('Đã thực hiện tính xong tổn thật tại trạm');", true);
                //ScriptManager.RegisterStartupScript(Page, Page.GetType(), "", "alert('Lỗi thực hiện tính " + ex.Message + "');", true);
            }

        }
        private DataTable dtHienThiBanDo(DataTable dt)
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

        private void hienthiBanDo(DataTable dt, decimal tyle, decimal TTKD, decimal TTKT)
        {
            DataTable souce = new DataTable();


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
                ct.Text = "CẢNH BÁO CÓ TỔN THẤT BẤT THƯỜNG TRẠM " + cmbMaTram.Text + " TRONG THÁNG " + cmbThang.Value;
            else
                ct.Text = "TỶ LỆ TỔN THẤT TRẠM " + cmbMaTram.Text + " TRONG THÁNG" + cmbThang.Value + " BÌNH THƯỜNG";
            WebChartControl1.Titles.Add(ct);

            decimal tyleChia = 30;

            if (TTKD > TTKT)
                tyleChia = TTKD + 5;
            else
                tyleChia = TTKT + 5;
            ((XYDiagram)WebChartControl1.Diagram).Rotated = false;
            ((XYDiagram)WebChartControl1.Diagram).AxisY.Range.SetMinMaxValues(0, tyleChia);
            ((XYDiagram)WebChartControl1.Diagram).AxisY.Label.EndText = "%";
        }
        private DataTable DiLaiDuongDay(DataTable dt)
        {

            return dt;

        }
        protected void grdDVT_StartRowEditing(object sender, DevExpress.Web.Data.ASPxStartRowEditingEventArgs e)
        {
            (sender as ASPxGridView).GetRowValuesByKeyValue(e.EditingKeyValue);

        }

        protected void grdDVT_CellEditorInitialize1(object sender, ASPxGridViewEditorEventArgs e)
        {

        }


        protected void grdDVT_HtmlCommandCellPrepared(object sender, ASPxGridViewTableCommandCellEventArgs e)
        {

        }

        protected void btnDanhSanhKH_Click(object sender, EventArgs e)
        {
            Response.Redirect("../TonThatKyThuat/dmKhachHang.aspx?MA_TRAM=" + cmbMaTram.Value);

        }

        protected void ASPxButton1_Click(object sender, EventArgs e)
        {
            Response.Redirect("../TonThatKyThuat/ChiTietPhuTai.aspx?MA_TRAM=" + cmbMaTram.Value + "&Thang=" + cmbThang.Value + "&Nam=" + cmbNam.Value);
        }


    }
}