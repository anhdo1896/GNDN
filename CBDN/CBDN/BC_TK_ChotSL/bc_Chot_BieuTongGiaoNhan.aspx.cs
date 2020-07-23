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
    public partial class bc_Chot_BieuTongGiaoNhan : BasePage
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
                if (DateTime.Now.Month == 1)
                {
                    cmbThang.Value = 11;
                    cmbNam.Value = DateTime.Now.Year - 1;
                }
                else if (DateTime.Now.Month == 2)
                {
                    cmbThang.Value = 12;
                    cmbNam.Value = DateTime.Now.Year - 1;
                }
                else
                {
                    cmbThang.Value = DateTime.Now.Month - 2;
                    cmbNam.Value = DateTime.Now.Year;
                }
            }
            loadDanhMuc();
            if (!IsPostBack)
                _DataBind();
        }

        private void loadDanhMuc()
        {
            MTCSYT.SYS_Session session = (MTCSYT.SYS_Session)Session["SYS_Session"];
            int ma_dviqly = int.Parse(session.User.ma_dviqly + "");

            tlDonVi.DataSource = db.BC_GiaoNhanDaXacNhan(ma_dviqly, int.Parse(cmbThang.Value + ""), int.Parse(cmbNam.Value + "")).ToList();
            tlDonVi.DataBind();
        }

        private void _DataBind()
        {
            if (tlDonVi.FocusedNode == null)
            {
                return;
            }
            MTCSYT.SYS_Session session = (MTCSYT.SYS_Session)Session["SYS_Session"];
            int ma_dviqly = int.Parse(session.User.ma_dviqly + "");
            if (int.Parse(tlDonVi.FocusedNode.Key) > 0)
            {
                var lst = db.db_CHOT_GetSanLuongIDGiaoNhan_LS(ma_dviqly, int.Parse(tlDonVi.FocusedNode.Key), int.Parse(cmbThang.Value + ""), int.Parse(cmbNam.Value + ""));
                foreach (var chitiet in lst)
                {
                    lbPhuongThucGiaoNhan.Text = chitiet.TenChiNhanh;
                    lbB1Giao.Text = chitiet.Giao_Bieu1_SanLuong + "";
                    lbB1Nhan.Text = chitiet.Nhan_Bieu1_SanLuong + "";
                    lbDienLucNhan.Text = chitiet.dvNhan + "";
                    lbDLGiao.Text = chitiet.dvGiao;
                    lbB2Giao.Text = chitiet.Giao_Bieu2_SanLuong + "";
                    lbB2Nhan.Text = chitiet.Nhan_Bieu2_SanLuong + "";
                    lbBieu3Giao.Text = chitiet.Giao_Bieu3_SanLuong + "";
                    lbB3Nhan.Text = chitiet.Nhan_Bieu3_SanLuong + "";
                    lbTongPGiao.Text = chitiet.Giao_P_SanLuong + "";
                    lbPNhan.Text = chitiet.Nhan_P_SanLuong + "";
                    lbTongQGiao.Text = chitiet.Giao_Q_SanLuong + "";
                    lbQNhan.Text = chitiet.Nhan_Q_SanLuong + "";
                    break;
                }
                var chinhanh = db.DM_ChiNhanhs.SingleOrDefault(x => x.ID == int.Parse(tlDonVi.FocusedNode.Key));
                if (chinhanh != null)
                {
                    var gdXN = db.HD_GiamDocXNGiaoNhans.SingleOrDefault(x => x.IDChiNhanh == chinhanh.MaChiNhanh && x.Thang == int.Parse(cmbThang.Value + "") && x.Nam == int.Parse(cmbNam.Value + ""));
                    if (gdXN != null)
                    {
                        if (gdXN.ISGDGXN != null)
                        {
                            if ((bool)gdXN.ISGDGXN)
                            {
                                lbGiaoXN.Visible = true;
                                lbGiaoXN.Text = "Đã xác nhận vào ngày: " + ((DateTime)gdXN.NgayGDGXN).ToString("dd/MM/yyyy");
                            }
                            else
                                lbGiaoXN.Visible = false;
                        }
                        else
                            lbGiaoXN.Visible = false;
                        if ((gdXN.ISGDNXN != null))
                        {
                            if ((bool)gdXN.ISGDNXN)
                            {
                                lbNhanXacNhan.Visible = true;
                                lbNhanXacNhan.Text = "Đã xác nhận vào ngày: " + ((DateTime)gdXN.NgayGDNXN).ToString("dd/MM/yyyy");
                            }
                            else
                                lbNhanXacNhan.Visible = false;
                        }
                        else
                            lbNhanXacNhan.Visible = false;
                    }
                    else
                    {
                        lbGiaoXN.Visible = false;
                        lbNhanXacNhan.Visible = false;
                    }


                }


            }
        }

        protected void btnLoc_Click(object sender, EventArgs e)
        {
            loadDanhMuc();
            _DataBind();
        }



        protected void TreeListOrganization_HtmlCommandCellPrepared(object sender, DevExpress.Web.ASPxTreeList.TreeListHtmlCommandCellEventArgs e)
        {

        }


        protected void tlDonVi_FocusedNodeChanged(object sender, EventArgs e)
        {
            _DataBind();
        }

        protected void btnLuu_Click(object sender, EventArgs e)
        {

        }

        protected void btXuatDL_Click(object sender, EventArgs e)
        {

            if (tlDonVi.FocusedNode == null)
            {
                return;
            }
            Response.Redirect("../Report/Report.aspx?ChinhNhanh=" + tlDonVi.FocusedNode.Key + "&Loai=8&XacNhan=1&Thang=" + cmbThang.Value + "&Nam=" + cmbNam.Value);
            //#region Chuẩn bị tệp excel mẫu để ghi dữ liệu
            //string destFile = Server.MapPath("~/Tem/BC_TongHopDienNang.xls");
            //string sTemplate = (destFile);
            //Workbook exBook = new Workbook();
            //exBook.Open(sTemplate, FileFormatType.Excel2003);
            //_exSheet = exBook.Worksheets[0];
            //_range = _exSheet.Cells;
            //#endregion
            //MTCSYT.SYS_Session session = (MTCSYT.SYS_Session)Session["SYS_Session"];
            //int ma_dviqly = int.Parse(session.User.ma_dviqly + "");
            //if (int.Parse(tlDonVi.FocusedNode.Key) > 0)
            //{
            //    DM_DVQLYService dm_dviSer = new DM_DVQLYService();
            //    var donvi = dm_dviSer.SelectDM_DVQLY(ma_dviqly);
            //    _exSheet.Replace("ntDienLuc", donvi.NAME_DVIQLY.Split('-')[1].ToString().ToUpper());

            //    var lst = db.db_GetSanLuongIDGiaoNhan(ma_dviqly, int.Parse(tlDonVi.FocusedNode.Key), int.Parse(cmbThang.Value + ""), int.Parse(cmbNam.Value + ""));
            //    foreach (var chitiet in lst)
            //    {
            //        _exSheet.Replace("ntGiaoNhan", "Sản lượng điện năng giao nhận tháng " + cmbThang.Value + " năm " + cmbNam.Value + " giữa " + chitiet.dvGiao + " với " + chitiet.dvNhan + " như sau:");
            //        _exSheet.Replace("ntGiao", "1. Tổng sản lượng " + chitiet.dvGiao + " Giao cho " + chitiet.dvNhan + " trong tháng:");
            //        _exSheet.Replace("ntNhan", "2. Tổng sản lượng " + chitiet.dvGiao + " nhận từ " + chitiet.dvNhan + " trong tháng:");
            //        _exSheet.Replace("ntDLGiao",  chitiet.dvGiao );
            //        _exSheet.Replace("ntDLNhan", chitiet.dvNhan);

            //        _exSheet.Replace("ntBieu1G", chitiet.Giao_Bieu1_SanLuong + "");
            //        _exSheet.Replace("ntBieu2G", chitiet.Giao_Bieu2_SanLuong + "");
            //        _exSheet.Replace("ntBieu3G", chitiet.Giao_Bieu3_SanLuong + "");
            //        _exSheet.Replace("ntSL3Bieu", (chitiet.Giao_Bieu1_SanLuong + chitiet.Giao_Bieu2_SanLuong + chitiet.Giao_Bieu3_SanLuong) + "");

            //        _exSheet.Replace("ntBieu1N", chitiet.Nhan_Bieu1_SanLuong + "");
            //        _exSheet.Replace("ntBieu2N", chitiet.Nhan_Bieu2_SanLuong + "");
            //        _exSheet.Replace("ntBieu3N", chitiet.Nhan_Bieu3_SanLuong + "");
            //        _exSheet.Replace("ntNSL3Bieu", (chitiet.Nhan_Bieu1_SanLuong + chitiet.Nhan_Bieu2_SanLuong + chitiet.Nhan_Bieu3_SanLuong) + "");

            //        break;
            //    }
            //    var lst1Gia = db.db_GetSanLuongIDGiaoNhan_1Gia(ma_dviqly, int.Parse(tlDonVi.FocusedNode.Key), int.Parse(cmbThang.Value + ""), int.Parse(cmbNam.Value + ""));
            //    if (lst1Gia.Count() > 0)
            //    {
            //        foreach (var chitiet in lst1Gia)
            //        {
            //            _exSheet.Replace("ntTong1GiaG", (chitiet.Giao_Bieu1_SanLuong + chitiet.Giao_Bieu2_SanLuong + chitiet.Giao_Bieu3_SanLuong) + "");
            //            _exSheet.Replace("ntTong1GiaN", (chitiet.Nhan_Bieu1_SanLuong + chitiet.Nhan_Bieu2_SanLuong + chitiet.Nhan_Bieu3_SanLuong) + "");
            //            break;
            //        }
            //    }
            //    else
            //    {
            //        _exSheet.Replace("ntTong1GiaG", "0");
            //        _exSheet.Replace("ntTong1GiaN", "0");
            //    }
            //}

            //exBook.Save("BC_ChotDLThang.xls", SaveType.OpenInExcel, FileFormatType.Default, this.Response);
        }



    }
}