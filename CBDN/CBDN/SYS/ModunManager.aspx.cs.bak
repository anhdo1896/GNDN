using System;
using System.Collections.Generic;
using DevExpress.Web.ASPxEditors;
using DevExpress.Web.ASPxGridView;
using Entity;
using SystemManageService;
using System.Web.UI;

namespace MTCSYT
{
    public partial class ModunManager : BasePage
    {
        private SYS_Right rightOfUser = null;
        //private const string funcName = "SYS_Partition";
        private const string funcid = "21";

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
                List<SYS_Right> right = session.User.Rights;
                foreach (SYS_Right sysRight in right)
                {
                    if (sysRight.FuncId == funcid)
                    {
                        rightOfUser = sysRight;
                        Session["Right"] = rightOfUser;
                        Session["UserId"] = session.User.IDUSER;
                        Session["FunctionId"] = int.Parse(sysRight.FuncId);
                        break;
                    }
                }

                if (rightOfUser == null)
                {
                    Session["Status"] = "0";
                    Response.Redirect("~\\Content\\DefaultSYS.aspx");
                }
                _DataBind();
                session.CurrentPage = Request.AppRelativeCurrentExecutionFilePath;
            }
            Session["SYS_Session"] = session;
        }

        private void _DataBind()
        {
            List<SYS_Modun> lstModun = new List<SYS_Modun>();
            List<SYS_Modun> lst = new List<SYS_Modun>();
            var sysModunService = new SYS_ModunService();
            SYS_ConfigConnectionServer configConnectionServer = new SYS_ConfigConnectionServer();
            lstModun = sysModunService.SelectAllSYS_Modun();
            foreach (SYS_Modun sysModun in lstModun)
            {
                string temp = "";
                temp = configConnectionServer.DecryptSYS_ConfigConnection(sysModun.ConnectString);
                sysModun.ConnectString = temp;
                lst.Add(sysModun);
            }
            grvModunManager.DataSource = lst;
            grvModunManager.DataBind();

        }

        protected void Grd_CustomColumnDisplayText(object sender, ASPxGridViewColumnDisplayTextEventArgs e)
        {
            if (e.Column.Caption == "STT")
            {
                e.DisplayText = (e.VisibleRowIndex + 1).ToString();
            }
        }

        protected void grvPartitionManager_RowDeleting(object sender, DevExpress.Web.Data.ASPxDataDeletingEventArgs e)
        {
            var sysModunService = new SYS_ModunService();
            var Modun = new SYS_Modun { ID = (int)e.Keys["ID"] };
            sysModunService.DeleteSYS_Modun(Modun);
            _DataBind();
            e.Cancel = true;
            //WriteLog("Delete " + Modun.Name, Action.Delete);
        }

        protected void grvPartitionManager_RowInserting(object sender, DevExpress.Web.Data.ASPxDataInsertingEventArgs e)
        {
            string strCn = e.NewValues["ConnectString"] + "";
            string code = e.NewValues["Code"] + "";
            int IDUser = 0;
            if (e.NewValues[3] != null)
            {
                IDUser = int.Parse(e.NewValues[3] + "");
            }
            TestConnect(strCn, code);
            var sysPartitionService = new SYS_ModunService();
            SYS_ConfigConnectionServer configConnectionServer = new SYS_ConfigConnectionServer();
            var partition = new SYS_Modun
                                {
                                    Name = e.NewValues["Name"] + "",
                                    Code = code,
                                    idUser = IDUser,
                                    ConnectString = configConnectionServer.EncryptSYS_ConfigConnection(strCn)
                                };
            sysPartitionService.InsertSYS_Modun(partition);
            _DataBind();
            e.Cancel = true;
            grvModunManager.CancelEdit();
            //WriteLog("Insert " + e.NewValues["Name"] + "", Action.Create);
        }

        protected void grvPartitionManager_RowUpdating(object sender, DevExpress.Web.Data.ASPxDataUpdatingEventArgs e)
        {
            string strCn = e.NewValues["ConnectString"] + "";
            string code = e.NewValues["Code"] + "";
            SYS_Modun sysModun = (SYS_Modun)grvModunManager.GetRow(grvModunManager.EditingRowVisibleIndex);
            int IDUser = sysModun.idUser;
            if (e.NewValues["UserName"] != null)
            {
                IDUser = int.Parse(e.NewValues["UserName"] + "");
            }

            TestConnect(strCn, code);


            SYS_ConfigConnectionServer configConnectionServer = new SYS_ConfigConnectionServer();
            var sysPartitionService = new SYS_ModunService();
            var partition = new SYS_Modun
                                {
                                    ID = (int)e.Keys["ID"],
                                    Name = e.NewValues["Name"] + "",
                                    Code = code,
                                    idUser = IDUser,
                                    ConnectString = configConnectionServer.EncryptSYS_ConfigConnection(strCn)
                                };
            sysPartitionService.UpdateSYS_Modun(partition);
            _DataBind();
            e.Cancel = true;
            grvModunManager.CancelEdit();
            //WriteLog("Update " + e.NewValues["Name"] + "", Action.Update);
        }


        protected void grvPartitionManager_HtmlCommandCellPrepared(object sender, DevExpress.Web.ASPxGridView.ASPxGridViewTableCommandCellEventArgs e)
        {
            //if (e.CommandCellType == GridViewTableCommandCellType.Data)
            //{
            //    SYS_Right right = (SYS_Right)Session["Right"];
            //    for (int i = 0; i < e.Cell.Controls.Count; i++)
            //    {
            //        if (!right.IsCreate && i == 1)
            //        {
            //            btnThem.Visible = false;
            //        }
            //        if (!right.IsUpdate && i == 0)
            //        {
            //            e.Cell.Controls[0].Visible = false;
            //        }
            //        if (!right.IsDelete && i == 1)
            //        {
            //            e.Cell.Controls[1].Visible = false;
            //        }
            //    }
            //}
        }

        protected void TestConnect(string strcn, string Code)
        {
            var sys_configconnection = new SYS_ConfigConnection();
            var isys_configconnection = new SYS_ConfigConnectionServer();
            sys_configconnection.connection = strcn;
            var sysModunService = new SYS_ModunService();
            List<SYS_Modun> sysModun = sysModunService.SelectAllSYS_Modun();
            for (int i = 0; i < sysModun.Count; i++)
            {
                if (Code.Trim() == sysModun[i].Code.Trim())
                {
                    throw new Exception(GetLocalResourceObject("strErrMesageCode").ToString());
                }

            }
            try
            {
                if (isys_configconnection.TestConnectSYS_ConfigConnection(sys_configconnection, "KoMH"))
                {
                    Session["ConnectString"] = sys_configconnection.connection;
                }
                else
                {
                    throw new Exception(GetLocalResourceObject("strErrMesage").ToString());
                }
            }
            catch (Exception)
            {
                throw new Exception(GetLocalResourceObject("strErrMesage").ToString());
            }
        }

        protected void grvModunManager_DataBinding(object sender, EventArgs e)
        {
            GridViewDataComboBoxColumn column = ((GridViewDataComboBoxColumn)(sender as ASPxGridView).Columns["Manager"]);
            SYS_UserService _UserService = new SYS_UserService();
            column.PropertiesComboBox.DataSource = _UserService.SelectAllSYS_User_IsActive();
            column.PropertiesComboBox.TextField = "UserName";
            column.PropertiesComboBox.ValueField = "ID";
        }

        protected void grvModunManager_CellEditorInitialize(object sender, ASPxGridViewEditorEventArgs e)
        {
            e.Column.ToString();
            if (e.Column.FieldName == "Code")
                e.Editor.Focus();
        }

        protected void btnThem_Click(object sender, EventArgs e)
        {
            grvModunManager.AddNewRow();
        }

        protected void grvModunManager_StartRowEditing(object sender, DevExpress.Web.Data.ASPxStartRowEditingEventArgs e)
        {
            (sender as ASPxGridView).GetRowValuesByKeyValue(e.EditingKeyValue);

        }
    }
}
