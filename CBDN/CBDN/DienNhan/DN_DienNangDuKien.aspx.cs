using System;
using System.Collections.Generic;
using DevExpress.Web;
using Entity;
using SystemManageService;
using System.Web.UI;
using System.Linq;
using System.Data;
using Aspose.Cells;
namespace MTCSYT
{
    public partial class DN_DienNangDuKien : BasePage
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

            Session["SYS_Session"] = session;

            if (!IsPostBack)
            {

                cmbThang.Value = DateTime.Now.Month;
                cmbNam.Value = DateTime.Now.Year;
                CheckData();

            }
            _DataBind();
        }
        private void CheckData()
        {
            var check = db.DN_TongNhapDienNhans.Where(x => x.Thang == int.Parse(cmbThang.Value + "") && x.Nam == int.Parse(cmbNam.Value + ""));
            if (check.Count() > 0)
            {
                btnLoc.Visible = true;
                btnCreate.Visible = false;
            }
            else
            {
                btnLoc.Visible = false;
                btnCreate.Visible = true;
            }

        }
        private void _DataBind()
        {
            MTCSYT.SYS_Session session = (MTCSYT.SYS_Session)Session["SYS_Session"];
            grdDVT.DataSource = db.DN_DM_NHAPLIEUTONG(0, int.Parse(cmbThang.Value + ""), int.Parse("" + cmbNam.Value)).ToList();
            grdDVT.DataBind();
        }

        protected void grdDVT_CustomColumnDisplayText(object sender, ASPxGridViewColumnDisplayTextEventArgs e)
        {
            if (e.Column.Caption == "STT")
            {
                e.DisplayText = (e.VisibleRowIndex + 1).ToString();
            }
        }

        private bool CheckName(int donvi, int thang, int nam)
        {
            SYS_Session session = (SYS_Session)Session["SYS_Session"];

            var dt = db.TT_KhachHangDAThaps.SingleOrDefault(x => x.IDMA_DVIQLY == donvi && x.Thang == thang && x.Nam == nam);
            if (dt != null)
                return false;
            return true;
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
            Response.Redirect("../Report/Report.aspx?Thang=" + cmbThang.Value + "&Nam=" + cmbNam.Value + "&Loai=4");

        }



        protected void btnLoc_Click(object sender, EventArgs e)
        {
            CheckData();
        }

        protected void grdDVT_RowUpdating(object sender, DevExpress.Web.Data.ASPxDataUpdatingEventArgs e)
        {
            try
            {
                SYS_Session session = (SYS_Session)Session["SYS_Session"];
                CBDN.DN_TongNhapDienNhan cv = new CBDN.DN_TongNhapDienNhan();
                cv = db.DN_TongNhapDienNhans.SingleOrDefault(x => x.ID == int.Parse(e.Keys[0] + ""));
                cv.DienNhanThucTe = int.Parse(e.NewValues[0] + "");
                cv.DN_Thang = int.Parse(e.NewValues[1] + "");
                if (int.Parse(e.NewValues[2] + "") != 0 && cv.NgayDCL1==DateTime.Now.Day)
                {
                    cv.DN_DC_Lan1 = int.Parse(e.NewValues[2] + "");
                    cv.NgayDCLan1 = DateTime.Now;
                    cv.NgayDCL1 = DateTime.Now.Day;
                }
                if (int.Parse(e.NewValues[3] + "") != 0 && cv.NgayDCL2 == DateTime.Now.Day)
                {
                    cv.DN_DC_Lan2 = int.Parse(e.NewValues[3] + "");
                    cv.NgayDCLan2 = DateTime.Now;
                    cv.NgayDCL2 = DateTime.Now.Day;
                }
                if (int.Parse(e.NewValues[4] + "") != 0 && cv.NgayDCL3 == DateTime.Now.Day)
                {
                    cv.NgayDCL3 = DateTime.Now.Day;
                    cv.NgayDCLan3 = DateTime.Now;
                    cv.DN_DC_Lan3 = int.Parse(e.NewValues[4] + "");
                }

                grdDVT.CancelEdit();
                e.Cancel = true;
                db.SubmitChanges();
                _DataBind();
                ScriptManager.RegisterStartupScript(Page, Page.GetType(), "", "alert('Xoá người phụ trách thành công');", true);
            }
            catch (Exception ex)
            { }
            finally
            {
                e.Cancel = true;
            }
        }

        protected void btnCreate_Click(object sender, EventArgs e)
        {
            // tạo dữ liệu tahngs
            try
            {
                db.DN_Create_DienN(0, int.Parse(cmbThang.Value + ""), int.Parse("" + cmbNam.Value));
                ScriptManager.RegisterStartupScript(Page, Page.GetType(), "", "alert('Tạo dữ liệu nhập kế hoạch điện năng theo tháng thành công');", true);
                btnCreate.Visible = false;
                btnLoc.Visible = true;
                _DataBind();
            }
            catch (Exception ex)
            {

            }

        }


    }
}