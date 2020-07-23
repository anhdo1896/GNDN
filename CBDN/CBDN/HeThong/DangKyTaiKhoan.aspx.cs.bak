using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using DevExpress.Web.ASPxEditors;
using DevExpress.Web.ASPxGridView;
using DevExpress.Web.ASPxTreeList;
using Entity;
using SystemManageService;
using System.Data;

namespace QLY_VTTB
{
    public partial class DangKyTaiKhoan : MTCSYT.BasePage
    {

        DM_USERService _IDM_USERService = new DM_USERService();
        protected void Page_Load(object sender, EventArgs e)
        {            
            BindComboDonVi();            
        }    
          
        private void BindComboDonVi()
        {
            DM_DVQLYService dm_dviSer = new DM_DVQLYService();
            List<DM_DVQLY> lst_dmdv = new List<DM_DVQLY>();
            lst_dmdv = dm_dviSer.SelectAllDM_DVQLY();
            cmbDonVi.DataSource = lst_dmdv;
            cmbDonVi.ValueField = "IDMA_DVIQLY";
            cmbDonVi.TextField = "NAME_DVIQLY";
            cmbDonVi.DataBind();
        }
        private int IndexOf(int ID, List<Entity.DM_DVQLY> lstOrganization)
        {
            int ret = 0;
            for (int i = 0; i < lstOrganization.Count; i++)
            {
                if (ID == lstOrganization[i].IDMA_DVIQLY)
                {
                    ret = i;
                    break;
                }
            }
            return ret;
        }

        private bool checkUser(string name, int IDMA_DVIQLY)
        {
            DM_USER sysuser = _IDM_USERService.DM_UserByUserNameAndIDOrganization(IDMA_DVIQLY, name);
            if (sysuser != null && sysuser.IDUSER > 0)
                return false;
            else
                return true;
        }

        protected void btnAddUser_Click(object sender, EventArgs e)
        {
            DM_USER sysUser = new DM_USER();
            DateTime testdate = new DateTime();
            loiNgayThang.Visible = false;
            try
            {

                if (checkUser(txtUserName.Text, int.Parse(cmbDonVi.Value.ToString())))
                {
                    DM_USER User = new DM_USER { USERNAME = txtUserName.Text };
                    // Password:
                    string password = txtPassword.Text;
                    if (!string.IsNullOrEmpty(password))
                    {
                        User.PASSWORD = DM_USER.Encrypt(password);
                    }
                    User.HOTEN = txtHoTen.Text;
                    User.DIACHI = txtDiaChi.Text;
                    if (txtNgaySinh.Text.Trim() != "")
                    {
                        if (txtNgaySinh.Text.Split('/').Length == 3)
                        {
                            if (DateTime.TryParse(txtNgaySinh.Text, out testdate))
                                User.NGAYSINH = DateTime.Parse(txtNgaySinh.Text);
                        }
                        else
                        {
                            loiNgayThang.Visible = true;
                            return;
                        }
                    }
                    else
                        User.NGAYSINH = DateTime.Now;
                    User.EMAIL = txtEmail.Text;
                    User.XACNHAN =  false;
                    User.SODT = txtPhone.Text;
                    sysUser.IS_ADMIN = 0;

                    User.IDMA_DVIQLY = int.Parse(cmbDonVi.Value.ToString());
                    _IDM_USERService.InsertDM_USER(User);
                    ClientScript.RegisterClientScriptBlock(this.GetType(), "", "<script language='javascript'>alert('Đăng ký tài khoảng thành công! Vui lòng chờ xác nhận');</script>");
                }
                else
                {
                    lblError.Visible = true;
                    throw new Exception(string.Format("Trùng tên! Vui lòng nhập lại."));
                }

            }
            catch (Exception ex)
            {
                lblError.Text = ex.Message;
            }
        }

        protected void btnDong_Click1(object sender, EventArgs e)
        {
            txtUserName.Text = "";
            txtPhone.Text = "";
            txtPassword.Text = "";
            txtHoTen.Text = "";
            txtEmail.Text = "";
            txtDiaChi.Text = "";
            txtNgaySinh.Text = "";
        }
    }
}