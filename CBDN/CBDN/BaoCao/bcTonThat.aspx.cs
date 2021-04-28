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
    public partial class bcTonThat : BasePage
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
            else if (session.XacNhanPass == 0)
            {
                ScriptManager.RegisterStartupScript(this, this.GetType(), "alertMessage", "alert('Mật Khẩu Không Hợp Lệ. Yêu Cầu Đổi Mật Khẩu'); window.location='" +
                Request.ApplicationPath + "HeThong/ChangePassword.aspx';", true);
            }
            else if (session.DatePass > 90)
            {
                ScriptManager.RegisterStartupScript(this, this.GetType(), "alertMessage", "alert('Mật Khẩu Quá 90 Ngày. Yêu Cầu Đổi Mật Khẩu'); window.location='" +
                Request.ApplicationPath + "HeThong/ChangePassword.aspx';", true);
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
                loadDV();
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
            }
            loadDanhMuc();
        }
        private void loadDV()
        {
            MTCSYT.SYS_Session session = (MTCSYT.SYS_Session)Session["SYS_Session"];

            List<CBDN.DM_DVQLY> lstDD = db.DM_DVQLies.Where(x => x.Type == 2 || x.Type==1).ToList();
            cmbDonVi.DataSource = lstDD;
            cmbDonVi.ValueField = "IDMA_DVIQLY";
            cmbDonVi.TextField = "TEN_DVIQLY";
            cmbDonVi.DataBind();
            cmbDonVi.SelectedIndex = 0;
        }
        private void loadDanhMuc()
        {
            if (cmbDonVi.Value == null) return;
            DM_DVQLYService dm_dviSer = new DM_DVQLYService();

            MTCSYT.SYS_Session session = (MTCSYT.SYS_Session)Session["SYS_Session"];
            int ma_dviqly = int.Parse(session.User.ma_dviqly + "");

            //grdDVT.DataSource = db.BC_TonThat110ChiTiet(int.Parse(cmbDonVi.Value+""), int.Parse(cmbThang.Value + ""), int.Parse(cmbNam.Value + ""), cmbCapDienAp.Value + "");
            grdDVT.DataSource = db.BC_TonThat_ChiTietCDA(int.Parse(cmbDonVi.Value + ""), int.Parse(cmbThang.Value + ""), int.Parse(cmbNam.Value + ""), cmbCapDienAp.Value + "");
            grdDVT.DataBind();

            //var listTong = db.BC_TonThat110(int.Parse(cmbDonVi.Value + ""), int.Parse(cmbThang.Value + ""), int.Parse(cmbNam.Value + ""), cmbCapDienAp.Value + "");
            var listTong = db.BC_TonThatCDA(int.Parse(cmbDonVi.Value + ""), int.Parse(cmbThang.Value + ""), int.Parse(cmbNam.Value + ""), cmbCapDienAp.Value + "");
            grdBieuTong.DataSource = listTong;
            grdBieuTong.DataBind();

            grdTonHao.DataSource = listTong;
            grdTonHao.DataBind();

            grdTonThat.DataSource = listTong;
            grdTonThat.DataBind();

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
            if (cmbDonVi.Value == null) return;
            MTCSYT.SYS_Session session = (MTCSYT.SYS_Session)Session["SYS_Session"];
            int ma_dviqly = int.Parse(session.User.ma_dviqly + "");

            var lst = db.BC_TonThat_ChiTietCDA(int.Parse(cmbDonVi.Value + ""), int.Parse("0" + cmbThang.Value), int.Parse("0" + cmbNam.Value), cmbCapDienAp.Value + "").ToList();
            var lsttONG = db.BC_TonThatCDA(int.Parse(cmbDonVi.Value + ""), int.Parse("0" + cmbThang.Value), int.Parse("0" + cmbNam.Value), cmbCapDienAp.Value + "").ToList();

            //var lst = db.BC_TonThat110ChiTiet(int.Parse(cmbDonVi.Value + ""), int.Parse("0" + cmbThang.Value), int.Parse("0" + cmbNam.Value), cmbCapDienAp.Value + "").ToList();
            //var lsttONG = db.BC_TonThat110(int.Parse(cmbDonVi.Value + ""), int.Parse("0" + cmbThang.Value), int.Parse("0" + cmbNam.Value), cmbCapDienAp.Value + "").ToList();
            #region Chuẩn bị tệp excel mẫu để ghi dữ liệu
            string destFile = Server.MapPath("~/Tem/BC_TonThat.xls");
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
            _exSheet.Replace("ntNgayThang", "Ngày " + DateTime.Now.Day + " tháng " + DateTime.Now.Month + " năm " + DateTime.Now.Year);

            Style celicaStil = exBook.Styles[exBook.Styles.Add()];
            celicaStil.Font.IsBold = true;

            DM_DVQLYService dm_dviSer = new DM_DVQLYService();
            var donvi = dm_dviSer.SelectDM_DVQLY(ma_dviqly);

            _exSheet.Replace("ntDienLuc", donvi.NAME_DVIQLY.Split('-')[1].ToUpper());

            _exSheet.Replace("ntTieuDe", "BÁO CÁO SẢN LƯỢNG ĐIỆN GIAO CỦA " + donvi.NAME_DVIQLY.Split('-')[1].ToString().ToUpper() + " TRONG THÁNG " + cmbThang.Value + " NĂM " + cmbNam.Value);

            if (lst.Count > 0)
            {
                _exSheet.Cells.InsertRows(donghientai + 1, lst.Count);
            }

            int stt = 1;
            string tenchinhan = "";
            foreach (var chitiet in lst)
            {
                _range[donghientai + stt, 0].PutValue(stt);
                if (tenchinhan != chitiet.TenChiNhanh)
                {
                    var soTCN = lst.Where(x => x.TenChiNhanh == chitiet.TenChiNhanh);
                    _range[donghientai + stt, 1].PutValue(chitiet.TenChiNhanh);
                    _range.Merge(donghientai + stt, 1, soTCN.Count(), 1);
                    _range[donghientai + stt, 1].SetStyle(celicaStil);
                    tenchinhan = chitiet.TenChiNhanh;
                }


                _range[donghientai + stt, 2].PutValue(chitiet.MaDiemDo + "-" + chitiet.TenDiemDo);
                _range[donghientai + stt, 3].PutValue(chitiet.Nhan_Bieu1_SanLuong);
                _range[donghientai + stt, 4].PutValue(chitiet.Giao_Bieu1_SanLuong);
                _range[donghientai + stt, 5].PutValue(chitiet.Nhan_Bieu2_SanLuong);
                _range[donghientai + stt, 6].PutValue(chitiet.Giao_Bieu2_SanLuong);
                _range[donghientai + stt, 7].PutValue(chitiet.Nhan_Bieu3_SanLuong);
                _range[donghientai + stt, 8].PutValue(chitiet.Giao_Bieu3_SanLuong);
                _range[donghientai + stt, 9].PutValue(chitiet.TongNhan3B);
                _range[donghientai + stt, 10].PutValue(chitiet.TongGiao3B);
                stt++;
            }
            foreach (var chitiet in lsttONG)
            {

                _range[donghientai + stt, 0].PutValue("Tổng");
                _range.Merge(donghientai + stt, 0, 1, 3);
                _range[donghientai + stt, 3].PutValue(chitiet.NhanB1);
                _range[donghientai + stt, 4].PutValue(chitiet.GiaoB1);
                _range[donghientai + stt, 5].PutValue(chitiet.NhanB2);
                _range[donghientai + stt, 6].PutValue(chitiet.GiaoB2);
                _range[donghientai + stt, 7].PutValue(chitiet.NhanB3);
                _range[donghientai + stt, 8].PutValue(chitiet.GiaoB3);
                _range[donghientai + stt, 9].PutValue(chitiet.TongN3B);
                _range[donghientai + stt, 10].PutValue(chitiet.TongG3B);
                stt++;

                _range[donghientai + stt, 0].PutValue("Tổn hao");
                _range.Merge(donghientai + stt, 0, 1, 3);
                _range[donghientai + stt, 3].PutValue(chitiet.TonHao1);
                _range.Merge(donghientai + stt, 3, 1, 2);
                _range[donghientai + stt, 5].PutValue(chitiet.TonHao2);
                _range.Merge(donghientai + stt, 5, 1, 2);
                _range[donghientai + stt, 7].PutValue(chitiet.TonHao3);
                _range.Merge(donghientai + stt, 7, 1, 2);
                _range[donghientai + stt, 9].PutValue(chitiet.TonHaoTong);
                _range.Merge(donghientai + stt, 9, 1, 2);
                stt++;

                _range[donghientai + stt, 0].PutValue("Tổng thất công ty");
                _range.Merge(donghientai + stt, 0, 1, 3);
                _range[donghientai + stt, 3].PutValue(chitiet.TiLeTonThatB1);
                _range.Merge(donghientai + stt, 3, 1, 2);
                _range[donghientai + stt, 5].PutValue(chitiet.TiLeTonThatB2);
                _range.Merge(donghientai + stt, 5, 1, 2);
                _range[donghientai + stt, 7].PutValue(chitiet.TiLeTonThatb3);
                _range.Merge(donghientai + stt, 7, 1, 2);
                _range[donghientai + stt, 9].PutValue(chitiet.TiLeTonThat);
                _range.Merge(donghientai + stt, 9, 1, 2);

                break;
            }


            #endregion

            exBook.Save("bc_dienLuc.xls", SaveType.OpenInExcel, FileFormatType.Default, this.Response);
            //Response.Redirect("../BaoCao/Report.aspx?Loai=5&strSQL=" + strTruyVan);
        }

        protected void grdDVT_CellEditorInitialize1(object sender, ASPxGridViewEditorEventArgs e)
        {

        }

        protected void grdDVT_CustomColumnDisplayText(object sender, ASPxGridViewColumnDisplayTextEventArgs e)
        {

        }

        protected void grdDVT_HtmlCommandCellPrepared(object sender, ASPxGridViewTableCommandCellEventArgs e)
        {

        }

    }
}