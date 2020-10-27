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
namespace MTCSYT
{
    //sCAP_DDIEN
    //sLoaiSoDoCapDien
    //DCS, LM,DT,NR
    public partial class bd_xacNhanSL : BasePage
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
            if (!IsPostBack)
            {
                loadDSNgay();
                loadGiaoNhan();

            }
            bool giao = LoadGrdGiao();
            bool nhan = LoadGrdNhan();

            InTongHopDienNang();
            InBienBanQuyetToan();
            loadTTKy();
        }
        private void InTongHopDienNang()
        {
            if (cmbPhuongThuc.Value == null || cmbPhuongThuc.Value + "" == "0")
                return;
            MTCSYT.SYS_Session session = (MTCSYT.SYS_Session)Session["SYS_Session"];
            int ma_dviqly = int.Parse(session.User.ma_dviqly);
            DM_DVQLYService dm_dviSer = new DM_DVQLYService();
            var donvi = dm_dviSer.SelectDM_DVQLY(ma_dviqly);
           
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


            MTCSYT.Report.InBieuTong report = new MTCSYT.Report.InBieuTong(int.Parse(cmbPhuongThuc.Value + ""), ma_dviqly, int.Parse(cmbThang.Value + ""), int.Parse(cmbNam.Value + ""), "", "", donvi.TEN_DVIQLY, giao.TEN_DVIQLY, nhan.TEN_DVIQLY, 0, strTPNhan, strTPGiao, "", "");

            ReportViewer1.Report = report;

            ReportToolbar1.ReportViewer = ReportViewer1;


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
        private void InBienBanQuyetToan()
        {
            if (cmbPhuongThuc.Value == null)
                return;
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
            dt = inBienBan.InBienBanQuyetToan(phuongthuc, donvi, int.Parse(cmbThang.Value + ""), int.Parse(cmbNam.Value + ""), ref strGiao, ref strNhan, ref strGDNhan, ref strGiao);
          
            MTCSYT.Report.InBienBanQT report = new MTCSYT.Report.InBienBanQT(dt, "" + cmbThang.Value, "" + cmbNam.Value, false, false, "", "", strGiao,strNhan, "", "",strGDNhan, strGDGiao);
            ReportViewer2.Report = report;

            ReportToolbar2.ReportViewer = ReportViewer2;

        }
        private void loadGiaoNhan()
        {
            //Where(x => x.IDChiNhanh == cmbPhuongThuc.Value + "");
            MTCSYT.SYS_Session session = (MTCSYT.SYS_Session)Session["SYS_Session"];
            List<Phuongthuc> dsT = new List<Phuongthuc>();
            if (int.Parse(session.User.ma_dviqly + "") == 2)
            {
                var lstDD = db.db_SelectPhuongThucCanXN(int.Parse(session.User.ma_dviqly + ""), int.Parse(cmbThang.Value + ""), int.Parse(cmbNam.Value + ""), "TPXacNhan").ToList();
                foreach(var list in lstDD)
                {
                    var a = db.HD_GiamDocXNGiaoNhans.Where(x => x.IDChiNhanh == list.IDChiNhanh + "").Where(x => x.Thang == int.Parse(cmbThang.Value + "")).Where(x => x.Nam == int.Parse(cmbNam.Value + "")).ToList();
                    var b = db.HD_ThongTinKies.Where(x => x.IDChinhNhanh == int.Parse(list.IDChiNhanh + "")).Where(x => x.Thang == int.Parse(cmbThang.Value + "")).Where(x => x.Nam == int.Parse(cmbNam.Value + "")).Where(x => x.ChucVu ==3).ToList();
                    if (a.Count!=0 || b.Count != 0)
                    {
                        Phuongthuc ds = new Phuongthuc();
                        ds.IDChiNhanh = list.IDChiNhanh + "";
                        ds.TenPhuongThuc = list.TenPhuongThuc + "";
                        dsT.Add(ds);
                    }
                }
                cmbPhuongThuc.DataSource = dsT;
            }
            else
            {
                var lstDDALL = db.db_SelectPhuongThucCanXN(int.Parse(session.User.ma_dviqly + ""), int.Parse(cmbThang.Value + ""), int.Parse(cmbNam.Value + ""), "TPXNALL").ToList();
                foreach (var list in lstDDALL)
                {
                    if (list.IDChiNhanh != 0)
                    {
                        var checkphuongthuc = db.DM_ChiNhanhs.SingleOrDefault(x => x.ID == int.Parse(list.IDChiNhanh + ""));
                        if (checkphuongthuc.DiemCuoiNguon == 2 || checkphuongthuc.DiemDauNguon == 2)
                        {
                            Phuongthuc ds = new Phuongthuc();
                            ds.IDChiNhanh = list.IDChiNhanh + "";
                            ds.TenPhuongThuc = list.TenPhuongThuc + "";
                            dsT.Add(ds);
                        }
                    }
                }
                    var lstDD = db.db_SelectPhuongThucCanXN(int.Parse(session.User.ma_dviqly + ""), int.Parse(cmbThang.Value + ""), int.Parse(cmbNam.Value + ""), "TPXacNhan").ToList();
                foreach (var list in lstDD)
                {
                    if (list.IDChiNhanh !=0)
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
        private bool LoadGrdGiao()
        {
            if (cmbPhuongThuc.Value == null)
                return false;
            bool kiemtra = false;
            MTCSYT.SYS_Session session = (MTCSYT.SYS_Session)Session["SYS_Session"];
            int strMadviqly = int.Parse(session.User.ma_dviqly);
            var lstGiao = db.db_DSDiemGiaoCanXacNhan(strMadviqly, int.Parse(cmbThang.Value + ""), int.Parse(cmbNam.Value + ""), int.Parse(cmbPhuongThuc.Value + "")).ToList();
            if (lstGiao.Count > 0)
                kiemtra = true;
            else
                kiemtra = false;
            grdGiao.DataSource = lstGiao;
            grdGiao.DataBind();

            grdSLGiao.DataSource = lstGiao;
            grdSLGiao.DataBind();
            return kiemtra;
        }
        private bool LoadGrdNhan()
        {
            if (cmbPhuongThuc.Value == null)
                return false;
            bool kiemtra = false;
            MTCSYT.SYS_Session session = (MTCSYT.SYS_Session)Session["SYS_Session"];
            int strMadviqly = int.Parse(session.User.ma_dviqly);
            var lstGiao = db.db_DSDiemNhanCanXacNhan(strMadviqly, int.Parse(cmbThang.Value + ""), int.Parse(cmbNam.Value + ""), int.Parse(cmbPhuongThuc.Value + "")).ToList();
            if (lstGiao.Count > 0)
                kiemtra = true;
            else
                kiemtra = false;
            grdNhan.DataSource = lstGiao;
            grdNhan.DataBind();

            grdSLNhan.DataSource = lstGiao;
            grdSLNhan.DataBind();
            return kiemtra;
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
            lbNguoiXacNhan.Text = userky.HOTEN;
            txtSDT.Text = userky.SODT;
            pcFileKy.ShowOnPageLoad = true;

            InTongHopDienNang();
            InBienBanQuyetToan();
        }


        protected void grdGiao_CustomCallback(object sender, DevExpress.Web.ASPxGridViewCustomCallbackEventArgs e)
        {
            LoadGrdGiao();
        }
        protected void grdNhan_CustomCallback(object sender, DevExpress.Web.ASPxGridViewCustomCallbackEventArgs e)
        {
            LoadGrdNhan();
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

            var lstNhan = db.db_DSDiemNhanCanXacNhan(int.Parse(strMadviqly), int.Parse(cmbThang.Value + ""), int.Parse(cmbNam.Value + ""), int.Parse(cmbPhuongThuc.Value + "")).ToList();
            foreach (var a in lstNhan)
            {
                var bd_chitiet = db.HD_GiaoNhanThangs.SingleOrDefault(x => x.ID == a.ID);
                bd_chitiet.XacNhanDVNhan = false;
                bd_chitiet.ISChot = false;
                bd_chitiet.IDXacNhanNhan = int.Parse(strMadviqly);
                bd_chitiet.NgayXacNhanDVNhan = DateTime.Now;
                if(int.Parse(strMadviqly) == 2)
                {
                    bd_chitiet.ISNhanVien = false;
                }    
                if (txtLyDo.Text != "")
                    bd_chitiet.GhiChuXacNhanNhan = txtLyDo.Text;
                else
                    bd_chitiet.GhiChuXacNhanNhan = "Không đồng ý xác nhận điểm đo này";

                db.SubmitChanges();
            }

            var lstGiao = db.db_DSDiemGiaoCanXacNhan(int.Parse(strMadviqly), int.Parse(cmbThang.Value + ""), int.Parse(cmbNam.Value + ""), int.Parse(cmbPhuongThuc.Value + "")).ToList();
            foreach (var a in lstGiao)
            {
                var bd_chitiet = db.HD_GiaoNhanThangs.SingleOrDefault(x => x.ID == a.ID);
                bd_chitiet.XacNhanDVGiao = false;
                bd_chitiet.IDXacNhanGiao = int.Parse(strMadviqly);
                bd_chitiet.NgayXacNhanDVGiao = DateTime.Now;
                bd_chitiet.ISChot = false;
                if (int.Parse(strMadviqly) == 2)
                {
                    bd_chitiet.ISNhanVien = false;
                }

                if (txtLyDo.Text != "")
                    bd_chitiet.GhiChuXacNhanGiao = txtLyDo.Text;
                else
                    bd_chitiet.GhiChuXacNhanGiao = "Không đồng ý xác nhận điểm đo này";

                db.SubmitChanges();
            }
            huyxacnhanky();
            LoadGrdGiao();
            LoadGrdNhan();

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
            bool giao = LoadGrdGiao();
            bool nhan = LoadGrdNhan();
        }

        protected void cmbThang_SelectedIndexChanged(object sender, EventArgs e)
        {
            bool giao = LoadGrdGiao();
            bool nhan = LoadGrdNhan();
        }

        protected void cmbPhuongThuc_SelectedIndexChanged(object sender, EventArgs e)
        {
            InTongHopDienNang();
            InBienBanQuyetToan();
            LoadGrdGiao();
            LoadGrdNhan();
        }

        protected void btnDongFileKy_Click(object sender, EventArgs e)
        {
            pcFileKy.ShowOnPageLoad = false;
        }

        private void huyxacnhanky()
        {
            MTCSYT.SYS_Session session = (MTCSYT.SYS_Session)Session["SYS_Session"];
            string strMadviqly = session.User.ma_dviqly;

            var dv = db.DM_DVQLies.SingleOrDefault(x => x.IDMA_DVIQLY == int.Parse(strMadviqly));
            var lstHDKy = db.HD_ThongTinKies.Where(x => x.IDChinhNhanh == int.Parse(cmbPhuongThuc.Value + "") && x.Thang == int.Parse(cmbThang.Value + "") && x.Nam == int.Parse(cmbNam.Value + "") && x.TrangThai == null);
            
            foreach (var list in lstHDKy)
            {
                list.TrangThai = 0;
                db.SubmitChanges();
            }
            var lstHDKyGD = db.HD_GiamDocXNGiaoNhans.Where(x => x.IDChiNhanh == (cmbPhuongThuc.Value + "") && x.Thang == int.Parse(cmbThang.Value + "") && x.Nam == int.Parse(cmbNam.Value + "") && x.TrangThai == null);
            foreach (var list in lstHDKyGD)
            {
                list.TrangThai = 0;
                db.SubmitChanges();
            }


        }
        private void xacnhanky()
        {
            MTCSYT.SYS_Session session = (MTCSYT.SYS_Session)Session["SYS_Session"];
            string strMadviqly = session.User.ma_dviqly;

            var dv = db.DM_DVQLies.SingleOrDefault(x => x.IDMA_DVIQLY == int.Parse(strMadviqly));
            var ky = db.HD_ThongTinKies.SingleOrDefault(x => x.IDChinhNhanh == int.Parse(cmbPhuongThuc.Value + "") && x.Nam == int.Parse(cmbNam.Value + "") && x.Thang == int.Parse(cmbThang.Value + "") && x.IDMaDViQLy == int.Parse(strMadviqly) && x.ChucVu == 2 && x.TrangThai == null);
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
            //TruongPhong
            hDKyTH.ChucVu = 2;
            db.HD_ThongTinKies.InsertOnSubmit(hDKyTH);
            db.SubmitChanges();

        }
        protected void btnLuuFile_Click(object sender, EventArgs e)
        {

            //Kiểm tra mã xác thực 
            if (!xacthuc())
            {
                ScriptManager.RegisterStartupScript(Page, Page.GetType(), "", "alert('Lỗi mã OTP không chính xác');", true);
                return;
            }
            xacnhanky();

            try
            {
                MTCSYT.SYS_Session session = (MTCSYT.SYS_Session)Session["SYS_Session"];
                string strMadviqly = session.User.ma_dviqly;

                var lstNhan = db.db_DSDiemNhanCanXacNhan(int.Parse(strMadviqly), int.Parse(cmbThang.Value + ""), int.Parse(cmbNam.Value + ""), int.Parse(cmbPhuongThuc.Value + "")).ToList();
                foreach (var a in lstNhan)
                {
                    var bd_chitiet = db.HD_GiaoNhanThangs.SingleOrDefault(x => x.ID == a.ID);

                    bd_chitiet.XacNhanDVNhan = true;
                    bd_chitiet.IDXacNhanNhan = int.Parse(strMadviqly);
                    bd_chitiet.NgayXacNhanDVNhan = DateTime.Now;
                    bd_chitiet.IDTPNhanXN = session.User.IDUSER;

                    db.SubmitChanges();
                }

                var lstGiao = db.db_DSDiemGiaoCanXacNhan(int.Parse(strMadviqly), int.Parse(cmbThang.Value + ""), int.Parse(cmbNam.Value + ""), int.Parse(cmbPhuongThuc.Value + "")).ToList();
                foreach (var a in lstGiao)
                {
                    var bd_chitiet = db.HD_GiaoNhanThangs.SingleOrDefault(x => x.ID == a.ID);
                    bd_chitiet.XacNhanDVGiao = true;
                    bd_chitiet.IDXacNhanGiao = int.Parse(strMadviqly);
                    bd_chitiet.NgayXacNhanDVGiao = DateTime.Now;
                    bd_chitiet.IDTPGiaoXN = session.User.IDUSER;

                    db.SubmitChanges();
                }

                ScriptManager.RegisterStartupScript(Page, Page.GetType(), "", "alert('Đã xác nhận số liệu thành công');", true);
                LoadGrdGiao();
                LoadGrdNhan();
                InTongHopDienNang();
                InBienBanQuyetToan();

            }
            catch (Exception ex)
            {
                ScriptManager.RegisterStartupScript(Page, Page.GetType(), "", "alert('Lỗi duyệt chấm nợ " + ex.Message + "');", true);

            }
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
            string SQL = "";

            int strMadviqly = int.Parse(session.User.ma_dviqly), intdonvi;
            if (strMadviqly == 2)
            {
                if (cmbPhuongThuc.Value +""!="0")
                {
                    intdonvi = int.Parse(db.DM_ChiNhanhs.SingleOrDefault(x => x.ID == int.Parse(cmbPhuongThuc.Value + "")).IDMADVIQLY.Replace(",2,", "").Replace(",", ""));
                    var donvi = db.DM_DVQLies.SingleOrDefault(x => x.IDMA_DVIQLY == intdonvi);
                    SQL = "http://10.21.50.212:8082/api/HsoDtuNPC/verify?strOTP=" + txtOTP.Text + "&strtoken=" + lbOTP.Text + "&struserID=" + txtSDT.Text;
                }
                else
                {
                    SQL = "http://10.21.50.212:8082/api/HsoDtuNPC/verify?strOTP=PA2201&strtoken=" + lbOTP.Text + "&struserID=PC_BacNinh";

                }

            }
            else
            {
                var donvi = db.DM_DVQLies.SingleOrDefault(x => x.IDMA_DVIQLY == strMadviqly);
                SQL = "http://10.21.50.212:8082/api/HsoDtuNPC/verify?strOTP=" + txtOTP.Text + "&strtoken=" + lbOTP.Text + "&struserID=" + txtSDT.Text;
            }
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
        protected void btnGuiMa_Click(object sender, EventArgs e)
        {
            MTCSYT.SYS_Session session = (MTCSYT.SYS_Session)Session["SYS_Session"];
            // gửi mã xác thực
            List<PUSHRESULT> services = new List<PUSHRESULT>();
            ServicePointManager.ServerCertificateValidationCallback = (senderX, certificate, chain, sslPolicyErrors) => { return true; };
            WebClient client = new WebClient();
            client.Headers["Content-type"] = "application/json";
            client.Encoding = Encoding.UTF8;
            string SQL = "";
            int strMadviqly = int.Parse(session.User.ma_dviqly), intdonvi;
            if (strMadviqly == 2)
            {
                if (cmbPhuongThuc.Value + "" != "0")
                {
                    intdonvi = int.Parse(db.DM_ChiNhanhs.SingleOrDefault(x => x.ID == int.Parse(cmbPhuongThuc.Value + "")).IDMADVIQLY.Replace(",2,", "").Replace(",", ""));
                    var donvi = db.DM_DVQLies.SingleOrDefault(x => x.IDMA_DVIQLY == intdonvi);
                    SQL = "http://10.21.50.212:8082/api/HsoDtuNPC/generate?strbrandname=" + donvi.TenVietTat + "&strType=1&struserID=" + txtSDT.Text + "&strRegion=" + donvi.MA_DVIQLY;
                }
                else
                {                    
                    SQL = "http://10.21.50.212:8082/api/HsoDtuNPC/generate?strbrandname=PC_BacNinh&strType=1&struserID=" + txtSDT.Text + "&strRegion=PA2201";
                }

            }
            else
            {
                var donvi = db.DM_DVQLies.SingleOrDefault(x => x.IDMA_DVIQLY == strMadviqly);
                SQL = "http://10.21.50.212:8082/api/HsoDtuNPC/generate?strbrandname=" + donvi.TenVietTat + "&strType=1&struserID=" + txtSDT.Text + "&strRegion=" + donvi.MA_DVIQLY;
            }
             
            string json = client.DownloadString(SQL);
            services = (new JavaScriptSerializer()).Deserialize<List<PUSHRESULT>>(json);
            lbOTP.Text = services[0].token;
        }

    }
    public class PUSHRESULT
    {
        private string _message; public string message { get { return _message; } set { _message = value; } }
        private string _token; public string token { get { return _token; } set { _token = value; } }
    }
    public class Phuongthuc
    {
        public string IDChiNhanh { get; set; }
        public string TenPhuongThuc { get; set; }
    }
}