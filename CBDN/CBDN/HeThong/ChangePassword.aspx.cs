using System;
using System.Collections.Generic;
using System.Web.UI;
using SystemManageService;
using Entity;


namespace QLY_VTTB
{
    public partial class PasswordChange : MTCSYT.BasePage
    {
        DM_USERService _userService = new DM_USERService();
        private DM_USER user = new DM_USER();
        protected void Page_Load(object sender, EventArgs e)
        {
            MTCSYT.SYS_Session session = (MTCSYT.SYS_Session)Session["SYS_Session"];
            lbUserName.Text = session.User.USERNAME;
        }
        private bool checkRetypePassword(ref  string Msg)
        {
            MTCSYT.SYS_Session session = (MTCSYT.SYS_Session)Session["SYS_Session"];
            user = _userService.CheckLogIn(session.User.USERNAME, txtPassword.Text, session.User.IDMA_DVIQLY);
            if (user == null)
            {
                txtPassWordNew.Text = "";
                txtRetypeNewPassword.Text = "";
                Msg = "Sai password cũ ";

                return false;
            }
            if (txtRetypeNewPassword.Text != txtPassWordNew.Text)
            {
                Msg = "hai ô text nhập Password mới phải giống nhau";
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
                ScriptManager.RegisterStartupScript(Page, Page.GetType(), "", "alert('Đã xảy ra lỗi. " + msg + " vui lòng nhập lại.');", true);
                return;
            }

            MTCSYT.SYS_Session session = (MTCSYT.SYS_Session)Session["SYS_Session"]; 
            session.User.PASSWORD = DM_USER.Encrypt(txtPassWordNew.Text);
            _userService.UpdateDM_USER_PASSWORD(session.User,session.User.MA_DVIQLY);
            //WriteLog("Thay đổi mật khẩu", Action.Update);
        }
    }
}