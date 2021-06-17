using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using DevExpress.XtraReports.UI;
using System.Data;
using SystemManageService;
namespace MTCSYT.Report
{
    public partial class InBaoCaoB5_Quy : DevExpress.XtraReports.UI.XtraReport
    {

        public InBaoCaoB5_Quy(DataTable dsdt, string quy, string nam)
        {
            CBDN.cl_class.clChuyenSoThanhChu clChuyenSo = new CBDN.cl_class.clChuyenSoThanhChu();
            InitializeComponent();
           
            
            Detail.Report.DataSource = dsdt;

            xlSTT.DataBindings.Add("Text", DataSource, "STT");
            xlTen_Cty.DataBindings.Add("Text", DataSource, "Ten_Cty");
            xlB1_TieuThu.DataBindings.Add("Text", DataSource, "B1_TieuThu");
            xlB2_TieuThu.DataBindings.Add("Text", DataSource, "B2_TieuThu");
            xlB3_TieuThu.DataBindings.Add("Text", DataSource, "B3_TieuThu");
            xlTong_TieuThu.DataBindings.Add("Text", DataSource, "Tong_TieuThu");

            xrAB_N_TD.Text = string.Format("{0:N0} ", dsdt.Compute("sum([B1])", ""));
            xrAB_N_1Gia.Text = string.Format("{0:N0} ", dsdt.Compute("sum([B2])", ""));
            xrAB_N_TC.Text = string.Format("{0:N0} ", dsdt.Compute("sum([B3])", ""));
            xrAB_N_CD.Text = string.Format("{0:N0} ", dsdt.Compute("sum([Tong])", ""));

          
         

            lbTieude.Text = @"BẢNG TỔNG HỢP ĐIỆN MUA CỦA CÁC CÔNG TY ĐIỆN LỰC";

        

            lbThangNam.Text = " Quý " + quy + " Năm " + nam + ".";
            nguoilap.Text = @"Người lập biểu";
            TruongBan.Text = @"KT. TRƯỞNG BAN";
            ptb.Text = @"PHÓ TRƯỞNG BAN";
        }

    }
}
