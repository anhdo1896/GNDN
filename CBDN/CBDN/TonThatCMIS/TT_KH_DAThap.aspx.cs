using System;
using System.Collections.Generic;
using DevExpress.Web;
using Entity;
using SystemManageService;
using System.Web.UI;
using System.Linq;
using System.Data;
using Aspose.Cells;
namespace MTCSYT
{
    public partial class TT_KH_DAThap : BasePage
    {
        CBDN.DB_CBDNDataContext db = new CBDN.DB_CBDNDataContext(new CBDN.ADOController().strcn());
        private SYS_Right rightOfUser = null;
        private const string funcid = "57";
        private Cells _range;
        private Worksheet _exSheet;
        protected void Page_Load(object sender, EventArgs e)
        {
            #region PhanQuyen
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
            #endregion

            Session["SYS_Session"] = session;

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
            }
            _DataBind();
        }
        private void loadDanhMuc()
        {
            DM_DVQLYService dm_dviSer = new DM_DVQLYService();

            MTCSYT.SYS_Session session = (MTCSYT.SYS_Session)Session["SYS_Session"];
            int ma_dviqly = int.Parse(session.User.ma_dviqly + "");
            var lst_dmdv = dm_dviSer.SelectAll_DVI_ByChild(ma_dviqly);

            cmbCuoiNguon.DataSource = lst_dmdv;
            cmbCuoiNguon.ValueField = "IDMA_DVIQLY";
            cmbCuoiNguon.TextField = "TEN_DVIQLY";
            cmbCuoiNguon.DataBind();

        }
        private void _DataBind()
        {
            MTCSYT.SYS_Session session = (MTCSYT.SYS_Session)Session["SYS_Session"];
            grdDVT.DataSource = db.TT_KhachHangDAThapTrongThang(int.Parse(session.User.ma_dviqly + ""), int.Parse(cmbThang.Value + ""), int.Parse("" + cmbNam.Value)).ToList();
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
                CBDN.TT_KhachHangDAThapTrongThangResult HoatDong = (CBDN.TT_KhachHangDAThapTrongThangResult)grdDVT.GetRow(grdDVT.FocusedRowIndex);


                CBDN.TT_KhachHangDAThap cv = new CBDN.TT_KhachHangDAThap();
                cv = db.TT_KhachHangDAThaps.SingleOrDefault(x => x.ID == HoatDong.ID);
                db.TT_KhachHangDAThaps.DeleteOnSubmit(cv);
                db.SubmitChanges();
                _DataBind();
                ScriptManager.RegisterStartupScript(Page, Page.GetType(), "", "alert('Xoá tổn thất khách hàng điện áp thấp thành công');", true);
            }
            catch (Exception ex)
            { }
            finally
            {
                e.Cancel = true;
            }
        }


        private bool CheckName(int donvi, int thang, int nam)
        {
            SYS_Session session = (SYS_Session)Session["SYS_Session"];

            var dt = db.TT_KhachHangDAThaps.SingleOrDefault(x => x.IDMA_DVIQLY == donvi && x.Thang == thang && x.Nam == nam);
            if (dt != null)
                return false;
            return true;
        }

        protected void grdDVT_CellEditorInitialize(object sender, ASPxGridViewEditorEventArgs e)
        {
            e.Column.ToString();
            if (e.Column.FieldName == "MaChiNhanh")
                e.Editor.Focus();
        }

        protected void btnThem_Click(object sender, EventArgs e)
        {
            pcAddRoles.ShowOnPageLoad = true;
            txtGiaiPhap.Text = "";
            txtSoKh160.Text = "";
            txtSoKH180.Text = "";
            txtSoKH200.Text = "";
            txtSoTram.Text = "";
            txtTienDo.Text = "";
            cmbCuoiNguon.Value = 0;

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
            CBDN.TT_KhachHangDAThapTrongThangResult cv = (CBDN.TT_KhachHangDAThapTrongThangResult)grdDVT.GetRow(grdDVT.FocusedRowIndex);
            txtSoTram.Text = cv.SoTBA + "";
            txtSoKh160.Value = cv.KH160 + "";
            txtSoKH180.Value = cv.KH180 + "";
            txtSoKH200.Value = cv.KH200 + "";
            cmbNam.Value = cv.Nam;
            cmbThang.Value = cv.Thang;
            txtTienDo.Text = cv.TienDoThucHien;
            txtGiaiPhap.Text = cv.GiaiPhap;

            loadDanhMuc();
            cmbCuoiNguon.Value = cv.IDMA_DVIQLY;
            cmbCuoiNguon.Text = db.DM_DVQLies.SingleOrDefault(x => x.IDMA_DVIQLY == cv.IDMA_DVIQLY).TEN_DVIQLY;
        }

        protected void btnCapNhat_Click(object sender, EventArgs e)
        {
            DM_DVQLYService dm_dviSer = new DM_DVQLYService();
            SYS_Session session = (SYS_Session)Session["SYS_Session"];
            if (cmbCuoiNguon.Value == null)
            {
                ScriptManager.RegisterStartupScript(Page, Page.GetType(), "", "alert('Bạn chưa chọn đơn vị');", true);
                cmbCuoiNguon.Focus();
                return;
            }
            if (txtSoTram.Text + "" == "")
            {
                ScriptManager.RegisterStartupScript(Page, Page.GetType(), "", "alert('Bạn phải nhập số khách hàng đang có điện áp thấp');", true);
                txtSoTram.Focus(); return;
            }
            int testInt = 0;
            if (!int.TryParse(txtSoTram.Text + "", out testInt))
            {
                ScriptManager.RegisterStartupScript(Page, Page.GetType(), "", "alert('Số khách hàng đang có điện áp thấp phải là kiểu số');", true);
                txtSoTram.Focus(); return;
            }
            if (!int.TryParse(txtSoKh160.Text + "", out testInt))
            {
                ScriptManager.RegisterStartupScript(Page, Page.GetType(), "", "alert('Số khách hàng SH có điện áp thấp < 160kV');", true);
                txtSoKh160.Focus(); return;
            }
            if (!int.TryParse(txtSoKH180.Text + "", out testInt))
            {
                ScriptManager.RegisterStartupScript(Page, Page.GetType(), "", "alert('Số khách hàng SH có điện áp thấp từ 160kV -180kv');", true);
                txtSoKH180.Focus(); return;
            }
            if (!int.TryParse(txtSoKH200.Text + "", out testInt))
            {
                ScriptManager.RegisterStartupScript(Page, Page.GetType(), "", "alert('Số khách hàng SH có điện áp thấp trên 200kv');", true);
                txtSoKH200.Focus(); return;
            }
            string dvdaunguon = dm_dviSer.SelectDM_DVQLY(int.Parse(session.User.ma_dviqly)).MA_DVIQLY;
            string dvcuoinguon = dm_dviSer.SelectDM_DVQLY(int.Parse(cmbCuoiNguon.Value + "")).MA_DVIQLY;
            if (Session["Add"] + "" == "0")
            {
                CBDN.TT_KhachHangDAThapTrongThangResult qtCT = (CBDN.TT_KhachHangDAThapTrongThangResult)grdDVT.GetRow(grdDVT.FocusedRowIndex);

                CBDN.TT_KhachHangDAThap cn = db.TT_KhachHangDAThaps.SingleOrDefault(x => x.ID == qtCT.ID);

                cn.SoTBA = int.Parse(txtSoTram.Text);
                cn.KH160 = int.Parse(txtSoKh160.Value + "");
                cn.KH180 = int.Parse(txtSoKH180.Value + "");
                cn.KH200 = int.Parse(txtSoKH200.Value + "");
                cn.Nam = int.Parse(cmbNam.Value + "");
                cn.Thang = int.Parse(cmbThang.Value + "");
                cn.TienDoThucHien = txtTienDo.Text;
                cn.GiaiPhap = txtGiaiPhap.Text;
                cn.IDMA_DVIQLY = int.Parse(cmbCuoiNguon.Value + "");
                db.SubmitChanges();

                //}


            }
            else
            {


                if (!CheckName(int.Parse(cmbCuoiNguon.Value + ""), int.Parse(cmbThang.Value + ""), int.Parse("" + cmbNam.Value)))
                {
                    ScriptManager.RegisterStartupScript(Page, Page.GetType(), "", "alert('Mã phương thức giao nhận được trùng');", true); return;
                }

                CBDN.TT_KhachHangDAThap cv = new CBDN.TT_KhachHangDAThap();
                cv.SoTBA = int.Parse(txtSoTram.Text);
                cv.KH160 = int.Parse(txtSoKh160.Value + "");
                cv.KH180 = int.Parse(txtSoKH180.Value + "");
                cv.KH200 = int.Parse(txtSoKH200.Value + "");
                cv.Nam = int.Parse(cmbNam.Value + "");
                cv.Thang = int.Parse(cmbThang.Value + "");
                cv.TienDoThucHien = txtTienDo.Text;
                cv.GiaiPhap = txtGiaiPhap.Text;
                cv.IDMA_DVIQLY = int.Parse(cmbCuoiNguon.Value + "");
                db.TT_KhachHangDAThaps.InsertOnSubmit(cv);
                db.SubmitChanges();



            }
            pcAddRoles.ShowOnPageLoad = false;
            _DataBind();
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

        protected void btnXuat_Click(object sender, EventArgs e)
        {
            Response.Redirect("../Report/Report.aspx?Thang=" + cmbThang.Value + "&Nam=" + cmbNam.Value + "&Loai=4");

        }



        protected void btnLoc_Click(object sender, EventArgs e)
        {

        }


    }
}