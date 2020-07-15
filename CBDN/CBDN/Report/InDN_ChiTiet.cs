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
    public partial class InDN_ChiTiet : DevExpress.XtraReports.UI.XtraReport
    {

        public InDN_ChiTiet(DataTable dt, string thang, string nam, string tenDonvi, int DonVi)
        {
            CBDN.DB_CBDNDataContext db = new CBDN.DB_CBDNDataContext(new CBDN.ADOController().strcn());

            InitializeComponent();
            var khDN = db.DN_TongNhapDienNhans.SingleOrDefault(x => x.IDMA_DVIQLY == DonVi && x.Thang == int.Parse(thang) && x.Nam == int.Parse(nam));
            if (khDN != null)
            {
                if (khDN.NgayDCLan1 != null)
                    lbDieuChinh1.Text = "ĐC lần 1: " + khDN.DN_DC_Lan1 + "   Ngày ĐC: " + ((DateTime)khDN.NgayDCLan1).ToString("dd/MM/yyyy");
                if (khDN.NgayDCLan2 != null)
                    lbDieuChinh2.Text = "ĐC lần 2: " + khDN.DN_DC_Lan2 + "   Ngày ĐC: " + ((DateTime)khDN.NgayDCLan2).ToString("dd/MM/yyyy");
                if (khDN.NgayDCLan3 != null)
                    lbDieuChinh3.Text = "ĐC lần 3: " + khDN.DN_DC_Lan3 + "   Ngày ĐC: " + ((DateTime)khDN.NgayDCLan3).ToString("dd/MM/yyyy");
            }

            Detail.Report.DataSource = dt;
            lbThangNam.Text = "Ngày: " + DateTime.Now.ToString("dd/MM/yyyy");
            lbTenDVBC.Text = tenDonvi;
            xlSTT.DataBindings.Add("Text", DataSource, "STT");
            lbNgay.DataBindings.Add("Text", DataSource, "Ngay");
            lbSLg.DataBindings.Add("Text", DataSource, "TH_PhanBoNgay");
            lbLan1.DataBindings.Add("Text", DataSource, "DieuChinh");
            lbLan2.DataBindings.Add("Text", DataSource, "DienNhan");
            lbTongKH.DataBindings.Add("Text", DataSource, "TongKH");
            lbLuyKeTH.DataBindings.Add("Text", DataSource, "LuyKeTH");
            lbSoSanh.DataBindings.Add("Text", DataSource, "SoSanh");
            lbTBNgayKh.DataBindings.Add("Text", DataSource, "TB_KH");
            xlNgayTH.DataBindings.Add("Text", DataSource, "TB_TH");
            xlSSNgay.DataBindings.Add("Text", DataSource, "TB_SS");

            xlSumDC1.Text = dt.Compute("Sum(TH_PhanBoNgay)", "1=1").ToString();
            xlSumDC3.Text = dt.Compute("Sum(DieuChinh)", "1=1").ToString();
            xlSumDC3.Text = dt.Compute("Sum(DienNhan)", "1=1").ToString();
            xlSumLuyKeTH.Text = dt.Compute("Sum(LuyKeTH)", "1=1").ToString();
            xlSumSLPB.Text = dt.Compute("Sum(TH_PhanBoNgay)", "1=1").ToString();
            xlSumSS.Text = dt.Compute("Sum(SoSanh)", "1=1").ToString();
            xlSumSSNgay.Text = dt.Compute("Sum(TB_SS)", "1=1").ToString();
            xlSumTBKH.Text = dt.Compute("Sum(TB_KH)", "1=1").ToString();
            xlSumTBTH.Text = dt.Compute("Sum(TB_TH)", "1=1").ToString();
            xlSumTongKH.Text = dt.Compute("Sum(TongKH)", "1=1").ToString();


        }

        private void InBienBanQT_BeforePrint(object sender, System.Drawing.Printing.PrintEventArgs e)
        {

        }

    }
}
