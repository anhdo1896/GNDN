using System;
using System.Collections.Generic;
using DevExpress.Web;
using Entity;
using SystemManageService;
using System.Web.UI;
using System.Linq;
using System.Data;
using MTCSYT;
using System.IO;
using System.Web.UI.HtmlControls;

namespace CBDN.TonThatKyThuat
{
    public partial class DM_TTKinhDoanh_TRAM : BasePage
    {
        DataAccess.clTTTT db = new DataAccess.clTTTT();
        // CBDN.DB_CBDNDataContext db = new CBDN.DB_CBDNDataContext(new CBDN.ADOController().strcn());
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
                TyLEBT();
                TyLEBTram();
            }

                _DataBind();


        }

        private void _DataBind()
        {
            MTCSYT.SYS_Session session = (MTCSYT.SYS_Session)Session["SYS_Session"];
            string madvi = session.User.ma_dviqlyDN;
            var dt = db.SELECT_CHECK_TTTT_TTKD_TLTTTRAM(madvi);
            grdDVT.DataSource = dt;
            grdDVT.DataBind();    
        }

        private void TyLEBT()
        {
            MTCSYT.SYS_Session session = (MTCSYT.SYS_Session)Session["SYS_Session"];
            string madvi = session.User.ma_dviqlyDN;
            var kh = db.SELECT_TTTT_PT_BT_KHANG(madvi,0);
            int t = kh.Rows.Count;
            if (t != 0)
            {
                string tlbt = kh.Rows[0]["PT_BT"] + "";
                txtTyLeBT.Text = tlbt;
            }
            else
            {
                txtTyLeBT.Text = "";
            }
        }
        private void TyLEBTram()
        {
            MTCSYT.SYS_Session session = (MTCSYT.SYS_Session)Session["SYS_Session"];
            string madvi = session.User.ma_dviqlyDN;
            var kh = db.SELECT_TTTT_PT_BT_KHANG(madvi, 1);
            int t = kh.Rows.Count;
            if (t != 0)
            {
                string tlbt = kh.Rows[0]["PT_BT"] + "";
                txtTyLeBTram.Text = tlbt;
            }
            else
            {
                txtTyLeBTram.Text = "";
            }
        }
        protected void grdDVT_CustomColumnDisplayText(object sender, ASPxGridViewColumnDisplayTextEventArgs e)
        {
           
        }
        




        protected void grdDVT_CellEditorInitialize(object sender, ASPxGridViewEditorEventArgs e)
        {
            e.Column.ToString();
            if (e.Column.FieldName == "MaChiNhanh")
                e.Editor.Focus();
        }

        protected void btnThem_Click(object sender, EventArgs e)
        {
            SYS_Session session = (SYS_Session)Session["SYS_Session"];
            txtMA_DVIQLY.Text = session.User.ma_dviqlyDN;
            pcAddRoles.ShowOnPageLoad = true;
        }

        protected void grdDVT_StartRowEditing(object sender, DevExpress.Web.Data.ASPxStartRowEditingEventArgs e)
        {
            (sender as ASPxGridView).GetRowValuesByKeyValue(e.EditingKeyValue);

        }

        protected void grdDVT_CellEditorInitialize1(object sender, ASPxGridViewEditorEventArgs e)
        {

        }



        protected void btnCapNhat_Click(object sender, EventArgs e)
        {
            DM_DVQLYService dm_dviSer = new DM_DVQLYService();
            SYS_Session session = (SYS_Session)Session["SYS_Session"];
            string tyle = txtTYLETT.Text;
            float tl = float.Parse(tyle.ToString().Replace(".", ","));
                db.INSERT_TTTT_TTKD_TLTTTRAM(txtMA_DVIQLY.Text, tl);
            pcAddRoles.ShowOnPageLoad = false;
            _DataBind();
        }

        protected void btnDong_Click(object sender, EventArgs e)
        {
            pcAddRoles.ShowOnPageLoad = false;
        }

        protected void cmbPhongBan_SelectedIndexChanged(object sender, EventArgs e)
        {
            _DataBind();
        }

        protected void grdDVT_HtmlCommandCellPrepared(object sender, ASPxGridViewTableCommandCellEventArgs e)
        {

        }
        protected void grdDVT_RowDeleting(object sender, DevExpress.Web.Data.ASPxDataDeletingEventArgs e)
        {
            try
            {
                SYS_Session session = (SYS_Session)Session["SYS_Session"];
                var HoatDong = (DataRowView)grdDVT.GetRow(grdDVT.FocusedRowIndex);
                int id = int.Parse(HoatDong["ID"] + "");
                db.DELETE_CHECK_TTTT_TTKD_TLTTTRAM(id);


                _DataBind();
                ScriptManager.RegisterStartupScript(Page, Page.GetType(), "", "alert('Xoá tỷ lệ thành công');", true);
            }
            catch (Exception ex)
            { }
            finally
            {
                e.Cancel = true;
            }
        }

        protected void btnSua_Click(object sender, EventArgs e)
        {
            pcAddRoles.ShowOnPageLoad = true;
            Session["Add"] = 0;
            SYS_Session session = (SYS_Session)Session["SYS_Session"];
            var qtCT = (DataRowView)grdDVT.GetRow(grdDVT.FocusedRowIndex);
            txtMA_DVIQLY.Text = qtCT["MA_DVIQLY"] + "";
            txtTYLETT.Text = qtCT["TYLETT"] + "";
            txtMA_DVIQLY.Enabled = false;
        }

        protected void TextboxA_TextChanged(object sender, EventArgs e)
        {
            MTCSYT.SYS_Session session = (MTCSYT.SYS_Session)Session["SYS_Session"];
            string madvi = session.User.ma_dviqlyDN;
            var kh = db.SELECT_TTTT_PT_BT_KHANG(madvi,0);
            int t = kh.Rows.Count;
            string btstr = txtTyLeBT.Text + "";
            if (btstr != "")
            {
                float bt = float.Parse(btstr);

                if (t == 0)
                {
                    db.INSERT_TTTT_PT_BT_KHANG(madvi, bt,0);
                }
                else
                {
                    db.UPDATE_TTTT_PT_BT_KHANG(madvi, bt,0);
                }
            }

        }
        protected void TextboxB_TextChanged(object sender, EventArgs e)
        {
            MTCSYT.SYS_Session session = (MTCSYT.SYS_Session)Session["SYS_Session"];
            string madvi = session.User.ma_dviqlyDN;
            var kh = db.SELECT_TTTT_PT_BT_KHANG(madvi, 1);
            int t = kh.Rows.Count;
            string btstr = txtTyLeBTram.Text + "";
            if (btstr != "")
            {
                float bt = float.Parse(btstr);

                if (t == 0)
                {
                    db.INSERT_TTTT_PT_BT_KHANG(madvi, bt, 1);
                }
                else
                {
                    db.UPDATE_TTTT_PT_BT_KHANG(madvi, bt, 1);
                }
            }

        }
    }
}