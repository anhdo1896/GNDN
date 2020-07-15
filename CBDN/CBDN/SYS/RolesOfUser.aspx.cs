using System;
using System.Collections.Generic;
using SystemManageService;
using Entity;

namespace MTCSYT
{
    public partial class RolesOfUser : BasePage
    {
        private SYS_RolesService _rolesService = new  SYS_RolesService();
        private List<Entity.SYS_Roles> _lst = new List<Entity.SYS_Roles>();

        private SYS_UserService _sysUserService = new  SYS_UserService();
        private List<Entity.SYS_User> _lstUser = new List<Entity.SYS_User>();
        private List<Entity.SYS_User> _lstUser1 = new List<Entity.SYS_User>();
        private SYS_Right rightOfUser = null;
        //private const string FuncName = "SYS_RoleOfUser";
        private const string funcid = "27";
        private SYS_RoleOfUserService _sysRoleOfUserService = new  SYS_RoleOfUserService();
        private SYS_LogService isys_logservice = new  SYS_LogService();
        private SYS_Log sys_log = new SYS_Log();

        private SYS_Roles _SYS_Roles = new SYS_Roles();

        
        protected void Page_Load(object sender, EventArgs e)
        {
            SYS_Session session = (SYS_Session)Session["SYS_Session"];
            session.FuncID = funcid;
            if (session == null || session.User.USERNAME == "Guest")
            {
                session.CurrentPage = Request.AppRelativeCurrentExecutionFilePath;
                Response.Redirect("~\\Login.aspx");
            }
            else
            {
                if (Request.Cookies["IDUSER"].Value != "1")
                {
                    List<SYS_Right> right = session.User.Rights;
                    foreach (SYS_Right sysRight in right)
                    {
                        if (sysRight.FuncId == funcid)
                        {
                            rightOfUser = sysRight;
                            if (!rightOfUser.IsCreate)
                                btnAdd.Enabled = false;
                            if (!rightOfUser.IsDelete)
                                btnRemove.Enabled = false;
                            Session["UserId"] = session.User.IDUSER;
                            Session["FunctionId"] = sysRight.FuncId;

                            break;
                        }
                    }

                    if (rightOfUser == null)
                    {
                        Session["Status"] = "0";
                        Response.Redirect("~\\SYS\\DefaultSYS.aspx");

                    }
                }
            }
            Session["SYS_Session"] = session;
            _DataBind();
        }

        private void _DataBind()
        {
            _lst = _rolesService.SelectAllSYS_Roles();
            cmbRoles.DataSource = _lst;
            cmbRoles.DataBind();
            if (cmbRoles.SelectedIndex != -1)
                BindGrid();
        }

        private void BindGrid()
        {   
            _lstUser = _sysUserService.SelectAllSYS_User_NotofRoles(int.Parse(cmbRoles.Value.ToString()));
            grdUserNotRoles.DataSource = _lstUser;
            grdUserNotRoles.DataBind();

            _lstUser1 = _sysUserService.SelectAllSYS_User_ofRoles(int.Parse(cmbRoles.Value.ToString()));
            grdUserOfRoles.DataSource = _lstUser1;
            grdUserOfRoles.DataBind();
        }


        protected void cmbRoles_SelectedIndexChanged(object sender, EventArgs e)
        {
            BindGrid();
        }

        protected void btnAdd_Click(object sender, EventArgs e)
        {
            if (grdUserNotRoles.Selection.Count == 0) return;
            if(grdUserNotRoles.Selection.Count ==0) return;
            SYS_RoleOfUser roleOfUser;
            List<Object> keyvalues = grdUserNotRoles.GetSelectedFieldValues("ID");
           
            foreach (object key in keyvalues)
            {
                roleOfUser = new SYS_RoleOfUser();
                roleOfUser.RoleId = int.Parse(cmbRoles.Value.ToString());
                roleOfUser.UserId = int.Parse(key.ToString());
                _sysRoleOfUserService.InsertSYS_RoleOfUser(roleOfUser);
                _SYS_Roles.Name = grdUserNotRoles.GetRowValuesByKeyValue(key, "UserName").ToString();
                //WriteLog("Insert " + _SYS_Roles.Name,Action.Create);
            }
            BindGrid();
            grdUserOfRoles.Selection.UnselectAll();
            grdUserNotRoles.Selection.UnselectAll();
        }

        protected void btnRemove_Click(object sender, EventArgs e)
        {
            if (grdUserOfRoles.Selection.Count == 0) return;
            List<Object> keyvalues = grdUserOfRoles.GetSelectedFieldValues("ID");
            foreach (object key in keyvalues)
            {
                 _rolesService.DeleteRoleOfUser(int.Parse(key.ToString()), int.Parse(cmbRoles.Value.ToString()));

                 _SYS_Roles.Name = grdUserOfRoles.GetRowValuesByKeyValue(key, "UserName").ToString();
                 //WriteLog("Delete " + _SYS_Roles.Name,Action.Delete);
            }
            BindGrid();
            grdUserOfRoles.Selection.UnselectAll();
            grdUserNotRoles.Selection.UnselectAll();
        }
    }
}
