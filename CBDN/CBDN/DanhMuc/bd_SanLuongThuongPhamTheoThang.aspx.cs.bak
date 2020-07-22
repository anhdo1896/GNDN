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
namespace MTCSYT
{
    public partial class bd_SanLuongThuongPhamTheoThang : BasePage
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
            txtThang.Text = DateTime.Now.Month + "";
            txtNam.Text = DateTime.Now.Year + "";

        }
        private void _DataBind()
        {
            MTCSYT.SYS_Session session = (MTCSYT.SYS_Session)Session["SYS_Session"];
            grdDVT.DataSource = db.HD_SanLuongThuongPhams.Where(x => x.IDMaDviQly == int.Parse(session.User.ma_dviqly + "")).ToList();
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
                CBDN.HD_SanLuongThuongPham HoatDong = (CBDN.HD_SanLuongThuongPham)grdDVT.GetRow(grdDVT.FocusedRowIndex);

                CBDN.HD_SanLuongThuongPham cv = new CBDN.HD_SanLuongThuongPham();
                cv = db.HD_SanLuongThuongPhams.SingleOrDefault(x => x.ID == HoatDong.ID);
                db.HD_SanLuongThuongPhams.DeleteOnSubmit(cv);
                db.SubmitChanges();
                _DataBind();
                ScriptManager.RegisterStartupScript(Page, Page.GetType(), "", "alert('Xoá phương thức giao nhận thành công');", true);
            }
            catch (Exception ex)
            { }
            finally
            {
                e.Cancel = true;
            }
        }


        protected void grdDVT_CellEditorInitialize(object sender, ASPxGridViewEditorEventArgs e)
        {
            e.Column.ToString();
            if (e.Column.FieldName == "MaChiNhanh")
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
            CBDN.HD_SanLuongThuongPham cv = (CBDN.HD_SanLuongThuongPham)grdDVT.GetRow(grdDVT.FocusedRowIndex);
            txtThang.Text = cv.Thang + "";
            txtNam.Value = cv.Nam + "";
            txtSanLuongDien.Text = cv.SLuongThuongPham + "";

        }
        private bool checkTrung(int thang, int nam, int IDDonVi)
        {
            var check = db.HD_SanLuongThuongPhams.Where(x => x.Nam == nam && x.Thang == thang && x.IDMaDviQly == IDDonVi);
            if (check.Count() > 0)
                return false;
            return true;
        }
        protected void btnCapNhat_Click(object sender, EventArgs e)
        {
            DM_DVQLYService dm_dviSer = new DM_DVQLYService();
            SYS_Session session = (SYS_Session)Session["SYS_Session"];
            decimal test = 0;
            if (!decimal.TryParse(txtSanLuongDien.Text + "", out test))
            {
                ScriptManager.RegisterStartupScript(Page, Page.GetType(), "", "alert('Sản lượng thương phẩm là kiểu số');", true);
                txtSanLuongDien.Focus(); return;
            }
            if (Session["Add"] + "" == "0")
            {
                CBDN.HD_SanLuongThuongPham qtCT = (CBDN.HD_SanLuongThuongPham)grdDVT.GetRow(grdDVT.FocusedRowIndex);

                CBDN.HD_SanLuongThuongPham cn = db.HD_SanLuongThuongPhams.SingleOrDefault(x => x.ID == qtCT.ID);

                cn.SLuongThuongPham = decimal.Parse(txtSanLuongDien.Text);
                cn.Thang = int.Parse(txtThang.Text);
                cn.Nam = int.Parse(txtNam.Text);
                db.SubmitChanges();
            }
            else
            {
                if (!checkTrung(int.Parse(txtNam.Text), int.Parse(txtThang.Text), int.Parse(session.User.ma_dviqly)))
                {
                    ScriptManager.RegisterStartupScript(Page, Page.GetType(), "", "alert('Đã có sản lượng thương phẩm tháng này không thể thêm được.');", true); return;
                }

                CBDN.HD_SanLuongThuongPham cv = new CBDN.HD_SanLuongThuongPham();
                cv.Thang = int.Parse(txtThang.Text);
                cv.Nam = int.Parse(txtNam.Text);
                cv.NgayNhap = DateTime.Now;
                cv.IDMaDviQly = int.Parse(session.User.ma_dviqly);
                cv.SLuongThuongPham = decimal.Parse(txtSanLuongDien.Text);
                db.HD_SanLuongThuongPhams.InsertOnSubmit(cv);
                db.SubmitChanges();
            }
            pcAddRoles.ShowOnPageLoad = false;
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