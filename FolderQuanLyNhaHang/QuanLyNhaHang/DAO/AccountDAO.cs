using Microsoft.SqlServer.Server;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyNhaHang.DAO
{
    internal class AccountDAO
    {
        private static AccountDAO intance;

        internal static AccountDAO Intance {
            get { 
                if(intance == null) 
                    intance = new AccountDAO();
                return intance;
            }
            set => intance = value; 
        }

        private AccountDAO() { }

        public bool Login(string username, string password)
        {
            string query = "USP_Login @userName , @passWord";
            DataTable result = DataProvider.Intance.ExcuteQuery(query, new object[] { username, password });
            return result.Rows.Count > 0;
        }
    }
  
}
