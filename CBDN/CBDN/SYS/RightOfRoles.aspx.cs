using System;
using System.Collections.Generic;
using SystemManageService;
using Entity;
using DevExpress.Web;

namespace MTCSYT
{
    public partial class RightOfRoles : BasePage
    {
        private SYS_RolesService _RolesService = new  SYS_RolesService();
        private List<SYS_Roles> _lst = new List<SYS_Roles>();

        private SYS_RightService _RightService = new  SYS_RightService();
        private List<SYS_Right> _lstRight = new List<SYS_Right>();
        private List<SYS_Right> _lstRight1 = new List<SYS_Right>();
        private SYS_Right rightOfUser;
        //private const string FuncName = "SYS_RightOfRoles";
        private const string funcid = "55";
        private SYS_LogService isys_logservice = new  SYS_LogService();
        private SYS_Log sys_log = new SYS_Log();
        private SYS_Roles roles = new SYS_Roles();
        protected void Page_Load(object sender, EventArgs e)
        {
            SYS_Session session = (SYS_Session)Session["SYS_Session"];
            session.FuncID = funcid;
            if (!IsPostBack)
            {
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
                                if (!rightOfUser.IsUpdate)
                                    btnSubmit.Enabled = false;
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
                        session.CurrentPage = Request.AppRelativeCurrentExecutionFilePath;
                    }
                }
                Session["SYS_Session"] = session;
                _DataBind();
            }
            else
            {
                grdRightOfRoles.DataSource = Session["ListRight"];
                grdRightNotRoles.DataSource = Session["ListLeft"];
            }
        }

        private void _DataBind()
        {
            _lst = _RolesService.SelectAllSYS_Roles();
            cmbRoles.DataSource = _lst;
            cmbRoles.DataBind();
            if (cmbRoles.SelectedIndex != -1)
                BindGrid();
        }

        private void BindGrid()
        {
            roles.ID = int.Parse(cmbRoles.Value.ToString());
            List<SYS_Right> _lstRight = _RightService.GetRightsByNotRole(roles);
            Session["ListLeft"] = _lstRight;
            grdRightNotRoles.DataSource = _lstRight;
            grdRightNotRoles.DataBind();

            List<SYS_Right> _lstRight1 = _RightService.GetRightsByRole(roles);
            Session["ListRight"] = _lstRight1;
            grdRightOfRoles.DataSource = _lstRight1;
            grdRightOfRoles.DataBind();

            grdRightOfRoles.ExpandAll();
        }

        protected void cmbRoles_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbRoles.SelectedIndex != -1)
                BindGrid();
        }

        protected void btnAdd_Click(object sender, EventArgs e)
        {

            _lstRight = (List<SYS_Right>)Session["ListLeft"];
            _lstRight1 = (List<SYS_Right>)Session["ListRight"];

            if (grdRightNotRoles.Selection.Count == 0) return;
            List<Object> keyvalues = grdRightNotRoles.GetSelectedFieldValues("ID");
            SYS_Right Right;
            foreach (object key in keyvalues)
            {
                Right = new SYS_Right();
                // fix
                Right.ModuleID = 1;
                Right.SysModun = _lstRight[0].SysModun;
                Right.FuncId = grdRightNotRoles.GetRowValuesByKeyValue(key, "FuncId").ToString();

                Right.FuncName = grdRightNotRoles.GetRowValuesByKeyValue(key, "FuncName").ToString();
                Right.ID = int.Parse(key.ToString());
                Right.Tag = key.ToString();
             
                Right.ModuleName = grdRightNotRoles.GetRowValuesByKeyValue(key, "ModuleName").ToString();

                //_lstRight.Remove(Right);
                for (int i = 0; i < _lstRight.Count;i++ )
                {
                    if(_lstRight[i].ID == Right.ID)
                    {
                        _lstRight.RemoveAt(i);
                    }
                }
                    Right.IsApprove = true;
                Right.IsCreate = true;
                Right.IsDelete = true;
                Right.IsUpdate = true;
                _lstRight1.Add(Right);
                //WriteLog("Insert " + Right.FuncName,Action.Create);
            }
            Session["ListLeft"] = _lstRight;
            grdRightNotRoles.DataSource = _lstRight;
            grdRightNotRoles.DataBind();
            
            Session["ListRight"] = _lstRight1;
            grdRightOfRoles.DataSource = _lstRight1;
            grdRightOfRoles.DataBind();

            grdRightOfRoles.Selection.UnselectAll();
            grdRightNotRoles.Selection.UnselectAll();
            
        }
        
        protected void btnRemove_Click(object sender, EventArgs e)
        {
            _lstRight = (List<SYS_Right>)Session["ListLeft"];
            _lstRight1 = (List<SYS_Right>)Session["ListRight"];

            if (grdRightOfRoles.Selection.Count == 0) return;
            List<Object> keyvalues = grdRightOfRoles.GetSelectedFieldValues("ID");
            SYS_Right Right;
            foreach (object key in keyvalues)
            {
                Right = new SYS_Right();
                Right.FuncId = grdRightOfRoles.GetRowValuesByKeyValue(key, "FuncId").ToString();
                Right.FuncName = grdRightOfRoles.GetRowValuesByKeyValue(key, "FuncName").ToString();
                Right.ID = int.Parse(key.ToString());
                Right.IsApprove = false;
                Right.IsCreate = false;
                Right.IsDelete = false;
                Right.IsUpdate = false;
                Right.ModuleName = grdRightOfRoles.GetRowValuesByKeyValue(key, "ModuleName").ToString();
                _lstRight.Add(Right);
                //_lstRight1.Remove(Right);
                for (int i = 0; i < _lstRight1.Count; i++)
                {
                    if (_lstRight1[i].ID == Right.ID)
                    {
                        _lstRight1.RemoveAt(i);
                    }
                }
                //WriteLog("Delete " + Right.FuncName,Action.Delete);
            }
            Session["ListLeft"] = _lstRight;
            grdRightNotRoles.DataSource = _lstRight;
            grdRightNotRoles.DataBind();

            Session["ListRight"] = _lstRight1;
            grdRightOfRoles.DataSource = _lstRight1;
            grdRightOfRoles.DataBind();

            grdRightOfRoles.Selection.UnselectAll();
            grdRightNotRoles.Selection.UnselectAll();
        }

        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            SYS_Roles roles = new SYS_Roles();
            _lstRight1 = (List<SYS_Right>)Session["ListRight"];
            for (int i = 0; i < _lstRight1.Count; i++)
            {
                ASPxCheckBox checkUpdate = grdRightOfRoles.FindRowCellTemplateControl(i, grdRightOfRoles.Columns["IsUpdate"] as GridViewDataColumn, "ChkUpdate") as ASPxCheckBox;
                ASPxCheckBox checkDelete = grdRightOfRoles.FindRowCellTemplateControl(i, grdRightOfRoles.Columns["IsDelete"] as GridViewDataColumn, "ChkDelete") as ASPxCheckBox;
                ASPxCheckBox checkCreate = grdRightOfRoles.FindRowCellTemplateControl(i, grdRightOfRoles.Columns["IsCreate"] as GridViewDataColumn, "ChkCreate") as ASPxCheckBox;
                ASPxCheckBox checkApprove = grdRightOfRoles.FindRowCellTemplateControl(i, grdRightOfRoles.Columns["IsApprove"] as GridViewDataColumn, "ChkApprove") as ASPxCheckBox;
                if (checkApprove != null) _lstRight1[i].IsApprove = checkApprove.Checked;
                if (checkCreate != null) _lstRight1[i].IsCreate = checkCreate.Checked;
                if (checkDelete != null) _lstRight1[i].IsDelete = checkDelete.Checked;
                if (checkUpdate != null) _lstRight1[i].IsUpdate = checkUpdate.Checked;
            }
            roles.ID = int.Parse(cmbRoles.Value.ToString());
            roles.Name = cmbRoles.Text;
            roles.Right = _lstRight1;
            _RightService.UpdateRightsOfRole(roles);
            //WriteLog("Submit " + cmbRoles.Text,Action.Approve);
            pcMess.ShowOnPageLoad = true;
        }

        protected void btnOK_Click(object sender, EventArgs e)
        {
            Response.Redirect("RightOfRoles.aspx");
        }
    }
}
