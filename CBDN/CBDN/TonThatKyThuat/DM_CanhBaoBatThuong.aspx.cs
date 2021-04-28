using System;
using System.Collections.Generic;
using SystemManageService;
using DevExpress.Web.ASPxTreeList;
using Entity;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Net;
using System.Data;
using DevExpress.Web;
using System.IO;
using CBDN.Class;
namespace MTCSYT
{
    //sCAP_DDIEN
    //sLoaiSoDoCapDien
    //DCS, LM,DT,NR
    public partial class DM_CanhBaoBatThuong : BasePage
    {
        DataAccess.clTTTT db = new DataAccess.clTTTT();
        private const string funcid = "61";
        private SYS_Right rightOfUser = null;
        protected void Page_Load(object sender, EventArgs e)
        {
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

            _DataBind();

        }
        private void _DataBind()
        {
            MTCSYT.SYS_Session session = (MTCSYT.SYS_Session)Session["SYS_Session"];
            var dt = db.SELECT_TTTT_DM_TTKD();
            grdDVT.DataSource = dt;
            grdDVT.DataBind();
        }
        protected void grdDVT_CustomColumnDisplayText(object sender, ASPxGridViewColumnDisplayTextEventArgs e)
        {
            if (e.Column.Caption == "STT")
            {
                e.DisplayText = (e.VisibleRowIndex + 1).ToString();
            }
        }

        private bool CheckName(string Name)
        {
            SYS_Session session = (SYS_Session)Session["SYS_Session"];

            var dt = db.SELECT_CHECK_TTTT_DM_TTKD(Name);

            if (dt.Rows.Count > 0)
                return false;
            return true;
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



        protected void btnCapNhat_Click(object sender, EventArgs e)
        {
            DM_DVQLYService dm_dviSer = new DM_DVQLYService();
            SYS_Session session = (SYS_Session)Session["SYS_Session"];

            if (Session["Add"] + "" == "0")
            {
                var qtCT = (DataRowView)grdDVT.GetRow(grdDVT.FocusedRowIndex);
                db.UPDATE_TTTT_DM_TTKD(txtMA_CANHBAO.Text, txtTT_CANHBAO.Text, txtDX_CANHBAO.Text);

            }
            else
            {
                db.INSERT_TTTT_DM_TTKD(txtMA_CANHBAO.Text, txtTT_CANHBAO.Text, txtDX_CANHBAO.Text);

            }
            pcAddRoles.ShowOnPageLoad = false;
            _DataBind();
        }

        protected void btnDong_Click(object sender, EventArgs e)
        {
            pcAddRoles.ShowOnPageLoad = false;
        }
        protected void grdDVT_HtmlCommandCellPrepared(object sender, ASPxGridViewTableCommandCellEventArgs e)
        {

        }
        protected void grdDVT_RowDeleting(object sender, DevExpress.Web.Data.ASPxDataDeletingEventArgs e)
        {
            try
            {
                SYS_Session session = (SYS_Session)Session["SYS_Session"];
                var HoatDong = (DataRowView)grdDVT.GetRow(grdDVT.FocusedRowIndex);

                db.DELETE_CHECK_TTTT_DM_TTKD(HoatDong["MA_CANHBAO"] + "");


                _DataBind();
                ScriptManager.RegisterStartupScript(Page, Page.GetType(), "", "alert('Xoá loại dây thành công');", true);
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
            Session["Add"] = 0;
            SYS_Session session = (SYS_Session)Session["SYS_Session"];
            var qtCT = (DataRowView)grdDVT.GetRow(grdDVT.FocusedRowIndex);
            txtMA_CANHBAO.Text = qtCT["MA_CANHBAO"] + "";
            txtTT_CANHBAO.Text = qtCT["TT_CANHBAO"] + "";
            txtDX_CANHBAO.Value = qtCT["DX_CANHBAO"] + "";
            txtMA_CANHBAO.Enabled = false;
        }
    }
}