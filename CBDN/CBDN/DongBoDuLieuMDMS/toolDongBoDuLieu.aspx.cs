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
using System.Web.Script.Serialization;
using System.Net;
using System.Text;
namespace MTCSYT
{
    public partial class toolDongBoDuLieu : BasePage
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
                loadDSNgay();
            _DataBind();

        }
        private void loadDSNgay()
        {
            int thang = DateTime.Now.Month;
            int nam = DateTime.Now.Year;
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
        private void _DataBind()
        {
            MTCSYT.SYS_Session session = (MTCSYT.SYS_Session)Session["SYS_Session"];
            int ma_dviqly = int.Parse(session.User.ma_dviqly + "");

            grdDVT.DataSource = db.LayThongTinGiaoNhanQuaTool(ma_dviqly, int.Parse(cmbThang.Value + ""), int.Parse(cmbNam.Value + "")).ToList();
            grdDVT.DataBind();
        }

        protected void grdDVT_CustomColumnDisplayText(object sender, ASPxGridViewColumnDisplayTextEventArgs e)
        {
            if (e.Column.Caption == "STT")
            {
                e.DisplayText = (e.VisibleRowIndex + 1).ToString();
            }
        }

        protected void grdDVT_RowDeleting(object sender, DevExpress.Web.Data.ASPxDataDeletingEventArgs e)
        {
            try
            {
                SYS_Session session = (SYS_Session)Session["SYS_Session"];
                CBDN.DM_NhaMay HoatDong = (CBDN.DM_NhaMay)grdDVT.GetRow(grdDVT.FocusedRowIndex);
                CBDN.DM_NhaMay cv = new CBDN.DM_NhaMay();
                cv = db.DM_NhaMays.SingleOrDefault(x => x.ID == HoatDong.ID && x.IDMADVIQLY == int.Parse(session.User.ma_dviqly));
                db.DM_NhaMays.DeleteOnSubmit(cv);
                db.SubmitChanges();
                _DataBind();
                ScriptManager.RegisterStartupScript(Page, Page.GetType(), "", "alert('Xoá người phụ trách thành công');", true);
            }
            catch (Exception ex)
            { }
            finally
            {
                e.Cancel = true;
            }
        }


        private bool CheckName(string Name, int id)
        {
            SYS_Session session = (SYS_Session)Session["SYS_Session"];

            var dt = db.DM_NhaMays.SingleOrDefault(x => x.MaNhaMay == Name && x.IDMADVIQLY == int.Parse(session.User.ma_dviqly) && x.ID != id);
            if (dt != null)
                return false;
            return true;
        }

        protected void grdDVT_CellEditorInitialize(object sender, ASPxGridViewEditorEventArgs e)
        {
            e.Column.ToString();
            if (e.Column.FieldName == "IDCanBo")
                e.Editor.Focus();
        }

        protected void grdDVT_StartRowEditing(object sender, DevExpress.Web.Data.ASPxStartRowEditingEventArgs e)
        {
            (sender as ASPxGridView).GetRowValuesByKeyValue(e.EditingKeyValue);

        }

        protected void grdDVT_CellEditorInitialize1(object sender, ASPxGridViewEditorEventArgs e)
        {

        }
        protected void grdDVT_HtmlCommandCellPrepared(object sender, ASPxGridViewTableCommandCellEventArgs e)
        {

        }
        private decimal soLon(string chisocu)
        {
            string chuoi = "1";
            for (int i = 0; i < chisocu.Split('.')[0].ToString().Length; i++)
            { chuoi += "0"; }
            return decimal.Parse(chuoi);

        }

        private void dongbosoLieu(TSVH vh, string maDiemDo)
        {
            try
            {
                MTCSYT.SYS_Session session = (MTCSYT.SYS_Session)Session["SYS_Session"];
                int ma_dviqly = int.Parse(session.User.ma_dviqly + "");

                //var cto = db.DM_CongTos.SingleOrDefault(x => x.IDCongTo == int.Parse(tlDonVi.FocusedNode.Key));
                //CBDN.HD_GiaoNhanThang chitiet = db.HD_GiaoNhanThangs.SingleOrDefault(x => x.ID == int.Parse(tlDonVi.FocusedNode.Key));
                var lstHD = db.LayThongTinGiaoNhanQuaMaDD(maDiemDo, int.Parse(cmbThang.Value + ""), int.Parse(cmbNam.Value + ""));
                foreach (var hd in lstHD)
                {
                    CBDN.HD_GiaoNhanThang chitiet = db.HD_GiaoNhanThangs.SingleOrDefault(x => x.ID == hd.ID && x.ISNhanVien != true);
                    if (chitiet == null) continue;
                    var congto = db.DM_CongTos.SingleOrDefault(x => x.IDCongTo == int.Parse(chitiet.IDCongTo));

                    if (chitiet != null)
                    {


                        chitiet.Giao_Bieu1_Cuoi = decimal.Parse("" + vh.IMPBT);
                        chitiet.Nhan_Bieu1_Cuoi = decimal.Parse("" + vh.EXPBT);
                        if (decimal.Parse("" + vh.IMPBT) < chitiet.Giao_Bieu1_Dau)
                            chitiet.Giao_Bieu1_SanLuong = (soLon(chitiet.Giao_Bieu1_Dau + "") - chitiet.Giao_Bieu1_Dau + decimal.Parse("" + vh.IMPBT)) * congto.HeSoNhan * congto.HeSoQuyDoi;
                        else
                            chitiet.Giao_Bieu1_SanLuong = (decimal.Parse("" + vh.IMPBT) - chitiet.Giao_Bieu1_Dau) * congto.HeSoNhan * congto.HeSoQuyDoi;
                        if (decimal.Parse("" + vh.EXPBT) < chitiet.Nhan_Bieu1_Dau)
                            chitiet.Nhan_Bieu1_SanLuong = (soLon(chitiet.Nhan_Bieu1_Dau + "") - chitiet.Nhan_Bieu1_Dau + decimal.Parse("" + vh.EXPBT)) * congto.HeSoNhan * congto.HeSoQuyDoi;
                        else
                            chitiet.Nhan_Bieu1_SanLuong = (decimal.Parse("" + vh.EXPBT) - chitiet.Nhan_Bieu1_Dau) * congto.HeSoNhan * congto.HeSoQuyDoi;

                        chitiet.Giao_Bieu2_Cuoi = decimal.Parse("" + vh.IMPCD);
                        chitiet.Nhan_Bieu2_Cuoi = decimal.Parse("" + vh.EXPCD);
                        if (decimal.Parse("" + vh.IMPCD) < chitiet.Giao_Bieu2_Dau)
                            chitiet.Giao_Bieu2_SanLuong = (soLon(chitiet.Giao_Bieu2_Dau + "") - chitiet.Giao_Bieu2_Dau + decimal.Parse("" + vh.IMPCD)) * congto.HeSoNhan * congto.HeSoQuyDoi;
                        else
                            chitiet.Giao_Bieu2_SanLuong = (decimal.Parse("" + vh.IMPCD) - chitiet.Giao_Bieu2_Dau) * congto.HeSoNhan * congto.HeSoQuyDoi;

                        if (decimal.Parse("" + vh.EXPCD) < chitiet.Nhan_Bieu2_Dau)
                            chitiet.Nhan_Bieu2_SanLuong = (soLon(chitiet.Nhan_Bieu2_Dau + "") - chitiet.Nhan_Bieu2_Dau + decimal.Parse("" + vh.EXPCD)) * congto.HeSoNhan * congto.HeSoQuyDoi;
                        else
                            chitiet.Nhan_Bieu2_SanLuong = (decimal.Parse("" + vh.EXPCD) - chitiet.Nhan_Bieu2_Dau) * congto.HeSoNhan * congto.HeSoQuyDoi;

                        chitiet.Giao_Bieu3_Cuoi = decimal.Parse("" + vh.IMPTD);
                        chitiet.Nhan_Bieu3_Cuoi = decimal.Parse("" + vh.EXPTD);
                        if (decimal.Parse("" + vh.IMPTD) < chitiet.Giao_Bieu3_Dau)
                            chitiet.Giao_Bieu3_SanLuong = (soLon(chitiet.Giao_Bieu3_Dau + "") - chitiet.Giao_Bieu3_Dau + decimal.Parse("" + vh.IMPTD)) * congto.HeSoNhan * congto.HeSoQuyDoi;
                        else
                            chitiet.Giao_Bieu3_SanLuong = (decimal.Parse("" + vh.IMPTD) - chitiet.Giao_Bieu3_Dau) * congto.HeSoNhan * congto.HeSoQuyDoi;
                        if (decimal.Parse("" + vh.EXPTD) < chitiet.Nhan_Bieu3_Dau)
                            chitiet.Nhan_Bieu3_SanLuong = (soLon(chitiet.Nhan_Bieu3_Dau + "") - chitiet.Nhan_Bieu3_Dau + decimal.Parse("" + vh.EXPTD)) * congto.HeSoNhan * congto.HeSoQuyDoi;
                        else
                            chitiet.Nhan_Bieu3_SanLuong = (decimal.Parse("" + vh.EXPTD) - chitiet.Nhan_Bieu3_Dau) * congto.HeSoNhan * congto.HeSoQuyDoi;

                        //chitiet.DonViTinh = int.Parse(cmbDonVi.Value + "");
                        chitiet.Nhan_P_Cuoi = Math.Round(decimal.Parse(vh.EXPORTKWH), 3);
                        chitiet.Giao_P_Cuoi = decimal.Parse(vh.IMPORTKWH);

                        chitiet.Giao_P_SanLuong = chitiet.Giao_Bieu1_SanLuong + chitiet.Giao_Bieu2_SanLuong + chitiet.Giao_Bieu3_SanLuong;
                        chitiet.Nhan_P_SanLuong = chitiet.Nhan_Bieu1_SanLuong + chitiet.Nhan_Bieu2_SanLuong + chitiet.Nhan_Bieu3_SanLuong;
                        //if (chitiet.Giao_P_Dau > decimal.Parse(vh.IMPORTKWH))
                        //{
                        //    //trường hợp quay đầu
                        //    chitiet.Giao_P_SanLuong = (soLon(chitiet.Giao_P_Dau + "") - chitiet.Giao_P_Dau + decimal.Parse("" + vh.IMPORTKWH)) * (decimal)congto.HeSoNhan * (decimal)congto.HeSoQuyDoi;
                        //}
                        //else
                        //    chitiet.Giao_P_SanLuong = (decimal.Parse("" + vh.IMPORTKWH) - chitiet.Giao_P_Dau) * (decimal)congto.HeSoNhan * (decimal)congto.HeSoQuyDoi;

                        //if (decimal.Parse(vh.EXPORTKWH) < chitiet.Nhan_P_Cuoi)
                        //    chitiet.Nhan_P_SanLuong = (soLon(chitiet.Nhan_P_Cuoi + "") - chitiet.Nhan_P_Cuoi + decimal.Parse(vh.EXPORTKWH)) * congto.HeSoNhan * congto.HeSoQuyDoi;
                        //else
                        //    chitiet.Nhan_P_SanLuong = (decimal.Parse(vh.EXPORTKWH) - chitiet.Nhan_P_Cuoi) * congto.HeSoNhan * congto.HeSoQuyDoi;

                        chitiet.Nhan_Q_Cuoi = decimal.Parse("" + vh.C2);
                        chitiet.Giao_Q_Cuoi = decimal.Parse("" + vh.C1);

                        if (decimal.Parse("" + vh.C1) < chitiet.Giao_Q_Dau)
                            chitiet.Giao_Q_SanLuong = (soLon(chitiet.Giao_Q_Dau + "") - chitiet.Giao_Q_Dau + decimal.Parse("" + vh.C1)) * congto.HeSoNhan * congto.HeSoQuyDoi;
                        else
                            chitiet.Giao_Q_SanLuong = (decimal.Parse("" + vh.C1) - chitiet.Giao_Q_Dau) * congto.HeSoNhan * congto.HeSoQuyDoi;

                        if (decimal.Parse("" + vh.C2) < chitiet.Nhan_Q_Dau)
                            chitiet.Nhan_Q_SanLuong = (soLon(chitiet.Nhan_Q_Dau + "") - chitiet.Nhan_Q_Dau + decimal.Parse("" + vh.C2)) * congto.HeSoNhan * congto.HeSoQuyDoi;
                        else
                            chitiet.Nhan_Q_SanLuong = (decimal.Parse("" + vh.C2) - chitiet.Nhan_Q_Dau) * congto.HeSoNhan * congto.HeSoQuyDoi;

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
                            chitiet.CosNhan = decimal.Parse("" + Math.Round(Math.Cos(Math.Atan(nhana / nhanb)), 3));
                        }
                        else
                            chitiet.CosNhan = 0;
                        chitiet.ISDoDem = 0;
                        chitiet.ISChot = true;
                        chitiet.XacNhanDVGiao = false;
                        chitiet.XacNhanDVNhan = false;
                        chitiet.ISNhanVien = false;
                        if (chitiet.GhiChuXacNhanGiao != "" && !(bool)chitiet.XacNhanDVGiao)
                            chitiet.GhiChuXacNhanGiao = "Đã hiệu chỉnh số liệu";
                        if (chitiet.GhiChuXacNhanNhan != "" && !(bool)chitiet.XacNhanDVNhan)
                            chitiet.GhiChuXacNhanNhan = "Đã hiệu chỉnh số liệu";
                        chitiet.ToolDB = true;
                        chitiet.LoaiNhap = 0;
                        db.SubmitChanges();
                    }
                }

                ScriptManager.RegisterStartupScript(Page, Page.GetType(), "", "alert('Cập nhật số liệu thành công');", true);
            }
            catch (Exception ex)
            {
                ScriptManager.RegisterStartupScript(Page, Page.GetType(), "", "alert('" + ex.Message + "');", true);
            }
        }
        private void DongBoDuLieuKhoEVN(CBDN.HD_DiemDoLienKet a)
        {
            if (DateTime.Now.Hour < 13)
            {
                DongBoNPC(a);
            }
            else
            {
                CBDN.ser_MDMS.Service_MDMS_EVNSoapClient ser = new CBDN.ser_MDMS.Service_MDMS_EVNSoapClient();
                //DataSet ds = ser.GET_READ_IX("G2A001S000M371",  "31/03/2020", "01/04/2020", "MDMS_PA", "MDMS_PA");
                DataSet ds = ser.GET_READ_IX_OPT(a.DDo, "2", "AM", "PA", "01/" + DateTime.Now.Month + "/" + DateTime.Now.Year, "01/" + DateTime.Now.Month + "/" + DateTime.Now.Year, "MDMS_PA", "MDMS_PA");
                if (ds.Tables[0].Rows.Count > 0)
                {
                    TSVH ts = new TSVH();
                    if ((bool)a.IsDaoChieu)
                    {
                        if (!(bool)a.IsChieuGiao && !(bool)a.IsChieuNhan)
                        {
                            ts.EXPBT = (decimal.Parse("0" + ds.Tables[0].Rows[0]["VAL_BTG"] + "") / 1000 * a.Nhan / a.Chia).ToString();
                            ts.EXPCD = (decimal.Parse("0" + ds.Tables[0].Rows[0]["VAL_CDG"] + "") / 1000 * a.Nhan / a.Chia).ToString();
                            ts.EXPTD = (decimal.Parse("0" + ds.Tables[0].Rows[0]["VAL_TDG"] + "") / 1000 * a.Nhan / a.Chia).ToString();
                            ts.EXPORTKWH = (decimal.Parse("0" + ds.Tables[0].Rows[0]["VAL_SGG"] + "") / 1000 * a.Nhan / a.Chia).ToString();
                            ts.C2 = (decimal.Parse("0" + ds.Tables[0].Rows[0]["VAL_VCG"]) / 1000 * a.Nhan / a.Chia).ToString();

                            ts.IMPBT = (decimal.Parse("0" + ds.Tables[0].Rows[0]["VAL_BTN"] + "") / 1000 * a.Nhan / a.Chia).ToString();
                            ts.IMPCD = (decimal.Parse("0" + ds.Tables[0].Rows[0]["VAL_CDN"] + "") / 1000 * a.Nhan / a.Chia).ToString();
                            ts.IMPTD = (decimal.Parse("0" + ds.Tables[0].Rows[0]["VAL_TDN"] + "") / 1000 * a.Nhan / a.Chia).ToString();
                            ts.IMPORTKWH = (decimal.Parse("0" + ds.Tables[0].Rows[0]["VAL_SGN"] + "") / 1000 * a.Nhan / a.Chia).ToString();
                            ts.C1 = (decimal.Parse("0" + ds.Tables[0].Rows[0]["VAL_VCN"]) / 1000 * a.Nhan / a.Chia).ToString();

                        }
                        else
                        {
                            if ((bool)a.IsChieuGiao)
                            {
                                ts.IMPBT = (decimal.Parse("0" + ds.Tables[0].Rows[0]["VAL_BTN"] + "") / 1000 * a.Nhan / a.Chia).ToString();
                                ts.IMPCD = (decimal.Parse("0" + ds.Tables[0].Rows[0]["VAL_CDN"] + "") / 1000 * a.Nhan / a.Chia).ToString();
                                ts.IMPTD = (decimal.Parse("0" + ds.Tables[0].Rows[0]["VAL_TDN"] + "") / 1000 * a.Nhan / a.Chia).ToString();
                                ts.IMPORTKWH = (decimal.Parse("0" + ds.Tables[0].Rows[0]["VAL_SGN"] + "") / 1000 * a.Nhan / a.Chia).ToString();
                                ts.C1 = (decimal.Parse("0" + ds.Tables[0].Rows[0]["VAL_VCN"]) / 1000 * a.Nhan / a.Chia).ToString();

                                ts.EXPBT = "0";
                                ts.EXPCD = "0";
                                ts.EXPTD = "0";
                                ts.EXPORTKWH = "0";
                                ts.C2 = "0";

                            }
                            if ((bool)a.IsChieuNhan)
                            {
                                ts.IMPBT = "0";
                                ts.IMPCD = "0";
                                ts.IMPTD = "0";
                                ts.IMPORTKWH = "0";
                                ts.C1 = "0";

                                ts.EXPBT = (decimal.Parse("0" + ds.Tables[0].Rows[0]["VAL_BTG"] + "") / 1000 * a.Nhan / a.Chia).ToString();
                                ts.EXPCD = (decimal.Parse("0" + ds.Tables[0].Rows[0]["VAL_CDG"] + "") / 1000 * a.Nhan / a.Chia).ToString();
                                ts.EXPTD = (decimal.Parse("0" + ds.Tables[0].Rows[0]["VAL_TDG"] + "") / 1000 * a.Nhan / a.Chia).ToString();
                                ts.EXPORTKWH = (decimal.Parse("0" + ds.Tables[0].Rows[0]["VAL_SGG"] + "") / 1000 * a.Nhan / a.Chia).ToString();
                                ts.C2 = (decimal.Parse("0" + ds.Tables[0].Rows[0]["VAL_VCG"]) / 1000 * a.Nhan / a.Chia).ToString();
                            }
                        }

                    }
                    else
                    {
                        if (!(bool)a.IsChieuGiao && !(bool)a.IsChieuNhan)
                        {
                            ts.IMPBT = (decimal.Parse("0" + ds.Tables[0].Rows[0]["VAL_BTG"] + "") / 1000 * a.Nhan / a.Chia).ToString();
                            ts.IMPCD = (decimal.Parse("0" + ds.Tables[0].Rows[0]["VAL_CDG"] + "") / 1000 * a.Nhan / a.Chia).ToString();
                            ts.IMPTD = (decimal.Parse("0" + ds.Tables[0].Rows[0]["VAL_TDG"] + "") / 1000 * a.Nhan / a.Chia).ToString();
                            ts.IMPORTKWH = (decimal.Parse("0" + ds.Tables[0].Rows[0]["VAL_SGG"] + "") / 1000 * a.Nhan / a.Chia).ToString();
                            ts.C1 = (decimal.Parse("0" + ds.Tables[0].Rows[0]["VAL_VCG"]) / 1000 * a.Nhan / a.Chia).ToString();

                            ts.EXPBT = (decimal.Parse("0" + ds.Tables[0].Rows[0]["VAL_BTN"] + "") / 1000 * a.Nhan / a.Chia).ToString();
                            ts.EXPCD = (decimal.Parse("0" + ds.Tables[0].Rows[0]["VAL_CDN"] + "") / 1000 * a.Nhan / a.Chia).ToString();
                            ts.EXPTD = (decimal.Parse("0" + ds.Tables[0].Rows[0]["VAL_TDN"] + "") / 1000 * a.Nhan / a.Chia).ToString();
                            ts.EXPORTKWH = (decimal.Parse("0" + ds.Tables[0].Rows[0]["VAL_SGN"] + "") / 1000 * a.Nhan / a.Chia).ToString();
                            ts.C2 = (decimal.Parse("0" + ds.Tables[0].Rows[0]["VAL_VCN"]) / 1000 * a.Nhan / a.Chia).ToString();

                        }
                        else
                        {
                            if ((bool)a.IsChieuGiao)
                            {
                                ts.IMPBT = (decimal.Parse("0" + ds.Tables[0].Rows[0]["VAL_BTG"] + "") / 1000 * a.Nhan / a.Chia).ToString();
                                ts.IMPCD = (decimal.Parse("0" + ds.Tables[0].Rows[0]["VAL_CDG"] + "") / 1000 * a.Nhan / a.Chia).ToString();
                                ts.IMPTD = (decimal.Parse("0" + ds.Tables[0].Rows[0]["VAL_TDG"] + "") / 1000 * a.Nhan / a.Chia).ToString();
                                //  ts.IMPORTKWH = ((decimal.Parse("0" + ds.Tables[0].Rows[0]["VAL_BTG"] + "") + decimal.Parse("0" + ds.Tables[0].Rows[0]["VAL_CDG"] + "") + decimal.Parse("0" + ds.Tables[0].Rows[0]["VAL_TDG"] + "")) / 1000).ToString();
                                ts.C1 = (decimal.Parse("0" + ds.Tables[0].Rows[0]["VAL_VCG"]) / 1000 * a.Nhan / a.Chia).ToString();
                                ts.IMPORTKWH = (decimal.Parse("0" + ds.Tables[0].Rows[0]["VAL_SGG"] + "") / 1000 * a.Nhan / a.Chia).ToString();

                                ts.EXPBT = "0";
                                ts.EXPCD = "0";
                                ts.EXPTD = "0";
                                ts.EXPORTKWH = "0";
                                ts.C2 = "0";

                            }
                            if ((bool)a.IsChieuNhan)
                            {
                                ts.IMPBT = "0";
                                ts.IMPCD = "0";
                                ts.IMPTD = "0";
                                ts.IMPORTKWH = "0";
                                ts.C1 = "0";

                                ts.EXPBT = (decimal.Parse("0" + ds.Tables[0].Rows[0]["VAL_BTN"] + "") / 1000 * a.Nhan / a.Chia).ToString();
                                ts.EXPCD = (decimal.Parse("0" + ds.Tables[0].Rows[0]["VAL_CDN"] + "") / 1000 * a.Nhan / a.Chia).ToString();
                                ts.EXPTD = (decimal.Parse("0" + ds.Tables[0].Rows[0]["VAL_TDN"] + "") / 1000 * a.Nhan / a.Chia).ToString();
                                //ts.EXPORTKWH = ((decimal.Parse("0" + ds.Tables[0].Rows[0]["VAL_BTN"] + "") + decimal.Parse("0" + ds.Tables[0].Rows[0]["VAL_CDN"] + "") + decimal.Parse("0" + ds.Tables[0].Rows[0]["VAL_TDN"] + "")) / 1000).ToString();
                                ts.EXPORTKWH = (decimal.Parse("0" + ds.Tables[0].Rows[0]["VAL_SGN"] + "") / 1000 * a.Nhan / a.Chia).ToString();

                                ts.C2 = (decimal.Parse("0" + ds.Tables[0].Rows[0]["VAL_VCN"]) / 1000 * a.Nhan / a.Chia).ToString();
                            }
                        }

                    }


                    ts.MA_DIEMDO = a.DDo;
                    dongbosoLieu(ts, a.MaDiemDo);
                }
                else
                {
                    DongBoNPC(a);
                }
            }

        }
        private void DongBoNPC(CBDN.HD_DiemDoLienKet a)
        {
            List<TSVH> services = new List<TSVH>();
            ServicePointManager.ServerCertificateValidationCallback = (senderX, certificate, chain, sslPolicyErrors) => { return true; };
            WebClient client = new WebClient();
            client.Headers["Content-type"] = "application/json";
            client.Encoding = Encoding.UTF8;
            string sql;

            if (a.DDo + "" == "")
            {
                sql = "p_MA_DIEMDO=" + a.MaDiemDo + "&p_THANG=" + DateTime.Now.Month + "&p_NAM=" + DateTime.Now.Year + "&p_HES=KhoEVN";
            }
            else if (a.Nguon != "IPP")
            {
                sql = "p_MA_DIEMDO=" + a.DDo + "&p_THANG=" + DateTime.Now.Month + "&p_NAM=" + DateTime.Now.Year + "&p_HES=EVNHES";
            }
            else
                sql = "p_MA_DIEMDO=" + a.DDo + "&p_THANG=" + DateTime.Now.Month + "&p_NAM=" + DateTime.Now.Year + "&p_HES=" + a.Nguon;
            string json = client.DownloadString("https://vhpm.npc.com.vn/DoDemAPI/api/DoXa?" + sql);
            services = (new JavaScriptSerializer()).Deserialize<List<TSVH>>(json);
            foreach (var tsvh in services)
            {
                TSVH vh = new TSVH();

                if ((bool)a.IsDaoChieu)
                {
                    if (!(bool)a.IsChieuGiao && !(bool)a.IsChieuNhan)
                    {
                        vh.C1 = (decimal.Parse(tsvh.C2) * a.Nhan / a.Chia) + "";
                        vh.EXPBT = (decimal.Parse(tsvh.IMPBT) * a.Nhan / a.Chia) + "";
                        vh.EXPCD = (decimal.Parse(tsvh.IMPCD) * a.Nhan / a.Chia) + "";
                        vh.EXPTD = (decimal.Parse(tsvh.IMPTD) * a.Nhan / a.Chia) + "";
                        vh.EXPORTKWH = (decimal.Parse(tsvh.IMPORTKWH) * a.Nhan / a.Chia) + "";

                        vh.IMPBT = (decimal.Parse(tsvh.EXPBT) * a.Nhan / a.Chia) + "";
                        vh.IMPCD = (decimal.Parse(tsvh.EXPCD) * a.Nhan / a.Chia) + "";
                        vh.IMPORTKWH = (decimal.Parse(tsvh.EXPORTKWH) * a.Nhan / a.Chia) + "";
                        vh.IMPTD = (decimal.Parse(tsvh.EXPTD) * a.Nhan / a.Chia) + "";
                        vh.C2 = (decimal.Parse(tsvh.C1) * a.Nhan / a.Chia) + "";
                    }
                    else
                    {
                        if ((bool)a.IsChieuGiao)
                        {
                            vh.IMPBT = (decimal.Parse(tsvh.EXPBT) * a.Nhan / a.Chia) + "";
                            vh.IMPCD = (decimal.Parse(tsvh.EXPCD) * a.Nhan / a.Chia) + "";
                            vh.IMPORTKWH = (decimal.Parse(tsvh.EXPORTKWH) * a.Nhan / a.Chia) + "";
                            vh.IMPTD = (decimal.Parse(tsvh.EXPTD) * a.Nhan / a.Chia) + "";
                            vh.C2 = (decimal.Parse(tsvh.C1) * a.Nhan / a.Chia) + "";

                            vh.EXPBT = "0";
                            vh.EXPCD = "0";
                            vh.EXPTD = "0";
                            vh.EXPORTKWH = "0";
                            vh.C1 = "0";
                        }
                        if ((bool)a.IsChieuNhan)
                        {
                            vh.IMPBT = "0";
                            vh.IMPCD = "0";
                            vh.IMPTD = "0";
                            vh.IMPORTKWH = "0";
                            vh.C2 = "0";

                            vh.C1 = (decimal.Parse(tsvh.C2) * a.Nhan / a.Chia) + "";
                            vh.EXPBT = (decimal.Parse(tsvh.IMPBT) * a.Nhan / a.Chia) + "";
                            vh.EXPCD = (decimal.Parse(tsvh.IMPCD) * a.Nhan / a.Chia) + "";
                            vh.EXPTD = (decimal.Parse(tsvh.IMPTD) * a.Nhan / a.Chia) + "";
                            vh.EXPORTKWH = (decimal.Parse(tsvh.IMPORTKWH) * a.Nhan / a.Chia) + "";
                        }
                    }
                }
                else
                {
                    if (!(bool)a.IsChieuGiao && !(bool)a.IsChieuNhan)
                    {
                        vh.C1 = (decimal.Parse(tsvh.C1) * a.Nhan / a.Chia) + "";
                        vh.EXPBT = (decimal.Parse(tsvh.EXPBT) * a.Nhan / a.Chia) + "";
                        vh.EXPCD = (decimal.Parse(tsvh.EXPCD) * a.Nhan / a.Chia) + "";
                        vh.EXPTD = (decimal.Parse(tsvh.EXPTD) * a.Nhan / a.Chia) + "";
                        vh.EXPORTKWH = (decimal.Parse(tsvh.EXPORTKWH) * a.Nhan / a.Chia) + "";

                        vh.IMPBT = (decimal.Parse(tsvh.IMPBT) * a.Nhan / a.Chia) + "";
                        vh.IMPCD = (decimal.Parse(tsvh.IMPCD) * a.Nhan / a.Chia) + "";
                        vh.IMPORTKWH = (decimal.Parse(tsvh.IMPORTKWH) * a.Nhan / a.Chia) + "";
                        vh.IMPTD = (decimal.Parse(tsvh.IMPTD) * a.Nhan / a.Chia) + "";
                        vh.C2 = (decimal.Parse(tsvh.C2) * a.Nhan / a.Chia) + "";
                    }
                    else
                    {
                        if ((bool)a.IsChieuGiao)
                        {
                            vh.IMPBT = (decimal.Parse(tsvh.IMPBT) * a.Nhan / a.Chia) + "";
                            vh.IMPCD = (decimal.Parse(tsvh.IMPCD) * a.Nhan / a.Chia) + "";
                            vh.IMPORTKWH = (decimal.Parse(tsvh.IMPORTKWH) * a.Nhan / a.Chia) + "";
                            vh.IMPTD = (decimal.Parse(tsvh.IMPTD) * a.Nhan / a.Chia) + "";
                            vh.C2 = (decimal.Parse(tsvh.C2) * a.Nhan / a.Chia) + "";

                            vh.EXPBT = "0";
                            vh.EXPCD = "0";
                            vh.EXPTD = "0";
                            vh.EXPORTKWH = "0";
                            vh.C1 = "0";
                        }
                        if ((bool)a.IsChieuNhan)
                        {
                            vh.IMPBT = "0";
                            vh.IMPCD = "0";
                            vh.IMPTD = "0";
                            vh.IMPORTKWH = "0";
                            vh.C2 = "0";

                            vh.C1 = (decimal.Parse(tsvh.C1) * a.Nhan / a.Chia) + "";
                            vh.EXPBT = (decimal.Parse(tsvh.EXPBT) * a.Nhan / a.Chia) + "";
                            vh.EXPCD = (decimal.Parse(tsvh.EXPCD) * a.Nhan / a.Chia) + "";
                            vh.EXPTD = (decimal.Parse(tsvh.EXPTD) * a.Nhan / a.Chia) + "";
                            vh.EXPORTKWH = (decimal.Parse(tsvh.EXPORTKWH) * a.Nhan / a.Chia) + "";
                        }
                    }
                }
                vh.MA_DIEMDO = tsvh.MA_DIEMDO;
                dongbosoLieu(vh, a.MaDiemDo);

            }
        }
        protected void btnDuyet_Click(object sender, EventArgs e)
        {
            try
            {
                MTCSYT.SYS_Session session = (MTCSYT.SYS_Session)Session["SYS_Session"];
                int ma_dviqly = int.Parse(session.User.ma_dviqly + "");
                var lstDDo = db.HD_DiemDoLienKets.ToList().Where(x=>x.IDMaDVIQLY==ma_dviqly).ToList();
                //var lstDDo = db.HD_DiemDoLienKets.Where(x => x.MaDiemDo == "PA1800T000242001").ToList();

                foreach (var a in lstDDo)
                {
                    if (a.DDo != "")
                        DongBoDuLieuKhoEVN(a);

                }
                _DataBind();
            }
            catch (Exception ex)
            {
                ScriptManager.RegisterStartupScript(Page, Page.GetType(), "", "alert('" + ex.Message + "');", true);
            }


        }

        protected void btnXuat_Click(object sender, EventArgs e)
        {
            _DataBind();
            ASPxGridViewExporter1.DataBind();
            ASPxGridViewExporter1.WriteXlsxToResponse();
        }

    }

    public class TSVH
    {
        private string _C1; public string C1 { get { return _C1; } set { _C1 = value; } }
        private string _C2; public string C2 { get { return _C2; } set { _C2 = value; } }
        private string _ENDBILL; public string ENDBILL { get { return _ENDBILL; } set { _ENDBILL = value; } }
        private string _EXPBT; public string EXPBT { get { return _EXPBT; } set { _EXPBT = value; } }
        private string _EXPCD; public string EXPCD { get { return _EXPCD; } set { _EXPCD = value; } }
        private string _EXPORTKWH; public string EXPORTKWH { get { return _EXPORTKWH; } set { _EXPORTKWH = value; } }
        private string _EXPTD; public string EXPTD { get { return _EXPTD; } set { _EXPTD = value; } }
        private string _IMPBT; public string IMPBT { get { return _IMPBT; } set { _IMPBT = value; } }
        private string _IMPCD; public string IMPCD { get { return _IMPCD; } set { _IMPCD = value; } }
        private string _IMPORTKWH; public string IMPORTKWH { get { return _IMPORTKWH; } set { _IMPORTKWH = value; } }
        private string _IMPTD; public string IMPTD { get { return _IMPTD; } set { _IMPTD = value; } }
        private string _MA_DIEMDO; public string MA_DIEMDO { get { return _MA_DIEMDO; } set { _MA_DIEMDO = value; } }
        private string _SERIALID; public string SERIALID { get { return _SERIALID; } set { _SERIALID = value; } }
        private string _TEN_DIEMDO; public string TEN_DIEMDO { get { return _TEN_DIEMDO; } set { _TEN_DIEMDO = value; } }
    }
}