using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using DevExpress.XtraReports.UI;
using System.Data;
using SystemManageService;
namespace MTCSYT.Report
{
    public partial class testViewPDF : DevExpress.XtraReports.UI.XtraReport
    {

        public testViewPDF(string link)
        {
            InitializeComponent();
            lbTest.Rtf = link;

           
        }

        private void InBienBanQT_BeforePrint(object sender, System.Drawing.Printing.PrintEventArgs e)
        {

        }

    }
}
