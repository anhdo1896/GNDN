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

       
        protected void btnRemove_Click(object sender, EventArgs e)
        {
            MTCSYT.SYS_Session session = (MTCSYT.SYS_Session)Session["SYS_Session"];
            string strMadviqly = session.User.ma_dviqlyDN;
            List<Object> keyvalues = grdKH.GetSelectedFieldValues("MA_KHANG");
            foreach (object key in keyvalues)
            {
                string ma_khang = key + "";
                db.DELETE_TTTT_KHACHHANG_LUUY(strMadviqly, ma_khang);
            }
            LoadKH();
            grdKH.Selection.UnselectAll();
            
        }
        private bool CheckName(string Name)
        {
            SYS_Session session = (SYS_Session)Session["SYS_Session"];

            var dt = db.CHECK_TTTT_TRAM_UUTIEN(session.User.ma_dviqlyDN, Name);
            if (dt.Rows.Count > 0)
                return false;
            return true;
        }

        private void LoadKH()
        {
           
            MTCSYT.SYS_Session session = (MTCSYT.SYS_Session)Session["SYS_Session"];
            DataTable ds = db.SELECT_TTTT_KHACHHANG_LUUY(session.User.ma_dviqlyDN);
            grdKH.DataSource = ds;
            grdKH.DataBind();
            
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
        protected void btnXemChiTiet_Click(object sender, EventArgs e)
        {
            List<Object> keyvalues = grdKH.GetSelectedFieldValues("MA_TRAM");
            List<Object> keyvalues1 = grdKH.GetSelectedFieldValues("MA_KHANG");
            int a = keyvalues.Count;
            for(int i=0;i<a;i++)
            {
                string ma_tram = keyvalues[i] + "";
                string ma_khang = keyvalues1[i] + "";
                Response.Redirect("../TonThatKyThuat/dmKhachHang_CT.aspx?MA_TRAM=" + ma_tram + "&MA_KHANG=" + ma_khang + "");
            }
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
    }
}
    