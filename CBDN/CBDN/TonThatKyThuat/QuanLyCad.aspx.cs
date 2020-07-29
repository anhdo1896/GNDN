using System;
using System.Collections.Generic;
using DevExpress.Web;
using Entity;
using SystemManageService;
using System.Web.UI;
using System.Linq;
using System.Data;
using MTCSYT;
using System.IO;
using System.Web.UI.HtmlControls;

namespace CBDN.TonThatKyThuat
{
    public partial class QuanLyCad : BasePage
    {
        DataAccess.clTTTT db = new DataAccess.clTTTT();
    // CBDN.DB_CBDNDataContext db = new CBDN.DB_CBDNDataContext(new CBDN.ADOController().strcn());
    private SYS_Right rightOfUser = null;
    private const string funcid = "57";
    protected void Page_Load(object sender, EventArgs e)
    {
        #region PhanQuyen
        MTCSYT.SYS_Session session = (MTCSYT.SYS_Session)Session["SYS_Session"];
        if (session == null || session.User.USERNAME == "Guest")
        {
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
        #endregion
        _DataBind();

    }

    private void _DataBind()
    {
        MTCSYT.SYS_Session session = (MTCSYT.SYS_Session)Session["SYS_Session"];
        grdDVT.DataSource = db.GET_TTTT_QUANLYCAD(session.User.ma_dviqlyDN);
        grdDVT.DataBind();
    }

    protected void grdDVT_CustomColumnDisplayText(object sender, ASPxGridViewColumnDisplayTextEventArgs e)
    {
        if (e.Column.Caption == "STT")
        {
            e.DisplayText = (e.VisibleRowIndex + 1).ToString();
        }
    }

   

    private bool CheckName(string Name)
    {
        SYS_Session session = (SYS_Session)Session["SYS_Session"];

        var dt = db.CHECK_TTTT_QUANLYCAD_MATRAM(session.User.ma_dviqlyDN, Name);
        if (dt.Rows.Count > 0)
            return false;
        return true;
    }

    protected void grdDVT_CellEditorInitialize(object sender, ASPxGridViewEditorEventArgs e)
    {
        e.Column.ToString();
        if (e.Column.FieldName == "MaChiNhanh")
            e.Editor.Focus();
    }

    protected void btnThem_Click(object sender, EventArgs e)
    {
        pcAddRoles.ShowOnPageLoad = true;
        Session["Add"] = 1;
    }

    protected void grdDVT_StartRowEditing(object sender, DevExpress.Web.Data.ASPxStartRowEditingEventArgs e)
    {
        (sender as ASPxGridView).GetRowValuesByKeyValue(e.EditingKeyValue);

    }

    protected void grdDVT_CellEditorInitialize1(object sender, ASPxGridViewEditorEventArgs e)
    {

    }

    
        public string UploadFile()
        {
            string strTenFile = fileUp.FileName;
            MTCSYT.SYS_Session session = (MTCSYT.SYS_Session)Session["SYS_Session"];
            try
            {

                if (!Directory.Exists(Server.MapPath("~/") + "TonThatKyThuat" + "/" + "LuuTruFileCAD" + "/" + session.User.ma_dviqlyDN))
                    Directory.CreateDirectory(Server.MapPath("~/") + "TonThatKyThuat" + "/" + "LuuTruFileCAD" + "/" + session.User.ma_dviqlyDN);
                if (!File.Exists(Server.MapPath("~/") + "TonThatKyThuat" + "/" + "LuuTruFileCAD" + "/" + session.User.ma_dviqlyDN + "\\" + fileUp.FileName))
                {
                    File.Delete(Server.MapPath("~/") + "TonThatKyThuat" + "/" + "LuuTruFileCAD" + "/" + session.User.ma_dviqlyDN + "\\" + fileUp.FileName);
                    fileUp.PostedFile.SaveAs(Server.MapPath("~/") + "TonThatKyThuat" + "/" + "LuuTruFileCAD" + "/" + session.User.ma_dviqlyDN + "\\" + strTenFile);
                }
                else
                {
                    fileUp.PostedFile.SaveAs(Server.MapPath("~/") + "TonThatKyThuat" + "/" + "LuuTruFileCAD" + "/" + session.User.ma_dviqlyDN + "\\" + fileUp.FileName);
                    strTenFile = fileUp.FileName;
                }
                hdTenFile.Value = strTenFile;
            }
            catch (Exception exp)
            {
                ScriptManager.RegisterStartupScript(Page, Page.GetType(), "", "alert('" + exp.Message + Server.MapPath("~/") + "LuuTruFileCAD" + "/" + session.User.ma_dviqlyDN + "\\" + hdTenFile.Value + "');", true);
            }
            return strTenFile;
        }
        protected void btnCapNhat_Click(object sender, EventArgs e)
    {
        DM_DVQLYService dm_dviSer = new DM_DVQLYService();
        SYS_Session session = (SYS_Session)Session["SYS_Session"];
            string strTenFile = fileUp.FileName;
            UploadFile();

            if (Session["Add"] + "" == "0")
        {
            var qtCT = (DataRowView)grdDVT.GetRow(grdDVT.FocusedRowIndex);

            //CBDN.DM_LoaiDay cn = db.DM_LoaiDays.SingleOrDefault(x => x.ID == qtCT.ID);
            if (!CheckName(txtMaTram.Text))
            {
                ScriptManager.RegisterStartupScript(Page, Page.GetType(), "", "alert('Mã trạm đã trùng');", true); return;
            }
            
            db.UPDATE_TTTT_QUANLYCAD_MATRAM(session.User.ma_dviqlyDN, txtMaTram.Text, strTenFile);

        }
        else
        {
            if (!CheckName(txtMaTram.Text))
            {
                ScriptManager.RegisterStartupScript(Page, Page.GetType(), "", "alert('Mã trạm đã trùng');", true); return;
            }


                db.INSERT_TTTT_QUANLYCAD(session.User.ma_dviqlyDN, txtMaTram.Text, strTenFile);

            }
        pcAddRoles.ShowOnPageLoad = false;
        _DataBind();
    }

    protected void btnDong_Click(object sender, EventArgs e)
    {
        pcAddRoles.ShowOnPageLoad = false;
    }

    protected void cmbPhongBan_SelectedIndexChanged(object sender, EventArgs e)
    {
        _DataBind();
    }

    protected void grdDVT_HtmlCommandCellPrepared(object sender, ASPxGridViewTableCommandCellEventArgs e)
    {

    }
        protected void grdDVT_RowDeleting(object sender, DevExpress.Web.Data.ASPxDataDeletingEventArgs e)
        {
            try
            {
                SYS_Session session = (SYS_Session)Session["SYS_Session"];
                var HoatDong = (DataRowView)grdDVT.GetRow(grdDVT.FocusedRowIndex);
                
                db.DELETE_TTTT_QUANLYCAD_MATRAM(session.User.ma_dviqlyDN, HoatDong["MATRAM"] + "");


                _DataBind();
                ScriptManager.RegisterStartupScript(Page, Page.GetType(), "", "alert('Xoá loại dây thành công');", true);
            }
            catch (Exception ex)
            { }
            finally
            {
                e.Cancel = true;
            }
        }
        protected void OnLinkInit(object sender, EventArgs e)
        {
            SYS_Session session = (SYS_Session)Session["SYS_Session"];
            HtmlAnchor anc = sender as HtmlAnchor;
            GridViewDataItemTemplateContainer container = anc.NamingContainer as GridViewDataItemTemplateContainer;
            anc.InnerText = container.Grid.GetRowValues(container.VisibleIndex, "DIACHI").ToString();
            anc.Attributes["href"] = "LuuTruFileCAD" + "/" + session.User.ma_dviqlyDN + "/" + anc.InnerText;
        }

    }
}