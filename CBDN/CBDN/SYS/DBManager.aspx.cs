using System;
using System.Collections.Generic;
using System.IO;
using System.Web.UI;
using SystemManageService;
using DevExpress.Web;
using DevExpress.Web.Internal;
using DevExpress.Web.ASPxTreeList;
using Entity;
using System.Web;
using QLY_VTTB.MasterPage;

namespace MTCSYT
{
    public partial class DBManager : BasePage
    {
        private SYS_DBManager _sysDbManager = new SYS_DBManager();
        private SYS_Right rightOfUser = null;
        //private const string FuncName = "SYS_DBManager";
        private const string funcid = "4";
        private SYS_LogService isys_logservice = new SYS_LogService();
        private SYS_Log sys_log = new SYS_Log();
       
        protected void Page_Load(object sender, EventArgs e)
        {
            ScriptManager ScriptMan = ScriptManager.GetCurrent(this);
            //ScriptManager1.RegisterPostBackControl(btnOk);
            if (ScriptMan != null) ScriptMan.RegisterPostBackControl(btnDownload);
            var session = (SYS_Session)Session["SYS_Session"];
            session.FuncID = funcid;
            if (session == null || session.User.USERNAME == "Guest")
            {
                session.CurrentPage = Request.AppRelativeCurrentExecutionFilePath;
                Response.Redirect("~\\Login.aspx");
            }
            else
            {
                List<SYS_Right> right = session.User.Rights;
                foreach (SYS_Right sysRight in right)
                {
                    if (sysRight.FuncId == funcid)
                    {
                        rightOfUser = sysRight;
                        Session["Right"] = sysRight;
                        Session["UserId"] = session.User.IDUSER;
                        Session["FunctionId"] = sysRight.FuncId;
                        break;
                    }
                }

                if (rightOfUser == null)
                {
                    Session["Status"] = "0";
                    Response.Redirect("~\\HeThong\\Default.aspx");

                }
            }
            Session["SYS_Session"] = session;
        }
        #region Create nodes

        protected void tree_VirtualModeCreateChildren(object sender, TreeListVirtualModeCreateChildrenEventArgs e)
        {
            string nodePath = e.NodeObject == null ? FileManagerHelper.RootFolder : e.NodeObject.ToString();
            if (Directory.Exists(nodePath))
            {
                List<string> children = new List<string>();
                string[] names;
                names = Directory.GetDirectories(nodePath);
                foreach (string name in names)
                    children.Add(name);
                e.Children = children;
            }
        }
        protected void tree_VirtualModeNodeCreating(object sender, TreeListVirtualModeNodeCreatingEventArgs e)
        {
            string nodePath = e.NodeObject.ToString();
            e.NodeKeyValue = FileManagerHelper.GetPathKey(nodePath);
            e.IsLeaf = !Directory.Exists(nodePath)
                || (Directory.GetFiles(nodePath).Length < 1 && Directory.GetDirectories(nodePath).Length < 1);
            e.SetNodeValue(FileManagerHelper.FullPathName, nodePath);
            e.SetNodeValue(FileManagerHelper.NameFieldName, Path.GetFileName(nodePath));
        }

        protected void tree0_VirtualModeCreateChildren(object sender, TreeListVirtualModeCreateChildrenEventArgs e)
        {
            string nodePath = e.NodeObject == null ? FileManagerHelper.RootFolder : e.NodeObject.ToString();
            // string nodePath = e.NodeObject == null ? Server.MapPath("~") : e.NodeObject.ToString();
            if (Directory.Exists(nodePath))
            {
                List<string> children = new List<string>();
                string[] names;
                names = Directory.GetDirectories(nodePath);
                foreach (string name in names)
                    children.Add(name);
                e.Children = children;
                names = Directory.GetFiles(nodePath);
                foreach (string name in names)
                {
                    if (name.IndexOf(".bak") > 0)
                    {
                        children.Add(name);
                    }
                }
                e.Children = children;

            }
        }
        protected void tree0_VirtualModeNodeCreating(object sender, TreeListVirtualModeNodeCreatingEventArgs e)
        {
            string nodePath = e.NodeObject.ToString();
            e.NodeKeyValue = FileManagerHelper.GetPathKey(nodePath);
            e.IsLeaf = !Directory.Exists(nodePath)
                || (Directory.GetFiles(nodePath).Length < 1 && Directory.GetDirectories(nodePath).Length < 1);
            e.SetNodeValue(FileManagerHelper.FullPathName, nodePath);
            e.SetNodeValue(FileManagerHelper.NameFieldName, Path.GetFileName(nodePath));
        }
        #endregion

        #region Utils
        protected string GetNodeGlyph(TreeListDataCellTemplateContainer container)
        {
            string fmt = "~/Images/{0}.png";
            if (container.NodeKey == null)
                return string.Format(fmt, "closed");
            string name = container.GetValue(FileManagerHelper.FullPathName).ToString();
            if (Directory.Exists(name))
            {
                if (container.Expandable && container.Expanded)
                    return string.Format(fmt, "opened");
                return string.Format(fmt, "closed");
            }
            return string.Format(fmt, "file");
        }
        #endregion

        protected void btnBackup_Click(object sender, EventArgs e)
        {

            if (!IsPostBack && !IsCallback)
                ASPxEdit.ValidateEditorsInContainer(this);
            string lang = System.Globalization.CultureInfo.CurrentUICulture.ToString();
            string fileName = String.Format("{0}\\{1}.bak", tree.GetVirtualNodeObject(tree.FocusedNode), txtFileName.Text);
            if (_sysDbManager.BackupDataBase(fileName))
            {
                if (lang == "vi-VN")
                lblStatus.Text = "Sao lưu thành công. ?";
                else
                {
                    lblStatus.Text = "Backup Successfuly. ?";
                }
                //btnOk.Visible = true;
                btnCancel.Visible = true;
            }
            else
            {
                if (lang == "vi-VN")
                lblStatus.Text = "Lỗi!Bạn hãy kiểm tra lai tên. Ko chưa các kí tự đặc biệt";
                else
                {
                    lblStatus.Text = "Error !";
                }
                //btnOk.Visible = true;
            }
            //WriteLog("Backup DataBase " + fileName, Action.Create);
        }

        protected void btnRestore_Click(object sender, EventArgs e)
        {
            if (!IsPostBack && !IsCallback)
                ASPxEdit.ValidateEditorsInContainer(this);
            string lang = System.Globalization.CultureInfo.CurrentUICulture.ToString();
            if (_sysDbManager.RestoreDataBase(tree0.GetVirtualNodeObject(tree0.FocusedNode).ToString()))
            {
                if (lang == "vi-VN")
                lblStatus.Text = "Phục hồi thành công!";
                else
                {
                    lblStatus.Text = "Restore Successfully!";
                }
                //btnOk.Visible = true;
            }
            else
            {
                if (lang == "vi-VN")
                    lblStatus.Text = "Lỗi!";
                else
                {
                    lblStatus.Text = "Error !";
                }
                //btnOk.Visible = true;
            }
            //WriteLog("Restore DataBase " + tree0.GetVirtualNodeObject(tree0.FocusedNode).ToString(), Action.Update);
        }
        //Download(Backup)
        protected void btnOk_Click(object sender, EventArgs e)
        {
            string lang = System.Globalization.CultureInfo.CurrentUICulture.ToString();
            try
            {
                string fileName = txtFileName.Text;
                var urlFile = String.Format("{0}\\{1}.bak", tree.GetVirtualNodeObject(tree.FocusedNode), fileName);
                DownloadFile(urlFile);
            }
            catch (Exception ex)
            {
                if(lang=="vi-VN")
                lblStatus.Text = "File không tìm thấy!";
                else
                {
                    lblStatus.Text = "File not found";
                }
                ex.ToString();
            }

        }
        private void DownloadFile(string url)
        {
            FileInfo file = new FileInfo(url);
            if (file.Exists)
            {
                Response.ClearContent();
                Response.ClearHeaders();
                Response.ContentType = "application/octet-stream";
                Response.AddHeader("Content-Disposition", "attachment; filename=" + file.Name);
                Response.AddHeader("Content-Length", file.Length.ToString());
                Response.WriteFile(file.FullName);
                Response.Flush();
             }
          
        }
        //Download(Restore)
        protected void btnDownload_Click(object sender, EventArgs e)
        {
            
           if(!tree0.FocusedNode.HasChildren)
           {
               try
               {
                   var url = String.Format("{0}", tree.GetVirtualNodeObject(tree0.FocusedNode));
                   FileInfo file = new FileInfo(url);
                   if(file.Name.Contains(".bak"))
                   {
                       DownloadFile(url);    
                   }
                   
               }
               catch (Exception ex)
               {
                   ex.ToString();
                   throw;
               }
              
           }
            
        }

    }


}

