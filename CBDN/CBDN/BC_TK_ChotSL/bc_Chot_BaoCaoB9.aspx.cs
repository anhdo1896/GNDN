using System;
using System.Collections.Generic;
using SystemManageService;
using DevExpress.Web.ASPxTreeList;
using Entity;
using System.Linq;
using System.Web.UI;
using System.Data;
using DevExpress.Web;
using System.IO;
using MTCSYT;

namespace CBDN.BC_TK_ChotSL
{
    public partial class bc_Chot_BaoCaoB9 : BasePage
    {
        CBDN.DB_CBDNDataContext db = new CBDN.DB_CBDNDataContext(new CBDN.ADOController().strcn());
        private const string funcid = "61";
        private SYS_Right rightOfUser = null;
        protected void Page_Load(object sender, EventArgs e)
        {

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
            if (!IsPostBack)
            {
                loadDSNgay();

                //if (session.User.ma_dviqly == "2")
                //    pcTax.TabIndex[4].
            }
            loadTax();

        }
        private void loadTax()
        {
            InBienBanQuyetToan();
        }

        private void InBienBanQuyetToan()
        {

            MTCSYT.SYS_Session session = (MTCSYT.SYS_Session)Session["SYS_Session"];
            int strMadviqly = int.Parse(session.User.ma_dviqly);

            DataTable dt = new DataTable();
            CBDN.Class.LS_InBienBanQT inBienBan = new CBDN.Class.LS_InBienBanQT();
            string strGiao = "", strNhan = "", strGDNhan = "", strGDGiao = "";

            int donvi = strMadviqly;
            // int phuongthuc = int.Parse(cmbPhuongThuc.Value + "");
            int phuongthuc = 0;
            DataTable dsdt = new DataTable();
            dsdt.Columns.Add("STT");
            dsdt.Columns.Add("Ten_Cty");

            dsdt.Columns.Add("B1_TieuThu");
            dsdt.Columns.Add("B2_TieuThu");
            dsdt.Columns.Add("B3_TieuThu");
            dsdt.Columns.Add("Tong_TieuThu");
            dsdt.Columns.Add("B1", typeof(decimal));
            dsdt.Columns.Add("B2", typeof(decimal));
            dsdt.Columns.Add("B3", typeof(decimal));
            dsdt.Columns.Add("Tong", typeof(decimal));
            dsdt.Columns.Add("Tyle_B1", typeof(decimal));
            dsdt.Columns.Add("Tyle_B2", typeof(decimal));
            dsdt.Columns.Add("Tyle_B3", typeof(decimal));
            int j = 0;
            decimal B1 = 0;
            decimal B2 = 0;
            decimal B3 = 0;
            for (int i = 11; i < 38; i++)
            {
                j++;
                donvi = i;
                var TenDonvi = db.DM_DVQLies.SingleOrDefault(x => x.IDMA_DVIQLY == donvi);
                var Ten = TenDonvi.TEN_DVIQLY;
                dt = inBienBan.InBienBanQuyetToan(phuongthuc, donvi, int.Parse(cmbThang.Value + ""), int.Parse(cmbNam.Value + ""), ref strGiao, ref strNhan, ref strGDNhan, ref strGDGiao);

                /*var B1_TieuThu1 = dt.Rows[0]["B1_TieuThu1"] + "";
                var B2_TieuThu1 = dt.Rows[0]["B2_TieuThu1"] + "";
                var B3_TieuThu1 = dt.Rows[0]["B3_TieuThu1"] + "";
                */
                string B1_TieuThu1 = dt.Compute("sum([B1_TieuThu])", "[Loai]=1 or [Loai]=2 or [Loai]=4").ToString();
                string B2_TieuThu1 = dt.Compute("sum([B2_TieuThu])", "[Loai]=1 or [Loai]=2 or [Loai]=4").ToString();
                string B3_TieuThu1 = dt.Compute("sum([B3_TieuThu])", "[Loai]=1 or [Loai]=2 or [Loai]=4").ToString();
                // var Tong_TieuThu1 = dt.Rows[0]["Tong_TieuThu1"] + "";

                if (B1_TieuThu1 != "")
                {
                    B1 = decimal.Parse(B1_TieuThu1.Replace(".", ""));
                }
                if (B1_TieuThu1 != "")
                {
                    B2 = decimal.Parse(B2_TieuThu1.Replace(".", ""));
                }
                if (B1_TieuThu1 != "")
                {
                    B3 = decimal.Parse(B3_TieuThu1.Replace(".", ""));
                }
                decimal Tong = B1 + B2 + B3;
                if (Tong != 0)
                {

                    //decimal Tong = decimal.Parse(Tong_TieuThu1.Replace(".", ""));
                    decimal tlB1 = B1 * 100 / Tong;
                    tlB1 = Math.Round(tlB1, 2);
                    decimal tlB2 = B2 * 100 / Tong;
                    tlB2 = Math.Round(tlB2, 2);
                    decimal tlB3 = B3 * 100 / Tong;
                    tlB3 = Math.Round(tlB3, 2);
                    var B1_TieuThu = string.Format("{0:N0} ", B1);
                    var B2_TieuThu = string.Format("{0:N0} ", B2);
                    var B3_TieuThu = string.Format("{0:N0} ", B3);
                    var Tong_TieuThu = string.Format("{0:N0} ", Tong);

                    dsdt.Rows.Add(j, Ten, B1_TieuThu, B2_TieuThu, B3_TieuThu, Tong_TieuThu, B1, B2, B3, Tong, tlB1, tlB2, tlB3);
                }
            }
            int a = dsdt.Rows.Count;
            if (a > 1)
            {
                MTCSYT.Report.InDienNhan3ThoiDiem report = new MTCSYT.Report.InDienNhan3ThoiDiem(dsdt, "" + cmbThang.Value, "" + cmbNam.Value, false, false, "", "", strGiao, strNhan, "", "", strGDNhan, strGDGiao);
            ReportViewer2.Report = report;

            ReportToolbar2.ReportViewer = ReportViewer2;
            }
        }



        protected void cbAll_Init(object sender, EventArgs e)
        {

            ASPxCheckBox chk = sender as ASPxCheckBox;
            ASPxGridView grid = (chk.NamingContainer as GridViewHeaderTemplateContainer).Grid;
            chk.Checked = (grid.Selection.Count == grid.VisibleRowCount);
        }
        private void loadDSNgay()
        {

                if (DateTime.Now.Month == 2)
                {
                    cmbThang.Value = 12;
                    cmbNam.Value = DateTime.Now.Year - 1;

                }
                if (DateTime.Now.Month == 1)
                {
                    cmbThang.Value = 11;
                    cmbNam.Value = DateTime.Now.Year - 1;

                }
                else
                {
                    cmbThang.Value = DateTime.Now.Month - 2;
                    cmbNam.Value = DateTime.Now.Year;


            }
        }
        protected void grdNhan_CustomCallback(object sender, DevExpress.Web.ASPxGridViewCustomCallbackEventArgs e)
        {
            loadTax();
        }
        protected void grdGiao_Callback(object sender, EventArgs e)
        {

        }





        protected void cmbThang_SelectedIndexChanged(object sender, EventArgs e)
        {
            loadTax();
        }

        protected void cmbNam_SelectedIndexChanged(object sender, EventArgs e)
        {
            loadTax();
        }

        protected void cmbPhuongThuc_SelectedIndexChanged(object sender, EventArgs e)
        {
            loadTax();
        }

        protected void btnIn_Click(object sender, EventArgs e)
        {
            MTCSYT.SYS_Session session = (MTCSYT.SYS_Session)Session["SYS_Session"];
            string strMadviqly = session.User.ma_dviqly;
            Response.Redirect("../Report/Report.aspx?ChiNhanh=" + 0 + "&Loai=1&Thang=" + cmbThang.Value + "&Nam=" + cmbNam.Value + "&ParentId=1");
        }



    }
}