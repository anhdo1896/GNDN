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
    public partial class bc_BieuTong_QT_ALL : BasePage
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
            if (!IsPostBack)
            {
                loadDSNgay();
                loadGiaoNhan();

            }

            InTongHopDienNang();
            InBienBanQuyetToan();
            loadTTKy();
        }
        private void loadTTKy()
        {
            if (cmbPhuongThuc.Value == null || cmbPhuongThuc.Value + "" == "0")
            {

                if (lbTP1.Text == "")
                {
                    imgAnhKyTP1.Visible = false;
                }
                if (lbTP2.Text == "")
                {
                    imgAnhKyTP2.Visible = false;
                }
                if (lbGiamDocKy.Text == "")
                {
                    imgAnhKyGD.Visible = false;
                }
                if (lbGiamDocKy2.Text == "")
                {
                    imgAnhKyGD2.Visible = false;

                }
                return;
            }

            if (lbTP1.Text == "")
            {
                imgAnhKyTP1.Visible = true;
            }
            if (lbTP2.Text == "")
            {
                imgAnhKyTP2.Visible = true;
            }
            if (lbGiamDocKy.Text == "")
            {
                imgAnhKyGD.Visible = true;
            }
            if (lbGiamDocKy2.Text == "")
            {
                imgAnhKyGD2.Visible = true;
            }
            lbNhanVienKy.Text = "";
            lbTP1.Text = "";
            lbTP2.Text = "";
            lbGiamDocKy.Text = "";
            lbGiamDocKy2.Text = "";
            var ttKy = db.HD_ThongTinKies.Where(x => x.IDChinhNhanh == int.Parse(cmbPhuongThuc.Value + "") && x.Thang == int.Parse(cmbThang.Value + "") && x.Nam == int.Parse(cmbNam.Value + "") && x.TrangThai == null).OrderBy(x => x.ChucVu);
            foreach (var ky in ttKy)
            {

                var user = db.DM_USERs.SingleOrDefault(x => x.IDUSER == ky.NguoiTao);
                if (user != null)
                {

                    if (ky.ChucVu == 1)
                    {
                        if (user.CHUCDANH == null) user.CHUCDANH = "Nhân Viên";
                        lbNhanVienKy.Text = user.CHUCDANH + "&nbsp;" + "xác nhận: " + user.HOTEN + "&nbsp;&nbsp; &nbsp;&nbsp;&nbsp;" + "Thời gian xác nhận: " + String.Format("{0:dd-MM-yyyy HH:mm:ss}", ky.NgayTao);

                    }
                    else if (ky.ChucVu == 2)
                    {
                        if (lbTP1.Text == "")
                        {
                            if (user.CHUCDANH == null) user.CHUCDANH = "Trưởng Phòng";
                            lbTP1.Text = user.CHUCDANH + "&nbsp;" + "đã xác nhận: " + user.HOTEN + "&nbsp;&nbsp; &nbsp;&nbsp;&nbsp;" + "Thời gian xác nhận: " + String.Format("{0:dd-MM-yyyy HH:mm:ss}", ky.NgayTao) + "</br>";

                        }
                        else
                        {
                            if (user.CHUCDANH == null) user.CHUCDANH = "Trưởng Phòng";
                            lbTP2.Text = user.CHUCDANH + "&nbsp;" + "đã xác nhận: " + user.HOTEN + "&nbsp;&nbsp; &nbsp;&nbsp;&nbsp;" + "Thời gian xác nhận: " + String.Format("{0:dd-MM-yyyy HH:mm:ss}", ky.NgayTao) + "</br>";
                            if (lbTP2.Text == lbTP1.Text)
                            {
                                lbTP2.Text = "";
                            }
                        }

                    }
                    else if (ky.ChucVu == 3)
                    {
                        if (lbGiamDocKy.Text == "")
                        {
                            if (user.CHUCDANH == null) user.CHUCDANH = "Giám Đốc";
                            lbGiamDocKy.Text = user.CHUCDANH + "&nbsp;" + " đã xác nhận: " + user.HOTEN + "&nbsp;&nbsp; &nbsp;&nbsp;&nbsp;" + "Thời gian xác nhận: " + String.Format("{0:dd-MM-yyyy HH:mm:ss}", ky.NgayTao) + "</br>";

                        }
                        else
                        {
                            if (user.CHUCDANH == null) user.CHUCDANH = "Giám Đốc";
                            lbGiamDocKy2.Text = user.CHUCDANH + "&nbsp;" + " đã xác nhận: " + user.HOTEN + "&nbsp;&nbsp; &nbsp;&nbsp;&nbsp;" + "Thời gian xác nhận: " + String.Format("{0:dd-MM-yyyy HH:mm:ss}", ky.NgayTao) + "</br>";

                            if (lbGiamDocKy.Text == lbGiamDocKy2.Text)
                            {
                                lbGiamDocKy2.Text = "";
                            }

                        }
                    }

                }

            }
            if (lbTP1.Text == "")
            {
                imgAnhKyTP1.Visible = false;
            }
            if (lbTP2.Text == "")
            {
                imgAnhKyTP2.Visible = false;
            }
            if (lbGiamDocKy.Text == "")
            {
                imgAnhKyGD.Visible = false;
            }
            if (lbGiamDocKy2.Text == "")
            {
                imgAnhKyGD2.Visible = false;
            }

        }
        private void InTongHopDienNang()
        {
            if (cmbPhuongThuc.Value == null || cmbPhuongThuc.Value + "" == "") return;

                MTCSYT.SYS_Session session = (MTCSYT.SYS_Session)Session["SYS_Session"];
                int ma_dviqly = int.Parse(session.User.ma_dviqly);
                DM_DVQLYService dm_dviSer = new DM_DVQLYService();
                var donvi = dm_dviSer.SelectDM_DVQLY(ma_dviqly);

                //  if (Request["XacNhan"] + "" == "1") kiemtra = true;

                var cn = db.DM_ChiNhanhs.SingleOrDefault(x => x.ID == int.Parse(cmbPhuongThuc.Value + ""));
                var giao = db.DM_DVQLies.SingleOrDefault(x => x.IDMA_DVIQLY == cn.DiemDauNguon);
                var nhan = db.DM_DVQLies.SingleOrDefault(x => x.IDMA_DVIQLY == cn.DiemCuoiNguon);

                string strTPGiao = "", strTPNhan = "", strGDNhan = "", strGDGiao = "";
                //var imTPGiao = db.HD_ThongTinKies.SingleOrDefault(x => x.IDMaDViQLy == cn.DiemDauNguon && x.IDChinhNhanh==int.Parse(cmbPhuongThuc.Value+"") && x.Thang == int.Parse(cmbThang.Value + "") && x.Nam == int.Parse(cmbNam.Value + "") && x.ChucVu == 2);
                //var imTPNhan = db.HD_ThongTinKies.SingleOrDefault(x => x.IDMaDViQLy == cn.DiemCuoiNguon && x.IDChinhNhanh == int.Parse(cmbPhuongThuc.Value + "") && x.Thang == int.Parse(cmbThang.Value + "") && x.Nam == int.Parse(cmbNam.Value + "") && x.ChucVu == 2);

                var imGDGiao = db.HD_ThongTinKies.SingleOrDefault(x => x.IDMaDViQLy == cn.DiemDauNguon && x.IDChinhNhanh == int.Parse(cmbPhuongThuc.Value + "") && x.Thang == int.Parse(cmbThang.Value + "") && x.Nam == int.Parse(cmbNam.Value + "") && x.ChucVu == 3 && x.TrangThai == null);
                var imGDNhan = db.HD_ThongTinKies.SingleOrDefault(x => x.IDMaDViQLy == cn.DiemCuoiNguon && x.IDChinhNhanh == int.Parse(cmbPhuongThuc.Value + "") && x.Thang == int.Parse(cmbThang.Value + "") && x.Nam == int.Parse(cmbNam.Value + "") && x.ChucVu == 3 && x.TrangThai == null);

                //if (imTPGiao != null)
                //    strTPGiao = imTPGiao.Link;
                //if (imTPNhan != null)
                //    strTPNhan = imTPNhan.Link;
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

                MTCSYT.Report.InBieuTong report = new MTCSYT.Report.InBieuTong(int.Parse(cmbPhuongThuc.Value + ""), ma_dviqly, int.Parse(cmbThang.Value + ""), int.Parse(cmbNam.Value + ""), "", "", donvi.TEN_DVIQLY, giao.TEN_DVIQLY,nhan.TEN_DVIQLY, 0, strTPNhan, strTPGiao, strGDNhan, strGDGiao);

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
            if (phuongthuc != 0)
            {
                var checkphuongthuc = db.DM_ChiNhanhs.SingleOrDefault(x => x.ID == phuongthuc);
                if (checkphuongthuc.DiemCuoiNguon == 2 || checkphuongthuc.DiemDauNguon == 2)
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
            var lstDD = db.db_GD_PhuongThucCanXN(int.Parse(session.User.ma_dviqly + ""), int.Parse(cmbThang.Value + ""), int.Parse(cmbNam.Value + ""), "1").ToList();
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

        protected void grdGiao_Callback(object sender, EventArgs e)
        {

        }

        protected void cmbNam_SelectedIndexChanged(object sender, EventArgs e)
        {
            InTongHopDienNang();
            InBienBanQuyetToan();

        }

        protected void cmbThang_SelectedIndexChanged(object sender, EventArgs e)
        {
            InTongHopDienNang();
            InBienBanQuyetToan();
        }

        protected void cmbPhuongThuc_SelectedIndexChanged(object sender, EventArgs e)
        {
            InTongHopDienNang();
            InBienBanQuyetToan();
        }



    }
}