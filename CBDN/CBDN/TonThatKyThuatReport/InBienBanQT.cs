using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using DevExpress.XtraReports.UI;
using System.Data;
using SystemManageService;
namespace MTCSYT.TonThatKyThuatReport
{
    public partial class InBienBanQT : DevExpress.XtraReports.UI.XtraReport
    {

        public InBienBanQT(DataTable dttram, DataTable dtKhang, string thang, string nam, string Ma_dvi)
        {
            InitializeComponent();
            string tentram = "Tên Trạm: " + dttram.Rows[0]["TEN_TRAM"] + "";
            lbMaTram.Text = "Mã Trạm: " + dttram.Rows[0]["MA_TRAM"] + "";
            lbTenTram.Text = tentram.ToUpper();
            //lbDoanhSo.Text = "Doanh Số: " + dttram.Rows[0]["DINH_DANH"] + "";
            lbCongSuat.Text = "Công Suất (kVA): " + dttram.Rows[0]["CSUAT_TRAM"] + "";
            lbSoNO.Text = "Số NO: " + dttram.Rows[0]["SO_CTO"] + "";
            lbHanKiemDinh.Text = "Ngày Kiểm Định: " + dttram.Rows[0]["NGAY_KDINH"] + ""; ;
            lbDNT1.Text = dttram.Rows[0]["SL_1"] + "";
            lbDNT2.Text = dttram.Rows[0]["SL_2"] + "";
            lbDNT3.Text = dttram.Rows[0]["SL_3"] + "";
            lbTLT1.Text = dttram.Rows[0]["TT_TL1"] + "";
            lbTLT2.Text = dttram.Rows[0]["TT_TL2"] + "";
            lbTLT3.Text = dttram.Rows[0]["TT_TL3"] + "";
            lbDNTT.Text = "DNTT KH (kWh): " + dttram.Rows[0]["DNTTKH"] + "";
            lbTT.Text = "DN Tổn Thất (kWh): " + dttram.Rows[0]["DNTT"] + "";
            lbHSN.Text = "HSN: " + dttram.Rows[0]["HSN"] + "";
            TongKHang.Text = "Tổng khách hàng: " + dtKhang.Rows.Count + "";

            DetailReport.Report.DataSource = dtKhang;

            //khSTT.DataBindings.Add("Text", DataSource, "STT");
            khMaKHang.DataBindings.Add("Text", DataSource, "MAKHACHHANG");
            khTenKhang.DataBindings.Add("Text", DataSource, "TENKHACHHANG");
            khDiaChi.DataBindings.Add("Text", DataSource, "DIACHI");
            khLoaiCT.DataBindings.Add("Text", DataSource, "MA_CLOAI");
            khSoCT.DataBindings.Add("Text", DataSource, "SO_CTO");
            khSoHo.DataBindings.Add("Text", DataSource, "SOHO");
            khMaNN.DataBindings.Add("Text", DataSource, "MA_NN");
            lbHanKH.DataBindings.Add("Text", DataSource, "HANKD");
            khCSMoi.DataBindings.Add("Text", DataSource, "SAN_LUONG");
            khSL_1.DataBindings.Add("Text", DataSource, "SLUONG_1");
            khSL_2.DataBindings.Add("Text", DataSource, "SLUONG_2");
            khSL_3.DataBindings.Add("Text", DataSource, "SLUONG_3");
            lbDXuat.DataBindings.Add("Text", DataSource, "DX_CANH_BAO");
            khCanhBao.DataBindings.Add("Text", DataSource, "CANH_BAO");

            cb_TRAM.Text = "Trạm Bình Thường";
            cb_PhuongPhap.Text = "";
            dxDeXuat1.Text = "1. Xử lý bán kính lưới điện; Xử lý cân pha";
            dxDeXuat2.Text = "2.Thực hiện kiểm tra sử dụng điện các khách hàng, lưu ý các khách hàng có cảnh báo về đề xuất tại phần phân tích Công tơ khách hàng";
        
    } 

    }
}
