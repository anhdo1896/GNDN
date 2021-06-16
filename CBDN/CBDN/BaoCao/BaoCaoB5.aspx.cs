using System;
using System.Collections.Generic;
using SystemManageService;
using DevExpress.Web.ASPxTreeList;
using Entity;
using System.Linq;
using System.Web.UI;
using System.Data;
using DevExpress.Web;
using System.IO;
using MTCSYT;
using DataAccess;

namespace CBDN.BaoCao
{
    public partial class BaoCaoB5 : BasePage
    {
        CBDN.DB_CBDNDataContext db = new CBDN.DB_CBDNDataContext(new CBDN.ADOController().strcn());
        private const string funcid = "61";
        private SYS_Right rightOfUser = null;
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
            Session["SYS_Session"] = session;
            if (!IsPostBack)
            {
                loadDSNgay();
                
            }
            InBienBanQuyetToan();

        }
       
        private void InBienBanQuyetToan()
        {
            int thang = int.Parse(cmbThang.Value + "");
            int nam = int.Parse(cmbNam.Value + "");
            int tnow = DateTime.Now.Month;
            int ynow = DateTime.Now.Year;
            DataTable dsdt = new DataTable();
            DataTable dsa = new DataTable();
            dsdt.Columns.Add("STT");
            dsdt.Columns.Add("Ten_Cty");

            dsdt.Columns.Add("B1_TieuThu");
            dsdt.Columns.Add("B2_TieuThu");
            dsdt.Columns.Add("B3_TieuThu");
            dsdt.Columns.Add("Tong_TieuThu");
            dsdt.Columns.Add("B1", typeof(decimal));
            dsdt.Columns.Add("B2", typeof(decimal));
            dsdt.Columns.Add("B3", typeof(decimal));
            dsdt.Columns.Add("Tong", typeof(decimal));
            if(thang == tnow-1 && nam == ynow)
            { dsa = Dapper_SQL.Get_BaoCaoB5(thang, nam); }    
            else if (thang == 12 && nam == ynow && tnow == 1)
            { dsa = Dapper_SQL.Get_BaoCaoB5(thang, nam); }
            else
            {
                dsa = Dapper_SQL.Get_BaoCaoB5_LS(thang, nam);
            }    
                int a = dsa.Rows.Count;
            if (a > 1)
            {
                for (int i = 0; i < a; i++)
                {
                    var Ten = dsa.Rows[i]["TenDV"];
                    var B1 = decimal.Parse(dsa.Rows[i]["B1_TieuThu"]+"");
                   var B2 = decimal.Parse(dsa.Rows[i]["B2_TieuThu"] + "");
                   var B3 = decimal.Parse(dsa.Rows[i]["B3_TieuThu"] + "");
                    var Tong = decimal.Parse(dsa.Rows[i]["Tong_TieuThu"] + "");
                    var B1_TieuThu = string.Format("{0:N0} ", B1);
                    var B2_TieuThu = string.Format("{0:N0} ", B2);
                    var B3_TieuThu = string.Format("{0:N0} ", B3);
                    var Tong_TieuThu = string.Format("{0:N0} ", Tong);

                    dsdt.Rows.Add(i+1,Ten, B1_TieuThu, B2_TieuThu, B3_TieuThu, Tong_TieuThu, B1, B2, B3, Tong);
                }
                MTCSYT.Report.InBaoCaoB5 report = new MTCSYT.Report.InBaoCaoB5(dsdt, "" + cmbThang.Value, "" + cmbNam.Value);
            ReportViewer2.Report = report;

            ReportToolbar2.ReportViewer = ReportViewer2;
            }
        }



       
        private void loadDSNgay()
        {

                if (DateTime.Now.Month == 1)
                {
                    cmbThang.Value = 12;
                    cmbNam.Value = DateTime.Now.Year - 1;

                }
                
                else
                {
                    cmbThang.Value = DateTime.Now.Month - 1;
                    cmbNam.Value = DateTime.Now.Year;


            }
        }
        protected void grdNhan_CustomCallback(object sender, DevExpress.Web.ASPxGridViewCustomCallbackEventArgs e)
        {
          
        }
        protected void grdGiao_Callback(object sender, EventArgs e)
        {

        }





        protected void cmbThang_SelectedIndexChanged(object sender, EventArgs e)
        {
            InBienBanQuyetToan();
        }

        protected void cmbNam_SelectedIndexChanged(object sender, EventArgs e)
        {
            InBienBanQuyetToan();
        }



    }
}