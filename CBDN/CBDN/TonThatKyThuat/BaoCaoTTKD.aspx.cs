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
                laodDVCapCha();
                LoadDataDV();
                _DataBind();

            }

            laodDVCapCha();
            LoadDataDV();
            _DataBind();
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
            cmbMaTram.DataSource = db.SELECT_TRAM_HATHE(cmMaDvi.Value + "");
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

            string Ma_dvi = cmMaDvi.Value + "";

            string Matram = cmbMaTram.Value + "";

            dttram = db.SELECT_THONGTIN_TRAM_BCKD(Ma_dvi, Matram, int.Parse(cmbThang.Value + ""), int.Parse(cmbNam.Value + ""));
            dtKhang = db.SELECT_THONGTIN_KHANG_BCKD(Ma_dvi, Matram, int.Parse(cmbThang.Value + ""), int.Parse(cmbNam.Value + ""));

            if (dtKhang.Rows.Count ==0 || dttram.Rows.Count == 0)
            {
                ScriptManager.RegisterStartupScript(Page, Page.GetType(), "", "alert('Trạm không có dữ liệu theo điều kiện chọn.');", true);
                return;
            }
            else
            {
                TonThatKyThuatReport.InBienBanQT report = new TonThatKyThuatReport.InBienBanQT(dttram, dtKhang, "" + cmbThang.Value, "" + cmbNam.Value, Ma_dvi);
                ReportViewer2.Report = report;
            }
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
        private void laodDVCapCha()
        {
            MTCSYT.SYS_Session session = (MTCSYT.SYS_Session)Session["SYS_Session"];
            if (session.User.ma_dviqly == "2")
            {
                DM_DVQLYService dm_dviSer = new DM_DVQLYService();

                var lst_dmdv = dm_dviSer.SelectAllDM_DVQLY();

                MaDienLuc.DataSource = lst_dmdv;
                MaDienLuc.ValueField = "IDMA_DVIQLY";
                MaDienLuc.TextField = "TEN_DVIQLY";
                MaDienLuc.DataBind();
            }
            else
            {
                DM_DVQLYService dm_dviSer = new DM_DVQLYService();
                var donvi = dm_dviSer.SelectDM_DVQLY(int.Parse(session.User.ma_dviqly));
                List<DM_DS> List = new List<DM_DS>();
                DM_DS Dvi = new DM_DS();

                Dvi.MA_DVIQLY = session.User.ma_dviqly;
                Dvi.NAME_DVIQLY = donvi.NAME_DVIQLY.Split('-')[1].ToString().ToUpper(); ;
                List.Add(Dvi);

                MaDienLuc.DataSource = List;
                MaDienLuc.TextField = "NAME_DVIQLY";
                MaDienLuc.ValueField = "MA_DVIQLY";
                MaDienLuc.DataBind();
            }

        }
        private void LoadDataDV()
        {

            if (MaDienLuc.Value + "" != "")
            {
                DM_DVQLYService dm_dviSer = new DM_DVQLYService();
                //  DataTable lst_dmdv = new DataTable();
                var lst_dmdv = dm_dviSer.SelectAll_DVI_ByChild(int.Parse(MaDienLuc.Value + ""));
                cmMaDvi.DataSource = lst_dmdv;
                cmMaDvi.ValueField = "MA_DVIQLY";
                cmMaDvi.TextField = "NAME_DVIQLY";
                cmMaDvi.DataBind();
            }


        }
        protected void grdGiao_Callback(object sender, EventArgs e)
        {

        }

        public class DM_DS
        {

            public string MA_DVIQLY { get; set; }
            public string NAME_DVIQLY { get; set; }
        }

        protected void btnLoc_Click(object sender, EventArgs e)
        {

            InBienBanTonThat();
        }
    }
}