using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Web;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using SystemManageService;
using System.Linq;
using DevExpress.Web.ASPxClasses;
using DevExpress.Web.ASPxClasses.Internal;
using Entity;
using QLY_VTTB.MasterPage;
using Page = System.Web.UI.Page;
using DevExpress.Web.ASPxGridView;

namespace MTCSYT
{
    public class SYS_Session
    {
        public DM_USER User { get; set; }
        public int langId { get; set; }
        public string CurrentPage { get; set; }
        public int CurrentYear { get; set; }
        public string FuncID { get; set; }
        public SYS_UserConfig UserConfig { get; set; }
        public Entity.DonVi DonVi { get; set; }
        public int PhanLoai { get; set; }

        public int IDOrganiztion { get; set; }
        public int IDOrganiztionCu { get; set; }
        public int IDDMDonVi { get; set; }
        public int Tuyen { get; set; }
        public string TenDonVi { get; set; }

    }

    public class BasePage : System.Web.UI.Page
    {
        private bool CheckFormNhapLieuSo(string RawURL)
        {
            bool ret = false;
            if (RawURL.IndexOf("BaoCaoQLCTYT_CoSoDaoTao.aspx") > 0)
                ret = true;
            else if (RawURL.IndexOf("ChiTietBaoCaoQLCTYT_CoSoDaoTao.aspx") > 0)
                ret = true;
            else if (RawURL.IndexOf("BaoCaoQLCTYT_BenhVien.aspx") > 0)
                ret = true;
            else if (RawURL.IndexOf("ChiTietBaoCaoQLCTYT_BenhVien.aspx") > 0)
                ret = true;
            else if (RawURL.IndexOf("BaoCao_CoSoSX.aspx") > 0)
                ret = true;
            else if (RawURL.IndexOf("ChiTietBaoCao_CoSoSX.aspx") > 0)
                ret = true;
            else if (RawURL.IndexOf("BaoCaoQLCTYT_CoSoYTDP.aspx") > 0)
                ret = true;
            else if (RawURL.IndexOf("ChiTietBaoCaoQLCTYT_CoSoYTDP.aspx") > 0)
                ret = true;
            else if (RawURL.IndexOf("BaoCaoTramYT.aspx") > 0)
                ret = true;
            else if (RawURL.IndexOf("ChiTietBaoCaoTramYT.aspx") > 0)
                ret = true;
            return ret;
        }

        protected void PageLoad()
        {

            SYS_Session session = (SYS_Session)Session["SYS_Session"];

            if (session == null)
            {
                session = new SYS_Session();
                Session["SYS_Session"] = session;
                Response.Redirect("~\\Login.aspx");
            }
            else if (session.User == null)
            {
                session.User = new DM_USER();
                session.User.USERNAME = "Guest";
                session.User.FullName = "Guest";
            }
            if (session.DonVi == null) return;
            if (session.PhanLoai == (int)PhanLoai.SoYTe)
            {
                if (CheckFormNhapLieuSo(this.Page.Request.RawUrl))
                {
                    // Kiểm tra xem Session cũ có bằng Session hiện tại không, nếu không bằng thì gán lại cũ = hiện tại
                    if (session.IDOrganiztionCu != session.DonVi.ID)
                    {
                        session.IDOrganiztionCu = session.DonVi.ID;
                    }
                }
            }
        }
        protected void Page_PreInit(object sender, EventArgs e)
        {
            Recursion(Page.Controls);
        }

        private void Recursion(ControlCollection Controls)
        {
            if (Controls.Count > 0)
            {
                foreach (Control c in Controls)
                {
                    if (c.Controls.Count > 0)
                    {
                        Recursion(c.Controls);
                    }
                    else if (c.GetType().ToString() == "ASPxGridView")
                    {
                        string a = "";
                    }
                }
            }
        }

        private string cssLink = "";

        protected virtual bool RequiresIE7CompatibilityMode
        {
            get { return false; }
        }
        protected BrowserInfo Browser
        {
            get { return RenderUtils.Browser; }
        }


        public DataTable TinhTongCTR(DataTable dtOld)
        {
            for (int i = 0; i < dtOld.Rows.Count; i++)
            {
                if (dtOld.Rows[i]["HasChildrent"].ToString().ToLower() == "true")
                {
                    // tính tổng
                    DataRow[] arrDr = dtOld.Select("ParentID=" + dtOld.Rows[i]["IDDMLoaiCTR"].ToString());
                    float TongPhatSinh = 0, TongXuLy = 0, Dot = 0, VS = 0, ChonLap = 0, ThueXL = 0, ConLai = 0; string GhiRo = "";
                    for (int j = 0; j < arrDr.Length; j++)
                    {
                        TongPhatSinh += float.Parse("0" + arrDr[j]["TongPhatSinh"].ToString());
                        TongXuLy += float.Parse("0" + arrDr[j]["TongXuLy"].ToString());
                        Dot += float.Parse("0" + arrDr[j]["Dot"].ToString());
                        VS += float.Parse("0" + arrDr[j]["VS"].ToString());
                        ChonLap += float.Parse("0" + arrDr[j]["ChonLap"].ToString());
                        ThueXL += float.Parse("0" + arrDr[j]["ThueXL"].ToString());
                        ConLai += float.Parse("0" + arrDr[j]["ConLai"].ToString());
                        if (arrDr[j]["GhiRo"].ToString() != "")
                            GhiRo += "," + arrDr[j]["GhiRo"].ToString();
                    }
                    dtOld.Rows[i]["TongPhatSinh"] = TongPhatSinh;
                    dtOld.Rows[i]["TongXuLy"] = TongXuLy;
                    dtOld.Rows[i]["Dot"] = Dot;
                    dtOld.Rows[i]["VS"] = VS;
                    dtOld.Rows[i]["ChonLap"] = ChonLap;
                    dtOld.Rows[i]["ThueXL"] = ThueXL;
                    dtOld.Rows[i]["ConLai"] = ConLai;
                    if (GhiRo.Length > 1)
                        dtOld.Rows[i]["GhiRo"] = GhiRo.Substring(1, GhiRo.Length - 1);
                }
            }
            return dtOld;
        }

        public DataTable GetChangeData(DataTable dtOld, DataTable dtNew)
        {
            DataTable dt = dtNew.Clone();
            var data3 = dtNew.AsEnumerable().Except(dtOld.AsEnumerable(), DataRowComparer.Default);
            foreach (var a in data3)
            {
                dt.ImportRow(a);
            }
            return dt;
        }

        public const string DefaultThemeName = "Aqua";
        //public void ChangeLbUser(string UserNameNew)
        //{
        //    ((MasterPageMTCSYT)Page.Master).ChangeLbUser(UserNameNew);
        //}
        //public void ShowMessage(string Msg)
        //{
        //    ((SSV_FW_DM)Page.Master).ShowMessage(Msg);
        //}
        public enum Action
        {
            LuuVaNopBaoCao = 1,
            MoKhoaBaoCao = 2,
            SuaBaoCaoSauMoKhoa = 3,
        }
        public enum LoaiBaoCao
        {
            BaoCaoThang = 0,
            BaoCaoSauThang = 1,
            BaoCaoNam = 2,
        }

        public enum PhanLoai
        {
            DonViChuQuan = 0,
            TramYTe = 1,
            BenhVien = 2,
            CoSoDaoTao = 3,
            CoSoSanXuat = 4,
            CoSoYTDP = 5,
            VienVSDT = 6,
            Vung = 7,
            SoYTe = 8,

        }


        public DataTable dtNam()
        {
            DataTable dt = new DataTable();
            dt.Columns.Add("Nam", typeof(int));
            int Nam = DateTime.Now.Year + 10;
            for (int i = 0; i < 20; i++)
            {
                dt.Rows.Add(Nam - i);
            }
            return dt;
        }

        protected SYS_UserConfigService _isysUserConfigService = new SYS_UserConfigService();
        protected SYS_LanguageService _isysLanguageService = new SYS_LanguageService();

        private string _userName;
        public string SYS_Session { get { return _userName; } set { _userName = value; } }


        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);

            if (UsingIE7CompatibilityMode)
            {
                LiteralControl ie7CompatModeMeta = RenderUtils.CreateLiteralControl();
                //ie7CompatModeMeta.ID = RenderUtils.IE8CompatibilityMetaID;
                //ie7CompatModeMeta.Text = RenderUtils.IE8CompatibilityMetaText;
                Header.Controls.AddAt(0, ie7CompatModeMeta);
            }
            return;
            // Scripts
            ASPxWebControl.RegisterBaseScript(this);
            RegisterScript("Utilities", "~/Scripts/Utilities.js");
            // CSS
            RegisterCSSLink("~/CSS/styles.css");
            if (!string.IsNullOrEmpty(this.cssLink))
                RegisterCSSLink(this.cssLink);
        }
        private void RegisterCSSLink(string url)
        {
            HtmlLink link = new HtmlLink();
            Page.Header.Controls.Add(link);
            link.EnableViewState = false;
            link.Attributes.Add("type", "text/css");
            link.Attributes.Add("rel", "stylesheet");
            link.Href = url;
        }
        private void RegisterScript(string key, string url)
        {
            Page.ClientScript.RegisterClientScriptInclude(key, Page.ResolveUrl(url));
        }
        private bool UsingIE7CompatibilityMode
        {
            get
            {
                return Browser.IsIE && RequiresIE7CompatibilityMode &&
                    (Browser.Version >= 8 || (Browser.Version == 7 && Browser.IsIE));
            }
        }
        protected string GetThemeCookieName()
        {
            string cookieName = "DemoCurrentTheme";
            string path = Page.Request.ApplicationPath;

            int startPos = path.IndexOf("ASPx");
            if (startPos != -1)
            {
                int endPos = path.IndexOf("/", startPos);
                if (endPos != -1)
                    cookieName = path.Substring(startPos, endPos - startPos);
            }
            if (cookieName.IndexOf(AssemblyInfo.VirtDirSuffix) == -1)
                cookieName += AssemblyInfo.VirtDirSuffix;
            return cookieName;
        }
        protected override void InitializeCulture()
        {
            string languagePost = "";
            try
            {
                if (Request.Form["ctl00_Category_ASPxRoundPanel1_Language_VI"] != null)
                {
                    languagePost = Request.Form["ctl00_Category_ASPxRoundPanel1_Language_VI"];
                }
            }
            catch (Exception)
            {

            }

            // init variable
            SYS_Language sysLanguage;
            string culture = "";
            int langId = 0;

            if (!string.IsNullOrEmpty(languagePost))
            {
                langId = int.Parse(languagePost);
            }

            SYS_Session session = (SYS_Session)Session["SYS_Session"];

            if (langId == 0)
            {
                if (session == null || session.langId == 0)
                {
                    langId = _isysLanguageService.SelectDefaultLanguage().ID;
                }
                else
                {
                    langId = session.langId;

                }
            }

            sysLanguage = _isysLanguageService.SelectSYS_Language(langId);

            // create culture
            if (sysLanguage != null)
            {
                culture = sysLanguage.Code;
            }

            if (culture != "")
            {
                culture = culture.Trim();
                var ci = new System.Globalization.CultureInfo(culture);
                System.Threading.Thread.CurrentThread.CurrentCulture = ci;
                System.Threading.Thread.CurrentThread.CurrentUICulture = ci;
            }

            base.InitializeCulture();
            Session["SYS_Session"] = session;
            PageLoad();
        }
        public void WriteLog(string Description, int action, int IDBC, int PhanLoai)
        {
            SYS_LogService isys_log = new SYS_LogService();
            SYS_Log sys_log = new SYS_Log();
            sys_log.Time = DateTime.Now;
            SYS_Session session = (SYS_Session)Session["SYS_Session"];
            sys_log.UserId = session.User.IDUSER;
            sys_log.FunctionId = int.Parse(session.FuncID);
            sys_log.Description = Description;
            sys_log.Action = action;
            sys_log.IDBC = IDBC;
            sys_log.PhanLoai = PhanLoai;
            isys_log.InsertSYS_Log(sys_log);
            //0 Update, 1 Create, 2 Delete, 3 Approve
        }
    }

    public class PrintHelper
    {
        public PrintHelper()
        {
        }

        public static void PrintWebControl(Control ctrl)
        {
            PrintWebControl(ctrl, string.Empty);
        }
        public static void PrintWebControl(string html)
        {
            HttpContext.Current.Response.Clear();
            HttpContext.Current.Response.Write(html);
            HttpContext.Current.Response.Write("<script>window.print();</script>");
            HttpContext.Current.Response.End();
        }

        public static void PrintWebControl(Control ctrl, string Script)
        {
            StringWriter stringWrite = new StringWriter();
            System.Web.UI.HtmlTextWriter htmlWrite = new System.Web.UI.HtmlTextWriter(stringWrite);
            if (ctrl is WebControl)
            {
                Unit w = new Unit(100, UnitType.Percentage); ((WebControl)ctrl).Width = w;
            }
            Page pg = new Page();
            pg.EnableEventValidation = false;
            if (Script != string.Empty)
            {
                pg.ClientScript.RegisterStartupScript(pg.GetType(), "PrintJavaScript", Script);
            }
            HtmlForm frm = new HtmlForm();
            pg.Controls.Add(frm);
            frm.Attributes.Add("runat", "server");
            frm.Controls.Add(ctrl);
            pg.DesignerInitialize();
            pg.RenderControl(htmlWrite);
            string strHTML = stringWrite.ToString();
            HttpContext.Current.Response.Clear();
            HttpContext.Current.Response.Write(strHTML);
            HttpContext.Current.Response.Write("<script>window.print();</script>");
            HttpContext.Current.Response.End();
        }

        protected virtual bool RequiresIE7CompatibilityMode
        {
            get { return false; }
        }
    }
}
