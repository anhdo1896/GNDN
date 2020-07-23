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
    public partial class dm_TramLo : BasePage
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

        private void loadPhuongThuc()
        {
            MTCSYT.SYS_Session session = (MTCSYT.SYS_Session)Session["SYS_Session"];
            //if (int.Parse(TreeListOrganization.FocusedNode.Key + "") == 0)
            //{
                var lstDD = db.DM_ChiNhanhs.Where(x => x.IDMADVIQLY.Contains("," + session.User.ma_dviqly + ","));
                cmbDuongDay.DataSource = lstDD;
            //}
            //else
            //{
            //    int idTram = int.Parse(db.DM_Trams.SingleOrDefault(x => x.IDTram == int.Parse(TreeListOrganization.FocusedNode.Key + "")).IDChiNhanh);
            //    var lstDD = db.DM_ChiNhanhs.Where(x => x.IDMADVIQLY.Contains("," + session.User.ma_dviqly + ",") && x.ID == idTram);
            //    cmbDuongDay.DataSource = lstDD;
            //}


            cmbDuongDay.ValueField = "ID";
            cmbDuongDay.TextField = "TenChiNhanh";
            cmbDuongDay.DataBind();



        }
        private void _DataBind()
        {
            MTCSYT.SYS_Session session = (MTCSYT.SYS_Session)Session["SYS_Session"];

            TreeListOrganization.DataSource = db.DM_TramSelectByIDDVi(session.User.ma_dviqly + "").ToList();
            TreeListOrganization.DataBind();
            TreeListOrganization.ExpandToLevel(1);
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

        }


        private bool CheckName(string Name, int id, string idPhuongThuc)
        {
            SYS_Session session = (SYS_Session)Session["SYS_Session"];

            var dt = db.DM_Trams.SingleOrDefault(x => x.MaTram == Name && x.IDTram != id && x.IDChiNhanh == idPhuongThuc);
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
            loadPhuongThuc();
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
            loadPhuongThuc();
            SYS_Session session = (SYS_Session)Session["SYS_Session"];
            CBDN.DM_Tram tram = db.DM_Trams.SingleOrDefault(x => x.IDTram == int.Parse(TreeListOrganization.FocusedNode.Key + ""));
            txtMaDuongDat.Text = tram.MaTram;
            txtTenDuongDay.Text = tram.TenTram;
            cmbDuongDay.Value = tram.IDChiNhanh;
            cmbDuongDay.Text = db.DM_ChiNhanhs.SingleOrDefault(x => x.ID == int.Parse(tram.IDChiNhanh)).TenChiNhanh;
            cmbCDA.Value = tram.TinhChatDD;
           
            if (tram.TinhChatDD == 0)
                cmbCDA.Text = "550 kV";
            else if (tram.TinhChatDD == 0)
                cmbCDA.Text = "220 kV";
            else if (tram.TinhChatDD == 0)
                cmbCDA.Text = "110 kV";
            else if (tram.TinhChatDD == 0)
                cmbCDA.Text = "350 kV";
            else if (tram.TinhChatDD == 0)
                cmbCDA.Text = "22 kV";
            else
                if (tram.TinhChatDD == 0)
                    cmbCDA.Text = "10 kV";
                else if (tram.TinhChatDD == 0)
                    cmbCDA.Text = "6 kV";
                else cmbCDA.Text = "0.4 kV";


            cmbTinhChat.Value = tram.IsLo;
            if (tram.IsLo == 0)
                cmbTinhChat.Text = "Trạm";
            else
                cmbTinhChat.Text = "Lộ";
            if (tram.HoatDong == 1)
                CkHoatDong.Checked = true;
            else
                CkHoatDong.Checked = false;
            txtmoTa.Text = tram.MoTa;
            //txtDiaChi.Value = cv.DiaDiem;
        }

        protected void btnCapNhat_Click(object sender, EventArgs e)
        {
            SYS_Session session = (SYS_Session)Session["SYS_Session"];
            if (cmbDuongDay.Value + "" == "")
            {
                ScriptManager.RegisterStartupScript(Page, Page.GetType(), "", "alert('Bạn phải chọn phương thức giao nhận');", true);
                return;
            }
           
            if (txtTenDuongDay.Value + "" == "")
            {
                ScriptManager.RegisterStartupScript(Page, Page.GetType(), "", "alert('Tên trạm không thể bỏ trống');", true);
                return;
            }
            var cn = db.DM_ChiNhanhs.SingleOrDefault(x => x.ID == int.Parse(cmbDuongDay.Value + "") && x.IDMADVIQLY.Contains(session.User.ma_dviqly));
            if (Session["Add"] + "" == "0")
            {
                CBDN.DM_Tram HoatDong = db.DM_Trams.SingleOrDefault(x => x.IDTram == int.Parse(TreeListOrganization.FocusedNode.Key + ""));
                //var lst = db.DM_Trams.Where(x => x.MaTram == cv.MaTram && x.IDChiNhanh==cv.IDChiNhanh);

                if (!CheckName(txtMaDuongDat.Text, HoatDong.IDTram, cmbDuongDay.Value + ""))
                {
                    ScriptManager.RegisterStartupScript(Page, Page.GetType(), "", "alert('Mã trạm không được trùng');", true); return;
                }

                CBDN.DM_Tram qtCT = db.DM_Trams.Single(x => x.IDTram == HoatDong.IDTram);
                //foreach (var qtCT in lst)
                //{

                qtCT.IDMaDviQly = cn.IDMADVIQLY;
                
                qtCT.MaTram = txtMaDuongDat.Text;
                qtCT.TenTram = txtTenDuongDay.Text;
                qtCT.MoTa = txtmoTa.Text;
                qtCT.DiaDiem = "";
                //qtCT.ParentId = int.Parse(TreeListOrganization.FocusedNode.Key + "");
                qtCT.IsLo = int.Parse("" + cmbTinhChat.Value);
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

              
            }
            else
            {
               
                if (!CheckName(txtMaDuongDat.Text, 0, cmbDuongDay.Value + ""))
                {
                    ScriptManager.RegisterStartupScript(Page, Page.GetType(), "", "alert('Mã trạm không được trùng');", true); return;
                }

              
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
                    cv.IDChiNhanh = cn.ID + "";
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
                cv.ParentId = int.Parse(TreeListOrganization.FocusedNode.Key + "");
                cv.IsLo = int.Parse("" + cmbTinhChat.Value);
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

        protected void TreeListOrganization_NodeDeleting(object sender, DevExpress.Web.Data.ASPxDataDeletingEventArgs e)
        {
            try
            {
                SYS_Session session = (SYS_Session)Session["SYS_Session"];

                CBDN.DM_Tram HoatDong = db.DM_Trams.SingleOrDefault(x => x.IDTram == int.Parse(e.Keys["IDTram"] + ""));
                if (HoatDong.MaDVNhap != int.Parse(session.User.ma_dviqly))
                {
                    ScriptManager.RegisterStartupScript(Page, Page.GetType(), "", "alert('Không thể xóa trạm lộ này vì không phải đơn vị bạn tạo ra');", true);
                    return;
                }
                var check = db.DM_DiemDos.Where(x => x.IDTram == HoatDong.IDTram + "");
                if(check.Count()>0)
                {
                    ScriptManager.RegisterStartupScript(Page, Page.GetType(), "", "alert('Không thể xóa trạm lộ này vì có điểm đo đang hoạt động ');", true);
                    return;
                }
                CBDN.DM_Tram cv = new CBDN.DM_Tram();
                cv = db.DM_Trams.SingleOrDefault(x => x.IDTram == HoatDong.IDTram);
                db.DM_Trams.DeleteOnSubmit(cv);
                db.SubmitChanges();
                _DataBind();
                ScriptManager.RegisterStartupScript(Page, Page.GetType(), "", "alert('Xoá danh mục thành công');", true);
            }
            catch (Exception ex)
            { }
            finally
            {
                e.Cancel = true;
            }
        }

    }
}