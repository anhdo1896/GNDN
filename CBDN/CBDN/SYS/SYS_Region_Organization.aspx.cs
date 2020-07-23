using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using SystemManageService;
using DevExpress.Web.ASPxEditors;
using DevExpress.Web.ASPxGridView;
using Entity;

namespace MTCSYT
{
    public partial class SYS_Region_Organization : BasePage
    {
        #region Khai bao

        private DonViService _iSysDV = new DonViService();
        private SYS_Region_OrganizationService _isRegionOrganizationService = new SYS_Region_OrganizationService();
        private SYS_Right rightOfUser = null;
        //private const string FuncName = "SYS_Right";
        private const string funcid = "71";

        #endregion


        protected void Page_Load(object sender, EventArgs e)
        {
            //#region [Phân quyền]
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

            //#endregion

            _BindGrdRegion();
            grdRegionOrganization_CustomCallback(null, null);
            if (IsCallback)
            {
                BinhGrdProvince();
            }

        }

        private void _BindGrdRegion()
        {
            List<Entity.DonVi> _lstRegion = new List<Entity.DonVi>();
            try
            {
                _lstRegion = _iSysDV.SelectAllDonViByPhanLoai(6);
                grdRegion.DataSource = _lstRegion;
                grdRegion.DataBind();
            }
            catch (Exception)
            {
                throw;
            }
        }
        private bool CheckName(string name)
        {
            List<Entity.DonVi> sysregion = _iSysDV.SelectAllDonVi();
            foreach (Entity.DonVi region in sysregion)
            {
                if (name.ToLower() == region.TenDV.ToLower())
                    return false;
            }
            return true;
        }


        #region grdRegionOrganization

        protected void grdRegionOrganization_CustomCallback(object sender, DevExpress.Web.ASPxGridView.ASPxGridViewCustomCallbackEventArgs e)
        {
            if (grdRegion.FocusedRowIndex > -1)
            {
                Entity.DonVi sysDV = (Entity.DonVi)grdRegion.GetRow(grdRegion.FocusedRowIndex);
                List<Entity.DonVi> lst = _iSysDV.SYS_Region_Organization_SelectByIDIDRegion(sysDV.ID);
                grdRegionOrganization.DataSource = lst;
                grdRegionOrganization.DataBind();
            }
        }

        protected void grdRegionOrganization_RowDeleting(object sender, DevExpress.Web.Data.ASPxDataDeletingEventArgs e)
        {
            Entity.SYS_Region_Organization sysRegionProvince = new Entity.SYS_Region_Organization();
            Entity.DonVi sysRegion = new Entity.DonVi();
            sysRegion = (Entity.DonVi)grdRegion.GetRow(grdRegion.FocusedRowIndex);
            try
            {
                sysRegionProvince.ID = (int)e.Keys["ID"];
                _isRegionOrganizationService.Delete_SYS_Region_OrganizationByIDRegion(sysRegion.ID, sysRegionProvince.ID);
                grdRegionOrganization_CustomCallback(null, null);
                e.Cancel = true;
                grdRegionOrganization.CancelEdit();
            }
            catch (Exception)
            {
                throw;
            }
        }

        protected void btnAddRegionOrganization_Click(object sender, EventArgs e)
        {
            //grdRegionOrganization.AddNewRow();
            pcAddProvince.ShowOnPageLoad = true;
            BinhGrdProvince();
        }


        private void BinhGrdProvince()
        {
            Entity.DonVi sysRegion = new Entity.DonVi();
            sysRegion = (Entity.DonVi)grdRegion.GetRow(grdRegion.FocusedRowIndex);
            List<Entity.DonVi> lstProvince = _iSysDV.SelectAll_DonViByIDRegion(sysRegion.ID, 8);
            grdProvince.DataSource = lstProvince;
            grdProvince.DataBind();
        }


        #endregion

        #region cmbOrganization

        #endregion

        protected void grdRegionOrganization_CellEditorInitialize(object sender, ASPxGridViewEditorEventArgs e)
        {
            //if (e.Column.FieldName == "Name")
            //{
            //    ASPxComboBox comboBox = e.Editor as ASPxComboBox;
            //    if (comboBox != null)
            //    {
            //        List<SYS_Province> lstProvince = new List<SYS_Province>();
            //        lstProvince = isProvinceService.SelectAllSYS_Province();
            //        comboBox.DataSource = lstProvince;
            //        comboBox.ValueField = "ID";
            //        comboBox.TextField = "Name";
            //        comboBox.DataBind();
            //    }
            //}
        }



        protected void btnAddProvinces_Click(object sender, EventArgs e)
        {
            List<Object> keyvalues = new List<Object>();
            Entity.DonVi sysRegion = new Entity.DonVi();
            sysRegion = (Entity.DonVi)grdRegion.GetRow(grdRegion.FocusedRowIndex);
            keyvalues = grdProvince.GetSelectedFieldValues("ID");
            foreach (object keyvalue in keyvalues)
            {
                Entity.SYS_Region_Organization sysRegionProvince = new Entity.SYS_Region_Organization();
                sysRegionProvince.IDRegion = sysRegion.ID;
                sysRegionProvince.IDOrganization = (int)keyvalue;
                _isRegionOrganizationService.InsertSYS_Region_Organization(sysRegionProvince);
            }
            grdRegionOrganization_CustomCallback(null, null);
            Response.Redirect("SYS_Region_Organization.aspx");
        }

        protected void btnDong_Click(object sender, EventArgs e)
        {
            pcAddProvince.ShowOnPageLoad = false;
        }

    }
}