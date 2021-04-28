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
    public partial class ImportData : System.Web.UI.Page
    {
        DataAccess.clTTTT dbTT = new DataAccess.clTTTT();
        private Cells _range;
        private Worksheet _exSheet;
        DataTable dtData = new DataTable();
        private const string funcid = "113";
        protected void Page_Load(object sender, EventArgs e)
        {
            MTCSYT.SYS_Session session = (MTCSYT.SYS_Session)Session["SYS_Session"];
            if (session == null || session.User.USERNAME == "Guest")
            {
                Response.Redirect("~\\Login.aspx");
            }
            else if (session.XacNhanPass == 0)
            {
                ScriptManager.RegisterStartupScript(this, this.GetType(), "alertMessage", "alert('Mật Khẩu Không Hợp Lệ. Yêu Cầu Đổi Mật Khẩu'); window.location='" +
                Request.ApplicationPath + "HeThong/ChangePassword.aspx';", true);
            }
            else if (session.DatePass > 90)
            {
                ScriptManager.RegisterStartupScript(this, this.GetType(), "alertMessage", "alert('Mật Khẩu Quá 90 Ngày. Yêu Cầu Đổi Mật Khẩu'); window.location='" +
                Request.ApplicationPath + "HeThong/ChangePassword.aspx';", true);
            }
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
            dtData.Columns.Add("DiemDau");
            dtData.Columns.Add("DiemCuoi");
            dtData.Columns.Add("MaLoaiDay");
            dtData.Columns.Add("ChieuDai");
            dtData.Columns.Add("HeSoCongSuat",typeof (string));
            #region Chuẩn bị tệp excel mẫu để ghi dữ liệu
            string destFile = Server.MapPath("~/") + "BaoCao\\" + hdTenFile.Value;
            string sTemplate = (destFile);
            Workbook exBook = new Workbook();
            exBook.Open(sTemplate, FileFormatType.Excel2007Xlsx);
            _exSheet = exBook.Worksheets[0];
            _range = _exSheet.Cells;
            #endregion


            for (int i = 1; i < _range.Rows.Count; i++)
            {
                dtData.Rows.Add(_range[i, 0].StringValue, _range[i, 1].StringValue, _range[i, 2].StringValue, _range[i, 3].StringValue, txtHSCS.Text);
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
                if (dtData != null && dtData.Rows.Count > 0)
                {
                    dbTT.DELETE_TTTT_DUONGDAYTRAM_BYTRAM(txtMaTram.Text);
                    for (int i = 0; i < dtData.Rows.Count; i++)
                    {
                        dbTT.INSERT_TTTT_DUONGDAY_TRAM(0, txtMaTram.Text, dtData.Rows[i]["DiemDau"] + "", dtData.Rows[i]["DiemCuoi"] + "", dtData.Rows[i]["MaLoaiDay"] + "", DateTime.Now, session.User.IDUSER, session.User.ma_dviqlyDN, decimal.Parse(txtHSCS.Text), decimal.Parse(dtData.Rows[i]["ChieuDai"] + ""), decimal.Parse(txtDienAp.Text));
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