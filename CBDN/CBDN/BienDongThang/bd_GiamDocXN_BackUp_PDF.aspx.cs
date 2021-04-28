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
    public partial class bd_GiamDocXN_BackUp_PDF : BasePage
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

            InTongHopDienNang();
        }
        private void InTongHopDienNang()
        {
            MTCSYT.SYS_Session session = (MTCSYT.SYS_Session)Session["SYS_Session"];
            if (cmbPhuongThuc.Value == null || cmbPhuongThuc.Value + "" == "0")
                return;

            //  var chinhanh = db.DM_ChiNhanhs.SingleOrDefault(x => x.ID == int.Parse(cmbPhuongThuc.Value + ""));
            var isKy = db.HD_ThongTinKies.SingleOrDefault(x => x.IDChinhNhanh == int.Parse(cmbPhuongThuc.Value + "") && x.Nam == int.Parse(cmbNam.Value + "") && x.Thang == int.Parse(cmbThang.Value + "") && x.Link.Contains(cmbPhuongThuc.Value + "_" + cmbThang.Value + "_" + cmbNam.Value + "_QT.pdf"));
            if (isKy != null)
            {
                var ngtao = db.DM_USERs.SingleOrDefault(x => x.IDUSER == isKy.NguoiTao);
                lbThoiGianXacNhan.Text = "Nhân viên xác nhận: " + isKy.NgayTao;
                lbNguoiXacNhan.Text = ngtao.HOTEN;
                //lbThoiGianXacNhan.Text = ngtao.HOTEN;

                string[] arrTPKy = isKy.Barcode.Split(';');
                for (int i = 0; i < arrTPKy.Count(); i++)
                {
                    string tpKy = arrTPKy[i];
                    if (tpKy.Contains("TP"))
                    {
                        string[] TP = tpKy.Split('_');

                        if (TP[1] == session.User.ma_dviqly)
                        {
                            lbTPKy.Text = "Trường phòng xác nhận: " +TP[3];
                            lbNguoiKy.Text =  TP[2];
                        }
                    }
                }

                IframeQT.Attributes["src"] = isKy.Link;
            }
            var isKyQT = db.HD_ThongTinKies.SingleOrDefault(x => x.IDChinhNhanh == int.Parse(cmbPhuongThuc.Value + "") && x.Nam == int.Parse(cmbNam.Value + "") && x.Thang == int.Parse(cmbThang.Value + "") && x.Link.Contains(cmbPhuongThuc.Value + "_" + cmbThang.Value + "_" + cmbNam.Value + "_TH.pdf"));
            if (isKyQT != null)
                mainiFrame.Attributes["src"] = isKyQT.Link;
        }
        private void loadGiaoNhan()
        {

            MTCSYT.SYS_Session session = (MTCSYT.SYS_Session)Session["SYS_Session"];
            var lstDD = db.db_SelectPhuongThucCanXN(int.Parse(session.User.ma_dviqly + ""), int.Parse(cmbThang.Value + ""), int.Parse(cmbNam.Value + ""), "GDXacNhan").ToList();
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
        private void kySo(string TenFile)
        {

            MTCSYT.SYS_Session session = (MTCSYT.SYS_Session)Session["SYS_Session"];
            var userky = db.DM_USERs.SingleOrDefault(x => x.IDUSER == session.User.IDUSER);
            if (userky.NguoiKy != txtTenNguoiKy.Text)
            {
                userky.HOTEN = txtHoTenNguoiKy.Text;
                userky.NguoiKy = txtTenNguoiKy.Text;
                db.SubmitChanges();
            }
            // thong tin thoi gian ký
            var isKy = db.HD_ThongTinKies.SingleOrDefault(x => x.IDChinhNhanh == int.Parse(cmbPhuongThuc.Value + "") && x.Nam == int.Parse(cmbNam.Value + "") && x.Thang == int.Parse(cmbThang.Value + "") && x.Link.Contains(cmbPhuongThuc.Value + "_" + cmbThang.Value + "_" + cmbNam.Value + "_QT.pdf"));
            if (isKy != null)
            {
                isKy.Barcode = isKy.Barcode + "GD_" + session.User.ma_dviqly + "_" + txtHoTenNguoiKy.Text + "_" + DateTime.Now + ";";
            }

            string strSerial = "";
            string strAlias = txtTenNguoiKy.Text;
            string strUrl = "http://10.0.0.146:8080/SignServerWSService?wsdl";
            string strFileName = TenFile;
            string strSaveTo = TenFile;
            string strAppCode = "cmis";
            string strPassword = "Cmis@2019";
            string strHashAlogrithm = "SHA-1";
            //string strInt = txtInt.Text;
            CBDN.ServerSignWS.signFileResponceBO signBO = null;
            try
            {
                var cn = db.DM_ChiNhanhs.SingleOrDefault(x => x.ID == int.Parse(cmbPhuongThuc.Value + ""));

                float Trai = 0, Phai = 0, Tren = 0, Duoi = 0;


                if (cn.IDMADVIQLY.Contains(",2,"))
                {
                    if (session.User.MA_DVIQLY != cn.DiemDauNguon + "")
                    {
                        //giao trái (ngược lại với tổng công ty)
                        Tren = 70;
                        Duoi = 300;
                        Phai = 410;
                        Trai = 80;
                    }
                    else
                    {
                        //nhan phải
                        Tren = 70;
                        Duoi = 300;
                        Phai = 140;
                        Trai = 360;
                    }
                }
                else
                {
                    if (session.User.MA_DVIQLY != cn.DiemDauNguon + "")
                    {
                        //nhan phải
                        Tren = 70;
                        Duoi = 300;
                        Phai = 140;
                        Trai = 360;

                    }
                    else
                    {
                        //giao trái (ngược lại với tổng công ty)
                        Tren = 70;
                        Duoi = 300;
                        Phai = 410;
                        Trai = 80;
                    }

                }
                byte[] AsBytes = File.ReadAllBytes(strFileName);
                string AsBase64String = Convert.ToBase64String(AsBytes);

                //byte[] tempBytes = Convert.FromBase64String(AsBase64String);
                CBDN.ServerSignWS.SignServerWSService ser = new CBDN.ServerSignWS.SignServerWSService();
                //ser.Url = strUrl;
                #region Display
                CBDN.ServerSignWS.displayRectangleTextConfigBO dspRec = new CBDN.ServerSignWS.displayRectangleTextConfigBO();
                dspRec.numberPageSign = DisplayConfigConsts.NUMBER_PAGE_SIGN_DEFAULT;
                dspRec.widthRectangle = DisplayConfigConsts.WIDTH_RECTANGLE_DEFAULT;
                dspRec.heightRectangle = DisplayConfigConsts.HEIGHT_RECTANGLE_DEFAULT;
                dspRec.locateSign = DisplayConfigConsts.LOCATE_SIGN_DEFAULT;

                dspRec.marginTopOfRectangle = Tren;
                dspRec.marginBottomOfRectangle = Duoi;
                dspRec.marginRightOfRectangle = Phai;
                dspRec.marginLeftOfRectangle = Trai;


                dspRec.displayText = DisplayConfigConsts.DISPLAY_TEXT_DEFAULT_EMPTY;
                dspRec.formatRectangleText = DisplayConfigConsts.FORMAT_RECTANGLE_TEXT_DEFAULT;
                dspRec.contact = DisplayConfigConsts.CONTACT_DEFAULT_EMPTY;
                dspRec.reason = DisplayConfigConsts.REASON_DEFAULT_EMPTY;
                dspRec.location = DisplayConfigConsts.LOCATION_DEFAULT_EMPTY;
                dspRec.dateFormatString = DisplayConfigConsts.DATE_FORMAT_STRING_DEFAULT;
                dspRec.fontPath = DisplayConfigConsts.FONT_PATH_DEFAULT;
                dspRec.sizeFont = DisplayConfigConsts.SIZE_FONT_DEFAULT;
                dspRec.organizationUnit = DisplayConfigConsts.ORGANIZATION_UNIT_DEFAULT_EMPTY;
                dspRec.organization = DisplayConfigConsts.ORGANIZATION_DEFAULT_EMPTY;
                dspRec.signDate = DateTime.Now;
                #endregion

                CBDN.ServerSignWS.timestampConfig timestamp = new CBDN.ServerSignWS.timestampConfig();
                timestamp.useTimestamp = false;

                signBO = ser.signPdfBase64RectangleText(strAppCode, strPassword, strSerial, strAlias, AsBase64String, strHashAlogrithm, dspRec, timestamp);
                string strOutput = signBO.signedFileBase64;
                byte[] tempBytes = Convert.FromBase64String(strOutput);
                try
                {
                    File.WriteAllBytes(strSaveTo, tempBytes);
                    ScriptManager.RegisterStartupScript(Page, Page.GetType(), "", "alert('Ký số thành công');", true);
                }
                catch (Exception ex)
                {
                    ScriptManager.RegisterStartupScript(Page, Page.GetType(), "", "alert('Lỗi duyệt chấm nợ " + ex.Message + "');", true);
                }


            }
            catch (Exception ex)
            {
                ScriptManager.RegisterStartupScript(Page, Page.GetType(), "", "alert('Lỗi duyệt chấm nợ " + ex.Message + "');", true);
            }

        }
        protected void btnDuyet_Click(object sender, EventArgs e)
        {
            MTCSYT.SYS_Session session = (MTCSYT.SYS_Session)Session["SYS_Session"];
            var userky = db.DM_USERs.SingleOrDefault(x => x.IDUSER == session.User.IDUSER);
            txtHoTenNguoiKy.Text = userky.HOTEN;
            txtTenNguoiKy.Text = userky.NguoiKy;
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

        }

        protected void cmbThang_SelectedIndexChanged(object sender, EventArgs e)
        {
            InTongHopDienNang();
        }

        protected void cmbPhuongThuc_SelectedIndexChanged(object sender, EventArgs e)
        {
            InTongHopDienNang();
        }

        protected void btnDongFileKy_Click(object sender, EventArgs e)
        {
            pcFileKy.ShowOnPageLoad = false;
        }

        protected void btnLuuFile_Click(object sender, EventArgs e)
        {
            string strTenFile = cmbPhuongThuc.Value + "_" + cmbThang.Value + "_" + cmbNam.Value;
            kySo(Server.MapPath("~/") + "FileKy\\" + strTenFile + "_TH.pdf");

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
            }
        }

    }
}