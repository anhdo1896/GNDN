﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Web.UI;
namespace CBDN.Class
{
    public class LS_InBienBanQT
    {
        public DataTable InBienBanQuyetToan(int PhuongThuc, int strMadviqly, int Thang, int Nam, ref string strTenDVGiao, ref string strTenDVnhan, ref string strGDNhan, ref string strGDGiao)
        {
            CBDN.DB_CBDNDataContext db = new CBDN.DB_CBDNDataContext(new CBDN.ADOController().strcn());

            DataTable dt = new DataTable();
            dt.Columns.Add("STT");
            dt.Columns.Add("TenDonVi");
            dt.Columns.Add("Loai", typeof(int));

            dt.Columns.Add("Nhan_Bieu1_SanLuong", typeof(decimal));
            dt.Columns.Add("Nhan_Bieu2_SanLuong", typeof(decimal));
            dt.Columns.Add("Nhan_Bieu3_SanLuong", typeof(decimal));
            dt.Columns.Add("Nhan1Gia", typeof(decimal));
            dt.Columns.Add("TongNhan3B", typeof(decimal));
            dt.Columns.Add("Giao_Bieu1_SanLuong", typeof(decimal));
            dt.Columns.Add("Giao_Bieu2_SanLuong", typeof(decimal));
            dt.Columns.Add("Giao_Bieu3_SanLuong", typeof(decimal));
            dt.Columns.Add("Giao1Gia", typeof(decimal));
            dt.Columns.Add("TongGiao3B", typeof(decimal));
            dt.Columns.Add("B1_TieuThu", typeof(decimal));
            dt.Columns.Add("B2_TieuThu", typeof(decimal));
            dt.Columns.Add("B3_TieuThu", typeof(decimal));
            dt.Columns.Add("Tong1Gia", typeof(decimal));
            dt.Columns.Add("Tong_TieuThu", typeof(decimal));

            dt.Columns.Add("Nhan_Bieu1_SanLuong1", typeof(string));
            dt.Columns.Add("Nhan_Bieu2_SanLuong1", typeof(string));
            dt.Columns.Add("Nhan_Bieu3_SanLuong1", typeof(string));
            dt.Columns.Add("Nhan1Gia1", typeof(string));
            dt.Columns.Add("TongNhan3B1", typeof(string));
            dt.Columns.Add("Giao_Bieu1_SanLuong1", typeof(string));
            dt.Columns.Add("Giao_Bieu2_SanLuong1", typeof(string));
            dt.Columns.Add("Giao_Bieu3_SanLuong1", typeof(string));
            dt.Columns.Add("Giao1Gia1", typeof(string));
            dt.Columns.Add("TongGiao3B1", typeof(string));
            dt.Columns.Add("B1_TieuThu1", typeof(string));
            dt.Columns.Add("B2_TieuThu1", typeof(string));
            dt.Columns.Add("B3_TieuThu1", typeof(string));
            dt.Columns.Add("Tong1Gia1", typeof(string));
            dt.Columns.Add("Tong_TieuThu1", typeof(string));

            var lstquyettoanTT = db.BC_LS_QuyetToanTruyenTai(strMadviqly, Thang, Nam, PhuongThuc);
            int stt = 1;
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


            var lstquyettoan = db.BC_LS_QuyetToan(strMadviqly, Thang, Nam, PhuongThuc);

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

            var lstquyettoanSX = db.BC_LS_QuyetToanTuSX(strMadviqly, Thang, Nam, PhuongThuc);
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

            var lstquyettoanMuaNgoai = db.BC_LS_QuyetToanNgoaiNganh(strMadviqly, Thang, Nam, PhuongThuc);
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

            var lstMTAPM = db.BC_LS_QuyetToanMTApMai(strMadviqly, Thang, Nam, PhuongThuc);
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


                var imGDGiao = db.HD_ThongTinKies.SingleOrDefault(x => x.IDMaDViQLy == giao.IDMA_DVIQLY && x.IDChinhNhanh == PhuongThuc && x.Thang == Thang && x.Nam == Nam && x.ChucVu == 3 && x.TrangThai == null);
                var imGDNhan = db.HD_ThongTinKies.SingleOrDefault(x => x.IDMaDViQLy == nhan.IDMA_DVIQLY && x.IDChinhNhanh == PhuongThuc && x.Thang == Thang && x.Nam == Nam && x.ChucVu == 3 && x.TrangThai == null);

                if (imGDGiao != null)
                {
                    var ngGiao = db.DM_USERs.SingleOrDefault(x => x.IDUSER == imGDGiao.NguoiTao);
                    if (ngGiao.CHUCDANH == null)
                    {
                        ngGiao.CHUCDANH = "Giám Đốc";
                    }
                    var chucdanh = ngGiao.CHUCDANH.ToUpper();
                    var TenCty = db.DM_DVQLies.SingleOrDefault(x => x.IDMA_DVIQLY == ngGiao.IDMA_DVIQLY);
                    var ten = TenCty.TEN_DVIQLY;
                    ten = ten.ToUpper();
                    strGDGiao = ngGiao.HOTEN + "</br> Đơn vị: " + chucdanh + " - " + ten + "</br> Thời gian xác nhận: " + String.Format("{0:dd-MM-yyyy HH:mm:ss}", imGDGiao.NgayTao);
                }
                if (imGDNhan != null)
                {
                    var ngNhan = db.DM_USERs.SingleOrDefault(x => x.IDUSER == imGDNhan.NguoiTao);
                    if (ngNhan.CHUCDANH == null)
                    {
                        ngNhan.CHUCDANH = "Giám Đốc";
                    }
                    var chucdanh = ngNhan.CHUCDANH.ToUpper();
                    var TenCty = db.DM_DVQLies.SingleOrDefault(x => x.IDMA_DVIQLY == ngNhan.IDMA_DVIQLY);
                    var ten = TenCty.TEN_DVIQLY;
                    ten = ten.ToUpper();
                    strGDNhan = ngNhan.HOTEN + "</br> Đơn vị: " + chucdanh + " - " + ten + "</br> Thời gian xác nhận: " + String.Format("{0:dd-MM-yyyy HH:mm:ss}", imGDNhan.NgayTao);
                }
                strTenDVGiao = giao.TEN_DVIQLY;
                strTenDVnhan = nhan.TEN_DVIQLY;
            }
            else

            {
                var lstPT = db.DM_ChiNhanhs.Where(x => x.DiemCuoiNguon == 2).Where(x => x.DiemDauNguon == strMadviqly).ToList();
                if (lstPT.Count == 0)
                {
                    lstPT = db.DM_ChiNhanhs.Where(x => x.DiemCuoiNguon == strMadviqly).Where(x => x.DiemDauNguon == 2).ToList();
                }
                if (lstPT.Count != 0)
                {
                    foreach (var list in lstPT)
                    {
                        PhuongThuc = list.ID;
                    }
                }
                var imGDGiao = db.HD_ThongTinKies.SingleOrDefault(x => x.IDMaDViQLy == 2 && x.IDChinhNhanh == PhuongThuc && x.Thang == Thang && x.Nam == Nam && x.ChucVu == 3 && x.TrangThai == null);
                var imGDNhan = db.HD_ThongTinKies.SingleOrDefault(x => x.IDMaDViQLy == strMadviqly && x.IDChinhNhanh == PhuongThuc && x.Thang == Thang && x.Nam == Nam && x.ChucVu == 3 && x.TrangThai == null);
                if (imGDGiao != null)
                {
                    var ngGiao = db.DM_USERs.SingleOrDefault(x => x.IDUSER == imGDGiao.NguoiTao);
                    if (ngGiao.CHUCDANH == null)
                    {
                        ngGiao.CHUCDANH = "Giám Đốc";
                    }
                    var chucdanh = ngGiao.CHUCDANH.ToUpper();
                    var TenCty = db.DM_DVQLies.SingleOrDefault(x => x.IDMA_DVIQLY == ngGiao.IDMA_DVIQLY);
                    var ten = TenCty.TEN_DVIQLY;
                    ten = ten.ToUpper();
                    strGDGiao = ngGiao.HOTEN + "</br> Đơn vị: " + chucdanh + " - " + ten + "</br> Thời gian xác nhận: " + String.Format("{0:dd-MM-yyyy HH:mm:ss}", imGDGiao.NgayTao);
                }
                if (imGDNhan != null)
                {
                    var ngNhan = db.DM_USERs.SingleOrDefault(x => x.IDUSER == imGDNhan.NguoiTao);
                    if (ngNhan.CHUCDANH == null)
                    {
                        ngNhan.CHUCDANH = "Giám Đốc";
                    }
                    var chucdanh = ngNhan.CHUCDANH.ToUpper();
                    var TenCty = db.DM_DVQLies.SingleOrDefault(x => x.IDMA_DVIQLY == ngNhan.IDMA_DVIQLY);
                    var ten = TenCty.TEN_DVIQLY;
                    ten = ten.ToUpper();
                    strGDNhan = ngNhan.HOTEN + "</br> Đơn vị: " + chucdanh + " - " + ten + "</br> Thời gian xác nhận: " + String.Format("{0:dd-MM-yyyy HH:mm:ss}", imGDNhan.NgayTao);
                }


                strTenDVGiao = "TỔNG CÔNG TY ĐIỆN LỰC MIỀN BẮC";
                strTenDVnhan = db.DM_DVQLies.SingleOrDefault(x => x.IDMA_DVIQLY == strMadviqly).TEN_DVIQLY;

            }


            return dt;
        }
    }
}