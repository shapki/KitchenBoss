using System;

namespace KitchenBoss.AppData
{
    public class OrderDto
    {
        public int OrderID { get; set; }
        public int CustomerID { get; set; }
        public string CustomerName { get; set; }
        public int? EmployeeID { get; set; }
        public string EmployeeName { get; set; }
        public int OrderStatusID { get; set; }
        public DateTime OrderDate { get; set; }
        public int TableID { get; set; }
        public int TableNumber { get; set; }
        public decimal TotalAmount { get; set; }
    }
}
