using System;
using System.Collections.Generic;
using DevExpress.Web;
using Entity;
using SystemManageService;
using System.Web.UI;
using System.Linq;
using System.Data;
using System.Globalization;
using DevExpress.XtraCharts;

namespace MTCSYT
{
    public partial class dmKhachHang_CT : BasePage
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
            if (!IsPostBack)
            {

                cmbThang.Value = DateTime.Now.Month - 1;
                cmbNam.Value = DateTime.Now.Year;
            }
            _DataBind();
            LoadKH();
            loadDanhMuc();

        }
        private void loadDanhMuc()
        {
            //WebChartControl WebChartControl = new WebChartControl();
            // Add the chart to the form.
            // Note that a chart isn't initialized until it's added to the form's collection of controls.
            //this.Controls.Add(WebChartControl);
            // Create a new bar series.
            Series series = new Series("Sản lượng khách hàng", ViewType.Bar);
            // Add the series to the chart.
            WebChartControl1.Series.Add(series);
            // Specify the series data source.
            DataTable seriesData = GetData();
            int max = Convert.ToInt32(seriesData.AsEnumerable().Max(row => row["Sales"]));
            series.DataSource = seriesData;

            ChartTitle ct = new ChartTitle();
            ct.Text = "THỐNG KÊ SẢN LƯỢNG KHÁCH HÀNG";
            WebChartControl1.Titles.Add(ct);
            // Specify an argument data member.
            series.ArgumentDataMember = "Region";
            // Specify a value data member.
            series.ValueDataMembers.AddRange(new string[] { "Sales" });
            // Rotate the diagram (if necessary).
            ((XYDiagram)WebChartControl1.Diagram).Rotated = false;
            ((XYDiagram)WebChartControl1.Diagram).AxisY.Range.SetMinMaxValues(0, max*1.25);
            ((XYDiagram)WebChartControl1.Diagram).AxisY.Label.EndText = "kWh";
        }
        public DataTable GetData()
        {
            
            MTCSYT.SYS_Session session = (MTCSYT.SYS_Session)Session["SYS_Session"];
            int ma_dviqly = int.Parse(session.User.ma_dviqly + "");
            string makhachang = lbMaKH.Text;
            DataTable dt = db.Get_SLKhang(session.User.ma_dviqlyDN, makhachang, int.Parse(cmbThang.Value + ""), int.Parse(cmbNam.Value + ""));
            DataTable table = new DataTable();
            table.Columns.AddRange(new DataColumn[] {
            new DataColumn("Region", typeof(string)),
            new DataColumn("Sales", typeof(decimal))
        });
            foreach (DataRow row in dt.Rows)
            {
                var SANLUONGTHANG = row["SANLUONGTHANG"];
                table.Rows.Add("Sản lượng tháng", SANLUONGTHANG);
                var SLUONG_1 = row["SLUONG_1"];
                table.Rows.Add("Sản lượng tháng trước", SLUONG_1);
                var SLUONG_2 = row["SLUONG_2"];
                table.Rows.Add("Sản lượng 2 tháng trước", SLUONG_2);
                var SLUONG_3 = row["SLUONG_3"];
                table.Rows.Add("Sản lượng 3 tháng trước", SLUONG_3);
                var SANLUONGCUNGKY = row["SANLUONGCUNGKY"];
                table.Rows.Add("Sản lượng cùng kỳ năm trước", SANLUONGCUNGKY);

            }
            
            return table;
        }
            
        private void LoadKH()
        {
            MTCSYT.SYS_Session session = (MTCSYT.SYS_Session)Session["SYS_Session"];
            string makhachang = lbMaKH.Text;
            DataTable dsa = db.SELECT_TTTT_KHACHHANG_LUUY_INFO(session.User.ma_dviqlyDN, makhachang);
            
            grdKH.DataSource = dsa;
            grdKH.DataBind();

        }
        private void _DataBind()
        {
            MTCSYT.SYS_Session session = (MTCSYT.SYS_Session)Session["SYS_Session"];
            DataTable dt = db.Get_SLKhang(session.User.ma_dviqlyDN, Request["MA_KHANG"], int.Parse(cmbThang.Value + ""), int.Parse(cmbNam.Value + ""));
            if (dt.Rows.Count > 0)
            {
                lbMaKH.Text = dt.Rows[0]["MA_KHANG"] + "";
                lbTenKH.Text = dt.Rows[0]["TENKHACHHANG"] + "";
                lbTram.Text = Request["MA_TRAM"] + "";
                lbDiaChi.Text = dt.Rows[0]["DIACHI"] + "";
            }

            grdDVT.DataSource = dt;
            grdDVT.DataBind();
        }

        protected void grdDVT_CustomColumnDisplayText(object sender, ASPxGridViewColumnDisplayTextEventArgs e)
        {
            if (e.Column.Caption == "STT")
            {
                e.DisplayText = (e.VisibleRowIndex + 1).ToString();
            }
        }

        protected void grdDVT_CellEditorInitialize(object sender, ASPxGridViewEditorEventArgs e)
        {
            e.Column.ToString();
            if (e.Column.FieldName == "MAKHACHHANG")
                e.Editor.Focus();
        }

        protected void grdDVT_StartRowEditing(object sender, DevExpress.Web.Data.ASPxStartRowEditingEventArgs e)
        {
            (sender as ASPxGridView).GetRowValuesByKeyValue(e.EditingKeyValue);

        }
        protected void ckChua_Init(object sender, EventArgs e)
        {
            ASPxCheckBox chk = sender as ASPxCheckBox;
            ASPxGridView grid = (chk.NamingContainer as GridViewHeaderTemplateContainer).Grid;
            chk.Checked = (grid.Selection.Count == grid.VisibleRowCount);
        }
        protected void grdDVT_CellEditorInitialize1(object sender, ASPxGridViewEditorEventArgs e)
        {

        }
        protected void grdDVT_HtmlCommandCellPrepared(object sender, ASPxGridViewTableCommandCellEventArgs e)
        {

        }

        protected void btnXemChiTiet_Click(object sender, EventArgs e)
        {

        }
        protected void btnThem_Click(object sender, EventArgs e)
        {
            pcAddRoles.ShowOnPageLoad = true;
            Session["Add"] = 1;
        }
        protected void btnCapNhat_Click(object sender, EventArgs e)
        {
            DM_DVQLYService dm_dviSer = new DM_DVQLYService();
            SYS_Session session = (SYS_Session)Session["SYS_Session"];
            
                if (txtNoiDung.Text == null)
                {
                    ScriptManager.RegisterStartupScript(Page, Page.GetType(), "", "alert('Nội dung không được để trống');", true); return;
                }
                string strMadviqly = session.User.ma_dviqlyDN;
                lbTram.Text = Request["MA_TRAM"];
                string tenkhachhang = lbTenKH.Text;
                    string diachi = lbDiaChi.Text;
                    string makhachang = lbMaKH.Text;
                    string matram = lbTram.Text;
                string strDate = DateTime.Now.ToString("dd/MM/yyyy h:mm");

                db.INSERT_TTTT_KHACHHANG_LUUY(strMadviqly, makhachang, matram, tenkhachhang, diachi, txtNoiDung.Text, strDate);
            pcAddRoles.ShowOnPageLoad = false;
            _DataBind();
            LoadKH();
        }
        protected void btnRemove_Click(object sender, EventArgs e)
        {
            MTCSYT.SYS_Session session = (MTCSYT.SYS_Session)Session["SYS_Session"];
            string makhachang = lbMaKH.Text;
            string matram = lbTram.Text;
            List<Object> keyvalues = grdKH.GetSelectedFieldValues("THOIGIAN");
            foreach (object key in keyvalues)
            {
                string thoigian = key + "";
                db.DELETE_TTTT_KHACHHANG_LUUY_INFO(matram, makhachang, thoigian);
            }
            LoadKH();
            grdKH.Selection.UnselectAll();

        }
        protected void btnDong_Click(object sender, EventArgs e)
        {
            pcAddRoles.ShowOnPageLoad = false;
        }
        protected void ASPxButton1_Click(object sender, EventArgs e)
        {
            Response.Redirect("../TonThatKyThuat/dmKhachHangLuuY.aspx");
        }
    }
}