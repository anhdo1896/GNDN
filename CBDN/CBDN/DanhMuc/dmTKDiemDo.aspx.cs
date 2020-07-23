using System;
using System.Collections.Generic;
using DevExpress.Web;
using Entity;
using SystemManageService;
using System.Web.UI;
using System.Linq;
using System.Data;
using DevExpress.Web.ASPxGridView;
using DevExpress.Web;
namespace MTCSYT
{
    public partial class dmTKDiemDo : BasePage
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
                Response.Redirect("~\\login\\Login.aspx");
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
                cmbThang.Value = DateTime.Now.Month;
                cmbNam.Value = DateTime.Now.Year;
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
                lbDiemDo.Text = db.DM_DiemDos.SingleOrDefault(x => x.IDDiemDo == congto.IDDiemDo).TenDiemDo;
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
                lbPhuongthuc.Text = db.DM_ChiNhanhs.SingleOrDefault(x => x.ID == congto.IDChiNhanh).TenChiNhanh;

            }
        }
        private void loadDanhMuc()
        {
            DM_DVQLYService dm_dviSer = new DM_DVQLYService();

            MTCSYT.SYS_Session session = (MTCSYT.SYS_Session)Session["SYS_Session"];
            int ma_dviqly = int.Parse(session.User.ma_dviqly + "");

            var lstDD = db.DM_DiemDos.Where(x => x.IDMaDViQly == ma_dviqly).ToList();
            cmbDiemDo.DataSource = lstDD;
            cmbDiemDo.ValueField = "IDDiemDo";
            cmbDiemDo.TextField = "TenDiemDo";
            cmbDiemDo.DataBind();

            //  var lstLo = db.DM_Los.Where(x => x.IDMaDViQly == ma_dviqly).ToList();


            var lstDMTinhChat = db.DM_TinhChatKenhs.ToList();
            cmbTinhChatGiao.DataSource = lstDMTinhChat;
            cmbTinhChatGiao.ValueField = "ID";
            cmbTinhChatGiao.TextField = "TinhChat";
            cmbTinhChatGiao.DataBind();

            cmbTinhChatNhan.DataSource = lstDMTinhChat;
            cmbTinhChatNhan.ValueField = "ID";
            cmbTinhChatNhan.TextField = "TinhChat";
            cmbTinhChatNhan.DataBind();


        }
        private void _DataBind()
        {
            MTCSYT.SYS_Session session = (MTCSYT.SYS_Session)Session["SYS_Session"];
            int ma_dviqly = int.Parse(session.User.ma_dviqly + "");

            grdDVT.DataSource = db.DM_CongToSelectByIDDVi(ma_dviqly).ToList();
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
                CBDN.DM_CongTo cv = new CBDN.DM_CongTo();
                cv = db.DM_CongTos.SingleOrDefault(x => x.IDCongTo == HoatDong.IDCongTo && x.IDDonViQuanLy == int.Parse(session.User.ma_dviqly));
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


        private bool CheckName(string Name, int id)
        {
            SYS_Session session = (SYS_Session)Session["SYS_Session"];

            var dt = db.DM_CongTos.SingleOrDefault(x => x.MaCongTo == Name && x.IDDonViQuanLy == int.Parse(session.User.ma_dviqly) && x.IDCongTo != id);
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
            cmbDiemDo.Value = (int)cv.IDDiemDo;
            cmbLo.Value = (int)cv.IDLo;
            if (cv.TinhTrang == 1)
                CkHoatDong.Checked = true;
            else
                CkHoatDong.Checked = false;
            mmMoTa.Text = cv.MoTa;

            txtCapDienAp.Text = cv.CapDienAp + "";
            txtChungLoai.Text = cv.ChungLoai;
            txtHangSanXuat.Text = cv.HangSanXuat;
            txtHeSoNhan.Text = cv.HeSoNhan + "";

            txtTuTi.Text = cv.TU_TI;
            dtNgayTreo.Text = cv.NgayTreoThao + "";
            cmbDvGiao.Value = cv.IDDonViGiao;
            cmbNhan.Value = cv.IDDonViNhan;
            cmbTinhChatNhan.Value = cv.NhanTinhChat;
            cmbTinhChatGiao.Value = cv.GiaoTinhChat;
            cmbTinhChatNhan.Text = cv.strTinhChatNhan + "";
            cmbTinhChatGiao.Text = cv.strTinhChatGiao + "";
            txtHsNhanQD.Text = cv.HeSoQuyDoi + "";
        }

        protected void btnCapNhat_Click(object sender, EventArgs e)
        {
            SYS_Session session = (SYS_Session)Session["SYS_Session"];
            int idChiNhanh = 0; int idtram = 0;
            if (session.User.ma_dviqly != cmbDvGiao.Value + "")
            {
                ScriptManager.RegisterStartupScript(Page, Page.GetType(), "", "alert('Không phải đơn vị giao không tạo được công tơ này.');", true);
                return;
            }
            if (cmbDiemDo.Value + "" != "")
            {
                var diemdo = db.DM_DiemDos.SingleOrDefault(x => x.IDDiemDo == int.Parse("0" + cmbDiemDo.Value));

                idChiNhanh = int.Parse("0" + diemdo.IDChiNhanh);
                idtram = diemdo.IDTram;
            }
            decimal cda = 0;
            if (txtCapDienAp.Text != "")
            {
                if (!decimal.TryParse(txtCapDienAp.Text, out cda))
                {
                    ScriptManager.RegisterStartupScript(Page, Page.GetType(), "", "alert('Cấp điện áp là kiểu só');", true);
                    txtCapDienAp.Focus();
                    return;
                }
                cda = decimal.Parse(txtCapDienAp.Text);
            }
            decimal hsn = 0, hsQD = 0;
            if (txtHeSoNhan.Text != "")
            {
                if (!decimal.TryParse(txtHeSoNhan.Text, out cda))
                {
                    ScriptManager.RegisterStartupScript(Page, Page.GetType(), "", "alert('Hệ số nhân là kiểu số');", true);
                    txtHeSoNhan.Focus();
                    return;
                }
                hsn = decimal.Parse(txtHeSoNhan.Text);
            }
            if (txtHsNhanQD.Text != "")
            {
                if (!decimal.TryParse(txtHsNhanQD.Text, out cda))
                {
                    ScriptManager.RegisterStartupScript(Page, Page.GetType(), "", "alert('Hệ số nhân quy đổi là kiểu số');", true);
                    txtHsNhanQD.Focus();
                    return;
                }
                hsQD = decimal.Parse(txtHsNhanQD.Text);
            }
            if (cmbNhan.Value != null)
            {
                if (cmbTinhChatNhan.Value + "" == "")
                {
                    ScriptManager.RegisterStartupScript(Page, Page.GetType(), "", "alert('Kênh nhận không được để trống');", true);
                    txtHeSoNhan.Focus();
                    return;
                }
            }
            if (cmbDvGiao.Value != null)
            {
                if (cmbTinhChatGiao.Value + "" == "")
                {
                    ScriptManager.RegisterStartupScript(Page, Page.GetType(), "", "alert('Kênh giao không được để trống');", true);
                    txtHeSoNhan.Focus();
                    return;
                }
            }
            if (Session["Add"] + "" == "0")
            {
                CBDN.DM_CongToSelectByIDDViResult cv = (CBDN.DM_CongToSelectByIDDViResult)grdDVT.GetRow(grdDVT.FocusedRowIndex);
                var lstqtCT = db.DM_CongTos.Where(x => x.MaCongTo == cv.MaCongTo);
                foreach (var qtCT in lstqtCT)
                {
                    var dd = db.DM_Los.SingleOrDefault(x => x.IDLo == int.Parse(cmbLo.Value + ""));
                    if (!CheckName(txtMaDuongDat.Text, cv.IDCongTo))
                    {
                        ScriptManager.RegisterStartupScript(Page, Page.GetType(), "", "alert('Mã đường dây không được trùng');", true); return;
                    }


                    //CBDN.DM_CongTo qtCT = new CBDN.DM_CongTo();
                    qtCT.TenCongTo = txtTenDuongDay.Text;
                    qtCT.MoTa = mmMoTa.Text;
                    qtCT.IDDiemDo = int.Parse(cmbDiemDo.Value + "");
                    if (cmbLo.Value + "" != "")
                        qtCT.IDLo = int.Parse(cmbLo.Value + "");
                    else
                        qtCT.IDLo = 0;

                    qtCT.IDChiNhanh = idChiNhanh;
                    if (CkHoatDong.Checked)
                        qtCT.TinhTrang = 1;
                    else
                        qtCT.TinhTrang = 0;
                    qtCT.CapDienAp = cda;
                    qtCT.ChungLoai = txtChungLoai.Text;
                    qtCT.HangSanXuat = txtHangSanXuat.Text;
                    qtCT.HeSoNhan = hsn;
                    qtCT.TU_TI = txtTuTi.Text;

                    if (cmbNhan.Value != null)
                    {
                        qtCT.IDDonViNhan = int.Parse(cmbNhan.Value + "");
                        qtCT.KenhNhanCongTo = cmbTinhChatNhan.Value + "";
                        if (cmbTinhChatNhan.Value != null)
                            qtCT.NhanTinhChat = int.Parse(cmbTinhChatNhan.Value + "");
                    }


                    qtCT.IDTram = idtram;
                    if (cmbDvGiao.Value != null)
                    {
                        qtCT.IDDonViGiao = int.Parse(cmbDvGiao.Value + "");
                        qtCT.KenhGiaoCongTo = "" + cmbTinhChatGiao.Value;
                        qtCT.GiaoTinhChat = int.Parse(cmbTinhChatGiao.Value + "");
                    }
                    qtCT.HeSoQuyDoi = hsQD;
                    db.SubmitChanges();
                }


            }
            else
            {

                if (!CheckName(txtMaDuongDat.Text, 0))
                {
                    ScriptManager.RegisterStartupScript(Page, Page.GetType(), "", "alert('Mã đường dây không được trùng');", true); return;
                }
                var diemdo = db.DM_DiemDos.SingleOrDefault(x => x.IDDiemDo == int.Parse(cmbDiemDo.Value + ""));
                var lst = db.DM_DiemDos.Where(x => x.MaDiemDo == diemdo.MaDiemDo).ToList();
                foreach (var ddo in lst)
                {
                    CBDN.DM_CongTo cv = new CBDN.DM_CongTo();
                    cv.MaCongTo = txtMaDuongDat.Text;
                    cv.TenCongTo = txtTenDuongDay.Text;
                    cv.MoTa = mmMoTa.Text;
                    cv.IDDiemDo = ddo.IDDiemDo;
                    if (cmbLo.Value + "" != "")
                        cv.IDLo = int.Parse(cmbLo.Value + "");
                    else
                        cv.IDLo = 0;
                    cv.IDDonViQuanLy = ddo.IDMaDViQly;
                    if (CkHoatDong.Checked)
                        cv.TinhTrang = 1;
                    else
                        cv.TinhTrang = 0;
                    cv.CapDienAp = cda;
                    cv.ChungLoai = txtChungLoai.Text;
                    cv.HangSanXuat = txtHangSanXuat.Text;
                    cv.HeSoNhan = hsn;
                    cv.NgayTreoThao = DateTime.Now;
                    cv.TU_TI = txtTuTi.Text;
                    cv.IDTram = ddo.IDTram;
                    cv.IDChiNhanh = ddo.IDChiNhanh;

                    if (cmbNhan.Value != null)
                    {
                        cv.IDDonViNhan = int.Parse(cmbNhan.Value + "");
                        cv.KenhNhanCongTo = "" + cmbTinhChatNhan.Value;
                        if (cmbTinhChatNhan.Value != null)
                            cv.NhanTinhChat = int.Parse(cmbTinhChatNhan.Value + "");
                    }
                    if (cmbDvGiao.Value != null)
                    {
                        cv.IDDonViGiao = int.Parse(cmbDvGiao.Value + "");
                        cv.KenhGiaoCongTo = "" + cmbTinhChatGiao.Value;
                        cv.GiaoTinhChat = int.Parse(cmbTinhChatGiao.Value + "");
                    }
                    cv.IDUser = session.User.IDUSER;
                    cv.NgayTao = DateTime.Now;
                    cv.NgayKiemDinh = dtNgayTreo.Date;
                    cv.NhanTinhChat = int.Parse(cmbTinhChatNhan.Value + "");
                    cv.GiaoTinhChat = int.Parse(cmbTinhChatGiao.Value + "");
                    cv.HeSoQuyDoi = decimal.Parse("0" + txtHsNhanQD.Text);
                    cv.HeSoQuyDoi = hsQD;
                    db.DM_CongTos.InsertOnSubmit(cv);
                    db.SubmitChanges();


                    pcAddRoles.ShowOnPageLoad = false;
                    txtGPDau.Focus();
                    setControlText(cv.IDCongTo);
                    visibleNhanChiSo();

                }


            }
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
            //CBDN.DM_CongToSelectByIDDViResult HoatDong = (CBDN.DM_CongToSelectByIDDViResult)grdDVT.GetRow(grdDVT.FocusedRowIndex);
            CBDN.HD_GiaoNhanThang giaonhan = new CBDN.HD_GiaoNhanThang();
            giaonhan.IDCongTo = congto.MaCongTo;
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
            db.HD_GiaoNhanThangs.InsertOnSubmit(giaonhan);
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

            var lstLo = db.DM_Los.Where(x => x.IDTram == lstDD.IDTram);
            cmbLo.DataSource = lstLo;
            cmbLo.ValueField = "IDLo";
            cmbLo.TextField = "TenLo";
            cmbLo.DataBind();

            List<Entity.DM_DVQLY> lst = new List<DM_DVQLY>();
            var chinhanh = db.DM_ChiNhanhs.SingleOrDefault(x => x.ID == lstDD.IDChiNhanh);
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