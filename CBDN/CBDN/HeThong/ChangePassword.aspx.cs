using System;
using System.Collections.Generic;
using System.Web.UI;
using SystemManageService;
using Entity;
using DataAccess;

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
            var ds = Dapper_SQL.Checklogin(session.User.IDMA_DVIQLY,session.User.USERNAME, txtPassword.Text);
            //user = _userService.CheckLogIn(session.User.USERNAME, txtPassword.Text, session.User.IDMA_DVIQLY);
            if (ds == null)
            {
                txtPassWordNew.Text = "";
                txtRetypeNewPassword.Text = "";
                Msg = "Sai password cũ ";

                return false;
            }
            if (txtRetypeNewPassword.Text != txtPassWordNew.Text)
            {
                Msg = "hai ô text nhập Password mới phải giống nhau";

            }
            if (!CheckPass_User.CheckPassword(txtRetypeNewPassword.Text))
            {
                Msg = "Phải tối thiểu 8 ký tự, 1 chữ hoa, 1 chữ thường, 1 ký tự đặc biệt";
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
            session.XacNhanPass = 1;
            session.DatePass = 0;
            Dapper_SQL.updatePass_DMUSER(session.User.IDMA_DVIQLY, session.User.USERNAME, session.User.PASSWORD);
           // _userService.UpdateDM_USER_PASSWORD(session.User,session.User.MA_DVIQLY);
            //WriteLog("Thay đổi mật khẩu", Action.Update);
        }
    }
}