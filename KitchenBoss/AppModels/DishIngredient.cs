namespace KitchenBoss.AppModels
{
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    [Table("DishIngredient")]
    public partial class DishIngredient
    {
        [Key]
        [Column(Order = 0)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int DishID { get; set; }

        [Key]
        [Column(Order = 1)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int IngredientID { get; set; }

        public decimal Quantity { get; set; }

        public virtual Dish Dish { get; set; }

        public virtual Ingredient Ingredient { get; set; }
    }
}
