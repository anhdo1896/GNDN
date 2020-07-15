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
    public partial class InDN_ChiTietThuongPham_DonVi : DevExpress.XtraReports.UI.XtraReport
    {

        public InDN_ChiTietThuongPham_DonVi(DataTable dt, string thang, string nam, string tenDonvi, int DonVi,string TCT)
        {
            CBDN.DB_CBDNDataContext db = new CBDN.DB_CBDNDataContext(new CBDN.ADOController().strcn());

            InitializeComponent();
            var khDN = db.DN_TongNhapDienNhans.SingleOrDefault(x => x.IDMA_DVIQLY == DonVi && x.Thang == int.Parse(thang) && x.Nam == int.Parse(nam));
            if (khDN != null)
            {
                lbTongDN.Text =string.Format( "Sản lượng thương phẩm phân bổ: {0:N0}", + khDN.DN_Thang);
                if (khDN.NgayDCLan1 != null)
                    lbDieuChinh1.Text = string.Format("ĐC lần 1: {0:N0}," , khDN.DN_DC_Lan1 )+ "   Ngày ĐC: " + ((DateTime)khDN.NgayDCLan1).ToString("dd/MM/yyyy");
                if (khDN.NgayDCLan2 != null)
                    lbDieuChinh2.Text = string.Format("ĐC lần 2: {0:N0}," , khDN.DN_DC_Lan2) + "   Ngày ĐC: " + ((DateTime)khDN.NgayDCLan2).ToString("dd/MM/yyyy");
                if (khDN.NgayDCLan3 != null)
                    lbDieuChinh3.Text = string.Format("ĐC lần 3: {0:N0}," , khDN.DN_DC_Lan3) + "   Ngày ĐC: " + ((DateTime)khDN.NgayDCLan3).ToString("dd/MM/yyyy");
            }
            if (TCT == "TCT")
            {
                lbSanLuong.Text = "Sản lượng thương phẩm";
            }
            else
                lbSanLuong.Text = "Thương phẩm theo các phần ghi chỉ số";
            Detail.Report.DataSource = dt;
            lbThangNam.Text = "Ngày: " + DateTime.Now.ToString("dd/MM/yyyy");
            lbTenDVBC.Text = tenDonvi;
            xlSTT.DataBindings.Add("Text", DataSource, "STT");
            lbNgay.DataBindings.Add("Text", DataSource, "Ngay");
            lnDNN2.DataBindings.Add("Text", DataSource,string.Format("{0:N0}", "DN2"));
            lbDNN1.DataBindings.Add("Text", DataSource,string.Format("{0:N0}", "DN1"));
            lbDNHT.DataBindings.Add("Text", DataSource, string.Format("{0:N0}","DN"));
            lbDNSS.DataBindings.Add("Text", DataSource, string.Format("{0:N0}","SS_DN"));
            lbSLgN1.DataBindings.Add("Text", DataSource, string.Format("{0:N0}","SanLuongPB1"));
            lbSLgPB.DataBindings.Add("Text", DataSource, string.Format("{0:N0}","SanLuongKH"));
            lbSLgThucHien.DataBindings.Add("Text", DataSource, string.Format("{0:N0}","SanLuongPB"));
            //xlSSNgay.DataBindings.Add("Text", DataSource, "SS_N1");
            lbSSN1.DataBindings.Add("Text", DataSource, string.Format("{0:N0}","SS_N1"));
            lbGhiChu.DataBindings.Add("Text", DataSource, "GhiChu");
            xrSoSanh.DataBindings.Add("Html", DataSource, "SS_N0");

            xlSumDNN2.Text =string.Format("{0:N0}", dt.Compute("Sum(DN2)", "1=1").ToString());
            xlSumDNN1.Text = string.Format("{0:N0}", dt.Compute("Sum(DN1)", "1=1").ToString());
            xlSumHt.Text = string.Format("{0:N0}", dt.Compute("Sum(DN)", "1=1").ToString());
            xlSumSSDN.Text = string.Format("{0:N0}", dt.Compute("Sum(SS_DN)", "1=1").ToString());
            xlSumSlgN1.Text =string.Format("{0:N0}",  dt.Compute("Sum(SanLuongPB1)", "1=1").ToString());
            xlSumSlgPB.Text =string.Format("{0:N0}",  dt.Compute("Sum(SanLuongKH)", "1=1").ToString());
            xlSumSLgTH.Text =string.Format("{0:N0}",  dt.Compute("Sum(SanLuongPB)", "1=1").ToString());
            xlSumSlgKh.Text =string.Format("{0:N0}",  dt.Compute("Sum(SS_N1)", "1=1").ToString());
            xlSumSSSlgN1.Text = string.Format("{0:N0}", dt.Compute("Sum(SSKH_TH)", "1=1").ToString());

        }

        private void InBienBanQT_BeforePrint(object sender, System.Drawing.Printing.PrintEventArgs e)
        {

        }

    }
}
