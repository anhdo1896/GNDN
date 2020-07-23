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
namespace MTCSYT
{
    public partial class bd_TongXacNhan : BasePage
    {
        CBDN.DB_CBDNDataContext db = new CBDN.DB_CBDNDataContext(new CBDN.ADOController().strcn());
        private SYS_Right rightOfUser = null;
        private const string funcid = "57";
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
                    cmbThang.Value = 12;
                    cmbNam.Value = DateTime.Now.Year - 1;

                }
                else
                {
                    cmbThang.Value = DateTime.Now.Month - 1;
                    cmbNam.Value = DateTime.Now.Year;

                } 
              //  _DataBind();
                loadGiaoNhan();
            }
           // loadDanhMuc();
            InTongHopDienNang();

        }
        private void loadGiaoNhan()
        {
            MTCSYT.SYS_Session session = (MTCSYT.SYS_Session)Session["SYS_Session"];
            var lstDD = db.db_SelectPhuongThucCanXN(int.Parse(session.User.ma_dviqly + ""), int.Parse(cmbThang.Value + ""), int.Parse(cmbNam.Value + ""), "GDXacNhan").ToList();
            cmbPhuongThuc.DataSource = lstDD;
            cmbPhuongThuc.ValueField = "IDChiNhanh";
            cmbPhuongThuc.TextField = "TenPhuongThuc";
            cmbPhuongThuc.DataBind();

        }
        //private void loadDanhMuc()
        //{
        //    MTCSYT.SYS_Session session = (MTCSYT.SYS_Session)Session["SYS_Session"];
        //    int ma_dviqly = int.Parse(session.User.ma_dviqly + "");

        //    tlDonVi.DataSource = db.db_ChiNhanhSelectXacNhan(ma_dviqly, int.Parse(cmbThang.Value + ""), int.Parse(cmbNam.Value + "")).ToList();
        //    tlDonVi.DataBind();
        //}
        private void InTongHopDienNang()
        {
            if (cmbPhuongThuc.Value != null)
            {
                MTCSYT.SYS_Session session = (MTCSYT.SYS_Session)Session["SYS_Session"];
                int ma_dviqly = int.Parse(session.User.ma_dviqly);
                DM_DVQLYService dm_dviSer = new DM_DVQLYService();
                var donvi = dm_dviSer.SelectDM_DVQLY(ma_dviqly);
                bool kiemtra = false;
                //  if (Request["XacNhan"] + "" == "1") kiemtra = true;

                //MTCSYT.Report.InBieuTong report = new MTCSYT.Report.InBieuTong(int.Parse(cmbPhuongThuc.Value + ""), ma_dviqly, int.Parse(cmbThang.Value + ""), int.Parse(cmbNam.Value + ""), kiemtra, kiemtra, "", "", donvi.TEN_DVIQLY, 0,"","","","");

                //ReportViewer1.Report = report;

                //ReportToolbar1.ReportViewer = ReportViewer1;
            }

        }
       /* private void _DataBind()
        {
            if (tlDonVi.FocusedNode == null)
            {
                btnXacNhan.Enabled = false;
                return;
            }
            btnXacNhan.Enabled = true;
            MTCSYT.SYS_Session session = (MTCSYT.SYS_Session)Session["SYS_Session"];
            int ma_dviqly = int.Parse(session.User.ma_dviqly + "");
            int IDDViNhan = 0;
            int IDDViGiao = 0;
            lbNhanXacNhan.Text = "Chưa xác nhận";
            lbGiaoXN.Text = "Chưa xác nhận";
            if (int.Parse(tlDonVi.FocusedNode.Key) > 0)
            {
                var lst = db.db_GetSanLuongIDGiaoNhan(ma_dviqly, int.Parse(tlDonVi.FocusedNode.Key), int.Parse(cmbThang.Value + ""), int.Parse(cmbNam.Value + "")).ToList();
                if (lst.Count() == 0)
                {
                    lbPhuongThucGiaoNhan.Text = 0 + "";
                    lbB1Giao.Text = 0 + "";
                    lbB1Nhan.Text = 0 + "";
                    lbDienLucNhan.Text = 0 + "";
                    lbDLGiao.Text = 0 + "";
                    lbB2Giao.Text = 0 + "";
                    lbB2Nhan.Text = 0 + "";
                    lbBieu3Giao.Text = 0 + "";
                    lbB3Nhan.Text = 0 + "";
                    lbTongPGiao.Text = 0 + "";
                    lbPNhan.Text = 0 + "";
                    lbTongQGiao.Text = 0 + "";
                    lbQNhan.Text = 0 + "";
                    lbNhanXacNhan.Text = "Cấp trưởng phòng chưa xác nhận";
                    lbNhanXacNhan.Visible = true;
                    lbGiaoXN.Text = "Cấp trưởng phòng chưa xác nhận";
                    lbGiaoXN.Visible = true;
                }
                else
                {
                    foreach (var chitiet in lst)
                    {
                        lbPhuongThucGiaoNhan.Text = chitiet.TenChiNhanh;
                        lbB1Giao.Text = chitiet.Giao_Bieu1_SanLuong + "";
                        lbB1Nhan.Text = chitiet.Nhan_Bieu1_SanLuong + "";
                        lbDienLucNhan.Text = chitiet.dvNhan + "";
                        lbDLGiao.Text = chitiet.dvGiao;
                        IDDViGiao = (int)chitiet.IDDonViGiao;
                        IDDViNhan = (int)chitiet.IDDonViNhan;
                        lbB2Giao.Text = chitiet.Giao_Bieu2_SanLuong + "";
                        lbB2Nhan.Text = chitiet.Nhan_Bieu2_SanLuong + "";
                        lbBieu3Giao.Text = chitiet.Giao_Bieu3_SanLuong + "";
                        lbB3Nhan.Text = chitiet.Nhan_Bieu3_SanLuong + "";
                        lbTongPGiao.Text = (chitiet.Giao_Bieu1_SanLuong + chitiet.Giao_Bieu2_SanLuong + chitiet.Giao_Bieu3_SanLuong) + "";
                        lbPNhan.Text = (chitiet.Nhan_Bieu1_SanLuong + chitiet.Nhan_Bieu2_SanLuong + chitiet.Nhan_Bieu3_SanLuong) + "";
                        lbTongQGiao.Text = chitiet.Giao_Q_SanLuong + "";
                        lbQNhan.Text = chitiet.Nhan_Q_SanLuong + "";
                        break;
                    }

                    var chinhanh = db.DM_ChiNhanhs.SingleOrDefault(x => x.ID == int.Parse(tlDonVi.FocusedNode.Key));
                    bool kiemtraG = false, kiemtraN = false;
                    var giao = db.HD_GiamDocXNGiaoNhans.SingleOrDefault(x => x.IDChiNhanh == chinhanh.ID + "" && (x.IDGDGXN == IDDViGiao || x.IDGDNXN == IDDViGiao) && x.Thang == int.Parse(cmbThang.Value + "") && x.Nam == int.Parse(cmbNam.Value + ""));
                    if (giao != null)
                    {
                        if (giao.ISGDGXN != null)
                            kiemtraG = (bool)giao.ISGDGXN;
                        else kiemtraG = false;
                        if (giao.ISGDNXN != null)
                            kiemtraN = (bool)giao.ISGDNXN;
                        else
                            kiemtraN = false;

                        if (kiemtraG || kiemtraN)
                        {
                            lbGiaoXN.Visible = true;
                            if (giao.NgayGDGXN + "" != "")
                                lbGiaoXN.Text = "Đã xác nhận vào ngày: " + ((DateTime)giao.NgayGDGXN).ToString("dd/MM/yyyy");
                            else
                                lbGiaoXN.Text = "Đã xác nhận vào ngày: " + ((DateTime)giao.NgayGDNXN).ToString("dd/MM/yyyy");
                        }
                    }
                    var nhan = db.HD_GiamDocXNGiaoNhans.SingleOrDefault(x => x.IDChiNhanh == chinhanh.ID + "" && (x.IDGDNXN == IDDViNhan || x.IDGDGXN == IDDViNhan) && x.Thang == int.Parse(cmbThang.Value + "") && x.Nam == int.Parse(cmbNam.Value + ""));
                    if (nhan != null)
                    {
                        if (nhan.ISGDGXN != null)
                            kiemtraG = (bool)nhan.ISGDGXN;
                        else kiemtraG = false;
                        if (nhan.ISGDNXN != null)
                            kiemtraN = (bool)nhan.ISGDNXN;
                        else
                            kiemtraN = false;
                        if (kiemtraN || kiemtraG)
                        {
                            lbNhanXacNhan.Visible = true;
                            if (nhan.NgayGDNXN + "" != "")
                                lbNhanXacNhan.Text = "Đã xác nhận vào ngày: " + ((DateTime)nhan.NgayGDNXN).ToString("dd/MM/yyyy");
                            else
                                lbNhanXacNhan.Text = "Đã xác nhận vào ngày: " + ((DateTime)nhan.NgayGDGXN).ToString("dd/MM/yyyy");
                        }
                    }

                    //if (chinhanh != null)
                    //{
                    //    var gdXN = db.HD_GiamDocXNGiaoNhans.SingleOrDefault(x => x.IDChiNhanh == chinhanh.ID + "" && x.Thang == int.Parse(cmbThang.Value + "") && x.Nam == int.Parse(cmbNam.Value + ""));
                    //    if (gdXN != null)
                    //    {
                    //        if (gdXN.ISGDGXN != null)
                    //        {

                    //            if ((bool)gdXN.ISGDGXN)
                    //            {
                    //                lbGiaoXN.Visible = true;
                    //                lbGiaoXN.Text = "Đã xác nhận vào ngày: " + ((DateTime)gdXN.NgayGDGXN).ToString("dd/MM/yyyy");
                    //            }
                    //            else
                    //                lbGiaoXN.Visible = false;
                    //        }
                    //        else
                    //            lbGiaoXN.Visible = false;
                    //        if ((gdXN.ISGDNXN != null))
                    //        {
                    //            if ((bool)gdXN.ISGDNXN)
                    //            {
                    //                lbNhanXacNhan.Visible = true;
                    //                lbNhanXacNhan.Text = "Đã xác nhận vào ngày: " + ((DateTime)gdXN.NgayGDNXN).ToString("dd/MM/yyyy");
                    //            }
                    //            else
                    //                lbNhanXacNhan.Visible = false;
                    //        }
                    //        else
                    //            lbNhanXacNhan.Visible = false;
                    //    }
                    //    else
                    //    {
                    //        lbGiaoXN.Visible = false;
                    //        lbNhanXacNhan.Visible = false;
                    //    }

                    //}
                }


            }
        }
        */
        protected void btnLoc_Click(object sender, EventArgs e)
        {
            InTongHopDienNang();
        }



        protected void TreeListOrganization_HtmlCommandCellPrepared(object sender, DevExpress.Web.ASPxTreeList.TreeListHtmlCommandCellEventArgs e)
        {

        }


        protected void tlDonVi_FocusedNodeChanged(object sender, EventArgs e)
        {
           // _DataBind();
        }

        protected void btnLuu_Click(object sender, EventArgs e)
        {

        }

        protected void btnXacNhan_Click(object sender, EventArgs e)
        {
            MTCSYT.SYS_Session session = (MTCSYT.SYS_Session)Session["SYS_Session"];
            int ma_dviqly = int.Parse(session.User.ma_dviqly + "");
            //var chinhanh = db.DM_ChiNhanhs.SingleOrDefault(x => x.ID == int.Parse(tlDonVi.FocusedNode.Key));
            var congto = db.DM_CongTos.Where(x => x.IDChiNhanh == cmbPhuongThuc.Value + "");
            int dvGiao = 0, idDVNhan = 0;
            CBDN.DM_CongTo cto = new CBDN.DM_CongTo();
            foreach (var ct in congto)
            {
                cto = ct;
                break;
            }
            dvGiao = (int)cto.IDDonViGiao;
            idDVNhan = (int)cto.IDDonViNhan;

            var gdXN = db.HD_GiamDocXNGiaoNhans.SingleOrDefault(x => x.IDChiNhanh == cto.IDChiNhanh + "" && x.Thang == int.Parse(cmbThang.Value + "") && x.Nam == int.Parse(cmbNam.Value + ""));
            if (gdXN == null)
            {
                CBDN.HD_GiamDocXNGiaoNhan gd = new CBDN.HD_GiamDocXNGiaoNhan();
                gd.IDChiNhanh = cto.IDChiNhanh + "";
                if (dvGiao == ma_dviqly)
                {
                    gd.IDGDGXN = ma_dviqly;
                    gd.ISGDGXN = true;
                    gd.NgayGDGXN = DateTime.Now;
                    gd.IDUserGiaoXN = session.User.IDUSER;
                }
                else if (idDVNhan == ma_dviqly)
                {
                    gd.IDGDNXN = ma_dviqly;
                    gd.ISGDNXN = true;
                    gd.NgayGDNXN = DateTime.Now;
                    gd.IDUserNhanXN = session.User.IDUSER;
                }
                gd.Thang = int.Parse("" + cmbThang.Value);
                gd.Nam = int.Parse("" + cmbNam.Value);
                db.HD_GiamDocXNGiaoNhans.InsertOnSubmit(gd);
                db.SubmitChanges();
            }
            else
            {
                if (dvGiao == ma_dviqly)
                {
                    gdXN.IDGDGXN = ma_dviqly;
                    gdXN.ISGDGXN = true;
                    gdXN.NgayGDGXN = DateTime.Now;
                    gdXN.IDUserGiaoXN = session.User.IDUSER;
                }
                else if (idDVNhan == ma_dviqly)
                {
                    gdXN.IDGDNXN = ma_dviqly;
                    gdXN.ISGDNXN = true;
                    gdXN.NgayGDNXN = DateTime.Now;
                    gdXN.IDUserNhanXN = session.User.IDUSER;
                }
                db.SubmitChanges();
            }
            InTongHopDienNang();
        }

        protected void btnXemBanIn_Click(object sender, EventArgs e)
        {
           
        }

        protected void btnKoXacNhan_Click(object sender, EventArgs e)
        {
            pcAddRoles.ShowOnPageLoad = true;

        }

        protected void btnCapNhat_Click(object sender, EventArgs e)
        {
            MTCSYT.SYS_Session session = (MTCSYT.SYS_Session)Session["SYS_Session"];
            int ma_dviqly = int.Parse(session.User.ma_dviqly + "");
            var lstGiao = db.HD_GiaoNhanThangs.Where(x => x.IDChiNhanh == cmbPhuongThuc.Value+ "").ToList();
            foreach (var a in lstGiao)
            {
                var bd_chitiet = db.HD_GiaoNhanThangs.SingleOrDefault(x => x.ID == a.ID);
                bd_chitiet.ISNhanVien = false;
                bd_chitiet.NgayXacNhanDVGiao = DateTime.Now;
                bd_chitiet.XacNhanDVNhan = false;
                bd_chitiet.ISChot = false;

                if (txtLyDo.Text != "")
                    bd_chitiet.GhiChuXacNhanGiao = txtLyDo.Text;
                else
                    bd_chitiet.GhiChuXacNhanGiao = "Không đồng ý xác nhận điểm đo này";
                bd_chitiet.XacNhanDVGiao = false;
                bd_chitiet.ISChot = false;
                bd_chitiet.NgayXacNhanDVNhan = DateTime.Now;

                if (txtLyDo.Text != "")
                    bd_chitiet.GhiChuXacNhanNhan = txtLyDo.Text;
                else
                    bd_chitiet.GhiChuXacNhanNhan = "Không đồng ý xác nhận điểm đo này";

                db.SubmitChanges();
            }
            pcAddRoles.ShowOnPageLoad = false;
        }

        protected void btnDong_Click(object sender, EventArgs e)
        {
            pcAddRoles.ShowOnPageLoad = false;
        }

        protected void cmbNam_SelectedIndexChanged(object sender, EventArgs e)
        {
            InTongHopDienNang();

        }

        protected void cmbThang_SelectedIndexChanged(object sender, EventArgs e)
        {
            InTongHopDienNang();

        }

        protected void cmbPhuongThuc_SelectedIndexChanged(object sender, EventArgs e)
        {
            InTongHopDienNang();
        }

        protected void btnIn_Click(object sender, EventArgs e)
        {
            MTCSYT.SYS_Session session = (MTCSYT.SYS_Session)Session["SYS_Session"];
            string strMadviqly = session.User.ma_dviqly;
            Response.Redirect("../Report/Report.aspx?ChiNhanh=" + cmbPhuongThuc.Value + "&Loai=1&Thang=" + cmbThang.Value + "&Nam=" + cmbNam.Value + "&ParentId=1");

        }

    }
}