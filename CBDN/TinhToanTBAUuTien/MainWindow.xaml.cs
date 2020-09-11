using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace TinhToanTBAUuTien
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            tinhtonthat();
        }
        public bool TinhChuKy(string ma_dviqlyDN, string MaTram, int thang, int nam, int Ngay, int ChuKy, int ngaysau, int chukysau, int kiemtra)
        {

            DataAccess.clTTTT db = new DataAccess.clTTTT();
            DataTable dt = db.SELECT_TONTHAT_CHUKY(ma_dviqlyDN, MaTram, thang, nam, Ngay, ChuKy, ngaysau, chukysau, kiemtra);
            if (dt.Rows.Count == 0)
                return false;
            if (dt.Rows[0]["CSUAT"] + "" == "0" || dt.Rows[0]["CSUAT"] + "" == "")
                return false;
            decimal sltinhCK = 0, sanluongtrc = 0;
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                if (i == 0)
                {
                    decimal slg = (decimal.Parse(dt.Rows[i]["SLGCOT"] + "") * decimal.Parse(dt.Rows[i]["CSUAT"] + "")) / decimal.Parse(dt.Rows[i]["SLDAUNGUONG"] + "");
                    sanluongtrc = decimal.Parse(dt.Rows[i]["SLGCOT"] + "");
                    sltinhCK = slg;
                    db.INSERT_TTTT_SLGNUT_CHUKY(ma_dviqlyDN, MaTram, dt.Rows[i]["MACOT"] + "", thang, nam, Math.Round(slg, 2), Ngay, ChuKy);

                }
                else
                {
                    decimal slg = sltinhCK * decimal.Parse(dt.Rows[i]["SLGCOT"] + "") / sanluongtrc;
                    sanluongtrc = decimal.Parse(dt.Rows[i]["SLGCOT"] + "");
                    sltinhCK = slg;
                    db.INSERT_TTTT_SLGNUT_CHUKY(ma_dviqlyDN, MaTram, dt.Rows[i]["MACOT"] + "", thang, nam, Math.Round(slg, 2), Ngay, ChuKy);
                }
            }
            return true;
        }
        public void tinhtonthat()
        {
            try
            {
                TinhToanTBAUuTien.clTinhTonThatKT clTT = new TinhToanTBAUuTien.clTinhTonThatKT();
                
                int thang = 6;
                int nam = 2020;
                string strDate = DateTime.Now.ToString("dd/MM/yyyy hh:mm");
                DataAccess.clTTTT db = new DataAccess.clTTTT();
                var dstba = db.SELECT_TTTT_TRAM_UUTIEN_TT(thang, nam);
                int a1 = dstba.Rows.Count;
                
                for (int i1 = 0; i1 < a1; i1++)
                {
                    string ma_dviqlyDN = dstba.Rows[i1]["MADVIQLY"] + ""; 
                    string MaTram = dstba.Rows[i1]["MATRAM"] + "";
                    //ma_dviqlyDN = "PA23MV";
                    //MaTram = "MVCE00099";
                    DataTable dtSLg_DD = db.TTTT_SELECT_SLG_DUONGDAY_TRAM_CHECK(ma_dviqlyDN, MaTram, thang, nam);
                    int check = dtSLg_DD.Rows.Count;
                    if (check > 1)
                    {
                        
                        DataTable dtNew = new DataTable();
                        db.Delete_TTTT_TRAM_CHUYKYTINH(ma_dviqlyDN, MaTram, thang, nam);

                        DataTable dt = db.SELECT_TONTHATKD_BYTRAM(ma_dviqlyDN, MaTram, thang, nam);
                        string tonthatKyThat = "0";

                        int ngay = 0, gio = 23, ngaysau = 0, giosau = 0, kiemtra;
                        bool ktrMuc2 = false;
                        int songay = DateTime.DaysInMonth(nam, thang);
                        for (int i = songay * 24; i > 0; i--)
                        {
                            if (i == 706)
                            {
                                string a = "1";
                            }
                            if (i == songay * 24)
                            {
                                kiemtra = 1;
                            }
                            else if (ktrMuc2)
                                kiemtra = 1;
                            else
                                kiemtra = 2;
                            ngaysau = ngay;
                            giosau = gio;
                            if (i % 24 == 0)
                            {
                                ngay = i / 24;
                                gio = 23;
                            }
                            else if (i != songay * 24)
                            {
                                gio = gio - 1;
                            }
                            //int strNgay = 0, strChuKy = 0;
                            //string ma_dviqlyDN, string maTram, ref string TonThat, int thang, int nam, int ngay, int chuky)
                            if (TinhChuKy(ma_dviqlyDN, MaTram, thang, nam, ngay, gio, ngaysau, giosau, kiemtra))
                            {
                                DataTable dtTTKT = clTT.TTKyThuat(ma_dviqlyDN, MaTram, ref tonthatKyThat, thang, nam, ngay, gio);

                                ktrMuc2 = false;
                            }
                            else
                                ktrMuc2 = true;

                        }
                        dtNew.Columns.Add("TTDN");
                        dtNew.Columns.Add("TTKT");
                        dtNew.Columns.Add("TTKD");
                        dtNew.Columns.Add("SoSanh");

                        //dtNew.Rows.Add("ĐN tổn thất delta A", decimal.Parse(tonthatKyThat) * decimal.Parse("15"), dt.Rows[0]["TONTHAT"] + "", decimal.Parse(dt.Rows[0]["TONTHAT"] + "") - decimal.Parse(tonthatKyThat) * decimal.Parse("15"));
                        //decimal phantramkt = Math.Round(decimal.Parse(tonthatKyThat) * decimal.Parse("15") / decimal.Parse(dt.Rows[0]["DAUNGUONTHANG"] + "") * 100, 2);
                        //dtNew.Rows.Add("Tỉ lệ tổn thất delta A", phantramkt, decimal.Parse(dt.Rows[0]["PHANTRAMTT"] + ""), decimal.Parse(dt.Rows[0]["PHANTRAMTT"] + "") - phantramkt);

                        DataTable dtTongKT = db.select_TTTT_TONTHATKYTHUAT_THANG(ma_dviqlyDN, MaTram, thang, nam, 1);
                        string kiemtra1 = dtTongKT.Rows[0]["TONTHAT"] + "";
                        if (dtTongKT.Rows.Count > 0 && kiemtra1 != "")
                        {
                            tonthatKyThat = dtTongKT.Rows[0]["TONTHAT"] + "";
                            tonthatKyThat = (decimal.Parse(tonthatKyThat) / 1000) + "";
                            dtNew.Rows.Add("ĐN tổn thất delta A", tonthatKyThat, dt.Rows[0]["TONTHAT"] + "", decimal.Parse(dt.Rows[0]["TONTHAT"] + "") - decimal.Parse(tonthatKyThat));
                            decimal phantramkt = Math.Round(decimal.Parse(tonthatKyThat) / decimal.Parse(dt.Rows[0]["DAUNGUONTHANG"] + "") * 100, 2);
                            dtNew.Rows.Add("Tỉ lệ tổn thất delta A", phantramkt, decimal.Parse(dt.Rows[0]["PHANTRAMTT"] + ""), decimal.Parse(dt.Rows[0]["PHANTRAMTT"] + "") - phantramkt);
                            string KyThuat = dtNew.Rows[0]["TTKT"] + "";
                            string KinhDoanh = dtNew.Rows[0]["TTKD"] + "";
                            string SoSanh = dtNew.Rows[0]["SoSanh"] + "";
                            string KyThuatTL = dtNew.Rows[1]["TTKT"] + "";
                            string KinhDoanhTL = dtNew.Rows[1]["TTKD"] + "";
                            string SoSanhTL = dtNew.Rows[1]["SoSanh"] + "";
                            string Nam = nam + "";
                            string Thang = thang + "";
                            db.INSERT_TTTT_TRAM_UUTIEN_TINHTOAN(ma_dviqlyDN, MaTram, KyThuat, KinhDoanh, SoSanh, KyThuatTL, KinhDoanhTL, SoSanhTL, strDate, Nam, Thang);
                        }
                    }
                }
                //hienthiBanDo(dtBD, decimal.Parse(dt.Rows[0]["PHANTRAMTT"] + "") - phantramkt, decimal.Parse(dt.Rows[0]["PHANTRAMTT"] + ""), phantramkt);

                //grdDVT.Caption = "Tính toán tổn thất điện năng trạm " + MaTram.Text + " điện nhận tháng 6: " + dt.Rows[0]["DAUNGUONTHANG"] + " kwwh";
                // grdDVT.DataSource = dtNew;
                // grdDVT.DataBind();
                // ScriptManager.RegisterStartupScript(Page, Page.GetType(), "", "alert('Đã thực hiện tính xong tổn thật tại trạm');", true);
            }
            catch (Exception ex)
            {
                //ScriptManager.RegisterStartupScript(Page, Page.GetType(), "", "alert('Đã thực hiện tính xong tổn thật tại trạm');", true);
                //ScriptManager.RegisterStartupScript(Page, Page.GetType(), "", "alert('Lỗi thực hiện tính " + ex.Message + "');", true);
            }

        }
    }
}
