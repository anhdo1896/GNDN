using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using DevExpress.XtraReports.UI;
using System.Data;
using SystemManageService;
namespace MTCSYT.Report
{
    public partial class InTBA : DevExpress.XtraReports.UI.XtraReport
    {

        public InTBA(DataTable dt, string thang, string nam, string tenDonvi)
        {
            InitializeComponent();


            Detail.Report.DataSource = dt;


            lbThangNam.Text = " Tháng " + thang + " Năm " + nam + ".";
            lbDonvi.Text = tenDonvi;
            xlSTT.DataBindings.Add("Text", DataSource, "STT");
            xlDonVi.DataBindings.Add("Text", DataSource, "TEN_DVIQLY");

            xlTBA3.DataBindings.Add("Text", DataSource, "SO_TBA_LESS3");
            xlTBA6.DataBindings.Add("Text", DataSource, "SO_TBA_LESS6");
            xlTBA10.DataBindings.Add("Text", DataSource, "SO_TBA_LESS10");
            xlTBA15.DataBindings.Add("Text", DataSource, "SO_TBA_LESS15");
            xlTBAmax.DataBindings.Add("Text", DataSource, "SO_TBA_MORE15");

            xlTDN3.DataBindings.Add("Text", DataSource, "DAU_NGUON_LESS3");
            xlTDN6.DataBindings.Add("Text", DataSource, "DAU_NGUON_LESS6");
            xlTDN10.DataBindings.Add("Text", DataSource, "DAU_NGUON_LESS10");
            xlTDN15.DataBindings.Add("Text", DataSource, "DAU_NGUON_LESS15");
            xlTDNmax.DataBindings.Add("Text", DataSource, "DAU_NGUON_MORE15");

            xlTongTBA3.Text = dt.Compute("Sum(SO_TBA_LESS3)", "1=1") + "";
            xlTongTBA6.Text = dt.Compute("Sum(SO_TBA_LESS6)", "1=1") + "";
            xlTongTBA10.Text = dt.Compute("Sum(SO_TBA_LESS10)", "1=1") + "";
            xlTongTBA15.Text = dt.Compute("Sum(SO_TBA_LESS15)", "1=1") + "";
            xlTongTBMax.Text = dt.Compute("Sum(SO_TBA_MORE15)", "1=1") + "";

            xlTongDN3.Text = dt.Compute("Sum(DAU_NGUON_LESS3)", "1=1") + "";
            xlTongDN6.Text = dt.Compute("Sum(DAU_NGUON_LESS6)", "1=1") + "";
            xlTongDN10.Text = dt.Compute("Sum(DAU_NGUON_LESS10)", "1=1") + "";
            xlTongDN15.Text = dt.Compute("Sum(DAU_NGUON_LESS15)", "1=1") + "";
            xlTongDNMax.Text = dt.Compute("Sum(DAU_NGUON_MORE15)", "1=1") + "";
        }

        private void InBienBanQT_BeforePrint(object sender, System.Drawing.Printing.PrintEventArgs e)
        {

        }

    }
}
