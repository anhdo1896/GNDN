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
using Aspose.Cells;
namespace MTCSYT
{
    public partial class DM_DiemDoLienKet : BasePage
    {
        CBDN.DB_CBDNDataContext db = new CBDN.DB_CBDNDataContext(new CBDN.ADOController().strcn());
        private SYS_Right rightOfUser = null;
        private const string funcid = "57";
        private Cells _range;
        private Worksheet _exSheet;
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

            Session["SYS_Session"] = session;


            _DataBind();
        }

        private void _DataBind()
        {
            MTCSYT.SYS_Session session = (MTCSYT.SYS_Session)Session["SYS_Session"];
            grdDVT.DataSource = db.DM_DiemDoLienKet(int.Parse(session.User.ma_dviqly)).ToList();
            grdDVT.DataBind();
        }

        protected void grdDVT_CustomColumnDisplayText(object sender, ASPxGridViewColumnDisplayTextEventArgs e)
        {
            if (e.Column.Caption == "STT")
            {
                e.DisplayText = (e.VisibleRowIndex + 1).ToString();
            }
        }

        protected void grdDVT_CellEditorInitialize(object sender, ASPxGridViewEditorEventArgs e)
        {
            e.Column.ToString();
            if (e.Column.FieldName == "MaChiNhanh")
                e.Editor.Focus();
        }

        protected void grdDVT_StartRowEditing(object sender, DevExpress.Web.Data.ASPxStartRowEditingEventArgs e)
        {
            (sender as ASPxGridView).GetRowValuesByKeyValue(e.EditingKeyValue);

        }

        protected void grdDVT_CellEditorInitialize1(object sender, ASPxGridViewEditorEventArgs e)
        {

        }
        protected void cmbPhongBan_SelectedIndexChanged(object sender, EventArgs e)
        {
            _DataBind();
        }

        protected void grdDVT_HtmlCommandCellPrepared(object sender, ASPxGridViewTableCommandCellEventArgs e)
        {

        }

        protected void btnXuat_Click(object sender, EventArgs e)
        {
            // Response.Redirect("../Report/Report.aspx?Thang=" + cmbThang.Value + "&Nam=" + cmbNam.Value + "&Loai=4");

        }
        protected void btnLoc_Click(object sender, EventArgs e)
        {
            //  CheckData();
        }

        protected void grdDVT_RowUpdating(object sender, DevExpress.Web.Data.ASPxDataUpdatingEventArgs e)
        {
            try
            {
                SYS_Session session = (SYS_Session)Session["SYS_Session"];
                CBDN.DM_DiemDo ddo = db.DM_DiemDos.SingleOrDefault(x => x.IDDiemDo == int.Parse(e.Keys[0] + ""));
                CBDN.DM_DVQLY dv = db.DM_DVQLies.SingleOrDefault(c => c.IDMA_DVIQLY == ddo.MaDviNhap);
                CBDN.HD_DiemDoLienKet cv = db.HD_DiemDoLienKets.SingleOrDefault(x => x.MaDiemDo == ddo.MaDiemDo);
                if (cv == null)
                {
                    CBDN.HD_DiemDoLienKet ddoLK = new CBDN.HD_DiemDoLienKet();
                    ddoLK.DDo = e.NewValues[0] + "";
                    ddoLK.Nguon = e.NewValues[1] + "";
                    ddoLK.MaDiemDo = ddo.MaDiemDo;
                    ddoLK.IDMaDVIQLY = ddo.MaDviNhap;
                    ddoLK.MaDDVIQLY = dv.MA_DVIQLY;
                    ddoLK.IsChieuGiao = (bool)e.NewValues["IsChieuGiao"];
                    ddoLK.IsChieuNhan = (bool)e.NewValues["IsChieuNhan"];
                    ddoLK.IsDaoChieu = (bool)e.NewValues["IsDaoChieu"];
                    ddoLK.Nhan =decimal.Parse( e.NewValues["Nhan"]+"");
                    ddoLK.Chia = decimal.Parse(e.NewValues["Chia"] + "");
                    db.HD_DiemDoLienKets.InsertOnSubmit(ddoLK);
                    db.SubmitChanges();
                }
                else
                {
                    //CBDN.HD_DiemDoLienKet ddoLK = db.HD_DiemDoLienKets.SingleOrDefault(x => x.MaDiemDo == cv.MaDiemDo);
                    cv.DDo = e.NewValues[0] + "";
                    cv.Nguon = e.NewValues[1] + "";
                    cv.IsChieuGiao = (bool)e.NewValues["IsChieuGiao"];
                    cv.IsChieuNhan = (bool)e.NewValues["IsChieuNhan"];
                    cv.IsDaoChieu = (bool)e.NewValues["IsDaoChieu"];
                    cv.Nhan = decimal.Parse(e.NewValues["Nhan"] + "");
                    cv.Chia = decimal.Parse(e.NewValues["Chia"] + "");
                    // ddoLK.MaDiemDo = e.NewValues[0] + "";
                    db.SubmitChanges();

                }
                grdDVT.CancelEdit();
                e.Cancel = true;
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

        protected void btnSua_Click(object sender, EventArgs e)
        {
            pcAddRoles.ShowOnPageLoad = true;
            SYS_Session session = (SYS_Session)Session["SYS_Session"];
            CBDN.DM_DiemDoLienKetResult cv = (CBDN.DM_DiemDoLienKetResult)grdDVT.GetRow(grdDVT.FocusedRowIndex);
            lbdodiem.Text = cv.MaDiemDo;
            txtMaDiemDoLK.Text = cv.DDo;
            txtNguon.Text = cv.Nguon;
            ckGiao.Checked = (bool)cv.IsChieuGiao;
            CkNhan.Checked = (bool)cv.IsChieuNhan;        
        }

        protected void btnDong_Click(object sender, EventArgs e)
        {
            pcAddRoles.ShowOnPageLoad = false;
        }

        protected void btnCapNhat_Click(object sender, EventArgs e)
        {
            try
            {
                SYS_Session session = (SYS_Session)Session["SYS_Session"];
                CBDN.DM_DiemDoLienKetResult lk = (CBDN.DM_DiemDoLienKetResult)grdDVT.GetRow(grdDVT.FocusedRowIndex);
                CBDN.DM_DiemDo ddo = db.DM_DiemDos.SingleOrDefault(x => x.IDDiemDo == lk.IDDiemDo);
                CBDN.DM_DVQLY dv = db.DM_DVQLies.SingleOrDefault(c => c.IDMA_DVIQLY == ddo.MaDviNhap);
                CBDN.HD_DiemDoLienKet cv = db.HD_DiemDoLienKets.SingleOrDefault(x => x.MaDiemDo == ddo.MaDiemDo);
                if (cv == null)
                {
                    CBDN.HD_DiemDoLienKet ddoLK = new CBDN.HD_DiemDoLienKet();
                    ddoLK.DDo = txtMaDiemDoLK.Text;
                    ddoLK.Nguon = txtNguon.Text;
                    ddoLK.MaDiemDo = ddo.MaDiemDo;
                    ddoLK.IDMaDVIQLY = ddo.MaDviNhap;
                    ddoLK.MaDDVIQLY = dv.MA_DVIQLY;
                    ddoLK.IsChieuGiao = ckGiao.Checked;
                    ddoLK.IsChieuNhan = CkNhan.Checked;
                    ddoLK.IsDaoChieu = ckDaoChieu.Checked;
                    db.HD_DiemDoLienKets.InsertOnSubmit(ddoLK);
                    db.SubmitChanges();
                }
                else
                {
                    //CBDN.HD_DiemDoLienKet ddoLK = db.HD_DiemDoLienKets.SingleOrDefault(x => x.MaDiemDo == cv.MaDiemDo);
                    cv.DDo = txtMaDiemDoLK.Text;
                    cv.Nguon = txtNguon.Text;
                    cv.IsChieuGiao = ckGiao.Checked;
                    cv.IsChieuNhan = CkNhan.Checked;
                    cv.IsDaoChieu = ckDaoChieu.Checked;
                    // ddoLK.MaDiemDo = e.NewValues[0] + "";
                    db.SubmitChanges();

                }
                db.SubmitChanges();
                _DataBind();
                ScriptManager.RegisterStartupScript(Page, Page.GetType(), "", "alert('Cập nhật dữ liệu thành công');", true);
            }
            catch (Exception ex)
            { }
            finally
            {
            }
        }


    }
}