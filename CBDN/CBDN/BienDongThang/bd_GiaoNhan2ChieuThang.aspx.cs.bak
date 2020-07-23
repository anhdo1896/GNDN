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
    public partial class bd_GiaoNhan2ChieuThang : BasePage
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

            }
            loadDanhMuc();
            if (!IsPostBack)
                _DataBind();
        }

        private void loadDanhMuc()
        {
            DM_DVQLYService dm_dviSer = new DM_DVQLYService();

            MTCSYT.SYS_Session session = (MTCSYT.SYS_Session)Session["SYS_Session"];
            int ma_dviqly = int.Parse(session.User.ma_dviqly + "");

            tlDonVi.DataSource = db.DM_CayDanhMuc_Sum(ma_dviqly, int.Parse(cmbThang.Value + ""), int.Parse(cmbNam.Value + ""), txtTimKiem.Text);
            tlDonVi.DataBind();

        }
        private void hidenConTrol()
        {
            txtB1D.Enabled = false;
            txtB3D.Enabled = false;
            txtB3KDD.Enabled = false;
            txtGB1KQDD.Enabled = false;

            txtGB2D.Enabled = false;
            txtGB2kDD.Enabled = false;
            txtGB3KDD.Enabled = false;
            txtGPDau.Enabled = false;

            txtGPKDD.Enabled = false;
            txtGQDau.Enabled = false;
            txtGQKDD.Enabled = false;
            txtNB1.Enabled = false;

            txtNB1KDD.Enabled = false;
            txtNB2.Enabled = false;
            txtNB2KDD.Enabled = false;
            txtNB3.Enabled = false;

            txtNP.Enabled = false;
            txtNPKDD.Enabled = false;
            txtNQ.Enabled = false;
            txtNQKDD.Enabled = false;


        }
        private void clearTextKDD()
        {
            txtB3KDD.Text = "0";
            txtGB1KQDD.Text = "0";

            txtGB2kDD.Text = "0";
            txtGB3KDD.Text = "0";

            txtGPKDD.Text = "0";
            txtGQKDD.Text = "0";

            txtNB1KDD.Text = "0";
            txtNB2KDD.Text = "0";

            txtNPKDD.Text = "0";
            txtNQKDD.Text = "0";
        }
        private void clearText()
        {
            txtB1D.Text = "0";
            txtB3D.Text = "0";

            txtGB2D.Text = "0";
            txtGPDau.Text = "0";

            txtGQDau.Text = "0";
            txtNB1.Text = "0";

            txtNB2.Text = "0";
            txtNB3.Text = "0";

            txtNP.Text = "0";
            txtNQ.Text = "0";
        }
        private void EnabledConTrol()
        {
            txtB1D.Enabled = true;
            txtB3D.Enabled = true;
            txtGB2D.Enabled = true;
            txtGPDau.Enabled = true;
            txtGQDau.Enabled = true;
            txtNB1.Enabled = true;
            txtNB2.Enabled = true;
            txtNB3.Enabled = true;
            txtNP.Enabled = true;
            txtNQ.Enabled = true;

            txtGQKDD.Enabled = true;
            txtGPKDD.Enabled = true;
            txtNB1KDD.Enabled = true;
            txtGB2kDD.Enabled = true;
            txtGB3KDD.Enabled = true;
            txtNB2KDD.Enabled = true;
            txtNQKDD.Enabled = true;
            txtNPKDD.Enabled = true;
            txtB3KDD.Enabled = true;
            txtGB1KQDD.Enabled = true;
        }
        private void _DataBind()
        {
            if (tlDonVi.FocusedNode != null)
            // if (int.Parse(tlDonVi.FocusedNode.Key) < 0)
            {
                EnabledConTrol();
            }
            else
            {
                hidenConTrol();
                clearTextKDD();
                clearText();
                return;
            }
            MTCSYT.SYS_Session session = (MTCSYT.SYS_Session)Session["SYS_Session"];
            int ma_dviqly = int.Parse(session.User.ma_dviqly + "");
            var lstHD = db.HD_GiaoNhanThangs.Where(x => x.IDCongTo == tlDonVi.FocusedNode.Key);
            foreach (var chitiet in lstHD)
            {
                var cto = db.DM_CongTos.SingleOrDefault(x => x.IDCongTo == int.Parse(chitiet.IDCongTo));
                if (cto.IsCToMotGia == true)
                {
                    ppCongTo1Gia.Visible = true;
                    if (chitiet.ISDoDem == 0)
                    {
                        txtNhanCongTo1Gia.Text = chitiet.Nhan_SL_CongTo1Gia + "";
                        txtGiaoCongTo1Gia.Text = chitiet.Giao_SL_CongTo1Gia + "";
                    }

                }
                else
                    ppCongTo1Gia.Visible = false;

                var diemdo = db.DM_DiemDos.SingleOrDefault(x => x.IDDiemDo == int.Parse(cto.IDDiemDo));
                //lbMaCT.Text = cto.MaCongTo;
                //lbTenCongTo.Text = cto.TenCongTo;
                //lbDiemDo.Text = diemdo.TenDiemDo;
                txtHeSoNhan.Text = cto.HeSoNhan + "";
                txtHSQD.Text = cto.HeSoQuyDoi + "";
                lbPhuongthuc.Text = db.DM_ChiNhanhs.SingleOrDefault(x => x.ID == int.Parse(cto.IDChiNhanh)).TenChiNhanh;
                //lbDiemDo.Text = db.DM_DiemDos.SingleOrDefault(x => x.IDDiemDo == int.Parse(cto.IDDiemDo)).TenDiemDo;
                //lbHinhThuc.Text = "Nhập dữ liệu";
                txtHeSoNhan.Text = cto.HeSoNhan + "";
                lbGhiChu.Text = "Đơn vị giao nhận xét: " + chitiet.GhiChuXacNhanGiao + " - Đơn vị nhận ghi chú: " + chitiet.GhiChuXacNhanNhan;


                if (chitiet.ISDoDem == 0)
                {
                    txtG_PDau.Text = "" + chitiet.Giao_P_Dau;
                    txtG_QDau.Text = "" + chitiet.Giao_Q_Dau;
                    txtG_B1.Text = "" + chitiet.Giao_Bieu1_Dau;
                    txtG_B2.Text = "" + chitiet.Giao_Bieu2_Dau;
                    txtG_B3.Text = "" + chitiet.Giao_Bieu3_Dau;
                    txtNPD.Text = "" + chitiet.Nhan_P_Dau;
                    txtNQD.Text = "" + chitiet.Nhan_Q_Dau;
                    txtNB1D.Text = "" + chitiet.Nhan_Bieu1_Dau;
                    txtNB2D.Text = "" + chitiet.Nhan_Bieu2_Dau;
                    txtNB3D.Text = "" + chitiet.Nhan_Bieu3_Dau;
                    //txtGhiChu.Text = chitietDD.DDGhiChu;

                    if (0 + chitiet.Nhan_P_Cuoi != 0 && chitiet.Nhan_P_Cuoi != null)
                        txtNP.Text = "" + chitiet.Nhan_P_Cuoi;


                    if (0 + chitiet.Giao_P_Cuoi != 0 && chitiet.Giao_P_Cuoi != null)
                        txtGPDau.Text = "" + chitiet.Giao_P_Cuoi;

                    if (0 + chitiet.Nhan_Q_Cuoi != 0 && chitiet.Nhan_Q_Cuoi != null)
                        txtNQ.Text = "" + chitiet.Nhan_Q_Cuoi;


                    if (0 + chitiet.Giao_Q_Cuoi != 0 && chitiet.Giao_Q_Cuoi != null)
                        txtGQDau.Text = "" + chitiet.Giao_Q_Cuoi;


                    if (0 + chitiet.Giao_Bieu1_Cuoi != 0 && chitiet.Giao_Bieu1_Cuoi != null)
                        txtB1D.Text = "" + chitiet.Giao_Bieu1_Cuoi;


                    if (0 + chitiet.Nhan_Bieu1_Cuoi != 0 && chitiet.Nhan_Bieu1_Cuoi != null)
                        txtNB1.Text = "" + chitiet.Nhan_Bieu1_Cuoi;


                    if (0 + chitiet.Giao_Bieu2_Cuoi != 0 && chitiet.Giao_Bieu2_Cuoi != null)
                        txtGB2D.Text = "" + chitiet.Giao_Bieu2_Cuoi;


                    if (0 + chitiet.Nhan_Bieu2_Cuoi != 0 && chitiet.Nhan_Bieu2_Cuoi != null)
                        txtNB2.Text = "" + chitiet.Nhan_Bieu2_Cuoi;


                    if (0 + chitiet.Giao_Bieu3_Cuoi != 0 && chitiet.Giao_Bieu3_Cuoi != null)
                        txtB3D.Text = "" + chitiet.Giao_Bieu3_Cuoi;

                    if (0 + chitiet.Nhan_Bieu3_Cuoi != 0 && chitiet.Nhan_Bieu3_Cuoi != null)
                        txtNB3.Text = "" + chitiet.Nhan_Bieu3_Cuoi;

                }
                else
                {
                    txtNQKDD.Text = "" + chitiet.Nhan_Q_SanLuong;
                    txtGQKDD.Text = "" + chitiet.Giao_Q_SanLuong;

                    txtGB1KQDD.Text = "" + chitiet.Giao_Bieu1_SanLuong;
                    txtNB1KDD.Text = "" + chitiet.Nhan_Bieu1_SanLuong;

                    txtGB2kDD.Text = "" + chitiet.Giao_Bieu2_SanLuong;
                    txtNB2KDD.Text = "" + chitiet.Nhan_Bieu2_SanLuong;

                    txtGB3KDD.Text = "" + chitiet.Giao_Bieu3_SanLuong;
                    txtB3KDD.Text = "" + chitiet.Nhan_Bieu3_SanLuong;

                    txtGPKDD.Text = "" + chitiet.Giao_P_SanLuong;
                    txtNPKDD.Text = "" + chitiet.Nhan_P_SanLuong;
                }
            }


            tinhSLg();
        }

        protected void btnCapNhat_Click1(object sender, EventArgs e)
        {
            MTCSYT.SYS_Session session = (MTCSYT.SYS_Session)Session["SYS_Session"];
            int ma_dviqly = int.Parse(session.User.ma_dviqly + "");

            //var cto = db.DM_CongTos.SingleOrDefault(x => x.IDCongTo == int.Parse(tlDonVi.FocusedNode.Key));

            //CBDN.HD_GiaoNhanThang chitiet = db.HD_GiaoNhanThangs.SingleOrDefault(x => x.ID == int.Parse(tlDonVi.FocusedNode.Key));
            var chitiet = db.HD_GiaoNhanThangs.SingleOrDefault(x => x.IDCongTo == tlDonVi.FocusedNode.Key && x.Thang == int.Parse(cmbThang.Value + "") && x.Nam == int.Parse(cmbNam.Value + "") && x.ISDoDem == 0);

            var congto = db.DM_CongTos.SingleOrDefault(x => x.IDCongTo == int.Parse(chitiet.IDCongTo));
            var diemdo = db.DM_DiemDos.SingleOrDefault(x => x.IDDiemDo == int.Parse(congto.IDDiemDo));
            var tram = db.DM_Trams.SingleOrDefault(x => x.IDTram == int.Parse(diemdo.IDTram));
            decimal G_PCuoi = 0, G_PKQDD = 0;
            if (txtGPDau.Text != "")
                G_PCuoi = decimal.Parse(txtGPDau.Text);
            if (txtGPKDD.Text != "")
                G_PKQDD = decimal.Parse(txtGPKDD.Text);
            decimal G_QCuoi = 0, G_QKQDD = 0;
            if (txtGQDau.Text != "")
                G_QCuoi = decimal.Parse(txtGQDau.Text);
            if (txtGQKDD.Text != "")
                G_QKQDD = decimal.Parse(txtGQKDD.Text);
            decimal G_B1Cuoi = 0, G_B1KQDD = 0;
            if (txtB1D.Text != "")
                G_B1Cuoi = decimal.Parse(txtB1D.Text);
            if (txtGB1KQDD.Text != "")
                G_B1KQDD = decimal.Parse(txtGB1KQDD.Text);
            decimal G_B2Cuoi = 0, G_B2KQDD = 0;
            if (txtGB2D.Text != "")
                G_B2Cuoi = decimal.Parse(txtGB2D.Text);
            if (txtGB1KQDD.Text != "")
                G_B2KQDD = decimal.Parse(txtGB2kDD.Text);
            decimal G_B3Cuoi = 0, G_B3KQDD = 0;
            if (txtB3D.Text != "")
                G_B3Cuoi = decimal.Parse(txtB3D.Text);
            if (txtGB3KDD.Text != "")
                G_B3KQDD = decimal.Parse(txtGB3KDD.Text);

            decimal N_PCuoi = 0, N_PKQDD = 0;
            if (txtNP.Text != "")
                N_PCuoi = decimal.Parse(txtNP.Text);
            if (txtNPKDD.Text != "")
                N_PKQDD = decimal.Parse(txtNPKDD.Text);
            decimal N_QCuoi = 0, N_QKQDD = 0;
            if (txtNQ.Text != "")
                N_QCuoi = decimal.Parse(txtNQ.Text);
            if (txtNPKDD.Text != "")
                N_QKQDD = decimal.Parse(txtNQKDD.Text);

            decimal N_B1Cuoi = 0, N_B1KQDD = 0;
            if (txtNB1.Text != "")
                N_B1Cuoi = decimal.Parse(txtNB1.Text);
            if (txtNB1KDD.Text != "")
                N_B1KQDD = decimal.Parse(txtNB1KDD.Text);
            decimal N_B2Cuoi = 0, N_B2KQDD = 0;
            if (txtNB2.Text != "")
                N_B2Cuoi = decimal.Parse(txtNB2.Text);
            if (txtNB2KDD.Text != "")
                N_B2KQDD = decimal.Parse(txtNB2KDD.Text);

            decimal N_B3Cuoi = 0, N_B3KQDD = 0;
            if (txtNB3.Text != "")
                N_B3Cuoi = decimal.Parse(txtNB3.Text);
            if (txtB3KDD.Text != "")
                N_B3KQDD = decimal.Parse(txtB3KDD.Text);
            if (chitiet != null)
            {
                if (congto.IsCToMotGia == true)
                {
                    if (txtNhanCongTo1Gia.Text != "")
                        chitiet.Nhan_SL_CongTo1Gia = decimal.Parse(txtNhanCongTo1Gia.Text);
                    else
                        chitiet.Nhan_SL_CongTo1Gia = 0;
                    if (txtGiaoCongTo1Gia.Text != "")
                        chitiet.Giao_SL_CongTo1Gia = decimal.Parse(txtGiaoCongTo1Gia.Text);
                    else
                        chitiet.Giao_SL_CongTo1Gia = 0;
                }
                chitiet.Giao_P_Dau = decimal.Parse("0" + txtG_PDau.Text);
                chitiet.Giao_Q_Dau = decimal.Parse("0" + txtG_QDau.Text);
                chitiet.Giao_Bieu1_Dau = decimal.Parse("0" + txtG_B1.Text);
                chitiet.Giao_Bieu2_Dau = decimal.Parse("0" + txtG_B2.Text);
                chitiet.Giao_Bieu3_Dau = decimal.Parse("0" + txtG_B3.Text);
                chitiet.Nhan_P_Dau = decimal.Parse("0" + txtNPD.Text);
                chitiet.Nhan_Q_Dau = decimal.Parse("0" + txtNQD.Text);
                chitiet.Nhan_Bieu1_Dau = decimal.Parse("0" + txtNB1D.Text);
                chitiet.Nhan_Bieu2_Dau = decimal.Parse("0" + txtNB2D.Text);
                chitiet.Nhan_Bieu3_Dau = decimal.Parse("0" + txtNB3D.Text);



                if (chitiet.ISDoDem == 0)
                {
                    chitiet.Nhan_P_Cuoi = Math.Round(N_PCuoi, 3);
                    chitiet.Giao_P_Cuoi = Math.Round(G_PCuoi, 3);  //decimal.Parse("0" + txtGPDau.Text);
                    if (G_PCuoi < decimal.Parse("0" + txtG_PDau.Text + ""))
                    {
                        chitiet.Giao_P_SanLuong = (soLon(txtG_PDau.Text) - decimal.Parse("0" + txtG_PDau.Text + "") + G_PCuoi) * (decimal)congto.HeSoNhan * (decimal)congto.HeSoQuyDoi;
                    }
                    else
                        chitiet.Giao_P_SanLuong = (G_PCuoi - decimal.Parse("0" + txtG_PDau.Text + "")) * (decimal)congto.HeSoNhan * (decimal)congto.HeSoQuyDoi;

                    if (N_PCuoi < decimal.Parse("0" + txtNPD.Text + ""))
                        chitiet.Nhan_P_SanLuong = (soLon(txtNPD.Text) - decimal.Parse("0" + txtNPD.Text + "") + N_PCuoi) * congto.HeSoNhan * congto.HeSoQuyDoi;
                    else
                        chitiet.Nhan_P_SanLuong = (N_PCuoi - decimal.Parse("0" + txtNPD.Text + "")) * congto.HeSoNhan * congto.HeSoQuyDoi;

                    chitiet.Nhan_Q_Cuoi = N_QCuoi;
                    chitiet.Giao_Q_Cuoi = G_QCuoi;

                    if (G_QCuoi < decimal.Parse("0" + txtG_QDau.Text + ""))
                        chitiet.Giao_Q_SanLuong = (soLon(txtG_QDau.Text) - decimal.Parse("0" + txtG_QDau.Text + "") + G_QCuoi) * congto.HeSoNhan * congto.HeSoQuyDoi;
                    else
                        chitiet.Giao_Q_SanLuong = (G_QCuoi - decimal.Parse("0" + txtG_QDau.Text + "")) * congto.HeSoNhan * congto.HeSoQuyDoi;

                    if (N_QCuoi < decimal.Parse("0" + txtNQD.Text + ""))
                        chitiet.Nhan_Q_SanLuong = (soLon(txtNQD.Text) - decimal.Parse("0" + txtNQD.Text + "") + N_QCuoi) * congto.HeSoNhan * congto.HeSoQuyDoi;
                    else
                        chitiet.Nhan_Q_SanLuong = (N_QCuoi - decimal.Parse("0" + txtNQD.Text + "")) * congto.HeSoNhan * congto.HeSoQuyDoi;

                    if (chitiet.Giao_P_SanLuong != null && chitiet.Giao_P_SanLuong != 0)
                    {
                        double a = (double)chitiet.Giao_Q_SanLuong;
                        double b = (double)chitiet.Giao_P_SanLuong;
                        chitiet.CosGiao = decimal.Parse("0" + Math.Round(Math.Cos(Math.Atan(a / b)), 3));

                    }
                    else
                        chitiet.CosGiao = 0;

                    if (chitiet.Nhan_P_SanLuong != 0 && chitiet.Nhan_P_SanLuong != null)
                    {
                        double nhana = (double)chitiet.Nhan_Q_SanLuong;
                        double nhanb = (double)chitiet.Nhan_P_SanLuong;
                        chitiet.CosNhan = decimal.Parse("0" + Math.Round(Math.Cos(Math.Atan(nhana / nhanb)), 3));
                    }
                    else
                        chitiet.CosNhan = 0;

                    chitiet.Giao_Bieu1_Cuoi = G_B1Cuoi;
                    chitiet.Nhan_Bieu1_Cuoi = N_B1Cuoi;
                    if (G_B1Cuoi < decimal.Parse("0" + txtG_B1.Text + ""))
                        chitiet.Giao_Bieu1_SanLuong = (soLon(txtG_B1.Text) - decimal.Parse("0" + txtG_B1.Text + "") + G_B1Cuoi) * congto.HeSoNhan * congto.HeSoQuyDoi;
                    else
                        chitiet.Giao_Bieu1_SanLuong = (G_B1Cuoi - decimal.Parse("0" + txtG_B1.Text + "")) * congto.HeSoNhan * congto.HeSoQuyDoi;

                    if (N_B1Cuoi < decimal.Parse("0" + txtNB1D.Text + ""))
                        chitiet.Nhan_Bieu1_SanLuong = (soLon(txtNB1D.Text) - decimal.Parse("0" + txtNB1D.Text + "") + N_B1Cuoi) * congto.HeSoNhan * congto.HeSoQuyDoi;
                    else
                        chitiet.Nhan_Bieu1_SanLuong = (N_B1Cuoi - decimal.Parse("0" + txtNB1D.Text + "")) * congto.HeSoNhan * congto.HeSoQuyDoi;

                    chitiet.Giao_Bieu2_Cuoi = G_B2Cuoi;
                    chitiet.Nhan_Bieu2_Cuoi = N_B2Cuoi;
                    if (G_B2Cuoi < decimal.Parse("0" + txtG_B2.Text + ""))
                        chitiet.Giao_Bieu2_SanLuong = (soLon(txtG_B2.Text) - decimal.Parse("0" + txtG_B2.Text + "") + G_B2Cuoi) * congto.HeSoNhan * congto.HeSoQuyDoi;
                    else
                        chitiet.Giao_Bieu2_SanLuong = (G_B2Cuoi - decimal.Parse("0" + txtG_B2.Text + "")) * congto.HeSoNhan * congto.HeSoQuyDoi;

                    if (N_B2Cuoi < decimal.Parse("0" + txtNB2D.Text + ""))
                        chitiet.Nhan_Bieu2_SanLuong = (soLon(txtNB2D.Text) - decimal.Parse("0" + txtNB2D.Text + "") + N_B2Cuoi) * congto.HeSoNhan * congto.HeSoQuyDoi;
                    else
                        chitiet.Nhan_Bieu2_SanLuong = (N_B2Cuoi - decimal.Parse("0" + txtNB2D.Text + "")) * congto.HeSoNhan * congto.HeSoQuyDoi;

                    chitiet.Giao_Bieu3_Cuoi = G_B3Cuoi;
                    chitiet.Nhan_Bieu3_Cuoi = N_B3Cuoi;
                    if (G_B3Cuoi < decimal.Parse("0" + txtG_B3.Text + ""))
                        chitiet.Giao_Bieu3_SanLuong = (soLon(txtG_B3.Text) - decimal.Parse("0" + txtG_B3.Text + "") + G_B3Cuoi) * congto.HeSoNhan * congto.HeSoQuyDoi;
                    else
                        chitiet.Giao_Bieu3_SanLuong = (G_B3Cuoi - decimal.Parse("0" + txtG_B3.Text + "")) * congto.HeSoNhan * congto.HeSoQuyDoi;
                    if (N_B3Cuoi < decimal.Parse("0" + txtNB3D.Text + ""))
                        chitiet.Nhan_Bieu3_SanLuong = (soLon(txtNB3D.Text) - decimal.Parse("0" + txtNB3D.Text + "") + N_B3Cuoi) * congto.HeSoNhan * congto.HeSoQuyDoi;
                    else
                        chitiet.Nhan_Bieu3_SanLuong = (N_B3Cuoi - decimal.Parse("0" + txtNB3D.Text + "")) * congto.HeSoNhan * congto.HeSoQuyDoi;
                    //chitiet.DonViTinh = int.Parse(cmbDonVi.Value + "");
                    chitiet.ISDoDem = 0;
                    chitiet.ISChot = true;
                    chitiet.XacNhanDVGiao = false;
                    chitiet.XacNhanDVNhan = false;
                    chitiet.ISNhanVien = false;
                    if (chitiet.GhiChuXacNhanGiao != "" && !(bool)chitiet.XacNhanDVGiao)
                        chitiet.GhiChuXacNhanGiao = "Đã hiệu chỉnh số liệu";
                    if (chitiet.GhiChuXacNhanNhan != "" && !(bool)chitiet.XacNhanDVNhan)
                        chitiet.GhiChuXacNhanNhan = "Đã hiệu chỉnh số liệu";

                    chitiet.LoaiNhap = 0;
                    db.SubmitChanges();

                }


            }
            var chitietDD = db.HD_GiaoNhanThangs.SingleOrDefault(x => x.IDCongTo == tlDonVi.FocusedNode.Key && x.Thang == int.Parse(cmbThang.Value + "") && x.Nam == int.Parse(cmbNam.Value + "") && x.ISDoDem == 1);
            if (chitietDD != null)
            {
                chitietDD.Giao_P_SanLuong = G_PKQDD;// decimal.Parse("0" + txtGPKDD.Text);
                chitietDD.Nhan_P_SanLuong = N_PKQDD;


                chitietDD.Giao_Q_SanLuong = G_QKQDD; //decimal.Parse("0" + txtGQKDD.Text);
                chitietDD.Nhan_Q_SanLuong = N_QKQDD;

                if (chitietDD.Giao_P_SanLuong != null && chitietDD.Giao_P_SanLuong != 0)
                {
                    double a = (double)chitietDD.Giao_Q_SanLuong;
                    double b = (double)chitietDD.Giao_P_SanLuong;
                    chitietDD.CosGiao = decimal.Parse("0" + Math.Round(Math.Cos(Math.Atan(a / b)), 3));

                }
                else
                    chitietDD.CosGiao = 0;

                if (chitietDD.Nhan_P_SanLuong != 0 && chitietDD.Nhan_P_SanLuong != null)
                {
                    double nhana = (double)chitietDD.Nhan_Q_SanLuong;
                    double nhanb = (double)chitietDD.Nhan_P_SanLuong;
                    chitietDD.CosNhan = decimal.Parse("0" + Math.Round(Math.Cos(Math.Atan(nhana / nhanb)), 3));
                }
                else
                    chitietDD.CosNhan = 0;


                chitietDD.Giao_Bieu1_SanLuong = G_B1KQDD;//decimal.Parse("0" + txtGB1KQDD.Text);
                chitietDD.Nhan_Bieu1_SanLuong = N_B1KQDD;


                chitietDD.Giao_Bieu2_SanLuong = G_B2KQDD;//decimal.Parse("0" + txtGB2kDD.Text);
                chitietDD.Nhan_Bieu2_SanLuong = N_B2KQDD;


                chitietDD.Giao_Bieu3_SanLuong = G_B3KQDD;//decimal.Parse("0" + txtGB3KDD.Text);
                chitietDD.Nhan_Bieu3_SanLuong = N_B3KQDD;

                chitietDD.ISDoDem = 1;
                chitietDD.ISChot = true;
                chitietDD.LoaiNhap = 0;
                db.SubmitChanges();

            }
            else
            {
                //if (decimal.Parse("0" + txtGPKDD.Text) + decimal.Parse("0" + txtGQKDD.Text) + decimal.Parse("0" + txtGB1KQDD.Text) + decimal.Parse("0" + txtGB2kDD.Text) + decimal.Parse("0" + txtGB3KDD.Text) != 0 ||
                //    N_PKQDD + N_QKQDD + N_B1KQDD + N_B2KQDD + N_B3KQDD != 0)
                if (G_PKQDD != 0 || G_QKQDD != 0 || G_B1KQDD != 0 || G_B2KQDD != 0 || G_B3KQDD != 0 || N_PKQDD != 0 || N_QKQDD != 0 || N_B1KQDD != 0 || N_B2KQDD != 0 || N_B3KQDD != 0)
                {

                    CBDN.HD_GiaoNhanThang giaonhan = new CBDN.HD_GiaoNhanThang();
                    giaonhan.IDCongTo = congto.IDCongTo + "";
                    giaonhan.IDChiNhanh = congto.IDChiNhanh;
                    giaonhan.IDDuongDay = congto.IDChiNhanh;
                    giaonhan.IDMaDViQly = int.Parse(session.User.ma_dviqly);
                    giaonhan.IDUser = session.User.IDUSER;
                    giaonhan.IDTram = congto.IDTram;
                    giaonhan.Nam = int.Parse("" + cmbNam.Value);
                    giaonhan.Thang = int.Parse("" + cmbThang.Value);

                    giaonhan.Nhan_P_Dau = 0;
                    giaonhan.Nhan_P_Cuoi = 0;

                    giaonhan.Giao_P_Dau = 0;
                    giaonhan.Giao_P_Cuoi = 0;

                    giaonhan.Giao_P_SanLuong = G_PKQDD;//decimal.Parse("0" + txtGPKDD.Text);
                    giaonhan.Nhan_P_SanLuong = N_PKQDD;

                    giaonhan.Nhan_Q_Dau = 0;
                    giaonhan.Nhan_Q_Cuoi = 0;
                    giaonhan.Giao_Q_Dau = 0;
                    giaonhan.Giao_Q_Cuoi = 0;

                    giaonhan.Giao_Q_SanLuong = G_QKQDD;//decimal.Parse("0" + txtGQKDD.Text);
                    giaonhan.Nhan_Q_SanLuong = N_QKQDD;

                    if (giaonhan.Giao_P_SanLuong != null && giaonhan.Giao_P_SanLuong != 0)
                    {
                        double a = (double)giaonhan.Giao_Q_SanLuong;
                        double b = (double)giaonhan.Giao_P_SanLuong;
                        giaonhan.CosGiao = decimal.Parse("0" + Math.Round(Math.Cos(Math.Atan(a / b)), 3));

                    }
                    else
                        giaonhan.CosGiao = 0;

                    if (giaonhan.Nhan_P_SanLuong != 0 && giaonhan.Nhan_P_SanLuong != null)
                    {
                        double nhana = (double)giaonhan.Nhan_Q_SanLuong;
                        double nhanb = (double)giaonhan.Nhan_P_SanLuong;
                        giaonhan.CosNhan = decimal.Parse("0" + Math.Round(Math.Cos(Math.Atan(nhana / nhanb)), 3));
                    }
                    else
                        giaonhan.CosNhan = 0;

                    giaonhan.Giao_Bieu1_Dau = 0;
                    giaonhan.Giao_Bieu1_Cuoi = 0;
                    giaonhan.Nhan_Bieu1_Dau = 0;
                    giaonhan.Nhan_Bieu1_Cuoi = 0;
                    giaonhan.Giao_Bieu1_SanLuong = G_B1KQDD;//decimal.Parse("0" + txtGB1KQDD.Text);
                    giaonhan.Nhan_Bieu1_SanLuong = N_B1KQDD;

                    giaonhan.Giao_Bieu2_Dau = 0;
                    giaonhan.Giao_Bieu2_Cuoi = 0;
                    giaonhan.Nhan_Bieu2_Dau = 0;
                    giaonhan.Nhan_Bieu2_Cuoi = 0;
                    giaonhan.Giao_Bieu2_SanLuong = G_B2KQDD;//decimal.Parse("0" + txtGB2kDD.Text);
                    giaonhan.Nhan_Bieu2_SanLuong = N_B2KQDD;

                    giaonhan.Giao_Bieu3_Dau = 0;
                    giaonhan.Giao_Bieu3_Cuoi = 0;
                    giaonhan.Nhan_Bieu3_Dau = 0;
                    giaonhan.Nhan_Bieu3_Cuoi = 0;
                    giaonhan.Giao_Bieu3_SanLuong = G_B3KQDD;//decimal.Parse("0" + txtGB3KDD.Text);
                    giaonhan.Nhan_Bieu3_SanLuong = N_B3KQDD;

                    giaonhan.ISDoDem = 1;
                    giaonhan.ISChot = true;
                    giaonhan.LoaiNhap = 0;
                    giaonhan.NgayNhap = DateTime.Now;
                    db.HD_GiaoNhanThangs.InsertOnSubmit(giaonhan);
                    db.SubmitChanges();
                }
            }
            loadDanhMuc();
            _DataBind();
            ScriptManager.RegisterStartupScript(Page, Page.GetType(), "", "alert('Cập nhật số liệu thành công');", true);
        }

        private decimal soLon(string chisocu)
        {
            string chuoi = "1";
            for (int i = 0; i < chisocu.Split('.')[0].ToString().Length; i++)
            { chuoi += "0"; }
            return decimal.Parse(chuoi);

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
        private void tinhSLg()
        {
            decimal G_PCuoi = 0, G_PKQDD = 0;
            if (txtGPDau.Text != "")
                G_PCuoi = decimal.Parse(txtGPDau.Text);
            if (txtGPKDD.Text != "")
                G_PKQDD = decimal.Parse(txtGPKDD.Text);

            if (G_PCuoi < decimal.Parse("0" + txtG_PDau.Text))
                txtSLgPGiao.Text = string.Format("{0:N0}", (Math.Round((soLon(txtG_PDau.Text) - decimal.Parse("0" + txtG_PDau.Text) + G_PCuoi) * decimal.Parse("0" + txtHeSoNhan.Text) * decimal.Parse("0" + txtHSQD.Text) + G_PKQDD, 0)));
            else
                txtSLgPGiao.Text = string.Format("{0:N0}", (Math.Round((G_PCuoi - decimal.Parse("0" + txtG_PDau.Text)) * decimal.Parse("0" + txtHeSoNhan.Text) * decimal.Parse("0" + txtHSQD.Text) + G_PKQDD, 0)));

            decimal G_QCuoi = 0, G_QKQDD = 0;
            if (txtGQDau.Text != "")
                G_QCuoi = decimal.Parse(txtGQDau.Text);
            if (txtGQKDD.Text != "")
                G_QKQDD = decimal.Parse(txtGQKDD.Text);
            if (G_QCuoi < decimal.Parse("0" + txtG_QDau.Text))
                txtSlQGiao.Text = string.Format("{0:N0}", (Math.Round((soLon(txtG_QDau.Text) - decimal.Parse("0" + txtG_QDau.Text) + G_QCuoi) * decimal.Parse("0" + txtHeSoNhan.Text) * decimal.Parse("0" + txtHSQD.Text) + G_QKQDD, 0)));
            else
                txtSlQGiao.Text = string.Format("{0:N0}", (Math.Round((G_QCuoi - decimal.Parse("0" + txtG_QDau.Text)) * decimal.Parse("0" + txtHeSoNhan.Text) * decimal.Parse("0" + txtHSQD.Text) + G_QKQDD, 0)));

            decimal G_B1Cuoi = 0, G_B1KQDD = 0;
            if (txtB1D.Text != "")
                G_B1Cuoi = decimal.Parse(txtB1D.Text);
            if (txtGB1KQDD.Text != "")
                G_B1KQDD = decimal.Parse(txtGB1KQDD.Text);
            if (G_B1Cuoi < decimal.Parse("0" + txtG_B1.Text))
                txtSlB1Giao.Text = string.Format("{0:N0}", (Math.Round((soLon(txtG_B1.Text) - decimal.Parse("0" + txtG_B1.Text) + G_B1Cuoi) * decimal.Parse("0" + txtHeSoNhan.Text) * decimal.Parse("0" + txtHSQD.Text) + G_B1KQDD, 0)));
            else
                txtSlB1Giao.Text = string.Format("{0:N0}", (Math.Round((G_B1Cuoi - decimal.Parse("0" + txtG_B1.Text)) * decimal.Parse("0" + txtHeSoNhan.Text) * decimal.Parse("0" + txtHSQD.Text) + G_B1KQDD, 0)));

            decimal G_B2Cuoi = 0, G_B2KQDD = 0;
            if (txtGB2D.Text != "")
                G_B2Cuoi = decimal.Parse(txtGB2D.Text);
            if (txtGB1KQDD.Text != "")
                G_B2KQDD = decimal.Parse(txtGB2kDD.Text);
            if (G_B2Cuoi < decimal.Parse("0" + txtG_B2.Text))
                txtSLgB2Giao.Text = string.Format("{0:N0}", (Math.Round((soLon(txtG_B2.Text) - decimal.Parse("0" + txtG_B2.Text) + G_B2Cuoi) * decimal.Parse("0" + txtHeSoNhan.Text) * decimal.Parse("0" + txtHSQD.Text) + G_B2KQDD, 0)));
            else
                txtSLgB2Giao.Text = string.Format("{0:N0}", (Math.Round((G_B2Cuoi - decimal.Parse("0" + txtG_B2.Text)) * decimal.Parse("0" + txtHeSoNhan.Text) * decimal.Parse("0" + txtHSQD.Text) + G_B2KQDD, 0)));

            decimal G_B3Cuoi = 0, G_B3KQDD = 0;
            if (txtB3D.Text != "")
                G_B3Cuoi = decimal.Parse(txtB3D.Text);
            if (txtGB3KDD.Text != "")
                G_B3KQDD = decimal.Parse(txtGB3KDD.Text);
            if (G_B3Cuoi < decimal.Parse("0" + txtG_B3.Text))
                txtSLgGiaoB3.Text = string.Format("{0:N0}", (Math.Round((soLon(txtG_B3.Text) - decimal.Parse("0" + txtG_B3.Text + "") + G_B3Cuoi) * decimal.Parse("0" + txtHeSoNhan.Text) * decimal.Parse("0" + txtHSQD.Text) + G_B3KQDD, 0)));
            else
                txtSLgGiaoB3.Text = string.Format("{0:N0}", (Math.Round((G_B3Cuoi - decimal.Parse("0" + txtG_B3.Text)) * decimal.Parse("0" + txtHeSoNhan.Text) * decimal.Parse("0" + txtHSQD.Text) + G_B3KQDD, 0)));

            decimal N_PCuoi = 0, N_PKQDD = 0;
            if (txtNP.Text != "")
                N_PCuoi = decimal.Parse(txtNP.Text);
            if (txtNPKDD.Text != "")
                N_PKQDD = decimal.Parse(txtNPKDD.Text);
            if (N_PCuoi < decimal.Parse("0" + txtNPD.Text))
                txtSlgPNhap.Text = string.Format("{0:N0}", (Math.Round((soLon(txtNPD.Text) - decimal.Parse("0" + txtNPD.Text + "") + N_PCuoi) * decimal.Parse("0" + txtHeSoNhan.Text) * decimal.Parse("0" + txtHSQD.Text) + N_PKQDD, 0)));
            else
                txtSlgPNhap.Text = string.Format("{0:N0}", (Math.Round((N_PCuoi - decimal.Parse("0" + txtNPD.Text)) * decimal.Parse("0" + txtHeSoNhan.Text) * decimal.Parse("0" + txtHSQD.Text) + N_PKQDD, 0)));

            decimal N_QCuoi = 0, N_QKQDD = 0;
            if (txtNQ.Text != "")
                N_QCuoi = decimal.Parse(txtNQ.Text);
            if (txtNPKDD.Text != "")
                N_QKQDD = decimal.Parse(txtNQKDD.Text);
            if (N_QCuoi < decimal.Parse("0" + txtNQD.Text))
                txtSlgQNhap.Text = string.Format("{0:N0}", (Math.Round((soLon(txtNQD.Text) - decimal.Parse("0" + txtNQD.Text + "") + N_QCuoi) * decimal.Parse("0" + txtHeSoNhan.Text) * decimal.Parse("0" + txtHSQD.Text) + N_QKQDD, 0)));
            else
                txtSlgQNhap.Text = string.Format("{0:N0}", (Math.Round((N_QCuoi - decimal.Parse("0" + txtNQD.Text)) * decimal.Parse("0" + txtHeSoNhan.Text) * decimal.Parse("0" + txtHSQD.Text) + N_QKQDD, 0)));

            decimal N_B1Cuoi = 0, N_B1KQDD = 0;
            if (txtNB1.Text != "")
                N_B1Cuoi = decimal.Parse(txtNB1.Text);
            if (txtNB1KDD.Text != "")
                N_B1KQDD = decimal.Parse(txtNB1KDD.Text);
            if (N_B1Cuoi < decimal.Parse("0" + txtNB1D.Text))
                txtSlgB1Nhap.Text = string.Format("{0:N0}", (Math.Round((soLon(txtNB1D.Text) - decimal.Parse("0" + txtNB1D.Text + "") + N_B1Cuoi) * decimal.Parse("0" + txtHeSoNhan.Text) * decimal.Parse("0" + txtHSQD.Text) + N_B1KQDD, 0)));
            else
                txtSlgB1Nhap.Text = string.Format("{0:N0}", (Math.Round((N_B1Cuoi - decimal.Parse("0" + txtNB1D.Text)) * decimal.Parse("0" + txtHeSoNhan.Text) * decimal.Parse("0" + txtHSQD.Text) + N_B1KQDD, 0)));

            decimal N_B2Cuoi = 0, N_B2KQDD = 0;
            if (txtNB2.Text != "")
                N_B2Cuoi = decimal.Parse(txtNB2.Text);
            if (txtNB2KDD.Text != "")
                N_B2KQDD = decimal.Parse(txtNB2KDD.Text);
            if (N_B2Cuoi < decimal.Parse("0" + txtNB2D.Text))
                txtSlgB2Nhap.Text = string.Format("{0:N0}", (Math.Round((soLon(txtNB2D.Text) - decimal.Parse("0" + txtNB2D.Text + "") + N_B2Cuoi) * decimal.Parse("0" + txtHeSoNhan.Text) * decimal.Parse("0" + txtHSQD.Text) + N_B2KQDD, 0)));
            else
                txtSlgB2Nhap.Text = string.Format("{0:N0}", (Math.Round((N_B2Cuoi - decimal.Parse("0" + txtNB2D.Text)) * decimal.Parse("0" + txtHeSoNhan.Text) * decimal.Parse("0" + txtHSQD.Text) + N_B2KQDD, 0)));


            decimal N_B3Cuoi = 0, N_B3KQDD = 0;
            if (txtNB3.Text != "")
                N_B3Cuoi = decimal.Parse(txtNB3.Text);
            if (txtB3KDD.Text != "")
                N_B3KQDD = decimal.Parse(txtB3KDD.Text);
            if (N_B3Cuoi < decimal.Parse("0" + txtNB3D.Text))
                txtSlgB3Nhap.Text = string.Format("{0:N0}", (Math.Round((soLon(txtNB3D.Text) - decimal.Parse("0" + txtNB3D.Text + "") + N_B3Cuoi) * decimal.Parse("0" + txtHeSoNhan.Text) * decimal.Parse("0" + txtHSQD.Text) + N_B3KQDD, 0)));
            else
                txtSlgB3Nhap.Text = string.Format("{0:N0}", (Math.Round((N_B3Cuoi - decimal.Parse("0" + txtNB3D.Text)) * decimal.Parse("0" + txtHeSoNhan.Text) * decimal.Parse("0" + txtHSQD.Text) + N_B3KQDD, 0)));


        }
        protected void btnTinhSanLuong_Click(object sender, EventArgs e)
        {
            tinhSLg();
        }

    }
}