using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using DevExpress.XtraReports.UI;
using System.Data;
using SystemManageService;
namespace MTCSYT.Report
{
    public partial class InTrungAp : DevExpress.XtraReports.UI.XtraReport
    {

        public InTrungAp(DataTable dt, string thang, string nam, string tenDonvi)
        {
            InitializeComponent();

            
            Detail.Report.DataSource = dt;

         
            lbThangNam.Text = " Tháng " + thang + " Năm " + nam + ".";
            lbDonvi.Text = tenDonvi;
            xlSTT.DataBindings.Add("Text", DataSource, "STT");
            xlDonVi.DataBindings.Add("Text", DataSource, "TEN_DVIQLY");

            XL2.DataBindings.Add("Text", DataSource, "SO_LDD_LESS2");
            XL3.DataBindings.Add("Text", DataSource, "SO_LDD_LESS3");
            XL4.DataBindings.Add("Text", DataSource, "SO_LDD_LESS4");
            XL5.DataBindings.Add("Text", DataSource, "SO_LDD_LESS5");
            XL6.DataBindings.Add("Text", DataSource, "SO_LDD_LESS6");
            XLMAX.DataBindings.Add("Text", DataSource, "SO_LDD_MORE6");
           // XLMAX.Properties.Mask.EditMask = "#,##0.00";  

            xlTong2.Text = dt.Compute("Sum(SO_LDD_LESS2)", "1=1") + "";
            xlTong3.Text = dt.Compute("Sum(SO_LDD_LESS3)", "1=1") + "";
            xlTong4.Text = dt.Compute("Sum(SO_LDD_LESS4)", "1=1") + "";
            xlTong5.Text = dt.Compute("Sum(SO_LDD_LESS5)", "1=1") + "";
            xlTong6.Text = dt.Compute("Sum(SO_LDD_LESS6)", "1=1") + "";
            //xlTongMax.Text = dt.Compute("Sum(SO_LDD_MORE6)", "1=1") + "";
            xlTong7.Text = dt.Compute("Sum(SO_LDD_MORE6)", "1=1") + "";
        }

        private void InBienBanQT_BeforePrint(object sender, System.Drawing.Printing.PrintEventArgs e)
        {

        }

    }
}
