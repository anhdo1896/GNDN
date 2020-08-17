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

namespace TBAUuTien
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
        private void tinhtonthat()
        {
            //var Thang = DateTime.Now.Month - 1;
            //var Nam = DateTime.Now.Year;
            int Thang = 6;
            int Nam = 2020;
            DataAccess.clTTTT db = new DataAccess.clTTTT();
            TBAUuTien.clTinhTonThatKT clTT = new TBAUuTien.clTinhTonThatKT();

            var dstba = db.SELECT_TTTT_TRAM_UUTIEN_TT(Thang, Nam);
            int a1 = dstba.Rows.Count;
            for (int i1 = 0; i1 < a1; i1++)
            {
                string ma_dviqlyDN = "PA23MV";
                string MaTram = "MVCE00099";
                //string ma_dviqlyDN = dstba.Rows[i1]["MADVIQLY"].ToString();
                //string MaTram = dstba.Rows[i1]["MATRAM"].ToString();
                DataTable dtNew = new DataTable();

                DataTable dt = db.SELECT_TONTHATKD_BYTRAM(ma_dviqlyDN, MaTram, int.Parse(Thang + ""), int.Parse(Nam + ""));
                string tonthatKyThat = "0";

                int ngay = 0, gio = 23, ngaysau = 0, giosau = 0, kiemtra;
                bool ktrMuc2 = false;
                int songay = DateTime.DaysInMonth(int.Parse(Nam + ""), int.Parse(Thang + ""));
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
                    if (TinhChuKy(ma_dviqlyDN, MaTram,int.Parse(Thang + ""), int.Parse("" + Nam), ngay, gio, ngaysau, giosau, kiemtra))
                    {
                        DataTable dtTTKT = clTT.TTKyThuat(ma_dviqlyDN, MaTram, ref tonthatKyThat, int.Parse(Thang + ""), int.Parse("" + Nam), ngay, gio);

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

                DataTable dtTongKT = db.select_TTTT_TONTHATKYTHUAT_THANG(ma_dviqlyDN, MaTram, int.Parse(Thang + ""), int.Parse("" + Nam), 1);

                if (dtTongKT.Rows.Count > 0)
                    tonthatKyThat = dtTongKT.Rows[0]["TONTHAT"] + "";

                dtNew.Rows.Add("ĐN tổn thất delta A", tonthatKyThat, dt.Rows[0]["TONTHAT"] + "", decimal.Parse(dt.Rows[0]["TONTHAT"] + "") - decimal.Parse(tonthatKyThat));
                decimal phantramkt = Math.Round(decimal.Parse(tonthatKyThat) / decimal.Parse(dt.Rows[0]["DAUNGUONTHANG"] + "") * 100, 2);
                dtNew.Rows.Add("Tỉ lệ tổn thất delta A", phantramkt, decimal.Parse(dt.Rows[0]["PHANTRAMTT"] + ""), decimal.Parse(dt.Rows[0]["PHANTRAMTT"] + "") - phantramkt);
                DataTable dtBD = new DataTable();

            }
        }
        private bool TinhChuKy(string ma_dviqlyDN, string MaTram, int thang, int nam, int Ngay, int ChuKy, int ngaysau, int chukysau, int kiemtra)
        {
            DataAccess.clTTTT db = new DataAccess.clTTTT();

            DataTable dt = db.SELECT_TONTHAT_CHUKY(ma_dviqlyDN, MaTram + "", thang, nam, Ngay, ChuKy, ngaysau, chukysau, kiemtra);
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
                    db.INSERT_TTTT_SLGNUT_CHUKY(ma_dviqlyDN, MaTram + "", dt.Rows[i]["MACOT"] + "", thang, nam, Math.Round(slg, 2), Ngay, ChuKy);

                }
                else
                {
                    decimal slg = sltinhCK * decimal.Parse(dt.Rows[i]["SLGCOT"] + "") / sanluongtrc;
                    sanluongtrc = decimal.Parse(dt.Rows[i]["SLGCOT"] + "");
                    sltinhCK = slg;
                    db.INSERT_TTTT_SLGNUT_CHUKY(ma_dviqlyDN, MaTram + "", dt.Rows[i]["MACOT"] + "", thang, nam, Math.Round(slg, 2), Ngay, ChuKy);
                }
            }
            return true;
        }
    }
}
    

