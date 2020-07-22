using System;
using System.Collections.Generic;
using SystemManageService;
using DevExpress.Web.ASPxTreeList;
using Entity;
using System.Linq;
using System.Web.UI;
using System.Data;
using DevExpress.Web;
namespace MTCSYT
{
    public partial class bd_ThongKeDiemDo : BasePage
    {
        CBDN.DB_CBDNDataContext db = new CBDN.DB_CBDNDataContext(new CBDN.ADOController().strcn());
        private const string funcid = "61";
        private SYS_Right rightOfUser = null;
        protected void Page_Load(object sender, EventArgs e)
        {
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
            if (!IsPostBack)
                loadDSNgay();
            //kiem tra chôt tháng

            LoadGrdGiao();



        }
        private void LoadGrdGiao()
        {
            MTCSYT.SYS_Session session = (MTCSYT.SYS_Session)Session["SYS_Session"];
            //var chotthang = db.HD_DonViChotThangs.Where(x => x.IDMADVIQLY == int.Parse(session.User.ma_dviqly) && x.Nam == int.Parse("" + cmbThang.Value) && x.Thang == int.Parse("" + cmbThang.Value));
            var chotthang = db.HD_DonViChotThangs.Where(x =>x.Nam == int.Parse("" + cmbThang.Value) && x.Thang == int.Parse("" + cmbThang.Value));
           
            if (chotthang.Count() > 0)
            {
                lbThongBao.Text = "Đơn vị đã chốt báo cáo tháng này";
            }
            else
            {
                int strMadviqly = int.Parse(session.User.ma_dviqly);
                var lstGiao = db.TK_NhapLieuTrongThang(strMadviqly, int.Parse(cmbThang.Value + ""), int.Parse(cmbNam.Value + ""));
                grdThongKe.DataSource = lstGiao;
                grdThongKe.DataBind();
            }

        }
        //private void LoadGrdNhan()
        //{
        //    MTCSYT.SYS_Session session = (MTCSYT.SYS_Session)Session["SYS_Session"];
        //    int strMadviqly = int.Parse(session.User.ma_dviqly);
        //    var lstGiao = db.BC_TongNhanSoDaXacNhan(strMadviqly, int.Parse(cmbThang.Value + ""), int.Parse(cmbNam.Value + ""));
        //    grdNhan.DataSource = lstGiao;
        //    grdNhan.DataBind();
        //}
        protected void cbAll_Init(object sender, EventArgs e)
        {

            ASPxCheckBox chk = sender as ASPxCheckBox;
            ASPxGridView grid = (chk.NamingContainer as GridViewHeaderTemplateContainer).Grid;
            chk.Checked = (grid.Selection.Count == grid.VisibleRowCount);
        }
        private void loadDSNgay()
        {
            //MTCSYT.SYS_Session session = (MTCSYT.SYS_Session)Session["SYS_Session"];
            //int strMadviqly = int.Parse(session.User.ma_dviqly);
            //var thangnammax = db.LayThangNamMax(strMadviqly).ToList();
            int thang = DateTime.Now.Month;
            int nam = DateTime.Now.Year;
            //if (thangnammax.Count > 0)
            //{
            //    foreach (var a in thangnammax)
            //    {
            //        thang = a.Thang;
            //        nam = a.Nam;
            //    }

            //}
            if (thang == 1)
            {
                cmbThang.Value = 12;
                cmbNam.Value = DateTime.Now.Year - 1;
            }
            else
            {
                cmbThang.Value = thang - 1;
                cmbNam.Value = DateTime.Now.Year;
            }

        }

        protected void grdGiao_Callback(object sender, EventArgs e)
        {

        }
        protected void btnDuyet_Click(object sender, EventArgs e)
        {

            try
            {
                int Nam = DateTime.Now.Year; int thang = DateTime.Now.Month - 1;
                int sosanh = DateTime.Now.Month - 1 - int.Parse(cmbThang.Value + "");
                if (DateTime.Now.Month == 1)
                {
                    Nam = DateTime.Now.Year - 1;
                    thang = 12;
                    sosanh = DateTime.Now.Month + 11 - int.Parse(cmbThang.Value + "");

                }
                if (DateTime.Now.Month == 2 && cmbThang.Value + "" != "1" && DateTime.Now.Year < int.Parse(cmbNam.Value + ""))
                {
                    sosanh = DateTime.Now.Month + 10 - int.Parse(cmbThang.Value + "");
                }

                DateTime dtkiemtra = new DateTime(Nam, thang, 28);

                DateTime ngaytra = new DateTime(int.Parse(cmbNam.Value.ToString()), int.Parse(cmbThang.Value.ToString()), DateTime.Now.Day);
                TimeSpan Time = ngaytra - dtkiemtra;
                DateTime dtHT = new DateTime(Nam, thang, DateTime.Now.Day);
                if (ngaytra > dtHT)
                {
                    ScriptManager.RegisterStartupScript(Page, Page.GetType(), "", "alert('Chưa đến 28 bạn chưa thể chốt số liệu!');", true);
                    return;
                }
                if (Time.Days < 0 && sosanh <= 0 && DateTime.Now.Year <= int.Parse(cmbNam.Value + ""))
                {
                    ScriptManager.RegisterStartupScript(Page, Page.GetType(), "", "alert('Chưa đến 28 bạn chưa thể chốt số liệu!');", true);
                    return;
                }
                //return;
                MTCSYT.SYS_Session session = (MTCSYT.SYS_Session)Session["SYS_Session"];
                int strMadviqly = int.Parse(session.User.ma_dviqly);
                int thangTT = 0, namTT = 0;
                if (int.Parse("" + cmbThang.Value) == 12)
                {
                    namTT = int.Parse("" + cmbNam.Value) + 1;
                    thangTT = 1;
                }
                else
                {
                    namTT = int.Parse("" + cmbNam.Value);
                    thangTT = int.Parse("" + cmbThang.Value) + 1;
                }
                db.ChotSoLieu(strMadviqly, int.Parse(cmbThang.Value + ""), int.Parse(cmbNam.Value + ""), thangTT, namTT);

                CBDN.HD_DonViChotThang chotthang = new CBDN.HD_DonViChotThang();
                chotthang.IDMADVIQLY = strMadviqly;
                chotthang.IDUser = session.User.IDUSER;
                chotthang.Nam = int.Parse("" + cmbNam.Value);
                chotthang.Thang = int.Parse("" + cmbThang.Value);
                chotthang.NgayChot = DateTime.Now;

                db.HD_DonViChotThangs.InsertOnSubmit(chotthang);
                db.SubmitChanges();

                LoadGrdGiao();
                ScriptManager.RegisterStartupScript(Page, Page.GetType(), "", "alert('Chốt số liệu thành công!');", true);

            }
            catch (Exception ex)
            {
                ScriptManager.RegisterStartupScript(Page, Page.GetType(), "", "alert('Lỗi duyệt chấm nợ " + ex.Message + "');", true);

            }
        }


        protected void grdGiao_CustomCallback(object sender, DevExpress.Web.ASPxGridViewCustomCallbackEventArgs e)
        {
            LoadGrdGiao();
        }
        protected void grdNhan_CustomCallback(object sender, DevExpress.Web.ASPxGridViewCustomCallbackEventArgs e)
        {
            LoadGrdGiao();
        }

        protected void grdGiao_CustomColumnDisplayText(object sender, ASPxGridViewColumnDisplayTextEventArgs e)
        {
            if (e.Column.Caption == "STT")
            {
                e.DisplayText = (e.VisibleRowIndex + 1).ToString();
            }
        }

        protected void grdNhan_CustomColumnDisplayText(object sender, ASPxGridViewColumnDisplayTextEventArgs e)
        {
            if (e.Column.Caption == "STT")
            {
                e.DisplayText = (e.VisibleRowIndex + 1).ToString();
            }
        }

        protected void cmbThang_SelectedIndexChanged(object sender, EventArgs e)
        {
            LoadGrdGiao();
        }

        protected void cmbNam_SelectedIndexChanged(object sender, EventArgs e)
        {
            LoadGrdGiao();
        }


    }
}