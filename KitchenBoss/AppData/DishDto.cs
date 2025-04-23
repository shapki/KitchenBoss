namespace KitchenBoss.AppData
{
    public class DishDto
    {
        public int DishID { get; set; }
        public string DishName { get; set; }
        public int CategoryID { get; set; }
        public string CategoryName { get; set; }
        public decimal Price { get; set; }
        public string Description { get; set; }
    }
}
