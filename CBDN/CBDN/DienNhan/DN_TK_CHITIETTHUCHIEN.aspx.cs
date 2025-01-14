﻿using System;
using System.Collections.Generic;
using DevExpress.Web;
using Entity;
using SystemManageService;
using System.Web.UI;
using System.Linq;
using System.Data;
using Aspose.Cells;
using System.Collections;
namespace MTCSYT
{
    public partial class DN_TK_CHITIETTHUCHIEN : BasePage
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
                Response.Redirect("~\\login\\Login.aspx");
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

            Session["SYS_Session"] = session;

            if (!IsPostBack)
            {

                cmbThang.Value = DateTime.Now.Month;
                cmbNam.Value = DateTime.Now.Year;

            }
            _DataBind();
        }

        private void _DataBind()
        {
            MTCSYT.SYS_Session session = (MTCSYT.SYS_Session)Session["SYS_Session"];

            var khDN = db.DN_TongNhapDienNhans.Where(x => x.IDMA_DVIQLY == int.Parse(session.User.MA_DVIQLY) && x.Thang == int.Parse(cmbThang.Value + "") && x.Nam == int.Parse("" + cmbNam.Value));

            if (khDN.Count() > 0)
            {
                foreach (var kh in khDN)
                {

                    lbTongDienNhan.Text = "Tổng điện nhận: " + kh.DN_Thang + "";
                    if (kh.DN_Thang == 0)
                    {
                        ScriptManager.RegisterStartupScript(Page, Page.GetType(), "", "alert('Tổng điện nhận theo kế hoạch =0 nên chưa thể nhập dữ liệu thực tế');", true);
                        btnIN.Visible = false;
                        return;
                    }
                    if (kh.NgayDCLan1 != null)
                    {
                        DateTime Lan1 = (DateTime)kh.NgayDCLan1;
                        lbDieuChinhLan1.Text = "ĐC lần 1: " + kh.DN_DC_Lan1 + "/ĐC ngày: " + Lan1.ToString("dd/MM/yyyy");
                    }
                    if (kh.NgayDCLan2 != null)
                    {
                        DateTime Lan2 = (DateTime)kh.NgayDCLan2;
                        lbDieuChinhLan2.Text = "  ĐC lần 2: " + kh.DN_DC_Lan2 + "/ĐC ngày: " + Lan2.ToString("dd/MM/yyyy");
                    }
                    if (kh.NgayDCLan3 != null)
                    {
                        DateTime Lan3 = (DateTime)kh.NgayDCLan3;
                        lbDieuChinhLan3.Text = "  ĐC lần 3: " + kh.DN_DC_Lan3 + "/ĐC ngày: " + Lan3.ToString("dd/MM/yyyy");
                    }

                    break;
                }
               // grdDVT.DataSource = db.DN_TK_ThucTeDonVi(int.Parse(session.User.ma_dviqly), int.Parse(cmbThang.Value + ""), int.Parse("" + cmbNam.Value)).ToList();
               // grdDVT.DataBind();
            }
            else
            {
                ScriptManager.RegisterStartupScript(Page, Page.GetType(), "", "alert('Chưa có dữ liệu kế hoạch nhập điện nhận nên chưa thể nhập dữ liệu thực tế');", true);
            }


        }

        protected void grdDVT_CustomColumnDisplayText(object sender, ASPxGridViewColumnDisplayTextEventArgs e)
        {
            if (e.Column.Caption == "STT")
            {
                e.DisplayText = (e.VisibleRowIndex + 1).ToString();
            }
        }

       
        protected void grdDVT_CellEditorInitialize(object sender, ASPxGridViewEditorEventArgs e)
        {
            e.Column.ToString();
            if (e.Column.FieldName == "MaChiNhanh")
                e.Editor.Focus();
        }

        protected void grdDVT_StartRowEditing(object sender, DevExpress.Web.Data.ASPxStartRowEditingEventArgs e)
        {
            (sender as ASPxGridView).GetRowValuesByKeyValue(e.EditingKeyValue);

        }

        protected void grdDVT_CellEditorInitialize1(object sender, ASPxGridViewEditorEventArgs e)
        {

        }



        protected void cmbPhongBan_SelectedIndexChanged(object sender, EventArgs e)
        {
            _DataBind();
        }

        protected void grdDVT_HtmlCommandCellPrepared(object sender, ASPxGridViewTableCommandCellEventArgs e)
        {

        }

        protected void btnXuat_Click(object sender, EventArgs e)
        {
             MTCSYT.SYS_Session session = (MTCSYT.SYS_Session)Session["SYS_Session"];
            Response.Redirect("../Report/Report.aspx?Thang=" + cmbThang.Value + "&Nam=" + cmbNam.Value + "&Loai=10&DonVi=" + session.User.ma_dviqly);

        }



        protected void btnLoc_Click(object sender, EventArgs e)
        {

        }

       
        protected void btnCreate_Click(object sender, EventArgs e)
        {
            
        }

        protected void btnIN_Click(object sender, EventArgs e)
        {
            MTCSYT.SYS_Session session = (MTCSYT.SYS_Session)Session["SYS_Session"];
            Response.Redirect("../Report/Report.aspx?Thang=" + cmbThang.Value + "&Nam=" + cmbNam.Value + "&Loai=10&DonVi=" + session.User.ma_dviqly);
        }


    }
}