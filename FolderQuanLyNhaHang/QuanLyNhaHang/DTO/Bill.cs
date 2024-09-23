using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyNhaHang.DTO
{
    internal class Bill
    {
        private int iD;
        private DateTime? dateCheckin;
        private DateTime? dateCheckout;
        private int status;

        public int ID { get => iD; set => iD = value; }
        public DateTime? DateCheckin { get => dateCheckin; set => dateCheckin = value; }
        public DateTime? DateCheckout { get => dateCheckout; set => dateCheckout = value; }
        public int Status { get => status; set => status = value; }

        public Bill(int iD, DateTime? dateCheckin, DateTime? dateCheckout, int status)
        {
            ID = iD;
            DateCheckin = dateCheckin;
            DateCheckout = dateCheckout;
            Status = status;
        }

        public Bill(DataRow row)
        {
            this.ID = (int)row["id"];
            this.DateCheckin = (DateTime?)row["dateCheckIn"];

            var dateCheckOutTemp = row["dateCheckOut"];
            if (dateCheckOutTemp.ToString() != "")
                this.DateCheckout = (DateTime)dateCheckOutTemp;
            this.Status = (int)row["status"];
        }

    }
}
