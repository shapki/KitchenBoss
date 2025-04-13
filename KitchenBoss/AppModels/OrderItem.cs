namespace KitchenBoss.AppModels
{
    using System.ComponentModel.DataAnnotations.Schema;

    [Table("OrderItem")]
    public partial class OrderItem
    {
        public int OrderItemID { get; set; }

        public int OrderID { get; set; }

        public int DishID { get; set; }

        public int Quantity { get; set; }

        public decimal Price { get; set; }

        public virtual Dish Dish { get; set; }

        public virtual Order Order { get; set; }
    }
}
