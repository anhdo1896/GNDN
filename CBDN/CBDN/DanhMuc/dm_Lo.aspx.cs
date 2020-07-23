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
    public partial class dm_Lo : BasePage
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
            _DataBind();
            if (!IsPostBack)
                loadDanhMuc();
        }
        private void loadDanhMuc()
        {
            MTCSYT.SYS_Session session = (MTCSYT.SYS_Session)Session["SYS_Session"];
            int ma_dviqly = int.Parse(session.User.ma_dviqly + "");
            var lstDD = db.DM_Trams.Where(x => x.IDMaDviQly == ma_dviqly);
            cmbTram.DataSource = lstDD;
            cmbTram.ValueField = "IDTram";
            cmbTram.TextField = "TenTram";
            cmbTram.DataBind();

        }
        private void _DataBind()
        {
            MTCSYT.SYS_Session session = (MTCSYT.SYS_Session)Session["SYS_Session"];
            int ma_dviqly = int.Parse(session.User.ma_dviqly + "");

            grdDVT.DataSource = db.DM_LoSelectByIDDVi(ma_dviqly).ToList();
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
                CBDN.DM_LoSelectByIDDViResult HoatDong = (CBDN.DM_LoSelectByIDDViResult)grdDVT.GetRow(grdDVT.FocusedRowIndex);
                CBDN.DM_Lo cv = new CBDN.DM_Lo();
                cv = db.DM_Los.SingleOrDefault(x => x.IDMaDViQly == HoatDong.IDTram && x.IDMaDViQly == int.Parse(session.User.ma_dviqly));
                db.DM_Los.DeleteOnSubmit(cv);
                db.SubmitChanges();
                _DataBind();
                ScriptManager.RegisterStartupScript(Page, Page.GetType(), "", "alert('Xoá lộ thành công');", true);
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

            var dt = db.DM_Los.SingleOrDefault(x => x.MaLo == Name && x.IDMaDViQly == int.Parse(session.User.ma_dviqly) && x.IDTram != id);
            if (dt != null)
                return false;
            return true;
        }

        protected void grdDVT_CellEditorInitialize(object sender, ASPxGridViewEditorEventArgs e)
        {
            e.Column.ToString();
            if (e.Column.FieldName == "IDLo")
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
            CBDN.DM_LoSelectByIDDViResult cv = (CBDN.DM_LoSelectByIDDViResult)grdDVT.GetRow(grdDVT.FocusedRowIndex);
            txtMaDuongDat.Text = cv.MaLo;
            txtTenDuongDay.Text = cv.TenLo;
            cmbTram.Value = (int)cv.IDTram;
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
                ScriptManager.RegisterStartupScript(Page, Page.GetType(), "", "alert('Bạn phải chọn trạm');", true);
                return;
            }
            var dmtram = db.DM_Trams.SingleOrDefault(x => x.IDTram == int.Parse(cmbTram.Value + ""));

            if (Session["Add"] + "" == "0")
            {
                CBDN.DM_LoSelectByIDDViResult cv = (CBDN.DM_LoSelectByIDDViResult)grdDVT.GetRow(grdDVT.FocusedRowIndex);

                CBDN.DM_Lo qtCT = db.DM_Los.SingleOrDefault(x => x.IDLo == cv.IDLo);
                if (!CheckName(txtMaDuongDat.Text, cv.IDLo))
                {
                    ScriptManager.RegisterStartupScript(Page, Page.GetType(), "", "alert('Mã lộ không được trùng');", true); return;
                }
                if (txtTenDuongDay.Value + "" == "")
                {
                    ScriptManager.RegisterStartupScript(Page, Page.GetType(), "", "alert('Tên lộ không thể bỏ trống');", true);
                    return;
                }

                //CBDN.DM_Lo qtCT = new CBDN.DM_Lo();
                qtCT.TenLo = txtTenDuongDay.Text;
                qtCT.MoTa = txtmoTa.Text;
                qtCT.IDChiNhanh = dmtram.IDChiNhanh;
                qtCT.IDTram = dmtram.IDTram;
                if (CkHoatDong.Checked)
                    qtCT.HoatDong = 1;
                else
                    qtCT.HoatDong = 0;
                db.SubmitChanges();

            }
            else
            {
                if (txtMaDuongDat.Text + "" == "")
                {
                    ScriptManager.RegisterStartupScript(Page, Page.GetType(), "", "alert('Mã lộ không được để trống');", true);
                    txtMaDuongDat.Focus(); return;
                }
                if (txtTenDuongDay.Text == "")
                {
                    ScriptManager.RegisterStartupScript(Page, Page.GetType(), "", "alert('Tên lộ không được để trống');", true);
                    txtTenDuongDay.Focus(); return;
                }

                if (!CheckName(txtMaDuongDat.Text, 0))
                {
                    ScriptManager.RegisterStartupScript(Page, Page.GetType(), "", "alert('Mã lộ không được trùng');", true); return;
                }


                CBDN.DM_Lo cv = new CBDN.DM_Lo();
                cv.MaLo = txtMaDuongDat.Text;
                cv.IDMaDViQly = int.Parse(session.User.ma_dviqly);
                cv.TenLo = txtTenDuongDay.Text;
                cv.IDChiNhanh = dmtram.IDChiNhanh;
                cv.MoTa = txtmoTa.Text;
                cv.IDTram = dmtram.IDTram;
                if (CkHoatDong.Checked)
                    cv.HoatDong = 1;
                else
                    cv.HoatDong = 0;
                db.DM_Los.InsertOnSubmit(cv);
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