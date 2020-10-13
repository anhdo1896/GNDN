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

        public InBienBanQT(DataTable dt, string thang, string nam, bool GiaoKy, bool NhanKy, string userKyGiao, string userKyNhan, string tenDonviGiao, String TenDVNhan, string strImTPNhan, string strImTPGiao, string strImGDNhan, string strImGDGiao)
        {
            CBDN.cl_class.clChuyenSoThanhChu clChuyenSo = new CBDN.cl_class.clChuyenSoThanhChu();
            InitializeComponent();
            /*
            lbDLGiaoKy.Text = tenDonviGiao.ToUpper();
            lbDLNhanKy.Text = TenDVNhan.ToUpper();
            //imTPNhan.ImageUrl = strImTPNhan;
            //imTPGiao.ImageUrl = strImTPGiao;
            //imGDNhan.ImageUrl = strImGDNhan;
            //imGDGiao.ImageUrl = strImGDGiao;

            //lbkyNhan.Text = "Đã ký: Người ký " + strImGDNhan ;
            //lbKyGiao.Text = "Đã ký: Người ký " + strImGDGiao;
                if (strImGDNhan != "")
                rTNhan.Html = "<span align='center' style='color:red;font-weight:bold'>Người ký: " + strImGDNhan + "</span>";
            if (strImGDGiao != "")
                rTGiao.Html = "<span align='center' style='color:red;font-weight:bold'>Người ký: " + strImGDGiao + "</span>";

            */
            Detail.Report.DataSource = dt;
            /*
            xlSTT.DataBindings.Add("Text", DataSource, "STT");
            xlDonViGiaoNhan.DataBindings.Add("Text", DataSource, "TenDonVi");
            xlN_BT.DataBindings.Add("Text", DataSource, "Nhan_Bieu1_SanLuong1");
            xlN_CD.DataBindings.Add("Text", DataSource, "Nhan_Bieu2_SanLuong1");
            xlN_TD.DataBindings.Add("Text", DataSource, "Nhan_Bieu3_SanLuong1");
            xlN_1Gia.DataBindings.Add("Text", DataSource, "Nhan1Gia1");
            xlTongCong.DataBindings.Add("Text", DataSource, "TongNhan3B1");
            xlGiaoBinhThuong.DataBindings.Add("Text", DataSource, "Giao_Bieu1_SanLuong1");
            xlG_CD.DataBindings.Add("Text", DataSource, "Giao_Bieu2_SanLuong1");
            xlG_TD.DataBindings.Add("Text", DataSource, "Giao_Bieu3_SanLuong1");
            xlG_1Gia.DataBindings.Add("Text", DataSource, "Giao1Gia1");
            xlG_TongCong.DataBindings.Add("Text", DataSource, "TongGiao3B1");
            xlDN_BT.DataBindings.Add("Text", DataSource, "B1_TieuThu1");
            xlDN_CD.DataBindings.Add("Text", DataSource, "B2_TieuThu1");
            xlDN_TD.DataBindings.Add("Text", DataSource, "B3_TieuThu1");
            xlDN_1Gia.DataBindings.Add("Text", DataSource, "Tong1Gia1");
            xlDN_TongCong.DataBindings.Add("Text", DataSource, "Tong_TieuThu1");

            xlTN_BT.Text =  string.Format("{0:N0} ", dt.Compute("sum(Nhan_Bieu1_SanLuong)", "Loai>0")).Replace(",",".");
            xlTN_CD.Text = string.Format("{0:N0} ", dt.Compute("sum(Nhan_Bieu2_SanLuong)", "Loai>0")).Replace(",", ".");
            xl_TNTD.Text = string.Format("{0:N0} ", dt.Compute("sum(Nhan_Bieu3_SanLuong)", "Loai>0")).Replace(",", ".");
            xlTN1Gia.Text = string.Format("{0:N0} ", dt.Compute("sum(Nhan1Gia)", "1=1")).Replace(",", ".");
            xlTNTongCong.Text = string.Format("{0:N0} ", dt.Compute("sum(TongNhan3B)", "Loai>0")).Replace(",", ".");

            xlTG_BT.Text = string.Format("{0:N0} ", dt.Compute("sum(Giao_Bieu1_SanLuong)", "Loai>0")).Replace(",", ".");
            xlTG_CD.Text = string.Format("{0:N0} ", dt.Compute("sum(Giao_Bieu2_SanLuong)", "Loai>0")).Replace(",", ".");
            xlTG_TD.Text = string.Format("{0:N0} ", dt.Compute("sum(Giao_Bieu3_SanLuong)", "Loai>0")).Replace(",", ".");
            xlTG_1Gia.Text = string.Format("{0:N0} ", dt.Compute("sum(Giao1Gia)", "Loai>0")).Replace(",", ".");
            xlTG_TongCong.Text = string.Format("{0:N0} ", dt.Compute("sum(TongGiao3B)", "Loai>0")).Replace(",", ".");

            xlTDN_BT.Text = string.Format("{0:N0} ", dt.Compute("sum(B1_TieuThu)", "Loai>0")).Replace(",", ".");
            xlTDN_CD.Text = string.Format("{0:N0} ", dt.Compute("sum(B2_TieuThu)", "Loai>0")).Replace(",", ".");
            xlTDN_TD.Text = string.Format("{0:N0} ", dt.Compute("sum(B3_TieuThu)", "Loai>0")).Replace(",", ".");
            xlTDN_1Gia.Text = string.Format("{0:N0} ", dt.Compute("sum(Tong1Gia)", "Loai>0")).Replace(",", ".");
            xlTDN_TongCong.Text = string.Format("{0:N0} ", dt.Compute("sum(Tong_TieuThu)", "Loai>0")).Replace(",", ".");

            xrAB_N_BT.Text = string.Format("{0:N0} ", dt.Compute("sum(Nhan_Bieu1_SanLuong)", "Loai>0 and Loai<5 and Loai <> 3")).Replace(",", ".");
            xrAB_N_CD.Text = string.Format("{0:N0} ", dt.Compute("sum(Nhan_Bieu2_SanLuong)", "Loai>0 and Loai<5 and Loai <> 3")).Replace(",", ".");
            xrAB_N_TD.Text = string.Format("{0:N0} ", dt.Compute("sum(Nhan_Bieu3_SanLuong)", "Loai>0 and Loai<5 and Loai <> 3")).Replace(",", ".");
            xrAB_N_1Gia.Text = string.Format("{0:N0} ", dt.Compute("sum(Nhan1Gia)", "Loai>0 and Loai<5 and Loai <> 3")).Replace(",", ".");
            xrAB_N_TC.Text = string.Format("{0:N0} ", dt.Compute("sum(TongNhan3B)", "Loai>0 and Loai<5 and Loai <> 3")).Replace(",", ".");

            xrAB_G_BT.Text = string.Format("{0:N0} ", dt.Compute("sum(Giao_Bieu1_SanLuong)", "Loai>0 and Loai<5 and Loai <> 3")).Replace(",", ".");
            xrAB_G_CD.Text = string.Format("{0:N0} ", dt.Compute("sum(Giao_Bieu2_SanLuong)", "Loai>0 and Loai<5 and Loai <> 3")).Replace(",", ".");
            xrAB_G_TD.Text = string.Format("{0:N0} ", dt.Compute("sum(Giao_Bieu3_SanLuong)", "Loai>0 and Loai<5 and Loai <> 3")).Replace(",", ".");
            xrAB_G_1Gia.Text = string.Format("{0:N0} ", dt.Compute("sum(Giao1Gia)", "Loai>0 and Loai<5 and Loai <> 3")).Replace(",", ".");
            xrAB_G_TC.Text = string.Format("{0:N0} ", dt.Compute("sum(TongGiao3B)", "Loai>0 and Loai<5 and Loai <> 3")).Replace(",", ".");

            xrAB_TT_BT.Text = string.Format("{0:N0} ", dt.Compute("sum(B1_TieuThu)", "Loai>0 and Loai<5 and Loai <> 3")).Replace(",", ".");
            xrAB_TT_CD.Text = string.Format("{0:N0} ", dt.Compute("sum(B2_TieuThu)", "Loai>0 and Loai<5 and Loai <> 3")).Replace(",", ".");
            xrAB_TT_TD.Text = string.Format("{0:N0} ", dt.Compute("sum(B3_TieuThu)", "Loai>0 and Loai<5 and Loai <> 3")).Replace(",", ".");
            xrAB_TT_1Gia.Text = string.Format("{0:N0} ", dt.Compute("sum(Tong1Gia)", "Loai>0 and Loai<5 and Loai <> 3")).Replace(",", ".");
            xrAB_TT_TC.Text = string.Format("{0:N0} ", dt.Compute("sum(Tong_TieuThu)", "Loai>0 and Loai<5 and Loai <> 3")).Replace(",", ".");

            // lbDienNangMua.Text = "2. Điện năng mua của " + tenDonvi + " là: " + dt.Compute("sum(TongNhan3B)", "Loai=1 or Loai=2 or Loai=4").ToString() + "kWh     (A+C chiều nhận)";
            string tongKWh = dt.Compute("sum([Tong_TieuThu])", "[Loai]=1 or [Loai]=2 or [Loai]=4") + "";
            if (tongKWh != "")
                lbDienNangMua.Text = "2. Điện năng mua của " + tenDonviGiao + " là: " + string.Format("{0:N0} ", decimal.Parse(tongKWh)).Replace(",", ".") + "kWh (Bằng chữ: " + clChuyenSo.ChuyenSo(tongKWh.Replace("-", "")) + " kWh)";
            else
                lbDienNangMua.Text = "2. Điện năng mua của " + tenDonviGiao + " là: 0kWh (Bằng chữ: Không Kwh)";

            string Btchu = "Không", cdChu = "Không", TDChu = "Không";

            string bt = dt.Compute("sum([B1_TieuThu])", "[Loai]=1 or [Loai]=2 or [Loai]=4").ToString();
            string cd = dt.Compute("sum([B2_TieuThu])", "[Loai]=1 or [Loai]=2 or [Loai]=4").ToString();
            string td = dt.Compute("sum([B3_TieuThu])", "[Loai]=1 or [Loai]=2 or [Loai]=4").ToString();

            if (bt != "0" && bt != "")
            {
                Btchu = clChuyenSo.ChuyenSo(bt.ToString().Replace("-", "")); 
                lbBinhThuong.Text = "- Lượng điện năng mua theo giờ Bình thường: " + string.Format("{0:N0} ", decimal.Parse(bt)).Replace(",", ".") + "kWh (Bằng chữ: " + Btchu + " kWh)";
            } if (cd != "0" && cd != "")
            {
                cdChu = clChuyenSo.ChuyenSo(cd.ToString().Replace("-", "")); 
                lbCaoDiem.Text = "- Lượng điện năng mua theo giờ Cao điểm: " + string.Format("{0:N0} ", decimal.Parse(cd)).Replace(",", ".") + "kWh  (Bằng chữ: " + cdChu + " kWh)";
            } if (td != "0" && td != "")
            {
                TDChu = clChuyenSo.ChuyenSo(td.ToString().Replace("-", "")); 
                lbThapDiem.Text = "- Lượng điện năng mua theo giờ Thấp điểm: " + string.Format("{0:N0} ", decimal.Parse(td)).Replace(",", ".") + "kWh  (Bằng chữ: " + TDChu + " kWh)";
            }




            //lbBinhThuong.Text = "- Lượng điện năng mua theo giờ Bình thường: " + bt + "kWh " ; 
            //lbCaoDiem.Text = "- Lượng điện năng mua theo giờ Cao điểm: " + cd + "kWh ";
            //lbThapDiem.Text = "- Lượng điện năng mua theo giờ Thấp điểm: " + td + "kWh ";
            lbTieude.Text = @"BIÊN BẢN QUYẾT TOÁN 
                              ĐIỆN NĂNG MUA BÁN GIỮA " + tenDonviGiao.ToUpper() + " VỚI " + TenDVNhan.ToUpper();

            lbGhiChu1.Text = "- Căn cứ hợp đồng mua bán điện giữa " + tenDonviGiao + " với " + TenDVNhan;

            lbThangNam.Text = " Tháng " + thang + " Năm " + nam + ".";
            lbGhiChu2.Text = "- " + tenDonviGiao + " và " + TenDVNhan + " lập biên bản quyết toán điện năng tháng " + thang + " năm " + nam + " như sau:";
            */
        }

    }
}
