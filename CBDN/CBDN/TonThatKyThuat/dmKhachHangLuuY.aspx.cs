using System;
using System.Collections.Generic;
using DevExpress.Web;
using Entity;
using SystemManageService;
using System.Web.UI;
using System.Linq;
using System.Data;
using MTCSYT;
using System.IO;
using System.Web.UI.HtmlControls;

namespace CBDN.TonThatKyThuat
{
    public partial class dmKhachHangUuTien : BasePage
    {
        DataAccess.clTTTT db = new DataAccess.clTTTT();
        private const string funcid = "58";
        private SYS_Right rightOfUser = null;
        protected void Page_Load(object sender, EventArgs e)
        {
            #region PhanQuyen
            MTCSYT.SYS_Session session = (MTCSYT.SYS_Session)Session["SYS_Session"];
            if (session == null || session.User.USERNAME == "Guest")
            {
                Response.Redirect("~\\Login.aspx");
            }
            else if (session.XacNhanPass == 0)
            {
                ScriptManager.RegisterStartupScript(this, this.GetType(), "alertMessage", "alert('Mật Khẩu Không Hợp Lệ. Yêu Cầu Đổi Mật Khẩu'); window.location='" +
                Request.ApplicationPath + "HeThong/ChangePassword.aspx';", true);
            }
            else if (session.DatePass > 90)
            {
                ScriptManager.RegisterStartupScript(this, this.GetType(), "alertMessage", "alert('Mật Khẩu Quá 90 Ngày. Yêu Cầu Đổi Mật Khẩu'); window.location='" +
                Request.ApplicationPath + "HeThong/ChangePassword.aspx';", true);
            }
            Session["SYS_Session"] = session;
            #endregion
            LoadKH();
        }


        protected void btnRemove_Click(object sender, EventArgs e)
        {
            MTCSYT.SYS_Session session = (MTCSYT.SYS_Session)Session["SYS_Session"];
            string strMadviqly = session.User.ma_dviqlyDN;
            var cv = (DataRowView)grdKH.GetRow(grdKH.FocusedRowIndex);
            string ma_tram = cv["MA_TRAM"] + "";
            string ma_khang = cv["MA_KHANG"] + "";
            db.DELETE_TTTT_KHACHHANG_LUUY(strMadviqly, ma_khang);
            LoadKH();
            grdKH.Selection.UnselectAll();

        }
        private void LoadKH()
        {

            MTCSYT.SYS_Session session = (MTCSYT.SYS_Session)Session["SYS_Session"];
            DataTable ds = db.SELECT_TTTT_KHACHHANG_LUUY(session.User.ma_dviqlyDN);
            grdKH.DataSource = ds;
            grdKH.DataBind();

        }

        protected void btnXemChiTiet_Click(object sender, EventArgs e)
        {
            var cv = (DataRowView)grdKH.GetRow(grdKH.FocusedRowIndex);
                string ma_tram = cv["MA_TRAM"] + "";
                string ma_khang = cv["MA_KHANG"] + "";
                Response.Redirect("../TonThatKyThuat/dmKhachHang_CT.aspx?MA_TRAM=" + ma_tram + "&MA_KHANG=" + ma_khang + "");

        }
        protected void cmbRoles_SelectedIndexChanged(object sender, EventArgs e)
        {
            LoadKH();
        }

        protected void btnSubmit_Click(object sender, EventArgs e)
        {

        }

        protected void btnOK_Click(object sender, EventArgs e)
        {

        }
        protected void grdKH_CustomColumnDisplayText(object sender, ASPxGridViewColumnDisplayTextEventArgs e)
        {
            if (e.Column.Caption == "STT")
            {
                e.DisplayText = (e.VisibleRowIndex + 1).ToString();
            }
        }

        protected void grdKH_CellEditorInitialize(object sender, ASPxGridViewEditorEventArgs e)
        {
            e.Column.ToString();
            if (e.Column.FieldName == "MA_KHANG")
                e.Editor.Focus();
        }

        protected void grdKH_StartRowEditing(object sender, DevExpress.Web.Data.ASPxStartRowEditingEventArgs e)
        {
            (sender as ASPxGridView).GetRowValuesByKeyValue(e.EditingKeyValue);

        }

        protected void grdKH_CellEditorInitialize1(object sender, ASPxGridViewEditorEventArgs e)
        {

        }
        protected void grdKH_HtmlCommandCellPrepared(object sender, ASPxGridViewTableCommandCellEventArgs e)
        {

        }
    }
}
