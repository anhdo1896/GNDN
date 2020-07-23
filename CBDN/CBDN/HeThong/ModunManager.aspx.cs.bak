using System;
using System.Collections.Generic;
using DevExpress.Web.ASPxEditors;
using DevExpress.Web.ASPxGridView;
using Entity;
using SystemManageService;
using System.Web.UI;

namespace QLY_VTTB
{
    public partial class ModunManager : MTCSYT.BasePage
    {
        private const string funcid = "8";
        private SYS_Right rightOfUser = null;

        protected void Page_Load(object sender, EventArgs e)
        {
            MTCSYT.SYS_Session session = (MTCSYT.SYS_Session)Session["SYS_Session"];
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
            List<DM_MODULE> lstModun = new List<DM_MODULE>();
            List<DM_MODULE> lst = new List<DM_MODULE>();
            var sysModunService = new DM_MODULEService();
            SYS_ConfigConnectionServer configConnectionServer = new SYS_ConfigConnectionServer();
            lstModun = sysModunService.SelectAllDM_MODULE();
            foreach (DM_MODULE sysModun in lstModun)
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
            var sysModunService = new DM_MODULEService();
            var Modun = new DM_MODULE { IDMODULE = (int)e.Keys["IDMODULE"] };
            sysModunService.DeleteDM_MODULE(Modun);
            _DataBind();
            e.Cancel = true;
            //WriteLog("Delete " + Modun.Name, Action.Delete);
        }

        protected void grvPartitionManager_RowInserting(object sender, DevExpress.Web.Data.ASPxDataInsertingEventArgs e)
        {
            string strCn = e.NewValues["ConnectString"] + "";
            string code = e.NewValues["Code"] + "";
            int IDUser = 0, id_DV = 0;
            if (e.NewValues[4] != null)
            {
                IDUser = int.Parse(e.NewValues[4] + "");
            }
            if (e.NewValues[2] != null)
            {
                id_DV = int.Parse(e.NewValues[2] + "");
            }
            TestConnect(strCn, code);
            var sysPartitionService = new DM_MODULEService();
            SYS_ConfigConnectionServer configConnectionServer = new SYS_ConfigConnectionServer();
            var partition = new DM_MODULE
                                {
                                    Name = e.NewValues["Name"] + "",
                                    Code = code,
                                    IDUSER = IDUser,
                                    IDMA_DVIQLY = id_DV,
                                    ConnectString = configConnectionServer.EncryptSYS_ConfigConnection(strCn)
                                };
            sysPartitionService.InsertDM_MODULE(partition);
            _DataBind();
            e.Cancel = true;
            grvModunManager.CancelEdit();
            //WriteLog("Insert " + e.NewValues["Name"] + "", Action.Create);
        }
        private int returnIDUser(string Name)
        {
            DM_USERService serUser = new DM_USERService();
            List<DM_USER> lst = serUser.SelectAllDM_USER();
            foreach (var dtname in lst)
            {
                if (dtname.USERNAME == Name.Trim())
                    return dtname.IDUSER;
            }
            return 0;
        }
        private int returnIDMaDV(string Name)
        {
            DM_DVQLYService serUser = new DM_DVQLYService();
            List<DM_DVQLY> lst = serUser.SelectAllDM_DVQLY();
            foreach (var dtname in lst)
            {
                if (dtname.MA_DVIQLY == Name.Split('-')[0])
                    return dtname.IDMA_DVIQLY;
            }
            return 0;
        }
        protected void grvPartitionManager_RowUpdating(object sender, DevExpress.Web.Data.ASPxDataUpdatingEventArgs e)
        {
            string strCn = e.NewValues["ConnectString"] + "";
            string code = e.NewValues["Code"] + "";
            DM_MODULE sysModun = (DM_MODULE)grvModunManager.GetRow(grvModunManager.EditingRowVisibleIndex);
            int IDUser = sysModun.IDUSER;
            int idDV = sysModun.IDMA_DVIQLY;
            int testInt = 0;
            if (e.NewValues["USERNAME"] != null)
            {
                if (int.TryParse(e.NewValues["USERNAME"] + "", out testInt))
                {
                    IDUser = int.Parse(e.NewValues["USERNAME"] + "");
                }
                else
                    IDUser = returnIDUser(e.NewValues["USERNAME"] + "");
            }

            if (e.NewValues["NAME_DVIQLY"] != null)
            {
                if (int.TryParse(e.NewValues["NAME_DVIQLY"] + "", out testInt))
                {
                    idDV = int.Parse(e.NewValues["NAME_DVIQLY"] + "");
                }
                else
                    idDV = returnIDMaDV(e.NewValues["NAME_DVIQLY"] + "");
            }

            if (e.OldValues["Code"].ToString() != e.NewValues["Code"].ToString())
            {
                TestConnect(strCn, code);
            }

            SYS_ConfigConnectionServer configConnectionServer = new SYS_ConfigConnectionServer();
            var sysPartitionService = new DM_MODULEService();
            var partition = new DM_MODULE
                                {
                                    IDMODULE = (int)e.Keys["IDMODULE"],
                                    Name = e.NewValues["Name"] + "",
                                    Code = code,
                                    IDUSER = IDUser,
                                    IDMA_DVIQLY = idDV,
                                    ConnectString = configConnectionServer.EncryptSYS_ConfigConnection(strCn)
                                };
            sysPartitionService.UpdateDM_MODULE(partition);
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
            var sysModunService = new DM_MODULEService();
            List<DM_MODULE> sysModun = sysModunService.SelectAllDM_MODULE();
            for (int i = 0; i < sysModun.Count; i++)
            {
                if (Code.Trim() == sysModun[i].Code.Trim())
                {
                    throw new Exception("Mã không được trùng.");
                }

            }
            try
            {
                if (isys_configconnection.TestConnectSYS_ConfigConnection(sys_configconnection,"KoMH"))
                {
                    Session["ConnectString"] = sys_configconnection.connection;
                }
                else
                {
                    throw new Exception("Không kết nối được đến Server này.");
                }
            }
            catch (Exception)
            {
                throw new Exception("Không kết nối được đến Server này.");
            }
        }

        protected void grvModunManager_DataBinding(object sender, EventArgs e)
        {
            GridViewDataComboBoxColumn column = ((GridViewDataComboBoxColumn)(sender as ASPxGridView).Columns["Manager"]);
            DM_USERService _UserService = new DM_USERService();
            column.PropertiesComboBox.DataSource = _UserService.SelectAllSYS_User_IsActive(0);
            column.PropertiesComboBox.TextField = "USERNAME";
            column.PropertiesComboBox.ValueField = "IDUSER";

            GridViewDataComboBoxColumn columnDV = ((GridViewDataComboBoxColumn)(sender as ASPxGridView).Columns["DonVi"]);
            DM_DVQLYService _DVService = new DM_DVQLYService();
            columnDV.PropertiesComboBox.DataSource = _DVService.SelectAllDM_DVQLY();
            columnDV.PropertiesComboBox.TextField = "NAME_DVIQLY";
            columnDV.PropertiesComboBox.ValueField = "IDMA_DVIQLY";
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
