using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using DevExpress.XtraReports.UI;
using System.Data;
using SystemManageService;
namespace MTCSYT.Report
{
    public partial class InBieuTong_LS : DevExpress.XtraReports.UI.XtraReport
    {
        CBDN.DB_CBDNDataContext db = new CBDN.DB_CBDNDataContext(new CBDN.ADOController().strcn());
        public InBieuTong_LS(int chinhanh, int ma_dviqly, int thang, int nam, bool GiaoKy, bool NhanKy, string userKyGiao, string userKyNhan, string tenDonvi, int loai)
        {
            InitializeComponent();
            xlThangNam.Text = "Tháng " + DateTime.Now.Month + " Năm " + DateTime.Now.Year;
            lbDLNhanKy.Text = tenDonvi.ToUpper();
            if (loai == 0)
            {
                var lst = db.db_GetSanLuongIDGiaoNhan_LS(ma_dviqly, chinhanh, thang, nam);
                foreach (var chitiet in lst)
                {
                    string tendvBC = "";
                    if (!tenDonvi.Contains("TỔNG CÔNG TY ĐIỆN LỰC MIỀN BẮC")) tendvBC = tenDonvi;
                    else if (!chitiet.dvGiao.Contains("TỔNG CÔNG TY ĐIỆN LỰC MIỀN BẮC"))
                        tendvBC = chitiet.dvGiao;
                    else if (!chitiet.dvNhan.Contains("TỔNG CÔNG TY ĐIỆN LỰC MIỀN BẮC"))
                        tendvBC = chitiet.dvNhan;
                    lbDonvi.Text = tendvBC;
                    xlGhiChu1.Text = "Sản lượng điện năng giao nhận tháng " + thang + " năm " + nam + " giữa " + chitiet.dvGiao + " với " + chitiet.dvNhan + " như sau:";
                    xlGhiChu2.Text = "1. Tổng sản lượng " + chitiet.dvGiao + " Giao cho " + chitiet.dvNhan + " trong tháng:";
                    xlGhiChu3.Text = "2. Tổng sản lượng " + chitiet.dvGiao + " nhận từ " + chitiet.dvNhan + " trong tháng:";
                    lbDLNhanKy.Text = chitiet.dvGiao + "";
                    lbDLGiaoKy.Text = chitiet.dvNhan + "";
                    xlBieu1G.Text = chitiet.Giao_Bieu1_SanLuong + "";
                    xlBieu2G.Text = chitiet.Giao_Bieu2_SanLuong + "";
                    xlBieu3G.Text = chitiet.Giao_Bieu3_SanLuong + "";
                    xlTongSLuongG.Text = (chitiet.Giao_Bieu1_SanLuong + chitiet.Giao_Bieu2_SanLuong + chitiet.Giao_Bieu3_SanLuong) + "";

                    xlB1N.Text = chitiet.Nhan_Bieu1_SanLuong + "";
                    xlB2N.Text = chitiet.Nhan_Bieu2_SanLuong + "";
                    xlB3N.Text = chitiet.Nhan_Bieu3_SanLuong + "";
                    xlTongSlgN.Text = (chitiet.Nhan_Bieu1_SanLuong + chitiet.Nhan_Bieu2_SanLuong + chitiet.Nhan_Bieu3_SanLuong ) + "";

                    break;
                }
                var lst1Gia = db.db_GetSanLuongIDGiaoNhan_1Gia_LS(ma_dviqly, chinhanh, thang, nam);

                foreach (var chitiet in lst1Gia)
                {
                    xlCongTo1G.Text = (chitiet.Giao_Bieu1_SanLuong + chitiet.Giao_Bieu2_SanLuong + chitiet.Giao_Bieu3_SanLuong) + "";
                    xlCto1N.Text = (chitiet.Nhan_Bieu1_SanLuong + chitiet.Nhan_Bieu2_SanLuong + chitiet.Nhan_Bieu3_SanLuong) + "";

                    break;
                }
                if (GiaoKy || NhanKy)
                {
                    xldaKyGiao.Text = "Đã ký";
                    xlDaKyNhan.Text = "Đã ký";
                }
                xlTongSlgN.Text = (decimal.Parse(xlTongSlgN.Text) + decimal.Parse(xlCto1N.Text)) + "";
                xlTongSLuongG.Text = (decimal.Parse(xlTongSLuongG.Text) + decimal.Parse(xlCongTo1G.Text)) + "";
            }
            else
            {
                var lst = db.db_CHOT_GetSanLuongIDGiaoNhan(ma_dviqly, chinhanh, thang, nam);
                foreach (var chitiet in lst)
                {
                    string tendvBC = "";
                    if (!tenDonvi.Contains("TỔNG CÔNG TY ĐIỆN LỰC MIỀN BẮC")) tendvBC = tenDonvi;
                    else if (!chitiet.dvGiao.Contains("TỔNG CÔNG TY ĐIỆN LỰC MIỀN BẮC"))
                        tendvBC = chitiet.dvGiao;
                    else if (!chitiet.dvNhan.Contains("TỔNG CÔNG TY ĐIỆN LỰC MIỀN BẮC"))
                        tendvBC = chitiet.dvNhan;
                    lbDonvi.Text = tendvBC;
                    xlGhiChu1.Text = "Sản lượng điện năng giao nhận tháng " + thang + " năm " + nam + " giữa " + chitiet.dvGiao + " với " + chitiet.dvNhan + " như sau:";
                    xlGhiChu2.Text = "1. Tổng sản lượng " + chitiet.dvGiao + " Giao cho " + chitiet.dvNhan + " trong tháng:";
                    xlGhiChu3.Text = "2. Tổng sản lượng " + chitiet.dvGiao + " nhận từ " + chitiet.dvNhan + " trong tháng:";
                    lbDLNhanKy.Text = chitiet.dvGiao + "";
                    lbDLGiaoKy.Text = chitiet.dvNhan + "";
                    xlBieu1G.Text = chitiet.Giao_Bieu1_SanLuong + "";
                    xlBieu2G.Text = chitiet.Giao_Bieu2_SanLuong + "";
                    xlBieu3G.Text = chitiet.Giao_Bieu3_SanLuong + "";
                    xlTongSLuongG.Text = (chitiet.Giao_Bieu1_SanLuong + chitiet.Giao_Bieu2_SanLuong + chitiet.Giao_Bieu3_SanLuong) + "";

                    xlB1N.Text = chitiet.Nhan_Bieu1_SanLuong + "";
                    xlB2N.Text = chitiet.Nhan_Bieu2_SanLuong + "";
                    xlB3N.Text = chitiet.Nhan_Bieu3_SanLuong + "";
                    xlTongSlgN.Text = (chitiet.Nhan_Bieu1_SanLuong + chitiet.Nhan_Bieu2_SanLuong + chitiet.Nhan_Bieu3_SanLuong) + "";

                    break;
                }
                var lst1Gia = db.db_GetSanLuongIDGiaoNhan_1Gia_LS(ma_dviqly, chinhanh, thang, nam);

                foreach (var chitiet in lst1Gia)
                {
                    xlCongTo1G.Text = (chitiet.Giao_Bieu1_SanLuong + chitiet.Giao_Bieu2_SanLuong + chitiet.Giao_Bieu3_SanLuong) + "";
                    xlCto1N.Text = (chitiet.Nhan_Bieu1_SanLuong + chitiet.Nhan_Bieu2_SanLuong + chitiet.Nhan_Bieu3_SanLuong) + "";

                    break;
                }
                if (GiaoKy || NhanKy)
                {
                    xldaKyGiao.Text = "Đã ký";
                    xlDaKyNhan.Text = "Đã ký";
                }
                xlTongSlgN.Text = (decimal.Parse(xlTongSlgN.Text) + decimal.Parse(xlCto1N.Text)) + "";
                xlTongSLuongG.Text = (decimal.Parse(xlTongSLuongG.Text) + decimal.Parse(xlCongTo1G.Text)) + "";
            }
        }

        private void InBienBanQT_BeforePrint(object sender, System.Drawing.Printing.PrintEventArgs e)
        {

        }

    }
}
