using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Entity
{
    public partial class SYS_User
    {
        #region private
        List<SYS_Right> _rights = new List<SYS_Right>();
        SYS_Roles _roles = new SYS_Roles();
        private string _FullName;

        private int _IDOrganization;
        SYS_Position _position = new SYS_Position();
        private SYS_Organization _organization;
        private string _RoleGroup;
        SYS_Province _sysProvince=new SYS_Province();
        private int _IDDonVi;
        #endregion

        #region public

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
        #endregion
    }
}
