using System;
using System.Collections.Generic;
using DevExpress.Web;
using Entity;
using SystemManageService;
using System.Web.UI;
using System.Linq;
using System.Data;
namespace MTCSYT
{
    public partial class dm_DiemDo : BasePage
    {
        CBDN.DB_CBDNDataContext db = new CBDN.DB_CBDNDataContext(new CBDN.ADOController().strcn());
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
            if (!IsPostBack)

                loadDanhMuc();

        }
        private void loadDanhMuc()
        {
            MTCSYT.SYS_Session session = (MTCSYT.SYS_Session)Session["SYS_Session"];
            //int ma_dviqly = int.Parse();
            var lstDD = db.DM_Trams.Where(x => x.IDMaDviQly.Contains(session.User.ma_dviqly + ""));
            cmbTram.DataSource = lstDD;
            cmbTram.ValueField = "IDTram";
            cmbTram.TextField = "TenTram";
            cmbTram.DataBind();

        }
        private void _DataBind()
        {
            MTCSYT.SYS_Session session = (MTCSYT.SYS_Session)Session["SYS_Session"];

            grdDVT.DataSource = db.DM_DiemDoSelectByIDDVi(session.User.ma_dviqly + "").ToList();
            grdDVT.DataBind();
        }

        protected void grdDVT_CustomColumnDisplayText(object sender, ASPxGridViewColumnDisplayTextEventArgs e)
        {
            if (e.Column.Caption == "STT")
            {
                e.DisplayText = (e.VisibleRowIndex + 1).ToString();
            }
        }

        protected void grdDVT_RowDeleting(object sender, DevExpress.Web.Data.ASPxDataDeletingEventArgs e)
        {
            try
            {
                SYS_Session session = (SYS_Session)Session["SYS_Session"];
                CBDN.DM_DiemDoSelectByIDDViResult HoatDong = (CBDN.DM_DiemDoSelectByIDDViResult)grdDVT.GetRow(grdDVT.FocusedRowIndex);
                if (HoatDong.MaDviNhap != int.Parse(session.User.ma_dviqly))
                {
                    ScriptManager.RegisterStartupScript(Page, Page.GetType(), "", "alert('Không thể xóa giao nhận này vì không phải đơn vị bạn tạo ra');", true);
                    return;
                }
                CBDN.DM_DiemDo cv = new CBDN.DM_DiemDo();
                cv = db.DM_DiemDos.SingleOrDefault(x => x.IDDiemDo == cv.IDDiemDo && x.IDTram == cv.IDTram && x.IDChiNhanh == cv.IDChiNhanh);
                db.DM_DiemDos.DeleteOnSubmit(cv);
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


        private bool CheckName(string Name, string id)
        {
            SYS_Session session = (SYS_Session)Session["SYS_Session"];

            var dt = db.DM_DiemDos.SingleOrDefault(x => x.MaDiemDo == Name && x.IDMaDViQly.Contains(session.User.ma_dviqly) && x.IDTram != id);
            if (dt != null)
                return false;
            return true;
        }

        protected void grdDVT_CellEditorInitialize(object sender, ASPxGridViewEditorEventArgs e)
        {
            e.Column.ToString();
            if (e.Column.FieldName == "IDDiemDo")
                e.Editor.Focus();
        }

        protected void btnThem_Click(object sender, EventArgs e)
        {
            pcAddRoles.ShowOnPageLoad = true;
            Session["Add"] = 1;
        }

        protected void grdDVT_StartRowEditing(object sender, DevExpress.Web.Data.ASPxStartRowEditingEventArgs e)
        {
            (sender as ASPxGridView).GetRowValuesByKeyValue(e.EditingKeyValue);

        }

        protected void grdDVT_CellEditorInitialize1(object sender, ASPxGridViewEditorEventArgs e)
        {

        }

        protected void btnSua_Click(object sender, EventArgs e)
        {
            pcAddRoles.ShowOnPageLoad = true;
            Session["Add"] = 0;
            SYS_Session session = (SYS_Session)Session["SYS_Session"];
            CBDN.DM_DiemDoSelectByIDDViResult cv = (CBDN.DM_DiemDoSelectByIDDViResult)grdDVT.GetRow(grdDVT.FocusedRowIndex);
            txtMaDuongDat.Text = cv.MaDiemDo;
            txtTenDuongDay.Text = cv.TenDiemDo;
            cmbLoaiDD.Value = cv.ISLoaiDD;
            cmbTinhChat.Value = cv.TinhChatDD;
            cmbTinhChat.Text = cv.strTinhChat;
            cmbTram.Value = cv.IDTram;
            cmbTram.Text = cv.TenTram;
            if (cv.HoatDong == 1)
                CkHoatDong.Checked = true;
            else
                CkHoatDong.Checked = false;
            txtmoTa.Text = cv.MoTa;
        }

        protected void btnCapNhat_Click(object sender, EventArgs e)
        {
            SYS_Session session = (SYS_Session)Session["SYS_Session"];
            if (cmbTram.Value + "" == "")
            {
                ScriptManager.RegisterStartupScript(Page, Page.GetType(), "", "alert('Trạm không được để trống');", true);
                return;
            }
            if (txtMaDuongDat.Text + "" == "")
            {
                ScriptManager.RegisterStartupScript(Page, Page.GetType(), "", "alert('Mã Điểm đo không được để trống');", true);
                txtMaDuongDat.Focus(); return;
            }
            if (txtTenDuongDay.Text == "")
            {
                ScriptManager.RegisterStartupScript(Page, Page.GetType(), "", "alert('Tên Điểm đo không được để trống');", true);
                txtTenDuongDay.Focus(); return;
            }


            if (Session["Add"] + "" == "0")
            {
                CBDN.DM_DiemDoSelectByIDDViResult cv = (CBDN.DM_DiemDoSelectByIDDViResult)grdDVT.GetRow(grdDVT.FocusedRowIndex);
                //var lst = db.DM_DiemDos.Where(x => x.MaDiemDo == cv.MaDiemDo && x.MaDviNhap == int.Parse(session.User.ma_dviqly) && x.IDTram == cv.IDTram && x.IDChiNhanh == cv.IDChiNhanh).ToList();
                CBDN.DM_DiemDo qtCT = db.DM_DiemDos.SingleOrDefault(x => x.IDDiemDo == cv.IDDiemDo);
                //foreach (var qtCT in lst)
                //{
                if (!CheckName(txtMaDuongDat.Text, cv.MaDiemDo))
                {
                    ScriptManager.RegisterStartupScript(Page, Page.GetType(), "", "alert('Mã Điểm đo không được trùng');", true); return;
                }


                //CBDN.DM_DiemDo qtCT = new CBDN.DM_DiemDo();
                qtCT.TinhChatDD = int.Parse(cmbTinhChat.Value + "");
                qtCT.ISLoaiDD = int.Parse(cmbLoaiDD.Value + "");
                qtCT.TenDiemDo = txtTenDuongDay.Text;
                qtCT.MoTa = txtmoTa.Text;
                if (CkHoatDong.Checked)
                    qtCT.HoatDong = 1;
                else
                    qtCT.HoatDong = 0;
                db.SubmitChanges();
                //}


            }
            else
            {
                if (!CheckName(txtMaDuongDat.Text, ""))
                {
                    ScriptManager.RegisterStartupScript(Page, Page.GetType(), "", "alert('Mã Điểm đo không được trùng');", true); return;
                }
                var tr = db.DM_Trams.SingleOrDefault(x => x.IDTram ==int.Parse( cmbTram.Value + "") && x.IDMaDviQly.Contains(","+session.User.ma_dviqly+","));
                //var lst = db.DM_Trams.Where(x => x.MaTram == cmbTram.Value + "" && x.MaDVNhap == int.Parse(session.User.ma_dviqly)).ToList();
                //foreach (var tr in lst)
                //{
                    CBDN.DM_DiemDo cv = new CBDN.DM_DiemDo();
                    cv.MaDiemDo = txtMaDuongDat.Text;
                    cv.IDMaDViQly = tr.IDMaDviQly;
                    cv.TenDiemDo = txtTenDuongDay.Text;
                    cv.MoTa = txtmoTa.Text;
                    cv.IDChiNhanh = tr.IDChiNhanh;
                    cv.IDTram = tr.IDTram+"";
                    cv.TinhChatDD = int.Parse(cmbTinhChat.Value + "");
                    cv.ISLoaiDD = int.Parse(cmbLoaiDD.Value + "");
                    if (CkHoatDong.Checked)
                        cv.HoatDong = 1;
                    else
                        cv.HoatDong = 0;
                    cv.MaDviNhap = int.Parse(session.User.ma_dviqly);
                    db.DM_DiemDos.InsertOnSubmit(cv);
                    db.SubmitChanges();
                //}


            }
            _DataBind();
            pcAddRoles.ShowOnPageLoad = false;
        }

        protected void btnDong_Click(object sender, EventArgs e)
        {
            pcAddRoles.ShowOnPageLoad = false;
        }

        protected void cmbPhongBan_SelectedIndexChanged(object sender, EventArgs e)
        {
            _DataBind();
        }

        protected void grdDVT_HtmlCommandCellPrepared(object sender, ASPxGridViewTableCommandCellEventArgs e)
        {

        }

    }
}