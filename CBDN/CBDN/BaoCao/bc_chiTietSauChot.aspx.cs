using System;
using System.Collections.Generic;
using DevExpress.Web;
using Entity;
using SystemManageService;
using System.Web.UI;
using System.Linq;
using System.Data;
using DevExpress.Web.ASPxGridView;
using DevExpress.Web;
using Aspose.Cells;
namespace MTCSYT
{
    public partial class bc_chiTietSauChot : BasePage
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
    
        protected void btnXuat_Click(object sender, EventArgs e)
        {
            MTCSYT.SYS_Session session = (MTCSYT.SYS_Session)Session["SYS_Session"];
            int ma_dviqly = int.Parse(session.User.ma_dviqly + "");

            var lst = db.BC_ChotChiSoThang(ma_dviqly, int.Parse("0" + cmbThang.Value), int.Parse("0" + cmbNam.Value)).ToList();
            var lsttONG = db.BC_TongTram_DaChot(ma_dviqly, int.Parse("0" + cmbThang.Value), int.Parse("0" + cmbNam.Value)).ToList();
            #region Chuẩn bị tệp excel mẫu để ghi dữ liệu
            string destFile = Server.MapPath("~/Tem/BC_BCDienLuc.xls");
            string sTemplate = (destFile);
            Workbook exBook = new Workbook();
            exBook.Open(sTemplate, FileFormatType.Excel2003);
            _exSheet = exBook.Worksheets[0];
            _range = _exSheet.Cells;
            #endregion

            // Xử lý replace các thông tin báo cáo tĩnh theo công ty
            //Report.ReplaceSpecificationField(_exSheet);

            int donghientai = 7;

            #region Ghi dữ liệu
            _exSheet.Replace("NGAYTHANG", "Ngày " + DateTime.Now.Day + " tháng " + DateTime.Now.Month + " năm " + DateTime.Now.Year);

            Style celicaStil = exBook.Styles[exBook.Styles.Add()];
            celicaStil.VerticalAlignment = TextAlignmentType.Center;
            celicaStil.HorizontalAlignment = TextAlignmentType.Center;
            celicaStil.Pattern = BackgroundType.Solid;
            celicaStil.Font.IsBold = true;
            StyleFlag flg = new StyleFlag();

            DM_DVQLYService dm_dviSer = new DM_DVQLYService();
            var donvi = dm_dviSer.SelectDM_DVQLY(ma_dviqly);

            _exSheet.Replace("ntDienLuc", donvi.NAME_DVIQLY.ToUpper());

            _exSheet.Replace("ntTieuDe", "BÁO CÁO SẢN LƯỢNG ĐIỆN GIAO CỦA " + donvi.NAME_DVIQLY + " TRONG THÁNG " + cmbThang.Value + " NĂM " + cmbNam.Value);

            if (lst.Count > 0)
            {
                //_exSheet.Cells.InsertRows(donghientai + 1, (lst.Count + lsttONG.Count) - 3);
            }
            string idTram = "0"; int vitri = 0;
            int sttTong = 0, sttChiTiet = 0;
            foreach (var tongtram in lsttONG)
            {
                if (idTram != tongtram.IDTram + "")
                {
                    var tram = db.DM_Trams.SingleOrDefault(x => x.IDTram == tongtram.IDTram);
                    var phuongthuc = db.DM_ChiNhanhs.SingleOrDefault(x => x.MaChiNhanh == tram.IDChiNhanh);
                    _range[donghientai + vitri, 0].PutValue(phuongthuc.MoTa);
                    _range.Merge(donghientai + vitri, 0, 1, 21);
                    _range[donghientai + vitri, 0].SetStyle(celicaStil);

                    vitri = vitri + 1;
                    sttTong = sttTong + 1;
                    _range[donghientai + vitri, 0].PutValue(sttTong);
                    _range[donghientai + vitri, 0].SetStyle(celicaStil);
                    _range[donghientai + vitri, 1].PutValue(tongtram.TenTram);
                    _range[donghientai + vitri, 1].SetStyle(celicaStil);
                    _range[donghientai + vitri, 5].PutValue(tongtram.slPGiao);
                    _range[donghientai + vitri, 5].SetStyle(celicaStil);
                    _range[donghientai + vitri, 9].PutValue(tongtram.slb1Giao);
                    _range[donghientai + vitri, 9].SetStyle(celicaStil);
                    _range[donghientai + vitri, 13].PutValue(tongtram.slb2Giao);
                    _range[donghientai + vitri, 13].SetStyle(celicaStil);
                    _range[donghientai + vitri, 17].PutValue(tongtram.slb3Giao);
                    _range[donghientai + vitri, 17].SetStyle(celicaStil);
                    vitri = vitri + 1;
                    var lstByTram = lst.Where(x => x.IDTram == tongtram.IDTram);
                    sttChiTiet = sttChiTiet + 1;
                    foreach (var chitiet in lstByTram)
                    {
                        _range[donghientai + vitri, 0].PutValue(sttTong + "." + sttChiTiet);
                        _range[donghientai + vitri, 1].PutValue(chitiet.TenDiemDo);
                        _range[donghientai + vitri, 2].PutValue(chitiet.CapDienAp);
                        _range[donghientai + vitri, 3].PutValue(chitiet.HeSoNhan);
                        _range[donghientai + vitri, 4].PutValue(chitiet.Giao_P_Dau);
                        _range[donghientai + vitri, 5].PutValue(chitiet.Giao_P_Cuoi);
                        _range[donghientai + vitri, 6].PutValue(chitiet.Giao_P_Cuoi - chitiet.Giao_P_Dau);
                        _range[donghientai + vitri, 7].PutValue(chitiet.Giao_P_SanLuong);

                        _range[donghientai + vitri, 8].PutValue(chitiet.Giao_Bieu1_Dau);
                        _range[donghientai + vitri, 9].PutValue(chitiet.Giao_Bieu1_Cuoi);
                        _range[donghientai + vitri, 10].PutValue(chitiet.Giao_Bieu1_Cuoi - chitiet.Giao_Bieu1_Dau);
                        _range[donghientai + vitri, 11].PutValue(chitiet.Giao_Bieu1_SanLuong);

                        _range[donghientai + vitri, 12].PutValue(chitiet.Giao_Bieu2_Dau);
                        _range[donghientai + vitri, 13].PutValue(chitiet.Giao_Bieu2_Cuoi);
                        _range[donghientai + vitri, 14].PutValue(chitiet.Giao_Bieu2_Cuoi - chitiet.Giao_Bieu2_Dau);
                        _range[donghientai + vitri, 15].PutValue(chitiet.Giao_Bieu2_SanLuong);

                        _range[donghientai + vitri, 16].PutValue(chitiet.Giao_Bieu3_Dau);
                        _range[donghientai + vitri, 17].PutValue(chitiet.Giao_Bieu3_Cuoi);
                        _range[donghientai + vitri, 18].PutValue(chitiet.Giao_Bieu3_Cuoi - chitiet.Giao_Bieu3_Dau);
                        _range[donghientai + vitri, 19].PutValue(chitiet.Giao_Bieu3_SanLuong);

                        vitri = vitri + 1;
                    }
                    idTram = tongtram.IDTram + "";
                }

            }


            #endregion

            exBook.Save("bc_dienLuc.xls", SaveType.OpenInExcel, FileFormatType.Default, this.Response);
            //Response.Redirect("../BaoCao/Report.aspx?Loai=5&strSQL=" + strTruyVan);
        }

    }
}