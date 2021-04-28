using System;
using System.Collections.Generic;
using SystemManageService;
using DevExpress.Web.ASPxTreeList;
using Entity;
using System.Linq;
using System.Web.UI;
using System.Data;
using DevExpress.Web;
namespace MTCSYT
{
    public partial class bd_NVienNhapXacNhan : BasePage
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
            LoadGrdNhan();
        }
        private void loadGiaoNhan()
        {
            MTCSYT.SYS_Session session = (MTCSYT.SYS_Session)Session["SYS_Session"];
            var lstDD = db.db_SelectPhuongThucCanXN(int.Parse(session.User.ma_dviqly + ""), int.Parse(lbThang.Text), int.Parse(lbNam.Text), "NVNhapXN").ToList();
            cmbPhuongThuc.DataSource = lstDD;
            cmbPhuongThuc.ValueField = "IDChiNhanh";
            cmbPhuongThuc.TextField = "TenPhuongThuc";
            cmbPhuongThuc.DataBind();

        }
        private void LoadGrdNhan()
        {
            MTCSYT.SYS_Session session = (MTCSYT.SYS_Session)Session["SYS_Session"];
            int strMadviqly = int.Parse(session.User.ma_dviqly);
            //var lstNhan = db.db_DSDiemNhanNVXacNhan(strMadviqly, int.Parse(lbThang.Text + ""), int.Parse(lbNam.Text + ""));

            //var lstGiao = db.db_DSDiemGiaoNVXacNhan(strMadviqly, int.Parse(lbThang.Text + ""), int.Parse(lbNam.Text + ""));


            grdNhan.DataSource = db.DM_CayDanhMuc_Sum_CanXacNhan(strMadviqly,int.Parse(cmbPhuongThuc.Value + ""), int.Parse(lbThang.Text + ""), int.Parse(lbNam.Text + ""), "");
            grdNhan.DataBind();


        }
        protected void cbAll_Init(object sender, EventArgs e)
        {

            ASPxCheckBox chk = sender as ASPxCheckBox;
            ASPxGridView grid = (chk.NamingContainer as GridViewHeaderTemplateContainer).Grid;
            chk.Checked = (grid.Selection.Count == grid.VisibleRowCount);
        }
        private void loadDSNgay()
        {
            int thang, nam;
            if (DateTime.Now.Month == 1)
            {
                thang = 12;
                nam = DateTime.Now.Year - 1;
            }
            else
            {
                thang = DateTime.Now.Month - 1;
                nam = DateTime.Now.Year;
            }

            lbThang.Text = thang + ""; lbNam.Text = nam + "";
        }
        protected void grdNhan_CustomCallback(object sender, DevExpress.Web.ASPxGridViewCustomCallbackEventArgs e)
        {
            LoadGrdNhan();
        }
        protected void grdGiao_Callback(object sender, EventArgs e)
        {

        }
        protected void btnDuyet_Click(object sender, EventArgs e)
        {

            try
            {
                MTCSYT.SYS_Session session = (MTCSYT.SYS_Session)Session["SYS_Session"];
                string strMadviqly = session.User.ma_dviqly;


                if (grdNhan.Selection.Count == 0) return;
                List<Object> keyvalues = grdNhan.GetSelectedFieldValues("ID");
                // List<Object> temp = new List<Object>();


                foreach (object key in keyvalues)
                {
                    var bd_chitiet = db.HD_GiaoNhanThangs.SingleOrDefault(x => x.ID == int.Parse(key + ""));
                    bd_chitiet.ISNhanVien = true;
                    bd_chitiet.IDUseNhanVienXN = session.User.IDUSER;
                    bd_chitiet.DateNhanVienXN = DateTime.Now;
                    db.SubmitChanges();
                }

                LoadGrdNhan();
                //pcAddRoles.ShowOnPageLoad = false;

            }
            catch (Exception ex)
            {
                ScriptManager.RegisterStartupScript(Page, Page.GetType(), "", "alert('Lỗi duyệt chấm nợ " + ex.Message + "');", true);

            }
        }



        protected void btnHuy_Click(object sender, EventArgs e)
        {
            MTCSYT.SYS_Session session = (MTCSYT.SYS_Session)Session["SYS_Session"];
            string strMadviqly = session.User.ma_dviqly;

            if (grdNhan.Selection.Count == 0) return;
            List<Object> keyvalues = grdNhan.GetSelectedFieldValues("IDCongTo");


            foreach (object key in keyvalues)
            {
                var bd_chitiet = db.HD_GiaoNhanThangs.Where(x => x.IDCongTo == key + "");
                foreach (var item in bd_chitiet)
                {
                    item.XacNhanDVNhan = false;
                    item.ISChot = false;
                    item.IDXacNhanNhan = int.Parse(strMadviqly);
                    item.NgayXacNhanDVNhan = DateTime.Now;
                    db.SubmitChanges();
                }

            }
            LoadGrdNhan();
        }

        protected void ckNhan_Init(object sender, EventArgs e)
        {
            ASPxCheckBox chk = sender as ASPxCheckBox;
            ASPxGridView grid = (chk.NamingContainer as GridViewHeaderTemplateContainer).Grid;
            chk.Checked = (grid.Selection.Count == grid.VisibleRowCount);
        }

        protected void btnDong_Click(object sender, EventArgs e)
        {
            //pcAddRoles.ShowOnPageLoad = false;
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

                db.SubmitChanges();
            }
            LoadGrdNhan();

        }

        protected void cmbThang_SelectedIndexChanged(object sender, EventArgs e)
        {
            LoadGrdNhan();
        }

        protected void cmbNam_SelectedIndexChanged(object sender, EventArgs e)
        {
            LoadGrdNhan();
        }

        protected void cmbPhuongThuc_SelectedIndexChanged(object sender, EventArgs e)
        {
            LoadGrdNhan();
        }

    }
}