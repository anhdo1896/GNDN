using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.IO;
using Aspose.Cells;
namespace MTCSYT.GCS_ONLINE
{
    public partial class ImportCMIS : System.Web.UI.Page
    {
        DataAccess.clTTTT dbTT = new DataAccess.clTTTT();
        CBDN.DB_CBDNDataContext db = new CBDN.DB_CBDNDataContext(new CBDN.ADOController().strcn());
        private Cells _range;
        private Worksheet _exSheet;
        DataTable dtData = new DataTable();
        DataTable dsData = new DataTable();
        private const string funcid = "113";
        protected void Page_Load(object sender, EventArgs e)
        {
            Session["Data"] = null;
        }

        public string UploadFile()
        {
            string strTenFile = "";
            try
            {

                if (!Directory.Exists(Server.MapPath("~/") + "DongBoCMIS"))
                    Directory.CreateDirectory(Server.MapPath("~/") + "DongBoCMIS");
                if (!File.Exists(Server.MapPath("~/") + "DongBoCMIS\\" + fileUp.FileName))
                {
                    strTenFile = DateTime.Today.Day + DateTime.Today.Hour + DateTime.Today.Second + fileUp.FileName;
                    fileUp.PostedFile.SaveAs(Server.MapPath("~/") + "DongBoCMIS\\" + strTenFile);
                }
                else
                {
                    fileUp.PostedFile.SaveAs(Server.MapPath("~/") + "DongBoCMIS\\" + fileUp.FileName);
                    strTenFile = fileUp.FileName;
                }
                hdTenFile.Value = strTenFile;
            }
            catch (Exception exp)
            {
                ScriptManager.RegisterStartupScript(Page, Page.GetType(), "", "alert('" + exp.Message + Server.MapPath("~/") + "DongBoCMIS\\" + hdTenFile.Value + "');", true);
            }
            return strTenFile;
        }
        public DataTable GetData()
        {
            

            dtData = new DataTable();
            dtData.Columns.Add("STT");
            dtData.Columns.Add("MaDiemDo");
            dtData.Columns.Add("TenDiemDo");
            dtData.Columns.Add("MaTram");
            dtData.Columns.Add("MaLo");
            dtData.Columns.Add("BoChiSo");
            dtData.Columns.Add("MaSoGCS");
            dtData.Columns.Add("MaCongTo");
            dtData.Columns.Add("SoCongTo");
            dtData.Columns.Add("SoPha");
            dtData.Columns.Add("HeSoNhan");
            dtData.Columns.Add("NgayDauKy");
            dtData.Columns.Add("NgayCuoiKy");
            dtData.Columns.Add("ChiSoCu");
            dtData.Columns.Add("ChiSoMoi");
            dtData.Columns.Add("TinhTrang");
            dtData.Columns.Add("DienTieuThu");
            dtData.Columns.Add("SL");
            dtData.Columns.Add("SLThao");
            dtData.Columns.Add("TongCong"); 

            #region Chuẩn bị tệp excel mẫu để ghi dữ liệu

            string destFile = Server.MapPath("~/") + "DongBoCMIS\\" + hdTenFile.Value;
            string ten = hdTenFile.Value;
            int Lchuoi = ten.Length;
            int c = ten.LastIndexOf(".");
            string duoi = ten.Substring(c + 1, Lchuoi - c - 1);

            string sTemplate = (destFile);
            if (duoi == "xls")
            {

                Workbook exBook = new Workbook();
                exBook.Open(sTemplate, FileFormatType.Excel2003);
                _exSheet = exBook.Worksheets[0];
                _range = _exSheet.Cells;
            }
            if(duoi == "xlsx")
            {
                Workbook exBook = new Workbook();
                exBook.Open(sTemplate, FileFormatType.Excel2007Xlsx);
                _exSheet = exBook.Worksheets[0];
                _range = _exSheet.Cells;
            }
                
            #endregion


            for (int i = 1; i < _range.Rows.Count; i++)
            {
                dtData.Rows.Add(_range[i, 0].StringValue, _range[i, 1].StringValue, _range[i, 2].StringValue, _range[i, 3].StringValue, _range[i, 4].StringValue, _range[i, 5].StringValue, _range[i, 6].StringValue, _range[i, 7].StringValue,
                    _range[i, 8].StringValue, _range[i, 9].StringValue, _range[i, 10].StringValue, _range[i, 11].StringValue, _range[i, 12].StringValue, _range[i, 13].StringValue, _range[i, 14].StringValue, _range[i, 15].StringValue,
                    _range[i, 16].StringValue, _range[i, 17].StringValue, _range[i, 18].StringValue, _range[i, 19].StringValue);
            }
            return dtData;
        }

        protected void btnXem_Click(object sender, EventArgs e)
        {
            if (fileUp.FileName != "")
            {
                UploadFile();
                dtData = GetData();
                grvView.DataSource = dtData;
                grvView.DataBind();
                btnConvert.Enabled = true;
            }
            else
            {
                hdTenFile.Value = "";
            }
        }

        protected void grvView_PageIndexChanged(object sender, EventArgs e)
        {
            dtData = GetData();
            grvView.DataSource = dtData;
            grvView.DataBind();

        }

        protected void btnConvert_Click(object sender, EventArgs e)
        {
            dtData = GetData();
           if(dtData != null)
            {     
            dsData = new DataTable();
            #region khai bao bang
            dsData.Columns.Add("MaDiemDo");
            dsData.Columns.Add("Thang");
            dsData.Columns.Add("Nam");
            dsData.Columns.Add("Giao_P_Cuoi");
            dsData.Columns.Add("Nhan_P_Cuoi");
            dsData.Columns.Add("Giao_Q_Cuoi");
            dsData.Columns.Add("Nhan_Q_Cuoi");
            dsData.Columns.Add("Giao_Bieu1_Cuoi");
            dsData.Columns.Add("Nhan_Bieu1_Cuoi");
            dsData.Columns.Add("Giao_Bieu2_Cuoi");
            dsData.Columns.Add("Nhan_Bieu2_Cuoi");
            dsData.Columns.Add("Giao_Bieu3_Cuoi");
            dsData.Columns.Add("Nhan_Bieu3_Cuoi");
            #endregion


            DataTable dsdiemdo = new DataTable();
            dsdiemdo.Columns.Add("MaDiemDo");
            int b = dtData.Rows.Count;
            int d = 0;
            for (int i = 0; i < b; i++)
            {
                int c = dsdiemdo.Rows.Count;
                var check2 = dtData.Rows[i]["MaDiemDo"] + "";
                    var checkhong = dtData.Rows[i]["TinhTrang"] + "";
                    if (checkhong != "H")
                    {
                        if (c > 0)
                        {
                            for (int j = 0; j < c; j++)
                            {
                                var check = dsdiemdo.Rows[j]["MaDiemDo"] + "";

                                if (check2 == check)
                                {
                                    d++;
                                }
                            }
                        }
                        if (d == 0)
                        {
                            dsdiemdo.Rows.Add(check2);
                        }
                        d = 0;
                    }
            }

            int a = dsdiemdo.Rows.Count;
            int a1 = dtData.Rows.Count;
            for (int i = 0; i < a; i++)
            {
                #region Khoi tao gia tri diem do
                decimal Giao_P_Cuoi = 0;
                decimal Nhan_P_Cuoi = 0;

                decimal Giao_Q_Cuoi = 0;

                decimal Nhan_Q_Cuoi = 0;

                decimal Giao_Bieu1_Cuoi = 0;

                decimal Nhan_Bieu1_Cuoi = 0;

                decimal Giao_Bieu2_Cuoi = 0;

                decimal Nhan_Bieu2_Cuoi = 0;

                decimal Giao_Bieu3_Cuoi = 0;

                decimal Nhan_Bieu3_Cuoi = 0;
                #endregion


                var checkdiemdo = dsdiemdo.Rows[i]["MaDiemDo"] + "";

                string thang = "";
                string nam = "";
                string madiemdo = "";
                for (int j = 0; j < a1; j++)
                {
                    madiemdo = dtData.Rows[j]["MaDiemDo"] + "";
                    string bcs = dtData.Rows[j]["BoChiSo"] + "";
                    if (madiemdo == checkdiemdo)
                    {
                        madiemdo = dtData.Rows[j]["MaDiemDo"] + "";
                        string ngay = dtData.Rows[j]["NgayDauKy"] + "";
                        thang = ngay.Substring(3, 2);
                        nam = ngay.Substring(6, 4); 
                        var checkhong = dtData.Rows[j]["TinhTrang"] + "";
                            if (checkhong != "H")
                            {
                                decimal csm = 0;
                                if (dtData.Rows[j]["ChiSoMoi"] + ""!="")
                                {
                                    csm = decimal.Parse(dtData.Rows[j]["ChiSoMoi"].ToString().Replace(".",","));
                                }

                                if (bcs == "BT")
                                {
                                   
                                    Giao_Bieu1_Cuoi = csm;
                                }
                                if (bcs == "CD")
                                {
                                    Giao_Bieu2_Cuoi = csm;
                                }
                                if (bcs == "TD")
                                {
                                    Giao_Bieu3_Cuoi = csm;
                                }
                                if (bcs == "SG")
                                {
                                    Giao_P_Cuoi = csm;
                                }
                                if (bcs == "VC")
                                {
                                    Giao_Q_Cuoi = csm;
                                }

                                if (bcs == "BN")
                                {
                                    Nhan_Bieu1_Cuoi = csm;

                                }
                                if (bcs == "CN")
                                {
                                    Nhan_Bieu2_Cuoi = csm;
                                }
                                if (bcs == "TN")
                                {
                                    Nhan_Bieu3_Cuoi = csm;
                                }
                                if (bcs == "SN")
                                {
                                    Nhan_P_Cuoi = csm;
                                }
                                if (bcs == "VN")
                                {
                                    Nhan_Q_Cuoi = csm;

                                }
                            }
                    }
                }
                dsData.Rows.Add(checkdiemdo, thang, nam, Giao_P_Cuoi, Nhan_P_Cuoi,
                    Giao_Q_Cuoi, Nhan_Q_Cuoi, Giao_Bieu1_Cuoi, Nhan_Bieu1_Cuoi, Giao_Bieu2_Cuoi, Nhan_Bieu2_Cuoi,
                    Giao_Bieu3_Cuoi, Nhan_Bieu3_Cuoi);
            }
            int bdem = dsData.Rows.Count;
            int adem = 0;

                for (int i = 0; i < bdem; i++)
                {
                    try
                    {

                        decimal Giao_Bieu1_Cuoi = decimal.Parse(dsData.Rows[i]["Giao_Bieu1_Cuoi"] + "");
                        decimal Giao_Bieu2_Cuoi = decimal.Parse(dsData.Rows[i]["Giao_Bieu2_Cuoi"] + "");
                        decimal Giao_Bieu3_Cuoi = decimal.Parse(dsData.Rows[i]["Giao_Bieu3_Cuoi"] + "");
                        decimal Giao_P_Cuoi = decimal.Parse(dsData.Rows[i]["Giao_P_Cuoi"] + "");
                        decimal Giao_Q_Cuoi = decimal.Parse(dsData.Rows[i]["Giao_Q_Cuoi"] + "");

                        decimal Nhan_Bieu1_Cuoi = decimal.Parse(dsData.Rows[i]["Nhan_Bieu1_Cuoi"] + "");
                        decimal Nhan_Bieu2_Cuoi = decimal.Parse(dsData.Rows[i]["Nhan_Bieu2_Cuoi"] + "");
                        decimal Nhan_Bieu3_Cuoi = decimal.Parse(dsData.Rows[i]["Nhan_Bieu3_Cuoi"] + "");
                        decimal Nhan_P_Cuoi = decimal.Parse(dsData.Rows[i]["Nhan_P_Cuoi"] + "");
                        decimal Nhan_Q_Cuoi = decimal.Parse(dsData.Rows[i]["Nhan_Q_Cuoi"] + "");
                       
                        var MaDiemDo = dsData.Rows[i]["MaDiemDo"] + "";
                        var Thang = int.Parse(dsData.Rows[i]["Thang"] + "");
                        var Nam = int.Parse(dsData.Rows[i]["Nam"] + "");

                        var lstHD = db.LayThongTinGiaoNhanQuaMaDD(MaDiemDo, Thang, Nam);
                        adem++;

                        foreach (var hd in lstHD)
                        {

                            CBDN.HD_GiaoNhanThang chitiet = db.HD_GiaoNhanThangs.SingleOrDefault(x => x.ID == hd.ID && x.ISNhanVien != true);
                            if (chitiet == null) continue;
                            var diemdo = db.DM_DiemDos.SingleOrDefault(x => x.MaDiemDo == MaDiemDo);

                            var congto = db.DM_CongTos.SingleOrDefault(x => x.IDDiemDo == diemdo.IDDiemDo + "" && x.TinhTrang == 1);
                            if (congto == null) continue;
                            var tram = db.DM_Trams.SingleOrDefault(x => x.IDTram == int.Parse(diemdo.IDTram));
                            var ID = congto.IDCongTo;
                            var idDuongday = diemdo.IDChiNhanh;
                            var idtram = tram.IDTram;

                            if (chitiet != null)
                            {
                                chitiet.Giao_Bieu1_Cuoi = decimal.Parse("" + Giao_Bieu1_Cuoi);
                                chitiet.Nhan_Bieu1_Cuoi = decimal.Parse("" + Nhan_Bieu1_Cuoi);

                                if (decimal.Parse("" + Giao_Bieu1_Cuoi) < chitiet.Giao_Bieu1_Dau)
                                    chitiet.Giao_Bieu1_SanLuong = (soLon(chitiet.Giao_Bieu1_Dau + "") - chitiet.Giao_Bieu1_Dau + decimal.Parse("" + Giao_Bieu1_Cuoi)) * congto.HeSoNhan * congto.HeSoQuyDoi;
                                else
                                    chitiet.Giao_Bieu1_SanLuong = (decimal.Parse("" + Giao_Bieu1_Cuoi) - chitiet.Giao_Bieu1_Dau) * congto.HeSoNhan * congto.HeSoQuyDoi;
                                if (decimal.Parse("" + Nhan_Bieu1_Cuoi) < chitiet.Nhan_Bieu1_Dau)
                                    chitiet.Nhan_Bieu1_SanLuong = (soLon(chitiet.Nhan_Bieu1_Dau + "") - chitiet.Nhan_Bieu1_Dau + decimal.Parse("" + Nhan_Bieu1_Cuoi)) * congto.HeSoNhan * congto.HeSoQuyDoi;
                                else
                                    chitiet.Nhan_Bieu1_SanLuong = (decimal.Parse("" + Nhan_Bieu1_Cuoi) - chitiet.Nhan_Bieu1_Dau) * congto.HeSoNhan * congto.HeSoQuyDoi;

                                chitiet.Giao_Bieu2_Cuoi = decimal.Parse("" + Giao_Bieu2_Cuoi);
                                chitiet.Nhan_Bieu2_Cuoi = decimal.Parse("" + Nhan_Bieu2_Cuoi);
                                if (decimal.Parse("" + Giao_Bieu2_Cuoi) < chitiet.Giao_Bieu2_Dau)
                                    chitiet.Giao_Bieu2_SanLuong = (soLon(chitiet.Giao_Bieu2_Dau + "") - chitiet.Giao_Bieu2_Dau + decimal.Parse("" + Giao_Bieu2_Cuoi)) * congto.HeSoNhan * congto.HeSoQuyDoi;
                                else
                                    chitiet.Giao_Bieu2_SanLuong = (decimal.Parse("" + Giao_Bieu2_Cuoi) - chitiet.Giao_Bieu2_Dau) * congto.HeSoNhan * congto.HeSoQuyDoi;

                                if (decimal.Parse("" + Nhan_Bieu2_Cuoi) < chitiet.Nhan_Bieu2_Dau)
                                    chitiet.Nhan_Bieu2_SanLuong = (soLon(chitiet.Nhan_Bieu2_Dau + "") - chitiet.Nhan_Bieu2_Dau + decimal.Parse("" + Nhan_Bieu2_Cuoi)) * congto.HeSoNhan * congto.HeSoQuyDoi;
                                else
                                    chitiet.Nhan_Bieu2_SanLuong = (decimal.Parse("" + Nhan_Bieu2_Cuoi) - chitiet.Nhan_Bieu2_Dau) * congto.HeSoNhan * congto.HeSoQuyDoi;

                                chitiet.Giao_Bieu3_Cuoi = decimal.Parse("" + Giao_Bieu3_Cuoi);
                                chitiet.Nhan_Bieu3_Cuoi = decimal.Parse("" + Nhan_Bieu3_Cuoi);
                                if (decimal.Parse("" + Giao_Bieu3_Cuoi) < chitiet.Giao_Bieu3_Dau)
                                    chitiet.Giao_Bieu3_SanLuong = (soLon(chitiet.Giao_Bieu3_Dau + "") - chitiet.Giao_Bieu3_Dau + decimal.Parse("" + Giao_Bieu3_Cuoi)) * congto.HeSoNhan * congto.HeSoQuyDoi;
                                else
                                    chitiet.Giao_Bieu3_SanLuong = (decimal.Parse("" + Giao_Bieu3_Cuoi) - chitiet.Giao_Bieu3_Dau) * congto.HeSoNhan * congto.HeSoQuyDoi;
                                if (decimal.Parse("" + Nhan_Bieu3_Cuoi) < chitiet.Nhan_Bieu3_Dau)
                                    chitiet.Nhan_Bieu3_SanLuong = (soLon(chitiet.Nhan_Bieu3_Dau + "") - chitiet.Nhan_Bieu3_Dau + decimal.Parse("" + Nhan_Bieu3_Cuoi)) * congto.HeSoNhan * congto.HeSoQuyDoi;
                                else
                                    chitiet.Nhan_Bieu3_SanLuong = (decimal.Parse("" + Nhan_Bieu3_Cuoi) - chitiet.Nhan_Bieu3_Dau) * congto.HeSoNhan * congto.HeSoQuyDoi;

                                chitiet.Nhan_P_Cuoi = Math.Round(decimal.Parse(Nhan_P_Cuoi + ""), 3);
                                chitiet.Giao_P_Cuoi = decimal.Parse(Giao_P_Cuoi + "");

                                chitiet.Giao_P_SanLuong = chitiet.Giao_Bieu1_SanLuong + chitiet.Giao_Bieu2_SanLuong + chitiet.Giao_Bieu3_SanLuong;
                                chitiet.Nhan_P_SanLuong = chitiet.Nhan_Bieu1_SanLuong + chitiet.Nhan_Bieu2_SanLuong + chitiet.Nhan_Bieu3_SanLuong;
                             
                                chitiet.Nhan_Q_Cuoi = decimal.Parse("" + Nhan_Q_Cuoi);
                                chitiet.Giao_Q_Cuoi = decimal.Parse("" + Giao_Q_Cuoi);

                                if (decimal.Parse("" + Giao_Q_Cuoi) < chitiet.Giao_Q_Dau)
                                    chitiet.Giao_Q_SanLuong = (soLon(chitiet.Giao_Q_Dau + "") - chitiet.Giao_Q_Dau + decimal.Parse("" + Giao_Q_Cuoi)) * congto.HeSoNhan * congto.HeSoQuyDoi;
                                else
                                    chitiet.Giao_Q_SanLuong = (decimal.Parse("" + Giao_Q_Cuoi) - chitiet.Giao_Q_Dau) * congto.HeSoNhan * congto.HeSoQuyDoi;

                                if (decimal.Parse("" + Nhan_Q_Cuoi) < chitiet.Nhan_Q_Dau)
                                    chitiet.Nhan_Q_SanLuong = (soLon(chitiet.Nhan_Q_Dau + "") - chitiet.Nhan_Q_Dau + decimal.Parse("" + Nhan_Q_Cuoi)) * congto.HeSoNhan * congto.HeSoQuyDoi;
                                else
                                    chitiet.Nhan_Q_SanLuong = (decimal.Parse("" + Nhan_Q_Cuoi) - chitiet.Nhan_Q_Dau) * congto.HeSoNhan * congto.HeSoQuyDoi;

                                if (chitiet.Giao_P_SanLuong != null && chitiet.Giao_P_SanLuong != 0)
                                {
                                    double a2 = (double)chitiet.Giao_Q_SanLuong;
                                    double b2 = (double)chitiet.Giao_P_SanLuong;
                                    chitiet.CosGiao = decimal.Parse("0" + Math.Round(Math.Cos(Math.Atan(a2 / b2)), 3));

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
                                chitiet.LoaiNhap =1;
                                db.SubmitChanges();
                            }
                        }
                        ScriptManager.RegisterStartupScript(Page, Page.GetType(), "", "alert('Import dữ liệu thành công');", true);
                    }


                    catch (Exception ex)
                    {
                        ScriptManager.RegisterStartupScript(Page, Page.GetType(), "", "alert('" + ex.Message + adem + "');", true);
                    }
                }
            }

        }

        protected void grvView_CustomColumnDisplayText(object sender, DevExpress.Web.ASPxGridViewColumnDisplayTextEventArgs e)
        {

            if (e.Column.Caption == "STT")
            {
                e.DisplayText = (e.VisibleRowIndex + 1).ToString();
            }
        }
        private decimal soLon(string chisocu)
        {
            string chuoi = "1";
            for (int i = 0; i < chisocu.Split('.')[0].ToString().Length; i++)
            { chuoi += "0"; }
            return decimal.Parse(chuoi);

        }

    }
}