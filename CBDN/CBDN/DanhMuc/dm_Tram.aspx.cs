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
    public partial class dm_Tram : BasePage
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
            MTCSYT.SYS_Session session = (MTCSYT.SYS_Session)Session["SYS_Session"];
            var lstDD = db.DM_ChiNhanhs.Where(x => x.IDMADVIQLY.Contains(session.User.ma_dviqly + ""));
            cmbDuongDay.DataSource = lstDD;
            cmbDuongDay.ValueField = "ID";
            cmbDuongDay.TextField = "TenChiNhanh";
            cmbDuongDay.DataBind();

        }
        private void _DataBind()
        {
            MTCSYT.SYS_Session session = (MTCSYT.SYS_Session)Session["SYS_Session"];

            grdDVT.DataSource = db.DM_TramSelectByIDDVi(session.User.ma_dviqly + "").ToList();
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
                CBDN.DM_TramSelectByIDDViResult HoatDong = (CBDN.DM_TramSelectByIDDViResult)grdDVT.GetRow(grdDVT.FocusedRowIndex);
                if (HoatDong.MaDVNhap != int.Parse(session.User.ma_dviqly))
                {
                    ScriptManager.RegisterStartupScript(Page, Page.GetType(), "", "alert('Không thể xóa giao nhận này vì không phải đơn vị bạn tạo ra');", true);
                    return;
                }
                CBDN.DM_Tram cv = new CBDN.DM_Tram();
                cv = db.DM_Trams.SingleOrDefault(x => x.IDTram == cv.IDTram && x.IDChiNhanh == cv.IDChiNhanh);
                db.DM_Trams.DeleteOnSubmit(cv);
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


        private bool CheckName(string Name, int id, string idPhuongThuc)
        {
            SYS_Session session = (SYS_Session)Session["SYS_Session"];

            var dt = db.DM_Trams.SingleOrDefault(x => x.MaTram == Name &&  x.IDTram != id && x.IDChiNhanh == idPhuongThuc);
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
            CBDN.DM_TramSelectByIDDViResult cv = (CBDN.DM_TramSelectByIDDViResult)grdDVT.GetRow(grdDVT.FocusedRowIndex);
            txtMaDuongDat.Text = cv.MaTram;
            txtTenDuongDay.Text = cv.TenTram;
            cmbDuongDay.Value = cv.IDChiNhanh;
            cmbDuongDay.Text = cv.TenChiNhanh;
            if (cv.HoatDong == 1)
                CkHoatDong.Checked = true;
            else
                CkHoatDong.Checked = false;
            txtmoTa.Text = cv.MoTa;
            //txtDiaChi.Value = cv.DiaDiem;
        }

        protected void btnCapNhat_Click(object sender, EventArgs e)
        {
            SYS_Session session = (SYS_Session)Session["SYS_Session"];
            if (Session["Add"] + "" == "0")
            {
                CBDN.DM_TramSelectByIDDViResult cv = (CBDN.DM_TramSelectByIDDViResult)grdDVT.GetRow(grdDVT.FocusedRowIndex);
                //var lst = db.DM_Trams.Where(x => x.MaTram == cv.MaTram && x.IDChiNhanh==cv.IDChiNhanh);

                if (cmbDuongDay.Value + "" == "")
                {
                    ScriptManager.RegisterStartupScript(Page, Page.GetType(), "", "alert('Bạn phải chọn phương thức giao nhận');", true);
                    return;
                }
                if (!CheckName(txtMaDuongDat.Text, cv.IDTram, cmbDuongDay.Value + ""))
                {
                    ScriptManager.RegisterStartupScript(Page, Page.GetType(), "", "alert('Mã trạm không được trùng');", true); return;
                }
                if (txtTenDuongDay.Value + "" == "")
                {
                    ScriptManager.RegisterStartupScript(Page, Page.GetType(), "", "alert('Tên trạm không thể bỏ trống');", true);
                    return;
                }
                CBDN.DM_Tram qtCT = db.DM_Trams.Single(x => x.IDTram == cv.IDTram);
                //foreach (var qtCT in lst)
                //{
                    qtCT.TenTram = txtTenDuongDay.Text;
                    qtCT.MoTa = txtmoTa.Text;
                    qtCT.DiaDiem = "";
                    if (cmbDuongDay.Value + "" != "")
                    {
                        qtCT.IDChiNhanh = cmbDuongDay.Value + "";
                    }
                    else
                    {
                        qtCT.IDChiNhanh = "";
                        qtCT.IDDuongDay = 0;
                    }
                    if (CkHoatDong.Checked)
                        qtCT.HoatDong = 1;
                    else
                        qtCT.HoatDong = 0;
                    db.SubmitChanges();

                //}

                //CBDN.DM_Tram qtCT = new CBDN.DM_Tram();


            }
            else
            {
                if (txtMaDuongDat.Text + "" == "")
                {
                    ScriptManager.RegisterStartupScript(Page, Page.GetType(), "", "alert('Mã trạm không được để trống');", true);
                    txtMaDuongDat.Focus(); return;
                }
                if (txtTenDuongDay.Text == "")
                {
                    ScriptManager.RegisterStartupScript(Page, Page.GetType(), "", "alert('Tên trạm không được để trống');", true);
                    txtTenDuongDay.Focus(); return;
                }

                if (!CheckName(txtMaDuongDat.Text, 0, cmbDuongDay.Value + ""))
                {
                    ScriptManager.RegisterStartupScript(Page, Page.GetType(), "", "alert('Mã trạm không được trùng');", true); return;
                }

                var cn = db.DM_ChiNhanhs.SingleOrDefault(x => x.ID ==int.Parse( cmbDuongDay.Value+"") && x.IDMADVIQLY.Contains(session.User.ma_dviqly));
                //var lstDD = db.DM_ChiNhanhs.Where(x => x.MaChiNhanh == cn.MaChiNhanh);
                //foreach (var dd in lstDD)
                //{
                    CBDN.DM_Tram cv = new CBDN.DM_Tram();
                    cv.MaTram = txtMaDuongDat.Text;
                    cv.IDMaDviQly = cn.IDMADVIQLY;
                    cv.TenTram = txtTenDuongDay.Text;
                    cv.MoTa = txtmoTa.Text;
                    cv.TinhChatDD = int.Parse(cmbTinhChat.Value + "");
                    cv.DiaDiem = "";
                    if (cmbDuongDay.Value + "" != "")
                    {
                        cv.IDDuongDay = cn.ID;
                        cv.IDChiNhanh =  cn.ID+"";
                    }
                    else
                    {
                        cv.IDDuongDay = 0;
                        cv.IDChiNhanh = "";
                    }
                    if (CkHoatDong.Checked)
                        cv.HoatDong = 1;
                    else
                        cv.HoatDong = 0;
                    cv.MaDVNhap = int.Parse(session.User.ma_dviqly);
                    db.DM_Trams.InsertOnSubmit(cv);
                    db.SubmitChanges();

                //}

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