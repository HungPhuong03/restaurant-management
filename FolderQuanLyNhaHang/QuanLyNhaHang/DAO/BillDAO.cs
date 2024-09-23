using QuanLyNhaHang.DTO;
using System.Data;

namespace QuanLyNhaHang.DAO
{
    internal class BillDAO
    {
        private static BillDAO instance;

        internal static BillDAO Instance
        {
            get { if (instance == null) instance = new BillDAO(); return instance; }
            private set => instance = value;
        }

        BillDAO() { }

        public int GetUnCheckBillIDByTableId(int tableId)
        {
            DataTable data = DataProvider.Intance.ExcuteQuery($"SELECT * FROM BILL WHERE IdTable = {tableId} AND Status = 0");
            if (data.Rows.Count > 0)
            {
                Bill bill = new Bill(data.Rows[0]);
                return bill.ID;
            }
            return -1;
        }
    }
}
