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
using System.Web.Script.Serialization;
using System.Net;
using System.Text;
using DevExpress.XtraRichEdit.Fields;

namespace MTCSYT
{
    //sCAP_DDIEN
    //sLoaiSoDoCapDien
    //DCS, LM,DT,NR
    public partial class bd_GiamDocXN : BasePage
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
            else
            {

            }
            Session["SYS_Session"] = session;
            if (!IsPostBack)
            {
                loadDSNgay();
                loadGiaoNhan();
                loadTTKy();

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
           
            var ttKy = db.HD_ThongTinKies.Where(x => x.IDChinhNhanh == int.Parse(cmbPhuongThuc.Value + "") && x.Thang == int.Parse(cmbThang.Value + "") && x.Nam == int.Parse(cmbNam.Value + "")).OrderBy(x => x.ChucVu);
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
            string strTPGiao = "", strTPNhan = "", strGDNhan = "", strGDGiao = "";
            var lstHDKy = db.HD_ThongTinKies.Where(x => x.IDChinhNhanh == int.Parse(cmbPhuongThuc.Value + "") && x.Thang == int.Parse(cmbThang.Value + "") && x.Nam == int.Parse(cmbNam.Value + ""));
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

            MTCSYT.Report.InBieuTong report = new MTCSYT.Report.InBieuTong(int.Parse(cmbPhuongThuc.Value + ""), ma_dviqly, int.Parse(cmbThang.Value + ""), int.Parse(cmbNam.Value + ""), "", "", donvi.TEN_DVIQLY, giao.TEN_DVIQLY, nhan.TEN_DVIQLY, 0, strTPNhan, strTPGiao, strGDNhan, strGDGiao);

            ReportViewer1.Report = report;

            ReportToolbar1.ReportViewer = ReportViewer1;


        }
        private void InBienBanQuyetToan()
        {
            if (cmbPhuongThuc.Value == null ) return;
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
          

            MTCSYT.Report.InBienBanQT report = new MTCSYT.Report.InBienBanQT(dt, "" + cmbThang.Value, "" + cmbNam.Value, false, false, "", "", strGiao, strNhan, "","", strGDNhan, strGDGiao);
            ReportViewer2.Report = report;

            ReportToolbar2.ReportViewer = ReportViewer2;

        }
        private void loadGiaoNhan()
        {

            MTCSYT.SYS_Session session = (MTCSYT.SYS_Session)Session["SYS_Session"];
            int strMadviqly = int.Parse(session.User.ma_dviqly);
            List<Phuongthuc> dsT = new List<Phuongthuc>();
            if (strMadviqly == 2)
            {
                var lstDD = db.db_GD_PhuongThucCanXN(int.Parse(session.User.ma_dviqly + ""), int.Parse(cmbThang.Value + ""), int.Parse(cmbNam.Value + ""), "GDXN").ToList();
                cmbPhuongThuc.DataSource = lstDD;
            }
            else
            {

                var lstDDNPC = db.db_GD_PhuongThucCanXN_NPCT(int.Parse(session.User.ma_dviqly + ""), int.Parse(cmbThang.Value + ""), int.Parse(cmbNam.Value + ""), "GDXN").ToList();
                if (lstDDNPC.Count>0)
                {
                    foreach (var list in lstDDNPC)
                    {
                        int id = int.Parse(list.DiemCuoiNguon + "");
                        int id2 = int.Parse(list.DiemDauNguon + "");
                        if (id == 2 || id2 ==2)
                        {
                            Phuongthuc ds = new Phuongthuc();
                            ds.IDChiNhanh = list.IDChiNhanh + "";
                            ds.TenPhuongThuc = list.TenPhuongThuc + "";
                            dsT.Add(ds);
                        }
                    }
                }
                var lstDD = db.db_GD_PhuongThucCanXN(int.Parse(session.User.ma_dviqly + ""), int.Parse(cmbThang.Value + ""), int.Parse(cmbNam.Value + ""), "GDXN").ToList();
                foreach (var list in lstDD)
                {
                    int id = int.Parse(list.IDChiNhanh);
                    if (id >= 586)
                    {
                        Phuongthuc ds = new Phuongthuc();
                        ds.IDChiNhanh = list.IDChiNhanh + "";
                        ds.TenPhuongThuc = list.TenPhuongThuc + "";
                        dsT.Add(ds);
                    }

                }
                cmbPhuongThuc.DataSource = dsT;
            }
                
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
      
        protected void btnDuyet_Click(object sender, EventArgs e)
        {
            MTCSYT.SYS_Session session = (MTCSYT.SYS_Session)Session["SYS_Session"];
            var userky = db.DM_USERs.SingleOrDefault(x => x.IDUSER == session.User.IDUSER);
            lbNguoiXN.Text = userky.HOTEN;
            txtSDT.Text = userky.SODT;
            pcFileKy.ShowOnPageLoad = true;

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
            int ma_dviqly = int.Parse(session.User.ma_dviqly + "");
            var lstGiao = db.HD_GiaoNhanThangs.Where(x => x.IDChiNhanh == cmbPhuongThuc.Value + "").ToList();
            foreach (var a in lstGiao)
            {
                var bd_chitiet = db.HD_GiaoNhanThangs.SingleOrDefault(x => x.ID == a.ID);
                bd_chitiet.ISNhanVien = false;
                bd_chitiet.NgayXacNhanDVGiao = DateTime.Now;
                bd_chitiet.XacNhanDVNhan = false;
                bd_chitiet.ISChot = false;

                if (txtLyDo.Text != "")
                    bd_chitiet.GhiChuXacNhanGiao = txtLyDo.Text;
                else
                    bd_chitiet.GhiChuXacNhanGiao = "Không đồng ý xác nhận điểm đo này";
                bd_chitiet.XacNhanDVGiao = false;
                bd_chitiet.ISChot = false;
                bd_chitiet.NgayXacNhanDVNhan = DateTime.Now;

                if (txtLyDo.Text != "")
                    bd_chitiet.GhiChuXacNhanNhan = txtLyDo.Text;
                else
                    bd_chitiet.GhiChuXacNhanNhan = "Không đồng ý xác nhận điểm đo này";

                db.SubmitChanges();
            }
            pcAddRoles.ShowOnPageLoad = false;
        }

        protected void btnIn_Click(object sender, EventArgs e)
        {
            MTCSYT.SYS_Session session = (MTCSYT.SYS_Session)Session["SYS_Session"];
            string strMadviqly = session.User.ma_dviqly;
            Response.Redirect("../Report/Report.aspx?ChiNhanh=" + strMadviqly + "&Loai=1&Thang=" + cmbThang.Value + "&Nam=" + cmbNam.Value + "&ParentId=1");
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

        protected void btnDongFileKy_Click(object sender, EventArgs e)
        {
            pcFileKy.ShowOnPageLoad = false;
        }
        private void xacnhanky()
        {
            MTCSYT.SYS_Session session = (MTCSYT.SYS_Session)Session["SYS_Session"];
            string strMadviqly = session.User.ma_dviqly;

            var dv = db.DM_DVQLies.SingleOrDefault(x => x.IDMA_DVIQLY == int.Parse(strMadviqly));
            var ky = db.HD_ThongTinKies.SingleOrDefault(x => x.IDChinhNhanh == int.Parse(cmbPhuongThuc.Value + "") && x.Nam == int.Parse(cmbNam.Value + "") && x.Thang == int.Parse(cmbThang.Value + "") && x.IDMaDViQLy == int.Parse(strMadviqly) && x.ChucVu == 3);
            if (ky != null)
                return;
            CBDN.HD_ThongTinKy hDKyTH = new CBDN.HD_ThongTinKy();
            hDKyTH.IDChinhNhanh = int.Parse(cmbPhuongThuc.Value + "");
            hDKyTH.NgayTao = DateTime.Now;
            hDKyTH.NguoiTao = session.User.IDUSER;
            hDKyTH.Link = "";
            hDKyTH.Barcode = "";
            hDKyTH.Thang = int.Parse(cmbThang.Value + "");
            hDKyTH.Nam = int.Parse(cmbNam.Value + "");
            hDKyTH.IDMaDViQLy = int.Parse(strMadviqly);
            //GiamDoc
            hDKyTH.ChucVu = 3;
            db.HD_ThongTinKies.InsertOnSubmit(hDKyTH);
            db.SubmitChanges();
        }
        private bool xacthuc()
        {
            MTCSYT.SYS_Session session = (MTCSYT.SYS_Session)Session["SYS_Session"];

            //kiểm tra mã otp

            // gửi mã xác thực
            string services;
            ServicePointManager.ServerCertificateValidationCallback = (senderX, certificate, chain, sslPolicyErrors) => { return true; };
            WebClient client = new WebClient();
            client.Headers["Content-type"] = "application/json";
            client.Encoding = Encoding.UTF8;

            var donvi = db.DM_DVQLies.SingleOrDefault(x => x.IDMA_DVIQLY == int.Parse(session.User.ma_dviqly));
            string SQL = "http://10.21.50.212:8082/api/HsoDtuNPC/verify?strOTP=" + txtOTP.Text + "&strtoken=" + lbOTP.Text + "&struserID=" + txtSDT.Text;
            string json = client.DownloadString(SQL);
            services = (new JavaScriptSerializer()).Deserialize<string>(json);
            if (services.Contains("không"))
            {
                return false;
            }

            // lưu lại sdt
            var userky = db.DM_USERs.SingleOrDefault(x => x.IDUSER == session.User.IDUSER);
            if (userky.SODT != txtSDT.Text)
            {
                //userky.HOTEN = txtHoTenNguoiKy.Text;
                userky.SODT = txtSDT.Text;
                db.SubmitChanges();
            }
            return true;
        }
        protected void btnLuuFile_Click(object sender, EventArgs e)
        {
            if (!xacthuc())
            {
                ScriptManager.RegisterStartupScript(Page, Page.GetType(), "", "alert('Lỗi mã OTP không chính xác');", true);
                return;
            }
            xacnhanky();
            MTCSYT.SYS_Session session = (MTCSYT.SYS_Session)Session["SYS_Session"];
            int ma_dviqly = int.Parse(session.User.ma_dviqly + "");

            //var chinhanh = db.DM_ChiNhanhs.SingleOrDefault(x => x.ID == int.Parse(tlDonVi.FocusedNode.Key));
            var congto = db.DM_CongTos.Where(x => x.IDChiNhanh == cmbPhuongThuc.Value + "");
            int dvGiao = 0, idDVNhan = 0;
            CBDN.DM_CongTo cto = new CBDN.DM_CongTo();
            foreach (var ct in congto)
            {
                cto = ct;
                break;
            }
            dvGiao = (int)cto.IDDonViGiao;
            idDVNhan = (int)cto.IDDonViNhan;

            var gdXN = db.HD_GiamDocXNGiaoNhans.SingleOrDefault(x => x.IDChiNhanh == cto.IDChiNhanh + "" && x.Thang == int.Parse(cmbThang.Value + "") && x.Nam == int.Parse(cmbNam.Value + ""));
            if (gdXN == null)
            {
                CBDN.HD_GiamDocXNGiaoNhan gd = new CBDN.HD_GiamDocXNGiaoNhan();
                gd.IDChiNhanh = cto.IDChiNhanh + "";
                if (dvGiao == ma_dviqly)
                {
                    gd.IDGDGXN = ma_dviqly;
                    gd.ISGDGXN = true;
                    gd.NgayGDGXN = DateTime.Now;
                    gd.IDUserGiaoXN = session.User.IDUSER;
                }
                else if (idDVNhan == ma_dviqly)
                {
                    gd.IDGDNXN = ma_dviqly;
                    gd.ISGDNXN = true;
                    gd.NgayGDNXN = DateTime.Now;
                    gd.IDUserNhanXN = session.User.IDUSER;
                }
                gd.Thang = int.Parse("" + cmbThang.Value);
                gd.Nam = int.Parse("" + cmbNam.Value);
                db.HD_GiamDocXNGiaoNhans.InsertOnSubmit(gd);
                db.SubmitChanges();
            }
            else
            {
                if (dvGiao == ma_dviqly)
                {
                    gdXN.IDGDGXN = ma_dviqly;
                    gdXN.ISGDGXN = true;
                    gdXN.NgayGDGXN = DateTime.Now;
                    gdXN.IDUserGiaoXN = session.User.IDUSER;
                }
                else if (idDVNhan == ma_dviqly)
                {
                    gdXN.IDGDNXN = ma_dviqly;
                    gdXN.ISGDNXN = true;
                    gdXN.NgayGDNXN = DateTime.Now;
                    gdXN.IDUserNhanXN = session.User.IDUSER;
                }
                db.SubmitChanges();
                InTongHopDienNang();
                InBienBanQuyetToan();
            }
        }

        protected void btnGuiMa_Click(object sender, EventArgs e)
        {
            MTCSYT.SYS_Session session = (MTCSYT.SYS_Session)Session["SYS_Session"];
            // gửi mã xác thực
            List<PUSHRESULT> services = new List<PUSHRESULT>();
            ServicePointManager.ServerCertificateValidationCallback = (senderX, certificate, chain, sslPolicyErrors) => { return true; };
            WebClient client = new WebClient();
            client.Headers["Content-type"] = "application/json";
            client.Encoding = Encoding.UTF8;

            var donvi = db.DM_DVQLies.SingleOrDefault(x => x.IDMA_DVIQLY == int.Parse(session.User.ma_dviqly));
            string SQL = "http://10.21.50.212:8082/api/HsoDtuNPC/generate?strbrandname=" + donvi.TenVietTat + "&strType=1&struserID=" + txtSDT.Text + "&strRegion=" + donvi.MA_DVIQLY;
            string json = client.DownloadString(SQL);
            services = (new JavaScriptSerializer()).Deserialize<List<PUSHRESULT>>(json);
            lbOTP.Text = services[0].token;
        }
        public class Phuongthuc
        {
            public string IDChiNhanh { get; set; }
            public string TenPhuongThuc { get; set; }
        }

    }
}