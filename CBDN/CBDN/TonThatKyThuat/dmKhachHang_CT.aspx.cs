using System;
using System.Collections.Generic;
using DevExpress.Web;
using Entity;
using SystemManageService;
using System.Web.UI;
using System.Linq;
using System.Data;
using System.Globalization;

namespace MTCSYT
{
    public partial class dmKhachHang_CT : BasePage
    {
        DataAccess.clTTTT db = new DataAccess.clTTTT();
        // CBDN.DB_CBDNDataContext db = new CBDN.DB_CBDNDataContext(new CBDN.ADOController().strcn());
        private SYS_Right rightOfUser = null;
        private const string funcid = "57";
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
            if (!IsPostBack)
            {

                cmbThang.Value = DateTime.Now.Month - 1;
                cmbNam.Value = DateTime.Now.Year;
            }
            _DataBind();

        }

        private void _DataBind()
        {
            MTCSYT.SYS_Session session = (MTCSYT.SYS_Session)Session["SYS_Session"];
            DataTable dt = db.Get_SLKhang(session.User.ma_dviqlyDN, Request["MA_KHANG"], int.Parse(cmbThang.Value + ""), int.Parse(cmbNam.Value + ""));
            if (dt.Rows.Count > 0)
            {
                lbMaKH.Text = dt.Rows[0]["MA_KHANG"] + "";
                lbTenKH.Text = dt.Rows[0]["TENKHACHHANG"] + "";
                lbTram.Text = Request["MA_TRAM"] + "";
                lbDiaChi.Text = dt.Rows[0]["DIACHI"] + "";
            }

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

        protected void grdDVT_CellEditorInitialize(object sender, ASPxGridViewEditorEventArgs e)
        {
            e.Column.ToString();
            if (e.Column.FieldName == "MAKHACHHANG")
                e.Editor.Focus();
        }

        protected void grdDVT_StartRowEditing(object sender, DevExpress.Web.Data.ASPxStartRowEditingEventArgs e)
        {
            (sender as ASPxGridView).GetRowValuesByKeyValue(e.EditingKeyValue);

        }

        protected void grdDVT_CellEditorInitialize1(object sender, ASPxGridViewEditorEventArgs e)
        {

        }
        protected void grdDVT_HtmlCommandCellPrepared(object sender, ASPxGridViewTableCommandCellEventArgs e)
        {

        }

        protected void btnXemChiTiet_Click(object sender, EventArgs e)
        {

        }
        protected void btnThem_Click(object sender, EventArgs e)
        {
            pcAddRoles.ShowOnPageLoad = true;
            Session["Add"] = 1;
        }
        protected void btnCapNhat_Click(object sender, EventArgs e)
        {
            DM_DVQLYService dm_dviSer = new DM_DVQLYService();
            SYS_Session session = (SYS_Session)Session["SYS_Session"];
            
                if (txtNoiDung.Text == null)
                {
                    ScriptManager.RegisterStartupScript(Page, Page.GetType(), "", "alert('Nội dung không được để trống');", true); return;
                }
                string strMadviqly = session.User.ma_dviqlyDN;
                lbTram.Text = Request["MA_TRAM"];
            string tenkhachhang = lbTenKH.Text;
                    string diachi = lbDiaChi.Text;
                    string makhachang = lbMaKH.Text;
                    string matram = lbTram.Text;
                string strDate = DateTime.Now.ToString("dd/MM/yyyy h:mm");

                db.INSERT_TTTT_KHACHHANG_LUUY(strMadviqly, makhachang, matram, tenkhachhang, diachi, txtNoiDung.Text, strDate);
            pcAddRoles.ShowOnPageLoad = false;
            _DataBind();
        }
        protected void btnDong_Click(object sender, EventArgs e)
        {
            pcAddRoles.ShowOnPageLoad = false;
        }
        protected void ASPxButton1_Click(object sender, EventArgs e)
        {
            Response.Redirect("../TonThatKyThuat/dmKhachHangLuuY.aspx");
        }
    }
}