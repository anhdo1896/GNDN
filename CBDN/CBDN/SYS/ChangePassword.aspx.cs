using System;
using System.Collections.Generic;
using System.Web.UI;
using SystemManageService;
using Entity;


namespace MTCSYT
{
    public partial class PasswordChange : BasePage
    {
        DM_USERService _userService = new DM_USERService();
        private DM_USER user = new DM_USER();
        protected void Page_Load(object sender, EventArgs e)
        {
            SYS_Session session = (SYS_Session)Session["SYS_Session"];
            lbUserName.Text = session.User.USERNAME;
        }
        private bool checkRetypePassword(ref  string Msg)
        {
            SYS_Session session = (SYS_Session)Session["SYS_Session"];
            user = _userService.CheckLogIn(session.User.USERNAME, txtPassword.Text, session.User.MA_DVIQLY);
            if (user == null)
            {
                txtPassWordNew.Text = "";
                txtRetypeNewPassword.Text = "";
                Msg = "you enter the wrong password";

                return false;
            }
            if (txtRetypeNewPassword.Text != txtPassWordNew.Text)
            {
                Msg = "the two passwords do not match";
                return false;
            }
            return true;
        }
        protected void btnUpdate_Click(object sender, EventArgs e)
        {
            string msg = "";
            if (checkRetypePassword(ref msg))
            {
                ScriptManager.RegisterStartupScript(Page, Page.GetType(), "", "alert('Cập nhật thành công.');", true);
            }
            else
            {
                ScriptManager.RegisterStartupScript(Page, Page.GetType(), "", "alert('Đã xảy ra lỗi, vui lòng nhập lại." + msg + "');", true);
                return;
            }

            SYS_Session session = (SYS_Session)Session["SYS_Session"];
            DM_USER user1 = new DM_USER();
            user1.IDUSER = session.User.IDUSER;
            user1.PASSWORD =DM_USER.Encrypt( txtPassWordNew.Text);

            _userService.UpdateDM_USER_PASSWORD(user1,session.User.MA_DVIQLY);
            //WriteLog("Thay đổi mật khẩu", Action.Update);
        }
    }
}