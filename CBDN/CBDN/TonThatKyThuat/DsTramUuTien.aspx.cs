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
    public partial class DsTramUuTien : BasePage
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
            LoadKH();
        }


        protected void btnThem_Click(object sender, EventArgs e)
        {

            var thang = cmbThang.Value;
            var nam = cmbNam.Value;
            MTCSYT.SYS_Session session = (MTCSYT.SYS_Session)Session["SYS_Session"];
            DataTable ds = db.SELECT_TRAM_HATHE_UT_TT_DS(session.User.ma_dviqlyDN, thang + "", nam + "");
            grdKH.DataSource = ds;
            grdKH.DataBind();
        }
        private void LoadKH()
        {
            if (cmbThang.Value == null && cmbNam.Value == null)
            {
                int thang = DateTime.Now.Month - 1;
                int nam = DateTime.Now.Year;
                cmbThang.Value = thang;
                cmbNam.Value = nam;
                MTCSYT.SYS_Session session = (MTCSYT.SYS_Session)Session["SYS_Session"];
                DataTable ds = db.SELECT_TRAM_HATHE_UT_TT_DS(session.User.ma_dviqlyDN, thang + "", nam + "");
                grdKH.DataSource = ds;
                grdKH.DataBind();
            }
            else
            {
                var thang = cmbThang.Value;
                var nam = cmbNam.Value;
                MTCSYT.SYS_Session session = (MTCSYT.SYS_Session)Session["SYS_Session"];
                DataTable ds = db.SELECT_TRAM_HATHE_UT_TT_DS(session.User.ma_dviqlyDN, thang + "", nam + "");
                grdKH.DataSource = ds;
                grdKH.DataBind();
            }    

        }

        protected void btnXemChiTiet_Click(object sender, EventArgs e)
        {
            var cv = (DataRowView)grdKH.GetRow(grdKH.FocusedRowIndex);
            if (cv != null)
            {
                string ma_dviqly = cv["MA_DVIQLY"] + "";
                string ma_tram = cv["MA_TRAM"] + "";
                string Thang = cmbThang.Value + "";
                string Nam = cmbNam.Value + "";
                Response.Redirect("../TonThatKyThuat/TonThatTramUuTien.aspx?MA_QVIQLY=" + ma_dviqly + "&MA_TRAM=" + ma_tram + "" + "&THANG=" + Thang + "&NAM=" + Nam);
            }
            LoadKH();
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
            if (e.Column.FieldName == "MA_TRAM")
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
