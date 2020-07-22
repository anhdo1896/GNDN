using System;
using System.Collections.Generic;
using SystemManageService;
using DevExpress.Web.ASPxTreeList;
using Entity;
using System.Linq;
using System.Web.UI;
using System.Data.OleDb;
using System.Data;
using System.IO;
using System.Xml;
using System.Text;
using System.Net;
using DevExpress.Web;
namespace MTCSYT.GCS_ONLINE
{
    public partial class GCS_XUATFILE : BasePage
    {
        DataAccess.dbGCS dlDB = new DataAccess.dbGCS();
        private const string funcid = "100";
        private SYS_Right rightOfUser = null;
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
            #endregion
            if (!IsPostBack)
            {
                string strMadviqly = session.User.ma_dviqly;
                int thang = 0, nam = 0;
                dlDB.SELECT_LAYTHANGLAMVIEC(strMadviqly, ref thang, ref nam);

                txtnam.Text = nam + "";
                txtthang.Text = thang + "";

            }
            loadTenFile();

        }
        private void loadTenFile()
        {
            SYS_Session session = (SYS_Session)Session["SYS_Session"];
            string strMadviqly = session.User.ma_dviqly;
            DataAccess.dbGCS dlDB = new DataAccess.dbGCS();
            grdCN.DataSource = dlDB.SELECT_TENFILE_XN(strMadviqly, int.Parse(cmbKy.Value + ""), int.Parse(txtthang.Text), int.Parse(txtnam.Text), "TENFILE", "");
            grdCN.DataBind();
        }

        protected void grdCN_Callback(object sender, EventArgs e)
        {

        }

        protected void grdCN_CustomCallback(object sender, DevExpress.Web.ASPxGridViewCustomCallbackEventArgs e)
        {
        }

        protected void grdCN_CustomColumnDisplayText(object sender, DevExpress.Web.ASPxGridViewColumnDisplayTextEventArgs e)
        {
            if (e.Column.Caption == "STT")
            {
                e.DisplayText = (e.VisibleRowIndex + 1).ToString();
            }
        }

        protected void btnXuatFile_Click(object sender, EventArgs e)
        {
            SYS_Session session = (SYS_Session)Session["SYS_Session"];
            string strMadviqly = session.User.ma_dviqly;
            DataAccess.dbGCS dlDB = new DataAccess.dbGCS();
            if (grdCN.FocusedRowIndex == -1)
                return;


            var KH = (DataRowView)grdCN.GetRow(grdCN.FocusedRowIndex);
            DataTable dt = dlDB.SELECT_KH_BYSOGCS(strMadviqly, int.Parse(cmbKy.Value + ""), int.Parse(txtthang.Text), int.Parse(txtnam.Text), KH.Row.ItemArray[0].ToString().Trim(), "FILE");
            if (dt.Rows.Count == 0)
                return;
            #region
            foreach (DataRow dr in dt.Rows)
            {
                dr["CS_CU"] = Math.Round(Convert.ToDecimal(dr["CS_CU"].ToString()), 3);
                dr["CS_MOI"] = Math.Round(Convert.ToDecimal(dr["CS_MOI"].ToString()), 3);
                if (dr["NGAY_PMAX"] + "" == "" || dr["NGAY_PMAX"] + "" == null || dr["NGAY_PMAX"] + "" == "T00:00:00")
                    dr["NGAY_PMAX"] = "1900-01-01T00:00:00";
            }
            #endregion


            QLY_VTTB.Class.XuatXML_GCS class_xuatso = new QLY_VTTB.Class.XuatXML_GCS();
            DataSet ds = new DataSet();
            ds.Tables.Add(dt);
            string strXML = class_xuatso.HTML_XuatFileCMIS();
            string strXML1 = ds.GetXml();
            //strXML1 = strXML1.Replace(",", ".");
            strXML1 = strXML1.Replace("<NewDataSet>", "");
            strXML1 = strXML1.Replace("</NewDataSet>", "");
            strXML1 = strXML1.Replace("<Table>", "<Table1>");
            strXML1 = strXML1.Replace("</Table>", "</Table1>");
            strXML += strXML1 + "</NewDataSet>";

            string attachment = "attachment;filename=" + KH.Row.ItemArray[0].ToString();
            Response.ClearContent();
            Response.ContentType = "application/xml";
            Response.AddHeader("content-disposition", attachment);
            Response.Write(strXML);

            Response.End();


        }

        protected void cbAll_Init(object sender, EventArgs e)
        {

            ASPxCheckBox chk = sender as ASPxCheckBox;
            ASPxGridView grid = (chk.NamingContainer as GridViewHeaderTemplateContainer).Grid;
            chk.Checked = (grid.Selection.Count == grid.VisibleRowCount);
        }
    }
}