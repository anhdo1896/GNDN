using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using DevExpress.XtraReports.UI;
using System.Data;
using SystemManageService;
namespace MTCSYT.Report
{
    public partial class InChiTiet : DevExpress.XtraReports.UI.XtraReport
    {

        public InChiTiet(DataTable dt, string thang, string nam, bool GiaoKy, bool NhanKy, string userKyGiao, string userKyNhan, string tenDonvi)
        {
            InitializeComponent();

            lbDLNhanKy.Text = tenDonvi.ToUpper();
            Detail.Report.DataSource = dt;

            xlSTT.DataBindings.Add("Text", DataSource, "STT");
            xlDonViGiaoNhan.DataBindings.Add("Text", DataSource, "TenDonVi");
            xlN_BT.DataBindings.Add("Text", DataSource, "Nhan_Bieu1_SanLuong");
            xlN_CD.DataBindings.Add("Text", DataSource, "Nhan_Bieu2_SanLuong");
            xlN_TD.DataBindings.Add("Text", DataSource, "Nhan_Bieu3_SanLuong");
            xlN_1Gia.DataBindings.Add("Text", DataSource, "Nhan1Gia");
            xlTongCong.DataBindings.Add("Text", DataSource, "TongNhan3B");
            xlGiaoBinhThuong.DataBindings.Add("Text", DataSource, "Giao_Bieu1_SanLuong");
            xlG_CD.DataBindings.Add("Text", DataSource, "Giao_Bieu2_SanLuong");
            xlG_TD.DataBindings.Add("Text", DataSource, "Giao_Bieu3_SanLuong");
            xlG_1Gia.DataBindings.Add("Text", DataSource, "Giao1Gia");
            xlDN_BT.DataBindings.Add("Text", DataSource, "B1_TieuThu");
            xlDN_CD.DataBindings.Add("Text", DataSource, "B2_TieuThu");
            xlDN_TD.DataBindings.Add("Text", DataSource, "B3_TieuThu");
            xlDN_1Gia.DataBindings.Add("Text", DataSource, "Tong1Gia");
            lbTieude.Text = @"BIÊN BẢN QUYẾT TOÁN 
                              ĐIỆN NĂNG MUA BÁN GIỮA TỔNG CÔNG TY ĐIỆN LỰC MIỀN BẮC VỚI " + tenDonvi.ToUpper();
            lbThangNam.Text = " Tháng " + thang + " Năm " + nam + ".";
            if (GiaoKy)
            {
                xlKyTen.Text = userKyNhan.ToUpper();
                xldaKyGiao.Text = "Đã ký";
            }
            if (NhanKy)
            {
                xlTenNguoiKy.Text = userKyNhan.ToUpper();
                xlDaKyNhan.Text = "Đã ký";
            }
        }

        private void InBienBanQT_BeforePrint(object sender, System.Drawing.Printing.PrintEventArgs e)
        {

        }

    }
}
