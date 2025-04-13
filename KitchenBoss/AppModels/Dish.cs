namespace KitchenBoss.AppModels
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    [Table("Dish")]
    public partial class Dish
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Dish()
        {
            DishIngredients = new HashSet<DishIngredient>();
            OrderItems = new HashSet<OrderItem>();
        }

        public int DishID { get; set; }

        [Required]
        [StringLength(100)]
        public string DishName { get; set; }

        public int CategoryID { get; set; }

        [StringLength(255)]
        public string Description { get; set; }

        public decimal Price { get; set; }

        public virtual DishCategory DishCategory { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<DishIngredient> DishIngredients { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<OrderItem> OrderItems { get; set; }
    }
}
