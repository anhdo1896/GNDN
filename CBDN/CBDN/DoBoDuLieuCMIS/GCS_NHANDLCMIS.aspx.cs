using System;
using System.Collections.Generic;
using SystemManageService;
using DevExpress.Web.ASPxTreeList;
using Entity;
using System.Linq;
using System.Web.UI;
using System.IO;
using System.Data.OleDb;
using System.Data;
using System.Net;
using System.Xml;
using System.Text;
using System.ComponentModel;
namespace MTCSYT.GCS_ONLINE
{
    public partial class GCS_NHANDLCMIS : BasePage
    {
        CBDN.DB_CBDNDataContext dbSQL = new CBDN.DB_CBDNDataContext(new CBDN.ADOController().strcn());
        private const string funcid = "97";
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
                string strMadviqly = session.User.ma_dviqly;
                loadDSNgay();

            }
            if (rdImportDuLieu.SelectedIndex == 0)
            {
                grdCN.Visible = false;
                Label23.Text = "Chọn đường dẫn";
                fileUp.Visible = true;
                btnImport.Text = "Import dữ liệu";
                btnHuyNhan.Text = "Hủy nhận file";
            }
            else
            {
                grdCN.Visible = true;
                Label23.Text = "";
                fileUp.Visible = false;
                btnImport.Text = "Đồng bộ dữ liệu";
                btnHuyNhan.Text = "Xuất dữ liệu";
                loadDLDongBo();
            }
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
        protected void grdCN_Callback(object sender, EventArgs e)
        {

        }

        protected void grdCN_CustomCallback(object sender, DevExpress.Web.ASPxGridViewCustomCallbackEventArgs e)
        {
        }

        protected void grdCN_CustomColumnDisplayText(object sender, DevExpress.Web.ASPxGridViewColumnDisplayTextEventArgs e)
        {
            if (e.Column.Caption == "STT")
            {
                e.DisplayText = (e.VisibleRowIndex + 1).ToString();
            }
        }

        public string UploadFile()
        {
            string strTenFile = "";
            try
            {

                if (!Directory.Exists(Server.MapPath("~/") + "FileGCSCMIS"))
                    Directory.CreateDirectory(Server.MapPath("~/") + "FileGCSCMIS");
                if (!File.Exists(Server.MapPath("~/") + "FileGCSCMIS\\" + fileUp.FileName))
                {
                    strTenFile = DateTime.Today.Day + DateTime.Today.Hour + DateTime.Today.Second + fileUp.FileName;
                    fileUp.PostedFile.SaveAs(Server.MapPath("~/") + "FileGCSCMIS\\" + strTenFile);
                }
                else
                {
                    fileUp.PostedFile.SaveAs(Server.MapPath("~/") + "FileGCSCMIS\\" + fileUp.FileName);
                    strTenFile = fileUp.FileName;
                }
                hdTenFile.Value = strTenFile;
            }
            catch (Exception exp)
            {
                ScriptManager.RegisterStartupScript(Page, Page.GetType(), "", "alert('" + exp.Message + "');", true);
            }
            return strTenFile;
        }
        private void loadDLDongBo()
        {
            SYS_Session session = (SYS_Session)Session["SYS_Session"];
            string strMadviqly = session.User.ma_dviqly;

            DM_DVQLYService isyOrganizationService = new DM_DVQLYService();
            Entity.DM_DVQLY sysOrganization = new Entity.DM_DVQLY();

            sysOrganization = isyOrganizationService.SelectDM_DVQLY(int.Parse(strMadviqly));
            var lst = dbSQL.CMIS_DDoGCs.Where(x => x.MA_DVIQLY == sysOrganization.MA_DVIQLY && x.THANG == int.Parse(cmbThang.Value + "") && x.NAM == int.Parse(cmbNam.Value + "") && x.TrangThaiDongBo == 1);

            grdCN.DataSource = lst;
            grdCN.DataBind();
        }
        protected void btnXuatFile_Click(object sender, EventArgs e)
        {
            if (rdImportDuLieu.SelectedIndex == 0)
            {
                try
                {
                    SYS_Session session = (SYS_Session)Session["SYS_Session"];
                    string strMadviqly = session.User.ma_dviqly;
                    DataSet dsTem = new DataSet();

                    DataAccess.dbGCS dataA = new DataAccess.dbGCS();
                    dsTem.ReadXml(Server.MapPath("~/") + "FileGCSCMIS\\" + UploadFile(), XmlReadMode.InferSchema);

                    for (int i = 0; i < dsTem.Tables[0].Rows.Count; i++)
                    {

                        CBDN.CMIS_DDoGC ddo = new CBDN.CMIS_DDoGC();
                        CBDN.CMIS_DDoGC kiemtraDDo = new CBDN.CMIS_DDoGC();
                        kiemtraDDo = dbSQL.CMIS_DDoGCs.SingleOrDefault(x => x.MA_DVIQLY == dsTem.Tables[0].Rows[i]["MA_DVIQLY"] + "" && x.MA_DDO == dsTem.Tables[0].Rows[i]["MA_DDO"] + "" && x.THANG == int.Parse(dsTem.Tables[0].Rows[i]["THANG"] + "") && x.NAM == int.Parse(dsTem.Tables[0].Rows[i]["NAM"] + "") && x.LOAI_BCS == dsTem.Tables[0].Rows[i]["LOAI_BCS"] + "");
                        if (kiemtraDDo == null)
                        {
                            ddo.MA_NVGCS = dsTem.Tables[0].Rows[i]["MA_NVGCS"] + "";
                            ddo.BOCSO_ID = dsTem.Tables[0].Rows[i]["BOCSO_ID"] + "";
                            ddo.CHUOI_GIA = dsTem.Tables[0].Rows[i]["CHUOI_GIA"] + "";
                            ddo.CS_CU = decimal.Parse(dsTem.Tables[0].Rows[i]["CS_CU"] + "");
                            ddo.CS_MOI = decimal.Parse(dsTem.Tables[0].Rows[i]["CS_MOI"] + "");
                            ddo.DIA_CHI = dsTem.Tables[0].Rows[i]["DIA_CHI"] + "";
                            ddo.HSN = decimal.Parse(dsTem.Tables[0].Rows[i]["HSN"] + "");
                            ddo.KIMUA_CSPK = decimal.Parse(dsTem.Tables[0].Rows[i]["KIMUA_CSPK"] + "");
                            ddo.KY = int.Parse(dsTem.Tables[0].Rows[i]["KY"] + "");
                            ddo.LOAI_BCS = dsTem.Tables[0].Rows[i]["LOAI_BCS"] + "";

                            ddo.LOAI_CS = dsTem.Tables[0].Rows[i]["LOAI_CS"] + "";
                            ddo.MA_CNANG = "";
                            ddo.MA_COT = dsTem.Tables[0].Rows[i]["MA_COT"] + "";
                            ddo.MA_CTO = dsTem.Tables[0].Rows[i]["MA_CTO"] + "";
                            ddo.MA_DDO = dsTem.Tables[0].Rows[i]["MA_DDO"] + "";
                            ddo.MA_DVIQLY = dsTem.Tables[0].Rows[i]["MA_DVIQLY"] + "";
                            ddo.MA_GC = dsTem.Tables[0].Rows[i]["MA_GC"] + "";
                            ddo.MA_KHANG = dsTem.Tables[0].Rows[i]["MA_KHANG"] + "";
                            ddo.MA_NVGCS = dsTem.Tables[0].Rows[i]["MA_NVGCS"] + "";
                            ddo.MA_NVIEN = "";
                            ddo.MA_SOGCS = dsTem.Tables[0].Rows[i]["MA_QUYEN"] + "";
                            ddo.MA_TRAM = dsTem.Tables[0].Rows[i]["MA_TRAM"] + "";
                            ddo.NAM = int.Parse(dsTem.Tables[0].Rows[i]["NAM"] + "");
                            ddo.NGAY_CU = DateTime.Parse(dsTem.Tables[0].Rows[i]["NGAY_CU"] + "");
                            ddo.NGAY_MOI = DateTime.Parse(dsTem.Tables[0].Rows[i]["NGAY_MOI"] + "");
                            ddo.NGAY_PMAX = DateTime.Parse(dsTem.Tables[0].Rows[i]["NGAY_PMAX"] + "");
                            ddo.NGUOI_GCS = dsTem.Tables[0].Rows[i]["NGUOI_GCS"] + "";
                            ddo.PMAX = decimal.Parse(dsTem.Tables[0].Rows[i]["PMAX"] + "");
                            ddo.SERY_CTO = dsTem.Tables[0].Rows[i]["SERY_CTO"] + "";
                            ddo.SL_MOI = decimal.Parse(dsTem.Tables[0].Rows[i]["SL_MOI"] + "");
                            ddo.SL_THAO = decimal.Parse(dsTem.Tables[0].Rows[i]["SL_THAO"] + "");
                            ddo.SL_TTIEP = decimal.Parse(dsTem.Tables[0].Rows[i]["SL_TTIEP"] + "");
                            ddo.SLUONG_1 = decimal.Parse(dsTem.Tables[0].Rows[i]["SLUONG_1"] + "");
                            ddo.SLUONG_2 = decimal.Parse(dsTem.Tables[0].Rows[i]["SLUONG_2"] + "");
                            ddo.SLUONG_3 = decimal.Parse(dsTem.Tables[0].Rows[i]["SLUONG_3"] + "");
                            ddo.SO_HO = int.Parse(dsTem.Tables[0].Rows[i]["SO_HO"] + "");
                            ddo.SO_HOM = dsTem.Tables[0].Rows[i]["SO_HOM"] + "";
                            ddo.TEN_KHANG = dsTem.Tables[0].Rows[i]["TEN_KHANG"] + "";
                            ddo.THANG = int.Parse(dsTem.Tables[0].Rows[i]["THANG"] + "");
                            ddo.TTR_CU = dsTem.Tables[0].Rows[i]["TTR_MOI"] + "";
                            ddo.TENFILE = fileUp.FileName;
                            dbSQL.CMIS_DDoGCs.InsertOnSubmit(ddo);
                            dbSQL.SubmitChanges();
                        }



                    }
                    ScriptManager.RegisterStartupScript(Page, Page.GetType(), "", "alert('Nhận dữ liệu thành công');", true);

                }
                catch (Exception ex)
                {
                    ScriptManager.RegisterStartupScript(Page, Page.GetType(), "", "alert('Lỗi nhận dữ liệu: " + ex.Message + "');", true);
                }
            }
            else
            {
                SYS_Session session = (SYS_Session)Session["SYS_Session"];
                string strMadviqly = session.User.ma_dviqly;

                DM_DVQLYService _DM_DVQLY = new DM_DVQLYService();
                var dv = _DM_DVQLY.SelectDM_DVQLY(int.Parse(strMadviqly));

                var lst = dbSQL.CMIS_DDoGCs.Where(x => x.MA_DVIQLY == dv.MA_DVIQLY && x.THANG == int.Parse(cmbThang.Value + "") && x.NAM == int.Parse(cmbNam.Value + ""));
                foreach (var ddo in lst)
                {
                    var diemdo = dbSQL.DM_DiemDos.SingleOrDefault(x => x.MaDiemDo == ddo.MA_DDO && x.HoatDong == 1);
                    if (diemdo == null) continue;
                    var kiemtra = dbSQL.DM_CongTos.SingleOrDefault(x => x.IDDiemDo == diemdo.IDDiemDo + "" && x.TinhTrang == 1);
                    if (kiemtra == null) continue;
                    var hhddo = dbSQL.HD_GiaoNhanThangs.SingleOrDefault(x => x.IDCongTo == kiemtra.IDCongTo + "" && x.Thang == int.Parse(cmbThang.Value + "") && x.Nam == int.Parse(cmbNam.Value + ""));
                    if (hhddo == null) continue;

                    if (ddo.LOAI_BCS == "BT")
                    {
                        var diemdocmis = dbSQL.CMIS_DDoGCs.SingleOrDefault(x => x.MA_DVIQLY == dv.MA_DVIQLY && x.THANG == int.Parse(cmbThang.Value + "") && x.NAM == int.Parse(cmbNam.Value + "") && x.MA_DDO == diemdo.MaDiemDo && x.LOAI_BCS == "BT");

                        diemdocmis.CS_MOI = hhddo.Giao_Bieu1_Cuoi;
                        diemdocmis.SL_MOI = hhddo.Giao_Bieu1_SanLuong;
                        diemdocmis.TrangThaiDongBo = 1;
                        dbSQL.SubmitChanges();
                    }
                    else if (ddo.LOAI_BCS == "CD")
                    {
                        var diemdocmis = dbSQL.CMIS_DDoGCs.SingleOrDefault(x => x.MA_DVIQLY == dv.MA_DVIQLY && x.THANG == int.Parse(cmbThang.Value + "") && x.NAM == int.Parse(cmbNam.Value + "") && x.MA_DDO == diemdo.MaDiemDo && x.LOAI_BCS == "CD");

                        diemdocmis.CS_MOI = hhddo.Giao_Bieu2_Cuoi;
                        diemdocmis.SL_MOI = hhddo.Giao_Bieu2_SanLuong;
                        diemdocmis.TrangThaiDongBo = 1;
                        dbSQL.SubmitChanges();
                    }
                    else if (ddo.LOAI_BCS == "TD")
                    {
                        var diemdocmis = dbSQL.CMIS_DDoGCs.SingleOrDefault(x => x.MA_DVIQLY == dv.MA_DVIQLY && x.THANG == int.Parse(cmbThang.Value + "") && x.NAM == int.Parse(cmbNam.Value + "") && x.MA_DDO == diemdo.MaDiemDo && x.LOAI_BCS == "TD");

                        diemdocmis.CS_MOI = hhddo.Giao_Bieu3_Cuoi;
                        diemdocmis.SL_MOI = hhddo.Giao_Bieu3_SanLuong;
                        diemdocmis.TrangThaiDongBo = 1;
                        dbSQL.SubmitChanges();
                    }
                    else if (ddo.LOAI_BCS == "VC")
                    {
                        var diemdocmis = dbSQL.CMIS_DDoGCs.SingleOrDefault(x => x.MA_DVIQLY == dv.MA_DVIQLY && x.THANG == int.Parse(cmbThang.Value + "") && x.NAM == int.Parse(cmbNam.Value + "") && x.MA_DDO == diemdo.MaDiemDo && x.LOAI_BCS == "VC");

                        diemdocmis.CS_MOI = hhddo.Giao_Q_Cuoi;
                        diemdocmis.SL_MOI = hhddo.Giao_Q_SanLuong;
                        diemdocmis.TrangThaiDongBo = 1;
                        dbSQL.SubmitChanges();
                    }

                    if (ddo.LOAI_BCS == "BN")
                    {
                        var diemdocmis = dbSQL.CMIS_DDoGCs.SingleOrDefault(x => x.MA_DVIQLY == dv.MA_DVIQLY && x.THANG == int.Parse(cmbThang.Value + "") && x.NAM == int.Parse(cmbNam.Value + "") && x.MA_DDO == diemdo.MaDiemDo && x.LOAI_BCS == "BN");

                        diemdocmis.CS_MOI = hhddo.Nhan_Bieu1_Cuoi;
                        diemdocmis.SL_MOI = hhddo.Nhan_Bieu1_SanLuong;
                        diemdocmis.TrangThaiDongBo = 1;
                        dbSQL.SubmitChanges();
                    }
                    else if (ddo.LOAI_BCS == "CN")
                    {
                        var diemdocmis = dbSQL.CMIS_DDoGCs.SingleOrDefault(x => x.MA_DVIQLY == dv.MA_DVIQLY && x.THANG == int.Parse(cmbThang.Value + "") && x.NAM == int.Parse(cmbNam.Value + "") && x.MA_DDO == diemdo.MaDiemDo && x.LOAI_BCS == "CN");

                        diemdocmis.CS_MOI = hhddo.Nhan_Bieu2_Cuoi;
                        diemdocmis.SL_MOI = hhddo.Nhan_Bieu2_SanLuong;
                        diemdocmis.TrangThaiDongBo = 1;
                        dbSQL.SubmitChanges();
                    }
                    else if (ddo.LOAI_BCS == "TN")
                    {
                        var diemdocmis = dbSQL.CMIS_DDoGCs.SingleOrDefault(x => x.MA_DVIQLY == dv.MA_DVIQLY && x.THANG == int.Parse(cmbThang.Value + "") && x.NAM == int.Parse(cmbNam.Value + "") && x.MA_DDO == diemdo.MaDiemDo && x.LOAI_BCS == "TN");

                        diemdocmis.CS_MOI = hhddo.Nhan_Bieu3_Cuoi;
                        diemdocmis.SL_MOI = hhddo.Nhan_Bieu3_SanLuong;
                        diemdocmis.TrangThaiDongBo = 1;
                        dbSQL.SubmitChanges();
                    }
                    else if (ddo.LOAI_BCS == "VN")
                    {
                        var diemdocmis = dbSQL.CMIS_DDoGCs.SingleOrDefault(x => x.MA_DVIQLY == dv.MA_DVIQLY && x.THANG == int.Parse(cmbThang.Value + "") && x.NAM == int.Parse(cmbNam.Value + "") && x.MA_DDO == diemdo.MaDiemDo && x.LOAI_BCS == "VN");

                        diemdocmis.CS_MOI = hhddo.Nhan_Q_Cuoi;
                        diemdocmis.SL_MOI = hhddo.Nhan_Q_SanLuong;
                        diemdocmis.TrangThaiDongBo = 1;
                        dbSQL.SubmitChanges();
                    }
                }
                ScriptManager.RegisterStartupScript(Page, Page.GetType(), "", "alert('Đồng bộ số liệu thành công');", true);
                loadDLDongBo();
            }

        }
        protected void btnHuyNhan_Click(object sender, EventArgs e)
        {
            SYS_Session session = (SYS_Session)Session["SYS_Session"];
            string strMadviqly = session.User.ma_dviqly;

            DM_DVQLYService isyOrganizationService = new DM_DVQLYService();
            Entity.DM_DVQLY sysOrganization = new Entity.DM_DVQLY();

            sysOrganization = isyOrganizationService.SelectDM_DVQLY(int.Parse(strMadviqly));

            if (rdImportDuLieu.SelectedIndex == 0)
            {

            }
            else
            {
                var lstData = dbSQL.CMIS_DDoGCs.Where(x => x.MA_DVIQLY == sysOrganization.MA_DVIQLY && x.THANG == int.Parse(cmbThang.Value + "") && x.NAM == int.Parse(cmbNam.Value + ""));

                string tenfile = "";
                foreach (var a in lstData)
                {
                    tenfile = a.TENFILE;
                    break;
                }
                Class.XuatXML_GCS class_xuatso = new Class.XuatXML_GCS();
                DataSet ds = new DataSet();
                CBDN.ConvertListToTable cv = new CBDN.ConvertListToTable();
                DataTable dt = cv.ConvertToDataTable(lstData.ToList());
                dt.Columns.Remove("TENFILE");
                dt.Columns.Remove("TrangThaiDongBo");
                ds.Tables.Add(dt);
                string strXML = class_xuatso.HTML_XuatFileCMIS();
                string strXML1 = ds.GetXml();
                //strXML1 = strXML1.Replace(",", ".");
                strXML1 = strXML1.Replace("<NewDataSet>", "");
                strXML1 = strXML1.Replace("</NewDataSet>", "");
                strXML1 = strXML1.Replace("<Table>", "<Table1>");
                strXML1 = strXML1.Replace("</Table>", "</Table1>");
                strXML += strXML1 + "</NewDataSet>";

                string attachment = "attachment;filename=" + tenfile + ".XML";
                Response.ClearContent();
                Response.ContentType = "application/xml";
                Response.AddHeader("content-disposition", attachment);
                Response.Write(strXML);

                Response.End();
            }
        }

    }
}