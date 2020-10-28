using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using DevExpress.XtraReports.UI;
using System.Data;
using SystemManageService;
namespace MTCSYT.TonThatKyThuatReport
{
    public partial class InBienTTKD : DevExpress.XtraReports.UI.XtraReport
    {

        public InBienTTKD(DataTable dttram, DataTable dtKhang, string thang, string nam, string Ma_dvi)
        {
           
            InitializeComponent();
            string tentram = dttram.Rows[0]["TEN_TRAM"]+"";
            lbMaTram.Text = Ma_dvi.ToUpper();
            lbTenTram.Text = tentram.ToUpper();
            lbDoanhSo.Text = "0";
            lbCongSuat.Text = dttram.Rows[0]["CSUAT_TRAM"] + "";
            lbSoNO.Text = "0";
            lbHanKiemDinh.Text = "0";
            lbDNT1.Text = dttram.Rows[0]["DNTT1"] + "";
            lbDNT2.Text = dttram.Rows[0]["DNTT2"] + "";
            lbDNT3.Text = dttram.Rows[0]["DNTT3"] + "";
            lbTLT1.Text = dttram.Rows[0]["DNTT_TL1"] + "";
            lbTLT2.Text = dttram.Rows[0]["DNTT_TL2"] + "";
            lbTLT3.Text = dttram.Rows[0]["DNTT_TL3"] + "";
            lbDNTT.Text = dttram.Rows[0]["CUOIKY"] + "";
            lbTT.Text = dttram.Rows[0]["TONTHAT"] + "";
            lbHSN.Text = "0";
            lbCSMtram.Text = "0";

            Detail.Report.DataSource = dtKhang;

            khSTT.DataBindings.Add("Text", DataSource, "STT");
            khMaKHang.DataBindings.Add("Text", DataSource, "MA_KHANG");
            khTenKhang.DataBindings.Add("Text", DataSource, "TENKHACHHANG");
            khDiaChi.DataBindings.Add("Text", DataSource, "DIACHI");
            khLoaiCT.DataBindings.Add("Text", DataSource, "MA_CLOAI");
            khSoCT.DataBindings.Add("Text", DataSource, "SO_CTO");
            //khSoHo.DataBindings.Add("Text", DataSource, "SO_HO");
            khMaNN.DataBindings.Add("Text", DataSource, "MA_NN");
            //khDM.DataBindings.Add("Text", DataSource, "D_M");
            khCSMoi.DataBindings.Add("Text", DataSource, "CHISO_MOI");
            khSL_1.DataBindings.Add("Text", DataSource, "SLUONG_1");
            khSL_2.DataBindings.Add("Text", DataSource, "SLUONG_2");
            khSL_3.DataBindings.Add("Text", DataSource, "SLUONG_3");
            //khPhienLT.DataBindings.Add("Text", DataSource, "PHIEN_LT");
            //khCL.DataBindings.Add("Text", DataSource, "C_L");
            //khVT.DataBindings.Add("Text", DataSource, "V_T");
            //khCanhBao.DataBindings.Add("Text", DataSource, "CANh_BAO");

            cb_TRAM.Text = "Trạm Bình Thường";
            cb_PhuongPhap.Text = "";
            dxDeXuat1.Text = "1. Xử lý bán kính lưới điện; Xử lý cân pha";
            dxDeXuat2.Text = "2.Thực hiện kiểm tra sử dụng điện các khách hàng, lưu ý các khách hàng có cảnh báo về đề xuất tại phần phân tích Công tơ khách hàng";
        }

    }
}
