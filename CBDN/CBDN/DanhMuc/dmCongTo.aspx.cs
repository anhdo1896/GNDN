using System;
using System.Collections.Generic;
using DevExpress.Web;
using Entity;
using SystemManageService;
using System.Web.UI;
using System.Linq;
using System.Data;
namespace MTCSYT
{
    public partial class dmCongTo : BasePage
    {
        DM_DVQLYService dm_dviSer = new DM_DVQLYService();
        CBDN.DB_CBDNDataContext db = new CBDN.DB_CBDNDataContext(new CBDN.ADOController().strcn());
        private SYS_Right rightOfUser = null;
        private const string funcid = "57";
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
            _DataBind();
            if (!IsPostBack)
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
                loadDanhMuc();
                rpKenhGiao.Visible = false;
                rpNhan.Visible = false;
                rpThongTin.Visible = false;
                ThoiGianChon.Visible = false;
            }

        }
        private void setControlText(int idCongTo)
        {
            var congto = db.DM_CongTos.SingleOrDefault(x => x.IDCongTo == idCongTo);
            if (congto != null)
            {
                lbMaCT.Text = congto.MaCongTo;
                lbTenCongTo.Text = congto.TenCongTo;
                lbChungLoai.Text = congto.ChungLoai;
                lbCDA.Text = congto.CapDienAp + "";
                lbIDCongTO.Text = idCongTo + "";
                lbDiemDo.Text = db.DM_DiemDos.SingleOrDefault(x => x.IDDiemDo == int.Parse(congto.IDDiemDo)).TenDiemDo;
                lbDVGiao.Text = dm_dviSer.SelectDM_DVQLY((int)congto.IDDonViGiao).NAME_DVIQLY;
                lbDVNhan.Text = dm_dviSer.SelectDM_DVQLY((int)congto.IDDonViNhan).NAME_DVIQLY;
                lbHangSX.Text = congto.HangSanXuat;
                lbHSNhan.Text = congto.HeSoNhan + "";
                lbHSQuyDoi.Text = congto.HeSoQuyDoi + "";
                lbKenhNhan.Text = congto.KenhGiaoCongTo;
                lbKenhNhan.Text = congto.KenhNhanCongTo;
                lbMoTa.Text = congto.MoTa;

                lbNgayHieuLuc.Text = congto.NgayTreoThao + "";
                lbNgaySua.Text = congto.NgayTao + "";
                lbngayTao.Text = congto.NgayTao + "";
                lbPhuongthuc.Text = db.DM_ChiNhanhs.SingleOrDefault(x => x.ID == int.Parse(congto.IDChiNhanh)).TenChiNhanh;
                ckNhanTonThat.Checked = (bool)congto.ISTonThatNhan;
                ckGiaoTonThat.Checked = (bool)congto.IsTonThat;

            }
        }
        private void loadDanhMuc()
        {
            DM_DVQLYService dm_dviSer = new DM_DVQLYService();

            MTCSYT.SYS_Session session = (MTCSYT.SYS_Session)Session["SYS_Session"];


            var lstDD = db.DM_DiemDos.Where(x => x.IDMaDViQly.Contains("," + session.User.ma_dviqly + ",")).ToList();
            cmbDiemDo.DataSource = lstDD;
            cmbDiemDo.ValueField = "IDDiemDo";
            cmbDiemDo.TextField = "MaDiemDo";
            cmbDiemDo.DataBind();

            //  var lstLo = db.DM_Los.Where(x => x.IDMaDViQly == ma_dviqly).ToList();


            //var lstDMTinhChat = db.DM_TinhChatKenhs.ToList();
            //cmbTinhChatGiao.DataSource = lstDMTinhChat;
            //cmbTinhChatGiao.ValueField = "ID";
            //cmbTinhChatGiao.TextField = "TinhChat";
            //cmbTinhChatGiao.DataBind();

            //cmbTinhChatNhan.DataSource = lstDMTinhChat;
            //cmbTinhChatNhan.ValueField = "ID";
            //cmbTinhChatNhan.TextField = "TinhChat";
            //cmbTinhChatNhan.DataBind();


        }
        private void _DataBind()
        {
            MTCSYT.SYS_Session session = (MTCSYT.SYS_Session)Session["SYS_Session"];

            grdDVT.DataSource = db.DM_CongToSelectByIDDVi(session.User.ma_dviqly + "", "0").ToList();
            grdDVT.DataBind();
        }

        protected void grdDVT_CustomColumnDisplayText(object sender, ASPxGridViewColumnDisplayTextEventArgs e)
        {
            if (e.Column.Caption == "STT")
            {
                e.DisplayText = (e.VisibleRowIndex + 1).ToString();
            }
        }

        protected void grdDVT_RowDeleting(object sender, DevExpress.Web.Data.ASPxDataDeletingEventArgs e)
        {
            try
            {
                SYS_Session session = (SYS_Session)Session["SYS_Session"];
                CBDN.DM_CongToSelectByIDDViResult HoatDong = (CBDN.DM_CongToSelectByIDDViResult)grdDVT.GetRow(grdDVT.FocusedRowIndex);
                if (HoatDong.IDDVNhapDL != int.Parse(session.User.ma_dviqly))
                {
                    ScriptManager.RegisterStartupScript(Page, Page.GetType(), "", "alert('Không thể xóa giao nhận này vì không phải đơn vị bạn tạo ra');", true);
                    return;
                }
                CBDN.DM_CongTo cv = new CBDN.DM_CongTo();
                cv = db.DM_CongTos.SingleOrDefault(x => x.IDCongTo == HoatDong.IDCongTo && x.IDDonViQuanLy.Contains(session.User.ma_dviqly) && x.IDChiNhanh == HoatDong.IDChiNhanh && x.IDTram == HoatDong.IDTram && x.IDDiemDo == HoatDong.IDDiemDo);
                db.DM_CongTos.DeleteOnSubmit(cv);
                db.SubmitChanges();
                _DataBind();
                ScriptManager.RegisterStartupScript(Page, Page.GetType(), "", "alert('Xoá công tơ thành công');", true);
            }
            catch (Exception ex)
            { }
            finally
            {
                e.Cancel = true;
            }
        }


        private bool CheckName(string Name, int id, string tram, string idchinhanh)
        {
            SYS_Session session = (SYS_Session)Session["SYS_Session"];

            var dt = db.DM_CongTos.SingleOrDefault(x => x.MaCongTo == Name && x.IDCongTo != id && x.IDTram == tram && x.IDChiNhanh == idchinhanh);
            if (dt != null)
                return false;
            return true;
        }

        protected void grdDVT_CellEditorInitialize(object sender, ASPxGridViewEditorEventArgs e)
        {
            e.Column.ToString();
            if (e.Column.FieldName == "IDCongTo")
                e.Editor.Focus();
        }

        protected void btnThem_Click(object sender, EventArgs e)
        {
            pcAddRoles.ShowOnPageLoad = true;
            Session["Add"] = 1;
        }

        protected void grdDVT_StartRowEditing(object sender, DevExpress.Web.Data.ASPxStartRowEditingEventArgs e)
        {
            (sender as ASPxGridView).GetRowValuesByKeyValue(e.EditingKeyValue);

        }

        protected void grdDVT_CellEditorInitialize1(object sender, ASPxGridViewEditorEventArgs e)
        {

        }

        protected void btnSua_Click(object sender, EventArgs e)
        {
            pcAddRoles.ShowOnPageLoad = true;
            Session["Add"] = 0;
            SYS_Session session = (SYS_Session)Session["SYS_Session"];
            CBDN.DM_CongToSelectByIDDViResult cv = (CBDN.DM_CongToSelectByIDDViResult)grdDVT.GetRow(grdDVT.FocusedRowIndex);
            txtMaDuongDat.Text = cv.MaCongTo;
            txtTenDuongDay.Text = cv.TenCongTo;
            loadDanhMuc();           
            cmbDiemDo.Text = cv.MaDiemDo;
            cmbDiemDo.Value = cv.IDDiemDo;

            if (cv.TinhTrang == 1)
                CkHoatDong.Checked = true;
            else
                CkHoatDong.Checked = false;
            mmMoTa.Text = cv.MoTa;

            cmbCapDienAp.Value = cv.CapDienAp + "";
            txtChungLoai.Text = cv.ChungLoai;
            txtHangSanXuat.Text = cv.HangSanXuat;
            txtHeSoNhan.Text = cv.HeSoNhan + "";
            if (cv.ISTonThatNhan != null)
                ckNhanTonThat.Checked = (bool)cv.ISTonThatNhan;
            else
                ckNhanTonThat.Checked = false;
            if (cv.IsTonThat != null)
                ckGiaoTonThat.Checked = (bool)cv.IsTonThat;
            else
                ckGiaoTonThat.Checked = false;
            txtTuTi.Text = cv.TU_TI;
            dtNgayTreo.Text = cv.NgayTreoThao + "";
            ckCongTo1Gia.Checked =(bool) cv.IsCToMotGia;
            //cmbDvGiao.Value = cv.IDDonViGiao;
            //cmbDvGiao.Text = db.DM_DVQLies.SingleOrDefault(x => x.IDMA_DVIQLY == cv.IDDonViGiao).TEN_DVIQLY;
            //cmbNhan.Value = cv.IDDonViNhan;
            //cmbNhan.Text = db.DM_DVQLies.SingleOrDefault(x => x.IDMA_DVIQLY == cv.IDDonViNhan).TEN_DVIQLY;

            CBDN.DM_DVQLY giao = db.DM_DVQLies.SingleOrDefault(x => x.IDMA_DVIQLY == cv.IDDonViGiao);
            CBDN.DM_DVQLY nhan = db.DM_DVQLies.SingleOrDefault(x => x.IDMA_DVIQLY == cv.IDDonViNhan);
            List<CBDN.DM_DVQLY> lst = new List<CBDN.DM_DVQLY>();
            lst.Add(giao);
            lst.Add(nhan);

            cmbDvGiao.DataSource = lst;
            cmbDvGiao.ValueField = "IDMA_DVIQLY";
            cmbDvGiao.TextField = "TEN_DVIQLY";
            cmbDvGiao.DataBind();
          
             cmbDvGiao.Value = cv.IDDonViGiao; cmbDvGiao.Text = giao.TEN_DVIQLY;

            cmbNhan.DataSource = lst;
            cmbNhan.ValueField = "IDMA_DVIQLY";
            cmbNhan.TextField = "TEN_DVIQLY";
            cmbNhan.DataBind();
           
            cmbNhan.Value = cv.IDDonViNhan;cmbNhan.Text = nhan.TEN_DVIQLY; 

            txtHsNhanQD.Text = cv.HeSoQuyDoi + "";
        }

        protected void btnCapNhat_Click(object sender, EventArgs e)
        {
            SYS_Session session = (SYS_Session)Session["SYS_Session"];
            string idChiNhanh = ""; string idtram = "";
            var ddo = db.DM_DiemDos.SingleOrDefault(x => x.IDDiemDo == int.Parse(cmbDiemDo.Value + "") && x.IDMaDViQly.Contains(session.User.ma_dviqly));

            if (cmbDiemDo.Value + "" != "")
            {
                var diemdo = db.DM_DiemDos.SingleOrDefault(x => x.IDDiemDo == int.Parse("0" + cmbDiemDo.Value));

                idChiNhanh = diemdo.IDChiNhanh;
                idtram = diemdo.IDTram;
            }

            if (cmbCapDienAp.Value + "" == "")
            {
                ScriptManager.RegisterStartupScript(Page, Page.GetType(), "", "alert('Bạn phải chọn cấp điện áp');", true);

            }
            decimal hsn = 0, hsQD = 0;
            decimal testDec = 0;
            if (txtHeSoNhan.Text != "")
            {
                if (!decimal.TryParse(txtHeSoNhan.Text, out testDec))
                {
                    ScriptManager.RegisterStartupScript(Page, Page.GetType(), "", "alert('Hệ số nhân là kiểu số');", true);
                    txtHeSoNhan.Focus();
                    return;
                }
                hsn = decimal.Parse(txtHeSoNhan.Text);
            }
            if (txtHsNhanQD.Text != "")
            {
                if (!decimal.TryParse(txtHsNhanQD.Text, out testDec))
                {
                    ScriptManager.RegisterStartupScript(Page, Page.GetType(), "", "alert('Hệ số nhân quy đổi là kiểu số');", true);
                    txtHsNhanQD.Focus();
                    return;
                }
                hsQD = decimal.Parse(txtHsNhanQD.Text);
            }

            if (Session["Add"] + "" == "0")
            {
                CBDN.DM_CongToSelectByIDDViResult cv = (CBDN.DM_CongToSelectByIDDViResult)grdDVT.GetRow(grdDVT.FocusedRowIndex);
                var lstqtCT = db.DM_CongTos.Where(x => x.MaCongTo == cv.MaCongTo && x.IDDVNhapDL == int.Parse(session.User.ma_dviqly) && x.IDTram == cv.IDTram && x.IDChiNhanh == cv.IDChiNhanh && x.IDDiemDo == cv.IDDiemDo);
                foreach (var qtCT in lstqtCT)
                {
                    if (!CheckName(txtMaDuongDat.Text, cv.IDCongTo, cv.IDTram, cv.IDChiNhanh))
                    {
                        ScriptManager.RegisterStartupScript(Page, Page.GetType(), "", "alert('Mã đường dây không được trùng');", true); return;
                    }


                    //CBDN.DM_CongTo qtCT = new CBDN.DM_CongTo();
                    qtCT.TenCongTo = txtTenDuongDay.Text;
                    qtCT.MoTa = mmMoTa.Text;
                    qtCT.IDDiemDo = cmbDiemDo.Value + "";


                    qtCT.IDChiNhanh = idChiNhanh;
                    if (CkHoatDong.Checked)
                        qtCT.TinhTrang = 1;
                    else
                        qtCT.TinhTrang = 0;


                    qtCT.CapDienAp = cmbCapDienAp.Value + "";
                    qtCT.ChungLoai = txtChungLoai.Text;
                    qtCT.HangSanXuat = txtHangSanXuat.Text;
                    qtCT.HeSoNhan = hsn;
                    qtCT.TU_TI = txtTuTi.Text;

                    if (cmbNhan.Value != null)
                    {
                        qtCT.IDDonViNhan = int.Parse(cmbNhan.Value + "");
                        if (ddo.IDMaDViQly.Contains(cmbNhan.Value + "")) { qtCT.ISTonThatNhan = ckNhanTonThat.Checked; }
                        qtCT.KenhNhanCongTo = "N";
                        qtCT.NhanTinhChat = 0;
                    }

                    qtCT.IDTram = idtram;
                    if (cmbDvGiao.Value != null)
                    {
                        if (ddo.IDMaDViQly.Contains(cmbDvGiao.Value + "")) { qtCT.IsTonThat = ckGiaoTonThat.Checked; }
                        qtCT.IDDonViGiao = int.Parse(cmbDvGiao.Value + "");
                        qtCT.KenhGiaoCongTo = "G";
                        qtCT.GiaoTinhChat = 0;
                    }
                    qtCT.IsCToMotGia = ckCongTo1Gia.Checked;
                    qtCT.HeSoQuyDoi = hsQD;
                    db.SubmitChanges();
                }


            }
            else
            {
                // var lstDD = db.DM_DiemDos.SingleOrDefault(x => x.IDDiemDo == int.Parse(cmbDiemDo.Value + ""));

                List<Entity.DM_DVQLY> lst = new List<DM_DVQLY>();
                var chinhanh = db.DM_ChiNhanhs.SingleOrDefault(x => x.ID == int.Parse(ddo.IDChiNhanh));
                if (chinhanh.DiemCuoiNguon != chinhanh.DiemDauNguon && cmbDvGiao.Value + "" == cmbNhan.Value + "")
                {
                    ScriptManager.RegisterStartupScript(Page, Page.GetType(), "", "alert('Đơn vị nhận và đơn vị giao không thể trùng nhau do phương thức của điểm đo thuộc giao nhận giữa 2 công ty');", true); return;

                }

                if (!CheckName(txtMaDuongDat.Text, 0, ddo.IDTram, ddo.IDChiNhanh))
                {
                    ScriptManager.RegisterStartupScript(Page, Page.GetType(), "", "alert('Mã đường dây không được trùng');", true); return;
                }

                CBDN.DM_CongTo cv = new CBDN.DM_CongTo();
                cv.MaCongTo = txtMaDuongDat.Text;
                cv.TenCongTo = txtTenDuongDay.Text;
                cv.MoTa = mmMoTa.Text;
                cv.IDDiemDo = ddo.IDDiemDo + "";

                cv.IDDonViQuanLy = ddo.IDMaDViQly;
                if (CkHoatDong.Checked)
                    cv.TinhTrang = 1;
                else
                    cv.TinhTrang = 0;

                cv.CapDienAp = cmbCapDienAp.Value + "";
                cv.ChungLoai = txtChungLoai.Text;
                cv.HangSanXuat = txtHangSanXuat.Text;
                cv.HeSoNhan = hsn;
                cv.NgayTreoThao = DateTime.Now;
                cv.TU_TI = txtTuTi.Text;
                cv.IDTram = ddo.IDTram;
                cv.IDChiNhanh = ddo.IDChiNhanh;

                if (cmbNhan.Value != null)
                {
                    if (ddo.IDMaDViQly.Contains(cmbNhan.Value + "")) { cv.ISTonThatNhan = ckNhanTonThat.Checked; }
                    cv.IDDonViNhan = int.Parse(cmbNhan.Value + "");
                    cv.KenhNhanCongTo = "N";

                }

                if (cmbDvGiao.Value != null)
                {
                    if (ddo.IDMaDViQly.Contains(cmbDvGiao.Value + "")) { cv.IsTonThat = ckGiaoTonThat.Checked; }
                    cv.IDDonViGiao = int.Parse(cmbDvGiao.Value + "");
                    cv.KenhGiaoCongTo = "G";
                }
                cv.IDUser = session.User.IDUSER;
                cv.NgayTao = DateTime.Now;
                cv.NgayKiemDinh = dtNgayTreo.Date;
                cv.HeSoQuyDoi = hsQD;
                cv.IDDVNhapDL = int.Parse(session.User.ma_dviqly);
                if (session.User.ma_dviqly != cmbDvGiao.Value + "")
                    cv.IDDVXacNhan = int.Parse(cmbDvGiao.Value + "");
                else
                    cv.IDDVXacNhan = int.Parse(cmbNhan.Value + "");
                cv.IsCToMotGia = ckCongTo1Gia.Checked;
                db.DM_CongTos.InsertOnSubmit(cv);
                db.SubmitChanges();


                pcAddRoles.ShowOnPageLoad = false;
                txtGPDau.Focus();
                setControlText(cv.IDCongTo);
                visibleNhanChiSo();

                var congto = db.DM_CongTos.SingleOrDefault(x => x.IDCongTo == int.Parse(lbIDCongTO.Text));
                //CBDN.DM_CongToSelectByIDDViResult HoatDong = (CBDN.DM_CongToSelectByIDDViResult)grdDVT.GetRow(grdDVT.FocusedRowIndex);
                CBDN.HD_GiaoNhanThang giaonhan = new CBDN.HD_GiaoNhanThang();
                giaonhan.IDCongTo = congto.IDCongTo + "";
                giaonhan.IDChiNhanh = congto.IDChiNhanh;
                giaonhan.IDDuongDay = congto.IDChiNhanh;
                giaonhan.IDMaDViQly = int.Parse(session.User.ma_dviqly);
                giaonhan.IDUser = session.User.IDUSER;
                giaonhan.IDTram = congto.IDTram;
                giaonhan.Nam = int.Parse("0" + cmbNam.Value);
                giaonhan.Thang = int.Parse("0" + cmbThang.Value);

                giaonhan.Nhan_P_Dau = decimal.Parse(txtNPD.Text);
                giaonhan.Giao_P_Dau = decimal.Parse(txtGPDau.Text);
                giaonhan.Giao_P_SanLuong = 0;
                giaonhan.Nhan_P_SanLuong = 0;

                giaonhan.Nhan_Q_Dau = decimal.Parse(txtNQD.Text);
                giaonhan.Giao_Q_Dau = decimal.Parse(txtGQDau.Text);
                giaonhan.Giao_Q_SanLuong = 0;
                giaonhan.Nhan_Q_SanLuong = 0;


                giaonhan.CosGiao = 0;

                giaonhan.CosNhan = 0;


                giaonhan.Giao_Bieu1_Dau = decimal.Parse(txtB1D.Text);
                giaonhan.Nhan_Bieu1_Dau = decimal.Parse(txtNB1D.Text);
                giaonhan.Giao_Bieu1_SanLuong = 0;
                giaonhan.Nhan_Bieu1_SanLuong = 0;

                giaonhan.Giao_Bieu2_Dau = decimal.Parse(txtGB2D.Text);
                giaonhan.Nhan_Bieu2_Dau = decimal.Parse(txtNB2D.Text);
                giaonhan.Giao_Bieu2_SanLuong = 0;
                giaonhan.Nhan_Bieu2_SanLuong = 0;

                giaonhan.Giao_Bieu3_Dau = decimal.Parse(txtB3D.Text);
                giaonhan.Nhan_Bieu3_Dau = decimal.Parse(txtNB3D.Text);
                giaonhan.Giao_Bieu3_SanLuong = 0;
                giaonhan.Nhan_Bieu3_SanLuong = 0;
                giaonhan.ISDoDem = 0;
                giaonhan.ISChot = false;
                giaonhan.LoaiNhap = 0;
                giaonhan.NgayNhap = DateTime.Now;
                db.HD_GiaoNhanThangs.InsertOnSubmit(giaonhan);

            }


            db.SubmitChanges();
            pcAddRoles.ShowOnPageLoad = false;
            _DataBind();
        }
        private void visibleNhanChiSo()
        {
            rpThongTin.Visible = true;
            ThoiGianChon.Visible = true;
            rpKenhGiao.Visible = true;
            rpNhan.Visible = true;
        }
        protected void btnDong_Click(object sender, EventArgs e)
        {
            pcAddRoles.ShowOnPageLoad = false;
        }

        protected void cmbPhongBan_SelectedIndexChanged(object sender, EventArgs e)
        {
            _DataBind();
        }

        protected void grdDVT_HtmlCommandCellPrepared(object sender, ASPxGridViewTableCommandCellEventArgs e)
        {

        }

        protected void btnLuu_Click(object sender, EventArgs e)
        {
            MTCSYT.SYS_Session session = (MTCSYT.SYS_Session)Session["SYS_Session"];
            int ma_dviqly = int.Parse(session.User.ma_dviqly + "");
            var congto = db.DM_CongTos.SingleOrDefault(x => x.IDCongTo == int.Parse(lbIDCongTO.Text));


            var giaonhan = db.HD_GiaoNhanThangs.SingleOrDefault(x => x.IDCongTo == congto.IDCongTo + "" && x.Thang == int.Parse("" + cmbThang.Value) && x.Nam == int.Parse("" + cmbNam.Value) && x.IDMaDViQly == ma_dviqly);


            //CBDN.DM_CongToSelectByIDDViResult HoatDong = (CBDN.DM_CongToSelectByIDDViResult)grdDVT.GetRow(grdDVT.FocusedRowIndex);


            giaonhan.IDCongTo = congto.IDCongTo + "";
            giaonhan.IDChiNhanh = congto.IDChiNhanh;
            giaonhan.IDMaDViQly = ma_dviqly;
            giaonhan.IDUser = session.User.IDUSER;
            giaonhan.IDTram = congto.IDTram;
            giaonhan.Nam = int.Parse("0" + cmbNam.Value);
            giaonhan.Thang = int.Parse("0" + cmbThang.Value);

            giaonhan.Nhan_P_Dau = decimal.Parse(txtNPD.Text);
            giaonhan.Giao_P_Dau = decimal.Parse(txtGPDau.Text);
            giaonhan.Giao_P_SanLuong = 0;
            giaonhan.Nhan_P_SanLuong = 0;

            giaonhan.Nhan_Q_Dau = decimal.Parse(txtNQD.Text);
            giaonhan.Giao_Q_Dau = decimal.Parse(txtGQDau.Text);
            giaonhan.Giao_Q_SanLuong = 0;
            giaonhan.Nhan_Q_SanLuong = 0;


            giaonhan.CosGiao = 0;

            giaonhan.CosNhan = 0;


            giaonhan.Giao_Bieu1_Dau = decimal.Parse(txtB1D.Text);
            giaonhan.Nhan_Bieu1_Dau = decimal.Parse(txtNB1D.Text);
            giaonhan.Giao_Bieu1_SanLuong = 0;
            giaonhan.Nhan_Bieu1_SanLuong = 0;

            giaonhan.Giao_Bieu2_Dau = decimal.Parse(txtGB2D.Text);
            giaonhan.Nhan_Bieu2_Dau = decimal.Parse(txtNB2D.Text);
            giaonhan.Giao_Bieu2_SanLuong = 0;
            giaonhan.Nhan_Bieu2_SanLuong = 0;

            giaonhan.Giao_Bieu3_Dau = decimal.Parse(txtB3D.Text);
            giaonhan.Nhan_Bieu3_Dau = decimal.Parse(txtNB3D.Text);
            giaonhan.Giao_Bieu3_SanLuong = 0;
            giaonhan.Nhan_Bieu3_SanLuong = 0;
            giaonhan.ISChot = false;
            giaonhan.LoaiNhap = 0;
            giaonhan.NgayNhap = DateTime.Now;

            db.SubmitChanges();
            rpKenhGiao.Visible = false;
            rpNhan.Visible = false;
            rpThongTin.Visible = false;
            ThoiGianChon.Visible = false;
        }

        protected void grdDVT_CustomCallback(object sender, ASPxGridViewCustomCallbackEventArgs e)
        {
        }

        protected void grdDVT_CustomDataCallback(object sender, ASPxGridViewCustomDataCallbackEventArgs e)
        {
        }

        protected void grdDVT_FocusedRowChanged(object sender, EventArgs e)
        {

        }

        protected void btnHienNhapSL_Click(object sender, EventArgs e)
        {

        }

        protected void cmbDiemDo_SelectedIndexChanged(object sender, EventArgs e)
        {
            var lstDD = db.DM_DiemDos.SingleOrDefault(x => x.IDDiemDo == int.Parse(cmbDiemDo.Value + ""));

            List<Entity.DM_DVQLY> lst = new List<DM_DVQLY>();
            var chinhanh = db.DM_ChiNhanhs.SingleOrDefault(x => x.ID == int.Parse(lstDD.IDChiNhanh));
            var DonVi = dm_dviSer.SelectDM_DVQLY(chinhanh.DiemDauNguon);

            lst.Add(DonVi);

            if (chinhanh.DiemDauNguon != chinhanh.DiemCuoiNguon)
            {
                var DonVi2 = dm_dviSer.SelectDM_DVQLY(chinhanh.DiemCuoiNguon);
                lst.Add(DonVi2);
            }
            cmbDvGiao.DataSource = lst;
            cmbDvGiao.ValueField = "IDMA_DVIQLY";
            cmbDvGiao.TextField = "TEN_DVIQLY";
            cmbDvGiao.DataBind();

            cmbNhan.DataSource = lst;
            cmbNhan.ValueField = "IDMA_DVIQLY";
            cmbNhan.TextField = "TEN_DVIQLY";
            cmbNhan.DataBind();
        }

    }
}