using System;
using System.Collections.Generic;
using DevExpress.Web;
using Entity;
using SystemManageService;
using System.Web.UI;
using System.Linq;
using System.Data;
using Aspose.Cells;
using System.Collections;
namespace MTCSYT
{
    public partial class DN_TK_DIENTP_TCY : BasePage
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

            Session["SYS_Session"] = session;

            if (!IsPostBack)
            {

                cmbThang.Value = DateTime.Now.Month;
                cmbNam.Value = DateTime.Now.Year;
                loadNgay();
            }
            _DataBind();
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

        private void _DataBind()
        {
            MTCSYT.SYS_Session session = (MTCSYT.SYS_Session)Session["SYS_Session"];

            var khDN = db.DN_TK_SumALLKeHoach(int.Parse(cmbThang.Value + ""), int.Parse("" + cmbNam.Value)).ToList();

            if (khDN.Count() > 0)
            {
                foreach (var kh in khDN)
                {

                    lbTongDienNhan.Text = string.Format("Tổng Sản lượng thương phẩm phân bổ: {0:N0} " , kh.DN_Thang );
                    if (kh.DN_Thang == 0)
                    {
                        ScriptManager.RegisterStartupScript(Page, Page.GetType(), "", "alert('Tổng sản lượng thương phẩm theo kế hoạch =0 nên chưa thể nhập dữ liệu thực tế');", true);
                        btnIN.Visible = false;
                        return;
                    }

                    lbDieuChinhLan1.Text = string.Format("ĐC lần 1: {0:N0}" , kh.DN_DC_Lan1);

                    lbDieuChinhLan2.Text = string.Format("  ĐC lần 2: {0:N0}" , kh.DN_DC_Lan2);

                    lbDieuChinhLan3.Text = string.Format("  ĐC lần 3: {0:N0}" , kh.DN_DC_Lan3);

                    break;
                }
                int thangtr, namtr, thangN2, namN2;
                if (cmbThang.Value + "" == "1")
                {
                    thangtr = 12;
                    namtr = int.Parse(cmbNam.Value + "") - 1;
                    thangN2 = 11;
                    namN2 = int.Parse(cmbNam.Value + "") - 1;
                }
                else if (cmbThang.Value + "" == "2")
                {
                    thangtr = 1;
                    namtr = int.Parse(cmbNam.Value + "");
                    thangN2 = 12;
                    namN2 = int.Parse(cmbNam.Value + "") - 1;
                }
                else
                {
                    thangtr = int.Parse(cmbThang.Value + "") - 1;
                    namtr = int.Parse(cmbNam.Value + "");
                    thangN2 = int.Parse(cmbThang.Value + "") - 2;
                    namN2 = int.Parse(cmbNam.Value + "");
                }
                btnIN.Visible = true;
                grdDVT.DataSource = null;
                grdDVT.DataSource = db.DN_TK_ThucTeTCT(int.Parse(cmbThang.Value + ""), int.Parse(cmbNam.Value + ""), thangtr, namtr, thangN2, namN2, int.Parse(cmbTuNgay.Value + ""), int.Parse(cmbDenNgay.Value + ""));
                grdDVT.DataBind();
            }
            else
            {
                lbDieuChinhLan1.Text = "ĐC lần 1: 0";

                lbDieuChinhLan2.Text = "  ĐC lần 2: 0";

                lbDieuChinhLan3.Text = "  ĐC lần 3: 0";
                ScriptManager.RegisterStartupScript(Page, Page.GetType(), "", "alert('Chưa có dữ liệu kế hoạch nhập điện nhận nên chưa thể nhập dữ liệu thực tế');", true);
            }



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
            Response.Redirect("../Report/Report.aspx?DonVi=" + session .User.ma_dviqly+ "&DenNgay=" + cmbDenNgay.Value + "&TuNgay=" + cmbTuNgay.Value + "&Thang=" + cmbThang.Value + "&Nam=" + cmbNam.Value + "&Loai=13");

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
            Response.Redirect("../Report/Report.aspx?DenNgay=" + cmbDenNgay.Value + "&TuNgay=" + cmbTuNgay.Value + "&Thang=" + cmbThang.Value + "&Nam=" + cmbNam.Value + "&Loai=13");
        }


    }
}