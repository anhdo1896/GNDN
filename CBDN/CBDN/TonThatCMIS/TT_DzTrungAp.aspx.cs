using System;
using System.Collections.Generic;
using DevExpress.Web;
using Entity;
using SystemManageService;
using System.Web.UI;
using System.Linq;
using System.Data;
using Aspose.Cells;
using System.Data;
namespace MTCSYT
{
    public partial class TT_DzTrungAp : BasePage
    {
        DataAccess.TonThat dbOR = new DataAccess.TonThat();
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

            if (!IsPostBack)
            {
                if (DateTime.Now.Month == 1)
                {
                    cmbThang.Value = 12;
                    cmbNam.Value = DateTime.Now.Year - 1;

                }
                else
                {
                    cmbThang.Value = DateTime.Now.Month - 1;
                    cmbNam.Value = DateTime.Now.Year;

                }
            }
            loadDanhMuc();
        }
        private void loadDanhMuc()
        {
            MTCSYT.SYS_Session session = (MTCSYT.SYS_Session)Session["SYS_Session"];
            int ma_dviqly = int.Parse(session.User.ma_dviqly + "");
            int luyke = 0;
            if (ckLuyKe.Checked)
                luyke = 1;

            string madvi = db.DM_DVQLies.SingleOrDefault(x => x.IDMA_DVIQLY ==ma_dviqly).MA_DVIQLY;
            DataTable dt = dbOR.Get_BCTT_LDD(madvi, int.Parse(cmbThang.Value + ""), int.Parse(cmbNam.Value + ""), cmbLanBC.Value+"", luyke);
            grdDVT.DataSource = dt;
            grdDVT.DataBind();

        }


        protected void btnCapNhat_Click1(object sender, EventArgs e)
        {

        }

        protected void btnLoc_Click(object sender, EventArgs e)
        {
            loadDanhMuc();
        }

        protected void TreeListOrganization_CustomDataCallback(object sender, DevExpress.Web.ASPxTreeList.TreeListCustomDataCallbackEventArgs e)
        {

        }

        protected void TreeListOrganization_HtmlCommandCellPrepared(object sender, DevExpress.Web.ASPxTreeList.TreeListHtmlCommandCellEventArgs e)
        {

        }

        protected void tlDonVi_CustomCallback(object sender, DevExpress.Web.ASPxTreeList.TreeListCustomCallbackEventArgs e)
        {

        }

        protected void btnXuat_Click(object sender, EventArgs e)
        {
            int luyke =0;
            if(ckLuyKe.Checked)
                luyke=1;
            MTCSYT.SYS_Session session = (MTCSYT.SYS_Session)Session["SYS_Session"];
            int ma_dviqly = int.Parse(session.User.ma_dviqly + "");
            string madvi = db.DM_DVQLies.SingleOrDefault(x => x.IDMA_DVIQLY == ma_dviqly).MA_DVIQLY;
            Response.Redirect("../Report/Report.aspx?DonVi=" + madvi + "&Thang=" + cmbThang.Value + "&Nam=" + cmbNam.Value + "&LuyKe=" + luyke + "&LanBC=" + cmbLanBC.Value + "" + "&Loai=5");
        }

        protected void grdDVT_CellEditorInitialize1(object sender, ASPxGridViewEditorEventArgs e)
        {

        }

        protected void grdDVT_CustomColumnDisplayText(object sender, ASPxGridViewColumnDisplayTextEventArgs e)
        {

        }

        protected void grdDVT_HtmlCommandCellPrepared(object sender, ASPxGridViewTableCommandCellEventArgs e)
        {

        }

    }
}