using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using DevExpress.XtraCharts;
using DevExpress.XtraCharts.Web;
namespace CBDN
{
    public partial class Default : System.Web.UI.Page
    {
        DataAccess.clTBDD_CatDien dbOR = new DataAccess.clTBDD_CatDien();
        CBDN.DB_CBDNDataContext db = new CBDN.DB_CBDNDataContext(new CBDN.ADOController().strcn());
        protected void Page_Load(object sender, EventArgs e)
        {
            MTCSYT.SYS_Session session = (MTCSYT.SYS_Session)Session["SYS_Session"];
            if (session == null || session.User.USERNAME == "Guest")
            {
                Response.Redirect("~\\Login.aspx");
            }
            else
            {
                if (!IsPostBack)
                {

                    if (DateTime.Now.Month == 1)
                    {
                        cmbThang.Value = 12;
                        cmbNam.Value = DateTime.Now.Year - 1;

                    }
                    else
                    {
                        cmbThang.Value = DateTime.Now.Month - 1;
                        cmbNam.Value = DateTime.Now.Year;

                    }
                    loadtonthat();
                }
                loadDanhMuc();
                loadXacNhan();
            }
            //insertdulieu();
            // ScriptManager.RegisterStartupScript(Page, Page.GetType(), "", "alert('Insert dữ liệu thành công');", true);
        }
        private bool CheckName(string Name, int id, string ma_dviqly)
        {
            var dt = db.DM_ChiNhanhs.SingleOrDefault(x => x.MaChiNhanh == Name && x.ID != id);
            if (dt != null)
                return false;
            return true;
        }
        private bool CheckNameTramLo(string Name, int id, string idPhuongThuc)
        {
            var dt = db.DM_Trams.SingleOrDefault(x => x.MaTram == Name && x.IDTram != id && x.IDChiNhanh == idPhuongThuc);
            if (dt != null)
                return false;
            return true;
        }
        private void insertdulieu()
        {
            SystemManageService.DM_DVQLYService dvi = new SystemManageService.DM_DVQLYService();
            DataTable dt = new DataTable();
            dt = dbOR.SelectAllDDo_TT("RG");
            if (dt == null)
            {
                return;

            }

            for (int i = 0; i < dt.Rows.Count; i++)
            {
                var donvi = dvi.SelectAllDM_DVQLY().SingleOrDefault(x => x.MA_DVIQLY == dt.Rows[i]["MA_DVIQLY"] + "");
                var donviG = dvi.SelectAllDM_DVQLY().SingleOrDefault(x => x.MA_DVIQLY == dt.Rows[i]["DVIGIAO"] + "");
                if (!CheckName(dt.Rows[i]["MA_DVI"] + "", 0, donvi.MA_DVIQLY))
                {
                    continue;
                }
                if (!CheckName(dt.Rows[i]["MA_DVIB"] + "", 0, donvi.MA_DVIQLY))
                {
                    continue;
                }

                CBDN.DM_ChiNhanh cv = new CBDN.DM_ChiNhanh();
                cv.TenChiNhanh = dt.Rows[i]["MOTA"] + "";
                cv.MaChiNhanh = dt.Rows[i]["MA_DVI"] + "";
                if (dt.Rows[i]["CHIEU_GNHAN"] + "" == "G")
                {
                    cv.IDMADVIQLY = "," + donvi.IDMA_DVIQLY + "," + donviG.IDMA_DVIQLY + ",";
                }
                else
                    cv.IDMADVIQLY = "," + donviG.IDMA_DVIQLY + "," + donvi.IDMA_DVIQLY + ",";
                if (donvi.MA_DVIQLY == "PA" || donviG.MA_DVIQLY == "PA")
                    cv.LoaiPhuongThuc = 1;
                else if (donvi.MA_DVIQLY.Length == 4 && donviG.MA_DVIQLY.Length == 4)
                {
                    cv.LoaiPhuongThuc = 2;
                }
                else if (donvi.MA_DVIQLY.Length + donviG.MA_DVIQLY.Length < 12 && donvi.MA_DVIQLY.Length + donviG.MA_DVIQLY.Length > 9)
                { cv.LoaiPhuongThuc = 3; }
                else
                    cv.LoaiPhuongThuc = 4;
                cv.MoTa = dt.Rows[i]["MOTA"] + "";
                if (dt.Rows[i]["CHIEU_GNHAN"] + "" == "G")
                {
                    cv.DiemDauNguon = donvi.IDMA_DVIQLY;
                    cv.DiemCuoiNguon = donviG.IDMA_DVIQLY;
                }
                else
                {
                    cv.DiemCuoiNguon = donvi.IDMA_DVIQLY;
                    cv.DiemDauNguon = donviG.IDMA_DVIQLY;
                }


                cv.HoatDong = 1;
                cv.HoatDong = 0;
                db.DM_ChiNhanhs.InsertOnSubmit(cv);
                db.SubmitChanges();



            }
            // insert tram
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                var donvi = dvi.SelectAllDM_DVQLY().SingleOrDefault(x => x.MA_DVIQLY == dt.Rows[i]["MA_DVIQLY"] + "");
                var donviG = dvi.SelectAllDM_DVQLY().SingleOrDefault(x => x.MA_DVIQLY == dt.Rows[i]["DVIGIAO"] + "");
                var cn = db.DM_ChiNhanhs.SingleOrDefault(x => x.MaChiNhanh == dt.Rows[i]["MA_DVI"] + "");
                if (!CheckNameTramLo(dt.Rows[i]["MA_PTDIEN"] + "", 0, cn.ID + ""))
                {
                    continue;
                }

                //var cn = db.DM_ChiNhanhs.SingleOrDefault(x => x.ID == int.Parse(cmbDuongDay.Value + "") && x.IDMADVIQLY.Contains(session.User.ma_dviqly));
                //var lstDD = db.DM_ChiNhanhs.Where(x => x.MaChiNhanh == cn.MaChiNhanh);
                //foreach (var dd in lstDD)
                //{
                CBDN.DM_Tram cv = new CBDN.DM_Tram();
                cv.MaTram = dt.Rows[i]["MA_PTDIEN"] + "";

                cv.IDMaDviQly = cn.IDMADVIQLY;
                cv.TenTram = dt.Rows[i]["MA_PTDIEN"] + "";
                cv.MoTa = "";
                cv.TinhChatDD = 0;
                cv.DiaDiem = "";

                cv.IDDuongDay = cn.ID;
                cv.IDChiNhanh = cn.ID + "";

                cv.HoatDong = 1;
                cv.ParentId = 0;
                cv.IsLo = 0;
                cv.MaDVNhap = donviG.IDMA_DVIQLY;
                db.DM_Trams.InsertOnSubmit(cv);
                db.SubmitChanges();
            }
            // insert ma diem do
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                var donviG = dvi.SelectAllDM_DVQLY().SingleOrDefault(x => x.MA_DVIQLY == dt.Rows[i]["DVIGIAO"] + "");
                var cn = db.DM_ChiNhanhs.SingleOrDefault(x => x.MaChiNhanh == dt.Rows[i]["MA_DVI"] + "");
                var tr = db.DM_Trams.SingleOrDefault(x => x.MaTram == dt.Rows[i]["MA_PTDIEN"] + "" && x.IDMaDviQly.Contains(cn.IDMADVIQLY));
                if (!CheckNameDiemDo(dt.Rows[i]["MA_DDO"] + "", "0", tr.IDMaDviQly + ""))
                {
                    continue;
                }
                //var tr = db.DM_Trams.SingleOrDefault(x => x.IDTram == int.Parse(tlDonVi.FocusedNode.Key + "") && x.IDMaDviQly.Contains("," + session.User.ma_dviqly + ","));

                CBDN.DM_DiemDo cv = new CBDN.DM_DiemDo();
                cv.MaDiemDo = dt.Rows[i]["MA_DDO"] + "";
                cv.IDMaDViQly = tr.IDMaDviQly;
                cv.TenDiemDo = dt.Rows[i]["MA_DDO"] + "";
                cv.MoTa = "";
                cv.IDChiNhanh = tr.IDChiNhanh;
                cv.IDTram = tr.IDTram + "";
                cv.TinhChatDD = 0;
                cv.ISLoaiDD = 0;
                cv.HoatDong = 1;
                cv.MaDviNhap = donviG.IDMA_DVIQLY;
                db.DM_DiemDos.InsertOnSubmit(cv);
                db.SubmitChanges();
                //}
            }

            DataTable dtCongTo = new DataTable();
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                var donvi = dvi.SelectAllDM_DVQLY().SingleOrDefault(x => x.MA_DVIQLY == dt.Rows[i]["MA_DVIQLY"] + "");
                var donviG = dvi.SelectAllDM_DVQLY().SingleOrDefault(x => x.MA_DVIQLY == dt.Rows[i]["DVIGIAO"] + "");
                dtCongTo = dbOR.SelectAllCongTo(dt.Rows[i]["MA_DDO"] + "");
                if (dtCongTo.Rows.Count > 0)
                {
                    var listddo = db.DM_DiemDos.Where(x => x.MaDiemDo == dt.Rows[i]["MA_DDO"] + "");

                    foreach (var ddo in listddo)
                    {// List<Entity.DM_DVQLY> lst = new List<DM_DVQLY>();

                        //var ddo = db.DM_DiemDos.SingleOrDefault(x => x.IDDiemDo == int.Parse(cmbDiemDo.Value + "") && x.IDMaDViQly.Contains(session.User.ma_dviqly));
                        if (!CheckNameCongTo(dtCongTo.Rows[0]["MA_TBI"] + "", 0, ddo.IDTram, ddo.IDChiNhanh))
                        {
                            continue;
                        }
                        //foreach (var ddo in lst)
                        //{
                        CBDN.DM_CongTo cv = new CBDN.DM_CongTo();
                        cv.MaCongTo = dtCongTo.Rows[0]["MA_TBI"] + "";
                        cv.TenCongTo = dtCongTo.Rows[0]["SO_TBI"] + "";
                        cv.MoTa = "";
                        cv.IDDiemDo = ddo.IDDiemDo + "";

                        cv.IDDonViQuanLy = ddo.IDMaDViQly;

                        cv.TinhTrang = 1;
                        cv.CapDienAp = dtCongTo.Rows[0]["CAPDA"] + "";
                        cv.ChungLoai = "";
                        cv.HangSanXuat = "";
                        cv.HeSoNhan = decimal.Parse(dtCongTo.Rows[0]["HSN"] + "");
                        cv.NgayTreoThao = DateTime.Now;
                        cv.TU_TI = "";
                        cv.IDTram = ddo.IDTram;
                        cv.IDChiNhanh = ddo.IDChiNhanh;

                        if (dt.Rows[i]["CHIEU_GNHAN"] + "" == "G")
                        {
                            cv.IDDonViGiao = donvi.IDMA_DVIQLY;
                            cv.KenhGiaoCongTo = "G";
                            cv.GiaoTinhChat = 0;

                            cv.IDDonViNhan = donviG.IDMA_DVIQLY;
                            cv.KenhNhanCongTo = "N";
                            cv.NhanTinhChat = 0;
                        }
                        else
                        {
                            cv.IDDonViGiao = donviG.IDMA_DVIQLY;
                            cv.KenhGiaoCongTo = "G";
                            cv.GiaoTinhChat = 0;

                            cv.IDDonViNhan = donvi.IDMA_DVIQLY;
                            cv.KenhNhanCongTo = "N";
                            cv.NhanTinhChat = 0;
                        }

                        cv.IDUser = 1;
                        cv.NgayTao = DateTime.Now;
                        cv.NgayKiemDinh = DateTime.Now;
                        cv.HeSoQuyDoi = 1;
                        cv.IDDVNhapDL = donviG.IDMA_DVIQLY;

                        cv.IDDVXacNhan = donvi.IDMA_DVIQLY;
                        cv.IsCToMotGia = false;
                        db.DM_CongTos.InsertOnSubmit(cv);
                        db.SubmitChanges();



                        //}
                        var congto = db.DM_CongTos.SingleOrDefault(x => x.IDCongTo == cv.IDCongTo);
                        //CBDN.DM_CongToSelectByIDDViResult HoatDong = (CBDN.DM_CongToSelectByIDDViResult)grdDVT.GetRow(grdDVT.FocusedRowIndex);
                        CBDN.HD_GiaoNhanThang giaonhan = new CBDN.HD_GiaoNhanThang();
                        giaonhan.IDCongTo = congto.IDCongTo + "";
                        giaonhan.IDChiNhanh = congto.IDChiNhanh;
                        giaonhan.IDDuongDay = congto.IDChiNhanh;
                        giaonhan.IDMaDViQly = donviG.IDMA_DVIQLY;
                        giaonhan.IDUser = 1;
                        giaonhan.IDTram = congto.IDTram;
                        if (DateTime.Now.Month == 1)
                        {
                            giaonhan.Thang = 12;
                            giaonhan.Nam = DateTime.Now.Year - 1;
                        }

                        else
                        {
                            giaonhan.Thang = DateTime.Now.Month - 1;
                            giaonhan.Nam = DateTime.Now.Year;
                        }
                        giaonhan.Nhan_P_Dau = 0;
                        giaonhan.Giao_P_Dau = 0;
                        giaonhan.Giao_P_SanLuong = 0;
                        giaonhan.Nhan_P_SanLuong = 0;

                        giaonhan.Nhan_Q_Dau = 0;
                        giaonhan.Giao_Q_Dau = 0;
                        giaonhan.Giao_Q_SanLuong = 0;
                        giaonhan.Nhan_Q_SanLuong = 0;


                        giaonhan.CosGiao = 0;

                        giaonhan.CosNhan = 0;


                        giaonhan.Giao_Bieu1_Dau = 0;
                        giaonhan.Nhan_Bieu1_Dau = 0;
                        giaonhan.Giao_Bieu1_SanLuong = 0;
                        giaonhan.Nhan_Bieu1_SanLuong = 0;

                        giaonhan.Giao_Bieu2_Dau = 0;
                        giaonhan.Nhan_Bieu2_Dau = 0;
                        giaonhan.Giao_Bieu2_SanLuong = 0;
                        giaonhan.Nhan_Bieu2_SanLuong = 0;

                        giaonhan.Giao_Bieu3_Dau = 0;
                        giaonhan.Nhan_Bieu3_Dau = 0;
                        giaonhan.Giao_Bieu3_SanLuong = 0;
                        giaonhan.Nhan_Bieu3_SanLuong = 0;
                        giaonhan.ISDoDem = 0;
                        giaonhan.ISChot = false;
                        giaonhan.LoaiNhap = 0;
                        giaonhan.NgayNhap = DateTime.Now;
                        db.HD_GiaoNhanThangs.InsertOnSubmit(giaonhan);
                        db.SubmitChanges();
                    }


                }
            }
        }
        private bool CheckNameCongTo(string Name, int id, string tram, string idchinhanh)
        {
            var dt = db.DM_CongTos.SingleOrDefault(x => x.MaCongTo == Name && x.IDCongTo != id && x.IDTram == tram && x.IDChiNhanh == idchinhanh);
            if (dt != null)
                return false;
            return true;
        }

        private bool CheckNameDiemDo(string Name, string id, string madvi)
        {

            var dt = db.DM_DiemDos.SingleOrDefault(x => x.MaDiemDo == Name && x.IDMaDViQly.Contains(madvi) && x.IDTram != id);
            if (dt != null)
                return false;
            return true;
        }
        private void loadXacNhan()
        {
            MTCSYT.SYS_Session session = (MTCSYT.SYS_Session)Session["SYS_Session"];
            int ma_dviqly = int.Parse(session.User.ma_dviqly + "");
            var listTong = db.BC_TongHopDiemDoCanXacNhan(ma_dviqly, int.Parse(cmbThang.Value + ""), int.Parse(cmbNam.Value + "")).ToList();
            if (listTong.Count > 0)
            {
                foreach (var a in listTong)
                {
                    lbNhanVien.Text = a.NVCanXN + "";
                    lbTruongPhong.Text = a.TPCanXN + "";
                    lbGiamDocChua.Text = (a.GDChuaXN - a.GDDaXN) + "";
                    lbGiamDocDa.Text = a.GDDaXN + "";

                    break;
                }
            }
            else
            {
                lbNhanVien.Text = "0";
                lbTruongPhong.Text = "0";
                lbGiamDocChua.Text = "0";
                lbGiamDocDa.Text = "0";
            }
        }
        private void loadtonthat()
        {
            MTCSYT.SYS_Session session = (MTCSYT.SYS_Session)Session["SYS_Session"];
            int ma_dviqly = int.Parse(session.User.ma_dviqly + "");
            var listTong = db.BC_TonThat110(ma_dviqly, int.Parse(cmbThang.Value + ""), int.Parse(cmbNam.Value + ""), "110").ToList();
            if (listTong.Count > 0)
            {
                foreach (var a in listTong)
                {
                    lbTonThatBieuTong.Text = a.TiLeTonThat + "%";
                    lbBieu1.Text = a.TiLeTonThatB1 + "%";
                    break;
                }
            }
            else
            {
                lbTonThatBieuTong.Text = "0%";
                lbBieu1.Text = "0%";
            }

        }
        private void loadDanhMuc()
        {
            //WebChartControl WebChartControl = new WebChartControl();
            // Add the chart to the form.
            // Note that a chart isn't initialized until it's added to the form's collection of controls.
            //this.Controls.Add(WebChartControl);
            // Create a new bar series.
            Series series = new Series("Công ty điện lực", ViewType.Bar);
            // Add the series to the chart.
            WebChartControl1.Series.Add(series);
            // Specify the series data source.
            DataTable seriesData = GetData();
            series.DataSource = seriesData;

            ChartTitle ct = new ChartTitle();
            ct.Text = "THỐNG KÊ TÌNH HÌNH NHẬP LIỆU CÁC ĐIỆN LỰC ( Tính theo tỷ lệ %)";
            WebChartControl1.Titles.Add(ct);
            // Specify an argument data member.
            series.ArgumentDataMember = "Region";
            // Specify a value data member.
            series.ValueDataMembers.AddRange(new string[] { "Sales" });
            // Rotate the diagram (if necessary).
            ((XYDiagram)WebChartControl1.Diagram).Rotated = false;
            ((XYDiagram)WebChartControl1.Diagram).AxisY.Range.SetMinMaxValues(0, 100);
            ((XYDiagram)WebChartControl1.Diagram).AxisY.Label.EndText = "%";
        }


        public DataTable GetData()
        {
            MTCSYT.SYS_Session session = (MTCSYT.SYS_Session)Session["SYS_Session"];
            int ma_dviqly = int.Parse(session.User.ma_dviqly + "");
            var lst = db.TK_NhapLieuTrongThang(ma_dviqly, int.Parse(cmbThang.Value + ""), int.Parse(cmbNam.Value + "")).ToList();
            DataTable table = new DataTable();
            table.Columns.AddRange(new DataColumn[] {
            new DataColumn("Region", typeof(string)),
            new DataColumn("Sales", typeof(decimal))
        });
            foreach (var chitiet in lst)
            {
                decimal tyle = 0;
                if (chitiet.TongCongTo != "0")
                    tyle = decimal.Parse(chitiet.TongNhap) / decimal.Parse(chitiet.TongCongTo) * 100;
                string tyle1 = string.Format("{0:N} ", tyle);

                table.Rows.Add(chitiet.TEN_DVIQLY, tyle1);
            }
            return table;
        }
        protected void grdDVT_CustomColumnDisplayText(object sender, DevExpress.Web.ASPxGridViewColumnDisplayTextEventArgs e)
        {
            if (e.Column.Caption == "STT")
            {
                e.DisplayText = (e.VisibleRowIndex + 1).ToString();
            }
        }
    }
}