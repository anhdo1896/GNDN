using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using DevExpress.Web;
using DevExpress.Web.ASPxTreeList;
using Entity;
using SystemManageService;
using System.Data;
using System.Net.Mail;
using System.Net;
namespace QLY_VTTB
{
    public partial class UserManager : MTCSYT.BasePage
    {
        private const string funcid = "56";
        private SYS_Right rightOfUser = null;
        private SYS_RolesService iRolesService = new SYS_RolesService();
        SYS_RightService _ISYS_RightService = new SYS_RightService();
        SYS_RightOfUserService _ISYS_RightUserService = new SYS_RightOfUserService();
        DM_USERService _IDM_USERService = new DM_USERService();
        protected void Page_Load(object sender, EventArgs e)
        {
            MTCSYT.SYS_Session session = (MTCSYT.SYS_Session)Session["SYS_Session"];
            if (session == null || session.User.USERNAME == "Guest")
            {
                session.CurrentPage = Request.AppRelativeCurrentExecutionFilePath;
                Response.Redirect("~\\Login.aspx");
            }
            //else
            //{
            //    if (Request.Cookies["IDUSER"].Value != "1")
            //    {
            //        List<SYS_Right> right = session.User.Rights;
            //        foreach (SYS_Right sysRight in right)
            //        {
            //            if (sysRight.FuncId == funcid)
            //            {
            //                rightOfUser = sysRight;
            //                Session["Right"] = sysRight;
            //                Session["UserId"] = session.User.IDUSER;
            //                Session["FunctionId"] = sysRight.FuncId;
            //                break;
            //            }
            //        }

            //        if (rightOfUser == null)
            //        {
            //            Session["Status"] = "0";
            //            Response.Redirect("~\\HeThong\\Default.aspx");

            //        }
            //    }
            //}
            Session["SYS_Session"] = session;
            if (ASPxPageControl1.ActiveTabIndex == 0)
            {
                _LoadDonVi();
                GridUser_CustomCallback(null, null);
            }
            else
                LoadTKChuaXacThuc();

        }
        private void _LoadDonVi()
        {
            DM_DVQLYService dm_dviSer = new DM_DVQLYService();

            MTCSYT.SYS_Session session = (MTCSYT.SYS_Session)Session["SYS_Session"];
            string strMadviqly = session.User.MA_DVIQLY;

            List<DM_DVQLY> lst_dmdv = new List<DM_DVQLY>();
            lst_dmdv = dm_dviSer.DM_DVQLYandLEVER_BYDV(strMadviqly);

            TreeListOrganization.DataSource = lst_dmdv;
            TreeListOrganization.DataBind();
            TreeListOrganization.ExpandToLevel(1);
        }

        private void _DataBind()
        {
            List<DM_USER> lst_User = new List<DM_USER>();
            lst_User = _IDM_USERService.SelectAllDM_USER();
            GridUser.DataSource = lst_User;
            GridUser.DataBind();

        }

        //private void FindChild(List<Entity.DM_DVQLY> _lst, int ID, ref  List<Entity.DM_DVQLY> _lstNew)
        //{
        //    foreach (Entity.DM_DVQLY sysOrganization in _lst.Where(x => x.ParentId == ID))
        //    {
        //        _lstNew.Add(sysOrganization);
        //        FindChild(_lst, sysOrganization.IDMA_DVIQLY, ref _lstNew);
        //    }
        //}

        protected void btnAdd_Click(object sender, EventArgs e)
        {
            lblError.Visible = false;
            txtUserName.Text = "";
            txtPhone.Text = "";
            txtPassword.Text = "";
            //txtNgaySinh.Text = "";
            txtDiaChi.Text = "";
            txtHoTen.Text = "";
            txtEmail.Text = "";
            Session["SYSUser"] = null;
            txtUserName.Focus();
            pcAddUser.ShowOnPageLoad = true;
            BindComboDonVi();

            //BindComboLinHVuc();
            lblPassword.Visible = true;
            txtPassword.Visible = true;
            LoadCBXNhomQuyen();
        }

        //private void BindComboLinHVuc()
        //{
        //    List<Entity.Parts> lstModun = new List<Parts>();
        //    List<Parts> lst = new List<Parts>();
        //    var sysModunService = new PartsService();
        //    cmbLinhVuc.DataSource = sysModunService.SelectAllParts(); 
        //    cmbLinhVuc.ValueField = "ID";
        //    cmbLinhVuc.TextField = "LinhVuc";
        //    cmbLinhVuc.DataBind();           
        //}
        private void BindComboDonVi()
        {
            cmbDonVi.DataSource = TreeListOrganization.DataSource;
            cmbDonVi.ValueField = "IDMA_DVIQLY";
            cmbDonVi.TextField = "MA_DVIQLY";
            cmbDonVi.DataBind();
            cmbDonVi.SelectedIndex = IndexOf(int.Parse(TreeListOrganization.FocusedNode.Key),
                                             (List<Entity.DM_DVQLY>)TreeListOrganization.DataSource);
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

        protected void GridUser_RowInserting(object sender, DevExpress.Web.Data.ASPxDataInsertingEventArgs e)
        {

        }

        protected void GridUser_RowUpdating(object sender, DevExpress.Web.Data.ASPxDataUpdatingEventArgs e)
        {

        }




        protected void btnAddUser_Click(object sender, EventArgs e)
        {
            DM_USER sysUser = new DM_USER();
            DateTime testdate = new DateTime();
            //loiNgayThang.Visible = false;
            List<SYS_Roles> lstRole = new List<SYS_Roles>();
            try
            {
                if (Session["SYSUser"] != null)
                {
                    sysUser = (DM_USER)Session["SYSUser"];
                    sysUser.XACNHAN = cbxActive.Checked;
                    sysUser.HOTEN = txtHoTen.Text;
                    sysUser.DIACHI = txtDiaChi.Text;
                    sysUser.SODT = txtPhone.Text;
                    //if (txtNgaySinh.Text.Trim() != "")
                    //{
                    //    if (txtNgaySinh.Text.Split('/').Length == 3)
                    //    {
                    //        if (DateTime.TryParse(txtNgaySinh.Text.Split('/')[1] + "/" + txtNgaySinh.Text.Split('/')[0] + "/" + txtNgaySinh.Text.Split('/')[2], out testdate))
                    //            sysUser.NGAYSINH = DateTime.Parse(txtNgaySinh.Text.Split('/')[1] + "/" + txtNgaySinh.Text.Split('/')[0] + "/" + txtNgaySinh.Text.Split('/')[2]);
                    //    }
                    //    else
                    //    {
                    //        loiNgayThang.Visible = true;
                    //        return;
                    //    }
                    //}
                    //else
                    sysUser.NGAYSINH = DateTime.Now;
                    sysUser.USERNAME = txtUserName.Text;
                    //sysUser.IDparts = int.Parse(cmbLinhVuc.Value.ToString());
                    sysUser.EMAIL = txtEmail.Text;

                    sysUser.IS_ADMIN = 0;
                    sysUser.CHUCDANH = txtChucVuFix.Text;
                    SYS_Roles sysRoles = new SYS_Roles();
                    sysRoles.ID = int.Parse(cbxNhomQuyen.Value.ToString());

                    lstRole.Add(sysRoles);
                    sysUser.RoleGroup = cbxNhomQuyen.Text;

                    sysUser.Roles = sysRoles;
                    sysUser.IDMA_DVIQLY = int.Parse(cmbDonVi.Value.ToString());
                    _IDM_USERService.UpdateSYS_UserAll(sysUser);
                    Session["SYSUser"] = null;
                    lblPassword.Visible = true;
                    txtPassword.Visible = true;
                    pcAddUser.ShowOnPageLoad = false;
                    Page_Load(sender, e);
                }
                else
                {
                    if (checkUser(txtUserName.Text, int.Parse(cmbDonVi.Value.ToString())))
                    {
                        TreeListOrganization.FocusedNode.GetValue("IDMA_DVIQLY");
                        DM_USER User = new DM_USER { USERNAME = txtUserName.Text };
                        // Password:
                        string password = txtPassword.Text;
                        if (!string.IsNullOrEmpty(password))
                        {
                            User.PASSWORD = DM_USER.Encrypt(password);
                        }
                        User.HOTEN = txtHoTen.Text;
                        User.DIACHI = txtDiaChi.Text;
                        //if (txtNgaySinh.Text.Trim() != "")
                        //{
                        //    if (txtNgaySinh.Text.Split('/').Length == 3)
                        //    {
                        //        if (DateTime.TryParse(txtNgaySinh.Text.Split('/')[1] + "/" + txtNgaySinh.Text.Split('/')[0] + "/" + txtNgaySinh.Text.Split('/')[2], out testdate))
                        //            sysUser.NGAYSINH = DateTime.Parse(txtNgaySinh.Text.Split('/')[1] + "/" + txtNgaySinh.Text.Split('/')[0] + "/" + txtNgaySinh.Text.Split('/')[2]);
                        //    }
                        //    else
                        //    {
                        //        loiNgayThang.Visible = true;
                        //        return;
                        //    }
                        //}
                        //else
                        User.NGAYSINH = DateTime.Now;
                        User.EMAIL = txtEmail.Text;
                        User.XACNHAN = cbxActive != null ? cbxActive.Checked : false;
                        User.SODT = txtPhone.Text;
                        User.CHUCDANH = txtChucVuFix.Text;
                        sysUser.IS_ADMIN = 0;

                        SYS_Roles sysRoles = new SYS_Roles();
                        sysRoles.ID = int.Parse(cbxNhomQuyen.Value.ToString());
                        lstRole.Add(sysRoles);
                        sysUser.RoleGroup = cbxNhomQuyen.Text;

                        User.Roles = sysRoles;

                        //User.IDparts = int.Parse(cmbLinhVuc.Value.ToString());
                        User.IDMA_DVIQLY = int.Parse(cmbDonVi.Value.ToString());
                        _IDM_USERService.InsertSYS_UserAll(User);

                        //thêm user vào cmis

                        pcAddUser.ShowOnPageLoad = false;
                        GridUser_CustomCallback(null, null);
                        //WriteLog("Insert " + txtUserName.Text, Action.Create);
                    }
                    else
                    {
                        lblError.Visible = true;
                        throw new Exception(string.Format("Trùng tên! Vui lòng nhập lại."));
                        //lblError.Text = "Trùng tên! Vui lòng nhập lại.";
                    }
                }
            }
            catch (Exception ex)
            {
                lblError.Text = ex.Message;
                // throw new Exception(string.Format("Trùng tên! Vui lòng nhập lại."));
            }
        }

        protected void btnEditUser_Click(object sender, EventArgs e)
        {
            //BindComboLinHVuc();
            BindComboDonVi();
            //LoadCBXNhomQuyen();
            lblError.Visible = false;
            lblPassword.Visible = false;
            txtPassword.Visible = false;
            if (GridUser.FocusedRowIndex > -1)
            {
                DM_USER sysUser = (DM_USER)GridUser.GetRow(GridUser.FocusedRowIndex);
                txtUserName.Text = sysUser.USERNAME;
                txtPhone.Text = sysUser.SODT;
                txtPassword.Text = sysUser.PASSWORD;
                txtHoTen.Text = sysUser.HOTEN;
                txtEmail.Text = sysUser.EMAIL;
                txtDiaChi.Text = sysUser.DIACHI;
                //txtNgaySinh.Text = sysUser.NGAYSINH.ToString("dd/MM/yyyy");
                cbxActive.Checked = sysUser.XACNHAN;
                txtChucVuFix.Text = sysUser.CHUCDANH;
                Session["SYSUser"] = sysUser;
                pcAddUser.ShowOnPageLoad = true;

            }

            LoadCBXNhomQuyen();
        }


        protected void GridUser_CustomCallback(object sender, ASPxGridViewCustomCallbackEventArgs e)
        {
            if (TreeListOrganization.FocusedNode == null) return;
            List<DM_USER> lstUser = new List<DM_USER>();
            lstUser = _IDM_USERService.DM_USER_SelectAll_ByIDMA_DVIQLY(int.Parse(TreeListOrganization.FocusedNode.Key));
            GridUser.DataSource = lstUser;
            GridUser.DataBind();
        }



        protected void btnDong_Click(object sender, EventArgs e)
        {
            pcAddUser.ShowOnPageLoad = false;
        }

        protected void btnXoa_Click(object sender, EventArgs e)
        {
            //String content = "<html><body><table><tr><td>your table</td></tr></table></body></html>";

            //Response.Clear();
            //Response.AddHeader("Content-Disposition", "attachment;filename=C:\abc.xls");
            //Response.ContentType = "application/vnd.xls";
            //Response.Cache.SetCacheability(HttpCacheability.NoCache); // not necessarily required
            //Response.Charset = "";
            //Response.Output.Write(content);
            //Response.End();
            if (GridUser.FocusedRowIndex > -1)
            {
                DM_USER sysUser = (DM_USER)GridUser.GetRow(GridUser.FocusedRowIndex);
                DM_USERService isysUser = new DM_USERService();

                isysUser.DeleteDM_USER(sysUser);
                GridUser_CustomCallback(null, null);
            }

        }

        protected void btnDong_Click1(object sender, EventArgs e)
        {
            pcAddUser.ShowOnPageLoad = false;

        }

        protected void btnXemThongTin_Click(object sender, EventArgs e)
        {
            if (grdUserChuaXacThuc.FocusedRowIndex > -1)
            {
                DM_USER sysUser = (DM_USER)grdUserChuaXacThuc.GetRow(grdUserChuaXacThuc.FocusedRowIndex);
                lbTenDN.Text = sysUser.USERNAME;
                lbSDT.Text = sysUser.SODT;
                lbHoTen.Text = sysUser.HOTEN;
                lbEmail.Text = sysUser.EMAIL;
                lbDiaChi.Text = sysUser.DIACHI;
                lbDonVi.Text = sysUser.strDonVi;
                lbNgayThang.Text = sysUser.NGAYSINH.ToString("dd/MM/yyyy");
                lbNgayTao.Text = sysUser.NGAYTAO.ToString("dd/MM/yyyy");
                cbxActive.Checked = sysUser.XACNHAN;
                txtChucVuFix.Text = sysUser.CHUCDANH;
                Session["SYSUser"] = sysUser;
                pcTTUser.ShowOnPageLoad = true;

            }
            else
                ScriptManager.RegisterStartupScript(Page, Page.GetType(), "", "alert('Bạn chưa chọn Tài khoản.');", true);
        }
        private void LoadTKChuaXacThuc()
        {
            List<DM_USER> lstUser = new List<DM_USER>();
            lstUser = _IDM_USERService.SelectAllSYS_User_NotIsActive(0);
            grdUserChuaXacThuc.DataSource = lstUser;
            grdUserChuaXacThuc.DataBind();

        }

        protected void btnAddUser0_Click(object sender, EventArgs e)
        {
            DM_USER sysUser = new DM_USER();
            try
            {
                if (Session["SYSUser"] != null)
                {
                    sysUser = (DM_USER)Session["SYSUser"];
                    sysUser.XACNHAN = cbxActive0.Checked;
                    _IDM_USERService.UpdateDM_USER(sysUser);
                    LoadTKChuaXacThuc();
                    pcTTUser.ShowOnPageLoad = false;
                    Session["SYSUser"] = null;
                    if (sysUser.XACNHAN)
                        GuiMail(sysUser.USERNAME, sysUser.EMAIL);
                }
                LoadTKChuaXacThuc();

            }
            catch (Exception ex)
            {

            }


        }
        private void GuiMail(string UserName, string EMAIL)
        {
            try
            {
                string smtpAddress = "smtp.gmail.com";
                int portNumber = 587;
                bool enableSSL = true;

                string emailFrom = "anhktv@gmail.com";
                string password = "kieuthivananh";
                string emailTo = EMAIL;
                string subject = "Xác thực tài khoản phần mền quản lý vật tư thiết bị";
                string body = @"<b>Chào bạn!</b></br>Tài khoản: " + UserName + " của bạn để vào phần mềm quản lý vật tư thiết bị đã được quản trị viên kích hoạt.</br> Bạn có thể vào phần mềm theo đường link sau........ </br> Have a good time!!!";
                MailMessage mail = new MailMessage();
                mail.From = new MailAddress(emailFrom);
                mail.To.Add(emailTo);
                mail.Subject = subject;
                mail.Body = body;
                mail.IsBodyHtml = true;

                //MailMessage mail = new MailMessage();
                //SmtpClient SmtpServer = new SmtpClient("smtp.gmail.com");

                //mail.From = new MailAddress("anhktv@gmail.com");
                //mail.To.Add("hanhnt808@gmail.com");
                //mail.Subject = "Test Mail";
                //mail.Body = "This is for testing SMTP mail from GMAIL";

                //SmtpServer.Port = 587;
                //SmtpServer.Credentials = new System.Net.NetworkCredential("anhktv@gmail.com", "kieuthivananh");
                //SmtpServer.EnableSsl = true;

                using (SmtpClient smtp = new SmtpClient(smtpAddress, portNumber))
                {
                    smtp.Credentials = new NetworkCredential(emailFrom, password);
                    smtp.EnableSsl = enableSSL;
                    smtp.Send(mail);
                }
                ScriptManager.RegisterStartupScript(Page, Page.GetType(), "", "alert('Gửi mail xác thực tài khoản thành công.');", true);

            }
            catch (Exception ex)
            {
                ScriptManager.RegisterStartupScript(Page, Page.GetType(), "", "alert('Lỗi gửi mail xác thực tài khoản.');", true);
            }
        }
        protected void btnDong0_Click(object sender, EventArgs e)
        {
            // GuiMail();
            pcTTUser.ShowOnPageLoad = false;
        }

        protected void ASPxPageControl1_ActiveTabChanged(object source, TabControlEventArgs e)
        {
            if (ASPxPageControl1.ActiveTabIndex == 0)
            {
                _LoadDonVi();
                GridUser_CustomCallback(null, null);
            }
            else
                LoadTKChuaXacThuc();
            Session["SYSUser"] = null;
        }

        protected void ASPxPageControl1_ActiveTabChanging(object source, TabControlCancelEventArgs e)
        {

        }

        protected void ASPxPageControl1_TabClick(object source, TabControlCancelEventArgs e)
        {

        }

        protected void grdUserChuaXacThuc_CustomColumnDisplayText(object sender, ASPxGridViewColumnDisplayTextEventArgs e)
        {
            if (e.Column.Caption == "STT")
            {
                e.DisplayText = (e.VisibleRowIndex + 1).ToString();
            }
        }

        protected void btnResetPass_Click1(object sender, EventArgs e)
        {
            pcThongBao.ShowOnPageLoad = true;
        }

        protected void btnCo_Click(object sender, EventArgs e)
        {
            MTCSYT.SYS_Session session = (MTCSYT.SYS_Session)Session["SYS_Session"];
            if (GridUser.FocusedRowIndex > -1)
            {
                DM_USER sysUser = (DM_USER)GridUser.GetRow(GridUser.FocusedRowIndex);
                sysUser.PASSWORD = DM_USER.Encrypt("123");
                _IDM_USERService.UpdateDM_USER_PASSWORD(sysUser, session.User.MA_DVIQLY);
                pcThongBao.ShowOnPageLoad = false;
            }
            else
            {
                GridUser.FocusedRowIndex = 0;
                DM_USER sysUser = (DM_USER)GridUser.GetRow(GridUser.FocusedRowIndex);
                sysUser.PASSWORD = DM_USER.Encrypt("123");
                if (sysUser != null)
                    _IDM_USERService.UpdateDM_USER_PASSWORD(sysUser, session.User.MA_DVIQLY);
                pcThongBao.ShowOnPageLoad = false;
            }

        }

        protected void btnKhong_Click(object sender, EventArgs e)
        {
            pcThongBao.ShowOnPageLoad = false;
        }

        protected void btnAddRight_Click(object sender, EventArgs e)
        {
            pcChonChucNang.ShowOnPageLoad = true;
            LoadGrvChonChucNang();
        }
        private void LoadGrvChonChucNang()
        {
            List<SYS_Right> lstRight = new List<SYS_Right>();
            SYS_User sysUser = (SYS_User)GridUser.GetRow(GridUser.FocusedRowIndex);
            lstRight = _ISYS_RightService.GetRightsByNotUser(sysUser);
            grvChonChucNang.DataSource = lstRight;
            grvChonChucNang.DataBind();
        }

        protected void btnCommit_Click(object sender, EventArgs e)
        {
            SYS_User user = new SYS_User();
            List<SYS_Right> lst = new List<SYS_Right>();
            lst = ((SYS_User)GridUser.GetRow(GridUser.FocusedRowIndex)).Rights;
            for (int i = 0; i < lst.Count; i++)
            {
                ASPxCheckBox checkUpdate =
                    grdRightOfRoles.FindRowCellTemplateControl(i,
                                                               grdRightOfRoles.Columns["IsUpdate"] as GridViewDataColumn,
                                                               "ChkUpdate") as ASPxCheckBox;
                ASPxCheckBox checkDelete =
                    grdRightOfRoles.FindRowCellTemplateControl(i,
                                                               grdRightOfRoles.Columns["IsDelete"] as GridViewDataColumn,
                                                               "ChkDelete") as ASPxCheckBox;
                ASPxCheckBox checkCreate =
                    grdRightOfRoles.FindRowCellTemplateControl(i,
                                                               grdRightOfRoles.Columns["IsCreate"] as GridViewDataColumn,
                                                               "ChkCreate") as ASPxCheckBox;
                ASPxCheckBox checkApprove =
                    grdRightOfRoles.FindRowCellTemplateControl(i,
                                                               grdRightOfRoles.Columns["IsApprove"] as
                                                               GridViewDataColumn, "ChkApprove") as ASPxCheckBox;
                if (checkApprove != null) lst[i].IsApprove = checkApprove.Checked;
                if (checkCreate != null) lst[i].IsCreate = checkCreate.Checked;
                if (checkDelete != null) lst[i].IsDelete = checkDelete.Checked;
                if (checkUpdate != null) lst[i].IsUpdate = checkUpdate.Checked;
            }
            user.ID = (int)GridUser.GetRowValues(GridUser.FocusedRowIndex, "ID");
            user.Rights = lst;
            //_ISYS_RightService.UpdateRightsOfUser(user);
            GridUser_CustomCallback(null, null);
        }

        protected void btnDelete_Click(object sender, EventArgs e)
        {
            List<SYS_RightOfUser> lst = new List<SYS_RightOfUser>();
            SYS_RightOfUser rightOfUser = null;
            List<Object> keyvalues = grdRightOfRoles.GetSelectedFieldValues("ID");
            int UserID = (int)GridUser.GetRowValues(GridUser.FocusedRowIndex, "ID");
            foreach (Object key in keyvalues)
            {
                rightOfUser = new SYS_RightOfUser();
                rightOfUser.RightId = (int)key;
                rightOfUser.UserId = UserID;
                lst.Add(rightOfUser);
            }
            _ISYS_RightUserService.DeleteSYS_RightOfUser_ByUser(lst);
            //_DataBind();
            GridUser_CustomCallback(null, null);
            grdRightOfRoles.Selection.UnselectAll();
        }

        protected void btnThemQuyen_Click(object sender, EventArgs e)
        {
            SYS_RightOfUser rightOfUser = null;
            List<SYS_RightOfUser> sysRightOfUsers = new List<SYS_RightOfUser>();
            if (grvChonChucNang.Selection.Count == 0)
            {
                pcChonChucNang.ShowOnPageLoad = false;
                return;
            }
            List<Object> keyvalues = grvChonChucNang.GetSelectedFieldValues("ID");
            int UserID = (int)GridUser.GetRowValues(GridUser.FocusedRowIndex, "ID");
            foreach (int key in keyvalues)
            {
                rightOfUser = new SYS_RightOfUser();
                rightOfUser.Approve = true;
                rightOfUser.Create = true;
                rightOfUser.Delete = true;
                rightOfUser.Update = true;
                rightOfUser.RightId = key;
                rightOfUser.UserId = UserID;
                sysRightOfUsers.Add(rightOfUser);
            }
            _ISYS_RightUserService.InsertSYS_RightOfUser(sysRightOfUsers);
            GridUser_CustomCallback(null, null);
            grvChonChucNang.Selection.UnselectAll();
            pcChonChucNang.ShowOnPageLoad = false;
        }
        private void LoadCBXNhomQuyen()
        {
            MTCSYT.SYS_Session session = (MTCSYT.SYS_Session)Session["SYS_Session"];

            List<SYS_Roles> lstRole = new List<SYS_Roles>();
            lstRole = iRolesService.SelectListSYS_Roles();
            cbxNhomQuyen.DataSource = lstRole;
            cbxNhomQuyen.ValueField = "ID";
            cbxNhomQuyen.TextField = "Name";
            cbxNhomQuyen.DataBind();
            cbxNhomQuyen.Text = "";

        }

        protected void grdRightOfRoles_CustomCallback(object sender, ASPxGridViewCustomCallbackEventArgs e)
        {

        }
    }
}