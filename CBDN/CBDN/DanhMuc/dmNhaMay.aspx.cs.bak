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
    public partial class dmNhaMay : BasePage
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
        }
       
        private void _DataBind()
        {
            MTCSYT.SYS_Session session = (MTCSYT.SYS_Session)Session["SYS_Session"];
            int ma_dviqly = int.Parse(session.User.ma_dviqly + "");

            grdDVT.DataSource = db.DM_NhaMays.Where(x => x.IDMADVIQLY == ma_dviqly).ToList();
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
                CBDN.DM_NhaMay HoatDong = (CBDN.DM_NhaMay)grdDVT.GetRow(grdDVT.FocusedRowIndex);
                CBDN.DM_NhaMay cv = new CBDN.DM_NhaMay();
                cv = db.DM_NhaMays.SingleOrDefault(x => x.ID == HoatDong.ID && x.IDMADVIQLY == int.Parse(session.User.ma_dviqly));
                db.DM_NhaMays.DeleteOnSubmit(cv);
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

            var dt = db.DM_NhaMays.SingleOrDefault(x => x.MaNhaMay == Name && x.IDMADVIQLY == int.Parse(session.User.ma_dviqly) && x.ID != id);
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
            CBDN.DM_NhaMay cv = (CBDN.DM_NhaMay)grdDVT.GetRow(grdDVT.FocusedRowIndex);
            txtMaPhong.Text = cv.MaNhaMay;
            txtTenPhong.Text = cv.TenNhaMay;
            txtDiaChi.Text = cv.DiaChi;
            txtSDT.Text = cv.DienThoai;
            txtMota.Text = cv.MoTa;

        }

        protected void btnCapNhat_Click(object sender, EventArgs e)
        {
            SYS_Session session = (SYS_Session)Session["SYS_Session"];
            if (Session["Add"] + "" == "0")
            {
                CBDN.DM_NhaMay cv = (CBDN.DM_NhaMay)grdDVT.GetRow(grdDVT.FocusedRowIndex);
                CBDN.DM_NhaMay qtCT = db.DM_NhaMays.SingleOrDefault(x => x.ID == cv.ID);
                if (!CheckName(txtMaPhong.Text, cv.ID))
                {
                    ScriptManager.RegisterStartupScript(Page, Page.GetType(), "", "alert('Mã nhà máy không được trùng');", true); return;
                }
                if (txtTenPhong.Value + "" == "")
                {
                    ScriptManager.RegisterStartupScript(Page, Page.GetType(), "", "alert('Tên nhà máy không thể bỏ trống');", true);
                    return;
                }

                //CBDN.DM_NhaMay qtCT = new CBDN.DM_NhaMay();
                qtCT.TenNhaMay = txtTenPhong.Text;
                qtCT.DienThoai = txtSDT.Text;
                qtCT.MoTa = txtMota.Text;
                qtCT.DiaChi = txtDiaChi.Text;
                db.SubmitChanges();

            }
            else
            {
                if (txtMaPhong.Text + "" == "")
                {
                    ScriptManager.RegisterStartupScript(Page, Page.GetType(), "", "alert('Mã nhà máy không được để trống');", true);
                    txtMaPhong.Focus(); return;
                }
                if (txtTenPhong.Text == "")
                {
                    ScriptManager.RegisterStartupScript(Page, Page.GetType(), "", "alert('Tên nhà máy không được để trống');", true);
                    txtTenPhong.Focus(); return;
                }

                if (!CheckName(txtMaPhong.Text, 0))
                {
                    ScriptManager.RegisterStartupScript(Page, Page.GetType(), "", "alert('Mã nhà máy không được trùng');", true); return;
                }


                CBDN.DM_NhaMay cv = new CBDN.DM_NhaMay();
                cv.MaNhaMay = txtMaPhong.Text;
                cv.TenNhaMay = txtTenPhong.Text;
                cv.IDMADVIQLY = int.Parse(session.User.ma_dviqly + "");
                cv.DiaChi = txtDiaChi.Text;
                cv.MoTa = txtMota.Text;
                cv.DienThoai = txtSDT.Text;
                db.DM_NhaMays.InsertOnSubmit(cv);
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