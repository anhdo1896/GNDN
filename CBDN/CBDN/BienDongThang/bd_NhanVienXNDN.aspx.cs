using System;
using System.Collections.Generic;
using SystemManageService;
using DevExpress.Web.ASPxTreeList;
using Entity;
using System.Linq;
using System.Web.UI;
using System.Data;
using DevExpress.Web.ASPxEditors;
using DevExpress.Web.ASPxGridView;
using System.IO;
namespace MTCSYT
{
    public partial class bd_NhanVienXNDN : BasePage
    {
        CBDN.DB_CBDNDataContext db = new CBDN.DB_CBDNDataContext(new CBDN.ADOController().strcn());
        private const string funcid = "61";
        private SYS_Right rightOfUser = null;
        protected void Page_Load(object sender, EventArgs e)
        {
            MTCSYT.SYS_Session session = (MTCSYT.SYS_Session)Session["SYS_Session"];
            if (session == null || session.User.USERNAME == "Guest")
            {
                Response.Redirect("~\\Login.aspx");
            }

            Session["SYS_Session"] = session;
            if (!IsPostBack)
            {
                loadDSNgay();
                loadGiaoNhan();
                //if (session.User.ma_dviqly == "2")
                //    pcTax.TabIndex[4].
            }
            loadTax();

        }
        private void loadTax()
        {
            var isKy = db.HD_ThongTinKies.SingleOrDefault(x => x.IDChinhNhanh == int.Parse(cmbPhuongThuc.Value + "") && x.Nam == int.Parse(cmbNam.Value + "") && x.Thang == int.Parse(cmbThang.Value + "") && x.Link == cmbPhuongThuc.Value + "_" + cmbThang.Value + "_" + cmbNam.Value + "_QT.pdf");
            if (isKy != null)
            {
                var ngtao = db.DM_USERs.SingleOrDefault(x => x.IDUSER == isKy.NguoiTao);
                lbThongTinXacNhan.Text = "Giao nhận này đã được xác nhận và tạo File ký. Người tạo: " + ngtao.USERNAME + " - Ngày tạo: " + isKy.NgayTao;
            }

            InTongHopDienNang();
            InBienBanQuyetToan();
            LoadGrdNhan();
            loadPhuongThucDonVi();

        }
        private void InTongHopDienNang()
        {
            if (cmbPhuongThuc.Value == null || cmbPhuongThuc.Value+"" == "0") return;
            
                MTCSYT.SYS_Session session = (MTCSYT.SYS_Session)Session["SYS_Session"];
                int ma_dviqly = int.Parse(session.User.ma_dviqly);
                DM_DVQLYService dm_dviSer = new DM_DVQLYService();
                var donvi = dm_dviSer.SelectDM_DVQLY(ma_dviqly);
               
                //  if (Request["XacNhan"] + "" == "1") kiemtra = true;

                var cn = db.DM_ChiNhanhs.SingleOrDefault(x => x.ID == int.Parse(cmbPhuongThuc.Value + ""));
                CBDN.DM_DVQLY giao, nhan;
                if (cn.IDMADVIQLY.Contains(",2,"))
                {
                    giao = db.DM_DVQLies.SingleOrDefault(x => x.IDMA_DVIQLY == 2);
                    nhan = db.DM_DVQLies.SingleOrDefault(x => x.IDMA_DVIQLY == int.Parse(cn.IDMADVIQLY.Replace(",2,", "").Replace(",", "")));
                }
                else
                {
                    giao = db.DM_DVQLies.SingleOrDefault(x => x.IDMA_DVIQLY == cn.DiemDauNguon);
                    nhan = db.DM_DVQLies.SingleOrDefault(x => x.IDMA_DVIQLY == cn.DiemCuoiNguon);
                }
               
                MTCSYT.Report.InBieuTong report = new MTCSYT.Report.InBieuTong(int.Parse(cmbPhuongThuc.Value + ""), ma_dviqly, int.Parse(cmbThang.Value + ""), int.Parse(cmbNam.Value + ""),  "", "", donvi.TEN_DVIQLY, giao.TEN_DVIQLY, nhan.TEN_DVIQLY, 0, "", "", "", "");

                ReportViewer1.Report = report;

                ReportToolbar1.ReportViewer = ReportViewer1;
        

        }
        private void InBienBanQuyetToan()
        {
            if (cmbPhuongThuc.Value == null || cmbPhuongThuc.Value + "" == "0") return;
            MTCSYT.SYS_Session session = (MTCSYT.SYS_Session)Session["SYS_Session"];
            int strMadviqly = int.Parse(session.User.ma_dviqly);

            DataTable dt = new DataTable();

            CBDN.Class.InBienBanQT inBienBan = new CBDN.Class.InBienBanQT();
            string strGiao = "", strNhan = "", strGDNhan = "", strGDGiao = "";

            int donvi = strMadviqly;
            int phuongthuc = int.Parse(cmbPhuongThuc.Value + "");
            if (strMadviqly == 2)
            {
                if (phuongthuc != 0)
                {
                    donvi = int.Parse(db.DM_ChiNhanhs.SingleOrDefault(x => x.ID == int.Parse(cmbPhuongThuc.Value + "")).IDMADVIQLY.Replace(",2,", "").Replace(",", ""));
                    phuongthuc = 0;
                }

            }

            dt = inBienBan.InBienBanQuyetToan(phuongthuc, donvi, int.Parse(cmbThang.Value + ""), int.Parse(cmbNam.Value + ""), ref strGiao, ref strNhan, ref strGDNhan, ref strGiao);
          
            MTCSYT.Report.InBienBanQT report = new MTCSYT.Report.InBienBanQT(dt, "" + cmbThang.Value, "" + cmbNam.Value, false, false, "", "", strGiao, strNhan, "", "",strGDNhan,strGDGiao);
            ReportViewer2.Report = report;

            ReportToolbar2.ReportViewer = ReportViewer2;

        }
        private void loadGiaoNhan()
        {
            MTCSYT.SYS_Session session = (MTCSYT.SYS_Session)Session["SYS_Session"];
            var lstDD = db.db_SelectPhuongThucCanXN(int.Parse(session.User.ma_dviqly + ""), int.Parse(cmbThang.Value + ""), int.Parse(cmbNam.Value + ""), "NVXacNhan").ToList();
            cmbPhuongThuc.DataSource = lstDD;
            cmbPhuongThuc.ValueField = "IDChiNhanh";
            cmbPhuongThuc.TextField = "TenPhuongThuc";
            cmbPhuongThuc.DataBind();

        }
        private void LoadGrdNhan()
        {

            MTCSYT.SYS_Session session = (MTCSYT.SYS_Session)Session["SYS_Session"];
            int strMadviqly = int.Parse(session.User.ma_dviqly);
            //List<CBDN.db_DSDiemNhanNVXacNhanResult> lstNhan = new List<CBDN.db_DSDiemNhanNVXacNhanResult>();
            System.Data.Linq.ISingleResult<CBDN.db_DSDiemNhanNVXacNhanResult> lstNhan = null;
            System.Data.Linq.ISingleResult<CBDN.db_DSDiemGiaoNVXacNhanResult> lstGiao = null;
            if (cmbPhuongThuc.Value != null)
            {
                lstNhan = db.db_DSDiemNhanNVXacNhan(strMadviqly, int.Parse(cmbThang.Value + ""), int.Parse(cmbNam.Value + ""), int.Parse(cmbPhuongThuc.Value + ""));
                lstGiao = db.db_DSDiemGiaoNVXacNhan(strMadviqly, int.Parse(cmbThang.Value + ""), int.Parse(cmbNam.Value + ""), int.Parse(cmbPhuongThuc.Value + ""));

            }
            else
            {

                lstNhan = db.db_DSDiemNhanNVXacNhan(strMadviqly, int.Parse(cmbThang.Value + ""), int.Parse(cmbNam.Value + ""), 0);
                lstGiao = db.db_DSDiemGiaoNVXacNhan(strMadviqly, int.Parse(cmbThang.Value + ""), int.Parse(cmbNam.Value + ""), 0);

            }
            grdNhan.DataSource = lstNhan;
            grdNhan.DataBind();

            grdGiao.DataSource = lstGiao;
            grdGiao.DataBind();

            grdSanLuonghan.DataSource = lstNhan;
            grdSanLuonghan.DataBind();

            grdSLGiao.DataSource = lstGiao;
            grdSLGiao.DataBind();
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
        protected void grdNhan_CustomCallback(object sender, DevExpress.Web.ASPxGridView.ASPxGridViewCustomCallbackEventArgs e)
        {
            loadTax();
        }
        protected void grdGiao_Callback(object sender, EventArgs e)
        {

        }
        protected void btnDuyet_Click(object sender, EventArgs e)
        {
            //List<Object> keyvalues = grdNhan.GetSelectedFieldValues("ID");
            //if (keyvalues.Count == 0)
            //{
            //    ScriptManager.RegisterStartupScript(Page, Page.GetType(), "", "alert('Bạn chưa chọn dữ liệu để xác nhận.');", true);
            //    return;
            //}
            //pcFileKy.ShowOnPageLoad = true;

            MTCSYT.SYS_Session session = (MTCSYT.SYS_Session)Session["SYS_Session"];
            string strMadviqly = session.User.ma_dviqly;

            try
            {
                List<Object> keyvalues = grdNhan.GetSelectedFieldValues("ID");
                if (keyvalues.Count == 0)
                {
                    ScriptManager.RegisterStartupScript(Page, Page.GetType(), "", "alert('Bạn chưa chọn dữ liệu để xác nhận.');", true);
                    return;
                }
                //Lưu file ký
                // UploadFile();

                var ky = db.HD_ThongTinKies.SingleOrDefault(x => x.IDChinhNhanh == int.Parse(cmbPhuongThuc.Value + "") && x.Nam == int.Parse(cmbNam.Value + "") && x.Thang == int.Parse(cmbThang.Value + "") && x.IDMaDViQLy == int.Parse(strMadviqly) && x.ChucVu == 1);
                if (ky == null)
                {
                    CBDN.HD_ThongTinKy hDKyTH = new CBDN.HD_ThongTinKy();
                    hDKyTH.IDChinhNhanh = int.Parse(cmbPhuongThuc.Value + "");
                    hDKyTH.NgayTao = DateTime.Now;
                    hDKyTH.NguoiTao = session.User.IDUSER;
                    hDKyTH.Link = "";
                    hDKyTH.Barcode = "";
                    hDKyTH.Thang = int.Parse(cmbThang.Value + "");
                    hDKyTH.Nam = int.Parse(cmbNam.Value + "");
                    hDKyTH.IDMaDViQLy = int.Parse(strMadviqly);
                    //Nhan viên
                    hDKyTH.ChucVu = 1;
                    db.HD_ThongTinKies.InsertOnSubmit(hDKyTH);
                    db.SubmitChanges();
                }




                if (grdNhan.Selection.Count == 0) return;

                // List<Object> temp = new List<Object>();

                foreach (object key in keyvalues)
                {
                    var bd_chitiet = db.HD_GiaoNhanThangs.SingleOrDefault(x => x.ID == int.Parse(key + ""));
                    bd_chitiet.ISNhanVien = true;
                    bd_chitiet.IDUseNhanVienXN = session.User.IDUSER;
                    bd_chitiet.DateNhanVienXN = DateTime.Now;
                    db.SubmitChanges();
                }
                loadTax();
                pcAddRoles.ShowOnPageLoad = false;
                pcFileKy.ShowOnPageLoad = false;

            }
            catch (Exception ex)
            {
                ScriptManager.RegisterStartupScript(Page, Page.GetType(), "", "alert('Lỗi duyệt chấm nợ " + ex.Message + "');", true);

            }

        }



        protected void btnHuy_Click(object sender, EventArgs e)
        {
            pcAddRoles.ShowOnPageLoad = true;
        }

        protected void ckNhan_Init(object sender, EventArgs e)
        {
            ASPxCheckBox chk = sender as ASPxCheckBox;
            ASPxGridView grid = (chk.NamingContainer as GridViewHeaderTemplateContainer).Grid;
            chk.Checked = (grid.Selection.Count == grid.VisibleRowCount);
        }

        protected void btnDong_Click(object sender, EventArgs e)
        {
            pcAddRoles.ShowOnPageLoad = false;
        }

        protected void btnCapNhat_Click(object sender, EventArgs e)
        {
            MTCSYT.SYS_Session session = (MTCSYT.SYS_Session)Session["SYS_Session"];
            string strMadviqly = session.User.ma_dviqly;

            if (grdNhan.Selection.Count == 0) return;
            List<Object> keyvalues = grdNhan.GetSelectedFieldValues("ID");
            // List<Object> temp = new List<Object>();


            foreach (object key in keyvalues)
            {
                var bd_chitiet = db.HD_GiaoNhanThangs.SingleOrDefault(x => x.ID == int.Parse(key + ""));
                bd_chitiet.XacNhanDVNhan = false;
                bd_chitiet.ISChot = false;
                bd_chitiet.IDXacNhanNhan = int.Parse(strMadviqly);
                bd_chitiet.NgayXacNhanDVNhan = DateTime.Now;
                if (txtLyDo.Text != "")
                    bd_chitiet.GhiChuXacNhanNhan = txtLyDo.Text;
                else
                    bd_chitiet.GhiChuXacNhanNhan = "Không đồng ý xác nhận điểm đo này";
                db.SubmitChanges();
            }
            pcAddRoles.ShowOnPageLoad = false;
            loadTax();

        }

        protected void cmbThang_SelectedIndexChanged(object sender, EventArgs e)
        {
            loadTax();
        }

        protected void cmbNam_SelectedIndexChanged(object sender, EventArgs e)
        {
            loadTax();
        }

        protected void cmbPhuongThuc_SelectedIndexChanged(object sender, EventArgs e)
        {
            loadTax();
        }

        protected void btnIn_Click(object sender, EventArgs e)
        {
            MTCSYT.SYS_Session session = (MTCSYT.SYS_Session)Session["SYS_Session"];
            string strMadviqly = session.User.ma_dviqly;
            Response.Redirect("../Report/Report.aspx?ChiNhanh=" + cmbPhuongThuc.Value + "&Loai=1&Thang=" + cmbThang.Value + "&Nam=" + cmbNam.Value + "&ParentId=1");
        }

        protected void btnLuuFile_Click(object sender, EventArgs e)
        {
            try
            {
                List<Object> keyvalues = grdNhan.GetSelectedFieldValues("ID");
                if (keyvalues.Count == 0)
                {
                    ScriptManager.RegisterStartupScript(Page, Page.GetType(), "", "alert('Bạn chưa chọn dữ liệu để xác nhận.');", true);
                    return;
                }
                //Lưu file ký
                UploadFile();

                MTCSYT.SYS_Session session = (MTCSYT.SYS_Session)Session["SYS_Session"];
                string strMadviqly = session.User.ma_dviqly;

                if (grdNhan.Selection.Count == 0) return;

                // List<Object> temp = new List<Object>();

                foreach (object key in keyvalues)
                {
                    var bd_chitiet = db.HD_GiaoNhanThangs.SingleOrDefault(x => x.ID == int.Parse(key + ""));
                    bd_chitiet.ISNhanVien = true;
                    bd_chitiet.IDUseNhanVienXN = session.User.IDUSER;
                    bd_chitiet.DateNhanVienXN = DateTime.Now;
                    db.SubmitChanges();
                }
                loadTax();
                pcAddRoles.ShowOnPageLoad = false;
                pcFileKy.ShowOnPageLoad = false;

            }
            catch (Exception ex)
            {
                ScriptManager.RegisterStartupScript(Page, Page.GetType(), "", "alert('Lỗi duyệt chấm nợ " + ex.Message + "');", true);

            }
        }

        protected void btnDongFileKy_Click(object sender, EventArgs e)
        {
            pcFileKy.ShowOnPageLoad = false;
        }
        public string UploadFile()
        {
            MTCSYT.SYS_Session session = (MTCSYT.SYS_Session)Session["SYS_Session"];
            string strTenFile = "";
            try
            {
                //file tổng hợp
                strTenFile = cmbPhuongThuc.Value + "_" + cmbThang.Value + "_" + cmbNam.Value + "_TH.pdf";
                if (!Directory.Exists(Server.MapPath("~/") + "FileKy"))
                    Directory.CreateDirectory(Server.MapPath("~/") + "FileKy");
                if (!File.Exists(Server.MapPath("~/") + "FileKy\\" + strTenFile))
                {
                    fileUp.PostedFile.SaveAs(Server.MapPath("~/") + "FileKy\\" + strTenFile);
                    //strTenFile = fileUp.FileName;
                    CBDN.HD_ThongTinKy hDKyTH = new CBDN.HD_ThongTinKy();
                    hDKyTH.IDChinhNhanh = int.Parse(cmbPhuongThuc.Value + "");
                    hDKyTH.NgayTao = DateTime.Now;
                    hDKyTH.NguoiTao = session.User.IDUSER;
                    //hDKyTH.Link = "http://10.21.0.135:8091/FileKy/" + strTenFile;
                    hDKyTH.Link = "http://10.21.3.75:8899//FileKy/" + strTenFile;
                    hDKyTH.Barcode = "";
                    hDKyTH.Thang = int.Parse(cmbThang.Value + "");
                    hDKyTH.Nam = int.Parse(cmbNam.Value + "");
                    db.HD_ThongTinKies.InsertOnSubmit(hDKyTH);
                    db.SubmitChanges();

                }
                //hdTenFile.Value = strTenFile;

                // import file quyết toán 
                string strQT = cmbPhuongThuc.Value + "_" + cmbThang.Value + "_" + cmbNam.Value + "_QT.pdf";

                if (!File.Exists(Server.MapPath("~/") + "FileKy\\" + strQT))
                {
                    FileUpload1.PostedFile.SaveAs(Server.MapPath("~/") + "FileKy\\" + strQT);
                    //strTenFile = FileUpload1.FileName;
                    CBDN.HD_ThongTinKy hDKyQT = new CBDN.HD_ThongTinKy();
                    hDKyQT.IDChinhNhanh = int.Parse(cmbPhuongThuc.Value + "");
                    hDKyQT.NgayTao = DateTime.Now;
                    hDKyQT.NguoiTao = session.User.IDUSER;
                    // hDKyQT.Link = "http://10.21.0.135:8091/FileKy/"+strQT;
                    hDKyQT.Link = "http://10.21.3.75:8899/FileKy/" + strQT;
                    hDKyQT.Barcode = "";
                    hDKyQT.Thang = int.Parse(cmbThang.Value + "");
                    hDKyQT.Nam = int.Parse(cmbNam.Value + "");
                    db.HD_ThongTinKies.InsertOnSubmit(hDKyQT);
                    db.SubmitChanges();
                }
                //hdTenFile.Value = strTenFile;


            }
            catch (Exception exp)
            {
                ScriptManager.RegisterStartupScript(Page, Page.GetType(), "", "alert('" + exp.Message + Server.MapPath("~/") + "BaoCao\\" + hdTenFile.Value + "');", true);
            }
            //  ScriptManager.RegisterStartupScript(Page, Page.GetType(), "", "alert('" + strTenFile + "');", true);
            return strTenFile;
        }
        protected void btnDupngDan_Click(object sender, EventArgs e)
        {

        }
        private void loadPhuongThucDonVi()
        {
            if (cmbPhuongThuc.Value == null || cmbPhuongThuc.Value + "" == "0") return;
            var chinhanh = db.DM_ChiNhanhs.SingleOrDefault(x => x.ID == int.Parse(cmbPhuongThuc.Value + ""));
            string intDV = chinhanh.IDMADVIQLY.Replace(",2,", "").Replace(",", "");
            var lstDD = db.db_GD_PhuongThucCanXN(int.Parse(intDV), int.Parse(cmbThang.Value + ""), int.Parse(cmbNam.Value + ""), "1").ToList();
            cmbPhuongThucDV.DataSource = lstDD;
            cmbPhuongThucDV.ValueField = "IDChiNhanh";
            cmbPhuongThucDV.TextField = "TenPhuongThuc";
            cmbPhuongThucDV.DataBind();

            loadTHDonVi();
        }
        private void loadTHDonVi()
        {
            if (cmbPhuongThucDV.Value == null || cmbPhuongThucDV.Value + "" == "") return;

            var cn = db.DM_ChiNhanhs.SingleOrDefault(x => x.ID == int.Parse(cmbPhuongThucDV.Value + ""));
            var giao = db.DM_DVQLies.SingleOrDefault(x => x.IDMA_DVIQLY == cn.DiemDauNguon);
            var nhan = db.DM_DVQLies.SingleOrDefault(x => x.IDMA_DVIQLY == cn.DiemCuoiNguon);

            string strTPGiao = "", strTPNhan = "", strGDNhan = "", strGDGiao = "";
            var lstHDKy = db.HD_ThongTinKies.Where(x => x.IDChinhNhanh == int.Parse(cmbPhuongThucDV.Value + "") && x.Thang == int.Parse(cmbThang.Value + "") && x.Nam == int.Parse(cmbNam.Value + ""));
            foreach (var hdKy in lstHDKy)
            {
                if (hdKy.ChucVu == 2 && hdKy.IDMaDViQLy == giao.IDMA_DVIQLY)
                    strTPGiao = hdKy.Link;
                if (hdKy.ChucVu == 2 && hdKy.IDMaDViQLy == nhan.IDMA_DVIQLY)
                    strTPNhan = hdKy.Link;
                if (hdKy.ChucVu == 3 && hdKy.IDMaDViQLy == giao.IDMA_DVIQLY)
                    strGDGiao = hdKy.Link;
                if (hdKy.ChucVu == 3 && hdKy.IDMaDViQLy == nhan.IDMA_DVIQLY)
                    strGDNhan = hdKy.Link;
            }

            //var imTPGiao = db.HD_ThongTinKies.SingleOrDefault(x => x.IDMaDViQLy == cn.DiemDauNguon && x.Thang == int.Parse(cmbThang.Value + "") && x.Nam == int.Parse(cmbNam.Value + "") && x.ChucVu == 2);
            //var imTPNhan = db.HD_ThongTinKies.SingleOrDefault(x => x.IDMaDViQLy == cn.DiemCuoiNguon && x.Thang == int.Parse(cmbThang.Value + "") && x.Nam == int.Parse(cmbNam.Value + "") && x.ChucVu == 2);

            //var imGDGiao = db.HD_ThongTinKies.SingleOrDefault(x => x.IDMaDViQLy == cn.DiemDauNguon && x.Thang == int.Parse(cmbThang.Value + "") && x.Nam == int.Parse(cmbNam.Value + "") && x.ChucVu == 3);
            //var imGDNhan = db.HD_ThongTinKies.SingleOrDefault(x => x.IDMaDViQLy == cn.DiemCuoiNguon && x.Thang == int.Parse(cmbThang.Value + "") && x.Nam == int.Parse(cmbNam.Value + "") && x.ChucVu == 3);

            //if (imTPGiao != null)

            //    if (imTPNhan != null)
            //        strTPNhan = imTPNhan.Link;
            //if (imGDGiao != null)
            //    strGDGiao = imGDGiao.Link;
            //if (imGDNhan != null)
            //    strGDNhan = imGDNhan.Link;

            MTCSYT.Report.InBieuTong report = new MTCSYT.Report.InBieuTong(int.Parse(cmbPhuongThuc.Value + ""), giao.IDMA_DVIQLY, int.Parse(cmbThang.Value + ""), int.Parse(cmbNam.Value + ""), "", "", giao.TEN_DVIQLY, giao.TEN_DVIQLY, nhan.TEN_DVIQLY, 0, strTPNhan, strTPGiao, strGDNhan, strGDGiao);

            repViewDV.Report = report;

            reToodDV.ReportViewer = ReportViewer1;
        }
        protected void cmbPhuongThucDV_SelectedIndexChanged(object sender, EventArgs e)
        {
            loadTHDonVi();
        }

    }
}