using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using DevExpress.XtraReports.UI;
using System.Data;
using SystemManageService;
using System.Linq;
namespace MTCSYT.Report
{
    public partial class InDN_ThuongPhamTCT : DevExpress.XtraReports.UI.XtraReport
    {

        public InDN_ThuongPhamTCT(DataTable dt, string thang, string nam, string tenDonvi, int DonVi)
        {
            CBDN.DB_CBDNDataContext db = new CBDN.DB_CBDNDataContext(new CBDN.ADOController().strcn());
           
            InitializeComponent(); 
            return;
            var khDN = db.DN_TK_SumALLKeHoach(int.Parse(thang), int.Parse("" + nam)).ToList();

             if (khDN.Count() > 0)
             {
                 foreach (var kh in khDN)
                 {

                     lbTongDN.Text = "Tổng điện nhận: " + kh.DN_Thang + "";
                    

                     lbDieuChinh1.Text = "ĐC lần 1: " + kh.DN_DC_Lan1;

                     lbDieuChinh2.Text = "  ĐC lần 2: " + kh.DN_DC_Lan2;

                     lbDieuChinh3.Text = "  ĐC lần 3: " + kh.DN_DC_Lan3;

                     break;
                 }
             }
          

            Detail.Report.DataSource = dt;
            lbThangNam.Text = "Ngày: " + DateTime.Now.ToString("dd/MM/yyyy");
            xlSTT.DataBindings.Add("Text", DataSource, "STT");
            lbNgay.DataBindings.Add("Text", DataSource, "TEN_DVIQLY");
            lnDNN2.DataBindings.Add("Text", DataSource, "DN2");
            lbDNN1.DataBindings.Add("Text", DataSource, "DN1");
            lbDNHT.DataBindings.Add("Text", DataSource, "DN");
            lbDNSS.DataBindings.Add("Text", DataSource, "SS_DN");
            lbSLgN1.DataBindings.Add("Text", DataSource, "SanLuongPB1");
            lbSLgPB.DataBindings.Add("Text", DataSource, "SanLuongKH");
            lbSLgThucHien.DataBindings.Add("Text", DataSource, "SanLuongPB");
            lbSSN1.DataBindings.Add("Text", DataSource, "SS_N1");

            xlSumDNN2.Text = dt.Compute("Sum(DN2)", "1=1").ToString();
            xlSumDNN1.Text = dt.Compute("Sum(DN1)", "1=1").ToString();
            xlSumHt.Text = dt.Compute("Sum(DN)", "1=1").ToString();
            xlSumSSDN.Text = dt.Compute("Sum(SS_DN)", "1=1").ToString();
            xlSumSlgN1.Text = dt.Compute("Sum(SanLuongPB1)", "1=1").ToString();
            xlSumSlgPB.Text = dt.Compute("Sum(SanLuongKH)", "1=1").ToString();
            xlSumSLgTH.Text = dt.Compute("Sum(SanLuongPB)", "1=1").ToString();
            xlSumSlgKh.Text = dt.Compute("Sum(SSKH_TH)", "1=1").ToString();
            xlSumSSSlgN1.Text = dt.Compute("Sum(SS_N1)", "1=1").ToString();

            xrTest.DataBindings.Add("Html", DataSource, "SS_N0");

        }

        private void InBienBanQT_BeforePrint(object sender, System.Drawing.Printing.PrintEventArgs e)
        {

        }

    }
}
