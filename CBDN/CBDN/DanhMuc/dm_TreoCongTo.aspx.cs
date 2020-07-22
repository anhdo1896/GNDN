using System;
using System.Collections.Generic;
using SystemManageService;
using DevExpress.Web.ASPxTreeList;
using Entity;
using System.Linq;
using System.Web.UI;
using System.Data;
using System.IO;
using System.Xml;
using System.Text;
namespace MTCSYT
{
    public partial class dm_TreoCongTo : BasePage
    {
        CBDN.DB_CBDNDataContext db = new CBDN.DB_CBDNDataContext(new CBDN.ADOController().strcn());
        private const string funcid = "103";
        private SYS_Right rightOfUser = null;
        protected void Page_Load(object sender, EventArgs e)
        {
            #region PhanQuyen
            MTCSYT.SYS_Session session = (MTCSYT.SYS_Session)Session["SYS_Session"];
            if (session == null || session.User.USERNAME == "Guest")
            {
                Response.Redirect("~\\Login.aspx");
            }
            //else
            //{
            //    if (Request.Cookies["IDUSER"].Value != "1")
            //    {
            //        List<SYS_Right> right = session.User.Rights;
            //        foreach (SYS_Right sysRight in right)
            //        {
            //            if (sysRight.FuncId == funcid)
            //            {
            //                rightOfUser = sysRight;
            //                Session["Right"] = sysRight;
            //                Session["UserId"] = session.User.IDUSER;
            //                Session["FunctionId"] = sysRight.FuncId;
            //                break;
            //            }
            //        }

            //        if (rightOfUser == null)
            //        {
            //            Session["Status"] = "0";
            //            Response.Redirect("~\\HeThong\\Default.aspx");

            //        }
            //    }
            //}
            Session["SYS_Session"] = session;
            #endregion


            loadDSNgay();
            //if (IsCallback)
            //{
            loadKH();
            // _DataBidCongTo();
            // }
        }
        private void loadDSNgay()
        {
            MTCSYT.SYS_Session session = (MTCSYT.SYS_Session)Session["SYS_Session"];
            var lstDD = db.DM_Trams.Where(x => x.IDMaDviQly.Contains("," + session.User.ma_dviqly + ","));
            tlMucTin.DataSource = lstDD;
            tlMucTin.DataBind();
        }

        protected void grdCN_Callback(object sender, EventArgs e)
        {

        }


        private void loadKH()
        {
            MTCSYT.SYS_Session session = (MTCSYT.SYS_Session)Session["SYS_Session"];
            if (tlMucTin.FocusedNode == null) return;
            var ddo = db.DM_DiemDoSelectByIDDVi(session.User.ma_dviqly + "").ToList().Where(x => x.IDTram == tlMucTin.FocusedNode.Key + "").ToList();
            if (ddo.Count > 0)
            {
                grdCN.DataSource = ddo;
                grdCN.DataBind();
            }
            else
            {
                grdCN.DataSource = null;
                grdCN.DataBind();
            }


        }
        protected void grdCN_CustomCallback(object sender, DevExpress.Web.ASPxGridViewCustomCallbackEventArgs e)
        {
            loadKH();
        }


        protected void grdCN_CustomColumnDisplayText(object sender, DevExpress.Web.ASPxGridViewColumnDisplayTextEventArgs e)
        {
            if (e.Column.Caption == "STT")
            {
                e.DisplayText = (e.VisibleRowIndex + 1).ToString();
            }
        }

        protected void btnThem_Click(object sender, EventArgs e)
        {
            pcAddRoles.ShowOnPageLoad = true;
            Session["Add"] = 1;
        }

        protected void btnSua_Click(object sender, EventArgs e)
        {
            pcAddRoles.ShowOnPageLoad = true;
            Session["Add"] = 0;
            SYS_Session session = (SYS_Session)Session["SYS_Session"];
            CBDN.DM_DiemDoSelectByIDDViResult cv = (CBDN.DM_DiemDoSelectByIDDViResult)grdCN.GetRow(grdCN.FocusedRowIndex);
            txtMaDuongDat.Text = cv.MaDiemDo;
            txtTenDuongDay.Text = cv.TenDiemDo;
            cmbLoaiDD.Value = cv.ISLoaiDD;
            cmbTinhChat.Value = cv.TinhChatDD;
            cmbTinhChat.Text = cv.strTinhChat;
            if (cv.HoatDong == 1)
                CkHoatDong.Checked = true;
            else
                CkHoatDong.Checked = false;
            txtmoTa.Text = cv.MoTa;
        }
        private bool CheckName(string Name, int id, string IDTram, string IDChiNhanh)
        {
            SYS_Session session = (SYS_Session)Session["SYS_Session"];

            var dt = db.DM_DiemDos.SingleOrDefault(x => x.MaDiemDo == Name && x.IDTram != IDTram && x.IDChiNhanh != IDChiNhanh && x.IDDiemDo != id);
            if (dt != null)
                return false;
            return true;
        }
        protected void btnCapNhat_Click(object sender, EventArgs e)
        {
            SYS_Session session = (SYS_Session)Session["SYS_Session"];

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
                CBDN.DM_DiemDoSelectByIDDViResult cv = (CBDN.DM_DiemDoSelectByIDDViResult)grdCN.GetRow(grdCN.FocusedRowIndex);
                //var lst = db.DM_DiemDos.Where(x => x.MaDiemDo == cv.MaDiemDo && x.MaDviNhap == int.Parse(session.User.ma_dviqly) && x.IDTram == cv.IDTram && x.IDChiNhanh == cv.IDChiNhanh).ToList();
                CBDN.DM_DiemDo qtCT = db.DM_DiemDos.SingleOrDefault(x => x.IDDiemDo == cv.IDDiemDo);
                //foreach (var qtCT in lst)
                //{
                if (!CheckName(txtMaDuongDat.Text, cv.IDDiemDo, cv.IDTram, cv.IDChiNhanh))
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
                var tr = db.DM_Trams.SingleOrDefault(x => x.IDTram == int.Parse(tlMucTin.FocusedNode.Key) && x.IDMaDviQly.Contains("," + session.User.ma_dviqly + ","));

                if (!CheckName(txtMaDuongDat.Text, 0, tr.IDTram + "", tr.IDChiNhanh + ""))
                {
                    ScriptManager.RegisterStartupScript(Page, Page.GetType(), "", "alert('Mã Điểm đo không được trùng');", true); return;
                }
                //var lst = db.DM_Trams.Where(x => x.MaTram == cmbTram.Value + "" && x.MaDVNhap == int.Parse(session.User.ma_dviqly)).ToList();
                //foreach (var tr in lst)
                //{
                CBDN.DM_DiemDo cv = new CBDN.DM_DiemDo();
                cv.MaDiemDo = txtMaDuongDat.Text;
                cv.IDMaDViQly = tr.IDMaDviQly;
                cv.TenDiemDo = txtTenDuongDay.Text;
                cv.MoTa = txtmoTa.Text;
                cv.IDChiNhanh = tr.IDChiNhanh;
                cv.IDTram = tr.IDTram + "";
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
            loadKH();
            pcAddRoles.ShowOnPageLoad = false;
        }

        protected void btnDong_Click(object sender, EventArgs e)
        {
            pcAddRoles.ShowOnPageLoad = false;
        }

        protected void grdCN_RowDeleting(object sender, DevExpress.Web.Data.ASPxDataDeletingEventArgs e)
        {
            try
            {
                SYS_Session session = (SYS_Session)Session["SYS_Session"];
                CBDN.DM_DiemDoSelectByIDDViResult HoatDong = (CBDN.DM_DiemDoSelectByIDDViResult)grdCN.GetRow(grdCN.FocusedRowIndex);
                if (HoatDong.MaDviNhap != int.Parse(session.User.ma_dviqly))
                {
                    ScriptManager.RegisterStartupScript(Page, Page.GetType(), "", "alert('Không thể xóa giao nhận này vì không phải đơn vị bạn tạo ra');", true);
                    return;
                }
                CBDN.DM_DiemDo cv = new CBDN.DM_DiemDo();
                cv = db.DM_DiemDos.SingleOrDefault(x => x.IDDiemDo == HoatDong.IDDiemDo);
                db.DM_DiemDos.DeleteOnSubmit(cv);
                db.SubmitChanges();
                loadKH();
                ScriptManager.RegisterStartupScript(Page, Page.GetType(), "", "alert('Xoá điêm đo thành công');", true);
            }
            catch (Exception ex)
            { }
            finally
            {
                e.Cancel = true;
            }
        }

        protected void btnThemCongTo_Click(object sender, EventArgs e)
        {

        }

        protected void btnSuaCongTo_Click(object sender, EventArgs e)
        {

        }

        protected void grdCN_FocusedRowChanged(object sender, EventArgs e)
        {

        }


    }
}