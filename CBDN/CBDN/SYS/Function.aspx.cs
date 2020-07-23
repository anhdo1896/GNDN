using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Entity;
using SystemManageService;
using DevExpress.Web.ASPxGridView;

namespace MTCSYT
{
    public partial class Function : BasePage
    {
        private SYS_RightService sys_right = new  SYS_RightService();
        private SYS_Right _dm_location = new SYS_Right();
        private List<SYS_Right> _lst = new List<SYS_Right>();
        private SYS_Right rightOfUser = null;
        //private const string FuncName = "SYS_Right";
        private const string funcid = "1";

        protected void Page_Load(object sender, EventArgs e)
        {
            SYS_Session session = (SYS_Session)Session["SYS_Session"];
            if (session == null || session.User.USERNAME == "Guest")
            {
                session.CurrentPage = Request.AppRelativeCurrentExecutionFilePath;
                Response.Redirect("~\\Login.aspx");
            }
            else
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
            Session["SYS_Session"] = session;
            _DataBind();
            
        }

        private void _DataBind()
        {
            _lst = sys_right.SelectAllSYS_Right();
            grvSys_Right.DataSource = _lst;
            grvSys_Right.DataBind();
        }

        protected void Grd_CustomColumnDisplayText(object sender, ASPxGridViewColumnDisplayTextEventArgs e)
        {
            if (e.Column.Caption == "STT")
            {
                e.DisplayText = (e.VisibleRowIndex + 1).ToString();
            }
        }

        protected void grvSys_Right_RowDeleting(object sender, DevExpress.Web.Data.ASPxDataDeletingEventArgs e)
        {
            SYS_Right objSys_right = new SYS_Right { ID = (int)e.Keys["ID"] };
            try
            {
                sys_right.DeleteSYS_Right(objSys_right);
                _DataBind();
                e.Cancel = true;
            }

            catch (Exception ex)
            {
                throw new Exception(string.Format("grvSys_Right_RowDeleting DeleteSYS_Right:"));
            }
        }
        private bool CheckName(string name)
        {
            List<SYS_Right> sysright = sys_right.SelectAllSYS_Right();
            foreach (SYS_Right right in sysright)
            {
                if (name.ToLower() == right.FuncName.ToLower())
                    return false;
            }
            return true;
        }
        private bool CheckID(string id)
        {
            List<SYS_Right> sysright = sys_right.SelectAllSYS_Right();
            foreach (SYS_Right right in sysright)
            {
                if (id.ToLower() == right.FuncId.ToLower())
                    return false;
            }
            return true;
        }
        protected void grvSys_Right_RowInserting(object sender, DevExpress.Web.Data.ASPxDataInsertingEventArgs e)
        {
            SYS_Right sysRight = new SYS_Right();

            
            try {
                //if (CheckName(e.NewValues["FuncName"].ToString()) && CheckID(e.NewValues["FuncId"].ToString()))
                if (CheckName(e.NewValues["FuncName"].ToString()))
                {
                    int lstRight = sys_right.SelectMaxFuncID();
                    int i = lstRight + 1;
                    sysRight.FuncName = e.NewValues["FuncName"].ToString();
                    sysRight.FuncId = i.ToString();
                    sysRight.Tag = i.ToString();
                    sysRight.ModuleID = (int) e.NewValues["ModuleID"];
                    sys_right.InsertSYS_Right(sysRight);
                    _DataBind();
                    e.Cancel = true;
                    grvSys_Right.CancelEdit();
                }
                else
                {
                    throw new Exception("Trùng tên ! Vui lòng nhập lại");
                }
            }
            catch (Exception ex)
            {
                throw new Exception(string.Format("Trùng tên! Vui lòng nhập lại"));
            }

            
        }

        

        protected void grvSys_Right_RowUpdating(object sender, DevExpress.Web.Data.ASPxDataUpdatingEventArgs e)
        {
            SYS_Right sysRight = new SYS_Right();
            try {
                sysRight.ID = (int)e.Keys["ID"];
                sysRight.FuncName = e.NewValues["FuncName"].ToString();
                SYS_Right right = sys_right.SelectSYS_Right(sysRight.ID);
                sysRight.FuncId = right.FuncId;
                sysRight.ModuleID = (int)e.NewValues["ModuleID"];
                if (e.NewValues["FuncName"].ToString().ToLower() != e.OldValues["FuncName"].ToString().ToLower())
                {
                    if (!CheckName(e.NewValues["FuncName"].ToString()))
                    {
                        throw new Exception("Trùng tên ! Vui lòng nhập lại");
                    }
                }
                //if (e.NewValues["FuncId"].ToString().ToLower() != e.OldValues["FuncId"].ToString().ToLower())
                //{
                //    if (!CheckID(e.NewValues["FuncId"].ToString()))
                //    {
                //        throw new Exception("Trùng mã ! Vui lòng nhập lại");
                //    }
                //}
                sys_right.UpdateSYS_Right(sysRight);
                _DataBind();
                e.Cancel = true;
                grvSys_Right.CancelEdit();
            }
            catch (Exception ex)
            {
                throw new Exception(string.Format("Trùng tên vui lòng nhập lại."));
            }
            
            
        }

        protected void grvSys_Right_DataBinding(object sender, EventArgs e)
        {
            GridViewDataComboBoxColumn columnModule = ((GridViewDataComboBoxColumn)(sender as ASPxGridView).Columns["Module"]);
            var _sys_module = new SYS_ModunService();
            List<Entity.SYS_Modun> _lstModun = new List<Entity.SYS_Modun>();
            try
            {
                _lstModun = _sys_module.SelectAllSYS_Modun();
                columnModule.PropertiesComboBox.DataSource = _lstModun;
                columnModule.PropertiesComboBox.TextField = "Name";
                columnModule.PropertiesComboBox.ValueField = "ID";
            }
            catch (Exception ex)
            {
                throw new Exception(string.Format("grvSys_Right_DataBinding Error"));
            }
            
           
        }

        

        protected void grvSys_Right_HtmlCommandCellPrepared(object sender, ASPxGridViewTableCommandCellEventArgs e)
        {
            //if (e.CommandCellType == GridViewTableCommandCellType.Data)
            //{
            //    SYS_Right right = (SYS_Right)Session["Right"];
            //    for (int i = 0; i < e.Cell.Controls.Count; i++)
            //    {
            //        if (!right.IsCreate)
            //        {
            //            btnAdd.Enabled = false;
            //        }
            //        if (!right.IsUpdate)
            //        {
            //            e.Cell.Controls[0].Visible = false;
            //        }
            //        if (!right.IsDelete)
            //        {
            //            e.Cell.Controls[1].Visible = false;
            //        }
            //    }
            //}
        }

        protected void btnAdd_Click(object sender, EventArgs e)
        {
            grvSys_Right.AddNewRow();
        }

        protected void grvSys_Right_CellEditorInitialize(object sender, ASPxGridViewEditorEventArgs e)
        {
            if (e.Column.FieldName == "FuncName")
                e.Editor.Focus();
        }

        


    }
}