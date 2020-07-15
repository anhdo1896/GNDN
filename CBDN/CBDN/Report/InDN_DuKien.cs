using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using DevExpress.XtraReports.UI;
using System.Data;
using SystemManageService;
namespace MTCSYT.Report
{
    public partial class InDN_DuKien : DevExpress.XtraReports.UI.XtraReport
    {

        public InDN_DuKien(DataTable dt, string thang, string nam, string Ngay, string tenDonvi)
        {
            InitializeComponent();
            Detail.Report.DataSource = dt;
            lbThangNam.Text = "Ngày " + Ngay + " tháng " + thang + " năm " + nam;
            lbTenDVBC.Text = tenDonvi;
            xlSTT.DataBindings.Add("Text", DataSource, "STT");
            lbTenDV.DataBindings.Add("Text", DataSource, "TEN_DVIQLY");
            lbSLg.DataBindings.Add("Text", DataSource, "DN_Thang");
            lbLan1.DataBindings.Add("Text", DataSource, "DC1");
            lbLan2.DataBindings.Add("Text", DataSource, "DC2");
            lbLan3.DataBindings.Add("Text", DataSource, "DC3");
            lbTongKH.DataBindings.Add("Text", DataSource, "TongKH_PBNgay");
            lbLuyKeTH.DataBindings.Add("Text", DataSource, "LuyKeTH");
            lbSoSanh.DataBindings.Add("Text", DataSource, "SoSanh");
            lbTBNgayKh.DataBindings.Add("Text", DataSource, "TB_KH");
            xlNgayTH.DataBindings.Add("Text", DataSource, "TB_TH");
            xlSSNgay.DataBindings.Add("Text", DataSource, "SS_TB");

            xlSumDC1.Text = dt.Compute("Sum(DC1)", "1=1").ToString();
            xlSumDC2.Text = dt.Compute("Sum(DC2)", "1=1").ToString();
            xlSumDC3.Text = dt.Compute("Sum(DC3)", "1=1").ToString();
            xlSumLuyKeTH.Text = dt.Compute("Sum(LuyKeTH)", "1=1").ToString();
            xlSumSLPB.Text = dt.Compute("Sum(DN_Thang)", "1=1").ToString();
            xlSumSS.Text = dt.Compute("Sum(SoSanh)", "1=1").ToString();
            xlSumSSNgay.Text = dt.Compute("Sum(SS_TB)", "1=1").ToString();
            xlSumTBKH.Text = dt.Compute("Sum(TB_KH)", "1=1").ToString();
            xlSumTBTH.Text = dt.Compute("Sum(TB_TH)", "1=1").ToString();
            xlSumTongKH.Text = dt.Compute("Sum(TongKH_PBNgay)", "1=1").ToString();
            

        }

        private void InBienBanQT_BeforePrint(object sender, System.Drawing.Printing.PrintEventArgs e)
        {

        }

    }
}
