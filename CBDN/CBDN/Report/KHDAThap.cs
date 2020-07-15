using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using DevExpress.XtraReports.UI;
using System.Data;
using SystemManageService;
namespace MTCSYT.Report
{
    public partial class KHDAThap : DevExpress.XtraReports.UI.XtraReport
    {

        public KHDAThap(DataTable dt, string thang, string nam, string tenDonvi)
        {
            InitializeComponent();


            Detail.Report.DataSource = dt;

            lbThangNam.Text = " Tháng " + thang + " Năm " + nam + ".";
            lbDonvi.Text = tenDonvi;
            xlSTT.DataBindings.Add("Text", DataSource, "STT");
            xlDonVi.DataBindings.Add("Text", DataSource, "TenDonVi");
            xlTBA.DataBindings.Add("Text", DataSource, "SOKH");
            xl160.DataBindings.Add("Text", DataSource, "KH160");
            xl180.DataBindings.Add("Text", DataSource, "KH180");
            xl200.DataBindings.Add("Text", DataSource, "KH200");
            xlGiaiPhap.DataBindings.Add("Text", DataSource, "GiaiPhap");
            xlTienDo.DataBindings.Add("Text", DataSource, "TienDo");
        }

        private void InBienBanQT_BeforePrint(object sender, System.Drawing.Printing.PrintEventArgs e)
        {

        }

    }
}
