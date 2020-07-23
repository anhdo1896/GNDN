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
    public partial class DM_GiaoNhanKhac : BasePage
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

            grdDVT.DataSource = db.DM_ChiNhanhSelectByIDDVi(ma_dviqly, true).ToList();
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
                CBDN.DM_ChiNhanhSelectByIDDViResult HoatDong = (CBDN.DM_ChiNhanhSelectByIDDViResult)grdDVT.GetRow(grdDVT.FocusedRowIndex);
                CBDN.DM_ChiNhanh cv = new CBDN.DM_ChiNhanh();
                cv = db.DM_ChiNhanhs.SingleOrDefault(x => x.ID == HoatDong.ID && x.IDMADVIQLY == int.Parse(session.User.ma_dviqly));
                db.DM_ChiNhanhs.DeleteOnSubmit(cv);
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


        private bool CheckName(string Name, int id)
        {
            SYS_Session session = (SYS_Session)Session["SYS_Session"];

            var dt = db.DM_ChiNhanhs.SingleOrDefault(x => x.MaChiNhanh == Name && x.IDMADVIQLY == int.Parse(session.User.ma_dviqly) && x.ID != id);
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
            CBDN.DM_ChiNhanhSelectByIDDViResult cv = (CBDN.DM_ChiNhanhSelectByIDDViResult)grdDVT.GetRow(grdDVT.FocusedRowIndex);
            txtMaDuongDat.Text = cv.MaChiNhanh;
            if (cv.HoatDong == 1)
                CkHoatDong.Checked = true;
            else
                CkHoatDong.Checked = false;
            txtmoTa.Text = cv.MoTa;
            cmbloaiGiaoNhan.Value = cv.LoaiGiaoNhan;
        }

        protected void btnCapNhat_Click(object sender, EventArgs e)
        {
            DM_DVQLYService dm_dviSer = new DM_DVQLYService();
            SYS_Session session = (SYS_Session)Session["SYS_Session"];
            string dvdaunguon = dm_dviSer.SelectDM_DVQLY(int.Parse(session.User.ma_dviqly)).MA_DVIQLY;
            if (Session["Add"] + "" == "0")
            {
                CBDN.DM_ChiNhanhSelectByIDDViResult cv = (CBDN.DM_ChiNhanhSelectByIDDViResult)grdDVT.GetRow(grdDVT.FocusedRowIndex);
                var lst = db.DM_ChiNhanhs.Where(x => x.MaChiNhanh == cv.MaChiNhanh);
                foreach (var qtCT in lst)
                {
                    if (!CheckName(txtMaDuongDat.Text, cv.ID))
                    {
                        ScriptManager.RegisterStartupScript(Page, Page.GetType(), "", "alert('Mã phương thức giao nhận được trùng');", true); return;
                    }

                    qtCT.TenChiNhanh = txtmoTa.Text;
                    qtCT.MoTa = txtmoTa.Text;
                    if (CkHoatDong.Checked)
                        qtCT.HoatDong = 1;
                    else
                        qtCT.HoatDong = 0;
                    db.SubmitChanges();
                }


            }
            else
            {
                if (txtMaDuongDat.Text + "" == "")
                {
                    ScriptManager.RegisterStartupScript(Page, Page.GetType(), "", "alert('Mã chi nhánh không được để trống');", true);
                    txtMaDuongDat.Focus(); return;
                }

                if (!CheckName(txtMaDuongDat.Text, 0))
                {
                    ScriptManager.RegisterStartupScript(Page, Page.GetType(), "", "alert('Mã chi nhánh không được trùng');", true); return;
                }

                CBDN.DM_ChiNhanh cv = new CBDN.DM_ChiNhanh();
                cv.TenChiNhanh = txtmoTa.Text;
                cv.MaChiNhanh = txtMaDuongDat.Text;
                cv.IDMADVIQLY = int.Parse(session.User.ma_dviqly);
                cv.MoTa = txtmoTa.Text;
                cv.DiemDauNguon = int.Parse(session.User.ma_dviqly);
                cv.DiemCuoiNguon = int.Parse(session.User.ma_dviqly);
                if (CkHoatDong.Checked)
                    cv.HoatDong = 1;
                else
                    cv.HoatDong = 0;
                cv.ISNhaMay = true;
                cv.LoaiNhaMay = int.Parse(cmbloaiGiaoNhan.Value + "");
                db.DM_ChiNhanhs.InsertOnSubmit(cv);
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