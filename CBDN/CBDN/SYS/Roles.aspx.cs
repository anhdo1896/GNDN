using System;
using System.Collections.Generic;
using SystemManageService;
using DevExpress.Web.ASPxGridView;
using Entity;
using System.Web.UI;
namespace MTCSYT
{
    public partial class Roles : BasePage
    {

        private SYS_RolesService _ISYS_RolesService = new SYS_RolesService();
        private DM_DVQLYService iDonVi = new DM_DVQLYService();
        private List<Entity.SYS_Roles> _lst = new List<Entity.SYS_Roles>();
        private SYS_Right rightOfUser = null;
        private const string funcid = "54";
        private SYS_LogService isys_logservice = new SYS_LogService();
        private SYS_Log sys_log = new SYS_Log();
        private SYS_RoleOfUserService isyRoleOfUserService = new SYS_RoleOfUserService();

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
                            Session["Right"] = sysRight;
                            Session["UserId"] = session.User.IDUSER;
                            Session["FunctionId"] = sysRight.FuncId;
                            break;
                        }
                    }

                    if (rightOfUser == null)
                    {
                        Session["Status"] = "0";
                        Response.Redirect("~\\HeThong\\Default.aspx");

                    }
                }
            }
            Session["SYS_Session"] = session;
            _DataBind();
        }

        private void _DataBind()
        {
            _lst = _ISYS_RolesService.SelectAllSYS_Roles();
            Grd.DataSource = _lst;
            Grd.DataBind();
        }

        protected void Grd_CustomColumnDisplayText(object sender, ASPxGridViewColumnDisplayTextEventArgs e)
        {
            if (e.Column.Caption == "STT")
            {
                e.DisplayText = (e.VisibleRowIndex + 1).ToString();
            }
        }

        protected void Grd_RowDeleting(object sender, DevExpress.Web.Data.ASPxDataDeletingEventArgs e)
        {
            SYS_Roles roles = new SYS_Roles();
            roles.ID = (int)e.Keys["ID"];
            try
            {
                _ISYS_RolesService.DeleteSYS_Roles(roles);
            }
            catch (Exception)
            {
                throw new Exception("Nhóm quyền này đang được sử dụng! Bạn không có quyền xóa.");
            }

            _DataBind();
            e.Cancel = true;
            //WriteLog("Delete " + e.Values[0],Action.Delete);
        }

        protected void Grd_RowInserting(object sender, DevExpress.Web.Data.ASPxDataInsertingEventArgs e)
        {
            SYS_RoleOfUser sysRoleOfUser = new SYS_RoleOfUser();
            SYS_Roles roles = new SYS_Roles();
            roles.Name = e.NewValues["Name"] + "";
            roles.IDOrganization = int.Parse(e.NewValues["IDOrganization"] + "");
            if (CheckRole(roles.Name))
            {
                throw new Exception(string.Format("Trùng tên đơn vị! Vui lòng chọn lại."));
            }
            try
            {
                if (CheckRole(roles.Name) == false)
                {
                    int RoleID = _ISYS_RolesService.InsertSYS_Roles(roles);
                    //sysRoleOfUser.RoleId = RoleID;
                    //sysRoleOfUser.UserId = (int)Session["UserId"];
                    //isyRoleOfUserService.InsertSYS_RoleOfUser(sysRoleOfUser);
                    _DataBind();
                    e.Cancel = true;
                    Grd.CancelEdit();
                    //WriteLog("Insert " + e.NewValues["Name"], Action.Create);
                }
                else
                {
                    throw new Exception(string.Format("Trùng tên! Vui lòng nhập lại."));
                }

            }
            catch (Exception)
            {
                throw new Exception("Trùng tên! Vui lòng nhập lại.");
            }

        }

        protected bool CheckIDOrganization(int IDOrganization)
        {
            List<SYS_Roles> roles = _ISYS_RolesService.SelectAllSYS_Roles();
            foreach (SYS_Roles sysRolese in roles)
            {
                if (IDOrganization == sysRolese.IDOrganization) return true;
            }
            return false;
        }

        protected bool CheckRole(string name)
        {
            List<SYS_Roles> roles = _ISYS_RolesService.SelectAllSYS_Roles();
            foreach (SYS_Roles sysRolese in roles)
            {
                if (String.Compare(name, sysRolese.Name, true) == 0) return true;
            }
            return false;
        }

        protected void Grd_RowUpdating(object sender, DevExpress.Web.Data.ASPxDataUpdatingEventArgs e)
        {
            Entity.SYS_Roles roles = new Entity.SYS_Roles();
            roles.ID = (int)e.Keys["ID"];
            roles.Name = e.NewValues["Name"] + "";
            roles.IDOrganization = int.Parse(e.NewValues["IDOrganization"] + "");
            if ((int)e.NewValues["IDOrganization"] != (int)e.OldValues["IDOrganization"])
            {
                if (CheckIDOrganization(roles.IDOrganization))
                {
                    throw new Exception(string.Format("Trùng tên đơn vị! Vui lòng chọn lại."));
                }
            }

            if (e.OldValues["Name"] + "" != e.NewValues["Name"] + "")
            {
                if (CheckRole(roles.Name))
                {
                    throw new Exception(string.Format("Trùng tên nhóm quyền! Vui lòng nhập lại."));
                }
            }

            _ISYS_RolesService.UpdateSYS_Roles(roles);
            _DataBind();
            e.Cancel = true;
            Grd.CancelEdit();
            //WriteLog("Update " + e.NewValues["Name"],Action.Update);
        }

        protected void Grd_HtmlCommandCellPrepared(object sender, DevExpress.Web.ASPxGridView.ASPxGridViewTableCommandCellEventArgs e)
        {
            if (e.CommandCellType == GridViewTableCommandCellType.Data)
            {
                SYS_Right right = (SYS_Right)Session["Right"];
                if (right == null)
                    return;
                for (int i = 0; i < e.Cell.Controls.Count; i++)
                {
                    if (!right.IsCreate)
                    {
                        btnThem.Visible = false;
                        //e.Cell.Controls[1].Visible = false;
                    }
                    if (!right.IsUpdate)
                    {
                        e.Cell.Controls[0].Visible = false;
                    }
                    if (!right.IsDelete)
                    {
                        e.Cell.Controls[1].Visible = false;
                    }
                }
            }
        }

        protected void btnThem_Click(object sender, EventArgs e)
        {
            Grd.AddNewRow();
            //cmbOrganization.TextField = "";
            //pcAddRoles.ShowOnPageLoad = true;
            //BindCMBOrganization();
        }

        private void BindCMBOrganization()
        {
            List<Entity.DM_DVQLY> lstOrganization = new List<Entity.DM_DVQLY>();
            lstOrganization = iDonVi.SelectAllDM_DVQLY();
            cmbOrganization.DataSource = lstOrganization;
            cmbOrganization.ValueField = "IDMA_DVIQLY";
            cmbOrganization.TextField = "NAME_DVIQLY";
            cmbOrganization.DataBind();
        }

        protected void Grd_CellEditorInitialize(object sender, DevExpress.Web.ASPxGridView.ASPxGridViewEditorEventArgs e)
        {
            if (e.Column.FieldName == "NAME_DVIQLY")
                e.Editor.Focus();
        }

        protected void Grd_DataBinding(object sender, EventArgs e)
        {
            GridViewDataComboBoxColumn columnIDOrganization = ((GridViewDataComboBoxColumn)(sender as ASPxGridView).Columns["IDOrganization"]);
            //GridViewDataComboBoxColumn columnIDOrganization = ((GridViewDataComboBoxColumn)(sender as ASPxGridView).Columns["IDMA_DVIQLY"]);
            List<Entity.DM_DVQLY> _lstOrganization = new List<Entity.DM_DVQLY>();
            try
            {
                //_lstOrganization = isOrganizationService.SelectAllSYS_OrganizationByNotSYS_Roles();
                _lstOrganization = iDonVi.SelectAllDM_DVQLY();
                columnIDOrganization.PropertiesComboBox.DataSource = _lstOrganization;
                columnIDOrganization.PropertiesComboBox.TextField = "NAME_DVIQLY";
                columnIDOrganization.PropertiesComboBox.ValueField = "IDMA_DVIQLY";
            }
            catch (Exception ex)
            {
                throw new Exception(string.Format("grvSys_Roles_DataBinding Error"));
            }
        }

        protected void btnAddRoles_Click(object sender, EventArgs e)
        {
            SYS_RoleOfUser sysRoleOfUser = new SYS_RoleOfUser();
            SYS_Roles roles = new SYS_Roles();
            roles.Name = txtTenNhomQuyen.Text;
            roles.IDOrganization = int.Parse(cmbOrganization.Value.ToString());
            if (CheckIDOrganization(roles.IDOrganization))
            {
                throw new Exception(string.Format("Trùng tên đơn vị! Vui lòng chọn lại."));
            }
            try
            {
                if (CheckRole(roles.Name) == false)
                {
                    int RoleID = _ISYS_RolesService.InsertSYS_Roles(roles);
                    //sysRoleOfUser.RoleId = RoleID;
                    //sysRoleOfUser.UserId = (int)Session["UserId"];
                    //isyRoleOfUserService.InsertSYS_RoleOfUser(sysRoleOfUser);
                    _DataBind();
                    pcAddRoles.ShowOnPageLoad = false;
                    //WriteLog("Insert " + txtTenNhomQuyen.Text, Action.Create);
                }
                else
                {
                    throw new Exception(string.Format("Trùng tên! Vui lòng nhập lại."));
                }

            }
            catch (Exception)
            {
                throw new Exception("Trùng tên! Vui lòng nhập lại.");
            }
        }

        protected void btnEdit_Click(object sender, EventArgs e)
        {

            pcAddRoles.ShowOnPageLoad = true;

            BindCMBOrganization();
            if (Grd.FocusedRowIndex > -1)
            {
                SYS_Roles sysRoles = (SYS_Roles)Grd.GetRow(Grd.FocusedRowIndex);
                txtTenNhomQuyen.Text = sysRoles.Name;
                cmbOrganization.SelectedIndex = sysRoles.IDOrganization;

                //txtUserName.Text = sysUser.UserName;
                //txtPhone.Text = sysUser.NumberPhone;
                //txtPassword.Text = sysUser.Password;
                //txtMidName.Text = sysUser.MidName;
                //txtLastName.Text = sysUser.LastName;
                //txtFistName.Text = sysUser.FirstName;
                //txtEmail.Text = sysUser.Email;
                //cbxNhomQuyen.Text = sysUser.RoleGroup;
                //cbxActive.Checked = sysUser.IsActive;
                //Session["SYSUser"] = sysUser;
                //pcAddUser.ShowOnPageLoad = true;

            }
            //LoadCBXNhomQuyen();
        }



    }
}
