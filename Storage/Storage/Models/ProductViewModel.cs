namespace Storage.Models
{
    public class ProductViewModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Price { get; set; } = 0;
        public int Count { get; set; } = 0;
        public int InventoryValue { get; set; } = 0;
    }
    
}
