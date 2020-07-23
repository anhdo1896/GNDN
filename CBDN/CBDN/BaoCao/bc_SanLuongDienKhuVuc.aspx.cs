using System;
using System.Collections.Generic;
using DevExpress.Web;
using Entity;
using SystemManageService;
using System.Web.UI;
using System.Linq;
using System.Data;
using Aspose.Cells;
namespace MTCSYT
{
    public partial class bc_SanLuongDienKhuVuc : BasePage
    {
        CBDN.DB_CBDNDataContext db = new CBDN.DB_CBDNDataContext(new CBDN.ADOController().strcn());
        private SYS_Right rightOfUser = null;
        private const string funcid = "57";
        private Cells _range;
        private Worksheet _exSheet;
        protected void Page_Load(object sender, EventArgs e)
        {
            #region PhanQuyen
            MTCSYT.SYS_Session session = (MTCSYT.SYS_Session)Session["SYS_Session"];
            if (session == null || session.User.USERNAME == "Guest")
            {
                Response.Redirect("~\\Login.aspx");
            }
            else
            {
                //if (Request.Cookies["IDUSER"].Value != "1")
                //{
                //    List<SYS_Right> right = session.User.Rights;
                //    foreach (SYS_Right sysRight in right)
                //    {
                //        if (sysRight.FuncId == funcid)
                //        {
                //            rightOfUser = sysRight;
                //            Session["Right"] = sysRight;
                //            Session["UserId"] = session.User.IDUSER;
                //            Session["FunctionId"] = sysRight.FuncId;
                //            break;
                //        }
                //    }

                //    if (rightOfUser == null)
                //    {
                //        Session["Status"] = "0";
                //        Response.Redirect("~\\HeThong\\Default.aspx");

                //    }
                //}
            }
            Session["SYS_Session"] = session;
            #endregion

            if (!IsPostBack)
            {
                cmbThang.Value = DateTime.Now.Month;
                cmbNam.Value = DateTime.Now.Year;
            }
            loadDanhMuc();
        }
        private void loadDanhMuc()
        {
            DM_DVQLYService dm_dviSer = new DM_DVQLYService();

            MTCSYT.SYS_Session session = (MTCSYT.SYS_Session)Session["SYS_Session"];
            int ma_dviqly = int.Parse(session.User.ma_dviqly + "");
            var lst = db.BC_DaCoDL_KhuVuc(ma_dviqly).ToList();
            string tongdong = "";
            foreach (var a in lst)
            {
                tongdong = a.TongCo.Split('/')[0] + "";
                break;
            }
            Session["tongdong"] = tongdong;
            tlDonVi.DataSource = lst;
            tlDonVi.DataBind();

        }


        protected void btnCapNhat_Click1(object sender, EventArgs e)
        {

        }

        protected void btnLoc_Click(object sender, EventArgs e)
        {
        }

        protected void TreeListOrganization_CustomDataCallback(object sender, DevExpress.Web.ASPxTreeList.TreeListCustomDataCallbackEventArgs e)
        {

        }

        protected void TreeListOrganization_HtmlCommandCellPrepared(object sender, DevExpress.Web.ASPxTreeList.TreeListHtmlCommandCellEventArgs e)
        {

        }

        protected void tlDonVi_CustomCallback(object sender, DevExpress.Web.ASPxTreeList.TreeListCustomCallbackEventArgs e)
        {

        }

        protected void btnXuat_Click(object sender, EventArgs e)
        {
            MTCSYT.SYS_Session session = (MTCSYT.SYS_Session)Session["SYS_Session"];
            int ma_dviqly = int.Parse(session.User.ma_dviqly + "");
            var lst = db.BC_KhuVuc_ChiTiet(ma_dviqly, int.Parse("0" + cmbThang.Value), int.Parse("0" + cmbNam.Value)).ToList();
            #region Chuẩn bị tệp excel mẫu để ghi dữ liệu
            string destFile = Server.MapPath("~/Tem/BC_KhuVuc.xls");
            string sTemplate = (destFile);
            Workbook exBook = new Workbook();
            exBook.Open(sTemplate, FileFormatType.Excel2003);
            _exSheet = exBook.Worksheets[0];
            _range = _exSheet.Cells;
            #endregion

            // Xử lý replace các thông tin báo cáo tĩnh theo công ty
            //Report.ReplaceSpecificationField(_exSheet);

            int donghientai = 8;

            #region Ghi dữ liệu
            _exSheet.Replace("NGAYTHANG", "Ngày " + DateTime.Now.Day + " tháng " + DateTime.Now.Month + " năm " + DateTime.Now.Year);
            DM_DVQLYService dm_dviSer = new DM_DVQLYService();
            var donvi = dm_dviSer.SelectDM_DVQLY(ma_dviqly);
            string tongdong = Session["tongdong"] + "";
            if (donvi.Type < 3)
                _exSheet.Replace("ntTieuDe", "BÁO CÁO SẢN LƯỢNG ĐIỆN NĂNG GIAO NHẬN VỚI CÁC CÔNG TY ĐIỆN LỰC");
            else
                _exSheet.Replace("ntTieuDe", " BÁO CÁO ĐIỆN NĂNG GIAO NHẬN VỚI CÔNG TY " + donvi.TEN_DVIQLY);
            if (lst.Count > 1)
            {
                _exSheet.Cells.InsertRows(donghientai + 1, (lst.Count() + int.Parse(tongdong)) * 5 - 3);
            }
            string macto = "", tenkhuvuc = "";
            int vitri = 0;
            Style celicaStil = exBook.Styles[exBook.Styles.Add()];
            celicaStil.VerticalAlignment = TextAlignmentType.Center;
            celicaStil.HorizontalAlignment = TextAlignmentType.Center;
            celicaStil.Pattern = BackgroundType.Solid;
            celicaStil.Font.IsBold = true;
            celicaStil.Borders[BorderType.BottomBorder].LineStyle = CellBorderType.Thin;
            StyleFlag flg = new StyleFlag();
            flg.Font = true; int tongtram = 0;
            flg.CellShading = true;
           
            foreach (var ct in lst)
            {
                tongtram = tongtram + 1;
                celicaStil.VerticalAlignment = TextAlignmentType.Center;
                if (tenkhuvuc != ct.TEN_DVIQLY)
                {
                    var countKV = lst.Where(x => x.TEN_DVIQLY == ct.TEN_DVIQLY).Count();
                    _range[donghientai + vitri, 0].PutValue(ct.TEN_DVIQLY);
                    var categoryCounts =
                                        from p in lst
                                        group p by p.TenTram into g
                                        select new { TEN_DVIQLY = ct.TEN_DVIQLY, ProductCount = g.Count() };

                    _range.Merge(donghientai + vitri, 0, (categoryCounts.Count() + int.Parse(tongdong)) * 5, 1);
                    _range[donghientai + vitri, 0].SetStyle(celicaStil);

                    tenkhuvuc = ct.TEN_DVIQLY;
                }

                if (macto != ct.MaCongTo)
                {
                    _range[donghientai + vitri, 1].PutValue(ct.TenTram);
                    _range.Merge(donghientai + vitri, 1, 5, 1);
                    _range[donghientai + vitri, 1].SetStyle(celicaStil);

                    _range[donghientai + vitri, 2].PutValue(ct.TenDiemDo);
                    _range.Merge(donghientai + vitri, 2, 5, 1);
                    _range[donghientai + vitri, 2].SetStyle(celicaStil);

                    _range[donghientai + vitri, 3].PutValue(ct.TU_TI);
                    _range.Merge(donghientai + vitri, 3, 5, 1);
                    _range[donghientai + vitri, 3].SetStyle(celicaStil);

                    _range[donghientai + vitri, 4].PutValue(ct.TenCongTo);
                    _range.Merge(donghientai + vitri, 4, 5, 1);
                    _range[donghientai + vitri, 4].SetStyle(celicaStil);

                    _range[donghientai + vitri, 5].PutValue(ct.HeSoNhan);
                    _range.Merge(donghientai + vitri, 5, 5, 1);
                    _range[donghientai + vitri, 5].SetStyle(celicaStil);

                    macto = ct.MaCongTo;
                }
                for (int i = 0; i < 5; i++)
                {
                    if (i == 0)
                    {
                        _range[donghientai + vitri + i, 6].PutValue("Tổng P");
                        _range[donghientai + vitri + i, 7].PutValue(ct.Giao_P_Dau);
                        _range[donghientai + vitri + i, 8].PutValue(ct.Giao_P_Cuoi);
                        _range[donghientai + vitri + i, 9].PutValue(ct.Giao_P_SanLuong);
                        _range[donghientai + vitri + i, 10].PutValue(ct.CosGiao);
                        _range[donghientai + vitri + i, 11].PutValue(ct.Nhan_P_Dau);
                        _range[donghientai + vitri + i, 12].PutValue(ct.Nhan_P_Cuoi);
                        _range[donghientai + vitri + i, 13].PutValue(ct.Nhan_P_SanLuong);
                        _range[donghientai + vitri + i, 14].PutValue(ct.CosNhan);

                    }
                    else if (i == 1)
                    {
                        _range[donghientai + vitri + i, 6].PutValue("Tổng Q");
                        _range[donghientai + vitri + i, 7].PutValue(ct.Giao_Q_Dau);
                        _range[donghientai + vitri + i, 8].PutValue(ct.Giao_Q_Cuoi);
                        _range[donghientai + vitri + i, 9].PutValue(ct.Giao_Q_SanLuong);
                        _range[donghientai + vitri + i, 10].PutValue("");
                        _range[donghientai + vitri + i, 11].PutValue(ct.Nhan_Q_Dau);
                        _range[donghientai + vitri + i, 12].PutValue(ct.Nhan_Q_Cuoi);
                        _range[donghientai + vitri + i, 13].PutValue(ct.Nhan_Q_SanLuong);
                        _range[donghientai + vitri + i, 14].PutValue("");
                    }
                    else if (i == 2)
                    {
                        _range[donghientai + vitri + i, 6].PutValue("Biểu 1");
                        _range[donghientai + vitri + i, 7].PutValue(ct.Giao_Bieu1_Dau);
                        _range[donghientai + vitri + i, 8].PutValue(ct.Giao_Bieu1_Cuoi);
                        _range[donghientai + vitri + i, 9].PutValue(ct.Giao_Bieu1_SanLuong);
                        _range[donghientai + vitri + i, 10].PutValue("");
                        _range[donghientai + vitri + i, 11].PutValue(ct.Nhan_Bieu1_Dau);
                        _range[donghientai + vitri + i, 12].PutValue(ct.Nhan_Bieu1_Cuoi);
                        _range[donghientai + vitri + i, 13].PutValue(ct.Nhan_Bieu1_SanLuong);
                        _range[donghientai + vitri + i, 14].PutValue("");
                    }
                    else if (i == 3)
                    {
                        _range[donghientai + vitri + i, 6].PutValue("Biểu 2");
                        _range[donghientai + vitri + i, 7].PutValue(ct.Giao_Bieu2_Dau);
                        _range[donghientai + vitri + i, 8].PutValue(ct.Giao_Bieu2_Cuoi);
                        _range[donghientai + vitri + i, 9].PutValue(ct.Giao_Bieu1_SanLuong);
                        _range[donghientai + vitri + i, 10].PutValue("");
                        _range[donghientai + vitri + i, 11].PutValue(ct.Nhan_Bieu2_Dau);
                        _range[donghientai + vitri + i, 12].PutValue(ct.Nhan_Bieu2_Cuoi);
                        _range[donghientai + vitri + i, 13].PutValue(ct.Nhan_Bieu2_SanLuong);
                        _range[donghientai + vitri + i, 14].PutValue("");
                    }
                    else if (i == 4)
                    {
                        _range[donghientai + vitri + i, 6].PutValue("Biểu 3");
                        _range[donghientai + vitri + i, 7].PutValue(ct.Giao_Bieu3_Dau);
                        _range[donghientai + vitri + i, 8].PutValue(ct.Giao_Bieu3_Cuoi);
                        _range[donghientai + vitri + i, 9].PutValue(ct.Giao_Bieu3_SanLuong);
                        _range[donghientai + vitri + i, 10].PutValue("");
                        _range[donghientai + vitri + i, 11].PutValue(ct.Nhan_Bieu3_Dau);
                        _range[donghientai + vitri + i, 12].PutValue(ct.Nhan_Bieu3_Cuoi);
                        _range[donghientai + vitri + i, 13].PutValue(ct.Nhan_Bieu3_SanLuong);
                        _range[donghientai + vitri + i, 14].PutValue("");
                    }
                }
                //in tổng 
                _range[donghientai + vitri + 5, 1].PutValue("");
                _range.Merge(donghientai + vitri + 5, 1, 5, 1);
                _range[donghientai + vitri + 5, 1].SetStyle(celicaStil);
                var lstTong = db.BC_GiaoNhan2Chieu_TongTram(ma_dviqly, int.Parse("0" + cmbThang.Value), int.Parse("0" + cmbNam.Value)).ToList();
                var ctTong = lstTong.SingleOrDefault(x => x.TenTram == ct.TenTram);
                if (ctTong != null)
                {
                    if (tongtram == ctTong.TongTram)
                    {
                        tongtram = 0;
                        for (int i = 0; i < 5; i++)
                        {
                            celicaStil.VerticalAlignment = TextAlignmentType.Left;
                            celicaStil.HorizontalAlignment = TextAlignmentType.Left;
                            if (i == 0)
                            {
                                _range[donghientai + vitri + i + 5, 2].PutValue("Tổng P");
                                _range[donghientai + vitri + i + 5, 2].SetStyle(celicaStil);
                                _range.Merge(donghientai + vitri + i + 5, 2, 1, 7);

                                _range[donghientai + vitri + i + 5, 9].PutValue(ctTong.slPGiao);
                                _range[donghientai + vitri + i + 5, 13].PutValue(ctTong.slPNhan);

                                _range[donghientai + vitri + i + 5, 13].SetStyle(celicaStil);
                                _range[donghientai + vitri + i + 5, 9].SetStyle(celicaStil);

                            }
                            else if (i == 1)
                            {
                                _range[donghientai + vitri + i + 5, 2].PutValue("Tổng Q");
                                _range[donghientai + vitri + i + 5, 2].SetStyle(celicaStil);
                                _range.Merge(donghientai + vitri + i + 5, 2, 1, 7);
                                _range[donghientai + vitri + i + 5, 9].PutValue(ctTong.slQGiao);
                                _range[donghientai + vitri + i + 5, 13].PutValue(ctTong.slQNhan);
                                _range[donghientai + vitri + i + 5, 13].SetStyle(celicaStil);
                                _range[donghientai + vitri + i + 5, 9].SetStyle(celicaStil);
                            }
                            else if (i == 2)
                            {
                                _range[donghientai + vitri + i + 5, 2].PutValue("Tổng Biểu 1");
                                _range[donghientai + vitri + i + 5, 2].SetStyle(celicaStil);
                                _range.Merge(donghientai + vitri + i + 5, 2, 1, 7);
                                _range[donghientai + vitri + i + 5, 9].PutValue(ctTong.slb1Giao);
                                _range[donghientai + vitri + i + 5, 13].PutValue(ctTong.slb1Nhan);
                                _range[donghientai + vitri + i + 5, 13].SetStyle(celicaStil);
                                _range[donghientai + vitri + i + 5, 9].SetStyle(celicaStil);
                            }
                            else if (i == 3)
                            {
                                _range[donghientai + vitri + i + 5, 2].PutValue("Tổng Biểu 2");
                                _range[donghientai + vitri + i + 5, 2].SetStyle(celicaStil);
                                _range.Merge(donghientai + vitri + i + 5, 2, 1, 7);

                                _range[donghientai + vitri + i + 5, 9].PutValue(ctTong.slb2Giao);
                                _range[donghientai + vitri + i + 5, 13].PutValue(ctTong.slb2Nhan);
                                _range[donghientai + vitri + i + 5, 13].SetStyle(celicaStil);
                                _range[donghientai + vitri + i + 5, 9].SetStyle(celicaStil);
                            }
                            else if (i == 4)
                            {
                                _range[donghientai + vitri + i + 5, 2].PutValue("Tổng Biểu 3");
                                _range[donghientai + vitri + i + 5, 2].SetStyle(celicaStil);
                                _range.Merge(donghientai + vitri + i + 5, 2, 1, 7);

                                _range[donghientai + vitri + i + 5, 9].PutValue(ctTong.slb3Giao);
                                _range[donghientai + vitri + i + 5, 13].PutValue(ctTong.slb3Nhan);
                                _range[donghientai + vitri + i + 5, 13].SetStyle(celicaStil);
                                _range[donghientai + vitri + i + 5, 9].SetStyle(celicaStil);
                            }
                            else if (i == 5)
                            {
                                _range[donghientai + vitri + i + 5, 2].PutValue("Tổng 3 Biểu");
                                _range[donghientai + vitri + i + 5, 2].SetStyle(celicaStil);
                                _range.Merge(donghientai + vitri + i + 5, 2, 1, 7);
                                _range[donghientai + vitri + i + 5, 9].PutValue(ctTong.tong3B_Giao);
                                _range[donghientai + vitri + i + 5, 13].PutValue(ctTong.tong3B_Nhan);
                                _range[donghientai + vitri + i + 5, 13].SetStyle(celicaStil);
                                _range[donghientai + vitri + i + 5, 9].SetStyle(celicaStil);
                            }
                        }
                        vitri = vitri + 5;
                    }

                }
                vitri = vitri + 5;
            }

            #endregion

            exBook.Save("BC_KhuVuc.xls", SaveType.OpenInExcel, FileFormatType.Default, this.Response);
            //Response.Redirect("../BaoCao/Report.aspx?Loai=5&strSQL=" + strTruyVan);
        }

    }
}