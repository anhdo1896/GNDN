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
    public partial class dmChiNhanh : BasePage
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

            MTCSYT.SYS_Session session = (MTCSYT.SYS_Session)Session["SYS_Session"];
            int ma_dviqly = int.Parse(session.User.ma_dviqly + "");
            var lst_dmdv = dm_dviSer.DM_DVQLY_SelectByLever(ma_dviqly, 2);

            cmbCuoiNguon.DataSource = lst_dmdv;
            cmbCuoiNguon.ValueField = "IDMA_DVIQLY";
            cmbCuoiNguon.TextField = "TEN_DVIQLY";
            cmbCuoiNguon.DataBind();


        }
        private void _DataBind()
        {
            MTCSYT.SYS_Session session = (MTCSYT.SYS_Session)Session["SYS_Session"];
            grdDVT.DataSource = db.DM_ChiNhanhSelectByIDDVi(session.User.ma_dviqly + "", false).ToList();
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
                if (HoatDong.DiemDauNguon != int.Parse(session.User.ma_dviqly))
                {
                    ScriptManager.RegisterStartupScript(Page, Page.GetType(), "", "alert('Không thể xóa giao nhận này vì không phải đơn vị bạn tạo ra');", true);
                    return;
                }
                var check = db.DM_Trams.Where(x => x.IDChiNhanh == HoatDong.ID + "");
                if (check.Count()>0)
                {
                    ScriptManager.RegisterStartupScript(Page, Page.GetType(), "", "alert('Không thể xóa giao nhận này vì có trạm đang hoạt động ');", true);
                    return;
                }
                CBDN.DM_ChiNhanh cv = new CBDN.DM_ChiNhanh();
                cv = db.DM_ChiNhanhs.SingleOrDefault(x => x.ID == HoatDong.ID && x.IDMADVIQLY.Contains(session.User.ma_dviqly));
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

            var dt = db.DM_ChiNhanhs.SingleOrDefault(x => x.MaChiNhanh == Name && x.IDMADVIQLY.Contains(session.User.ma_dviqly) && x.ID != id);
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
            cmbCuoiNguon.Value = (int)cv.DiemCuoiNguon;
            if (cv.HoatDong == 1)
                CkHoatDong.Checked = true;
            else
                CkHoatDong.Checked = false;
            txtmoTa.Text = cv.MoTa;
            cmbLoaiPhuongThuc.Value = cv.LoaiPhuongThuc + "";
            cmbLoaiPhuongThuc.Text = cv.strLoaiPhuongThuc;
        }

        protected void btnCapNhat_Click(object sender, EventArgs e)
        {
            DM_DVQLYService dm_dviSer = new DM_DVQLYService();
            SYS_Session session = (SYS_Session)Session["SYS_Session"];
            string dvdaunguon = dm_dviSer.SelectDM_DVQLY(int.Parse(session.User.ma_dviqly)).MA_DVIQLY;
            string dvcuoinguon = dm_dviSer.SelectDM_DVQLY(int.Parse(cmbCuoiNguon.Value + "")).MA_DVIQLY;
            if (Session["Add"] + "" == "0")
            {
                CBDN.DM_ChiNhanhSelectByIDDViResult qtCT = (CBDN.DM_ChiNhanhSelectByIDDViResult)grdDVT.GetRow(grdDVT.FocusedRowIndex);
                //var lst = db.DM_ChiNhanhs.Where(x => x.MaChiNhanh == cv.MaChiNhanh);
                //foreach (var qtCT in lst)
                //{
                CBDN.DM_ChiNhanh cn = db.DM_ChiNhanhs.SingleOrDefault(x => x.ID == qtCT.ID);
                if (!CheckName(txtMaDuongDat.Text, qtCT.ID))
                {
                    ScriptManager.RegisterStartupScript(Page, Page.GetType(), "", "alert('Mã phương thức giao nhận được trùng');", true); return;
                }

                cn.TenChiNhanh = txtmoTa.Text;
                cn.LoaiPhuongThuc = int.Parse(cmbLoaiPhuongThuc.Value + "");
                cn.MoTa = txtmoTa.Text;
                if (CkHoatDong.Checked)
                    cn.HoatDong = 1;
                else
                    cn.HoatDong = 0;
                db.SubmitChanges();
                //}


            }
            else
            {
                if (txtMaDuongDat.Text + "" == "")
                {
                    ScriptManager.RegisterStartupScript(Page, Page.GetType(), "", "alert('Mã chi nhánh không được để trống');", true);
                    txtMaDuongDat.Focus(); return;
                }
                //if (txtTenDuongDay.Text == "")
                //{
                //    ScriptManager.RegisterStartupScript(Page, Page.GetType(), "", "alert('Tên chi nhánh không được để trống');", true);
                //    txtTenDuongDay.Focus(); return;
                //}

                if (!CheckName(txtMaDuongDat.Text, 0))
                {
                    ScriptManager.RegisterStartupScript(Page, Page.GetType(), "", "alert('Mã chi nhánh không được trùng');", true); return;
                }

                CBDN.DM_ChiNhanh cv = new CBDN.DM_ChiNhanh();
                cv.TenChiNhanh = txtmoTa.Text;
                cv.MaChiNhanh = dvdaunguon + "_" + dvcuoinguon;
                if (session.User.ma_dviqly != "" + cmbCuoiNguon.Value)
                {
                    cv.IDMADVIQLY = "," + session.User.ma_dviqly + "," + cmbCuoiNguon.Value + ",";
                }
                else
                    cv.IDMADVIQLY = session.User.ma_dviqly;
                cv.LoaiPhuongThuc = int.Parse(cmbLoaiPhuongThuc.Value + "");
                cv.MoTa = txtmoTa.Text;
                cv.DiemDauNguon = int.Parse(session.User.ma_dviqly);
                cv.DiemCuoiNguon = int.Parse(cmbCuoiNguon.Value + "");
                if (CkHoatDong.Checked)
                    cv.HoatDong = 1;
                else
                    cv.HoatDong = 0;
                db.DM_ChiNhanhs.InsertOnSubmit(cv);
                db.SubmitChanges();


                //CBDN.DM_ChiNhanh cnGiaoNhan = new CBDN.DM_ChiNhanh();
                //cnGiaoNhan.TenChiNhanh = txtmoTa.Text;
                //cnGiaoNhan.MaChiNhanh = dvdaunguon + "_" + dvcuoinguon;
                //cnGiaoNhan.IDMADVIQLY = int.Parse(cmbCuoiNguon.Value + "");
                //cnGiaoNhan.MoTa = txtmoTa.Text;
                //cnGiaoNhan.DiemCuoiNguon = int.Parse(session.User.ma_dviqly);
                //cnGiaoNhan.DiemDauNguon = int.Parse(cmbCuoiNguon.Value + "");
                //if (CkHoatDong.Checked)
                //    cnGiaoNhan.HoatDong = 1;
                //else
                //    cnGiaoNhan.HoatDong = 0;
                //db.DM_ChiNhanhs.InsertOnSubmit(cnGiaoNhan);
                //db.SubmitChanges();
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

        protected void cmbCuoiNguon_SelectedIndexChanged(object sender, EventArgs e)
        {
            SYS_Session session = (SYS_Session)Session["SYS_Session"];
            DM_DVQLYService dm_dviSer = new DM_DVQLYService();
            var dvDN = dm_dviSer.SelectDM_DVQLY(int.Parse(session.User.ma_dviqly));
            var dvChon = dm_dviSer.SelectDM_DVQLY(int.Parse(cmbCuoiNguon.Value + ""));
            txtMaDuongDat.Text = dvDN.MA_DVIQLY + "_" + dvChon.MA_DVIQLY;
        }

    }
}