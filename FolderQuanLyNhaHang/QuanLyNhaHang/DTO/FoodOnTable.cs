using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyNhaHang.DTO
{
    internal class FoodOnTable
    {
        private string FoodName;
        private int count;
        private float price;
        private float totalPrice;

        public FoodOnTable(DataRow row) {
            FoodName = row["name"].ToString();
            Count = (int)row["count"];
            Price = (float)((double)row["price"]);
            TotalPrice = (float)((double)row["totalPrice"]);
        }


        public string FoodName1 { get => FoodName; set => FoodName = value; }
        public int Count { get => count; set => count = value; }
        public float Price { get => price; set => price = value; }
        public float TotalPrice { get => totalPrice; set => totalPrice = value; }

        public FoodOnTable(string foodName, int count, float price, float totalPrice)
        {
            FoodName = foodName;
            Count = count;
            Price = price;
            TotalPrice = totalPrice;
        }
    }
}
