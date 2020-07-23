using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using QLY_VTTB;
using Entity;
using DevExpress.Web.ASPxEditors;
using DevExpress.Web.ASPxGridView;
namespace MTCSYT
{
    public partial class DN_MoKhoaNgay : BasePage
    {
        CBDN.DB_CBDNDataContext db = new CBDN.DB_CBDNDataContext(new CBDN.ADOController().strcn());
        private const string funcid = "58";
        private SYS_Right rightOfUser = null;
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
                loadDSNgay();
            }
            loadKHChua();
            loadKHDaP();
        }

        private void loadDSNgay()
        {
            lbNgay.Text = "Ngày " + DateTime.Now.Day;
            lbThang.Text = "Tháng " + DateTime.Now.Month;
            lbNam.Text = "Năm " + DateTime.Now.Year;
        }

        protected void btnAdd_Click(object sender, EventArgs e)
        {

            List<Object> keyvalues = grdKHCHUA.GetSelectedFieldValues("IDMA_DVIQLY");
            foreach (object key in keyvalues)
            {
                CBDN.DN_MoKhoaDV cv = new CBDN.DN_MoKhoaDV();
                cv.ID_MADVIQLY = int.Parse(key.ToString());
                cv.Nam = DateTime.Now.Year;
                cv.Ngay = DateTime.Now.Day - 2;
                cv.NgayTao = DateTime.Now;
                cv.Thang = DateTime.Now.Month;
                var check = db.DN_MoKhoaDVs.SingleOrDefault(x => x.ID_MADVIQLY == int.Parse(key.ToString()) && x.Nam == DateTime.Now.Year && x.Thang == DateTime.Now.Month && x.Ngay == DateTime.Now.Day);
                if (check == null)
                {
                    db.DN_MoKhoaDVs.InsertOnSubmit(cv);
                    db.SubmitChanges();
                }

            }
            loadKHDaP();
            loadKHChua();
            grdKH.Selection.UnselectAll();
            grdKHCHUA.Selection.UnselectAll();
        }
        protected void ckChua_Init(object sender, EventArgs e)
        {
            ASPxCheckBox chk = sender as ASPxCheckBox;
            ASPxGridView grid = (chk.NamingContainer as GridViewHeaderTemplateContainer).Grid;
            chk.Checked = (grid.Selection.Count == grid.VisibleRowCount);
        }
        protected void ckDa_Init(object sender, EventArgs e)
        {
            ASPxCheckBox chk = sender as ASPxCheckBox;
            ASPxGridView grid = (chk.NamingContainer as GridViewHeaderTemplateContainer).Grid;
            chk.Checked = (grid.Selection.Count == grid.VisibleRowCount);
        }
        protected void btnRemove_Click(object sender, EventArgs e)
        {
            List<Object> keyvalues = grdKH.GetSelectedFieldValues("IDMA_DVIQLY");
            foreach (object key in keyvalues)
            {
                var cv = db.DN_MoKhoaDVs.SingleOrDefault(x => x.ID_MADVIQLY == int.Parse(key.ToString()) && x.Nam == DateTime.Now.Year && x.Ngay == DateTime.Now.Day && x.Thang == DateTime.Now.Month);
                db.DN_MoKhoaDVs.DeleteOnSubmit(cv);
                db.SubmitChanges();
            }
            loadKHDaP();
            loadKHChua();
            grdKH.Selection.UnselectAll();
            grdKHCHUA.Selection.UnselectAll();
        }

        private void loadKHDaP()
        {
            var ds = db.DN_MoKhoaDVs.Where(x => x.Ngay == DateTime.Now.Day - 2 && x.Thang == DateTime.Now.Month && x.Nam == DateTime.Now.Year)
                .Join(db.DM_DVQLies, m => m.ID_MADVIQLY, x => x.IDMA_DVIQLY, (m, x) => x)
                .ToList();
            //DataTable ds = db.SELEC_USER_TB(strMadviqly, int.Parse(txtthang.Text), int.Parse(txtnam.Text));
            if (ds.Count() > 0)
            {
                btnRemove.Enabled = true;
            }
            else btnRemove.Enabled = false;
            grdKH.DataSource = ds;
            grdKH.DataBind();

        }

        private void loadKHChua()
        {
            MTCSYT.SYS_Session session = (MTCSYT.SYS_Session)Session["SYS_Session"];
            string strMadviqly = session.User.ma_dviqly;

            var ds = db.DN_PCChuaMoKhoa(DateTime.Now.Month, DateTime.Now.Year, DateTime.Now.Day - 2).ToList();
            if (ds.Count() > 0)
            {
                btnAdd.Enabled = true;
            }
            else btnAdd.Enabled = false;
            grdKHCHUA.DataSource = ds;
            grdKHCHUA.DataBind();

        }

        protected void cmbRoles_SelectedIndexChanged(object sender, EventArgs e)
        {
            loadKHDaP();
            loadKHChua();
        }

        protected void btnSubmit_Click(object sender, EventArgs e)
        {

        }

        protected void btnOK_Click(object sender, EventArgs e)
        {

        }
    }
}