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
    public partial class dmNguoiPhuTrach : BasePage
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
            if (!IsPostBack)
                loadDanhMuc();
        }
        private void loadDanhMuc()
        {
            DM_DVQLYService dm_dviSer = new DM_DVQLYService();
            DataTable lst_dmdv = new DataTable();
            MTCSYT.SYS_Session session = (MTCSYT.SYS_Session)Session["SYS_Session"];
            int ma_dviqly = int.Parse(session.User.ma_dviqly + "");
            var donvi = dm_dviSer.SelectDM_DVQLY(ma_dviqly);

            if (donvi.ParentId == 0 || donvi.ParentId == 61)
            {
                lst_dmdv = dm_dviSer.SelectAll_DVI_ByChild(ma_dviqly);
                cmbMaDonVi.DataSource = lst_dmdv;
                cmbMaDonVi.ValueField = "IDMA_DVIQLY";
                cmbMaDonVi.TextField = "NAME_DVIQLY";
                cmbMaDonVi.DataBind();
            }
            else
            {
                List<Entity.DM_DVQLY> lst = new List<DM_DVQLY>();
                lst.Add(donvi);
                cmbMaDonVi.DataSource = lst;
                cmbMaDonVi.ValueField = "IDMA_DVIQLY";
                cmbMaDonVi.TextField = "NAME_DVIQLY";
                cmbMaDonVi.DataBind();
            }

        }
        private void _DataBind()
        {
            MTCSYT.SYS_Session session = (MTCSYT.SYS_Session)Session["SYS_Session"];
            int ma_dviqly = int.Parse(session.User.ma_dviqly + "");

            grdDVT.DataSource = db.DM_NguoiPhuTrachSelectByIDDVi(ma_dviqly).ToList();
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
                CBDN.DM_NguoiPhuTrachSelectByIDDViResult HoatDong = (CBDN.DM_NguoiPhuTrachSelectByIDDViResult)grdDVT.GetRow(grdDVT.FocusedRowIndex);
                CBDN.DM_PhuTrachDuongDay cv = new CBDN.DM_PhuTrachDuongDay();
                cv = db.DM_PhuTrachDuongDays.SingleOrDefault(x => x.ID == HoatDong.ID && x.IDDonVi == int.Parse(session.User.ma_dviqly));
                db.DM_PhuTrachDuongDays.DeleteOnSubmit(cv);
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


        private bool CheckName(string Name, int id)
        {
            SYS_Session session = (SYS_Session)Session["SYS_Session"];

            var dt = db.DM_PhuTrachDuongDays.SingleOrDefault(x => x.MaNhanVien == Name && x.IDDonVi == int.Parse(session.User.ma_dviqly) && x.ID != id);
            if (dt != null)
                return false;
            return true;
        }

        protected void grdDVT_CellEditorInitialize(object sender, ASPxGridViewEditorEventArgs e)
        {
            e.Column.ToString();
            if (e.Column.FieldName == "IDCanBo")
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
            CBDN.DM_NguoiPhuTrachSelectByIDDViResult cv = (CBDN.DM_NguoiPhuTrachSelectByIDDViResult)grdDVT.GetRow(grdDVT.FocusedRowIndex);
            txtMaPhong.Text = cv.MaNhanVien;
            txtTenPhong.Text = cv.TenNhanVien;
            txtDiaChi.Text = cv.DiaChi;
            txtSDT.Text = cv.DienThoai;
            cmbMaDonVi.Value = cv.IDDonVi;
            txtChucVu.Value = cv.ChucVu;
        }

        protected void btnCapNhat_Click(object sender, EventArgs e)
        {
            SYS_Session session = (SYS_Session)Session["SYS_Session"];
            if (Session["Add"] + "" == "0")
            {
                CBDN.DM_NguoiPhuTrachSelectByIDDViResult cv = (CBDN.DM_NguoiPhuTrachSelectByIDDViResult)grdDVT.GetRow(grdDVT.FocusedRowIndex);
                CBDN.DM_PhuTrachDuongDay tinhtrang = db.DM_PhuTrachDuongDays.SingleOrDefault(x => x.ID == cv.ID);
                if (!CheckName(txtMaPhong.Text, cv.ID))
                {
                    ScriptManager.RegisterStartupScript(Page, Page.GetType(), "", "alert('Mã cán bộ không được trùng');", true); return;
                }
                if (txtTenPhong.Value + "" == "")
                {
                    ScriptManager.RegisterStartupScript(Page, Page.GetType(), "", "alert('Tên cán bộ không thể bỏ trống');", true);
                    return;
                }

                //CBDN.DM_PhuTrachDuongDay qtCT = new CBDN.DM_PhuTrachDuongDay();
                tinhtrang.TenNhanVien = txtTenPhong.Text;
                tinhtrang.DienThoai = txtSDT.Text;
                tinhtrang.ChucVu = txtChucVu.Text;
                tinhtrang.DiaChi = txtDiaChi.Text;
                db.SubmitChanges();

            }
            else
            {
                if (txtMaPhong.Text + "" == "")
                {
                    ScriptManager.RegisterStartupScript(Page, Page.GetType(), "", "alert('Mã cán bộ không được để trống');", true);
                    txtMaPhong.Focus(); return;
                }
                if (txtTenPhong.Text == "")
                {
                    ScriptManager.RegisterStartupScript(Page, Page.GetType(), "", "alert('Tên cán bộ không được để trống');", true);
                    txtTenPhong.Focus(); return;
                }

                if (!CheckName(txtMaPhong.Text, 0))
                {
                    ScriptManager.RegisterStartupScript(Page, Page.GetType(), "", "alert('Mã cán bộ không được trùng');", true); return;
                }


                CBDN.DM_PhuTrachDuongDay cv = new CBDN.DM_PhuTrachDuongDay();
                cv.MaNhanVien = txtMaPhong.Text;
                cv.TenNhanVien = txtTenPhong.Text;
                cv.IDDonVi = int.Parse(cmbMaDonVi.Value + "");
                cv.DiaChi = txtDiaChi.Text;
                cv.ChucVu = txtChucVu.Text;
                cv.DienThoai = txtSDT.Text;
                db.DM_PhuTrachDuongDays.InsertOnSubmit(cv);
                db.SubmitChanges();

            }
            _DataBind();
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