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
using static DevExpress.XtraExport.Helpers.TableCellCss;
using MTCSYT;

namespace CBDN.TonThatKyThuat
{
    public partial class TonThatTramUuTien : BasePage
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
            if (cmbThang.Value == null && cmbNam.Value == null)
            {
                var thang = Request["THANG"] + "";
                var nam = Request["NAM"] + "";
                cmbThang.Value = thang;
                cmbNam.Value = nam;
            }
            
            MTCSYT.SYS_Session session = (MTCSYT.SYS_Session)Session["SYS_Session"];
            lbDvi.Text = Request["MA_QVIQLY"] + "";
            lbTram.Text = Request["MA_TRAM"] + ""; 
        }

        protected void grdDVT_CustomColumnDisplayText(object sender, ASPxGridViewColumnDisplayTextEventArgs e)
        {
            if (e.Column.Caption == "STT")
            {
                e.DisplayText = (e.VisibleRowIndex + 1).ToString();
            }
        }
        protected void btnThem_Click(object sender, EventArgs e)
        {
            SYS_Session session = (SYS_Session)Session["SYS_Session"];

            if (lbTram.Text != null)
            {
                

                    DataTable dtTongKT = db.select_TTTT_TONTHATKYTHUAT_THANG(lbDvi.Text + "", lbTram.Text + "", int.Parse(cmbThang.Value + ""), int.Parse(cmbNam.Value + ""), 1);
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
                    CBDN.clTinhTonThatKT clTT = new CBDN.clTinhTonThatKT();
                    DataTable dtNew = new DataTable();
                    DataTable dta = db.SELECT_TONTHATKD_BYTRAM(lbDvi.Text + "", lbTram.Text + "", int.Parse(cmbThang.Value + ""), int.Parse(cmbNam.Value + ""));
                    DataTable dt = db.SELECT_TRAM_HATHE_UT_TT(lbDvi.Text + "", lbTram.Text + "", cmbThang.Value + "", cmbNam.Value + "");
                var a = dt.Rows.Count;
                    
                    dtNew.Columns.Add("TTDN");
                    dtNew.Columns.Add("TTKT");
                    dtNew.Columns.Add("TTKD");
                    dtNew.Columns.Add("SoSanh");
                if (a > 0)
                {
                    dtNew.Rows.Add("ĐN tổn thất delta A", dt.Rows[0]["KY_THUAT_DN"], dt.Rows[0]["KINH_DOANH_DN"], dt.Rows[0]["SO_SANH_DN"]);

                    dtNew.Rows.Add("Tỉ lệ tổn thất delta A", dt.Rows[0]["KY_THUAT_TL"], dt.Rows[0]["KINH_DOANH_TL"], dt.Rows[0]["SO_SANH_TL"]);
                    DataTable dtBD = new DataTable();
                    dtBD = dtHienThiBanDo(dtNew);

                    hienthiBanDo(dtBD, decimal.Parse(dta.Rows[0]["PHANTRAMTT"] + "") - decimal.Parse(dt.Rows[0]["KY_THUAT_TL"] + ""), decimal.Parse(dta.Rows[0]["PHANTRAMTT"] + ""), decimal.Parse(dt.Rows[0]["KY_THUAT_TL"] + ""));

                    grdDVT.Caption = "Tính toán tổn thất điện năng trạm " + lbTram.Text + " điện nhận tháng: " + cmbThang.Value + " : "+ dta.Rows[0]["DAUNGUONTHANG"] + " kwwh";
                    grdDVT.DataSource = dtNew;
                    grdDVT.DataBind();
                }
                else
                {
                    grdDVT.Caption = "Tính toán tổn thất điện năng trạm " + lbTram.Text + " chưa có dự liệu tháng: " + cmbThang.Value;
                    grdDVT.DataSource = dtNew;
                    grdDVT.DataBind();
                }    
                
            }


            btnDanhSanhKH.Enabled = true;
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
                ct.Text = "CẢNH BÁO CÓ TỔN THẤT BẤT THƯỜNG TRẠM " + lbTram.Text + " TRONG THÁNG " + cmbThang.Value;
            else
                ct.Text = "TỶ LỆ TỔN THẤT TRẠM " + lbTram.Text + " TRONG THÁNG " + cmbThang.Value + " BÌNH THƯỜNG";
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
            Response.Redirect("../TonThatKyThuat/dmKhachHang.aspx?MA_TRAM=" + lbTram.Text);

        }

        protected void ASPxButton1_Click(object sender, EventArgs e)
        {
            Response.Redirect("../TonThatKyThuat/ChiTietPhuTai.aspx?MA_TRAM=" + lbTram.Text + "&Thang=" + cmbThang.Value + "&Nam=" + cmbNam.Value);
        }


    }
}