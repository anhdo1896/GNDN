using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Entity
{
    public class SYS_Language
    {
        private int _ID;
		private string _name;
		private string _code;
        private string _path;
        private bool _isDefault;
	
		public int ID { get{ return _ID; } set { _ID= value; } }

        public string Name { get { return _name; } set { _name = value; } }
        public string Code { get { return _code; } set { _code = value; } }
        public string Path { get { return _path; } set { _path = value; } }
        public bool IsDefault { get { return _isDefault; } set { _isDefault = value; } }
	
		public SYS_Language(int ID, string name, string code, string path, bool isDefault)
		{
			_ID = ID;
		  _name = name;
		  _code = code;
          _path = path;
          _isDefault = isDefault;
		}
        public SYS_Language()
		{
			_ID =  0;
            _name = String.Empty;
            _code = String.Empty;
            _path = String.Empty;
            _isDefault = false;

		}
    }
}
