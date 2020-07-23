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
    public partial class bd_sl_khuVuc : BasePage
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
                if (Request.Cookies["IDUSER"].Value != "1")
                {
                    List<SYS_Right> right = session.User.Rights;
                    foreach (SYS_Right sysRight in right)
                    {
                        if (sysRight.FuncId == funcid)
                        {
                            rightOfUser = sysRight;
                            Session["Right"] = sysRight;
                            Session["UserId"] = session.User.IDUSER;
                            Session["FunctionId"] = sysRight.FuncId;
                            break;
                        }
                    }

                    if (rightOfUser == null)
                    {
                        Session["Status"] = "0";
                        Response.Redirect("~\\HeThong\\Default.aspx");

                    }
                }
            }
            Session["SYS_Session"] = session;
            #endregion

            if (!IsPostBack)
            {
                cmbThang.Value = DateTime.Now.Month;
                cmbNam.Value = DateTime.Now.Year;
            }
            loadDanhMuc();
            //if (!IsCallback)
            //    _DataBind();
        }
        private void loadDanhMuc()
        {
            DM_DVQLYService dm_dviSer = new DM_DVQLYService();

            MTCSYT.SYS_Session session = (MTCSYT.SYS_Session)Session["SYS_Session"];
            int ma_dviqly = int.Parse(session.User.ma_dviqly + "");

            tlDonVi.DataSource = db.DM_CayDanhMuc_KhuVuc(ma_dviqly);
            tlDonVi.DataBind();

        }
        private void hidenConTrol()
        {
            txtP2Dau.Enabled = false;
            txtP2Cuoi.Enabled = false;
            txtPDau.Enabled = false;
            txtPCuoi.Enabled = false;

            txtQ2Dau.Enabled = false;
            txtQ2Cuoi.Enabled = false;
            txtQDau.Enabled = false;
            txtQCuoi.Enabled = false;

            txtB1Dau.Enabled = false;
            txtB1Cuoi.Enabled = false;
            txtB1NDau.Enabled = false;
            txtB1NCuoi.Enabled = false;

            txtB2Dau.Enabled = false;
            txtB2Cuoi.Enabled = false;
            txtB2N_Dau.Enabled = false;
            txtB2N_Cuoi.Enabled = false;

            txtB3Dau.Enabled = false;
            txtB3Cuoi.Enabled = false;
            txtB3NDau.Enabled = false;
            txtB3NCuoi.Enabled = false;


        }
        private void setupControl()
        {
            txtP2Dau.Text = "0";
            txtP2Cuoi.Text = "0";
            txtPDau.Text = "0";
            txtPCuoi.Text = "0";

            txtQ2Dau.Text = "0";
            txtQ2Cuoi.Text = "0";
            txtQDau.Text = "0";
            txtQCuoi.Text = "0";

            txtB1Dau.Text = "0";
            txtB1Cuoi.Text = "0";
            txtB1NDau.Text = "0";
            txtB1NCuoi.Text = "0";

            txtB2Dau.Text = "0";
            txtB2Cuoi.Text = "0";
            txtB2N_Dau.Text = "0";
            txtB2N_Cuoi.Text = "0";

            txtB3Dau.Text = "0";
            txtB3Cuoi.Text = "0";
            txtB3NDau.Text = "0";
            txtB3NCuoi.Text = "0";

        }
        private void EnabledConTrol()
        {
            txtP2Dau.Enabled = true;
            txtP2Cuoi.Enabled = true;
            txtPDau.Enabled = true;
            txtPCuoi.Enabled = true;

            txtQ2Dau.Enabled = true;
            txtQ2Cuoi.Enabled = true;
            txtQDau.Enabled = true;
            txtQCuoi.Enabled = true;

            txtB1Dau.Enabled = true;
            txtB1Cuoi.Enabled = true;
            txtB1NDau.Enabled = true;
            txtB1NCuoi.Enabled = true;

            txtB2Dau.Enabled = true;
            txtB2Cuoi.Enabled = true;
            txtB2N_Dau.Enabled = true;
            txtB2N_Cuoi.Enabled = true;

            txtB3Dau.Enabled = true;
            txtB3Cuoi.Enabled = true;
            txtB3NDau.Enabled = true;
            txtB3NCuoi.Enabled = true;
        }
        private void _DataBind()
        {
            if (int.Parse(tlDonVi.FocusedNode.Key) - 3000 > 0)
            {
                EnabledConTrol();
            }
            else
            {
                setupControl();
                hidenConTrol();
                return;
            }
            MTCSYT.SYS_Session session = (MTCSYT.SYS_Session)Session["SYS_Session"];
            int ma_dviqly = int.Parse(session.User.ma_dviqly + "");
            var cto = db.DM_CongTos.SingleOrDefault(x => x.IDCongTo == int.Parse(tlDonVi.FocusedNode.Key));
            var chitiet = db.HD_GiaoNhanThangs.SingleOrDefault(x => x.IDCongTo ==cto.MaCongTo && x.IDMaDViQly == ma_dviqly && x.Thang == int.Parse("" + cmbThang.Value) && x.Nam == int.Parse("" + cmbNam.Value));
            if (chitiet == null)
            {
                setupControl();
                return;
            }
            txtP2Dau.Text = chitiet.Nhan_P_Dau + "";
            txtP2Cuoi.Text = chitiet.Nhan_P_Cuoi + "";
            txtPDau.Text = chitiet.Giao_P_Dau + "";
            txtPCuoi.Text = chitiet.Giao_P_Cuoi + "";

            txtQ2Dau.Text = chitiet.Nhan_Q_Dau + "";
            txtQ2Cuoi.Text = chitiet.Nhan_Q_Cuoi + "";
            txtQDau.Text = chitiet.Giao_Q_Dau + "";
            txtQCuoi.Text = chitiet.Giao_Q_Cuoi + "";

            txtB1Dau.Text = chitiet.Giao_Bieu1_Dau + "";
            txtB1Cuoi.Text = chitiet.Giao_Bieu1_Cuoi + "";
            txtB1NDau.Text = chitiet.Nhan_Bieu1_Dau + "";
            txtB1NCuoi.Text = chitiet.Nhan_Bieu1_Cuoi + "";

            txtB2Dau.Text = chitiet.Giao_Bieu2_Dau + "";
            txtB2Cuoi.Text = chitiet.Giao_Bieu2_Cuoi + "";
            txtB2N_Dau.Text = chitiet.Nhan_Bieu2_Dau + "";
            txtB2N_Cuoi.Text = chitiet.Nhan_Bieu2_Cuoi + "";

            txtB3Dau.Text = chitiet.Giao_Bieu3_Dau + "";
            txtB3Cuoi.Text = chitiet.Giao_Bieu3_Cuoi + "";
            txtB3NDau.Text = chitiet.Nhan_Bieu3_Dau + "";
            txtB3NCuoi.Text = chitiet.Nhan_Bieu3_Cuoi + "";
        }


        protected void btnCapNhat_Click1(object sender, EventArgs e)
        {
            MTCSYT.SYS_Session session = (MTCSYT.SYS_Session)Session["SYS_Session"];
            int ma_dviqly = int.Parse(session.User.ma_dviqly + "");
            var congto = db.DM_CongTos.SingleOrDefault(x => x.IDCongTo == int.Parse(tlDonVi.FocusedNode.Key) );
            var chitiet = db.HD_GiaoNhanThangs.SingleOrDefault(x => x.IDCongTo == congto.MaCongTo && x.IDMaDViQly == ma_dviqly && x.Thang == int.Parse("" + cmbThang.Value) && x.Nam == int.Parse("" + cmbNam.Value));

            
            var diemdo = db.DM_DiemDos.SingleOrDefault(x => x.IDDiemDo == congto.IDDiemDo);
            var tram = db.DM_Trams.SingleOrDefault(x => x.IDTram == diemdo.IDTram);
            if (chitiet == null)
            {
                CBDN.HD_GiaoNhanThang giaonhan = new CBDN.HD_GiaoNhanThang();
                giaonhan.IDCongTo = congto.MaCongTo;
                giaonhan.IDChiNhanh = int.Parse("0" + tram.IDChiNhanh);
                giaonhan.IDMaDViQly = ma_dviqly;
                giaonhan.IDUser = session.User.IDUSER;
                giaonhan.Nam = int.Parse("0" + cmbNam.Value);
                giaonhan.Thang = int.Parse("0" + cmbThang.Value);
                giaonhan.IDTram = int.Parse("0" + tram.IDTram);

                giaonhan.Nhan_P_Dau = decimal.Parse(txtP2Dau.Text);
                giaonhan.Nhan_P_Cuoi = decimal.Parse(txtP2Cuoi.Text);
                giaonhan.Giao_P_Dau = decimal.Parse(txtPDau.Text);
                giaonhan.Giao_P_Cuoi = decimal.Parse(txtPCuoi.Text);
                giaonhan.Giao_P_SanLuong = (decimal.Parse(txtP2Cuoi.Text) - decimal.Parse(txtP2Dau.Text)) * congto.HeSoNhan;
                giaonhan.Nhan_P_SanLuong = (decimal.Parse(txtPCuoi.Text) - decimal.Parse(txtPDau.Text)) * congto.HeSoNhan;

                giaonhan.Nhan_Q_Dau = decimal.Parse(txtQ2Dau.Text);
                giaonhan.Nhan_Q_Cuoi = decimal.Parse(txtQ2Cuoi.Text);
                giaonhan.Giao_Q_Dau = decimal.Parse(txtQDau.Text);
                giaonhan.Giao_Q_Cuoi = decimal.Parse(txtQCuoi.Text);
                giaonhan.Giao_Q_SanLuong = (decimal.Parse(txtQ2Cuoi.Text) - decimal.Parse(txtQ2Dau.Text)) * congto.HeSoNhan;
                giaonhan.Nhan_Q_SanLuong = (decimal.Parse(txtQCuoi.Text) - decimal.Parse(txtQDau.Text)) * congto.HeSoNhan;

                if (giaonhan.Giao_P_SanLuong != null && giaonhan.Giao_P_SanLuong != 0)
                {
                    double a = (double)giaonhan.Giao_Q_SanLuong;
                    double b = (double)giaonhan.Giao_P_SanLuong;
                    giaonhan.CosGiao = decimal.Parse("0" + Math.Cos(Math.Atan(a / b)));

                }
                else
                    giaonhan.CosGiao = 0;

                if (giaonhan.Nhan_P_SanLuong != 0 && giaonhan.Nhan_P_SanLuong != null)
                {
                    double nhana = (double)giaonhan.Nhan_Q_SanLuong;
                    double nhanb = (double)giaonhan.Nhan_P_SanLuong;
                    giaonhan.CosNhan = decimal.Parse("0" + Math.Cos(Math.Atan(nhana / nhanb)));
                }
                else
                    giaonhan.CosNhan = 0;


                giaonhan.Giao_Bieu1_Dau = decimal.Parse(txtB1Dau.Text);
                giaonhan.Giao_Bieu1_Cuoi = decimal.Parse(txtB1Cuoi.Text);
                giaonhan.Nhan_Bieu1_Dau = decimal.Parse(txtB1NDau.Text);
                giaonhan.Nhan_Bieu1_Cuoi = decimal.Parse(txtB1NCuoi.Text);
                giaonhan.Giao_Bieu1_SanLuong = (decimal.Parse(txtB1Cuoi.Text) - decimal.Parse(txtB1Dau.Text)) * congto.HeSoNhan;
                giaonhan.Nhan_Bieu1_SanLuong = (decimal.Parse(txtB1NCuoi.Text) - decimal.Parse(txtB1NDau.Text)) * congto.HeSoNhan;

                giaonhan.Giao_Bieu2_Dau = decimal.Parse(txtB2Dau.Text);
                giaonhan.Giao_Bieu2_Cuoi = decimal.Parse(txtB2Cuoi.Text);
                giaonhan.Nhan_Bieu2_Dau = decimal.Parse(txtB2N_Dau.Text);
                giaonhan.Nhan_Bieu2_Cuoi = decimal.Parse(txtB2N_Cuoi.Text);
                giaonhan.Giao_Bieu2_SanLuong = (decimal.Parse(txtB2Cuoi.Text) - decimal.Parse(txtB2Dau.Text)) * congto.HeSoNhan;
                giaonhan.Nhan_Bieu2_SanLuong = (decimal.Parse(txtB2N_Cuoi.Text) - decimal.Parse(txtB2N_Dau.Text)) * congto.HeSoNhan;

                giaonhan.Giao_Bieu3_Dau = decimal.Parse(txtB3Dau.Text);
                giaonhan.Giao_Bieu3_Cuoi = decimal.Parse(txtB3Cuoi.Text);
                giaonhan.Nhan_Bieu3_Dau = decimal.Parse(txtB3NDau.Text);
                giaonhan.Nhan_Bieu3_Cuoi = decimal.Parse(txtB3NCuoi.Text);
                giaonhan.Giao_Bieu3_SanLuong = (decimal.Parse(txtB3Cuoi.Text) - decimal.Parse(txtB2Dau.Text)) * congto.HeSoNhan;
                giaonhan.Nhan_Bieu3_SanLuong = (decimal.Parse(txtB3Cuoi.Text) - decimal.Parse(txtB3NDau.Text)) * congto.HeSoNhan;
                giaonhan.NgayNhap = DateTime.Now;
                db.HD_GiaoNhanThangs.InsertOnSubmit(giaonhan);
                db.SubmitChanges();
            }
            else
            {
                chitiet.Nhan_P_Dau = decimal.Parse(txtP2Dau.Text);
                chitiet.Nhan_P_Cuoi = decimal.Parse(txtP2Cuoi.Text);
                chitiet.Giao_P_Dau = decimal.Parse(txtPDau.Text);
                chitiet.Giao_P_Cuoi = decimal.Parse(txtPCuoi.Text);
                chitiet.Giao_P_SanLuong = (decimal.Parse(txtP2Cuoi.Text) - decimal.Parse(txtP2Dau.Text)) * congto.HeSoNhan;
                chitiet.Nhan_P_SanLuong = (decimal.Parse(txtPCuoi.Text) - decimal.Parse(txtPDau.Text)) * congto.HeSoNhan;

                chitiet.Nhan_Q_Dau = decimal.Parse(txtQ2Dau.Text);
                chitiet.Nhan_Q_Cuoi = decimal.Parse(txtQ2Cuoi.Text);
                chitiet.Giao_Q_Dau = decimal.Parse(txtQDau.Text);
                chitiet.Giao_Q_Cuoi = decimal.Parse(txtQCuoi.Text);
                chitiet.Giao_Q_SanLuong = (decimal.Parse(txtQ2Cuoi.Text) - decimal.Parse(txtQ2Dau.Text)) * congto.HeSoNhan;
                chitiet.Nhan_Q_SanLuong = (decimal.Parse(txtQCuoi.Text) - decimal.Parse(txtQDau.Text)) * congto.HeSoNhan;

                if (chitiet.Giao_P_SanLuong != null && chitiet.Giao_P_SanLuong != 0)
                {
                    double a = (double)chitiet.Giao_Q_SanLuong;
                    double b = (double)chitiet.Giao_P_SanLuong;
                    chitiet.CosGiao = decimal.Parse("0" + Math.Cos(Math.Atan(a / b)));

                }
                else
                    chitiet.CosGiao = 0;

                if (chitiet.Nhan_P_SanLuong != 0 && chitiet.Nhan_P_SanLuong != null)
                {
                    double nhana = (double)chitiet.Nhan_Q_SanLuong;
                    double nhanb = (double)chitiet.Nhan_P_SanLuong;
                    chitiet.CosNhan = decimal.Parse("0" + Math.Cos(Math.Atan(nhana / nhanb)));
                }
                else
                    chitiet.CosNhan = 0;

                chitiet.Giao_Bieu1_Dau = decimal.Parse(txtB1Dau.Text);
                chitiet.Giao_Bieu1_Cuoi = decimal.Parse(txtB1Cuoi.Text);
                chitiet.Nhan_Bieu1_Dau = decimal.Parse(txtB1NDau.Text);
                chitiet.Nhan_Bieu1_Cuoi = decimal.Parse(txtB1NCuoi.Text);
                chitiet.Giao_Bieu1_SanLuong = (decimal.Parse(txtB1Cuoi.Text) - decimal.Parse(txtB1Dau.Text)) * congto.HeSoNhan;
                chitiet.Nhan_Bieu1_SanLuong = (decimal.Parse(txtB1NCuoi.Text) - decimal.Parse(txtB1NDau.Text)) * congto.HeSoNhan;

                chitiet.Giao_Bieu2_Dau = decimal.Parse(txtB2Dau.Text);
                chitiet.Giao_Bieu2_Cuoi = decimal.Parse(txtB2Cuoi.Text);
                chitiet.Nhan_Bieu2_Dau = decimal.Parse(txtB2N_Dau.Text);
                chitiet.Nhan_Bieu2_Cuoi = decimal.Parse(txtB2N_Cuoi.Text);
                chitiet.Giao_Bieu2_SanLuong = (decimal.Parse(txtB2Cuoi.Text) - decimal.Parse(txtB2Dau.Text)) * congto.HeSoNhan;
                chitiet.Nhan_Bieu2_SanLuong = (decimal.Parse(txtB2N_Cuoi.Text) - decimal.Parse(txtB2N_Dau.Text)) * congto.HeSoNhan;

                chitiet.Giao_Bieu3_Dau = decimal.Parse(txtB3Dau.Text);
                chitiet.Giao_Bieu3_Cuoi = decimal.Parse(txtB3Cuoi.Text);
                chitiet.Nhan_Bieu3_Dau = decimal.Parse(txtB3NDau.Text);
                chitiet.Nhan_Bieu3_Cuoi = decimal.Parse(txtB3NCuoi.Text);
                chitiet.Giao_Bieu3_SanLuong = (decimal.Parse(txtB3Cuoi.Text) - decimal.Parse(txtB2Dau.Text)) * congto.HeSoNhan;
                chitiet.Nhan_Bieu3_SanLuong = (decimal.Parse(txtB3Cuoi.Text) - decimal.Parse(txtB3NDau.Text)) * congto.HeSoNhan;
                db.SubmitChanges();
            }
            ScriptManager.RegisterStartupScript(Page, Page.GetType(), "", "alert('Cập nhật số liệu thành công');", true);
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

    }
}