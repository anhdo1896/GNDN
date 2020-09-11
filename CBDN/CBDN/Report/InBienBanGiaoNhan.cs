using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using DevExpress.XtraReports.UI;
using System.Data;
using SystemManageService;
namespace MTCSYT.Report
{
    public partial class InBienBanGiaoNhan : DevExpress.XtraReports.UI.XtraReport
    {

        public InBienBanGiaoNhan(DataTable dt, string thang, string nam, bool GiaoKy, bool NhanKy, string userKyGiao, string userKyNhan, string tenDonviGiao, String TenDVNhan, string strImTPNhan, string strImTPGiao, string strImGDNhan, string strImGDGiao)
        {
            CBDN.cl_class.clChuyenSoThanhChu clChuyenSo = new CBDN.cl_class.clChuyenSoThanhChu();
            InitializeComponent();
            lbDLGiaoKy.Text = tenDonviGiao.ToUpper();
            lbDLNhanKy.Text = TenDVNhan.ToUpper();

            if (strImGDNhan != "")
                rTNhan.Html = "<span align='center' style='color:red;font-weight:bold'> Đã ký: Người ký " + strImGDNhan + "</span>";
            if (strImGDGiao != "")
                rTGiao.Html = "<span align='center' style='color:red;font-weight:bold'>Đã ký: Người ký " + strImGDGiao + "</span>";

            DetailReport2.Report.DataSource = dt;
            //DetailReport1.Report.DataSource = dtnhan;

            xlSTT.DataBindings.Add("Text", DataSource, "STT");
            xlDonViGiao.DataBindings.Add("Text", DataSource, "TenDiemDo");
            xlGBT_DD.DataBindings.Add("Text", DataSource, "Bieu1_DoDem1");
            xlGCD_DD.DataBindings.Add("Text", DataSource, "Bieu2_DoDem1");
            xlGTD_DD.DataBindings.Add("Text", DataSource, "Bieu3_DoDem1");
            xl1GBT_DD.DataBindings.Add("Text", DataSource, "Tong_DoDem1");
            xl1GGia_DD.DataBindings.Add("Text", DataSource, "Gia1_DoDem1");
            xlGTC_DD.DataBindings.Add("Text", DataSource, "TC_DoDem1");

            xlG_TC_K.DataBindings.Add("Text", DataSource, "TC_kDoDem1");

            xlDN_BT.DataBindings.Add("Text", DataSource, "Bieu11");
            xlG_CD.DataBindings.Add("Text", DataSource, "Bieu21");
            xlG_TD.DataBindings.Add("Text", DataSource, "Bieu31");
            xlG_1Gia.DataBindings.Add("Text", DataSource, "Gia11");
            xlGBT_TD.DataBindings.Add("Text", DataSource, "Tong1");
            xlG_TC.DataBindings.Add("Text", DataSource, "TC1");

            xlDonViNhan.DataBindings.Add("Text", DataSource, "TenDiemDo");
            xlNBT_DD.DataBindings.Add("Text", DataSource, "Bieu1_DoDem1");
            xlNCD_DD.DataBindings.Add("Text", DataSource, "Bieu2_DoDem1");
            xlNTD_DD.DataBindings.Add("Text", DataSource, "Bieu3_DoDem1");
            xl1NBT_DD.DataBindings.Add("Text", DataSource, "Tong_DoDem1");
            xl1NGia_DD.DataBindings.Add("Text", DataSource, "Gia1_DoDem1");

            xlNTC_DD.DataBindings.Add("Text", DataSource, "TC_DoDem1");

            xlN_TC_K.DataBindings.Add("Text", DataSource, "TC_kDoDem1");
            xlN_BT.DataBindings.Add("Text", DataSource, "Bieu11");
            xlN_CD.DataBindings.Add("Text", DataSource, "Bieu21");
            xlN_TD.DataBindings.Add("Text", DataSource, "Bieu31");
            xlN_1Gia.DataBindings.Add("Text", DataSource, "Gia11");
            xlN_TC.DataBindings.Add("Text", DataSource, "TC1");

            //Tong giao
            xlTGBT_DD.Text = string.Format("{0:N0} ", dt.Compute("sum([Bieu1_DoDem])", "[Loai]=0"));
            xlTGCD_DD.Text = string.Format("{0:N0} ", dt.Compute("sum([Bieu2_DoDem])", "[Loai]=0"));
            xlTGTD_DD.Text = string.Format("{0:N0} ", dt.Compute("sum([Bieu3_DoDem])", "[Loai]=0"));
            xl1TGBT_DD.Text = string.Format("{0:N0} ", dt.Compute("sum([Tong_DoDem])", "[Loai]=0"));
            xlT1GGia_DD.Text = string.Format("{0:N0} ", dt.Compute("sum([Gia1_DoDem])", "[Loai]=0"));
            xlTGTC_DD.Text = string.Format("{0:N0} ", dt.Compute("sum([TC_DoDem])", "[Loai]=0"));


            xlTG_TC_K.Text = string.Format("{0:N0} ", dt.Compute("sum([TC_kDoDem])", "[Loai]=0"));

            xlTG_BT.Text = string.Format("{0:N0} ", dt.Compute("sum([Bieu1])", "[Loai]=0"));
            xlTG_CD.Text = string.Format("{0:N0} ", dt.Compute("sum([Bieu2])", "[Loai]=0"));
            xlTG_TD.Text = string.Format("{0:N0} ", dt.Compute("sum([Bieu3])", "[Loai]=0"));
            xlTGBT_TD.Text = string.Format("{0:N0} ", dt.Compute("sum([Tong])", "[Loai]=0"));
            xlTG_1Gia.Text = string.Format("{0:N0} ", dt.Compute("sum([Gia1])", "[Loai]=0"));
            xlTG_TC.Text = string.Format("{0:N0} ", dt.Compute("sum([TC])", "[Loai]=0"));

            /*
              xlTNBT_DD.Text = string.Format("{0:N0} ", dtnhan.Compute("sum([Bieu1_DoDem])", "[Loai]=1"));
              xlTNCD_DD.Text = string.Format("{0:N0} ", dtnhan.Compute("sum([Bieu2_DoDem])", "[Loai]=1"));
              xlTNTD_DD.Text = string.Format("{0:N0} ", dtnhan.Compute("sum([Bieu3_DoDem])", "[Loai]=1"));
              xlT1NBT_DD.Text = string.Format("{0:N0} ", dtnhan.Compute("sum([Tong_DoDem])", "[Loai]=1"));
              xlT1NGia_DD.Text = string.Format("{0:N0} ", dtnhan.Compute("sum([Gia1_DoDem])", "[Loai]=1"));
              xlNTTC_DD.Text = string.Format("{0:N0} ", dtnhan.Compute("sum([TC_DoDem])", "[Loai]=1"));


              xlTN_TC_K.Text = string.Format("{0:N0} ", dtnhan.Compute("sum([TC_kDoDem])", "[Loai]=1"));

              xlTN_BT.Text = string.Format("{0:N0} ", dtnhan.Compute("sum([Bieu1])", "[Loai]=1"));
              xlTN_CD.Text = string.Format("{0:N0} ", dtnhan.Compute("sum([Bieu2])", "[Loai]=1"));
              xlTN_TD.Text = string.Format("{0:N0} ", dtnhan.Compute("sum([Bieu3])", "[Loai]=1"));
              xlTBT_TD.Text = string.Format("{0:N0} ", dtnhan.Compute("sum([Tong])", "[Loai]=1"));
              xlTN_1Gia.Text = string.Format("{0:N0} ", dtnhan.Compute("sum([Gia1])", "[Loai]=1"));
              xlTN_TC.Text = string.Format("{0:N0} ", dtnhan.Compute("sum([TC])", "[Loai]=1"));
            */

        }

    }
}
