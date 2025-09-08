namespace ClickMart.API.Models
{
    public class Product : JsonBase
    {
        public string Identifier { get; set; } = string.Empty;
        public string Name { get; set; } = string.Empty;
        public decimal Price { get; set; }
        public string Description { get; set; } = string.Empty;
        public int Category { get; set; }
        public string Image { get; set; } = string.Empty;

    }
}
