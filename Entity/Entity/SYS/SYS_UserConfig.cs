using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Entity
{
    public class SYS_UserConfig
    {
        private int _ID;
		private int _userId;
		private int _langId;

        public int ID { get; set; }
        public int UserId { get; set; }
        public int LangId { get; set; }
       	
		public SYS_UserConfig(int ID, int userId, int langId)
		{
			_ID = ID;
		  _userId = userId;
		  _langId = langId;
		}
        public SYS_UserConfig()
		{
			_ID =  0;
            _userId = 0;
			_langId = 0;
		}
    }
}
