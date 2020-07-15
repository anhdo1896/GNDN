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
    public partial class InBieuTong : DevExpress.XtraReports.UI.XtraReport
    {
        CBDN.DB_CBDNDataContext db = new CBDN.DB_CBDNDataContext(new CBDN.ADOController().strcn());
        public InBieuTong(int chinhanh, int ma_dviqly, int thang, int nam, string userKyGiao, string userKyNhan, string tenDonvi, string DVGiao, string DVNhan, int loai, string strImTPNhan, string strImTPGiao, string strImGDNhan, string strImGDGiao)
        {
            InitializeComponent();
            if (chinhanh == 0) return;
            if (strImGDNhan != "")
                rTNhan.Html = "<span align='center' style='color:red;font-weight:bold'> Đã ký: Người ký " + strImGDNhan + "</span>";
            if (strImGDGiao != "")
                rTGiao.Html = "<span align='center' style='color:red;font-weight:bold'>Đã ký: Người ký " + strImGDGiao + "</span>";

            xlThangNam.Text = "Tháng " + DateTime.Now.Month + " Năm " + DateTime.Now.Year;
            // lbDLNhanKy.Text = DVNhan.ToUpper();
            lbDLNhanKy.Text = DVNhan;
            lbDLGiaoKy.Text = DVGiao;
            var cnList = db.DM_ChiNhanhs.SingleOrDefault(x => x.ID == chinhanh);
            var giao = db.DM_DVQLies.SingleOrDefault(x => x.IDMA_DVIQLY == cnList.DiemDauNguon);
            var nhan = db.DM_DVQLies.SingleOrDefault(x => x.IDMA_DVIQLY == cnList.DiemCuoiNguon);

            if (nhan.IDMA_DVIQLY != 2)
                lbDonvi.Text = nhan.TEN_DVIQLY;
            else
                lbDonvi.Text = giao.TEN_DVIQLY;

            if (loai == 0)
            {
                var lst = db.db_GetSanLuongIDGiaoNhan(ma_dviqly, chinhanh, thang, nam);
                foreach (var chitiet in lst)
                {
                    string tendvBC = "";
                    if (!tenDonvi.Contains("TỔNG CÔNG TY ĐIỆN LỰC MIỀN BẮC")) tendvBC = tenDonvi;
                    else if (!chitiet.dvGiao.Contains("TỔNG CÔNG TY ĐIỆN LỰC MIỀN BẮC"))
                        tendvBC = chitiet.dvGiao;
                    else if (!chitiet.dvNhan.Contains("TỔNG CÔNG TY ĐIỆN LỰC MIỀN BẮC"))
                        tendvBC = chitiet.dvNhan;
                    //lbDonvi.Text = tendvBC;
                    xlGhiChu1.Text = "Sản lượng điện năng giao nhận tháng " + thang + " năm " + nam + " giữa " + chitiet.dvGiao + " với " + chitiet.dvNhan + " như sau:";
                    xlGhiChu2.Text = "1. Tổng sản lượng " + chitiet.dvGiao + " Giao cho " + chitiet.dvNhan + " trong tháng:";
                    xlGhiChu3.Text = "2. Tổng sản lượng " + chitiet.dvGiao + " nhận từ " + chitiet.dvNhan + " trong tháng:";

                    xlBieu1G.Text = string.Format("{0:N0} ", chitiet.Giao_Bieu1_SanLuong).Replace(",", ".");
                    xlBieu2G.Text = string.Format("{0:N0} ", chitiet.Giao_Bieu2_SanLuong).Replace(",", ".");
                    xlBieu3G.Text = string.Format("{0:N0} ", chitiet.Giao_Bieu3_SanLuong).Replace(",", ".");
                    xlTongSLuongG.Text = (chitiet.Giao_Bieu1_SanLuong + chitiet.Giao_Bieu2_SanLuong + chitiet.Giao_Bieu3_SanLuong).ToString().Replace(",", ".");

                    xlB1N.Text = string.Format("{0:N0} ", chitiet.Nhan_Bieu1_SanLuong).Replace(",", ".");
                    xlB2N.Text = string.Format("{0:N0} ", chitiet.Nhan_Bieu2_SanLuong).Replace(",", ".");
                    xlB3N.Text = string.Format("{0:N0} ", chitiet.Nhan_Bieu3_SanLuong).Replace(",", ".");
                    xlTongSlgN.Text = (chitiet.Nhan_Bieu1_SanLuong + chitiet.Nhan_Bieu2_SanLuong + chitiet.Nhan_Bieu3_SanLuong).ToString().Replace(",", ".");

                    break;
                }
                var lst1Gia = db.db_GetSanLuongIDGiaoNhan_1Gia(ma_dviqly, chinhanh, thang, nam);

                foreach (var chitiet in lst1Gia)
                {
                    xlCongTo1G.Text =(chitiet.Giao_Bieu1_SanLuong + chitiet.Giao_Bieu2_SanLuong + chitiet.Giao_Bieu3_SanLuong).ToString().Replace(",", ".");
                    xlCto1N.Text = (chitiet.Nhan_Bieu1_SanLuong + chitiet.Nhan_Bieu2_SanLuong + chitiet.Nhan_Bieu3_SanLuong).ToString().Replace(",", ".");

                    break;
                }
                //if (GiaoKy || NhanKy)
                //{
                //    xldaKyGiao.Text = "Đã ký";
                //    xlDaKyNhan.Text = "Đã ký";
                //}
                xlTongSlgN.Text =string.Format("{0:N0} ", (decimal.Parse(xlTongSlgN.Text) + decimal.Parse(xlCto1N.Text)) ).Replace(",", ".");
                xlTongSLuongG.Text =string.Format("{0:N0} ", (decimal.Parse(xlTongSLuongG.Text) + decimal.Parse(xlCongTo1G.Text)) ).Replace(",", ".");
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
                    //lbDonvi.Text = tendvBC;
                    xlGhiChu1.Text = "Sản lượng điện năng giao nhận tháng " + thang + " năm " + nam + " giữa " + chitiet.dvGiao + " với " + chitiet.dvNhan + " như sau:";
                    xlGhiChu2.Text = "1. Tổng sản lượng " + chitiet.dvGiao + " Giao cho " + chitiet.dvNhan + " trong tháng:";
                    xlGhiChu3.Text = "2. Tổng sản lượng " + chitiet.dvGiao + " nhận từ " + chitiet.dvNhan + " trong tháng:";
                   
                    xlBieu1G.Text = string.Format("{0:N0} ",chitiet.Giao_Bieu1_SanLuong ).Replace(",", ".");
                    xlBieu2G.Text = string.Format("{0:N0} ",chitiet.Giao_Bieu2_SanLuong ).Replace(",", ".");
                    xlBieu3G.Text = string.Format("{0:N0} ",chitiet.Giao_Bieu3_SanLuong ).Replace(",", ".");
                    xlTongSLuongG.Text =(chitiet.Giao_Bieu1_SanLuong + chitiet.Giao_Bieu2_SanLuong + chitiet.Giao_Bieu3_SanLuong).ToString().Replace(",", ".");

                    xlB1N.Text = string.Format("{0:N0} ",chitiet.Nhan_Bieu1_SanLuong ).Replace(",", ".");
                    xlB2N.Text = string.Format("{0:N0} ",chitiet.Nhan_Bieu2_SanLuong ).Replace(",", ".");
                    xlB3N.Text = string.Format("{0:N0} ",chitiet.Nhan_Bieu3_SanLuong ).Replace(",", ".");
                    xlTongSlgN.Text = (chitiet.Nhan_Bieu1_SanLuong + chitiet.Nhan_Bieu2_SanLuong + chitiet.Nhan_Bieu3_SanLuong).ToString().Replace(",", ".");

                    break;
                }
                var lst1Gia = db.db_GetSanLuongIDGiaoNhan_1Gia(ma_dviqly, chinhanh, thang, nam);

                foreach (var chitiet in lst1Gia)
                {
                    xlCongTo1G.Text =(chitiet.Giao_Bieu1_SanLuong + chitiet.Giao_Bieu2_SanLuong + chitiet.Giao_Bieu3_SanLuong).ToString().Replace(",", ".");
                    xlCto1N.Text =(chitiet.Nhan_Bieu1_SanLuong + chitiet.Nhan_Bieu2_SanLuong + chitiet.Nhan_Bieu3_SanLuong).ToString().Replace(",", ".");

                    break;
                }
                //if (GiaoKy || NhanKy)
                //{
                //    xldaKyGiao.Text = "Đã ký";
                //    xlDaKyNhan.Text = "Đã ký";
                //}
                xlTongSlgN.Text =string.Format("{0:N0} ", (decimal.Parse(xlTongSlgN.Text) + decimal.Parse(xlCto1N.Text)) ).Replace(",", ".");
                xlTongSLuongG.Text =string.Format("{0:N0} ", (decimal.Parse(xlTongSLuongG.Text) + decimal.Parse(xlCongTo1G.Text)) ).Replace(",", ".");
            }
        }

        private void InBienBanQT_BeforePrint(object sender, System.Drawing.Printing.PrintEventArgs e)
        {

        }

    }
}
