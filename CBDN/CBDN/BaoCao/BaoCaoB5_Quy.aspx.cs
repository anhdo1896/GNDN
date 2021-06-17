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
    public partial class BaoCaoB5_Quy : BasePage
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
            int quy = int.Parse(cmbQuy.Value + "");
           

            int thang1 = 0;
            int thang2 = 0;
            int thang3 = 0;
            var ThangM = Dapper_SQL.Get_MaxThang_DL_GN(DateTime.Now.Year);
            int thangmax = int.Parse(ThangM.Rows[0]["ThangMax"] + "");

            if (quy==1)
            { thang1 = 1; thang2 = 2; thang3 = 3; }
            else if(quy==2)
            { thang1 = 4; thang2 = 5; thang3 = 6; }    
            else if(quy==3)
            { thang1 = 7;thang2 = 8;thang3 = 9; }
            else
            { thang1 = 10; thang2 = 11; thang3 = 12; }
            
            int nam = int.Parse(cmbNam.Value + "");
            int tnow = DateTime.Now.Month;
            int ynow = DateTime.Now.Year;
            DataTable dsdt = new DataTable();
            DataTable dsa1 = new DataTable();
            DataTable dsa2 = new DataTable();
            DataTable dsa3 = new DataTable();
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
            if((quy ==1 && nam == ynow) || (quy == 2 && nam == ynow) || (quy == 3  && nam == ynow) || (quy == 4  && nam == ynow - 1))
            {
                if(thangmax == thang3)
                {
                    dsa1 = Dapper_SQL.Get_BaoCaoB5_LS(thang1, nam);
                    dsa2 = Dapper_SQL.Get_BaoCaoB5_LS(thang2, nam);
                    dsa3 = Dapper_SQL.Get_BaoCaoB5(thang3, nam);
                }
                else if (thangmax == thang2)
                {
                    dsa1 = Dapper_SQL.Get_BaoCaoB5_LS(thang1, nam);
                    dsa2 = Dapper_SQL.Get_BaoCaoB5(thang2, nam);
                }
                else if (thangmax == thang1)
                {
                    dsa1 = Dapper_SQL.Get_BaoCaoB5(thang1, nam);
                }
                else if (thangmax > thang3)
                {
                    dsa1 = Dapper_SQL.Get_BaoCaoB5_LS(thang1, nam);
                    dsa2 = Dapper_SQL.Get_BaoCaoB5_LS(thang2, nam);
                    dsa3 = Dapper_SQL.Get_BaoCaoB5_LS(thang3, nam);
                }

            }    
            else
            {
                dsa1 = Dapper_SQL.Get_BaoCaoB5_LS(thang1, nam);
                dsa2 = Dapper_SQL.Get_BaoCaoB5_LS(thang2, nam);
                dsa3 = Dapper_SQL.Get_BaoCaoB5_LS(thang3, nam);
            }    
                int a = dsa1.Rows.Count;
            if (a > 1)
            {
                for (int i = 0; i < a; i++)
                {
                    decimal B1_1 = 0, B2_1 = 0, B3_1 = 0, Tong_1 = 0, B1_2 = 0, B2_2 = 0, B3_2 = 0, Tong_2 = 0, B1_3 = 0, B2_3 = 0, B3_3 = 0, Tong_3 = 0;
                    var Ten = dsa1.Rows[i]["TenDV"];
                    if(dsa1.Rows[i]["B1_TieuThu"] + "" != "" )
                    { 
                    B1_1 = decimal.Parse(dsa1.Rows[i]["B1_TieuThu"]+"");
                    }
                    if (dsa1.Rows[i]["B2_TieuThu"] + "" != "")
                    {
                        B2_1 = decimal.Parse(dsa1.Rows[i]["B2_TieuThu"] + "");
                    }
                    if (dsa1.Rows[i]["B3_TieuThu"] + "" != "")
                    {
                        B3_1 = decimal.Parse(dsa1.Rows[i]["B3_TieuThu"] + "");
                    }
                    if (dsa1.Rows[i]["Tong_TieuThu"] + "" != "")
                    {
                        Tong_1 = decimal.Parse(dsa1.Rows[i]["Tong_TieuThu"] + "");
                    }
                    int a2 = dsa2.Rows.Count;
                    if (a2 > 1)
                    {
                        if (dsa2.Rows[i]["B1_TieuThu"] + "" != "")
                        {
                            B1_2 = decimal.Parse(dsa2.Rows[i]["B1_TieuThu"] + "");
                        }
                        if (dsa2.Rows[i]["B2_TieuThu"] + "" != "")
                        {
                            B2_2 = decimal.Parse(dsa2.Rows[i]["B2_TieuThu"] + "");
                        }
                        if (dsa2.Rows[i]["B3_TieuThu"] + "" != "")
                        {
                            B3_2 = decimal.Parse(dsa2.Rows[i]["B3_TieuThu"] + "");
                        }
                        if (dsa2.Rows[i]["Tong_TieuThu"] + "" != "")
                        {
                            Tong_2 = decimal.Parse(dsa2.Rows[i]["Tong_TieuThu"] + "");
                        }
                    }
                    int a3 = dsa3.Rows.Count;
                    if (a3 > 1)
                    {
                        if (dsa3.Rows[i]["B1_TieuThu"] + "" != "")
                        {
                            B1_3 = decimal.Parse(dsa3.Rows[i]["B1_TieuThu"] + "");
                        }
                        if (dsa3.Rows[i]["B2_TieuThu"] + "" != "")
                        {
                            B2_3 = decimal.Parse(dsa3.Rows[i]["B2_TieuThu"] + "");
                        }
                        if (dsa3.Rows[i]["B3_TieuThu"] + "" != "")
                        {
                            B3_3 = decimal.Parse(dsa3.Rows[i]["B3_TieuThu"] + "");
                        }
                        if (dsa3.Rows[i]["Tong_TieuThu"] + "" != "")
                        {
                            Tong_3 = decimal.Parse(dsa3.Rows[i]["Tong_TieuThu"] + "");
                        }
                    }
                    var B1 = B1_1 + B1_2 + B1_3;
                    var B2 = B2_1 + B2_2 + B2_3;
                    var B3 = B3_1 + B3_2 + B3_3;
                    var Tong = Tong_1 + Tong_2 + Tong_3;
                    var B1_TieuThu = string.Format("{0:N0} ", B1);
                    var B2_TieuThu = string.Format("{0:N0} ", B2);
                    var B3_TieuThu = string.Format("{0:N0} ", B3);
                    var Tong_TieuThu = string.Format("{0:N0} ", Tong);

                    dsdt.Rows.Add(i+1,Ten, B1_TieuThu, B2_TieuThu, B3_TieuThu, Tong_TieuThu, B1, B2, B3, Tong);
                }
                MTCSYT.Report.InBaoCaoB5_Quy report = new MTCSYT.Report.InBaoCaoB5_Quy(dsdt, "" + cmbQuy.Value, "" + cmbNam.Value);
            ReportViewer2.Report = report;

            ReportToolbar2.ReportViewer = ReportViewer2;
            }
        }



       
        private void loadDSNgay()
        {
            if (DateTime.Now.Month <= 1)
            {
                cmbQuy.Value = 4;
                cmbNam.Value = DateTime.Now.Year - 1;

            }
            else if (DateTime.Now.Month <= 4)
                {
                    cmbQuy.Value = 1;
                    cmbNam.Value = DateTime.Now.Year;

                }
            else if (DateTime.Now.Month <= 7)
            {
                cmbQuy.Value = 2;
                cmbNam.Value = DateTime.Now.Year ;

            }
            else 
            {
                cmbQuy.Value = 3;
                cmbNam.Value = DateTime.Now.Year ;

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