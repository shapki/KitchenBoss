using System;

namespace KitchenBoss.AppData
{
    public class EmployeeDto
    {
        public int EmployeeID { get; set; }
        public string FullName { get; set; }
        public int PositionID { get; set; }
        public DateTime HireDate { get; set; }
        public decimal Salary { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
    }
}
