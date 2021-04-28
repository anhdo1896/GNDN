using System;
using System.Collections.Generic;
using DevExpress.Web;
using Entity;
using SystemManageService;
using System.Web.UI;
using System.Linq;
using System.Data;
using DevExpress.XtraCharts;
using DevExpress.XtraCharts.Web;
namespace MTCSYT
{
    public partial class dm_KeHoachThang : BasePage
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
                loadDSNgay();
                _DataBind();
            }

        }
        private void loadDSNgay()
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

            MTCSYT.SYS_Session session = (MTCSYT.SYS_Session)Session["SYS_Session"];
            cmbMaTram.DataSource = db.SELECT_TRAM_HATHE(session.User.ma_dviqlyDN);
            cmbMaTram.ValueField = "MA_TRAM";
            cmbMaTram.TextField = "STRTEN";
            cmbMaTram.DataBind();
        }

        private void _DataBind()
        {
            SYS_Session session = (SYS_Session)Session["SYS_Session"];
            if (cmbMaTram.Value != null)
            {
                DataTable dt = db.SELECT_TTTT_DN_KEHOACH(session.User.ma_dviqlyDN, cmbMaTram.Value + "");

                DataRow[] dr = dt.Select("THANG=" + cmbThang.Value + " AND NAM =" + cmbNam.Value);
                if (dr.Length > 0)
                    txtSanLuongKH.Text = dr[0]["KEHOACH"] + "";
                else txtSanLuongKH.Text = "0";
                grdTinhDetal.DataSource = dt;
                grdTinhDetal.DataBind();
            }

        }

        protected void grdDVT_CustomColumnDisplayText(object sender, ASPxGridViewColumnDisplayTextEventArgs e)
        {
            if (e.Column.Caption == "STT")
            {
                e.DisplayText = (e.VisibleRowIndex + 1).ToString();
            }
        }

        private bool CheckName(string Name, int id)
        {
            SYS_Session session = (SYS_Session)Session["SYS_Session"];

            var dt = db.TTTT_DM_LOAIDUONGDAY_CHECKNAME(id, session.User.ma_dviqlyDN, Name);
            if (dt.Rows.Count > 0)
                return false;
            return true;
        }

        protected void grdDVT_CellEditorInitialize(object sender, ASPxGridViewEditorEventArgs e)
        {
            e.Column.ToString();
            if (e.Column.FieldName == "MaChiNhanh")
                e.Editor.Focus();
        }

        protected void btnLuuDuLieu_Click(object sender, EventArgs e)
        {
            SYS_Session session = (SYS_Session)Session["SYS_Session"];
            int testso = 0;
            if (!int.TryParse(txtSanLuongKH.Text, out testso))
            {
                ScriptManager.RegisterStartupScript(Page, Page.GetType(), "", "alert('Sản lượng kế hoạch không phải là kiểu số. Bạn check lại thông tin');", true);
                txtSanLuongKH.Focus();
                return;
            }

            DataTable dt = db.SELECT_TTTT_DN_KEHOACH(session.User.ma_dviqlyDN, cmbMaTram.Value + "");

            DataRow[] dr = dt.Select("THANG=" + cmbThang.Value + " AND NAM =" + cmbNam.Value);
            if (dr.Length == 0)
            {

                db.Insert_TTTT_DN_KEHOACH(session.User.ma_dviqlyDN, cmbMaTram.Value.ToString(), int.Parse(txtSanLuongKH.Text), int.Parse(cmbThang.Value + ""), int.Parse(cmbNam.Value + ""), DateTime.Now);
            }
            else
            {
                db.Update_TTTT_DN_KEHOACH(session.User.ma_dviqlyDN, cmbMaTram.Value.ToString(), int.Parse(txtSanLuongKH.Text), int.Parse(cmbThang.Value + ""), int.Parse(cmbNam.Value + ""));
            }
            _DataBind();
        }

        protected void cmbMaTram_SelectedIndexChanged(object sender, EventArgs e)
        {
            _DataBind();
        }


    }
}