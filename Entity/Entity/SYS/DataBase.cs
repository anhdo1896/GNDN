using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Entity
{
    public class DataBase
    {
        public int _ID { get; set; }
        public string _Name { get; set; }
        public string _ColumnName { get; set; }
        public string _DataType { get; set; }
        public string _TableName { get; set; }


        public int ID { get { return _ID; } set { _ID = value; } }
        public string Name { get { return _Name; } set { _Name = value; } }
        public string ColumnName { get { return _ColumnName; } set { _ColumnName = value; } }
        public string DataType { get { return _DataType; } set { _DataType = value; } }
        public string TableName { get { return _TableName; } set { _TableName = value; } }
    }
}
