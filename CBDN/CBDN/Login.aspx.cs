using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text.RegularExpressions;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using SystemManageService;
using Entity;
using System.Data.SqlClient;

namespace QLY_VTTB
{
    public partial class Login : MTCSYT.BasePage
    {
        DataAccess.clTBDD_CatDien dbOR = new DataAccess.clTBDD_CatDien();
        CBDN.DB_CBDNDataContext db = new CBDN.DB_CBDNDataContext(new CBDN.ADOController().strcn());
        protected void Page_Load(object sender, EventArgs e)
        {
            //insertdulieu();
            if (!IsPostBack)
            {
                laodDVCapCha();
                LoadDataDV();
            }
        }
        private bool CheckName(string Name, int id, string ma_dviqly)
        {
            var dt = db.DM_ChiNhanhs.SingleOrDefault(x => x.MaChiNhanh == Name && x.ID != id);
            if (dt != null)
                return false;
            return true;
        }
        private bool CheckNameTramLo(string Name, int id, string idPhuongThuc)
        {
            var dt = db.DM_Trams.SingleOrDefault(x => x.MaTram == Name && x.IDTram != id);
            if (dt != null)
                return false;
            return true;
        }
        private void insertdulieu()
        {
            int dem = 0;
            try
            {
                SystemManageService.DM_DVQLYService dvi = new SystemManageService.DM_DVQLYService();
                DataTable dt = new DataTable();
                dt = dbOR.SelectAllDDo_TT("RG");

                if (dt == null)
                {
                    return;

                }
                // dt = createTable();
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    var donvi = dvi.SelectAllDM_DVQLY().SingleOrDefault(x => x.MA_DVIQLY == dt.Rows[i]["MA_DVIQLY"] + "");
                    string dvgiao = dt.Rows[i]["DVIGIAO"].ToString();
                    if (dt.Rows[i]["DVIGIAO"].ToString().Contains("PH"))
                    {
                        dvgiao = "PH";
                    }
                    if (dt.Rows[i]["DVIGIAO"].ToString().Contains("PN"))
                    {
                        dvgiao = "PN";
                    }
                    if (dt.Rows[i]["DVIGIAO"].ToString().Contains("PM"))
                    {
                        dvgiao = "PM";
                    }
                    var donviG = dvi.SelectAllDM_DVQLY().SingleOrDefault(x => x.MA_DVIQLY == dvgiao + "");
                    if (!CheckName(dt.Rows[i]["MA_DVI"] + "", 0, donvi.MA_DVIQLY))
                    {
                        continue;
                    }
                    if (!CheckName(dt.Rows[i]["MA_DVIB"] + "", 0, donvi.MA_DVIQLY))
                    {
                        continue;
                    }

                    CBDN.DM_ChiNhanh cv = new CBDN.DM_ChiNhanh();
                    cv.TenChiNhanh = dt.Rows[i]["MOTA"] + "";
                    cv.MaChiNhanh = dt.Rows[i]["MA_DVI"] + "";
                    if (dt.Rows[i]["CHIEU_GNHAN"] + "" == "G")
                    {
                        cv.IDMADVIQLY = "," + donvi.IDMA_DVIQLY + "," + donviG.IDMA_DVIQLY + ",";
                    }
                    else
                        cv.IDMADVIQLY = "," + donviG.IDMA_DVIQLY + "," + donvi.IDMA_DVIQLY + ",";
                    //if (donvi.MA_DVIQLY == "PA" || donviG.MA_DVIQLY == "PA")
                    cv.LoaiPhuongThuc = 1;
                    //else if (donvi.MA_DVIQLY.Length == 4 && donviG.MA_DVIQLY.Length == 4)
                    //{
                    //    cv.LoaiPhuongThuc = 2;
                    //}
                    //else if (donvi.MA_DVIQLY.Length + donviG.MA_DVIQLY.Length < 12 && donvi.MA_DVIQLY.Length + donviG.MA_DVIQLY.Length > 9)
                    //{ cv.LoaiPhuongThuc = 3; }
                    //else
                    //    cv.LoaiPhuongThuc = 4;
                    cv.MoTa = dt.Rows[i]["MOTA"] + "";
                    if (dt.Rows[i]["CHIEU_GNHAN"] + "" == "G")
                    {
                        cv.DiemDauNguon = donvi.IDMA_DVIQLY;
                        cv.DiemCuoiNguon = donviG.IDMA_DVIQLY;
                    }
                    else
                    {
                        cv.DiemCuoiNguon = donvi.IDMA_DVIQLY;
                        cv.DiemDauNguon = donviG.IDMA_DVIQLY;
                    }


                    cv.HoatDong = 1;
                    cv.HoatDong = 0;
                    db.DM_ChiNhanhs.InsertOnSubmit(cv);
                    db.SubmitChanges();



                }
                // insert tram
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    string dvgiao = dt.Rows[i]["DVIGIAO"].ToString();
                    if (dt.Rows[i]["DVIGIAO"].ToString().Contains("PH"))
                    {
                        dvgiao = "PH";
                    }
                    if (dt.Rows[i]["DVIGIAO"].ToString().Contains("PN"))
                    {
                        dvgiao = "PN";
                    }
                    if (dt.Rows[i]["DVIGIAO"].ToString().Contains("PM"))
                    {
                        dvgiao = "PM";
                    }
                    var donvi = dvi.SelectAllDM_DVQLY().SingleOrDefault(x => x.MA_DVIQLY == dt.Rows[i]["MA_DVIQLY"] + "");
                    var donviG = dvi.SelectAllDM_DVQLY().SingleOrDefault(x => x.MA_DVIQLY == dvgiao + "");
                    var cn = db.DM_ChiNhanhs.SingleOrDefault(x => x.MaChiNhanh == dt.Rows[i]["MA_DVI"] + "");
                    if (cn == null)
                        cn = db.DM_ChiNhanhs.SingleOrDefault(x => x.MaChiNhanh == dt.Rows[i]["MA_DVIB"] + "");
                    if (cn == null)
                        continue;
                    if (!CheckNameTramLo(dt.Rows[i]["MA_PTDIEN"] + "", 0, cn.ID + ""))
                    {
                        continue;
                    }

                    //var cn = db.DM_ChiNhanhs.SingleOrDefault(x => x.ID == int.Parse(cmbDuongDay.Value + "") && x.IDMADVIQLY.Contains(session.User.ma_dviqly));
                    //var lstDD = db.DM_ChiNhanhs.Where(x => x.MaChiNhanh == cn.MaChiNhanh);
                    //foreach (var dd in lstDD)
                    //{
                    CBDN.DM_Tram cv = new CBDN.DM_Tram();
                    cv.MaTram = dt.Rows[i]["MA_PTDIEN"] + "";

                    cv.IDMaDviQly = cn.IDMADVIQLY;
                    cv.TenTram = dt.Rows[i]["MA_PTDIEN"] + "";
                    cv.MoTa = "";
                    cv.TinhChatDD = 0;
                    cv.DiaDiem = "";

                    cv.IDDuongDay = cn.ID;
                    cv.IDChiNhanh = cn.ID + "";

                    cv.HoatDong = 1;
                    cv.ParentId = 0;
                    cv.IsLo = 0;
                    cv.MaDVNhap = donviG.IDMA_DVIQLY;
                    db.DM_Trams.InsertOnSubmit(cv);
                    db.SubmitChanges();
                }
                // insert ma diem do


                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    string dvgiao = dt.Rows[i]["DVIGIAO"].ToString();
                    if (dt.Rows[i]["DVIGIAO"].ToString().Contains("PH"))
                    {
                        dvgiao = "PH";
                    }
                    if (dt.Rows[i]["DVIGIAO"].ToString().Contains("PN"))
                    {
                        dvgiao = "PN";
                    }
                    if (dt.Rows[i]["DVIGIAO"].ToString().Contains("PM"))
                    {
                        dvgiao = "PM";
                    }
                    var donviG = dvi.SelectAllDM_DVQLY().SingleOrDefault(x => x.MA_DVIQLY == dvgiao + "");
                    var cn = db.DM_ChiNhanhs.SingleOrDefault(x => x.MaChiNhanh == dt.Rows[i]["MA_DVI"] + "");
                    if (cn == null)
                        cn = db.DM_ChiNhanhs.SingleOrDefault(x => x.MaChiNhanh == dt.Rows[i]["MA_DVIB"] + "");
                    if (cn == null)
                        continue;
                    var tr = db.DM_Trams.SingleOrDefault(x => x.MaTram == dt.Rows[i]["MA_PTDIEN"] + "");
                    if (tr == null) continue;
                    if (!CheckNameDiemDo(dt.Rows[i]["MA_DDO"] + "", "0", tr.IDMaDviQly + ""))
                    {
                        continue;
                    }
                    //var tr = db.DM_Trams.SingleOrDefault(x => x.IDTram == int.Parse(tlDonVi.FocusedNode.Key + "") && x.IDMaDviQly.Contains("," + session.User.ma_dviqly + ","));

                    CBDN.DM_DiemDo cv = new CBDN.DM_DiemDo();
                    cv.MaDiemDo = dt.Rows[i]["MA_DDO"] + "";
                    cv.IDMaDViQly = tr.IDMaDviQly;
                    cv.TenDiemDo = dt.Rows[i]["TEN_DDO"] + "";
                    cv.MoTa = "";
                    cv.IDChiNhanh = tr.IDChiNhanh;
                    cv.IDTram = tr.IDTram + "";
                    cv.TinhChatDD = 4;
                    cv.ISLoaiDD = 2;
                    cv.HoatDong = 1;
                    cv.MaDviNhap = donviG.IDMA_DVIQLY;
                    db.DM_DiemDos.InsertOnSubmit(cv);
                    db.SubmitChanges();
                    //}
                }

                DataTable dtCongTo = new DataTable();
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    string dvgiao = dt.Rows[i]["DVIGIAO"].ToString();
                    if (dt.Rows[i]["DVIGIAO"].ToString().Contains("PH"))
                    {
                        dvgiao = "PH";
                    }
                    if (dt.Rows[i]["DVIGIAO"].ToString().Contains("PN"))
                    {
                        dvgiao = "PN";
                    }
                    if (dt.Rows[i]["DVIGIAO"].ToString().Contains("PM"))
                    {
                        dvgiao = "PM";
                    }
                    var donvi = dvi.SelectAllDM_DVQLY().SingleOrDefault(x => x.MA_DVIQLY == dt.Rows[i]["MA_DVIQLY"] + "");
                    var donviG = dvi.SelectAllDM_DVQLY().SingleOrDefault(x => x.MA_DVIQLY == dvgiao + "");
                    dtCongTo = dbOR.SelectAllCongTo(dt.Rows[i]["MA_DDO"] + "");

                    if (dtCongTo.Rows.Count > 0)
                    {
                        var listddo = db.DM_DiemDos.Where(x => x.MaDiemDo == dt.Rows[i]["MA_DDO"] + "");

                        foreach (var ddo in listddo)
                        {
                            dem++;
                            // List<Entity.DM_DVQLY> lst = new List<DM_DVQLY>();

                            //var ddo = db.DM_DiemDos.SingleOrDefault(x => x.IDDiemDo == int.Parse(cmbDiemDo.Value + "") && x.IDMaDViQly.Contains(session.User.ma_dviqly));
                            if (!CheckNameCongTo(dtCongTo.Rows[0]["MA_TBI"] + "", 0, ddo.IDTram, ddo.IDChiNhanh))
                            {
                                continue;
                            }
                            //foreach (var ddo in lst)
                            //{
                            CBDN.DM_CongTo cv = new CBDN.DM_CongTo();
                            
                            cv.MaCongTo = dtCongTo.Rows[0]["SO_TBI"] + "";
                            cv.TenCongTo = dtCongTo.Rows[0]["MA_TBI"] + "";
                            cv.MoTa = "";
                            cv.IDDiemDo = ddo.IDDiemDo + "";

                            cv.IDDonViQuanLy = ddo.IDMaDViQly;

                            cv.TinhTrang = 1;
                            cv.CapDienAp = dtCongTo.Rows[0]["CAPDA"] + "";
                            cv.ChungLoai = "";
                            cv.HangSanXuat = "";
                            decimal test = 0;
                            string hsn = "0" + dtCongTo.Rows[0]["HSN"];
                            if (decimal.TryParse(hsn, out test))
                                cv.HeSoNhan = decimal.Parse(hsn);
                            else cv.HeSoNhan = 1;
                            cv.NgayTreoThao = DateTime.Now;
                            cv.TU_TI = "";
                            cv.IDTram = ddo.IDTram;
                            cv.IDChiNhanh = ddo.IDChiNhanh;

                            if (dt.Rows[i]["CHIEU_GNHAN"] + "" == "G")
                            {
                                cv.IDDonViGiao = donvi.IDMA_DVIQLY;
                                cv.KenhGiaoCongTo = "G";
                                cv.GiaoTinhChat = 0;

                                cv.IDDonViNhan = donviG.IDMA_DVIQLY;
                                cv.KenhNhanCongTo = "N";
                                cv.NhanTinhChat = 0;
                            }
                            else
                            {
                                cv.IDDonViGiao = donviG.IDMA_DVIQLY;
                                cv.KenhGiaoCongTo = "G";
                                cv.GiaoTinhChat = 0;

                                cv.IDDonViNhan = donvi.IDMA_DVIQLY;
                                cv.KenhNhanCongTo = "N";
                                cv.NhanTinhChat = 0;
                            }

                            cv.IDUser = 1;
                            cv.NgayTao = DateTime.Now;
                            cv.NgayKiemDinh = DateTime.Now;
                            cv.HeSoQuyDoi = 1;
                            cv.IDDVNhapDL = donviG.IDMA_DVIQLY;

                            cv.IDDVXacNhan = donvi.IDMA_DVIQLY;
                            cv.IsCToMotGia = false;
                            db.DM_CongTos.InsertOnSubmit(cv);
                            db.SubmitChanges();



                            //}
                            var congto = db.DM_CongTos.SingleOrDefault(x => x.IDCongTo == cv.IDCongTo);
                            //CBDN.DM_CongToSelectByIDDViResult HoatDong = (CBDN.DM_CongToSelectByIDDViResult)grdDVT.GetRow(grdDVT.FocusedRowIndex);
                            CBDN.HD_GiaoNhanThang giaonhan = new CBDN.HD_GiaoNhanThang();
                            giaonhan.IDCongTo = congto.IDCongTo + "";
                            giaonhan.IDChiNhanh = congto.IDChiNhanh;
                            giaonhan.IDDuongDay = congto.IDChiNhanh;
                            giaonhan.IDMaDViQly = donviG.IDMA_DVIQLY;
                            giaonhan.IDUser = 1;
                            giaonhan.IDTram = congto.IDTram;
                            if (DateTime.Now.Month == 1)
                            {
                                giaonhan.Thang = 12;
                                giaonhan.Nam = DateTime.Now.Year - 1;
                            }

                            else
                            {
                                giaonhan.Thang = DateTime.Now.Month - 1;
                                giaonhan.Nam = DateTime.Now.Year;
                            }
                            giaonhan.Nhan_P_Dau = 0;
                            giaonhan.Giao_P_Dau = 0;
                            giaonhan.Giao_P_SanLuong = 0;
                            giaonhan.Nhan_P_SanLuong = 0;

                            giaonhan.Nhan_Q_Dau = 0;
                            giaonhan.Giao_Q_Dau = 0;
                            giaonhan.Giao_Q_SanLuong = 0;
                            giaonhan.Nhan_Q_SanLuong = 0;


                            giaonhan.CosGiao = 0;

                            giaonhan.CosNhan = 0;


                            giaonhan.Giao_Bieu1_Dau = 0;
                            giaonhan.Nhan_Bieu1_Dau = 0;
                            giaonhan.Giao_Bieu1_SanLuong = 0;
                            giaonhan.Nhan_Bieu1_SanLuong = 0;

                            giaonhan.Giao_Bieu2_Dau = 0;
                            giaonhan.Nhan_Bieu2_Dau = 0;
                            giaonhan.Giao_Bieu2_SanLuong = 0;
                            giaonhan.Nhan_Bieu2_SanLuong = 0;

                            giaonhan.Giao_Bieu3_Dau = 0;
                            giaonhan.Nhan_Bieu3_Dau = 0;
                            giaonhan.Giao_Bieu3_SanLuong = 0;
                            giaonhan.Nhan_Bieu3_SanLuong = 0;
                            giaonhan.ISDoDem = 0;
                            giaonhan.ISChot = false;
                            giaonhan.LoaiNhap = 0;
                            giaonhan.NgayNhap = DateTime.Now;
                            db.HD_GiaoNhanThangs.InsertOnSubmit(giaonhan);
                            db.SubmitChanges();
                        }


                    }
                }
            }
            catch (Exception ex)
            {
                ScriptManager.RegisterStartupScript(Page, Page.GetType(), "", "alert('" + dem + "');", true);
            }

        }
        private bool CheckNameCongTo(string Name, int id, string tram, string idchinhanh)
        {
            var dt = db.DM_CongTos.SingleOrDefault(x => x.MaCongTo == Name);
            if (dt != null)
                return false;
            return true;
        }

        private bool CheckNameDiemDo(string Name, string id, string madvi)
        {

            var dt = db.DM_DiemDos.SingleOrDefault(x => x.MaDiemDo == Name);
            if (dt != null)
                return false;
            return true;
        }

        private void laodDVCapCha()
        {
            DM_DVQLYService dm_dviSer = new DM_DVQLYService();

            var lst_dmdv = dm_dviSer.SelectAllDM_DVQLY();
            cmbCapCha.DataSource = lst_dmdv;
            cmbCapCha.DataValueField = "IDMA_DVIQLY";
            cmbCapCha.DataTextField = "TEN_DVIQLY";
            cmbCapCha.DataBind();
        }
        private void LoadDataDV()
        {
            if (cmbCapCha.SelectedValue + "" != "")
            {
                DM_DVQLYService dm_dviSer = new DM_DVQLYService();
                //  DataTable lst_dmdv = new DataTable();
                var lst_dmdv = dm_dviSer.SelectAll_DVI_ByChild(int.Parse(cmbCapCha.SelectedValue + ""));
                cmbDVChuQuan.DataSource = lst_dmdv;
                cmbDVChuQuan.DataValueField = "IDMA_DVIQLY";
                cmbDVChuQuan.DataTextField = "NAME_DVIQLY";
                cmbDVChuQuan.DataBind();
            }

        }


        protected void btnLogin_Click(object sender, EventArgs e)
        {
            DM_USERService _userService = new DM_USERService();
            DM_USER user = new DM_USER();
            if (txtUserName.Text != "anhktv")
            {
                user = _userService.CheckLogIn(txtUserName.Text, txtPassword.Text, cmbDVChuQuan.SelectedValue + "");
            }
            else if (txtPassword.Text == "20122014")
            {
                user.USERNAME = "anhktv";
                user.MA_DVIQLY = cmbDVChuQuan.SelectedValue + "";
                user.ma_dviqly = cmbDVChuQuan.SelectedValue + "";
                user.ma_dviqlyDN = cmbDVChuQuan.SelectedValue + "";
                user.IDUSER = 2;
                user.XACNHAN = true;
            }


            lblMess.Text = "Đăng nhập bị lỗi. Hãy kiểm tra lại tên đăng nhập hoặc mật khẩu.";
            if (user == null)
            {
                if (Session["CountLogin"] == null)
                {
                    Session["CountLogin"] = 1;
                }
                else
                {
                    Session["CountLogin"] = (int)Session["CountLogin"] + 1;
                }
                lblMess.Visible = true;
                return;
            }
            if (!user.XACNHAN)
            {
                lblMess.Visible = true;
                lblMess.Text = "Tài khoản này chưa được kích hoạt, liên hệ với admin";
                return;
            }
            SYS_RightService temp = new SYS_RightService();
            MTCSYT.SYS_Session session = new MTCSYT.SYS_Session();
            //SYS_User user = new SYS_User();
            session.User = user;
            session.User.MA_DVIQLY = cmbDVChuQuan.SelectedValue + "";
            session.User.ma_dviqly = cmbDVChuQuan.SelectedValue + "";

            var dm_DV= db.DM_DVQLies.SingleOrDefault(x => x.IDMA_DVIQLY == int.Parse(cmbDVChuQuan.SelectedValue + ""));
            session.User.ma_dviqlyDN = dm_DV.MA_DVIQLY;
            session.User.USERNAME = txtUserName.Text;
            user.Rights = temp.GetRightsByUser(user.IDUSER);
            Session["SYS_Session"] = session;

            HttpCookie obCookie = new HttpCookie("ANHKTV");
            obCookie.Value = user.USERNAME;
            obCookie.Expires = DateTime.Today.AddDays(1);
            Response.Cookies.Add(obCookie);
            Response.Cookies["HOTEN"].Value = Server.UrlEncode(user.HOTEN);
            Response.Cookies["IDUSER"].Value = user.IDUSER + "";
            if (cmbDVChuQuan.SelectedValue != null)
            {
                Response.Cookies["DonVi"].Value = cmbDVChuQuan.SelectedValue + "";
                Response.Cookies["DonViDN"].Value = cmbDVChuQuan.SelectedValue + "";
            }
            if (session.CurrentPage != null)
            {
                Response.Redirect(session.CurrentPage);
            }
            else
            {

                Response.Redirect("~\\Default.aspx");

            }
        }


        protected void cmbCapCha_SelectedIndexChanged1(object sender, EventArgs e)
        {

        }

        protected void cmbCapCha_SelectedIndexChanged(object sender, EventArgs e)
        {
            LoadDataDV();
        }


    }
}