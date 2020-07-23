using System;
using System.Collections.Generic;
using SystemManageService;
using DevExpress.Web.ASPxTreeList;
using Entity;
using System.Linq;
using System.Web.UI;
namespace QLY_VTTB
{
    public partial class Organization : MTCSYT.BasePage
    {
        private const string funcid = "66";
        private SYS_Right rightOfUser = null;
        private DM_DVQLYService _DM_DVQLY = new DM_DVQLYService();
        private List<Entity.DM_DVQLY> _lst = new List<Entity.DM_DVQLY>();

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
                //if (Request.Cookies["IDUSER"].Value != "1")
                //{
                //    List<SYS_Right> right = session.User.Rights;
                //    foreach (SYS_Right sysRight in right)
                //    {
                //        if (sysRight.FuncId == funcid)
                //        {
                //            rightOfUser = sysRight;
                //            Session["Right"] = sysRight;
                //            Session["UserId"] = session.User.IDUSER;
                //            Session["FunctionId"] = sysRight.FuncId;
                //            break;
                //        }
                //    }

                //    if (rightOfUser == null)
                //    {
                //        Session["Status"] = "0";
                //        Response.Redirect("~\\HeThong\\Default.aspx");

                //    }
                //}
            }
            Session["SYS_Session"] = session;
            _DataBind();
            SetVisiableControl(true);
            if (!IsPostBack)
            {
                LoadData();
            }


        }


        private void SetVisiableControl(bool flag)
        {
            txtNameOrganization.ReadOnly = flag;
            cmbChoseParent.ReadOnly = flag;
            txtTenDV.ReadOnly = flag;
        }

        private List<DM_DVQLY> GetList()
        {
            List<DM_DVQLY> lstOrganizationParent = (List<DM_DVQLY>)TreeListOrganization.DataSource;
            List<DM_DVQLY> lstOrganization = new List<DM_DVQLY>();
            lstOrganization.Add((DM_DVQLY)TreeListOrganization.FocusedNode.DataItem);
            GetAllChildNode(TreeListOrganization.FocusedNode.ChildNodes, ref lstOrganization);
            for (int i = 0; i < lstOrganization.Count; i++)
            {
                lstOrganizationParent.Remove(lstOrganization[i]);
            }
            return lstOrganizationParent;
        }

        private void GetAllChildNode(TreeListNodeCollection ChildList, ref List<DM_DVQLY> lstOrganization)
        {
            for (int i = 0; i < ChildList.Count; i++)
            {
                lstOrganization.Add((DM_DVQLY)ChildList[i].DataItem);
                if (ChildList[i].HasChildren)
                {
                    GetAllChildNode(ChildList[i].ChildNodes, ref lstOrganization);
                }
            }
        }
        private void _DataBind()
        {
            MTCSYT.SYS_Session session = (MTCSYT.SYS_Session)Session["SYS_Session"];
            string strMadviqly = session.User.ma_dviqlyDN;

            List<DM_DVQLY> _lstNew = new List<DM_DVQLY>();
            _lstNew = _DM_DVQLY.DM_DVQLYandLEVER_BYDV(strMadviqly);

            TreeListOrganization.DataSource = _lstNew;
            TreeListOrganization.DataBind();
            TreeListOrganization.ExpandToLevel(1);

        }

        private void FindChild(List<DM_DVQLY> _lst, int ID, ref  List<Entity.DM_DVQLY> _lstNew)
        {
            foreach (DM_DVQLY sysOrganization in _lst.Where(x => x.ParentId == ID))
            {
                _lstNew.Add(sysOrganization);
                FindChild(_lst, sysOrganization.IDMA_DVIQLY, ref _lstNew);
            }
        }
        private bool CheckOrganization(string name)
        {
            List<DM_DVQLY> sysOrganizations = _DM_DVQLY.SelectAllDM_DVQLY();
            foreach (DM_DVQLY Organization in sysOrganizations)
            {
                if (name.ToLower() == Organization.MA_DVIQLY.ToLower())
                    return false;
            }
            return true;
        }



        protected void TreeListOrganization_NodeDeleting(object sender, DevExpress.Web.Data.ASPxDataDeletingEventArgs e)
        {
            try
            {
                var key = (int)e.Keys[0];
                var trl = new DM_DVQLY { IDMA_DVIQLY = key };
                _DM_DVQLY.DeleteDM_DVQLY(trl);
            }
            catch (Exception)
            {

                throw new Exception("Dữ liệu này không thể xóa!");
            }
            _DataBind();
            e.Cancel = true;
        }
        protected void btnAdd_Click(object sender, EventArgs e)
        {
            btnAdd.Visible = false;
            btnBack.Visible = true;
            TreeListOrganization.Columns["btnDelete"].Visible = false;
            SetVisiableControl(false);
            btnCapNhat.Enabled = true;
            txtNameOrganization.Text = "";
            txtTenDV.Text = "";
            txtTenVietTat.Text = "";
            Session["Organization"] = null;
            LoadCMBChooseParent(0);
            TreeListOrganization.SettingsBehavior.AllowFocusedNode = false;
            btnEdit.Visible = false;
            txtNameOrganization.Focus();
        }
        private int IndexOfTreelist(string value)
        {
            int Result = 0;
            for (int i = 0; i < _lst.Count; i++)
            {
                if (value == _lst[i].IDMA_DVIQLY.ToString())
                {
                    Result = i;
                    break;
                }
            }
            return Result;
        }


        protected void btnEdit_Click(object sender, EventArgs e)
        {
            btnEdit.Visible = false;
            btnBack.Visible = true;
            TreeListOrganization.Columns["btnDelete"].Visible = false;
            btnCapNhat.Enabled = true;
            btnAdd.Visible = false;
            txtNameOrganization.Focus();

            SetVisiableControl(false);
            TreeListOrganization.SettingsBehavior.AllowFocusedNode = false;
            lblCurrentEdit.Visible = true;
            lblCurrentEdit.Text = "Bạn đang sửa thông tin của: " + txtNameOrganization.Text;
            LoadCMBChooseParent(0);
            LoadData();
        }

        private void LoadCMBChooseParent(int ParentId)
        {
            //cmbChoseParent.DataSource = TreeListOrganization.DataSource;
            //cmbChoseParent.ValueField = "IDMA_DVIQLY";
            //cmbChoseParent.TextField = "NAME_DVIQLY";
            //cmbChoseParent.DataBind();
            MTCSYT.SYS_Session session = (MTCSYT.SYS_Session)Session["SYS_Session"];
            DM_DVQLYService dm_dviSer = new DM_DVQLYService();
            //List<DM_DVQLY> lst_dmdv = new List<DM_DVQLY>();
            var lst_dmdv = dm_dviSer.SelectAll_DVI_ByChild(int.Parse(session.User.ma_dviqly));
            cmbChoseParent.DataSource = lst_dmdv;
            cmbChoseParent.ValueField = "IDMA_DVIQLY";
            cmbChoseParent.TextField = "NAME_DVIQLY";
            cmbChoseParent.DataBind();
            //if (ParentId == 0)
            //    cmbChoseParent.SelectedIndex = IndexOf(int.Parse(TreeListOrganization.FocusedNode.Key),
            //                                    (List<Entity.DM_DVQLY>)TreeListOrganization.DataSource);
            //else
            //    cmbChoseParent.SelectedIndex = IndexOf(ParentId, (List<Entity.DM_DVQLY>)TreeListOrganization.DataSource);
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
        private void LoadData()
        {
            DM_DVQLYService isyOrganizationService = new DM_DVQLYService();
            Entity.DM_DVQLY sysOrganization = new Entity.DM_DVQLY();

            if (TreeListOrganization.FocusedNode != null)
            {
                var parentNode = TreeListOrganization.FocusedNode;
                //cmbChoseParent.SelectedIndex = IndexOfTreelist(parentNode.ParentNode.Key);
                int IDOrganization = int.Parse(TreeListOrganization.FocusedNode.Key.ToString());

                sysOrganization = isyOrganizationService.SelectDM_DVQLY(int.Parse(TreeListOrganization.FocusedNode.Key));
                txtNameOrganization.Text = sysOrganization.MA_DVIQLY;
                txtTenDV.Text = sysOrganization.TEN_DVIQLY;
                txtTenVietTat.Text = sysOrganization.TenVietTat;

                LoadCMBChooseParent(sysOrganization.ParentId);
                //cmbChoseParent.Value = sysOrganization.ParentId;
                Session["Organization"] = sysOrganization;
            }

        }



        protected void TreeListOrganization_CustomDataCallback(object sender, DevExpress.Web.ASPxTreeList.TreeListCustomDataCallbackEventArgs e)
        {
            DM_DVQLYService isyOrganizationService = new DM_DVQLYService();
            Entity.DM_DVQLY sysOrganization = new Entity.DM_DVQLY();

            string key = e.Argument.ToString();
            TreeListNode node = TreeListOrganization.FindNodeByKeyValue(key);
            string[] result = new string[4];
            //result[0] = node["MA_DVIQLY"].ToString();
            result[0] = node["TEN_DVIQLY"].ToString();
            result[1] = node["MA_DVIQLY"].ToString();
            result[2] = node["ParentId"].ToString();
            result[3] = node["TenVietTat"].ToString();
            e.Result = result;
            LoadData();
        }



        protected void btnCapNhat_Click(object sender, EventArgs e)
        {
            btnBack.Visible = false;
            btnAdd.Visible = true;
            btnEdit.Visible = true;
            btnCapNhat.Enabled = false;
            lblCurrentEdit.Visible = false;
            TreeListOrganization.Columns["btnDelete"].Visible = true;
            TreeListOrganization.SettingsBehavior.AllowFocusedNode = true;

            DM_DVQLY objOrganization = new DM_DVQLY();
            objOrganization.MA_DVIQLY = txtNameOrganization.Text;
            objOrganization.TEN_DVIQLY = txtTenDV.Text;
            objOrganization.TenVietTat = txtTenVietTat.Text;
            var parentNode = TreeListOrganization.FocusedNode;
            if (cmbChoseParent.Value == null)
                objOrganization.ParentId = 0;
            else if (cmbChoseParent.Value != "-1")
                objOrganization.ParentId = int.Parse(cmbChoseParent.Value + "");



            if (Session["Organization"] != null)
            {
                DM_DVQLY sysOrganization = (DM_DVQLY)Session["Organization"];
                //objOrganization.ParentID = sysOrganization.ParentId;
                objOrganization.IDMA_DVIQLY = sysOrganization.IDMA_DVIQLY;
                if (cmbChoseParent.Value == null)
                    objOrganization.ParentId = 0;
                else if (cmbChoseParent.Value != "-1")
                    objOrganization.ParentId = int.Parse(cmbChoseParent.Value + "");
                if (sysOrganization.MA_DVIQLY != txtNameOrganization.Text)
                {
                    if (!CheckOrganization(txtNameOrganization.Text))
                    {
                        lblError.Text = "Tên đơn vị này đã tồn tại.Mời bạn nhập tên khác !!";
                        SetVisiableControl(false);
                        btnCapNhat.Enabled = true;
                        return;
                    }
                }
                _DM_DVQLY.UpdateDM_DVQLY(objOrganization);
                Session["Organization"] = null;
                //WriteLog("Update " + txtName.Text, Action.Update);

            }
            else
            {
                if (CheckOrganization(txtNameOrganization.Text))
                {
                    //objOrganization.ParentID = int.Parse(TreeListOrganization.FocusedNode.Key); 
                    _DM_DVQLY.InsertDM_DVQLY(objOrganization);
                    //WriteLog("Insert " + txtName.Text, Action.Create);
                }
                else
                {
                    lblError.Text = "Tên đơn vị này đã tồn tại.Mời bạn nhập tên khác !!";
                    SetVisiableControl(false);
                    btnCapNhat.Enabled = true;
                    return;
                }
            }
            _DataBind();
        }

        protected void btnBack_Click(object sender, EventArgs e)
        {
            Response.Redirect("~\\DanhMuc\\Organization.aspx");
        }

        protected void TreeListOrganization_HtmlCommandCellPrepared(object sender, TreeListHtmlCommandCellEventArgs e)
        {

        }
    }
}
