namespace KitchenBoss.AppModels
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    public partial class OrderStatu
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public OrderStatu()
        {
            Orders = new HashSet<Order>();
        }

        [Key]
        public int OrderStatusID { get; set; }

        [Required]
        [StringLength(50)]
        public string StatusName { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Order> Orders { get; set; }
    }
}
