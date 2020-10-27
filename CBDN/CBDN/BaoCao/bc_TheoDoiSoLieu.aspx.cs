using System;
using System.Collections.Generic;
using SystemManageService;
using DevExpress.Web.ASPxTreeList;
using Entity;
using System.Linq;
using System.Web.UI;
using System.Data;
using DevExpress.Web;
using System.IO;
namespace MTCSYT
{
    public partial class bc_TheoDoiSoLieu : BasePage
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
            if (cmbPhuongThuc.Value == null) return;
            var isKy = db.HD_ThongTinKies.SingleOrDefault(x => x.IDChinhNhanh == int.Parse(cmbPhuongThuc.Value + "") && x.Nam == int.Parse(cmbNam.Value + "") && x.Thang == int.Parse(cmbThang.Value + "") && x.Link == cmbPhuongThuc.Value + "_" + cmbThang.Value + "_" + cmbNam.Value + "_QT.pdf");
            if (isKy != null)
            {
                var ngtao = db.DM_USERs.SingleOrDefault(x => x.IDUSER == isKy.NguoiTao);
                lbThongTinXacNhan.Text = "Giao nhận này đã được xác nhận và tạo File ký. Người tạo: " + ngtao.USERNAME + " - Ngày tạo: " + isKy.NgayTao;
            }

            InTongHopDienNang();
            InBienBanQuyetToan();


        }
        private void InTongHopDienNang()
        {
            if (cmbPhuongThuc.Value == null) return;

            MTCSYT.SYS_Session session = (MTCSYT.SYS_Session)Session["SYS_Session"];
            int ma_dviqly = int.Parse(session.User.ma_dviqly);
            DM_DVQLYService dm_dviSer = new DM_DVQLYService();
            var donvi = dm_dviSer.SelectDM_DVQLY(ma_dviqly);

            //  if (Request["XacNhan"] + "" == "1") kiemtra = true;
            string strGiao, strNhan; string strGDNhan = "", strGDGiao = "";
            if (cmbPhuongThuc.Value + "" != "0")
            {
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
                strGiao = giao.TEN_DVIQLY;
                strNhan = nhan.TEN_DVIQLY;


                var imGDGiao = db.HD_ThongTinKies.SingleOrDefault(x => x.IDMaDViQLy == cn.DiemDauNguon && x.IDChinhNhanh == int.Parse(cmbPhuongThuc.Value + "") && x.Thang == int.Parse(cmbThang.Value + "") && x.Nam == int.Parse(cmbNam.Value + "") && x.ChucVu == 3);
                var imGDNhan = db.HD_ThongTinKies.SingleOrDefault(x => x.IDMaDViQLy == cn.DiemCuoiNguon && x.IDChinhNhanh == int.Parse(cmbPhuongThuc.Value + "") && x.Thang == int.Parse(cmbThang.Value + "") && x.Nam == int.Parse(cmbNam.Value + "") && x.ChucVu == 3);

                if (imGDGiao != null)
                {
                    var ngGiao = db.DM_USERs.SingleOrDefault(x => x.IDUSER == imGDGiao.NguoiTao);
                    strGDGiao = ngGiao.HOTEN + "</br> Thời gian xác nhận: " + imGDGiao.NgayTao;
                }
                if (imGDNhan != null)
                {
                    var ngNhan = db.DM_USERs.SingleOrDefault(x => x.IDUSER == imGDNhan.NguoiTao);
                    strGDNhan = ngNhan.HOTEN + "</br> Thời gian xác nhận: " + imGDNhan.NgayTao;
                }
            }
            else
            {
                strGiao = "TỔNG CÔNG TY ĐIỆN LỰC MIỀM BẮC";
                strNhan = donvi.TEN_DVIQLY;
            }


            MTCSYT.Report.InBieuTong report = new MTCSYT.Report.InBieuTong(int.Parse(cmbPhuongThuc.Value + ""), ma_dviqly, int.Parse(cmbThang.Value + ""), int.Parse(cmbNam.Value + ""), "", "", donvi.TEN_DVIQLY, strGiao, strNhan, 0, "", "", strGDNhan, strGDGiao);

            ReportViewer1.Report = report;

            ReportToolbar1.ReportViewer = ReportViewer1;


        }
        private void InBienBanQuyetToan()
        {
            if (cmbPhuongThuc.Value == null) return;
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

            dt = inBienBan.InBienBanQuyetToan(phuongthuc, donvi, int.Parse(cmbThang.Value + ""), int.Parse(cmbNam.Value + ""), ref strGiao, ref strNhan, ref strGDNhan, ref strGDGiao);

            MTCSYT.Report.InBienBanQT report = new MTCSYT.Report.InBienBanQT(dt, "" + cmbThang.Value, "" + cmbNam.Value, false, false, "", "", strGiao, strNhan, "", "", strGDNhan, strGDGiao);
            ReportViewer2.Report = report;

            ReportToolbar2.ReportViewer = ReportViewer2;

            
        }
        private void loadGiaoNhan()
        {
            MTCSYT.SYS_Session session = (MTCSYT.SYS_Session)Session["SYS_Session"];
            var lstDD = db.db_GD_PhuongThucCanXN(int.Parse(session.User.ma_dviqly + ""), int.Parse(cmbThang.Value + "")-1, int.Parse(cmbNam.Value + ""), "ALL").ToList();
            cmbPhuongThuc.DataSource = lstDD;
            cmbPhuongThuc.ValueField = "IDChiNhanh";
            cmbPhuongThuc.TextField = "TenPhuongThuc";
            cmbPhuongThuc.DataBind();

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
        protected void grdNhan_CustomCallback(object sender, DevExpress.Web.ASPxGridViewCustomCallbackEventArgs e)
        {
            loadTax();
        }
        protected void grdGiao_Callback(object sender, EventArgs e)
        {

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

       

    }
}