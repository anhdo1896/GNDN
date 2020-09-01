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
            dt.Columns.Add("ISChot");
            dt.Columns.Add("MaCongTo");

            dt.Columns.Add("Nhan_Bieu1_DoDem", typeof(decimal));
            dt.Columns.Add("Nhan_Bieu2_DoDem", typeof(decimal));
            dt.Columns.Add("Nhan_Bieu3_DoDem", typeof(decimal));
            dt.Columns.Add("Nhan_Tong_DoDem", typeof(decimal));
            dt.Columns.Add("Nhan1Gia_DoDem", typeof(decimal));
            dt.Columns.Add("Tong_Nhan_DoDem", typeof(decimal));

            dt.Columns.Add("Nhan_Bieu1_kDoDem", typeof(decimal));
            dt.Columns.Add("Nhan_Bieu2_kDoDem", typeof(decimal));
            dt.Columns.Add("Nhan_Bieu3_kDoDem", typeof(decimal));
            dt.Columns.Add("Nhan_Tong_kDoDem", typeof(decimal));
            dt.Columns.Add("Tong_Nhan_kDoDem", typeof(decimal));

            dt.Columns.Add("Nhan_Bieu1", typeof(decimal));
            dt.Columns.Add("Nhan_Bieu2", typeof(decimal));
            dt.Columns.Add("Nhan_Bieu3", typeof(decimal));
            dt.Columns.Add("Nhan_Tong", typeof(decimal));
            dt.Columns.Add("Nhan1Gia", typeof(decimal));
            dt.Columns.Add("Tong_Nhan", typeof(decimal));


            dt.Columns.Add("Giao_Bieu1_DoDem", typeof(decimal));
            dt.Columns.Add("Giao_Bieu2_DoDem", typeof(decimal));
            dt.Columns.Add("Giao_Bieu3_DoDem", typeof(decimal));
            dt.Columns.Add("Giao_Tong_DoDem", typeof(decimal));
            dt.Columns.Add("Giao1Gia_DoDem", typeof(decimal));
            dt.Columns.Add("Tong_Giao_DoDem", typeof(decimal));

            dt.Columns.Add("Giao_Bieu1_kDoDem", typeof(decimal));
            dt.Columns.Add("Giao_Bieu2_kDoDem", typeof(decimal));
            dt.Columns.Add("Giao_Bieu3_kDoDem", typeof(decimal));
            dt.Columns.Add("Giao_Tong_kDoDem", typeof(decimal));
            dt.Columns.Add("Giao1Gia_kDoDem", typeof(decimal));
            dt.Columns.Add("Tong_Giao_kDoDem", typeof(decimal));

            dt.Columns.Add("Giao_Bieu1", typeof(decimal));
            dt.Columns.Add("Giao_Bieu2", typeof(decimal));
            dt.Columns.Add("Giao_Bieu3", typeof(decimal));
            dt.Columns.Add("Giao_Tong", typeof(decimal));
            dt.Columns.Add("Giao1Gia", typeof(decimal));
            dt.Columns.Add("Tong_Giao", typeof(decimal));





            var lst = db.BC_ChiSoThang_ChuaChot_BCC(strMadviqly, Thang,  Nam).ToList();
            var lsttONG = db.BC_GiaoNhan2Chieu_TongTram_BCC(strMadviqly, Thang, Nam).ToList();
            DataTable ds = new DataTable();
            ds.Columns.Add("Tram");
            int b = 0;
            foreach (var dstram in lst)
            {
                int a = ds.Rows.Count;
                var check2 = dstram.IDTram + "";

                if (a>0)
                {
                    for(int i=0; i<a;i++)
                    {
                        var check = ds.Rows[i]["Tram"]+"";
                        
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
            if (a1 >0)
            { 
            for(int i =0; i<a1 ; i++)
                {
                    string ID = ds.Rows[i]["Tram"] + "";
                    foreach (var tongtram in lsttONG)
                    {
                        string checkID = tongtram.IDTram + "";
                        
                        if (checkID == ID)
                        {
                            var tram = db.DM_Trams.SingleOrDefault(x => x.IDTram == tongtram.IDTram);
                            if (tram == null) continue;
                            var PTtram = db.DM_ChiNhanhs.SingleOrDefault(x => x.ID == int.Parse(tram.IDChiNhanh));
                            if (PTtram.ID == PhuongThuc)
                            {
                                var lstByTram = lst.Where(x => x.IDTram == tongtram.IDTram).ToList();

                                foreach (var chitiet in lstByTram)
                                {
                                    var x = tram.TenTram;
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

                                    dt.Rows.Add(chitiet.TEN_DVIQLY, chitiet.MaTram, chitiet.TenDiemDo, chitiet.ISDoDem,chitiet.MaCongTo, Nhan_Bieu1_DoDem, Nhan_Bieu2_DoDem, Nhan_Bieu3_DoDem, Nhan_Tong_DoDem, Nhan1Gia_DoDem, Tong_Nhan_DoDem,
                                       Nhan_Bieu1_kDoDem, Nhan_Bieu2_kDoDem, Nhan_Bieu3_kDoDem, Nhan_Tong_kDoDem, Tong_Nhan_kDoDem, Nhan_Bieu1, Nhan_Bieu2, Nhan_Bieu3, Nhan_Tong, Nhan1Gia, Tong_Nhan,
                                       Giao_Bieu1_DoDem, Giao_Bieu2_DoDem, Giao_Bieu3_DoDem, Giao_Tong_DoDem, Giao1Gia_DoDem, Tong_Giao_DoDem, Giao_Bieu1_kDoDem, Giao_Bieu2_kDoDem, Giao_Bieu3_kDoDem,
                                       Giao_Tong_kDoDem, Giao1Gia_kDoDem, Tong_Giao_kDoDem, Giao_Bieu1, Giao_Bieu2, Giao_Bieu3, Giao_Tong, Giao1Gia, Tong_Giao);

                                }


                            }
                        }
                    }

                }    
            }    



            int sttTong = 0;


            

             
            int stt = 1;
            /*
            dt.Rows.Add("A", "Từ hệ thống của EVN NPC", 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0);
            foreach (var chitiet in lstquyettoanTT)
            {
                dt.Rows.Add(stt, chitiet.khoitruyentai, 1, chitiet.Nhan_Bieu1_SanLuong, chitiet.Nhan_Bieu2_SanLuong, chitiet.Nhan_Bieu3_SanLuong, 0,
                    chitiet.TongNhan3B, chitiet.Giao_Bieu1_SanLuong, chitiet.Giao_Bieu2_SanLuong, chitiet.Giao_Bieu3_SanLuong,
                    0, chitiet.TongGiao3B, chitiet.B1_TieuThu, chitiet.B2_TieuThu, chitiet.B3_TieuThu, 0, chitiet.Tong_TieuThu
                    , string.Format("{0:N0} ", chitiet.Nhan_Bieu1_SanLuong).Replace(",", "."),
                    string.Format("{0:N0} ", chitiet.Nhan_Bieu2_SanLuong).Replace(",", "."),
                    string.Format("{0:N0} ", chitiet.Nhan_Bieu3_SanLuong).Replace(",", "."), 0,
                    string.Format("{0:N0} ", chitiet.TongNhan3B).Replace(",", "."),
                    string.Format("{0:N0} ", chitiet.Giao_Bieu1_SanLuong).Replace(",", "."),
                    string.Format("{0:N0} ", chitiet.Giao_Bieu2_SanLuong).Replace(",", "."),
                    string.Format("{0:N0} ", chitiet.Giao_Bieu3_SanLuong).Replace(",", "."),
                    0, string.Format("{0:N0} ", chitiet.TongGiao3B).Replace(",", "."),
                    string.Format("{0:N0} ", chitiet.B1_TieuThu).Replace(",", "."),
                    string.Format("{0:N0} ", chitiet.B2_TieuThu).Replace(",", "."),
                    string.Format("{0:N0} ", chitiet.B3_TieuThu).Replace(",", "."),
                    0, string.Format("{0:N0} ", chitiet.Tong_TieuThu).Replace(",", "."));
                stt++;
            }


            var lstquyettoan = db.BC_QuyetToan(strMadviqly, Thang, Nam, PhuongThuc);

            foreach (var chitiet in lstquyettoan)
            {
                dt.Rows.Add(stt, chitiet.TenCongTy, 2, chitiet.Nhan_Bieu1_SanLuong, chitiet.Nhan_Bieu2_SanLuong, chitiet.Nhan_Bieu3_SanLuong, 0, chitiet.TongNhan3B, chitiet.Giao_Bieu1_SanLuong, chitiet.Giao_Bieu2_SanLuong, chitiet.Giao_Bieu3_SanLuong, 0, chitiet.TongGiao3B, chitiet.B1_TieuThu, chitiet.B2_TieuThu, chitiet.B3_TieuThu, 0, chitiet.Tong_TieuThu

                     , string.Format("{0:N0} ", chitiet.Nhan_Bieu1_SanLuong).Replace(",", "."),
                     string.Format("{0:N0} ", chitiet.Nhan_Bieu2_SanLuong).Replace(",", "."),
                     string.Format("{0:N0} ", chitiet.Nhan_Bieu3_SanLuong).Replace(",", "."), 0,
                     string.Format("{0:N0} ", chitiet.TongNhan3B).Replace(",", "."),
                     string.Format("{0:N0} ", chitiet.Giao_Bieu1_SanLuong).Replace(",", "."),
                     string.Format("{0:N0} ", chitiet.Giao_Bieu2_SanLuong).Replace(",", "."),
                     string.Format("{0:N0} ", chitiet.Giao_Bieu3_SanLuong).Replace(",", "."),
                     0, string.Format("{0:N0} ", chitiet.TongGiao3B).Replace(",", "."),
                     string.Format("{0:N0} ", chitiet.B1_TieuThu).Replace(",", "."),
                     string.Format("{0:N0} ", chitiet.B2_TieuThu).Replace(",", "."),
                     string.Format("{0:N0} ", chitiet.B3_TieuThu).Replace(",", "."),
                     0, string.Format("{0:N0} ", chitiet.Tong_TieuThu).Replace(",", "."));
                stt++;
            }


            //tính tổng dòng A
            DataRow[] drA = dt.Select("STT='A' AND Loai=0");
            drA[0]["Nhan_Bieu1_SanLuong"] = 0;
            drA[0]["Nhan_Bieu2_SanLuong"] = 0;
            drA[0]["Nhan_Bieu3_SanLuong"] = 0;
            drA[0]["Nhan1Gia"] = 0;
            drA[0]["TongNhan3B"] = 0;
            drA[0]["Giao_Bieu1_SanLuong"] = 0;
            drA[0]["Giao_Bieu2_SanLuong"] = 0;
            drA[0]["Giao_Bieu3_SanLuong"] = 0;
            drA[0]["Giao1Gia"] = 0;
            drA[0]["TongGiao3B"] = 0;
            drA[0]["B1_TieuThu"] = 0;
            drA[0]["B2_TieuThu"] = 0;
            drA[0]["B3_TieuThu"] = 0;
            drA[0]["Tong1Gia"] = 0;
            drA[0]["Tong_TieuThu"] = 0;

            drA[0]["Nhan_Bieu1_SanLuong1"] = string.Format("{0:N0} ", dt.Compute("sum(Nhan_Bieu1_SanLuong)", "Loai<3")).Replace(",", ".");
            drA[0]["Nhan_Bieu2_SanLuong1"] = string.Format("{0:N0} ", dt.Compute("sum(Nhan_Bieu2_SanLuong)", "Loai<3")).Replace(",", ".");
            drA[0]["Nhan_Bieu3_SanLuong1"] = string.Format("{0:N0} ", dt.Compute("sum(Nhan_Bieu3_SanLuong)", "Loai<3")).Replace(",", ".");
            drA[0]["Nhan1Gia1"] = string.Format("{0:N0} ", dt.Compute("sum(Nhan1Gia)", "Loai<3")).Replace(",", ".");
            drA[0]["TongNhan3B1"] = string.Format("{0:N0} ", dt.Compute("sum(TongNhan3B)", "Loai<3")).Replace(",", ".");
            drA[0]["Giao_Bieu1_SanLuong1"] = string.Format("{0:N0} ", dt.Compute("sum(Giao_Bieu1_SanLuong)", "Loai<3")).Replace(",", ".");
            drA[0]["Giao_Bieu2_SanLuong1"] = string.Format("{0:N0} ", dt.Compute("sum(Giao_Bieu2_SanLuong)", "Loai<3")).Replace(",", ".");
            drA[0]["Giao_Bieu3_SanLuong1"] = string.Format("{0:N0} ", dt.Compute("sum(Giao_Bieu3_SanLuong)", "Loai<3")).Replace(",", ".");
            drA[0]["Giao1Gia1"] = string.Format("{0:N0} ", dt.Compute("sum(Giao1Gia)", "Loai<3")).Replace(",", ".");
            drA[0]["TongGiao3B1"] = string.Format("{0:N0} ", dt.Compute("sum(TongGiao3B)", "Loai<3")).Replace(",", ".");
            drA[0]["B1_TieuThu1"] = string.Format("{0:N0} ", dt.Compute("sum(B1_TieuThu)", "Loai<3")).Replace(",", ".");
            drA[0]["B2_TieuThu1"] = string.Format("{0:N0} ", dt.Compute("sum(B2_TieuThu)", "Loai<3")).Replace(",", ".");
            drA[0]["B3_TieuThu1"] = string.Format("{0:N0} ", dt.Compute("sum(B3_TieuThu)", "Loai<3")).Replace(",", ".");
            drA[0]["Tong1Gia1"] = string.Format("{0:N0} ", dt.Compute("sum(Tong1Gia)", "Loai<3")).Replace(",", ".");
            drA[0]["Tong_TieuThu1"] = string.Format("{0:N0} ", dt.Compute("sum(Tong_TieuThu)", "Loai<3")).Replace(",", ".");

            var lstquyettoanSX = db.BC_QuyetToanTuSX_CN(strMadviqly, Thang, Nam, PhuongThuc);
            stt = 1;
            dt.Rows.Add("B", "Tự sản xuất", 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0);
            foreach (var chitiet in lstquyettoanSX)
            {
                dt.Rows.Add(stt, chitiet.khoitruyentai, 3, chitiet.Nhan_Bieu1_SanLuong, chitiet.Nhan_Bieu2_SanLuong, chitiet.Nhan_Bieu3_SanLuong, 0, chitiet.TongNhan3B, chitiet.Giao_Bieu1_SanLuong, chitiet.Giao_Bieu2_SanLuong, chitiet.Giao_Bieu3_SanLuong, 0, chitiet.TongGiao3B, chitiet.B1_TieuThu, chitiet.B2_TieuThu, chitiet.B3_TieuThu, 0, chitiet.Tong_TieuThu

                     , string.Format("{0:N0} ", chitiet.Nhan_Bieu1_SanLuong).Replace(",", "."),
                     string.Format("{0:N0} ", chitiet.Nhan_Bieu2_SanLuong).Replace(",", "."),
                     string.Format("{0:N0} ", chitiet.Nhan_Bieu3_SanLuong).Replace(",", "."), 0,
                     string.Format("{0:N0} ", chitiet.TongNhan3B).Replace(",", "."),
                     string.Format("{0:N0} ", chitiet.Giao_Bieu1_SanLuong).Replace(",", "."),
                     string.Format("{0:N0} ", chitiet.Giao_Bieu2_SanLuong).Replace(",", "."),
                     string.Format("{0:N0} ", chitiet.Giao_Bieu3_SanLuong).Replace(",", "."),
                     0, string.Format("{0:N0} ", chitiet.TongGiao3B).Replace(",", "."),
                     string.Format("{0:N0} ", chitiet.B1_TieuThu).Replace(",", "."),
                     string.Format("{0:N0} ", chitiet.B2_TieuThu).Replace(",", "."),
                     string.Format("{0:N0} ", chitiet.B3_TieuThu).Replace(",", "."),
                     0, string.Format("{0:N0} ", chitiet.Tong_TieuThu).Replace(",", "."));
                stt++;
            }



            //tính tổng dòng B
            DataRow[] drB = dt.Select("STT='B' AND Loai=0");
            drB[0]["Nhan_Bieu1_SanLuong"] = 0;
            drB[0]["Nhan_Bieu2_SanLuong"] = 0;
            drB[0]["Nhan_Bieu3_SanLuong"] = 0;
            drB[0]["Nhan1Gia"] = 0;
            drB[0]["TongNhan3B"] = 0;
            drB[0]["Giao_Bieu1_SanLuong"] = 0;
            drB[0]["Giao_Bieu2_SanLuong"] = 0;
            drB[0]["Giao_Bieu3_SanLuong"] = 0;
            drB[0]["Giao1Gia"] = 0;
            drB[0]["TongGiao3B"] = 0;
            drB[0]["B1_TieuThu"] = 0;
            drB[0]["B2_TieuThu"] = 0;
            drB[0]["B3_TieuThu"] = 0;
            drB[0]["Tong1Gia"] = 0;
            drB[0]["Tong_TieuThu"] = 0;

            drB[0]["Nhan_Bieu1_SanLuong1"] = string.Format("{0:N0} ", dt.Compute("sum(Nhan_Bieu1_SanLuong)", "Loai=3")).Replace(",", ".");
            drB[0]["Nhan_Bieu2_SanLuong1"] = string.Format("{0:N0} ", dt.Compute("sum(Nhan_Bieu2_SanLuong)", "Loai=3")).Replace(",", ".");
            drB[0]["Nhan_Bieu3_SanLuong1"] = string.Format("{0:N0} ", dt.Compute("sum(Nhan_Bieu3_SanLuong)", "Loai=3")).Replace(",", ".");
            drB[0]["Nhan1Gia1"] = string.Format("{0:N0} ", dt.Compute("sum(Nhan1Gia)", "Loai=3")).Replace(",", ".");
            drB[0]["TongNhan3B1"] = string.Format("{0:N0} ", dt.Compute("sum(TongNhan3B)", "Loai=3")).Replace(",", ".");
            drB[0]["Giao_Bieu1_SanLuong1"] = string.Format("{0:N0} ", dt.Compute("sum(Giao_Bieu1_SanLuong)", "Loai=3")).Replace(",", ".");
            drB[0]["Giao_Bieu2_SanLuong1"] = string.Format("{0:N0} ", dt.Compute("sum(Giao_Bieu2_SanLuong)", "Loai=3")).Replace(",", ".");
            drB[0]["Giao_Bieu3_SanLuong1"] = string.Format("{0:N0} ", dt.Compute("sum(Giao_Bieu3_SanLuong)", "Loai=3")).Replace(",", ".");
            drB[0]["Giao1Gia1"] = string.Format("{0:N0} ", dt.Compute("sum(Giao1Gia)", "Loai=3")).Replace(",", ".");
            drB[0]["TongGiao3B1"] = string.Format("{0:N0} ", dt.Compute("sum(TongGiao3B)", "Loai=3")).Replace(",", ".");
            drB[0]["B1_TieuThu1"] = string.Format("{0:N0} ", dt.Compute("sum(B1_TieuThu)", "Loai=3")).Replace(",", ".");
            drB[0]["B2_TieuThu1"] = string.Format("{0:N0} ", dt.Compute("sum(B2_TieuThu)", "Loai=3")).Replace(",", ".");
            drB[0]["B3_TieuThu1"] = string.Format("{0:N0} ", dt.Compute("sum(B3_TieuThu)", "Loai=3")).Replace(",", ".");
            drB[0]["Tong1Gia1"] = string.Format("{0:N0} ", dt.Compute("sum(Tong1Gia)", "Loai=3")).Replace(",", ".");
            drB[0]["Tong_TieuThu1"] = string.Format("{0:N0} ", dt.Compute("sum(Tong_TieuThu)", "Loai=3")).Replace(",", ".");

            var lstquyettoanMuaNgoai = db.BC_QuyetToanNgoaiNganh_CN(strMadviqly, Thang, Nam, PhuongThuc);
            stt = 1;
            dt.Rows.Add("C", "Mua ngoài ngành", 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0);
            foreach (var chitiet in lstquyettoanMuaNgoai)
            {
                dt.Rows.Add(stt, chitiet.khoitruyentai, 4, chitiet.Nhan_Bieu1_SanLuong, chitiet.Nhan_Bieu2_SanLuong, chitiet.Nhan_Bieu3_SanLuong, 0, chitiet.TongNhan3B, chitiet.Giao_Bieu1_SanLuong, chitiet.Giao_Bieu2_SanLuong, chitiet.Giao_Bieu3_SanLuong, 0, chitiet.TongGiao3B, chitiet.B1_TieuThu, chitiet.B2_TieuThu, chitiet.B3_TieuThu, 0, chitiet.Tong_TieuThu,

                      string.Format("{0:N0} ", chitiet.Nhan_Bieu1_SanLuong).Replace(",", "."),
                      string.Format("{0:N0} ", chitiet.Nhan_Bieu2_SanLuong).Replace(",", "."),
                      string.Format("{0:N0} ", chitiet.Nhan_Bieu3_SanLuong).Replace(",", "."), 0,
                      string.Format("{0:N0} ", chitiet.TongNhan3B).Replace(",", "."),
                      string.Format("{0:N0} ", chitiet.Giao_Bieu1_SanLuong).Replace(",", "."),
                      string.Format("{0:N0} ", chitiet.Giao_Bieu2_SanLuong).Replace(",", "."),
                      string.Format("{0:N0} ", chitiet.Giao_Bieu3_SanLuong).Replace(",", "."),
                      0, string.Format("{0:N0} ", chitiet.TongGiao3B).Replace(",", ".")
                      , string.Format("{0:N0} ", chitiet.B1_TieuThu).Replace(",", "."),
                      string.Format("{0:N0} ", chitiet.B2_TieuThu).Replace(",", "."),
                      string.Format("{0:N0} ", chitiet.B3_TieuThu).Replace(",", "."),
                      0, string.Format("{0:N0} ", chitiet.Tong_TieuThu).Replace(",", "."));
                stt++;
            }

            DataRow[] drC = dt.Select("STT='C' AND Loai=0");
            drC[0]["Nhan_Bieu1_SanLuong"] = 0;
            drC[0]["Nhan_Bieu2_SanLuong"] = 0;
            drC[0]["Nhan_Bieu3_SanLuong"] = 0;
            drC[0]["Nhan1Gia"] = 0;
            drC[0]["TongNhan3B"] = 0;
            drC[0]["Giao_Bieu1_SanLuong"] = 0;
            drC[0]["Giao_Bieu2_SanLuong"] = 0;
            drC[0]["Giao_Bieu3_SanLuong"] = 0;
            drC[0]["Giao1Gia"] = 0;
            drC[0]["TongGiao3B"] = 0;
            drC[0]["B1_TieuThu"] = 0;
            drC[0]["B2_TieuThu"] = 0;
            drC[0]["B3_TieuThu"] = 0;
            drC[0]["Tong1Gia"] = 0;
            drC[0]["Tong_TieuThu"] = 0;

            drC[0]["Nhan_Bieu1_SanLuong1"] = string.Format("{0:N0} ", dt.Compute("sum(Nhan_Bieu1_SanLuong)", "Loai=4")).Replace(",", ".");
            drC[0]["Nhan_Bieu2_SanLuong1"] = string.Format("{0:N0} ", dt.Compute("sum(Nhan_Bieu2_SanLuong)", "Loai=4")).Replace(",", ".");
            drC[0]["Nhan_Bieu3_SanLuong1"] = string.Format("{0:N0} ", dt.Compute("sum(Nhan_Bieu3_SanLuong)", "Loai=4")).Replace(",", ".");
            drC[0]["Nhan1Gia1"] = string.Format("{0:N0} ", dt.Compute("sum(Nhan1Gia)", "Loai=4")).Replace(",", ".");
            drC[0]["TongNhan3B1"] = string.Format("{0:N0} ", dt.Compute("sum(TongNhan3B)", "Loai=4")).Replace(",", ".");
            drC[0]["Giao_Bieu1_SanLuong1"] = string.Format("{0:N0} ", dt.Compute("sum(Giao_Bieu1_SanLuong)", "Loai=4")).Replace(",", ".");
            drC[0]["Giao_Bieu2_SanLuong1"] = string.Format("{0:N0} ", dt.Compute("sum(Giao_Bieu2_SanLuong)", "Loai=4")).Replace(",", ".");
            drC[0]["Giao_Bieu3_SanLuong1"] = string.Format("{0:N0} ", dt.Compute("sum(Giao_Bieu3_SanLuong)", "Loai=4")).Replace(",", ".");
            drC[0]["Giao1Gia1"] = string.Format("{0:N0} ", dt.Compute("sum(Giao1Gia)", "Loai=4")).Replace(",", ".");
            drC[0]["TongGiao3B1"] = string.Format("{0:N0} ", dt.Compute("sum(TongGiao3B)", "Loai=4")).Replace(",", ".");
            drC[0]["B1_TieuThu1"] = string.Format("{0:N0} ", dt.Compute("sum(B1_TieuThu)", "Loai=4")).Replace(",", ".");
            drC[0]["B2_TieuThu1"] = string.Format("{0:N0} ", dt.Compute("sum(B2_TieuThu)", "Loai=4")).Replace(",", ".");
            drC[0]["B3_TieuThu1"] = string.Format("{0:N0} ", dt.Compute("sum(B3_TieuThu)", "Loai=4")).Replace(",", ".");
            drC[0]["Tong1Gia1"] = string.Format("{0:N0} ", dt.Compute("sum(Tong1Gia)", "Loai=4")).Replace(",", ".");
            drC[0]["Tong_TieuThu1"] = string.Format("{0:N0} ", dt.Compute("sum(Tong_TieuThu)", "Loai=4")).Replace(",", ".");

            var lstMTAPM = db.BC_QuyetToanMTApMai_CN(strMadviqly, Thang, Nam, PhuongThuc);
            stt = 1;

            foreach (var chitiet in lstMTAPM)
            {
                dt.Rows.Add("D", "Mặt trời áp mái", 5, chitiet.Nhan_Bieu1_SanLuong, chitiet.Nhan_Bieu2_SanLuong, chitiet.Nhan_Bieu3_SanLuong, chitiet.Nhan_1Gia, chitiet.TongNhan3B, chitiet.Giao_Bieu1_SanLuong, chitiet.Giao_Bieu2_SanLuong, chitiet.Giao_Bieu3_SanLuong, chitiet.Giao_1Gia, chitiet.TongGiao3B, chitiet.B1_TieuThu, chitiet.B2_TieuThu, chitiet.B3_TieuThu, chitiet.MGia_TieuThu, chitiet.Tong_TieuThu

                ,string.Format("{0:N0} ", chitiet.Nhan_Bieu1_SanLuong).Replace(",", "."),
                string.Format("{0:N0} ", chitiet.Nhan_Bieu2_SanLuong).Replace(",", "."),
                string.Format("{0:N0} ", chitiet.Nhan_Bieu3_SanLuong).Replace(",", "."),
                string.Format("{0:N0} ", chitiet.Nhan_1Gia).Replace(",", "."),
                string.Format("{0:N0} ", chitiet.TongNhan3B).Replace(",", "."),
                string.Format("{0:N0} ", chitiet.Giao_Bieu1_SanLuong).Replace(",", "."),
                string.Format("{0:N0} ", chitiet.Giao_Bieu2_SanLuong).Replace(",", "."),
                string.Format("{0:N0} ", chitiet.Giao_Bieu3_SanLuong).Replace(",", "."),
                string.Format("{0:N0} ", chitiet.Giao_1Gia).Replace(",", "."),
                string.Format("{0:N0} ", chitiet.TongGiao3B).Replace(",", "."),
                string.Format("{0:N0} ", chitiet.B1_TieuThu).Replace(",", "."),
                string.Format("{0:N0} ", chitiet.B2_TieuThu).Replace(",", "."),
                string.Format("{0:N0} ", chitiet.B3_TieuThu).Replace(",", "."),
                string.Format("{0:N0} ", chitiet.MGia_TieuThu).Replace(",", "."),
                string.Format("{0:N0} ", chitiet.Tong_TieuThu).Replace(",", "."));
                break;
            }
            //DM_DVQLYService dm_dviSer = new DM_DVQLYService();
            // var donvi = dm_dviSer.SelectDM_DVQLY(strMadviqly);

            //DM_DVQLYService dm_dviSer = new DM_DVQLYService();
            //var donvi = dm_dviSer.SelectDM_DVQLY(strMadviqly);
            */
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