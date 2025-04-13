namespace KitchenBoss.AppModels
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations.Schema;

    [Table("Order")]
    public partial class Order
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Order()
        {
            OrderItems = new HashSet<OrderItem>();
        }

        public int OrderID { get; set; }

        public int? CustomerID { get; set; }

        public int? TableID { get; set; }

        public int EmployeeID { get; set; }

        public DateTime OrderDate { get; set; }

        public int OrderStatusID { get; set; }

        public decimal TotalAmount { get; set; }

        public virtual Customer Customer { get; set; }

        public virtual Employee Employee { get; set; }

        public virtual OrderStatu OrderStatu { get; set; }

        public virtual Table Table { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<OrderItem> OrderItems { get; set; }
    }
}
