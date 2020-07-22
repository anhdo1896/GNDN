using System;
using System.Collections;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Xml.Linq;
using SystemManageService;
using DevExpress.Web;
using Entity;

namespace MTCSYT
{
    public partial class Log : BasePage
    {
        private SYS_LogService _ISYS_LogService = new  SYS_LogService();
        private List<SYS_Log> _lst = new List<SYS_Log>();
        //private const string FuncName = "SYS_Log";
        private const string funcid = "7";
        private SYS_Right rightOfUser = null;
       

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
            _DataBind();
        }

        protected void _DataBind()
        {
            SYS_Session session = (SYS_Session)Session["SYS_Session"];
            //session.FuncID = funcid;
            int UserID = 0;
            if(Request["UID"]+""!="")
            {
                UserID = int.Parse(Request["UID"]);
            }
            _lst = _ISYS_LogService.SelectSYSLogByIDBC(session.IDDMDonVi);
            GrdLog.DataSource = _lst;
            GrdLog.DataBind();
        }

        protected void Grd_RowDeleting(object sender, DevExpress.Web.Data.ASPxDataDeletingEventArgs e)
        {
            var log = new Entity.SYS_Log { ID = (int)e.Keys["ID"] };
            _ISYS_LogService.DeleteSYS_Log(log);
            _DataBind();
            e.Cancel = true;
            
        }

        protected void GrdLog_HtmlCommandCellPrepared(object sender, DevExpress.Web.ASPxGridViewTableCommandCellEventArgs e)
        {
            if (e.CommandCellType == DevExpress.Web.GridViewTableCommandCellType.Data)
            {
                SYS_Right right = (SYS_Right)Session["Right"];
                if(right!=null)
                {
                    for (int i = 0; i < e.Cell.Controls.Count; i++)
                    {
                        if (!right.IsDelete && i == 0)
                        {
                            btnDeleteLog.Visible = false;
                            e.Cell.Controls[0].Visible = false;
                        }
                    }
                    // Edit =0; New = 1;Delete =2
                }
                

            }
        }

        protected void GrdLog_CellEditorInitialize(object sender, DevExpress.Web.ASPxGridViewEditorEventArgs e)
        {
            if (e.Column.FieldName == "Username")
                e.Editor.Focus();
        }

        protected void Grd_CustomColumnDisplayText(object sender, ASPxGridViewColumnDisplayTextEventArgs e)
        {
            if (e.Column.Caption == "STT")
            {
                e.DisplayText = (e.VisibleRowIndex + 1).ToString();
            }
        }

        //Xoá toàn bộ dữ liệu trong gridview ở trang hiện thời
        protected void btnDeleteLog_Click(object sender, EventArgs e)
        {
            int _id=0;
            List<object> _lstCurrentPage=new List<object>();

            try
            {
                //Lấy ra toàn bộ key trong gridview ở trang hiện thời
                _lstCurrentPage = GrdLog.GetCurrentPageRowValues(new string[] { GrdLog.KeyFieldName });
                if(_lstCurrentPage.Count!=0 && _lstCurrentPage!=null)
                {
                    for(int i=0;i < _lstCurrentPage.Count;i++)
                    {
                        _id = int.Parse(_lstCurrentPage[i].ToString());
                        _ISYS_LogService.DeleteSYS_Logstr(_id);
                    }
                    _DataBind();
                }
            }
            catch (Exception ex)
            {
                throw new Exception(String.Format("btnDeleteLog_Click.Delete: {0}", ex.Message));
            }
        }
    }
}
