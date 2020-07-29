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
                LoadTramChecked();
        }


            protected void btnKiemTra_Click(object sender, EventArgs e)
            {
                MTCSYT.SYS_Session session = (MTCSYT.SYS_Session)Session["SYS_Session"];
                string strMadviqly = session.User.ma_dviqlyDN;
                List<Object> keyvalues = grdTram.GetSelectedFieldValues("MATRAM");
                foreach (object key in keyvalues)
                {
                    string matram= key + "";
                if (!CheckName(matram))
                {
                    string trangthai = "OK!";
                    string strDate = DateTime.Now.ToString("dd/MM/yyyy h:mm");
                    db.INSERT_TTTT_TRAM_CAD_CHECK(strMadviqly, matram, trangthai, strDate);
                }
                else
                {
                        string trangthai = "FAIL!";
                        string strDate = DateTime.Now.ToString("dd/MM/yyyy h:mm");
                        db.INSERT_TTTT_TRAM_CAD_CHECK(strMadviqly, matram, trangthai, strDate);
                }

                }
                LoadTram();
                LoadTramChecked();
                grdTram.Selection.UnselectAll();
                grdTramChecked.Selection.UnselectAll();

        }
        protected void btnKiemTraChecked_Click(object sender, EventArgs e)
        {
            MTCSYT.SYS_Session session = (MTCSYT.SYS_Session)Session["SYS_Session"];
            string strMadviqly = session.User.ma_dviqlyDN;
            List<Object> keyvalues = grdTramChecked.GetSelectedFieldValues("MA_TRAM");
            foreach (object key in keyvalues)
            {
                string matram = key + "";
                if (!CheckName(matram))
                {
                    string trangthai = "OK!";
                    string strDate = DateTime.Now.ToString("dd/MM/yyyy h:mm");
                    db.UPDATE_TTTT_TRAM_CAD_CHECK(strMadviqly, matram, trangthai, strDate);
                }
                else
                {
                    string trangthai = "FAIL!";
                    string strDate = DateTime.Now.ToString("dd/MM/yyyy h:mm");
                    db.UPDATE_TTTT_TRAM_CAD_CHECK(strMadviqly, matram, trangthai, strDate);
                }

            }
            LoadTram();
            LoadTramChecked();
            grdTram.Selection.UnselectAll();
            grdTramChecked.Selection.UnselectAll();

        }
        private bool CheckName(string Name)
            {
                SYS_Session session = (SYS_Session)Session["SYS_Session"];

                var dt = db.CHECK_TTTT_TRAM_CAD_CHECK(session.User.ma_dviqlyDN, Name);
                if (dt.Rows.Count > 0)
                    return true ;
                return false;
            }
        private void LoadTramChecked()
        {

            MTCSYT.SYS_Session session = (MTCSYT.SYS_Session)Session["SYS_Session"];
            DataTable ds = db.SELECT_TTTT_TRAM_CAD_CHECK(session.User.ma_dviqlyDN);
            grdTramChecked.DataSource = ds;
            grdTramChecked.DataBind();

        }
        private void LoadTram()
            {

                MTCSYT.SYS_Session session = (MTCSYT.SYS_Session)Session["SYS_Session"];
                DataTable ds = db.SELECT_TTTT_TRAM_CAD(session.User.ma_dviqlyDN);
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
