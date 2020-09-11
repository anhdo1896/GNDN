using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Web.UI;
namespace CBDN.Class
{
    public class InBienBanGiaoNhan
    {
        public DataTable InBienBanGN(int PhuongThuc, int strMadviqly, int Thang, int Nam, ref string strTenDVGiao, ref string strTenDVnhan, ref string strGDNhan, ref string strGDGiao)
        {
            CBDN.DB_CBDNDataContext db = new CBDN.DB_CBDNDataContext(new CBDN.ADOController().strcn());
            //if (PhuongThuc == null) return;
            //MTCSYT.SYS_Session session = (MTCSYT.SYS_Session)Session["SYS_Session"];
            //int strMadviqly = int.Parse(session.User.ma_dviqly);

            DataTable dt = new DataTable();

            dt.Columns.Add("TenDonVi");
            dt.Columns.Add("MaTram");
            dt.Columns.Add("TenDiemDo");
            dt.Columns.Add("Loai");
            dt.Columns.Add("MaCongTo");
            dt.Columns.Add("Bieu1_DoDem", typeof(decimal));
            dt.Columns.Add("Bieu2_DoDem", typeof(decimal));
            dt.Columns.Add("Bieu3_DoDem", typeof(decimal));
            dt.Columns.Add("Tong_DoDem", typeof(decimal));
            dt.Columns.Add("Gia1_DoDem", typeof(decimal));
            dt.Columns.Add("TC_DoDem", typeof(decimal));

            dt.Columns.Add("Bieu1_kDoDem", typeof(decimal));
            dt.Columns.Add("Bieu2_kDoDem", typeof(decimal));
            dt.Columns.Add("Bieu3_kDoDem", typeof(decimal));
            dt.Columns.Add("Gia1_kDoDem", typeof(decimal));
            dt.Columns.Add("Tong_kDoDem", typeof(decimal));
            dt.Columns.Add("TC_kDoDem", typeof(decimal));

            dt.Columns.Add("Bieu1", typeof(decimal));
            dt.Columns.Add("Bieu2", typeof(decimal));
            dt.Columns.Add("Bieu3", typeof(decimal));
            dt.Columns.Add("Tong", typeof(decimal));
            dt.Columns.Add("Gia1", typeof(decimal));
            dt.Columns.Add("TC", typeof(decimal));

            dt.Columns.Add("Bieu1_DoDem1");
            dt.Columns.Add("Bieu2_DoDem1");
            dt.Columns.Add("Bieu3_DoDem1");
            dt.Columns.Add("Tong_DoDem1");
            dt.Columns.Add("1Gia_DoDem1");
            dt.Columns.Add("TC_DoDem1");

            dt.Columns.Add("Bieu1_kDoDem1");
            dt.Columns.Add("Bieu2_kDoDem1");
            dt.Columns.Add("Bieu3_kDoDem1");
            dt.Columns.Add("1Gia_kDoDem1");
            dt.Columns.Add("Tong_kDoDem1");
            dt.Columns.Add("TC_kDoDem1");

            dt.Columns.Add("Bieu11");
            dt.Columns.Add("Bieu21");
            dt.Columns.Add("Bieu31");
            dt.Columns.Add("Tong1");
            dt.Columns.Add("1Gia1");
            dt.Columns.Add("TC1");

            var lst = db.BC_ChiSoThang_ChuaChot_BCC1(strMadviqly, Thang, Nam).ToList();
            var lsttONG = db.BC_GiaoNhan2Chieu_TongTram_BCC1(strMadviqly, Thang, Nam).ToList();
            DataTable ds = new DataTable();
            ds.Columns.Add("Tram");
            int b = 0;
            foreach (var dstram in lsttONG)
            {
                int a = ds.Rows.Count;
                var check2 = dstram.IDTram + "";

                if (a > 0)
                {
                    for (int i = 0; i < a; i++)
                    {
                        var check = ds.Rows[i]["Tram"] + "";

                        if (check2 == check)
                        {
                            b++;
                        }


                    }


                }
                if (b == 0)
                {
                    ds.Rows.Add(dstram.IDTram);
                }
                b = 0;

            }

            int a1 = ds.Rows.Count;
            if (a1 > 0)
            {
                for (int i = 0; i < a1; i++)
                {
                    int ID = int.Parse(ds.Rows[i]["Tram"] + "");
                   
                        
                    var lstByTram = lst.Where(x => x.IDTram == ID).ToList();
                    string TEN_DVIQLY = "";
                    string MaTram = "";
                    string TenDiemDo = "";
                    string MaCongTo = "";
                    decimal Nhan_Bieu1_DoDem = 0;
                    decimal Nhan_Bieu2_DoDem = 0;
                    decimal Nhan_Bieu3_DoDem = 0;
                    decimal Nhan_Tong_DoDem = 0;
                    decimal Nhan1Gia_DoDem = 0;
                    decimal Tong_Nhan_DoDem = 0;

                    decimal Nhan_Bieu1_kDoDem = 0;
                    decimal Nhan_Bieu2_kDoDem = 0;
                    decimal Nhan_Bieu3_kDoDem = 0;
                    decimal Nhan_Tong_kDoDem = 0;
                    decimal Nhan1Gia_kDoDem = 0;
                    decimal Tong_Nhan_kDoDem = 0;

                    decimal Nhan_Bieu1 = 0;
                    decimal Nhan_Bieu2 = 0;
                    decimal Nhan_Bieu3 = 0;
                    decimal Nhan_Tong = 0;
                    decimal Nhan1Gia = 0;
                    decimal Tong_Nhan = 0;

                    decimal Giao_Bieu1_DoDem = 0;
                    decimal Giao_Bieu2_DoDem = 0;
                    decimal Giao_Bieu3_DoDem = 0;
                    decimal Giao_Tong_DoDem = 0;
                    decimal Giao1Gia_DoDem = 0;
                    decimal Tong_Giao_DoDem = 0;

                    decimal Giao_Bieu1_kDoDem = 0;
                    decimal Giao_Bieu2_kDoDem = 0;
                    decimal Giao_Bieu3_kDoDem = 0;
                    decimal Giao_Tong_kDoDem = 0;
                    decimal Giao1Gia_kDoDem = 0;
                    decimal Tong_Giao_kDoDem = 0;

                    decimal Giao_Bieu1 = 0;
                    decimal Giao_Bieu2 = 0;
                    decimal Giao_Bieu3 = 0;
                    decimal Giao_Tong = 0;
                    decimal Giao1Gia = 0;
                    decimal Tong_Giao = 0;
                    foreach (var chitiet in lstByTram)
                    {
                        var tram = db.DM_Trams.SingleOrDefault(x => x.IDTram == chitiet.IDTram);
                        if (tram == null) continue;
                        var PTtram = db.DM_ChiNhanhs.SingleOrDefault(x => x.ID == int.Parse(tram.IDChiNhanh));
                        if (PTtram.ID == PhuongThuc)
                        {


                            if (chitiet.ISDoDem == 0)
                            {
                                if ((bool)chitiet.IsCToMotGia)
                                {

                                    Nhan1Gia_DoDem = (decimal)chitiet.Nhan_Bieu1_SanLuong + (decimal)chitiet.Nhan_Bieu2_SanLuong + (decimal)chitiet.Nhan_Bieu3_SanLuong;
                                    Giao1Gia_DoDem = (decimal)chitiet.Nhan_Bieu1_SanLuong + (decimal)chitiet.Nhan_Bieu2_SanLuong + (decimal)chitiet.Nhan_Bieu3_SanLuong;

                                }

                                else
                                {
                                    Nhan_Bieu1_DoDem = (decimal)chitiet.Nhan_Bieu1_SanLuong;
                                    Nhan_Bieu2_DoDem = (decimal)chitiet.Nhan_Bieu2_SanLuong;
                                    Nhan_Bieu3_DoDem = (decimal)chitiet.Nhan_Bieu3_SanLuong;
                                    Nhan_Tong_DoDem = Nhan_Bieu1_DoDem + Nhan_Bieu2_DoDem + Nhan_Bieu3_DoDem;
                                    Tong_Nhan_DoDem = Nhan_Tong_DoDem + Nhan1Gia_DoDem;


                                    Giao_Bieu1_DoDem = (decimal)chitiet.Giao_Bieu1_SanLuong;
                                    Giao_Bieu2_DoDem = (decimal)chitiet.Giao_Bieu2_SanLuong;
                                    Giao_Bieu3_DoDem = (decimal)chitiet.Giao_Bieu3_SanLuong;
                                    Giao_Tong_DoDem = Giao_Bieu1_DoDem + Giao_Bieu2_DoDem + Giao_Bieu3_DoDem;
                                    Tong_Giao_DoDem = Giao_Tong_DoDem + Giao1Gia_DoDem;
                                }
                            }
                            else
                            {
                                if ((bool)chitiet.IsCToMotGia)
                                {

                                    Nhan1Gia_kDoDem = (decimal)chitiet.Nhan_Bieu1_SanLuong + (decimal)chitiet.Nhan_Bieu2_SanLuong + (decimal)chitiet.Nhan_Bieu3_SanLuong;
                                    Giao1Gia_kDoDem = (decimal)chitiet.Nhan_Bieu1_SanLuong + (decimal)chitiet.Nhan_Bieu2_SanLuong + (decimal)chitiet.Nhan_Bieu3_SanLuong;

                                }

                                else
                                {
                                    Nhan_Bieu1_kDoDem = (decimal)chitiet.Nhan_Bieu1_SanLuong;
                                    Nhan_Bieu2_kDoDem = (decimal)chitiet.Nhan_Bieu2_SanLuong;
                                    Nhan_Bieu3_kDoDem = (decimal)chitiet.Nhan_Bieu3_SanLuong;
                                    Nhan_Tong_kDoDem = Nhan_Bieu1_kDoDem + Nhan_Bieu2_kDoDem + Nhan_Bieu3_kDoDem;
                                    Tong_Nhan_kDoDem = Nhan_Tong_kDoDem + Nhan1Gia_kDoDem;


                                    Giao_Bieu1_kDoDem = (decimal)chitiet.Giao_Bieu1_SanLuong;
                                    Giao_Bieu2_kDoDem = (decimal)chitiet.Giao_Bieu2_SanLuong;
                                    Giao_Bieu3_kDoDem = (decimal)chitiet.Giao_Bieu3_SanLuong;
                                    Giao_Tong_kDoDem = Giao_Bieu1_kDoDem + Giao_Bieu2_kDoDem + Giao_Bieu3_kDoDem;
                                    Tong_Giao_kDoDem = Giao_Tong_kDoDem + Giao1Gia_kDoDem;

                                }
                            }
                            TEN_DVIQLY = chitiet.TEN_DVIQLY + "";
                            MaTram = chitiet.MaTram + "";
                            TenDiemDo = chitiet.TenDiemDo + "";
                            MaCongTo = chitiet.MaCongTo + "";
                            Nhan_Bieu1 = Nhan_Bieu1_DoDem + Nhan_Bieu1_kDoDem;
                            Nhan_Bieu2 = Nhan_Bieu2_DoDem + Nhan_Bieu2_kDoDem;
                            Nhan_Bieu3 = Nhan_Bieu3_DoDem + Nhan_Bieu3_kDoDem;
                            Nhan_Tong = Nhan_Tong_DoDem + Nhan_Tong_kDoDem;
                            Nhan1Gia = Nhan1Gia_DoDem + Nhan1Gia_kDoDem;
                            Tong_Nhan = Tong_Nhan_DoDem + Tong_Nhan_kDoDem;

                            Giao_Bieu1 = Giao_Bieu1_DoDem + Giao_Bieu1_kDoDem;
                            Giao_Bieu2 = Giao_Bieu2_DoDem + Giao_Bieu2_kDoDem;
                            Giao_Bieu3 = Giao_Bieu3_DoDem + Giao_Bieu3_kDoDem;
                            Giao_Tong = Giao_Tong_DoDem + Giao_Tong_kDoDem;
                            Giao1Gia = Giao1Gia_DoDem + Giao1Gia_kDoDem;
                            Tong_Giao = Tong_Giao_DoDem + Tong_Giao_kDoDem;


                        }


                    }
                    if (Tong_Nhan > 0)
                    {
                        dt.Rows.Add(TEN_DVIQLY, MaTram, TenDiemDo, 1, MaCongTo,
                            string.Format("{0:N0} ", Nhan_Bieu1_DoDem),
                           string.Format("{0:N0} ", Nhan_Bieu2_DoDem), string.Format("{0:N0} ", Nhan_Bieu3_DoDem),
                           string.Format("{0:N0} ", Nhan_Tong_DoDem), string.Format("{0:N0} ", Nhan1Gia_DoDem),
                            string.Format("{0:N0} ", Tong_Nhan_DoDem),
                         string.Format("{0:N0} ", Nhan_Bieu1_kDoDem), string.Format("{0:N0} ", Nhan_Bieu2_kDoDem),
                         string.Format("{0:N0} ", Nhan_Bieu3_kDoDem), string.Format("{0:N0} ", Nhan1Gia_kDoDem),
                         string.Format("{0:N0} ", Nhan_Tong_kDoDem),
                         string.Format("{0:N0} ", Tong_Nhan_kDoDem), string.Format("{0:N0} ", Nhan_Bieu1),
                         string.Format("{0:N0} ", Nhan_Bieu2), string.Format("{0:N0} ", Nhan_Bieu3),
                         string.Format("{0:N0} ", Nhan_Tong), string.Format("{0:N0} ", Nhan1Gia),
                         string.Format("{0:N0} ", Tong_Nhan),
                         string.Format("{0:N0} ", Nhan_Bieu1_DoDem),
                           string.Format("{0:N0} ", Nhan_Bieu2_DoDem), string.Format("{0:N0} ", Nhan_Bieu3_DoDem),
                           string.Format("{0:N0} ", Nhan_Tong_DoDem), string.Format("{0:N0} ", Nhan1Gia_DoDem),
                            string.Format("{0:N0} ", Tong_Nhan_DoDem),
                         string.Format("{0:N0} ", Nhan_Bieu1_kDoDem), string.Format("{0:N0} ", Nhan_Bieu2_kDoDem),
                         string.Format("{0:N0} ", Nhan_Bieu3_kDoDem), string.Format("{0:N0} ", Nhan1Gia_kDoDem),
                         string.Format("{0:N0} ", Nhan_Tong_kDoDem),
                         string.Format("{0:N0} ", Tong_Nhan_kDoDem), string.Format("{0:N0} ", Nhan_Bieu1),
                         string.Format("{0:N0} ", Nhan_Bieu2), string.Format("{0:N0} ", Nhan_Bieu3),
                         string.Format("{0:N0} ", Nhan_Tong), string.Format("{0:N0} ", Nhan1Gia),
                         string.Format("{0:N0} ", Tong_Nhan));
                    }
                    if (Tong_Giao > 0)

                    {
                        dt.Rows.Add(TEN_DVIQLY, MaTram, TenDiemDo, 0, MaCongTo,
                         string.Format("{0:N0} ", Giao_Bieu1_DoDem), string.Format("{0:N0} ", Giao_Bieu2_DoDem),
                           string.Format("{0:N0} ", Giao_Bieu3_DoDem), string.Format("{0:N0} ", Giao_Tong_DoDem),
                           string.Format("{0:N0} ", Giao1Gia_DoDem), string.Format("{0:N0} ", Tong_Giao_DoDem),
                           string.Format("{0:N0} ", Giao_Bieu1_kDoDem), string.Format("{0:N0} ", Giao_Bieu2_kDoDem),
                           string.Format("{0:N0} ", Giao_Bieu3_kDoDem),
                            string.Format("{0:N0} ", Giao1Gia_kDoDem), string.Format("{0:N0} ", Giao_Tong_kDoDem),
                           string.Format("{0:N0} ", Tong_Giao_kDoDem), string.Format("{0:N0} ", Giao_Bieu1),
                           string.Format("{0:N0} ", Giao_Bieu2), string.Format("{0:N0} ", Giao_Bieu3),
                           string.Format("{0:N0} ", Giao_Tong), string.Format("{0:N0} ", Giao1Gia),
                            string.Format("{0:N0} ", Tong_Giao),
                             string.Format("{0:N0} ", Giao_Bieu1_DoDem), string.Format("{0:N0} ", Giao_Bieu2_DoDem),
                           string.Format("{0:N0} ", Giao_Bieu3_DoDem), string.Format("{0:N0} ", Giao_Tong_DoDem),
                           string.Format("{0:N0} ", Giao1Gia_DoDem), string.Format("{0:N0} ", Tong_Giao_DoDem),
                           string.Format("{0:N0} ", Giao_Bieu1_kDoDem), string.Format("{0:N0} ", Giao_Bieu2_kDoDem),
                           string.Format("{0:N0} ", Giao_Bieu3_kDoDem),
                            string.Format("{0:N0} ", Giao1Gia_kDoDem), string.Format("{0:N0} ", Giao_Tong_kDoDem),
                           string.Format("{0:N0} ", Tong_Giao_kDoDem), string.Format("{0:N0} ", Giao_Bieu1),
                           string.Format("{0:N0} ", Giao_Bieu2), string.Format("{0:N0} ", Giao_Bieu3),
                           string.Format("{0:N0} ", Giao_Tong), string.Format("{0:N0} ", Giao1Gia),
                            string.Format("{0:N0} ", Tong_Giao));
                    }
                }

            }
           
 
            if (PhuongThuc + "" != "0")
            {
                var cn = db.DM_ChiNhanhs.SingleOrDefault(x => x.ID == PhuongThuc);
                CBDN.DM_DVQLY giao, nhan;
                if (cn.IDMADVIQLY.Contains(",2,"))
                {
                    giao = db.DM_DVQLies.SingleOrDefault(x => x.IDMA_DVIQLY == 2);
                    nhan = db.DM_DVQLies.SingleOrDefault(x => x.IDMA_DVIQLY == int.Parse(cn.IDMADVIQLY.Replace(",2,", "").Replace(",", "")));
                }
                else
                {
                    giao = db.DM_DVQLies.SingleOrDefault(x => x.IDMA_DVIQLY == cn.DiemDauNguon);
                    nhan = db.DM_DVQLies.SingleOrDefault(x => x.IDMA_DVIQLY == cn.DiemCuoiNguon);
                }


                var imGDGiao = db.HD_ThongTinKies.SingleOrDefault(x => x.IDMaDViQLy == cn.DiemDauNguon && x.IDChinhNhanh == PhuongThuc && x.Thang == Thang && x.Nam == Nam && x.ChucVu == 3);
                var imGDNhan = db.HD_ThongTinKies.SingleOrDefault(x => x.IDMaDViQLy == cn.DiemCuoiNguon && x.IDChinhNhanh == PhuongThuc && x.Thang == Thang && x.Nam == Nam && x.ChucVu == 3);

                if (imGDGiao != null)
                {
                    var ngGiao = db.DM_USERs.SingleOrDefault(x => x.IDUSER == imGDGiao.NguoiTao);
                    strGDGiao = ngGiao.HOTEN + "</br> Thời gian xác nhận: " + imGDGiao.NgayTao;
                }
                if (imGDNhan != null)
                {
                    var ngNhan = db.DM_USERs.SingleOrDefault(x => x.IDUSER == imGDNhan.NguoiTao);
                    strGDNhan = ngNhan.HOTEN + "</br> Thời gian xác nhận: " + imGDNhan.NgayTao;
                }
                strTenDVGiao = giao.TEN_DVIQLY;
                strTenDVnhan = nhan.TEN_DVIQLY;
            }

            else
            {
                strTenDVGiao = "TỔNG CÔNG TY ĐIỆN LỰC MIỀM BẮC";
                strTenDVnhan = db.DM_DVQLies.SingleOrDefault(x => x.IDMA_DVIQLY == strMadviqly).TEN_DVIQLY;
            }


            return dt;
        }
    }
}