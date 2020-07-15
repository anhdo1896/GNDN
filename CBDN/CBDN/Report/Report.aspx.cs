using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using SystemManageService;
using DevExpress.XtraReports.UI;
namespace MTCSYT.Report
{
    public partial class Report : MTCSYT.BasePage
    {
        DataAccess.TonThat dbOR = new DataAccess.TonThat();
        CBDN.DB_CBDNDataContext db = new CBDN.DB_CBDNDataContext(new CBDN.ADOController().strcn());
        protected void Page_Load(object sender, EventArgs e)
        {
            string id = Request["Loai"];
            switch (id)
            {
                case "1":
                    Literal2.Text = "Biên bản quyết toán";
                    ltrTenBaoCao.Text = "Biên bản quyết toán";
                    InBienBanQuyetToan();
                    break;
                case "2":
                    Literal2.Text = "Tổng hợp điện năng giao nhận";
                    ltrTenBaoCao.Text = "Tổng hợp điện năng giao nhận";
                    InTongHopDienNang();
                    break;
                case "3":
                    Literal2.Text = "Tổng hợp điện năng giao nhận sau chốt";
                    ltrTenBaoCao.Text = "Tổng hợp điện năng giao nhận sau chốt";
                    InTongHopDienNangSauChot();
                    break;
                case "4":
                    Literal2.Text = " BẢNG TỔNG HỢP TBA, KHÁCH HÀNG CÓ ĐIỆN ÁP THẤP";
                    ltrTenBaoCao.Text = " BẢNG TỔNG HỢP TBA, KHÁCH HÀNG CÓ ĐIỆN ÁP THẤP";
                    InTongHopKHDAThap();
                    break;
                case "6":
                    Literal2.Text = "TỔNG HỢP TTĐN LŨY KẾ CÁC TBA PHÂN PHỐI THÁNG";
                    ltrTenBaoCao.Text = " TỔNG HỢP TTĐN LŨY KẾ CÁC TBA PHÂN PHỐI THÁNG ";
                    TBA();
                    break;
                case "5":
                    Literal2.Text = " Biểu số lượng đường dây trung áp có tỷ lệ TTĐN theo mức (%)";
                    ltrTenBaoCao.Text = " Biểu số lượng đường dây trung áp có tỷ lệ TTĐN theo mức (%)";
                    dZ();
                    break;
                case "7":
                    Literal2.Text = "Biên bản quyết toán";
                    ltrTenBaoCao.Text = "Biên bản quyết toán";
                    InBienBanQT_LS();
                    break;
                case "8":
                    Literal2.Text = "TỔNG HỢP DỮ LIỆU LỊCH SỬ ĐIỆN NĂNG GIAO NHẬN";
                    ltrTenBaoCao.Text = "Tổng hợp dữ liệu lịch sử điện năng giao nhận";
                    InTongHopDienNang_LichSu();
                    break;
                case "9":
                    Literal2.Text = "TỔNG HỢP ĐIỀU HÀNH TIẾT KIỆM ĐIỆN";
                    ltrTenBaoCao.Text = "Tổng hợp điều hàng tiết kiệm điện";
                    DN_TK_KeHoach();
                    break;
                case "10":
                    Literal2.Text = "TỔNG HỢP CHI TIẾT ĐIỀU HÀNH TIẾT KIỆM ĐIỆN";
                    ltrTenBaoCao.Text = "Tổng hợp chi tiết điều hàng tiết kiệm điện";
                    DN_TK_ChiTiet();
                    break;
                case "11":
                    Literal2.Text = "TỔNG HỢP CHI TIẾT ĐIỀU HÀNH TIẾT KIỆM ĐIỆN THƯƠNG PHẨM";
                    ltrTenBaoCao.Text = "Tổng hợp chi tiết điều hàng tiết kiệm điện thương phẩm";
                    DN_TK_ChiTietThuongPham();
                    break;
                case "12":
                    Literal2.Text = "TỔNG HỢP CHI TIẾT ĐIỀU HÀNH TIẾT KIỆM ĐIỆN THƯƠNG PHẨM";
                    ltrTenBaoCao.Text = "Tổng hợp chi tiết điều hàng tiết kiệm điện thương phẩm";
                    DN_TK_ChiTietTP_New();
                    break;
                case "13":
                    Literal2.Text = "TỔNG HỢP ĐIỀU HÀNH TIẾT KIỆM ĐIỆN THƯƠNG PHẨM";
                    ltrTenBaoCao.Text = "Tổng hợp điều hàng tiết kiệm điện thương phẩm";
                    DN_TK_ThuongPham_New();
                    break;
                default:
                    Response.Redirect("~\\");
                    break;
            }

        }
        private void DN_TK_ThuongPham_New()
        {
            MTCSYT.SYS_Session session = (MTCSYT.SYS_Session)Session["SYS_Session"];
            int ma_dviqly = int.Parse(session.User.ma_dviqly);
            DM_DVQLYService dm_dviSer = new DM_DVQLYService();
            var donvi = dm_dviSer.SelectDM_DVQLY(int.Parse(Request["DonVi"] + ""));


            int thangtr, namtr, thangN2, namN2;
            if (Request["Thang"] + "" == "1")
            {
                thangtr = 12;
                namtr = int.Parse(Request["Nam"] + "") - 1;
                thangN2 = 11;
                namN2 = int.Parse(Request["Nam"] + "") - 1;
            }
            else if (Request["Thang"] + "" == "2")
            {
                thangtr = 1;
                namtr = int.Parse(Request["Nam"] + "");
                thangN2 = 12;
                namN2 = int.Parse(Request["Nam"] + "") - 1;
            }
            else
            {
                thangtr = int.Parse(Request["Thang"] + "") - 1;
                namtr = int.Parse(Request["Nam"] + "");
                thangN2 = int.Parse(Request["Thang"] + "") - 2;
                namN2 = int.Parse(Request["Nam"] + "");
            }

            //DataTable dt = dbOR.DN_TK_ThucTeTCT(int.Parse(Request["Thang"] + ""), int.Parse(Request["Nam"] + ""), thangtr, namtr, thangN2, namN2, int.Parse(Request["TuNgay"] + ""), int.Parse(Request["DenNgay"] + ""));

            CBDN.ConvertListToTable cv = new CBDN.ConvertListToTable();
            var tk = db.DN_TK_ThucTeTCT(int.Parse(Request["Thang"] + ""), int.Parse(Request["Nam"] + ""), thangtr, namtr, thangN2, namN2, int.Parse(Request["TuNgay"] + ""), int.Parse(Request["DenNgay"] + ""));
            DataTable dt = cv.ConvertToDataTable(tk.ToList());

            MTCSYT.Report.InDN_ThuongPhamTCT report = new MTCSYT.Report.InDN_ThuongPhamTCT(dt, "" + Request["Thang"], "" + Request["Nam"], donvi.TEN_DVIQLY, int.Parse(Request["DonVi"] + ""));

            ReportViewer1.Report = report;

            ReportToolbar1.ReportViewer = ReportViewer1;
        }
        private void DN_TK_ChiTietTP_New()
        {
            MTCSYT.SYS_Session session = (MTCSYT.SYS_Session)Session["SYS_Session"];
            int ma_dviqly = int.Parse(session.User.ma_dviqly);
            DM_DVQLYService dm_dviSer = new DM_DVQLYService();
            var donvi = dm_dviSer.SelectDM_DVQLY(int.Parse(Request["DonVi"] + ""));


            int thangtr, namtr, thangN2, namN2;
            if (Request["Thang"] + "" == "1")
            {
                thangtr = 12;
                namtr = int.Parse(Request["Nam"] + "") - 1;
                thangN2 = 11;
                namN2 = int.Parse(Request["Nam"] + "") - 1;
            }
            else if (Request["Thang"] + "" == "2")
            {
                thangtr = 1;
                namtr = int.Parse(Request["Nam"] + "");
                thangN2 = 12;
                namN2 = int.Parse(Request["Nam"] + "") - 1;
            }
            else
            {
                thangtr = int.Parse(Request["Thang"] + "") - 1;
                namtr = int.Parse(Request["Nam"] + "");
                thangN2 = int.Parse(Request["Thang"] + "") - 2;
                namN2 = int.Parse(Request["Nam"] + "");
            }
            CBDN.ConvertListToTable cv = new CBDN.ConvertListToTable();
            var tk = db.DN_TK_ThucTeDonVi(int.Parse(Request["DonVi"] + ""), int.Parse(Request["Thang"] + ""), int.Parse(Request["Nam"] + ""), thangtr, namtr, thangN2, namN2, int.Parse(Request["TuNgay"] + ""), int.Parse(Request["DenNgay"] + ""));
            DataTable dt = cv.ConvertToDataTable(tk.ToList());
            // DataTable dt = dbOR.DN_TK_ThucTeDonVi();
            MTCSYT.Report.InDN_ChiTietThuongPham_DonVi report = new MTCSYT.Report.InDN_ChiTietThuongPham_DonVi(dt, "" + Request["Thang"], "" + Request["Nam"], donvi.TEN_DVIQLY, int.Parse(Request["DonVi"] + ""), Request["TCT"] + "");

            ReportViewer1.Report = report;

            ReportToolbar1.ReportViewer = ReportViewer1;
        }
        private void DN_TK_ChiTietThuongPham()
        {
            MTCSYT.SYS_Session session = (MTCSYT.SYS_Session)Session["SYS_Session"];
            int ma_dviqly = int.Parse(session.User.ma_dviqly);
            DM_DVQLYService dm_dviSer = new DM_DVQLYService();
            var donvi = dm_dviSer.SelectDM_DVQLY(int.Parse(Request["DonVi"] + ""));
            DataTable dt = Dienthuongpham();
            MTCSYT.Report.InDN_ThuongPham report = new MTCSYT.Report.InDN_ThuongPham(dt, "" + Request["Thang"], "" + Request["Nam"], donvi.TEN_DVIQLY, int.Parse(Request["DonVi"] + ""));

            ReportViewer1.Report = report;

            ReportToolbar1.ReportViewer = ReportViewer1;
        }
        private DataTable Dienthuongpham()
        {
            DataTable dt = new DataTable();
            dt.Columns.Add("Ngay");
            for (int i = 1; i <= 31; i++)
            {
                dt.Columns.Add(i + "");
            }
            dt.Rows.Add("Sản lượng thương phẩm tháng trước");
            dt.Rows.Add("Sản lượng kế hoạch tháng hiện tại");
            dt.Rows.Add("Sản lượng thương phẩm thực hiện tháng hiện tại");
            dt.Rows.Add("Chênh lệch tháng hiện tại");
            dt.Rows.Add("Chênh lệch tháng trước");

            // lấy điện thương phẩm tháng trước
            int thangtruoc, namtrc;
            if (Request["Thang"] + "" == "1")
            {
                thangtruoc = 12;
                namtrc = int.Parse(Request["Thang"] + "") - 1;
            }
            else
            {
                thangtruoc = int.Parse(Request["Thang"] + "") - 1;
                namtrc = int.Parse(Request["Nam"] + "");
            }

            // lấy điện thương phẩm tháng này

            for (int i = int.Parse(Request["TuNgay"] + ""); i < int.Parse(Request["DenNgay"] + ""); i++)
            {
                var lstTruoc = db.DN_CTy_DienNhans.SingleOrDefault(x => x.IDMA_DVIQLY == int.Parse(Request["DonVi"] + "") && x.Thang == thangtruoc && x.Nam == namtrc && x.Ngay == int.Parse(dt.Columns[i].ToString()));
                if (lstTruoc != null)
                    dt.Rows[0][i] = lstTruoc.DienNhan;
                var lst = db.DN_CTy_DienNhans.SingleOrDefault(x => x.IDMA_DVIQLY == int.Parse(Request["DonVi"] + "") && x.Thang == int.Parse(Request["Thang"] + "") && x.Nam == int.Parse("" + Request["Nam"]) && x.Ngay == int.Parse(dt.Columns[i].ToString()));
                if (lst != null)
                {
                    dt.Rows[1][i] = lst.SanLuongKH;
                    dt.Rows[2][i] = lst.DienNhan;
                }
            }
            return dt;

        }
        private void DN_TK_ChiTiet()
        {
            MTCSYT.SYS_Session session = (MTCSYT.SYS_Session)Session["SYS_Session"];
            int ma_dviqly = int.Parse(session.User.ma_dviqly);
            DM_DVQLYService dm_dviSer = new DM_DVQLYService();
            var donvi = dm_dviSer.SelectDM_DVQLY(int.Parse(Request["DonVi"] + ""));

            //CBDN.ConvertListToTable cv = new CBDN.ConvertListToTable();
            // var tk = db.DN_TK_ThucTeDonVi(int.Parse(Request["DonVi"] + ""), int.Parse("" + Request["Thang"]), int.Parse("" + Request["Nam"]));
            //DataTable dt = cv.ConvertToDataTable(tk.ToList());

            DataTable dt = dbOR.DN_TK_ThucTeDonVi_ByThangNam(int.Parse(Request["DonVi"] + ""), int.Parse("" + Request["Thang"]), int.Parse("" + Request["Nam"]));
            MTCSYT.Report.InDN_ChiTiet report = new MTCSYT.Report.InDN_ChiTiet(dt, "" + Request["Thang"], "" + Request["Nam"], donvi.TEN_DVIQLY, int.Parse(Request["DonVi"] + ""));

            ReportViewer1.Report = report;

            ReportToolbar1.ReportViewer = ReportViewer1;
        }
        private void DN_TK_KeHoach()
        {
            MTCSYT.SYS_Session session = (MTCSYT.SYS_Session)Session["SYS_Session"];
            int ma_dviqly = int.Parse(session.User.ma_dviqly);
            DM_DVQLYService dm_dviSer = new DM_DVQLYService();
            var donvi = dm_dviSer.SelectDM_DVQLY(ma_dviqly);
            //DataTable dt = dbOR.DN_TK_DNKeHoach(int.Parse(session.User.ma_dviqly), int.Parse("" + Request["Thang"]), int.Parse("" + Request["Nam"]), int.Parse(Request["Ngay"] + ""));

            CBDN.ConvertListToTable cv = new CBDN.ConvertListToTable();
            var tk = db.DN_TK_DNKeHoach(int.Parse(session.User.ma_dviqly), int.Parse("" + Request["Thang"]), int.Parse("" + Request["Nam"]), int.Parse(Request["Ngay"] + ""));
            DataTable dt = cv.ConvertToDataTable(tk.ToList());

            MTCSYT.Report.InDN_DuKien report = new MTCSYT.Report.InDN_DuKien(dt, "" + Request["Thang"], "" + Request["Nam"], Request["Ngay"], donvi.TEN_DVIQLY);

            ReportViewer1.Report = report;

            ReportToolbar1.ReportViewer = ReportViewer1;
        }
        private void InBienBanQT_LS()
        {
            // MTCSYT.SYS_Session session = (MTCSYT.SYS_Session)Session["SYS_Session"];
            int strMadviqly = int.Parse(Request["ChiNhanh"] + "");

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


            var lstquyettoanTT = db.BC_LS_QuyetToanTruyenTai(strMadviqly, int.Parse(Request["Thang"]), int.Parse(Request["Nam"]));
            int stt = 1;
            dt.Rows.Add("A", "Từ hệ thống của EVN NPC", 0);
            foreach (var chitiet in lstquyettoanTT)
            {
                dt.Rows.Add(stt, chitiet.khoitruyentai, 1, chitiet.Nhan_Bieu1_SanLuong, chitiet.Nhan_Bieu2_SanLuong, chitiet.Nhan_Bieu3_SanLuong, 0, chitiet.TongNhan3B, chitiet.Giao_Bieu1_SanLuong, chitiet.Giao_Bieu2_SanLuong, chitiet.Giao_Bieu3_SanLuong, 0, chitiet.TongGiao3B, chitiet.B1_TieuThu, chitiet.B2_TieuThu, chitiet.B3_TieuThu, 0, chitiet.Tong_TieuThu);
                stt++;
            }
            var lstquyettoan = db.BC_LS_QuyetToan(strMadviqly, int.Parse(Request["Thang"]), int.Parse(Request["Nam"]), int.Parse(Request["ParentId"]));

            foreach (var chitiet in lstquyettoan)
            {
                dt.Rows.Add(stt, chitiet.TenCongTy, 2, chitiet.Nhan_Bieu1_SanLuong, chitiet.Nhan_Bieu2_SanLuong, chitiet.Nhan_Bieu3_SanLuong, 0, chitiet.TongNhan3B, chitiet.Giao_Bieu1_SanLuong, chitiet.Giao_Bieu2_SanLuong, chitiet.Giao_Bieu3_SanLuong, 0, chitiet.TongGiao3B, chitiet.B1_TieuThu, chitiet.B2_TieuThu, chitiet.B3_TieuThu, 0, chitiet.Tong_TieuThu);
                stt++;
            }

            var lstquyettoanSX = db.BC_LS_QuyetToanTuSX(strMadviqly, int.Parse(Request["Thang"]), int.Parse(Request["Nam"]));
            stt = 1;
            dt.Rows.Add("B", "Tự sản xuất", 0);
            foreach (var chitiet in lstquyettoanSX)
            {
                dt.Rows.Add(stt, chitiet.khoitruyentai, 3, chitiet.Nhan_Bieu1_SanLuong, chitiet.Nhan_Bieu2_SanLuong, chitiet.Nhan_Bieu3_SanLuong, 0, chitiet.TongNhan3B, chitiet.Giao_Bieu1_SanLuong, chitiet.Giao_Bieu2_SanLuong, chitiet.Giao_Bieu3_SanLuong, 0, chitiet.TongGiao3B, chitiet.B1_TieuThu, chitiet.B2_TieuThu, chitiet.B3_TieuThu, 0, chitiet.Tong_TieuThu);
                stt++;
            }

            var lstquyettoanMuaNgoai = db.BC_LS_QuyetToanNgoaiNganh(strMadviqly, int.Parse(Request["Thang"]), int.Parse(Request["Nam"]));
            stt = 1;
            dt.Rows.Add("C", "Mua ngoài ngành", 0);
            foreach (var chitiet in lstquyettoanMuaNgoai)
            {
                dt.Rows.Add(stt, chitiet.khoitruyentai, 4, chitiet.Nhan_Bieu1_SanLuong, chitiet.Nhan_Bieu2_SanLuong, chitiet.Nhan_Bieu3_SanLuong, 0, chitiet.TongNhan3B, chitiet.Giao_Bieu1_SanLuong, chitiet.Giao_Bieu2_SanLuong, chitiet.Giao_Bieu3_SanLuong, 0, chitiet.TongGiao3B, chitiet.B1_TieuThu, chitiet.B2_TieuThu, chitiet.B3_TieuThu, 0, chitiet.Tong_TieuThu);
                stt++;
            }
            var lstMTAPM = db.BC_LS_QuyetToanMTApMai(strMadviqly, int.Parse(Request["Thang"]), int.Parse(Request["Nam"]));
            stt = 1;

            foreach (var chitiet in lstMTAPM)
            {
                dt.Rows.Add("D", "Mặt trời áp mái", 5, chitiet.Nhan_Bieu1_SanLuong, chitiet.Nhan_Bieu2_SanLuong, chitiet.Nhan_Bieu3_SanLuong, chitiet.Nhan_1Gia, chitiet.TongNhan3B, chitiet.Giao_Bieu1_SanLuong, chitiet.Giao_Bieu2_SanLuong, chitiet.Giao_Bieu3_SanLuong, chitiet.Giao_1Gia, chitiet.TongGiao3B, chitiet.B1_TieuThu, chitiet.B2_TieuThu, chitiet.B3_TieuThu, chitiet.MGia_TieuThu, chitiet.Tong_TieuThu);
                break;
            }
            var cn = db.DM_ChiNhanhs.SingleOrDefault(x => x.ID == int.Parse(Request["ChiNhanh"]));
            var giao = db.DM_DVQLies.SingleOrDefault(x => x.IDMA_DVIQLY == cn.DiemDauNguon);
            var nhan = db.DM_DVQLies.SingleOrDefault(x => x.IDMA_DVIQLY == cn.DiemCuoiNguon);
            MTCSYT.Report.InBienBanQT report = new MTCSYT.Report.InBienBanQT(dt, "" + Request["Thang"], "" + Request["Nam"], false, false, "", "", giao.TEN_DVIQLY, nhan.TEN_DVIQLY, "", "", "", "");
            ReportViewer1.Report = report;

            ReportToolbar1.ReportViewer = ReportViewer1;
        }

        private void TBA()
        {
            MTCSYT.SYS_Session session = (MTCSYT.SYS_Session)Session["SYS_Session"];
            int ma_dviqly = int.Parse(session.User.ma_dviqly);
            DM_DVQLYService dm_dviSer = new DM_DVQLYService();
            var donvi = dm_dviSer.SelectDM_DVQLY(ma_dviqly);
            DataTable dt = dbOR.Get_BCTT_TBACC(Request["DonVi"] + "", int.Parse("" + Request["Thang"]), int.Parse("" + Request["Nam"]), Request["LanBC"] + "", int.Parse(Request["LuyKe"] + ""));
            MTCSYT.Report.InTBA report = new MTCSYT.Report.InTBA(dt, "" + Request["Thang"], "" + Request["Nam"], donvi.TEN_DVIQLY);

            ReportViewer1.Report = report;

            ReportToolbar1.ReportViewer = ReportViewer1;
        }
        private void dZ()
        {
            MTCSYT.SYS_Session session = (MTCSYT.SYS_Session)Session["SYS_Session"];
            int ma_dviqly = int.Parse(session.User.ma_dviqly);
            DM_DVQLYService dm_dviSer = new DM_DVQLYService();
            var donvi = dm_dviSer.SelectDM_DVQLY(ma_dviqly);
            DataTable dt = dbOR.Get_BCTT_LDD(Request["DonVi"] + "", int.Parse("" + Request["Thang"]), int.Parse("" + Request["Nam"]), Request["LanBC"] + "", int.Parse(Request["LuyKe"] + ""));

            MTCSYT.Report.InTrungAp report = new MTCSYT.Report.InTrungAp(dt, "" + Request["Thang"], "" + Request["Nam"], donvi.TEN_DVIQLY);

            ReportViewer1.Report = report;

            ReportToolbar1.ReportViewer = ReportViewer1;
        }
        private void InTongHopKHDAThap()
        {
            MTCSYT.SYS_Session session = (MTCSYT.SYS_Session)Session["SYS_Session"];
            int ma_dviqly = int.Parse(session.User.ma_dviqly);
            DM_DVQLYService dm_dviSer = new DM_DVQLYService();
            var donvi = dm_dviSer.SelectDM_DVQLY(ma_dviqly);
            var lst = db.TT_KhachHangDAThapTrongThang(int.Parse(session.User.ma_dviqly + ""), int.Parse("" + Request["Thang"]), int.Parse("" + Request["Nam"])).ToList();
            DataTable dt = new DataTable();
            dt.Columns.Add("STT");
            dt.Columns.Add("TenDonVi");
            dt.Columns.Add("SOKH");
            dt.Columns.Add("KH160", typeof(decimal));
            dt.Columns.Add("KH180", typeof(decimal));
            dt.Columns.Add("KH200", typeof(decimal));
            dt.Columns.Add("GiaiPhap");
            dt.Columns.Add("TienDo");

            int stt = 1;
            foreach (var chitiet in lst)
            {
                dt.Rows.Add(stt, chitiet.TEN_DVIQLY, chitiet.SoTBA, chitiet.KH160, chitiet.KH180, chitiet.KH200, chitiet.GiaiPhap, chitiet.TienDoThucHien);
                stt++;
            }

            MTCSYT.Report.KHDAThap report = new MTCSYT.Report.KHDAThap(dt, "" + Request["Thang"], "" + Request["Nam"], donvi.TEN_DVIQLY);

            ReportViewer1.Report = report;

            ReportToolbar1.ReportViewer = ReportViewer1;
        }
        private void InTongHopDienNang()
        {
            MTCSYT.SYS_Session session = (MTCSYT.SYS_Session)Session["SYS_Session"];
            int ma_dviqly = int.Parse(session.User.ma_dviqly);
            DM_DVQLYService dm_dviSer = new DM_DVQLYService();
            var donvi = dm_dviSer.SelectDM_DVQLY(ma_dviqly);
            bool kiemtra = false;
            if (Request["XacNhan"] + "" == "1") kiemtra = true;

            //MTCSYT.Report.InBieuTong report = new MTCSYT.Report.InBieuTong(int.Parse(Request["ChinhNhanh"] + ""), ma_dviqly, int.Parse("" + Request["Thang"]), int.Parse("" + Request["Nam"]), kiemtra, kiemtra, "", "", donvi.TEN_DVIQLY, 0,"","","","");

            //ReportViewer1.Report = report;

            //ReportToolbar1.ReportViewer = ReportViewer1;
        }
        private void InTongHopDienNang_LichSu()
        {
            MTCSYT.SYS_Session session = (MTCSYT.SYS_Session)Session["SYS_Session"];
            int ma_dviqly = int.Parse(session.User.ma_dviqly);
            DM_DVQLYService dm_dviSer = new DM_DVQLYService();
            var donvi = dm_dviSer.SelectDM_DVQLY(ma_dviqly);
            bool kiemtra = false;
            if (Request["XacNhan"] + "" == "1") kiemtra = true;

            MTCSYT.Report.InBieuTong_LS report = new MTCSYT.Report.InBieuTong_LS(int.Parse(Request["ChinhNhanh"] + ""), ma_dviqly, int.Parse("" + Request["Thang"]), int.Parse("" + Request["Nam"]), kiemtra, kiemtra, "", "", donvi.TEN_DVIQLY, 0);

            ReportViewer1.Report = report;

            ReportToolbar1.ReportViewer = ReportViewer1;
        }

        private void InTongHopDienNangSauChot()
        {
            MTCSYT.SYS_Session session = (MTCSYT.SYS_Session)Session["SYS_Session"];
            int ma_dviqly = int.Parse(session.User.ma_dviqly);
            DM_DVQLYService dm_dviSer = new DM_DVQLYService();
            var donvi = dm_dviSer.SelectDM_DVQLY(ma_dviqly);
            bool kiemtra = false;
            if (Request["XacNhan"] + "" == "1") kiemtra = true;

            //MTCSYT.Report.InBieuTong report = new MTCSYT.Report.InBieuTong(int.Parse(Request["ChinhNhanh"] + ""), ma_dviqly, int.Parse("" + Request["Thang"]), int.Parse("" + Request["Nam"]), kiemtra, kiemtra, "", "", donvi.TEN_DVIQLY, 1, "", "", "", "");

            //ReportViewer1.Report = report;

            //ReportToolbar1.ReportViewer = ReportViewer1;
        }
        private void InBienBanQuyetToan()
        {
            MTCSYT.SYS_Session session = (MTCSYT.SYS_Session)Session["SYS_Session"];
            //int strMadviqly = int.Parse(Request["ChiNhanh"] + "");
            int strMadviqly = int.Parse(session.User.ma_dviqly);
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


            var lstquyettoanTT = db.BC_QuyetToanTruyenTai(strMadviqly, int.Parse(Request["Thang"]), int.Parse(Request["Nam"]));
            int stt = 1;
            dt.Rows.Add("A", "Từ hệ thống của EVN NPC", 0);
            foreach (var chitiet in lstquyettoanTT)
            {
                dt.Rows.Add(stt, chitiet.khoitruyentai, 1, chitiet.Nhan_Bieu1_SanLuong, chitiet.Nhan_Bieu2_SanLuong, chitiet.Nhan_Bieu3_SanLuong, 0, chitiet.TongNhan3B, chitiet.Giao_Bieu1_SanLuong, chitiet.Giao_Bieu2_SanLuong, chitiet.Giao_Bieu3_SanLuong, 0, chitiet.TongGiao3B, chitiet.B1_TieuThu, chitiet.B2_TieuThu, chitiet.B3_TieuThu, 0, chitiet.Tong_TieuThu);
                stt++;
            }
            var lstquyettoan = db.BC_QuyetToan(strMadviqly, int.Parse(Request["Thang"]), int.Parse(Request["Nam"]), int.Parse(Request["ParentId"]));

            foreach (var chitiet in lstquyettoan)
            {
                dt.Rows.Add(stt, chitiet.TenCongTy, 2, chitiet.Nhan_Bieu1_SanLuong, chitiet.Nhan_Bieu2_SanLuong, chitiet.Nhan_Bieu3_SanLuong, 0, chitiet.TongNhan3B, chitiet.Giao_Bieu1_SanLuong, chitiet.Giao_Bieu2_SanLuong, chitiet.Giao_Bieu3_SanLuong, 0, chitiet.TongGiao3B, chitiet.B1_TieuThu, chitiet.B2_TieuThu, chitiet.B3_TieuThu, 0, chitiet.Tong_TieuThu);
                stt++;
            }

            var lstquyettoanSX = db.BC_QuyetToanTuSX(strMadviqly, int.Parse(Request["Thang"]), int.Parse(Request["Nam"]));
            stt = 1;
            dt.Rows.Add("B", "Tự sản xuất", 0);
            foreach (var chitiet in lstquyettoanSX)
            {
                dt.Rows.Add(stt, chitiet.khoitruyentai, 3, chitiet.Nhan_Bieu1_SanLuong, chitiet.Nhan_Bieu2_SanLuong, chitiet.Nhan_Bieu3_SanLuong, 0, chitiet.TongNhan3B, chitiet.Giao_Bieu1_SanLuong, chitiet.Giao_Bieu2_SanLuong, chitiet.Giao_Bieu3_SanLuong, 0, chitiet.TongGiao3B, chitiet.B1_TieuThu, chitiet.B2_TieuThu, chitiet.B3_TieuThu, 0, chitiet.Tong_TieuThu);
                stt++;
            }

            var lstquyettoanMuaNgoai = db.BC_QuyetToanNgoaiNganh(strMadviqly, int.Parse(Request["Thang"]), int.Parse(Request["Nam"]));
            stt = 1;
            dt.Rows.Add("C", "Mua ngoài ngành", 0);
            foreach (var chitiet in lstquyettoanMuaNgoai)
            {
                dt.Rows.Add(stt, chitiet.khoitruyentai, 4, chitiet.Nhan_Bieu1_SanLuong, chitiet.Nhan_Bieu2_SanLuong, chitiet.Nhan_Bieu3_SanLuong, 0, chitiet.TongNhan3B, chitiet.Giao_Bieu1_SanLuong, chitiet.Giao_Bieu2_SanLuong, chitiet.Giao_Bieu3_SanLuong, 0, chitiet.TongGiao3B, chitiet.B1_TieuThu, chitiet.B2_TieuThu, chitiet.B3_TieuThu, 0, chitiet.Tong_TieuThu);
                stt++;
            }
            var lstMTAPM = db.BC_QuyetToanMTApMai(strMadviqly, int.Parse(Request["Thang"]), int.Parse(Request["Nam"]));
            stt = 1;

            foreach (var chitiet in lstMTAPM)
            {
                dt.Rows.Add("D", "Mặt trời áp mái", 5, chitiet.Nhan_Bieu1_SanLuong, chitiet.Nhan_Bieu2_SanLuong, chitiet.Nhan_Bieu3_SanLuong, chitiet.Nhan_1Gia, chitiet.TongNhan3B, chitiet.Giao_Bieu1_SanLuong, chitiet.Giao_Bieu2_SanLuong, chitiet.Giao_Bieu3_SanLuong, chitiet.Giao_1Gia, chitiet.TongGiao3B, chitiet.B1_TieuThu, chitiet.B2_TieuThu, chitiet.B3_TieuThu, chitiet.MGia_TieuThu, chitiet.Tong_TieuThu);
                break;
            }
            //var cn = db.DM_ChiNhanhs.SingleOrDefault(x => x.ID == int.Parse(Request["ChiNhanh"] + ""));
            //var giao = db.DM_DVQLies.SingleOrDefault(x => x.IDMA_DVIQLY == cn.DiemDauNguon);
            var nhan = db.DM_DVQLies.SingleOrDefault(x => x.IDMA_DVIQLY == int.Parse(session.User.ma_dviqly));
            MTCSYT.Report.InBienBanQT report = new MTCSYT.Report.InBienBanQT(dt, "" + Request["Thang"], "" + Request["Nam"], false, false, "", "", "Tổng công ty điện lực miền bắc", nhan.TEN_DVIQLY, "", "", "", "");
            ReportViewer1.Report = report;

            ReportToolbar1.ReportViewer = ReportViewer1;

        }

        protected void btnQuayLai_Click(object sender, EventArgs e)
        {
            string id = Request["Loai"];
            switch (id)
            {
                case "1":
                    Literal2.Text = "Biên bản quyết toán";
                    Response.Redirect("../BienDongThang/bd_xacNhanSL.aspx");
                    break;
                case "2":
                    Literal2.Text = "In biểu tổng hợp sản lượng trong tháng";
                    Response.Redirect("../BaoCao/bc_BieuTongGiaoNhan.aspx");
                    break;
                case "3":
                    Literal2.Text = "In biểu tổng hợp sản lượng trong tháng";
                    Response.Redirect("../BC_TK_ChotSL/bc_Chot_BieuTongGiaoNhan.aspx");
                    break;
                default:
                    Response.Redirect("~\\");
                    break;
            }
        }



        protected void btnTrinhKy_Click(object sender, EventArgs e)
        {
            pcTrinhKy.ShowOnPageLoad = true;
        }

        protected void btnDong2_Click(object sender, EventArgs e)
        {
            pcTrinhKy.ShowOnPageLoad = false;
        }

        protected void btnKhongXacNhan_Click(object sender, EventArgs e)
        {
            pcTrinhKy.ShowOnPageLoad = true;
        }

        protected void btnXacNhan_Click(object sender, EventArgs e)
        {

        }
    }
}

