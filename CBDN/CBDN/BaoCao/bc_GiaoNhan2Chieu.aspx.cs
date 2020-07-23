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
    public partial class bc_GiaoNhan2Chieu : BasePage
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

            tlDonVi.DataSource = db.BC_DaCoBaoCaoGiaoNhan2Chieu(ma_dviqly);
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
        private DataTable returnDt()
        {
            DataTable dt = new DataTable();
            MTCSYT.SYS_Session session = (MTCSYT.SYS_Session)Session["SYS_Session"];
            int ma_dviqly = int.Parse(session.User.ma_dviqly + "");
            var lst = db.BC_GiaoNhan2Chieu_ChiTiet(ma_dviqly, int.Parse("0" + cmbThang.Value), int.Parse("0" + cmbNam.Value));
            if (!dt.Columns.Contains("DiemDo"))
            {
                dt.Columns.Add("DiemDo");
                dt.Columns.Add("ThongSo");
                dt.Columns.Add("CongTo");
                dt.Columns.Add("HeSo");
                dt.Columns.Add("Bieu");
                dt.Columns.Add("Giao_Dau");
                dt.Columns.Add("Giao_Cuoi");
                dt.Columns.Add("Nhan_Dau");
                dt.Columns.Add("Nhan_Cuoi");


                dt.Columns.Add("Giao_SL");
                dt.Columns.Add("Giao_Cos");
                dt.Columns.Add("Nhan_SL");
                dt.Columns.Add("Nhan_Cos");
            }

            return dt;
        }
        protected void btnXuat_Click(object sender, EventArgs e)
        {
            MTCSYT.SYS_Session session = (MTCSYT.SYS_Session)Session["SYS_Session"];
            int ma_dviqly = int.Parse(session.User.ma_dviqly + "");
            var lst = db.BC_GiaoNhan2Chieu_ChiTiet(ma_dviqly, int.Parse("0" + cmbThang.Value), int.Parse("0" + cmbNam.Value)).ToList();
            #region Chuẩn bị tệp excel mẫu để ghi dữ liệu
            string destFile = Server.MapPath("~/Tem/BC_GiaoNhanChiNhanh.xls");
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

            if (lst.Count > 0)
            {
                _exSheet.Cells.InsertRows(donghientai + 1, lst.Count * 11 - 3);
            }
            string macto = "", tenchinhanh = "";
            int vitri = 0;
            Style celicaStil = exBook.Styles[exBook.Styles.Add()];
            celicaStil.VerticalAlignment = TextAlignmentType.Center;
            celicaStil.HorizontalAlignment = TextAlignmentType.Center;
            celicaStil.Pattern = BackgroundType.Solid;
            celicaStil.Font.IsBold = true;
            StyleFlag flg = new StyleFlag();
            flg.Font = true;
            flg.CellShading = true;
            foreach (var ct in lst)
            {
                if (tenchinhanh != ct.TenChiNhanh)
                {
                    _range[donghientai + vitri, 0].PutValue(ct.TenChiNhanh);
                    _range.Merge(donghientai + vitri, 0, 1, 14);
                    celicaStil.ForegroundColor = System.Drawing.Color.Aqua;
                    _range[donghientai + vitri, 0].SetStyle(celicaStil);

                    tenchinhanh = ct.TenChiNhanh;
                }
                vitri = vitri + 1;
                if (macto != ct.MaCongTo)
                {
                    _range[donghientai + vitri, 0].PutValue(ct.TenTram);
                    _range.Merge(donghientai + vitri, 0, 5, 1);

                    celicaStil.ForegroundColor = System.Drawing.Color.White;
                    _range[donghientai + vitri, 0].SetStyle(celicaStil);

                    _range[donghientai + vitri, 1].PutValue(ct.TenDiemDo);
                    _range.Merge(donghientai + vitri, 1, 5, 1);
                    _range[donghientai + vitri, 1].SetStyle(celicaStil);

                    _range[donghientai + vitri, 2].PutValue(ct.TU_TI);
                    _range.Merge(donghientai + vitri, 2, 5, 1);
                    _range[donghientai + vitri, 2].SetStyle(celicaStil);

                    _range[donghientai + vitri, 3].PutValue(ct.TenCongTo);
                    _range.Merge(donghientai + vitri, 3, 5, 1);
                    _range[donghientai + vitri, 3].SetStyle(celicaStil);

                    _range[donghientai + vitri, 4].PutValue(ct.HeSoNhan);
                    _range.Merge(donghientai + vitri, 4, 5, 1);
                    _range[donghientai + vitri, 4].SetStyle(celicaStil);

                    macto = ct.MaCongTo;
                }
                for (int i = 0; i < 5; i++)
                {
                    if (i == 0)
                    {
                        _range[donghientai + vitri + i, 5].PutValue("Tổng P");
                        _range[donghientai + vitri + i, 6].PutValue(ct.Giao_P_Dau);
                        _range[donghientai + vitri + i, 7].PutValue(ct.Giao_P_Cuoi);
                        _range[donghientai + vitri + i, 8].PutValue(ct.Giao_P_SanLuong);
                        _range[donghientai + vitri + i, 9].PutValue(ct.CosGiao);
                        _range[donghientai + vitri + i, 10].PutValue(ct.Nhan_P_Dau);
                        _range[donghientai + vitri + i, 11].PutValue(ct.Nhan_P_Cuoi);
                        _range[donghientai + vitri + i, 12].PutValue(ct.Nhan_P_SanLuong);
                        _range[donghientai + vitri + i, 13].PutValue(ct.CosNhan);

                    }
                    else if (i == 1)
                    {
                        _range[donghientai + vitri + i, 5].PutValue("Tổng Q");
                        _range[donghientai + vitri + i, 6].PutValue(ct.Giao_Q_Dau);
                        _range[donghientai + vitri + i, 7].PutValue(ct.Giao_Q_Cuoi);
                        _range[donghientai + vitri + i, 8].PutValue(ct.Giao_Q_SanLuong);
                        _range[donghientai + vitri + i, 9].PutValue("");
                        _range[donghientai + vitri + i, 10].PutValue(ct.Nhan_Q_Dau);
                        _range[donghientai + vitri + i, 11].PutValue(ct.Nhan_Q_Cuoi);
                        _range[donghientai + vitri + i, 12].PutValue(ct.Nhan_Q_SanLuong);
                        _range[donghientai + vitri + i, 13].PutValue("");
                    }
                    else if (i == 2)
                    {
                        _range[donghientai + vitri + i, 5].PutValue("Biểu 1");
                        _range[donghientai + vitri + i, 6].PutValue(ct.Giao_Bieu1_Dau);
                        _range[donghientai + vitri + i, 7].PutValue(ct.Giao_Bieu1_Cuoi);
                        _range[donghientai + vitri + i, 8].PutValue(ct.Giao_Bieu1_SanLuong);
                        _range[donghientai + vitri + i, 9].PutValue("");
                        _range[donghientai + vitri + i, 10].PutValue(ct.Nhan_Bieu1_Dau);
                        _range[donghientai + vitri + i, 11].PutValue(ct.Nhan_Bieu1_Cuoi);
                        _range[donghientai + vitri + i, 12].PutValue(ct.Nhan_Bieu1_SanLuong);
                        _range[donghientai + vitri + i, 13].PutValue("");
                    }
                    else if (i == 3)
                    {
                        _range[donghientai + vitri + i, 5].PutValue("Biểu 2");
                        _range[donghientai + vitri + i, 6].PutValue(ct.Giao_Bieu2_Dau);
                        _range[donghientai + vitri + i, 7].PutValue(ct.Giao_Bieu2_Cuoi);
                        _range[donghientai + vitri + i, 8].PutValue(ct.Giao_Bieu1_SanLuong);
                        _range[donghientai + vitri + i, 9].PutValue("");
                        _range[donghientai + vitri + i, 10].PutValue(ct.Nhan_Bieu2_Dau);
                        _range[donghientai + vitri + i, 11].PutValue(ct.Nhan_Bieu2_Cuoi);
                        _range[donghientai + vitri + i, 12].PutValue(ct.Nhan_Bieu2_SanLuong);
                        _range[donghientai + vitri + i, 13].PutValue("");
                    }
                    else if (i == 4)
                    {
                        _range[donghientai + vitri + i, 5].PutValue("Biểu 3");
                        _range[donghientai + vitri + i, 6].PutValue(ct.Giao_Bieu3_Dau);
                        _range[donghientai + vitri + i, 7].PutValue(ct.Giao_Bieu3_Cuoi);
                        _range[donghientai + vitri + i, 8].PutValue(ct.Giao_Bieu3_SanLuong);
                        _range[donghientai + vitri + i, 9].PutValue("");
                        _range[donghientai + vitri + i, 10].PutValue(ct.Nhan_Bieu3_Dau);
                        _range[donghientai + vitri + i, 11].PutValue(ct.Nhan_Bieu3_Cuoi);
                        _range[donghientai + vitri + i, 12].PutValue(ct.Nhan_Bieu3_SanLuong);
                        _range[donghientai + vitri + i, 13].PutValue("");
                    }
                }
                //in tổng 
                _range[donghientai + vitri + 5, 0].PutValue(ct.motaCN);
                _range.Merge(donghientai + vitri + 5, 0, 5, 5);
                _range[donghientai + vitri + 5, 0].SetStyle(celicaStil);
                var lstTong = db.BC_GiaoNhan2Chieu_TongTram(ma_dviqly, int.Parse("0" + cmbThang.Value), int.Parse("0" + cmbNam.Value)).ToList();
                var ctTong = lstTong.SingleOrDefault(x => x.TenTram == ct.TenTram);
                if (ctTong != null)
                {
                    for (int i = 0; i < 5; i++)
                    {
                        if (i == 0)
                        {
                            _range[donghientai + vitri + i + 5, 5].PutValue("Tổng P");
                            _range.Merge(donghientai + vitri + i + 5, 5, 1, 3);
                            _range[donghientai + vitri + i + 5, 8].PutValue(ctTong.slPGiao);
                            _range[donghientai + vitri + i + 5, 12].PutValue(ctTong.slPNhan);

                        }
                        else if (i == 1)
                        {
                            _range[donghientai + vitri + i + 5, 5].PutValue("Tổng Q");
                            _range.Merge(donghientai + vitri + i + 5, 5, 1, 3);
                            _range[donghientai + vitri + i + 5, 8].PutValue(ctTong.slQGiao);
                            _range[donghientai + vitri + i + 5, 12].PutValue(ctTong.slQNhan);
                        }
                        else if (i == 2)
                        {
                            _range[donghientai + vitri + i + 5, 5].PutValue("Tổng Biểu 1");
                            _range.Merge(donghientai + vitri + i + 5, 5, 1, 3);
                            _range[donghientai + vitri + i + 5, 8].PutValue(ctTong.slb1Giao);
                            _range[donghientai + vitri + i + 5, 12].PutValue(ctTong.slb1Nhan);
                        }
                        else if (i == 3)
                        {
                            _range[donghientai + vitri + i + 5, 5].PutValue("Tổng Biểu 2");
                            _range.Merge(donghientai + vitri + i + 5, 5, 1, 3);
                            _range[donghientai + vitri + i + 5, 8].PutValue(ctTong.slb2Giao);
                            _range[donghientai + vitri + i + 5, 12].PutValue(ctTong.slb2Nhan);
                        }
                        else if (i == 4)
                        {
                            _range[donghientai + vitri + i + 5, 5].PutValue("Tổng Biểu 3");
                            _range.Merge(donghientai + vitri + i + 5, 5, 1, 3);
                            _range[donghientai + vitri + i + 5, 8].PutValue(ctTong.slb3Giao);
                            _range[donghientai + vitri + i + 5, 12].PutValue(ctTong.slb3Nhan);
                        }
                        else if (i == 5)
                        {
                            _range[donghientai + vitri + i + 5, 5].PutValue("Tổng 3 Biểu");
                            _range.Merge(donghientai + vitri + i + 5, 5, 1, 3);
                            _range[donghientai + vitri + i + 5, 8].PutValue(ctTong.tong3B_Giao);
                            _range[donghientai + vitri + i + 5, 12].PutValue(ctTong.tong3B_Nhan);
                        }
                    }
                }




                vitri = vitri + 10;
            }

            #endregion

            exBook.Save("BC_GiaoNhanChiNhanh.xls", SaveType.OpenInExcel, FileFormatType.Default, this.Response);
            //Response.Redirect("../BaoCao/Report.aspx?Loai=5&strSQL=" + strTruyVan);
        }

    }
}