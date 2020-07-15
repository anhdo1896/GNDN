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
    public partial class InDN_ThuongPham : DevExpress.XtraReports.UI.XtraReport
    {

        public InDN_ThuongPham(DataTable dt, string thang, string nam, string tenDonvi, int DonVi)
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
            lbThangNam.Text = "Ngày: " + DateTime.Now.ToString("dd/MM/yyyy");
            lbTenDVBC.Text = tenDonvi;
            Detail.Report.DataSource = dt;

            xlSTT.DataBindings.Add("Text", DataSource, "Ngay");
            lb1.DataBindings.Add("Text", DataSource, "1");
            lb2.DataBindings.Add("Text", DataSource, "2");
            lb3.DataBindings.Add("Text", DataSource, "3");
            lb4.DataBindings.Add("Text", DataSource, "4");
            lb5.DataBindings.Add("Text", DataSource, "5");
            lb6.DataBindings.Add("Text", DataSource, "6");
            lb7.DataBindings.Add("Text", DataSource, "7");
            lb8.DataBindings.Add("Text", DataSource, "8");
            lb9.DataBindings.Add("Text", DataSource, "9");
            lb10.DataBindings.Add("Text", DataSource, "10");
            lb11.DataBindings.Add("Text", DataSource, "11");
            lb12.DataBindings.Add("Text", DataSource, "12");
            lb13.DataBindings.Add("Text", DataSource, "13");
            lb14.DataBindings.Add("Text", DataSource, "14");
            lb15.DataBindings.Add("Text", DataSource, "15");
            lb16.DataBindings.Add("Text", DataSource, "16");
            lb17.DataBindings.Add("Text", DataSource, "17");
            lb18.DataBindings.Add("Text", DataSource, "18");
            lb19.DataBindings.Add("Text", DataSource, "19");
            lb20.DataBindings.Add("Text", DataSource, "20");

            lb21.DataBindings.Add("Text", DataSource, "21");
            lb22.DataBindings.Add("Text", DataSource, "22");
            lb23.DataBindings.Add("Text", DataSource, "23");
            lb24.DataBindings.Add("Text", DataSource, "24");
            lb25.DataBindings.Add("Text", DataSource, "25");
            lb26.DataBindings.Add("Text", DataSource, "26");
            lb27.DataBindings.Add("Text", DataSource, "27");
            lb28.DataBindings.Add("Text", DataSource, "28");
            lb29.DataBindings.Add("Text", DataSource, "29");
            lb30.DataBindings.Add("Text", DataSource, "30");

            lb31.DataBindings.Add("Text", DataSource, "31");
          
        }

        private void InBienBanQT_BeforePrint(object sender, System.Drawing.Printing.PrintEventArgs e)
        {

        }

    }
}
