using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.IO;
using Aspose.Cells;
namespace BiQL_SangLoc
{
    public partial class ImportCS_ChuKyNgay : System.Web.UI.Page
    {
        DataAccess.clTTTT dbTT = new DataAccess.clTTTT();
        private Cells _range;
        private Worksheet _exSheet;
        DataTable dtData = new DataTable();
        private const string funcid = "113";
        protected void Page_Load(object sender, EventArgs e)
        {
            Session["Data"] = null;
        }

        public string UploadFile()
        {
            string strTenFile = "";
            try
            {

                if (!Directory.Exists(Server.MapPath("~/") + "BaoCao"))
                    Directory.CreateDirectory(Server.MapPath("~/") + "BaoCao");
                if (!File.Exists(Server.MapPath("~/") + "BaoCao\\" + fileUp.FileName))
                {
                    strTenFile = DateTime.Today.Day + DateTime.Today.Hour + DateTime.Today.Second + fileUp.FileName;
                    fileUp.PostedFile.SaveAs(Server.MapPath("~/") + "BaoCao\\" + strTenFile);
                }
                else
                {
                    fileUp.PostedFile.SaveAs(Server.MapPath("~/") + "BaoCao\\" + fileUp.FileName);
                    strTenFile = fileUp.FileName;
                }
                hdTenFile.Value = strTenFile;
            }
            catch (Exception exp)
            {
                ScriptManager.RegisterStartupScript(Page, Page.GetType(), "", "alert('" + exp.Message + Server.MapPath("~/") + "BaoCao\\" + hdTenFile.Value + "');", true);
            }
            return strTenFile;
        }
        public DataTable GetData()
        {
            dtData = new DataTable();
            dtData.Columns.Add("Ngay");
            dtData.Columns.Add("Gio");
            dtData.Columns.Add("CS_P_GIAO");
            #region Chuẩn bị tệp excel mẫu để ghi dữ liệu
            string destFile = Server.MapPath("~/") + "BaoCao\\" + hdTenFile.Value;
            string sTemplate = (destFile);
            Workbook exBook = new Workbook();
            exBook.Open(sTemplate, FileFormatType.Excel2003);
            _exSheet = exBook.Worksheets[0];
            _range = _exSheet.Cells;
            #endregion


            for (int i = 1; i < _range.Rows.Count; i++)
            {
                dtData.Rows.Add(_range[i, 7].StringValue, _range[i, 10].StringValue, _range[i, 28].StringValue);
            }
            return dtData;
        }

        protected void btnXem_Click(object sender, EventArgs e)
        {
            if (fileUp.FileName != "")
            {
                UploadFile();

                grvView.DataSource = GetData();
                grvView.DataBind();
                btnConvert.Enabled = true;
            }
            else
            {
                hdTenFile.Value = "";
            }
        }

        protected void grvView_PageIndexChanged(object sender, EventArgs e)
        {
            dtData = GetData();
            grvView.DataSource = dtData;
            grvView.DataBind();
        }

        protected void btnConvert_Click(object sender, EventArgs e)
        {
            decimal hscs = 0;
            if (txtMaTram.Text == "")
            {
                ScriptManager.RegisterStartupScript(Page, Page.GetType(), "", "alert('Bạn chưa nhập mã trạm');", true);
                return;
            }
            if (!decimal.TryParse(txtHSCS.Text, out hscs))
            {
                ScriptManager.RegisterStartupScript(Page, Page.GetType(), "", "alert('Hệ số công suất phải là kiểu số');", true);
                return;
            }
            MTCSYT.SYS_Session session = (MTCSYT.SYS_Session)Session["SYS_Session"];
            if (hdTenFile.Value == "")
                return;

            if (Session["Data"] != null && hdTenFile.Value != "")
            {
                dtData = (DataTable)Session["Data"];
            }
            else if (hdTenFile.Value != "")
            {
                dtData = GetData();

            }
            int dem = 0;
            try
            {
                string ngaygio = "";
                if (dtData != null && dtData.Rows.Count > 0)
                {
                    decimal Csdau = 0; int ngay = 1; string strngay = "";
                    //dbTT.DELETE_TTTT_DUONGDAYTRAM_BYTRAM(txtMaTram.Text);
                    strngay = dtData.Rows[0]["Ngay"] + "";
                    for (int i = 0; i < dtData.Rows.Count; i++)
                    {
                        //  strngay = dtData.Rows[i]["Ngay"]+"";
                        if (i == 0)
                        {
                            Csdau = decimal.Parse(dtData.Rows[i]["CS_P_GIAO"] + "");
                        }
                        else if (ngaygio != dtData.Rows[i]["Ngay"] + "_" + dtData.Rows[i]["Gio"])
                        {
                            decimal cs = decimal.Parse(dtData.Rows[i]["CS_P_GIAO"] + "") - Csdau;
                            Csdau = decimal.Parse(dtData.Rows[i]["CS_P_GIAO"] + "");
                            //  dbTT.INSERT_TTTT_CHUKYSLG_THANG(session.User.ma_dviqlyDN, txtMaTram.Text, DateTime.Now.Month, DateTime.Now.Year, int.Parse(dtData.Rows[i]["Ngay"] + ""), int.Parse(dtData.Rows[i]["Gio"] + ""), cs*100);
                            dbTT.INSERT_TTTT_CHUKYSLG_THANG(session.User.ma_dviqlyDN, txtMaTram.Text, DateTime.Now.Month - 1, DateTime.Now.Year, ngay, int.Parse(dtData.Rows[i]["Gio"] + ""), cs * 100);
                            if (strngay != dtData.Rows[i]["Ngay"] + "")
                            {
                                ngay = ngay++;
                                strngay = dtData.Rows[0]["Ngay"] + "";
                            }

                            ngaygio = dtData.Rows[i]["Ngay"] + "_" + dtData.Rows[i]["Gio"];
                        }
                    }
                }
                ScriptManager.RegisterStartupScript(Page, Page.GetType(), "", "alert('Import dữ liệu thành công');", true);
            }
            catch (Exception ex)
            {
                ScriptManager.RegisterStartupScript(Page, Page.GetType(), "", "alert('Bạn xem lại dòng: " + dem + " có dữ liệu chưa đúng định dạng');", true);

            }
        }

        protected void grvView_CustomColumnDisplayText(object sender, DevExpress.Web.ASPxGridViewColumnDisplayTextEventArgs e)
        {

            if (e.Column.Caption == "STT")
            {
                e.DisplayText = (e.VisibleRowIndex + 1).ToString();
            }
        }

    }
}