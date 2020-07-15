using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using SystemManageService;
using Entity;
using System.Web.UI;
namespace QLY_VTTB
{
    public partial class PersonalInformation : MTCSYT.BasePage
    {
        DM_USERService _userService = new DM_USERService();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
                LoadUser();
        }
        private void LoadUser()
        {
            MTCSYT.SYS_Session session = (MTCSYT.SYS_Session)Session["SYS_Session"];
            txtUserName.Text = session.User.USERNAME;
            txtDiaChi.Text = session.User.DIACHI;
            txtEmail.Text = session.User.EMAIL;
            txtHoTen.Text = session.User.FullName;
            txtSoDT.Text = session.User.SODT;
        }

        private bool IsValidEmailAddress(string sEmail)
        {
            return Regex.IsMatch(sEmail, @"^([\w-\.]+)@((\[[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}\.)|(([\w-]+\.)+))([a-zA-Z]{2,4}|[0-9]{1,3})(\]?)$");
        }

        protected void btnUpdate_Click(object sender, EventArgs e)
        {
            MTCSYT.SYS_Session session = (MTCSYT.SYS_Session)Session["SYS_Session"];
            session.User.USERNAME = txtUserName.Text;
            session.User.HOTEN = txtHoTen.Text;
            session.User.DIACHI = txtDiaChi.Text;
            session.User.SODT = txtSoDT.Text;
            session.User.PASSWORD = session.User.PASSWORD;
            session.User.XACNHAN = session.User.XACNHAN;
            session.User.IDMA_DVIQLY = session.User.IDMA_DVIQLY;
            session.User.NGAYSINH = session.User.NGAYSINH;

            if (IsValidEmailAddress(txtEmail.Text))
            {
                ScriptManager.RegisterStartupScript(Page, Page.GetType(), "", "alert('Cập nhật thành công.');", true);
                session.User.EMAIL = txtEmail.Text;
                _userService.UpdateDM_USER(session.User);
            }
            else
            {
                ScriptManager.RegisterStartupScript(Page, Page.GetType(), "", "alert('Email của bạn không đúng định dạng.Vui lòng nhập lại!');", true);
                txtEmail.Focus();
                return;
            }
            Session["SYS_Session"] = session;
            //WriteLog("Cập nhật thông tin cá nhân", Action.Update);
        }
    }
}