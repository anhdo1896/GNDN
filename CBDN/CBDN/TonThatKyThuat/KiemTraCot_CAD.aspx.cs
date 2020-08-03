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
  
        public partial class KiemTramCot_CAD : BasePage
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
                LoadTram();
            LoadTramCMIS();
            LoadTramCAD();
        }


            protected void btnKiemTra_Click(object sender, EventArgs e)
            {
            LoadTramCAD();
            LoadTramCMIS();
        }

        private bool CheckName(string Name)
            {
                SYS_Session session = (SYS_Session)Session["SYS_Session"];

                var dt = db.CHECK_TTTT_TRAM_CAD_CHECK(session.User.ma_dviqlyDN, Name);
                if (dt.Rows.Count > 0)
                    return true ;
                return false;
            }
        private void LoadTram()
            {

                MTCSYT.SYS_Session session = (MTCSYT.SYS_Session)Session["SYS_Session"];
                DataTable ds = db.SELECT_TTTT_TRAM_CAD(session.User.ma_dviqlyDN);
                grdTram.DataSource = ds;
                grdTram.DataBind();

            }
        private void LoadTramCMIS()
        {
            var cv = (DataRowView)grdTram.GetRow(grdTram.FocusedRowIndex);
            MTCSYT.SYS_Session session = (MTCSYT.SYS_Session)Session["SYS_Session"];
            string strMadviqly = session.User.ma_dviqlyDN;
            string matram = cv["MATRAM"] + "";
            DataTable ds = db.CHECK_TTTT_TRAM_CAD_CHECK(strMadviqly, matram);
            grdTramCMIS.DataSource = ds;
            grdTramCMIS.DataBind();
        }

        private void LoadTramCAD()
        {
            var cv = (DataRowView)grdTram.GetRow(grdTram.FocusedRowIndex);
            MTCSYT.SYS_Session session = (MTCSYT.SYS_Session)Session["SYS_Session"];
            string strMadviqly = session.User.ma_dviqlyDN;
            string matram = cv["MATRAM"] + "";
            DataTable dst = db.CHECK_TTTT_TRAM_CAD_CHECK_CAD_CMIS(strMadviqly, matram);
            grdTramCAD.DataSource = dst;
            grdTramCAD.DataBind();
        }
      
        protected void grdTram_CustomColumnDisplayText(object sender, ASPxGridViewColumnDisplayTextEventArgs e)
        {
            if (e.Column.Caption == "STT")
            {
                e.DisplayText = (e.VisibleRowIndex + 1).ToString();
            }
        }
        protected void grdTramCAD_CustomColumnDisplayText(object sender, ASPxGridViewColumnDisplayTextEventArgs e)
        {
            if (e.Column.Caption == "STT")
            {
                e.DisplayText = (e.VisibleRowIndex + 1).ToString();
            }
        }
        protected void grdTramCMIS_CustomColumnDisplayText(object sender, ASPxGridViewColumnDisplayTextEventArgs e)
        {
            if (e.Column.Caption == "STT")
            {
                e.DisplayText = (e.VisibleRowIndex + 1).ToString();
            }
        }

        protected void grdTram_CellEditorInitialize(object sender, ASPxGridViewEditorEventArgs e)
        {
            e.Column.ToString();
            if (e.Column.FieldName == "MATRAM")
                e.Editor.Focus();
        }

        protected void grdTram_StartRowEditing(object sender, DevExpress.Web.Data.ASPxStartRowEditingEventArgs e)
        {
            (sender as ASPxGridView).GetRowValuesByKeyValue(e.EditingKeyValue);

        }

        protected void grdTram_CellEditorInitialize1(object sender, ASPxGridViewEditorEventArgs e)
        {

        }
        protected void grdTram_HtmlCommandCellPrepared(object sender, ASPxGridViewTableCommandCellEventArgs e)
        {

        }
        protected void grdTramCAD_StartRowEditing(object sender, DevExpress.Web.Data.ASPxStartRowEditingEventArgs e)
        {
            (sender as ASPxGridView).GetRowValuesByKeyValue(e.EditingKeyValue);

        }

        protected void grdTramCAD_CellEditorInitialize1(object sender, ASPxGridViewEditorEventArgs e)
        {

        }
        protected void grdTramCAD_HtmlCommandCellPrepared(object sender, ASPxGridViewTableCommandCellEventArgs e)
        {

        }
        protected void grdTramCMIS_StartRowEditing(object sender, DevExpress.Web.Data.ASPxStartRowEditingEventArgs e)
        {
            (sender as ASPxGridView).GetRowValuesByKeyValue(e.EditingKeyValue);

        }

        protected void grdTramCMIS_CellEditorInitialize1(object sender, ASPxGridViewEditorEventArgs e)
        {

        }
        protected void grdTramCMIS_HtmlCommandCellPrepared(object sender, ASPxGridViewTableCommandCellEventArgs e)
        {

        }
    }
    }
