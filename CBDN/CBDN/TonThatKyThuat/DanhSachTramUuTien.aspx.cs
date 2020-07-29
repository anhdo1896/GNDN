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
    public partial class DanhSachTramUuTien : BasePage
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
            LoadTramUT();
        }

       
        protected void btnAdd_Click(object sender, EventArgs e)
        {
            MTCSYT.SYS_Session session = (MTCSYT.SYS_Session)Session["SYS_Session"];
            string strMadviqly = session.User.ma_dviqlyDN;
            List<Object> keyvalues = grdTram.GetSelectedFieldValues("MA_TRAM");
            foreach (object key in keyvalues)
            {

                string matram = key + "";
                if (!CheckName(matram))
                {
                    ScriptManager.RegisterStartupScript(Page, Page.GetType(), "", "alert('Mã trạm bị trùng');", true); return;
                }
                db.INSERT_TTTT_TRAM_UUTIEN(strMadviqly, matram);
            }
            LoadTramUT();
            LoadTram();
            grdTram_UT.Selection.UnselectAll();
            grdTram.Selection.UnselectAll();
            
        }
        private bool CheckName(string Name)
        {
            SYS_Session session = (SYS_Session)Session["SYS_Session"];

            var dt = db.CHECK_TTTT_TRAM_UUTIEN(session.User.ma_dviqlyDN, Name);
            if (dt.Rows.Count > 0)
                return false;
            return true;
        }

        protected void btnRemove_Click(object sender, EventArgs e)
        {
            MTCSYT.SYS_Session session = (MTCSYT.SYS_Session)Session["SYS_Session"];
            string strMadviqly = session.User.ma_dviqlyDN;
            List<Object> keyvalues = grdTram_UT.GetSelectedFieldValues("MATRAM");
            foreach (object key in keyvalues)
            {
                string matram = key + "";
                db.DELETE_TTTT_TRAM_UUTIEN(strMadviqly, matram);
            }
            LoadTramUT();
            LoadTram();
            grdTram_UT.Selection.UnselectAll();
            grdTram.Selection.UnselectAll();
        }
        
        private void LoadTramUT()
        {
            MTCSYT.SYS_Session session = (MTCSYT.SYS_Session)Session["SYS_Session"];
            DataTable dsa = db.SELECT_TTTT_TRAM_UUTIEN(session.User.ma_dviqlyDN);
            if (dsa.Rows.Count > 0)
            {
                btnRemove.Enabled = true;
            }
            else btnRemove.Enabled = false;
            grdTram_UT.DataSource = dsa;
            grdTram_UT.DataBind();
            
        }
       
        private void LoadTram()
        {
           
            MTCSYT.SYS_Session session = (MTCSYT.SYS_Session)Session["SYS_Session"];
            DataTable ds = db.SELECT_TRAM(session.User.ma_dviqlyDN);
            if (ds.Rows.Count > 0)
            {
                btnAdd.Enabled = true;
            }
            else btnAdd.Enabled = false;
            grdTram.DataSource = ds;
            grdTram.DataBind();
            
        }
        protected void ckChua_Init(object sender, EventArgs e)
        {
            ASPxCheckBox chk = sender as ASPxCheckBox;
            ASPxGridView grid = (chk.NamingContainer as GridViewHeaderTemplateContainer).Grid;
            chk.Checked = (grid.Selection.Count == grid.VisibleRowCount);
        }
        protected void ckDa_Init(object sender, EventArgs e)
        {
            ASPxCheckBox chk = sender as ASPxCheckBox;
            ASPxGridView grid = (chk.NamingContainer as GridViewHeaderTemplateContainer).Grid;
            chk.Checked = (grid.Selection.Count == grid.VisibleRowCount);
        }

        protected void cmbRoles_SelectedIndexChanged(object sender, EventArgs e)
        {
            LoadTramUT();
            LoadTram();
        }

        protected void btnSubmit_Click(object sender, EventArgs e)
        {

        }

        protected void btnOK_Click(object sender, EventArgs e)
        {

        }
    }
}