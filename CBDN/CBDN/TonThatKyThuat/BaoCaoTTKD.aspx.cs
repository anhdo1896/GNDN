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
                LoadTyLeTT();
                TyLEBT();

            }
            else
            {
                
                _DataBind();
                InBienBanTonThat();
            }
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
            float tt = float.Parse(cmtltt.Value + "");
            int Thang = int.Parse(cmbThang.Value + "");
            int Nam = int.Parse(cmbNam.Value + "");
            var dt =  db.SELECT_TRAM_HATHE_CTT(cmMaDvi.Value + "", tt, Thang, Nam);
            cmbMaTram.DataSource = dt;
            cmbMaTram.ValueField = "MA_TRAM";
            cmbMaTram.TextField = "STRTEN";
            cmbMaTram.DataBind();

        }
        private void TyLEBT()
        {
            MTCSYT.SYS_Session session = (MTCSYT.SYS_Session)Session["SYS_Session"];
            string madvi = session.User.ma_dviqlyDN;
            var kh = db.SELECT_TTTT_PT_BT_KHANG(madvi,0);
            int t = kh.Rows.Count;
            if (t != 0)
            {
                string tlbt = kh.Rows[0]["PT_BT"] + "";
                txtTyLeBT.Text = tlbt;
            }
            else
            {
                txtTyLeBT.Text = "30";
            }
        }
     
        private void InBienBanTonThat()
        {
            if (cmbMaTram.Value == null) return;
            MTCSYT.SYS_Session session = (MTCSYT.SYS_Session)Session["SYS_Session"];
            int strMadviqly = int.Parse(session.User.ma_dviqly);
            DataAccess.clTTTT db = new DataAccess.clTTTT();

            CBDN.TonThatKyThuatReport.DuyetCanhBaoTTKD DuyetKH = new CBDN.TonThatKyThuatReport.DuyetCanhBaoTTKD();
            
            DataTable dttram = new DataTable();
            DataTable dtKhang = new DataTable();
            DataTable dtKhangD = new DataTable();
            int thang = 0, thang1 = 0, thang2 = 0, thang3 = 0, nam = 0, nam1 = 0, nam2 = 0, nam3 = 0;
            string Ma_dvi = cmMaDvi.Value + "";

            string Matram = cmbMaTram.Value + "";
            thang = int.Parse(cmbThang.Value + "");
            nam = int.Parse(cmbNam.Value + "");
            if (thang == 1) { thang1 = 12; thang2 = 11; thang3 = 10; nam1 = nam - 1; nam2 = nam - 1; nam3 = nam - 1; }
            else if (thang == 2) { thang1 = 1; thang2 = 12; thang3 = 11; nam1 = nam; nam2 = nam - 1; nam3 = nam - 1; }
            else if (thang == 3) { thang1 = 2; thang2 = 1; thang3 = 12; nam1 = nam; nam2 = nam; nam3 = nam - 1; }
            else { thang1 = thang - 1; thang2 = thang - 2; thang3 = thang - 3; nam1 = nam; nam2 = nam; nam3 = nam; }

            float tylebt = float.Parse(txtTyLeBT.Text + "");
            dttram = db.SELECT_THONGTIN_TRAM_BCKD(Ma_dvi, Matram, thang, nam, thang1, nam1, thang2, nam2, thang3, nam3);
            dtKhang = db.SELECT_THONGTIN_KHANG_BCKD(Ma_dvi, Matram, thang, nam);
            if (int.Parse(rdTinhToan.Value + "") == 0)
            {
                dtKhangD = DuyetKH.DCB_TKD(dtKhang, tylebt,0, thang, nam, Ma_dvi, Matram);
            }
            else
            {
                dtKhangD = DuyetKH.DCB_TKD(dtKhang, tylebt, 1, thang, nam, Ma_dvi, Matram);
            }
            if (dtKhang.Rows.Count ==0 || dttram.Rows.Count == 0)
            {
                ScriptManager.RegisterStartupScript(Page, Page.GetType(), "", "alert('Trạm không có dữ liệu theo điều kiện chọn.');", true);
                return;
            }
            else
            {
                TonThatKyThuatReport.InBienTTKD report = new TonThatKyThuatReport.InBienTTKD(dttram, dtKhangD, "" + cmbThang.Value, "" + cmbNam.Value, Ma_dvi);
                ReportViewer2.Report = report;
                ReportToolbar2.ReportViewer = ReportViewer2;
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
        //Load tỷ lệ tổn thất của trạm
        private void LoadTyLeTT()
        {
            MTCSYT.SYS_Session session = (MTCSYT.SYS_Session)Session["SYS_Session"];
            string madvi = session.User.ma_dviqlyDN;
            var dt = db.SELECT_CHECK_TTTT_TTKD_TLTTTRAM(madvi);
            if (dt != null)
            {
                cmtltt.DataSource = dt;
                cmtltt.ValueField = "TYLETT";
                cmtltt.TextField = "TYLETT";
                cmtltt.DataBind();
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