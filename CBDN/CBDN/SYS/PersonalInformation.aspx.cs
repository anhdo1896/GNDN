using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using SystemManageService;
using Entity;
using System.Web.UI;

namespace MTCSYT
{
    public partial class PersonalInformation : BasePage
    {
        DM_USERService _userService = new DM_USERService();
        protected void Page_Load(object sender, EventArgs e)
        {

            if (!IsPostBack)
                LoadUser();
        }
        private void LoadUser()
        {
            SYS_Session session = (SYS_Session)Session["SYS_Session"];
            txtUserName.Text = session.User.USERNAME;
            txtFullName.Text = session.User.HOTEN;
            txtSDT.Text = session.User.SODT;
            txtEmail.Text = session.User.EMAIL;
        }

        private bool IsValidEmailAddress(string sEmail)
        {
            return Regex.IsMatch(sEmail, @"^([\w-\.]+)@((\[[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}\.)|(([\w-]+\.)+))([a-zA-Z]{2,4}|[0-9]{1,3})(\]?)$");
        }

        protected void btnUpdate_Click(object sender, EventArgs e)
        {

            //ChangeLbUser(UserNameNew);
            SYS_Session session = (SYS_Session)Session["SYS_Session"];
            session.User.USERNAME = txtUserName.Text;
            session.User.HOTEN = txtFullName.Text;
            session.User.SODT = txtSDT.Text;
            session.User.PASSWORD = session.User.PASSWORD;
            session.User.XACNHAN = session.User.XACNHAN;

            if (IsValidEmailAddress(txtEmail.Text))
            {
                ScriptManager.RegisterStartupScript(Page, Page.GetType(), "", "alert('Succsess.');", true);
                session.User.EMAIL = txtEmail.Text;
                _userService.UpdateDM_USER(session.User);
            }
            else
            {
                ScriptManager.RegisterStartupScript(Page, Page.GetType(), "", "alert('Error.Improperly formatted email');", true);
                return;
            }
            Session["SYS_Session"] = session;
            //WriteLog("Cập nhật thông tin cá nhân", Action.Update);
        }
    }
}