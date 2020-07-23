using System;
using System.Collections.Generic;
using DevExpress.Web;
using Entity;
using SystemManageService;
using System.Web.UI;
using System.Linq;
using System.Data;
using DevExpress.Web.ASPxGridView;
using DevExpress.Web;
using Aspose.Cells;
using System.Collections;
namespace MTCSYT
{
    public partial class DN_TK_CHITIETDIENTHUONGPHAM_TCY : BasePage
    {
        CBDN.DB_CBDNDataContext db = new CBDN.DB_CBDNDataContext(new CBDN.ADOController().strcn());
        private SYS_Right rightOfUser = null;
        private const string funcid = "57";
        private Cells _range;
        private Worksheet _exSheet;
        protected void Page_Load(object sender, EventArgs e)
        {
            #region PhanQuyen
            MTCSYT.SYS_Session session = (MTCSYT.SYS_Session)Session["SYS_Session"];
            if (session == null || session.User.USERNAME == "Guest")
            {
                Response.Redirect("~\\login\\Login.aspx");
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

            Session["SYS_Session"] = session;

            if (!IsPostBack)
            {

                cmbThang.Value = DateTime.Now.Month;
                cmbNam.Value = DateTime.Now.Year;
                LoadDataDV();
                loadNgay();
            }

            //  
        }
        private void loadNgay()
        {
            DataTable dtNgay = new DataTable();
            dtNgay.Columns.Add("Ngay");
            for (int i = 1; i <= DateTime.DaysInMonth(int.Parse(cmbNam.Value + ""), int.Parse(cmbThang.Value + "")); i++)
            {
                dtNgay.Rows.Add(i);

            }
            cmbTuNgay.DataSource = dtNgay;
            cmbTuNgay.ValueField = "Ngay";
            cmbTuNgay.TextField = "Ngay";
            cmbTuNgay.DataBind();
            cmbTuNgay.SelectedIndex = 0;

            cmbDenNgay.DataSource = dtNgay;
            cmbDenNgay.ValueField = "Ngay";
            cmbDenNgay.TextField = "Ngay";
            cmbDenNgay.DataBind();
            cmbDenNgay.SelectedIndex = DateTime.Now.Day;

        }
        private void LoadDataDV()
        {
            DM_DVQLYService dm_dviSer = new DM_DVQLYService();
            //  DataTable lst_dmdv = new DataTable();
            var lst_dmdv = db.DM_DVQLies.Where(x => x.Type == 2).ToList();
            cmbChonDonVi.DataSource = lst_dmdv;
            cmbChonDonVi.ValueField = "IDMA_DVIQLY";
            cmbChonDonVi.TextField = "TEN_DVIQLY";
            cmbChonDonVi.DataBind();

        }
        private void _DataBind()
        {
            MTCSYT.SYS_Session session = (MTCSYT.SYS_Session)Session["SYS_Session"];
            if (cmbChonDonVi.Value != null)
            {
                var khDN = db.DN_TongNhapDienNhans.Where(x => x.IDMA_DVIQLY == int.Parse(cmbChonDonVi.Value + "") && x.Thang == int.Parse(cmbThang.Value + "") && x.Nam == int.Parse("" + cmbNam.Value));

                if (khDN.Count() > 0)
                {
                    foreach (var kh in khDN)
                    {

                        lbTongDienNhan.Text = "Tổng điện nhận: " + kh.DN_Thang + "";
                        if (kh.DN_Thang == 0)
                        {
                            ScriptManager.RegisterStartupScript(Page, Page.GetType(), "", "alert('Tổng điện nhận theo kế hoạch =0 nên chưa thể nhập dữ liệu thực tế');", true);
                            btnIN.Visible = false;
                            return;
                        }
                        if (kh.NgayDCLan1 != null)
                        {
                            DateTime Lan1 = (DateTime)kh.NgayDCLan1;
                            lbDieuChinhLan1.Text = "ĐC lần 1: " + kh.DN_DC_Lan1 + "/ĐC ngày: " + Lan1.ToString("dd/MM/yyyy");
                        }
                        if (kh.NgayDCLan2 != null)
                        {
                            DateTime Lan2 = (DateTime)kh.NgayDCLan2;
                            lbDieuChinhLan2.Text = "  ĐC lần 2: " + kh.DN_DC_Lan2 + "/ĐC ngày: " + Lan2.ToString("dd/MM/yyyy");
                        }
                        if (kh.NgayDCLan3 != null)
                        {
                            DateTime Lan3 = (DateTime)kh.NgayDCLan3;
                            lbDieuChinhLan3.Text = "  ĐC lần 3: " + kh.DN_DC_Lan3 + "/ĐC ngày: " + Lan3.ToString("dd/MM/yyyy");
                        }

                        break;
                    }
                    btnIN.Visible = true;
                    grdDVT.DataSource = null;
                    grdDVT.DataSource = LoadDT();
                    grdDVT.DataBind();
                }
                else
                {
                    ScriptManager.RegisterStartupScript(Page, Page.GetType(), "", "alert('Chưa có dữ liệu kế hoạch nhập điện nhận nên chưa thể nhập dữ liệu thực tế');", true);
                }

            }


        }
        private DataTable LoadDT()
        {
            DataTable dt = new DataTable();
            dt.Columns.Add("Ngay");
            for (int i = int.Parse(cmbTuNgay.Value + ""); i <= int.Parse(cmbDenNgay.Value + ""); i++)
            {
                dt.Columns.Add(i + "");
            }
            dt.Rows.Add("Sản lượng thương phẩm tháng trước");
            dt.Rows.Add("Sản lượng kế hoạch tháng hiện tại");
            dt.Rows.Add("Sản lượng thương phẩm thực hiện tháng hiện tại");
            dt.Rows.Add("Chênh lệch tháng hiện tại");
            dt.Rows.Add("Chênh lệch tháng trước");

            // lấy điện thương phẩm tháng trước
            int thangtruoc, namtrc;
            if (cmbThang.Value + "" == "1")
            {
                thangtruoc = 12;
                namtrc = int.Parse(cmbNam.Value + "") - 1;
            }
            else
            {
                thangtruoc = int.Parse(cmbThang.Value + "") - 1;
                namtrc = int.Parse(cmbNam.Value + "");
            }

            // lấy điện thương phẩm tháng này

            for (int i = 1; i < dt.Columns.Count; i++)
            {
                var lstTruoc = db.DN_CTy_DienNhans.SingleOrDefault(x => x.IDMA_DVIQLY == int.Parse(cmbChonDonVi.Value + "") && x.Thang == thangtruoc && x.Nam == namtrc && x.Ngay == int.Parse(dt.Columns[i].ToString()));
                if (lstTruoc != null)
                    dt.Rows[0][i] = lstTruoc.DienNhan;
                var lst = db.DN_CTy_DienNhans.SingleOrDefault(x => x.IDMA_DVIQLY == int.Parse(cmbChonDonVi.Value + "") && x.Thang == int.Parse(cmbThang.Value + "") && x.Nam == int.Parse("" + cmbNam.Value) && x.Ngay == int.Parse(dt.Columns[i].ToString()));
                if (lst != null)
                {
                    dt.Rows[1][i] = lst.SanLuongKH;
                    dt.Rows[2][i] = lst.DienNhan;
                }
            }
            return dt;

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
            if (e.Column.FieldName == "MaChiNhanh")
                e.Editor.Focus();
        }

        protected void grdDVT_StartRowEditing(object sender, DevExpress.Web.Data.ASPxStartRowEditingEventArgs e)
        {
            (sender as ASPxGridView).GetRowValuesByKeyValue(e.EditingKeyValue);

        }

        protected void grdDVT_CellEditorInitialize1(object sender, ASPxGridViewEditorEventArgs e)
        {

        }



        protected void cmbPhongBan_SelectedIndexChanged(object sender, EventArgs e)
        {
            _DataBind();
        }

        protected void grdDVT_HtmlCommandCellPrepared(object sender, ASPxGridViewTableCommandCellEventArgs e)
        {

        }

        protected void btnXuat_Click(object sender, EventArgs e)
        {
            MTCSYT.SYS_Session session = (MTCSYT.SYS_Session)Session["SYS_Session"];
            Response.Redirect("../Report/Report.aspx?DenNgay="+cmbDenNgay.Value+"&TuNgay="+cmbTuNgay.Value+"&Thang=" + cmbThang.Value + "&Nam=" + cmbNam.Value + "&Loai=11&DonVi=" + cmbChonDonVi.Value);

        }



        protected void btnLoc_Click(object sender, EventArgs e)
        {
            _DataBind();
        }


        protected void btnCreate_Click(object sender, EventArgs e)
        {

        }

        protected void btnIN_Click(object sender, EventArgs e)
        {
            MTCSYT.SYS_Session session = (MTCSYT.SYS_Session)Session["SYS_Session"];
            Response.Redirect("../Report/Report.aspx?DenNgay=" + cmbDenNgay.Value + "&TuNgay=" + cmbTuNgay.Value + "&Thang=" + cmbThang.Value + "&Nam=" + cmbNam.Value + "&Loai=11&DonVi=" + cmbChonDonVi.Value);
        }


    }
}