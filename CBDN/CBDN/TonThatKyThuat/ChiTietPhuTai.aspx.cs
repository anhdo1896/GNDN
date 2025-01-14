﻿using System;
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
    public partial class ChiTietPhuTai : BasePage
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
            else if (session.XacNhanPass == 0)
            {
                ScriptManager.RegisterStartupScript(this, this.GetType(), "alertMessage", "alert('Mật Khẩu Không Hợp Lệ. Yêu Cầu Đổi Mật Khẩu'); window.location='" +
                Request.ApplicationPath + "HeThong/ChangePassword.aspx';", true);
            }
            else if (session.DatePass > 90)
            {
                ScriptManager.RegisterStartupScript(this, this.GetType(), "alertMessage", "alert('Mật Khẩu Quá 90 Ngày. Yêu Cầu Đổi Mật Khẩu'); window.location='" +
                Request.ApplicationPath + "HeThong/ChangePassword.aspx';", true);
            }
            Session["SYS_Session"] = session;
            #endregion
            _DataBind();
            lbMaTram.Text = Request["MA_TRAM"] + "";
        }

        private void _DataBind()
        {
            SYS_Session session = (SYS_Session)Session["SYS_Session"];
            cmbThang.Value = int.Parse(Request["Thang"] + "");
            cmbNam.Value = int.Parse(Request["Nam"] + "");
            var thang = cmbThang.Value;
            var nam = cmbNam.Value;
            var matram = Request["MA_TRAM"] + "";
            //DataTable dt = db.select_TTTT_TONTHATKYTHUAT_THANG(session.User.ma_dviqlyDN, Request["MA_TRAM"] + "", int.Parse(Request["Thang"] + ""), int.Parse(Request["Nam"] + ""), 0);
            DataTable dt = db.SELECT_TTTT_SANLUONG_TUTHANG_DENTHANG(session.User.ma_dviqlyDN, matram, int.Parse(thang + ""), int.Parse(nam + ""), 0, 31, 1);
            DataTable dts = db.SELECT_TTTT_TONTHATKYTHUAT_TUTHANG_DENTHANG(session.User.ma_dviqlyDN, matram, int.Parse(thang + ""), int.Parse(nam + ""), 0, 31, 1);

            grdTinhDetal.DataSource = dt;
            grdTinhDetal.DataBind();
            hienthibieudo(dt);
        }
        private void hienthibieudo(DataTable dt)
        {

            Series series1= new Series("Sản lượng", ViewType.Line);
            Series series2 = new Series("Sản lượng Trạm", ViewType.Line);
            Series series = new Series("Tổn thất", ViewType.Line);
            // Add the series to the chart.

                 WebChartControl1.Series.Add(series1);
            WebChartControl1.Series.Add(series2);
            WebChartControl1.Series.Add(series);
            // Specify the series data source.
            DataTable seriesData = dt;


            series1.DataSource = seriesData;
            series2.DataSource = seriesData;
            series.DataSource = seriesData;
            ChartTitle ct = new ChartTitle();
            ct.Text = "BIỂU ĐỒ PHỤ TẢI TỔN THẤT TẠI TRẠM " + Request["MA_TRAM"] + " THÁNG " + cmbThang.Value + " NĂM " + cmbNam.Value + " THEO CHU KỲ";
            ct.Font = new System.Drawing.Font("Tahoma", 12, System.Drawing.FontStyle.Bold);
            WebChartControl1.Titles.Add(ct);
            // Specify an argument data member.

            series1.ArgumentDataMember = "NGAYGIO";
            series2.ArgumentDataMember = "NGAYGIO";
            series.ArgumentDataMember = "NGAYGIO";
            // Specify a value data member.

            series1.ValueDataMembers.AddRange(new string[] { "TONGSL" });
            series2.ValueDataMembers.AddRange(new string[] { "SLTRAM" });
            series.ValueDataMembers.AddRange(new string[] { "TONTHATTONG" });
            ((XYDiagram)WebChartControl1.Diagram).EnableAxisXZooming = true;

            //diagram.AxisX.NumericScaleOptions.ScaleMode = ScaleMode.Manual;
            //diagram.AxisX.NumericScaleOptions.MeasureUnit = NumericMeasureUnit.Custom;
            //diagram.AxisX.NumericScaleOptions.CustomMeasureUnit = 1000;

            //((XYDiagram)WebChartControl1.Diagram).Rotated = false;
            //((XYDiagram)WebChartControl1.Diagram).AxisY.Range.SetMinMaxValues(0, 100);
            //((XYDiagram)WebChartControl1.Diagram).AxisY.Label.EndText = "%";
        }

        protected void grdDVT_CustomColumnDisplayText(object sender, ASPxGridViewColumnDisplayTextEventArgs e)
        {
            if (e.Column.Caption == "STT")
            {
                e.DisplayText = (e.VisibleRowIndex + 1).ToString();
            }
        }



        private bool CheckName(string Name, int id)
        {
            SYS_Session session = (SYS_Session)Session["SYS_Session"];

            var dt = db.TTTT_DM_LOAIDUONGDAY_CHECKNAME(id, session.User.ma_dviqlyDN, Name);
            if (dt.Rows.Count > 0)
                return false;
            return true;
        }

        protected void grdDVT_CellEditorInitialize(object sender, ASPxGridViewEditorEventArgs e)
        {
            e.Column.ToString();
            if (e.Column.FieldName == "MaChiNhanh")
                e.Editor.Focus();
        }

        protected void btnChiTietNgay_Click(object sender, EventArgs e)
        {
            Response.Redirect("../TonThatKyThuat/ChiTietPhuTaiNgay.aspx?MA_TRAM=" + lbMaTram.Text + "&Thang=" + cmbThang.Value + "&Nam=" + cmbNam.Value + "&Tungay=" + cmbTungay.Value + "&Denngay=" + cmbDenngay.Value);
        }



    }
}