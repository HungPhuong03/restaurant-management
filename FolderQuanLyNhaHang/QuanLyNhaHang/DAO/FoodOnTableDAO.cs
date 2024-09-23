using QuanLyNhaHang.DTO;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyNhaHang.DAO
{
    internal class FoodOnTableDAO
    {
        private static FoodOnTableDAO instance;

        internal static FoodOnTableDAO Instance { 
            get {
                if(instance == null)
                    instance = new FoodOnTableDAO();
                return instance;
            }
            private set => instance = value; 
        }

        private FoodOnTableDAO() { }

        public List<FoodOnTable> GetFoodsByTable(int  tableId)
        {
            List<FoodOnTable> foodOnTables = new List<FoodOnTable>();

            string query = $"SELECT f.name, bi.count, f.price, f.price * bi.count AS totalPrice FROM dbo.BillInfo AS bi, dbo.Bill AS b, dbo.Food AS f WHERE bi.idBill = b.id AND bi.idFood = f.id AND b.status = 0 AND b.idTable = {tableId}";
            DataTable dt = DataProvider.Intance.ExcuteQuery(query);

            foreach (DataRow item in dt.Rows)
            {
                FoodOnTable tmp = new FoodOnTable(item);
                foodOnTables.Add(tmp);
            }

            return foodOnTables;
        }
    }
}
