//------------------------------------------------------------------------------------------------------------------------
//-- Generated By:   TrungVK using CodeSmith 4.0.0.0
//-- Template:       Entity_Gen.cst
//-- Date Generated: Tuesday, September 23, 2014
//------------------------------------------------------------------------------------------------------------------------
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Entity
{
    public partial class DM_USER
    {
        private int _IDUSER;
        private int _IDMA_DVIQLY;
        private Boolean _XACNHAN;
        private string _USERNAME;
        private string _PASSWORD;
        private string _HOTEN;
        private string _DIACHI;
        private string _SODT;
        private string _EMAIL;
        private DateTime _NGAYSINH;
        private DateTime _NGAYTAO;
        private int _IS_ADMIN;
        private string _CHUCDANH;
        public int IDUSER { get { return _IDUSER; } set { _IDUSER = value; } }
        public int IDMA_DVIQLY { get { return _IDMA_DVIQLY; } set { _IDMA_DVIQLY = value; } }
        public Boolean XACNHAN { get { return _XACNHAN; } set { _XACNHAN = value; } }
        public string USERNAME { get { return _USERNAME; } set { _USERNAME = value; } }
        public string PASSWORD { get { return _PASSWORD; } set { _PASSWORD = value; } }
        public string HOTEN { get { return _HOTEN; } set { _HOTEN = value; } }
        public string DIACHI { get { return _DIACHI; } set { _DIACHI = value; } }
        public string SODT { get { return _SODT; } set { _SODT = value; } }
        public string EMAIL { get { return _EMAIL; } set { _EMAIL = value; } }
        public DateTime NGAYSINH { get { return _NGAYSINH; } set { _NGAYSINH = value; } }
        public DateTime NGAYTAO { get { return _NGAYTAO; } set { _NGAYTAO = value; } }
        public int IS_ADMIN { get { return _IS_ADMIN; } set { _IS_ADMIN = value; } }
        public string CHUCDANH { get { return _CHUCDANH; } set { _CHUCDANH = value; } }


        public DM_USER(int IDUSER, int IDMA_DVIQLY, Boolean XACNHAN, string USERNAME, string PASSWORD, string HOTEN, string DIACHI, string SODT, string EMAIL, DateTime NGAYSINH, DateTime NGAYTAO, int IS_ADMIN, string CHUCDANH)
        {
            _IDUSER = IDUSER;
            _IDMA_DVIQLY = IDMA_DVIQLY;
            _XACNHAN = XACNHAN;
            _USERNAME = USERNAME;
            _PASSWORD = PASSWORD;
            _HOTEN = HOTEN;
            _DIACHI = DIACHI;
            _SODT = SODT;
            _EMAIL = EMAIL;
            _NGAYSINH = NGAYSINH;
            _NGAYTAO = NGAYTAO;
            _IS_ADMIN = IS_ADMIN;
            _CHUCDANH = CHUCDANH;
        }
        public DM_USER()
        {
            _IDUSER = 0;
            _IDMA_DVIQLY = 0;
            _XACNHAN = false;
            _USERNAME = String.Empty;
            _PASSWORD = String.Empty;
            _HOTEN = String.Empty;
            _DIACHI = String.Empty;
            _SODT = String.Empty;
            _EMAIL = String.Empty;
            _NGAYSINH = DateTime.Now;
            _NGAYTAO = DateTime.Now;
            _IS_ADMIN = 0;
            _CHUCDANH = String.Empty; ;
        }

    }
}

