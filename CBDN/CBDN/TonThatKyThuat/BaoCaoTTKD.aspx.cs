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
    public partial class BaoCaoTTKD : BasePage
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
            else
            {
              
            }
            Session["SYS_Session"] = session;
            if (!IsPostBack)
            {
                loadDSNgay();
                _DataBind();


            }

            InBienBanTonThat();

        }
        private void _DataBind()
        {
            if (cmbThang.Value == null && cmbNam.Value == null)
            {

                int thang = DateTime.Now.Month - 1;
                cmbThang.Value = thang;
                cmbNam.Value = DateTime.Now.Year;
            }
            MTCSYT.SYS_Session session = (MTCSYT.SYS_Session)Session["SYS_Session"];
            cmbMaTram.DataSource = db.SELECT_TRAM_HATHE(session.User.ma_dviqlyDN);
            cmbMaTram.ValueField = "MA_TRAM";
            cmbMaTram.TextField = "STRTEN";
            cmbMaTram.DataBind();

        }

        private void InBienBanTonThat()
        {
            if (cmbMaTram.Value == null) return;
            MTCSYT.SYS_Session session = (MTCSYT.SYS_Session)Session["SYS_Session"];
            int strMadviqly = int.Parse(session.User.ma_dviqly);
            DataAccess.clTTTT db = new DataAccess.clTTTT();

            CBDN.Class.InBienBanQT inBienBan = new CBDN.Class.InBienBanQT();

            DataTable dttram = new DataTable();
            DataTable dtKhang = new DataTable();
            string Ma_dvi = session.User.ma_dviqlyDN;
            string Matram = cmbMaTram.Value + "";
            dttram = db.SELECT_THONGTIN_TRAM_BCKD(Ma_dvi, Matram, int.Parse(cmbThang.Value + ""), int.Parse(cmbNam.Value + ""));
            dtKhang = db.SELECT_THONGTIN_KHANG_BCKD(Ma_dvi, Matram, int.Parse(cmbThang.Value + ""), int.Parse(cmbNam.Value + ""));
            if (dttram.Rows.Count != 0 && dtKhang.Rows.Count != 0)
            {
                MTCSYT.TonThatKyThuatReport.InBienTTKD report = new MTCSYT.TonThatKyThuatReport.InBienTTKD(dttram, dtKhang, "" + cmbThang.Value, "" + cmbNam.Value, Ma_dvi);
                ReportViewer2.Report = report;
            }
            ReportViewer2.Report = null;
           ReportToolbar2.ReportViewer = ReportViewer2;

        }
        protected void cbAll_Init(object sender, EventArgs e)
        {

            ASPxCheckBox chk = sender as ASPxCheckBox;
            ASPxGridView grid = (chk.NamingContainer as GridViewHeaderTemplateContainer).Grid;
            chk.Checked = (grid.Selection.Count == grid.VisibleRowCount);
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
        }

        protected void grdGiao_Callback(object sender, EventArgs e)
        {

        }
    
        protected void cmbNam_SelectedIndexChanged(object sender, EventArgs e)
        {
            InBienBanTonThat();

        }

        protected void cmbThang_SelectedIndexChanged(object sender, EventArgs e)
        {
            InBienBanTonThat();
        }

        protected void cmbMaTram_SelectedIndexChanged(object sender, EventArgs e)
        {
            InBienBanTonThat();
        }

      

    }
}