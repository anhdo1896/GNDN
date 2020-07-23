using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using SystemManageService;
using DevExpress.Web.ASPxGridView;
using Entity;

namespace MTCSYT.Content
{
    public partial class Province : BasePage
    {
        private SYS_ProvinceService isysProvinceService = new  SYS_ProvinceService();
        private const string funcid = "24";
        private SYS_Right rightOfUser;

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
            
                BindGrvProvince();
            
        }

        private void BindGrvProvince()
        {
            List<SYS_Province> lstProvince = isysProvinceService.SelectAllSYS_Province();
            grvProvince.DataSource = lstProvince;
            grvProvince.DataBind();
        }

        private bool CheckProvince(string name)
        {
            List<SYS_Province> sysProvinces = isysProvinceService.SelectAllSYS_Province();
            foreach (SYS_Province sysProvince in sysProvinces)
            {
                if (name.ToLower() == sysProvince.Name.ToLower())
                    return false;
            }
            return true;
        }

        private bool CheckProvinceCode(string code)
        {
            List<SYS_Province> sysProvinces = isysProvinceService.SelectAllSYS_Province();
            foreach (SYS_Province sysProvince in sysProvinces)
            {
                if (code.ToLower() == sysProvince.Code.ToLower())
                    return false;
            }
            return true;
        }

        protected void grvProvince_RowUpdating(object sender, DevExpress.Web.Data.ASPxDataUpdatingEventArgs e)
        {
            SYS_Province sysProvince = new SYS_Province();
            try
            {
                sysProvince.ID = (int)e.Keys["ID"];
                sysProvince.Name = e.NewValues["Name"].ToString();
                sysProvince.Code = e.NewValues["Code"].ToString();

                if(e.NewValues["Name"].ToString().ToLower()!=e.OldValues["Name"].ToString().ToLower())
                {
                    if(!CheckProvince(e.NewValues["Name"].ToString()))
                    {
                        throw new Exception("Trùng tên ! Vui lòng nhập lại");
                    }
                }
                if (e.NewValues["Code"].ToString().ToLower() != e.OldValues["Code"].ToString().ToLower())
                {
                    if (!CheckProvinceCode(e.NewValues["Code"].ToString()))
                    {
                        throw new Exception("Trùng mã ! Vui lòng nhập lại");
                    }
                }
                isysProvinceService.UpdateSYS_Province(sysProvince);
                BindGrvProvince();
                e.Cancel = true;
                grvProvince.CancelEdit();
                //WriteLog("Update " + e.NewValues["Name"], Action.Update);
            }
            catch (Exception)
            {
                throw;
            }
        }

        protected void grvProvince_RowInserting(object sender, DevExpress.Web.Data.ASPxDataInsertingEventArgs e)
        {
            SYS_Province sysProvince = new SYS_Province();
            try
            {
                if (CheckProvince(e.NewValues["Name"].ToString()) && CheckProvinceCode(e.NewValues["Code"].ToString()))
                {
                    sysProvince.Name = e.NewValues["Name"].ToString();
                    sysProvince.Code = e.NewValues["Code"].ToString();

                    isysProvinceService.InsertSYS_Province(sysProvince);
                    BindGrvProvince();
                    e.Cancel = true;
                    grvProvince.CancelEdit();
                    ////WriteLog("Insert " + e.NewValues["Name"], Action.Create);
                }
                else
                {
                    throw new Exception("Trùng tên hoặc mã ! Vui lòng nhập lại");
                }
                
            }
            catch (Exception)
            {
                throw;
            }
        }

        protected void grvProvince_RowDeleting(object sender, DevExpress.Web.Data.ASPxDataDeletingEventArgs e)
        {
            try
            {
                SYS_Province sysProvince = new SYS_Province();
                sysProvince.ID = (int)e.Keys["ID"];
                isysProvinceService.DeleteSYS_Province(sysProvince);
                BindGrvProvince();
                e.Cancel = true;
            }
            catch (Exception)
            {
                throw new Exception("Tỉnh này đã thuộc vào vùng nào đó, không thể xóa.");
            }
            
        }

        protected void btnAdd_Click(object sender, EventArgs e)
        {
            grvProvince.AddNewRow();
        }

        protected void grvProvince_HtmlCommandCellPrepared(object sender, DevExpress.Web.ASPxGridView.ASPxGridViewTableCommandCellEventArgs e)
        {
            if (e.CommandCellType == GridViewTableCommandCellType.Data)
            {
                SYS_Right right = (SYS_Right)Session["Right"];
                for (int i = 0; i < e.Cell.Controls.Count; i++)
                {
                    if (!right.IsCreate)
                    {
                        btnAdd.Visible = false;
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
    }
}