using QuanLyNhaHang.DTO;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyNhaHang.DAO
{
    internal class BillInforDAO
    {
        private static BillInforDAO instance;

        internal static BillInforDAO Instance {
            get { if (instance == null) instance = new BillInforDAO(); return instance; }
            private set => instance = value; }

        private BillInforDAO( ) {}

        public List<BillInfo> GetListBillInfoByIdBill(int idBill)
        {
            List<BillInfo> listBillInfo = new List<BillInfo>();

            DataTable dataTable = DataProvider.Intance.ExcuteQuery($"SELECT * FROM BillInfo WHERE idBill = {idBill}");

            foreach (DataRow item in dataTable.Rows)
            {
                BillInfo info = new BillInfo(item);
                listBillInfo.Add(info);
            }

            return listBillInfo;
        }
    }
}
