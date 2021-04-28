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
            Session["SYS_Session"] = session;
            #endregion
            if (!IsPostBack)
            {
                TyLEBT();
                TyLEBTram();
                SLTram();
                _DataBind();
            }

        }

        private void _DataBind()
        {
            MTCSYT.SYS_Session session = (MTCSYT.SYS_Session)Session["SYS_Session"];
            string madvi = session.User.ma_dviqlyDN;
            var kh = db.SELECT_TTTT_PT_BT_KHANG(madvi,2);
            int t = kh.Rows.Count;
            if (t != 0)
            {
                string tlbt = kh.Rows[0]["PT_BT"] + "";
                txtTyLeTT.Text = tlbt;
            }
            else
            {
                txtTyLeTT.Text = "";
            }
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

        private void SLTram()
        {
            MTCSYT.SYS_Session session = (MTCSYT.SYS_Session)Session["SYS_Session"];
            string madvi = session.User.ma_dviqlyDN;
            var kh = db.SELECT_TTTT_PT_BT_KHANG(madvi, 3);
            int t = kh.Rows.Count;
            if (t != 0)
            {
                string tlbt = kh.Rows[0]["PT_BT"] + "";
                txtSL.Text = tlbt;
            }
            else
            {
                txtSL.Text = "";
            }
        }

        protected void btnLuc_Click(object sender, EventArgs e)
        {
            MTCSYT.SYS_Session session = (MTCSYT.SYS_Session)Session["SYS_Session"];
            string madvi = session.User.ma_dviqlyDN;
            var kh0 = db.SELECT_TTTT_PT_BT_KHANG(madvi, 0);
            int t0 = kh0.Rows.Count;
            string btstr0 = (txtTyLeBT.Text + "").Replace(".", ",");
            if (btstr0 != "")
            {
                float bt = float.Parse(btstr0);

                if (t0 == 0)
                {
                    db.INSERT_TTTT_PT_BT_KHANG(madvi, bt, 0);
                }
                else
                {
                    db.UPDATE_TTTT_PT_BT_KHANG(madvi, bt, 0);
                }
            }
            var kh1 = db.SELECT_TTTT_PT_BT_KHANG(madvi, 1);
            int t1 = kh1.Rows.Count;
            string btstr1 = (txtTyLeBTram.Text + "").Replace(".", ",");
            if (btstr1 != "")
            {
                float bt = float.Parse(btstr1);

                if (t1 == 0)
                {
                    db.INSERT_TTTT_PT_BT_KHANG(madvi, bt, 1);
                }
                else
                {
                    db.UPDATE_TTTT_PT_BT_KHANG(madvi, bt, 1);
                }
            }
            var kh2 = db.SELECT_TTTT_PT_BT_KHANG(madvi, 2);
            int t2 = kh2.Rows.Count;
            string btstr2 = (txtTyLeTT.Text + "").Replace(".", ",");
            if (btstr2 != "")
            {
                float bt = float.Parse(btstr2);

                if (t2 == 0)
                {
                    db.INSERT_TTTT_PT_BT_KHANG(madvi, bt, 2);
                }
                else
                {
                    db.UPDATE_TTTT_PT_BT_KHANG(madvi, bt, 2);
                }
            }
            var kh3 = db.SELECT_TTTT_PT_BT_KHANG(madvi, 3);

            int t3 = kh3.Rows.Count;
            string btstr3 = (txtSL.Text + "").Replace(".", ",");
            if (btstr3 != "")
            {
                float bt = float.Parse(btstr3);

                if (t3 == 0)
                {
                    db.INSERT_TTTT_PT_BT_KHANG(madvi, bt, 3);
                }
                else
                {
                    db.UPDATE_TTTT_PT_BT_KHANG(madvi, bt, 3);
                }
            }

            TyLEBT();
            TyLEBTram();
            SLTram();
            _DataBind();

        }

    }
}