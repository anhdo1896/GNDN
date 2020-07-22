using System;
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
    public partial class DN_DienNangThucTe : BasePage
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

            Session["SYS_Session"] = session;

            if (!IsPostBack)
            {

                cmbThang.Value = DateTime.Now.Month;
                cmbNam.Value = DateTime.Now.Year;
                CheckData();

            }
            _DataBind();
        }
        private void CheckData()
        {
            MTCSYT.SYS_Session session = (MTCSYT.SYS_Session)Session["SYS_Session"];
            var check = db.DN_CTy_DienNhans.Where(x => x.IDMA_DVIQLY == int.Parse(session.User.MA_DVIQLY) && x.Thang == int.Parse(cmbThang.Value + "") && x.Nam == int.Parse(cmbNam.Value + ""));
            if (check.Count() > 0)
            {
                btnLoc.Visible = true;
                btnCreate.Visible = false;
            }
            else
            {
                btnLoc.Visible = false;
                btnCreate.Visible = true;
            }

        }

        private void _DataBind()
        {
            MTCSYT.SYS_Session session = (MTCSYT.SYS_Session)Session["SYS_Session"];

            var khDN = db.DN_TongNhapDienNhans.Where(x => x.IDMA_DVIQLY == int.Parse(session.User.MA_DVIQLY) && x.Thang == int.Parse(cmbThang.Value + "") && x.Nam == int.Parse("" + cmbNam.Value));

            if (khDN.Count() > 0)
            {
                foreach (var kh in khDN)
                {

                    lbTongDienNhan.Text = string.Format("Tổng điện nhận: {0:N0}", kh.DN_Thang);
                    if (kh.DN_Thang == 0)
                    {
                        ScriptManager.RegisterStartupScript(Page, Page.GetType(), "", "alert('Tổng điện nhận theo kế hoạch =0 nên chưa thể nhập dữ liệu thực tế');", true);
                        btnCreate.Visible = false;
                        return;
                    }
                    if (kh.NgayDCLan1 != null)
                    {
                        DateTime Lan1 = (DateTime)kh.NgayDCLan1;
                        lbDieuChinhLan1.Text = string.Format("ĐC lần 1: {0:N0} ", kh.DN_DC_Lan1) + "/ĐC ngày: " + Lan1.ToString("dd/MM/yyyy");
                    }
                    if (kh.NgayDCLan2 != null)
                    {
                        DateTime Lan2 = (DateTime)kh.NgayDCLan2;
                        lbDieuChinhLan2.Text = string.Format("  ĐC lần 2: {0:N0} ", kh.DN_DC_Lan2) + "/ĐC ngày: " + Lan2.ToString("dd/MM/yyyy");
                    }
                    if (kh.NgayDCLan3 != null)
                    {
                        DateTime Lan3 = (DateTime)kh.NgayDCLan3;
                        lbDieuChinhLan3.Text = string.Format("  ĐC lần 3: {0:N0} ", kh.DN_DC_Lan3) + "/ĐC ngày: " + Lan3.ToString("dd/MM/yyyy");
                    }

                    break;
                }
                grdDVT.DataSource = db.DN_Select_ThucTe(int.Parse(session.User.ma_dviqly), int.Parse(cmbThang.Value + ""), int.Parse("" + cmbNam.Value)).ToList();
                grdDVT.DataBind();
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

        private bool CheckName(int donvi, int thang, int nam)
        {
            SYS_Session session = (SYS_Session)Session["SYS_Session"];

            var dt = db.TT_KhachHangDAThaps.SingleOrDefault(x => x.IDMA_DVIQLY == donvi && x.Thang == thang && x.Nam == nam);
            if (dt != null)
                return false;
            return true;
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



        protected void btnXuat_Click(object sender, EventArgs e)
        {
            Response.Redirect("../Report/Report.aspx?Thang=" + cmbThang.Value + "&Nam=" + cmbNam.Value + "&Loai=4");

        }



        protected void btnLoc_Click(object sender, EventArgs e)
        {
            CheckData();
        }

        protected void grdDVT_RowUpdating(object sender, DevExpress.Web.Data.ASPxDataUpdatingEventArgs e)
        {
            try
            {

                CBDN.DN_CTy_DienNhan cv = new CBDN.DN_CTy_DienNhan();
                cv = db.DN_CTy_DienNhans.SingleOrDefault(x => x.ID == int.Parse(e.Keys[0] + ""));


              /*  var tongKH = db.DN_TongNhapDienNhans.SingleOrDefault(x => x.IDMA_DVIQLY == cv.IDMA_DVIQLY && x.Thang == cv.Thang && x.Nam == cv.Nam);
                var dcKH1 = db.DN_TongNhapDienNhans.Where(x => x.IDMA_DVIQLY == cv.IDMA_DVIQLY && x.Thang == cv.Thang && x.Nam == cv.Nam
                          && x.NgayDCL1 == cv.Ngay);
                var dcKH2 = db.DN_TongNhapDienNhans.Where(x => x.IDMA_DVIQLY == cv.IDMA_DVIQLY && x.Thang == cv.Thang && x.Nam == cv.Nam
                          && x.NgayDCL2 == cv.Ngay);
                var dcKH3 = db.DN_TongNhapDienNhans.Where(x => x.IDMA_DVIQLY == cv.IDMA_DVIQLY && x.Thang == cv.Thang && x.Nam == cv.Nam
                          && x.NgayDCL3 == cv.Ngay);

                int tongDC = 0;
                foreach (var khDC in dcKH1)
                {
                    tongDC = tongDC + (int)khDC.DN_DC_Lan1;
                }
                foreach (var khDC in dcKH2)
                {
                    tongDC = tongDC + (int)khDC.DN_DC_Lan2;
                }
                foreach (var khDC in dcKH3)
                {
                    tongDC = tongDC + (int)khDC.DN_DC_Lan3;
                }

                if (cv.Ngay != 1)
                {
                    var cvls = db.DN_CTy_DienNhans.SingleOrDefault(x => x.IDMA_DVIQLY == cv.IDMA_DVIQLY && x.Thang == cv.Thang && x.Nam == cv.Nam && x.Ngay == cv.Ngay - 1);
                    cv.LuyKeTH = cvls.LuyKeTH + int.Parse(e.NewValues[0] + "");
                    cv.TH_PhanBoNgay = (tongKH.DN_Thang + tongDC - cvls.LuyKePhanBo) / (DateTime.DaysInMonth(int.Parse(cmbNam.Value + ""), int.Parse("" + cmbThang.Value)) - cv.Ngay);
                    cv.TongKH_PBNgay = cvls.TongKH_PBNgay + cv.TH_PhanBoNgay + tongDC;
                    cv.LuyKePhanBo = cvls.LuyKePhanBo + cv.TH_PhanBoNgay;
                }
                else
                {
                    cv.TH_PhanBoNgay = (tongKH.DN_Thang + tongDC) / (DateTime.DaysInMonth(int.Parse(cmbNam.Value + ""), int.Parse("" + cmbThang.Value)) - 1);
                    cv.LuyKeTH = int.Parse(e.NewValues[0] + "");
                    cv.TongKH_PBNgay = cv.TH_PhanBoNgay + tongDC;
                    cv.LuyKePhanBo = cv.TH_PhanBoNgay;
                }*/




                //if (cv.Ngay <= DateTime.Now.Day-4 && cv.DienNhan != int.Parse(e.NewValues[0] + ""))
                //{
                //    throw new Exception("Bạn không thể sửa giá trị điện nhận vì không phải ngày sửa hiện tại.");
                //}
                cv.DienNhan = int.Parse(e.NewValues[0] + "");
                cv.SanLuongKH = int.Parse(e.NewValues[1] + "");
                cv.SanLuongPB = int.Parse(e.NewValues[2] + "");
                cv.GhiChu = e.NewValues[3] + "";
                grdDVT.CancelEdit();
                e.Cancel = true;
                db.SubmitChanges();
                _DataBind();
                ScriptManager.RegisterStartupScript(Page, Page.GetType(), "", "alert('Cập nhật dữ liệu thành công');", true);
            }
            catch (Exception ex)
            {
                grdDVT.JSProperties["cpError"] = "SqlException";
                e.Cancel = true;
            }
            //finally
            //{
            //    e.Cancel = true;
            //}
        }

        protected void btnCreate_Click(object sender, EventArgs e)
        {
            // tạo dữ liệu tahngs
            try
            {
                SYS_Session session = (SYS_Session)Session["SYS_Session"];
                db.DN_Create_ThucTe(int.Parse(session.User.MA_DVIQLY), int.Parse(cmbThang.Value + ""), int.Parse("" + cmbNam.Value));
                ScriptManager.RegisterStartupScript(Page, Page.GetType(), "", "alert('Tạo dữ liệu nhập thực tế điện năng theo tháng cấp công ty thành công');", true);
                btnCreate.Visible = false;
                btnLoc.Visible = true;
                _DataBind();
            }
            catch (Exception ex)
            {

            }

        }
        private bool EditButtonVisibleCriteria(ASPxGridView grid, int visibleIndex)
        {
            object row = grid.GetRow(visibleIndex);
            return bool.Parse(((DataRowView)row)["ISLooK"].ToString());
        }

        protected void grdDVT_CustomButtonInitialize(object sender, ASPxGridViewCustomButtonEventArgs e)
        {
            if (e.VisibleIndex == -1) return;

            if (EditButtonVisibleCriteria((ASPxGridView)sender, e.VisibleIndex))
                e.Visible = DevExpress.Utils.DefaultBoolean.True;
            else
                e.Visible = DevExpress.Utils.DefaultBoolean.False;


        }
        protected void grdDVT_HtmlCommandCellPrepared(object sender, ASPxGridViewTableCommandCellEventArgs e)
        {

        }
        protected void grdDVT_HtmlDataCellPrepared(object sender, ASPxGridViewTableDataCellEventArgs e)
        {

        }


        protected void grdDVT_CommandButtonInitialize(object sender, ASPxGridViewCommandButtonEventArgs e)
        {
            return;
            SYS_Session session = (SYS_Session)Session["SYS_Session"];

            var lst = db.DN_Select_ThucTe(int.Parse(session.User.ma_dviqly), int.Parse(cmbThang.Value + ""), int.Parse("" + cmbNam.Value)).ToList().Where(x => x.Ngay == e.VisibleIndex + 1);
            bool kt = false;
            foreach (var a in lst)
            {

                if (a.ISLooK == 1)
                {
                    kt = true;
                }
                else
                    kt = false;
                if (e.ButtonType == DevExpress.Web.ColumnCommandButtonType.Edit)
                    e.Visible = kt;

                // disable the selction checkbox
                if (e.ButtonType == DevExpress.Web.ColumnCommandButtonType.SelectCheckbox)
                    e.Enabled = kt;
            }

        }

        protected void cmbThang_SelectedIndexChanged(object sender, EventArgs e)
        {
            CheckData();
        }

        protected void cmbNam_SelectedIndexChanged(object sender, EventArgs e)
        {
            CheckData();
        }


    }
}