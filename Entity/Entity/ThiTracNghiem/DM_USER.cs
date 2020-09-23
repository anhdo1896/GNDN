using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Entity
{
    public partial class DM_USER
    {
        #region private
       List<SYS_RightOfUser> _RightOfUser = new List<SYS_RightOfUser>();
        private string _FullName;
        private int _IDOrganization;

        private SYS_Organization _organization;
        private string _RoleGroup;
        //SYS_Province _sysProvince=new SYS_Province();
        private int _IDDonVi;
        private string _ma_dviqly;
        private string _ma_dviqlyDN;

        #endregion
        public string ma_dviqly
        {
            get { return _ma_dviqly; }
            set { _ma_dviqly = value; }
        }
        public string ma_dviqlyDN
        {
            get { return _ma_dviqlyDN; }
            set { _ma_dviqlyDN = value; }
        }
        private string _MA_DVIQLY;
        public string MA_DVIQLY
        {
            get { return _MA_DVIQLY; }
            set { _MA_DVIQLY = value; }
        }
      
        List<SYS_Right> _rights = new List<SYS_Right>();
        SYS_Roles _roles = new SYS_Roles();
        SYS_Position _position = new SYS_Position();
        SYS_Province _sysProvince = new SYS_Province();
  
        public DM_USER User { get; set; }
        //them chucdanh

        private string _strDonVi;
        public string strDonVi { get { return _strDonVi; } set { _strDonVi = value; } }       

        public static string Encrypt(string password)
        {
            byte[] textBytes = System.Text.Encoding.Default.GetBytes(password);
            var cryptHandler = new System.Security.Cryptography.MD5CryptoServiceProvider();
            byte[] hash = cryptHandler.ComputeHash(textBytes);
            string ret = "";
            foreach (byte a in hash)
            {
                if (a < 16)
                    ret += "0" + a.ToString("x");
                else
                    ret += a.ToString("x");
            }
            return ret;
        }
        public bool SuperUser { get; set; }
        public int IDOrganization
        {
            get { return _IDOrganization; }
            set { _IDOrganization = value; }
        }

        public int IDDonVi
        {
            get { return _IDDonVi; }
            set { _IDDonVi = value; }
        }

        public SYS_Organization Organization
        {
            get { return _organization; }
            set { _organization = value; }
        }

        public SYS_Province SysProvince
        {
            get { return _sysProvince; }
            set { _sysProvince = value; }
        }

        public SYS_Roles Roles
        {
            get { return _roles; }
            set { _roles = value; }
        }
        public string FullName { get { return _FullName; } set { _FullName = value; } }
        public string RoleGroup { get { return _RoleGroup; } set { _RoleGroup = value; } }

        public List<SYS_Right> Rights
        {
            get { return _rights; }
            set { _rights = value; }
        }       
    }
}
