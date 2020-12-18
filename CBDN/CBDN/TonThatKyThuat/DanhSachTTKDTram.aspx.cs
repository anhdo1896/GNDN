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
    public partial class DanhSachTTKDTram : BasePage
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
            if (!IsPostBack)
            {
                loadDSNgay();
                laodDVCapCha();
                LoadDataDV();
                TyLEBTTram();
                LoadTyLeTT();
                SLTTram();
            }
            else
            {
                LoadDataDV();
                loadTram();
            }
        }
        private void LoadTyLeTT()
        {
            MTCSYT.SYS_Session session = (MTCSYT.SYS_Session)Session["SYS_Session"];
            string madvi = session.User.ma_dviqlyDN;
            var kh = db.SELECT_TTTT_PT_BT_KHANG(madvi, 2);
            int t = kh.Rows.Count;
            if (t != 0)
            {
                string tlbt = kh.Rows[0]["PT_BT"] + "";
                TLTT_Tram.Text = tlbt;
            }
            else
            {
                TLTT_Tram.Text = "0";
            }
        }
        private void TyLEBTTram()
        {
            MTCSYT.SYS_Session session = (MTCSYT.SYS_Session)Session["SYS_Session"];
            string madvi = session.User.ma_dviqlyDN;
            int pLoai = 1;
            var kh = db.SELECT_TTTT_PT_BT_KHANG(madvi, pLoai);
            int t = kh.Rows.Count;
            if (t != 0)
            {
                string tlbt = kh.Rows[0]["PT_BT"] + "";
                txtTyLeBT.Text = tlbt;
            }
            else
            {
                txtTyLeBT.Text = "0";
            }
        }
        
        private void SLTTram()
        {
            MTCSYT.SYS_Session session = (MTCSYT.SYS_Session)Session["SYS_Session"];
            string madvi = session.User.ma_dviqlyDN;
            int pLoai = 3;
            var kh = db.SELECT_TTTT_PT_BT_KHANG(madvi, pLoai);
            int t = kh.Rows.Count;
            if (t != 0)
            {
                string tlbt = kh.Rows[0]["PT_BT"] + "";
                TLTT_SL.Text = tlbt;
            }
            else
            {
                TLTT_SL.Text = "0";
            }
        }
        
        protected void loadTram()
        {
            DataTable dsD = new DataTable();
            CBDN.TonThatKyThuatReport.DuyetTTTramTB DuyetKH = new CBDN.TonThatKyThuatReport.DuyetTTTramTB();
            int thang = 0, thang1 = 0, thang2 = 0, thang3 = 0, nam = 0, nam1 = 0, nam2 = 0, nam3 = 0;    
            string Ma_dvi = cmMaDvi.Value + "";
            thang = int.Parse(cmbThang.Value + "");
            nam = int.Parse(cmbNam.Value + "");
            if (thang == 1) { thang1 = 12; thang2 = 11; thang3 = 10; nam1 = nam - 1; nam2 = nam - 1; nam3 = nam - 1; }
            else if (thang == 2) { thang1 = 1; thang2 = 12; thang3 = 11; nam1 = nam; nam2 = nam - 1; nam3 = nam - 1; }
            else if (thang == 3) { thang1 = 2; thang2 = 1; thang3 = 12; nam1 = nam; nam2 = nam; nam3 = nam - 1; }
            else { thang1 = thang - 1; thang2 = thang - 2; thang3 = thang - 3; nam1 = nam; nam2 = nam; nam3 = nam; }
            MTCSYT.SYS_Session session = (MTCSYT.SYS_Session)Session["SYS_Session"];
           

            if (int.Parse(rdTinhToan.Value + "") == 0)
            {
                float pTyLeSS = 0;
                pTyLeSS = float.Parse(TLTT_Tram.Value + "");
                DataTable ds = db.SELECT_THONGTIN_TRAM_TLTT(Ma_dvi, thang, nam, thang1, nam1, thang2, nam2, thang3, nam3, pTyLeSS);
                grdKH.DataSource = ds;
                grdKH.DataBind();
            }
            else if (int.Parse(rdTinhToan.Value + "") == 1)
            {
                float tylebt = float.Parse(txtTyLeBT.Text + "");
                DataTable ds = db.SELECT_THONGTIN_TRAM_TLTT_BT(Ma_dvi, thang, nam, thang1, nam1, thang2, nam2, thang3, nam3, tylebt);
                grdKH.DataSource = ds;
                grdKH.DataBind();
            }
            
            else
            {
                float SL = float.Parse(TLTT_SL.Text + "");
                DataTable ds = db.SELECT_THONGTIN_TRAM_TLTT_SL(Ma_dvi, thang, nam, thang1, nam1, thang2, nam2, thang3, nam3, SL);
                grdKH.DataSource = ds;
                grdKH.DataBind();
            }    
            
        }
        protected void btnLoc_Click(object sender, EventArgs e)
        {
            DataTable dsD = new DataTable();
            CBDN.TonThatKyThuatReport.DuyetTTTramTB DuyetKH = new CBDN.TonThatKyThuatReport.DuyetTTTramTB();
            int thang = 0, thang1 = 0, thang2 = 0, thang3 = 0, nam = 0, nam1 = 0, nam2 = 0, nam3 = 0;
            string Ma_dvi = cmMaDvi.Value + "";

                thang = int.Parse(cmbThang.Value + "");
                nam = int.Parse(cmbNam.Value + "");
                if (thang == 1) { thang1 = 12; thang2 = 11; thang3 = 10; nam1 = nam - 1; nam2 = nam - 1; nam3 = nam - 1; }
                else if (thang == 2) { thang1 = 1; thang2 = 12; thang3 = 11; nam1 = nam; nam2 = nam - 1; nam3 = nam - 1; }
                else if (thang == 3) { thang1 = 2; thang2 = 1; thang3 = 12; nam1 = nam; nam2 = nam; nam3 = nam - 1; }
                else { thang1 = thang-1; thang2 = thang-2; thang3 = thang-3; nam1 = nam; nam2 = nam; nam3 = nam; }
                MTCSYT.SYS_Session session = (MTCSYT.SYS_Session)Session["SYS_Session"];
            
            if (int.Parse(rdTinhToan.Value + "") == 0)
            {
                float pTyLeSS = 0;
                pTyLeSS = float.Parse(TLTT_Tram.Value + "");
                DataTable ds = db.SELECT_THONGTIN_TRAM_TLTT(Ma_dvi, thang, nam, thang1, nam1, thang2, nam2, thang3, nam3, pTyLeSS);
                grdKH.DataSource = ds;
                grdKH.DataBind();
            }
            else if (int.Parse(rdTinhToan.Value + "") == 1)
            {
                float tylebt = float.Parse(txtTyLeBT.Text + "");
                DataTable ds = db.SELECT_THONGTIN_TRAM_TLTT_BT(Ma_dvi, thang, nam, thang1, nam1, thang2, nam2, thang3, nam3, tylebt);
                grdKH.DataSource = ds;
                grdKH.DataBind();
            }
            
            else
            {
                float SL = float.Parse(TLTT_SL.Text + "");
                DataTable ds = db.SELECT_THONGTIN_TRAM_TLTT_SL(Ma_dvi, thang, nam, thang1, nam1, thang2, nam2, thang3, nam3, SL);
                grdKH.DataSource = ds;
                grdKH.DataBind();
            }
            

        }

        private void laodDVCapCha()
        {
            MTCSYT.SYS_Session session = (MTCSYT.SYS_Session)Session["SYS_Session"];
            int a = int.Parse(session.User.ma_dviqly + "");
            if (a == 2)
            {
                DM_DVQLYService dm_dviSer = new DM_DVQLYService();

                var lst_dmdv = dm_dviSer.SelectAllDM_DVQLY();

                MaDienLuc.DataSource = lst_dmdv;
                MaDienLuc.ValueField = "IDMA_DVIQLY";
                MaDienLuc.TextField = "TEN_DVIQLY";
                MaDienLuc.DataBind();
            }
            else if (a < 38)
            {
                DM_DVQLYService dm_dviSer = new DM_DVQLYService();
                var donvi = dm_dviSer.SelectDM_DVQLY(int.Parse(session.User.ma_dviqly));
                List<DM_DS> List = new List<DM_DS>();
                DM_DS Dvi = new DM_DS();

                Dvi.MA_DVIQLY = donvi.IDMA_DVIQLY + "";
                Dvi.NAME_DVIQLY = donvi.NAME_DVIQLY.Split('-')[1].ToString().ToUpper(); ;
                List.Add(Dvi);

                MaDienLuc.DataSource = List;
                MaDienLuc.TextField = "NAME_DVIQLY";
                MaDienLuc.ValueField = "MA_DVIQLY";
                MaDienLuc.DataBind();
            }
            else
            {
                DM_DVQLYService dm_dviSer = new DM_DVQLYService();

                var lst_dmdv = dm_dviSer.Select_DVI_Cha_ByChild(a);

                MaDienLuc.DataSource = lst_dmdv;
                MaDienLuc.ValueField = "IDMA_DVIQLY";
                MaDienLuc.TextField = "TEN_DVIQLY";
                MaDienLuc.DataBind();

            }

        }
        private void LoadDataDV()
        {
            MTCSYT.SYS_Session session = (MTCSYT.SYS_Session)Session["SYS_Session"];
            int a = int.Parse(session.User.ma_dviqly + "");
            if (MaDienLuc.Value + "" != "")
            {
                if (a > 38)
                {
                    DM_DVQLYService dm_dviSer = new DM_DVQLYService();
                    var donvi = dm_dviSer.SelectDM_DVQLY(a);
                    List<DM_DS> List = new List<DM_DS>();
                    DM_DS Dvi = new DM_DS();

                    Dvi.MA_DVIQLY = session.User.ma_dviqlyDN + "";
                    Dvi.NAME_DVIQLY = donvi.NAME_DVIQLY.Split('-')[1].ToString().ToUpper();
                    List.Add(Dvi);

                    cmMaDvi.DataSource = List;
                    cmMaDvi.TextField = "NAME_DVIQLY";
                    cmMaDvi.ValueField = "MA_DVIQLY";
                    cmMaDvi.DataBind();
                }
                else
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
        protected void btnXemChiTiet_Click(object sender, EventArgs e)
        {
            var cv = (DataRowView)grdKH.GetRow(grdKH.FocusedRowIndex);
            if (cv != null)
            {

                string ma_tram = cv["MA_TRAM"] + "";
                string ma_tramtext = cv["TEN_TRAM"] + "";
                string ma_dl = MaDienLuc.Value + "";
                string ma_dltxt = MaDienLuc.Text + "";
                string ma_dv = cmMaDvi.Value + "";
                string ma_dvtxt = cmMaDvi.Text + "";
                string thang = cmbThang.Value + "";
                string nam = cmbNam.Value + "";
                Response.Redirect("../TonThatKyThuat/rq_BaoCaoTTKD.aspx?MATRAM_V=" + ma_tram + "&MATRAM_T=" + ma_tramtext + "&MADL_V=" + ma_dl + "&MADL_T=" + ma_dltxt +
                   "&MADV_V=" + ma_dv + "&MADV_T=" + ma_dvtxt + "&THANG=" + thang + "&NAM=" + nam); 
            }
            loadTram();
        }
        protected void cmbRoles_SelectedIndexChanged(object sender, EventArgs e)
        {
        }

        protected void btnSubmit_Click(object sender, EventArgs e)
        {

        }

        protected void btnOK_Click(object sender, EventArgs e)
        {

        }
        protected void grdKH_CustomColumnDisplayText(object sender, ASPxGridViewColumnDisplayTextEventArgs e)
        {
            if (e.Column.Caption == "STT")
            {
                e.DisplayText = (e.VisibleRowIndex + 1).ToString();
            }
        }

        protected void grdKH_CellEditorInitialize(object sender, ASPxGridViewEditorEventArgs e)
        {
            e.Column.ToString();
            if (e.Column.FieldName == "MA_TRAM")
                e.Editor.Focus();
        }

        protected void grdKH_StartRowEditing(object sender, DevExpress.Web.Data.ASPxStartRowEditingEventArgs e)
        {
            (sender as ASPxGridView).GetRowValuesByKeyValue(e.EditingKeyValue);

        }

        protected void grdKH_CellEditorInitialize1(object sender, ASPxGridViewEditorEventArgs e)
        {

        }
        protected void grdKH_HtmlCommandCellPrepared(object sender, ASPxGridViewTableCommandCellEventArgs e)
        {

        }
        public class DM_DS
        {

            public string MA_DVIQLY { get; set; }
            public string NAME_DVIQLY { get; set; }
        }
    }
}
