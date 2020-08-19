using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using DevExpress.XtraReports.UI;
using System.Data;
using SystemManageService;
namespace MTCSYT.Report
{
    public partial class InDienNhan3ThoiDiem : DevExpress.XtraReports.UI.XtraReport
    {

        public InDienNhan3ThoiDiem(DataTable dsdt, string thang, string nam, bool GiaoKy, bool NhanKy, string userKyGiao, string userKyNhan, string tenDonviGiao, String TenDVNhan, string strImTPNhan, string strImTPGiao, string strImGDNhan, string strImGDGiao)
        {
            CBDN.cl_class.clChuyenSoThanhChu clChuyenSo = new CBDN.cl_class.clChuyenSoThanhChu();
            InitializeComponent();
            //imTPNhan.ImageUrl = strImTPNhan;
            //imTPGiao.ImageUrl = strImTPGiao;
            //imGDNhan.ImageUrl = strImGDNhan;
            //imGDGiao.ImageUrl = strImGDGiao;

            //lbkyNhan.Text = "Đã ký: Người ký " + strImGDNhan ;
            //lbKyGiao.Text = "Đã ký: Người ký " + strImGDGiao;
            
            Detail.Report.DataSource = dsdt;

            xlSTT.DataBindings.Add("Text", DataSource, "STT");
            xlTen_Cty.DataBindings.Add("Text", DataSource, "Ten_Cty");
            xlB1_TieuThu.DataBindings.Add("Text", DataSource, "B1_TieuThu");
            xlB2_TieuThu.DataBindings.Add("Text", DataSource, "B2_TieuThu");
            xlB3_TieuThu.DataBindings.Add("Text", DataSource, "B3_TieuThu");
            xlTong_TieuThu.DataBindings.Add("Text", DataSource, "Tong_TieuThu");
            xlTyle_B1.DataBindings.Add("Text", DataSource, "Tyle_B1");
            xlTyle_B2.DataBindings.Add("Text", DataSource, "Tyle_B2");
            xlTyle_B3.DataBindings.Add("Text", DataSource, "Tyle_B3");

            xrAB_N_TD.Text = string.Format("{0:N0} ", dsdt.Compute("sum([B1])", ""));
            xrAB_N_1Gia.Text = string.Format("{0:N0} ", dsdt.Compute("sum([B2])", ""));
            xrAB_N_TC.Text = string.Format("{0:N0} ", dsdt.Compute("sum([B3])", ""));
            xrAB_N_CD.Text = string.Format("{0:N0} ", dsdt.Compute("sum([Tong])", ""));

            
            decimal a = (decimal)dsdt.Compute("sum([Tyle_B1])", "");
            decimal b = (decimal)dsdt.Compute("sum([Tyle_B2])", "");
            decimal c = (decimal)dsdt.Compute("sum([Tyle_B3])", "");
            
            a = a / 27;
            b = b / 27;
            c = c / 27;
            a = Math.Round(a, 2);
            b = Math.Round(b, 2);
            c = Math.Round(c, 2);
            xrAB_G_BT.Text = a+"";
            xrTableCell9.Text = b + "";
            xrAB_G_CD.Text = c + "";

            lbTieude.Text = @"BÁO CÁO ĐIỆN NHẬN 3 THỜI ĐIỂM ";

        

            lbThangNam.Text = " Tháng " + thang + " Năm " + nam + ".";
           
        }

    }
}
