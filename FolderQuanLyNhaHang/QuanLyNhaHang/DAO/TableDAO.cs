using QuanLyNhaHang.DTO;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyNhaHang.DAO
{
    internal class TableDAO
    {
        private static TableDAO intance;

        public static int TableWidth = 175;
        public static int TableHeight = 120;

        internal static TableDAO Intance {
            get { if (intance == null) intance = new TableDAO(); return intance; }
            private set => intance = value; 
        }

        private TableDAO() { }

        public List<Table> LoadTableList()
        {
            List < Table > tableList = new List < Table >();

            DataTable dt = DataProvider.Intance.ExcuteQuery("USP_GetTableList");

            foreach (DataRow item in dt.Rows)
            {
                Table table = new Table(item);
                tableList.Add(table);
            }

            return tableList;
        }

    }
}
