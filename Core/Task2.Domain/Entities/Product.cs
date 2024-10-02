using System.Text.Json.Serialization;
using Task2.Domain.Entities.Common;

namespace Task2.Domain.Entities
{
    public class Product : BaseEntity
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }
        public string Category { get; set; }
        public string BarcodeCode { get; set; }
        public string Brand { get; set; }
        public int StockQuantity { get; set; }

        [JsonIgnore]
        public ICollection<OrderProduct>? OrderProducts { get; set; } = new List<OrderProduct>();

        public Product() { }

        public Product(string name, string description, decimal price, string category, string barcodeCode, string brand, int stockQuantity, ICollection<OrderProduct>? orderProducts)
        {
            Name = name;
            Description = description;
            Price = price;
            Category = category;
            BarcodeCode = barcodeCode;
            Brand = brand;
            StockQuantity = stockQuantity;
            OrderProducts = orderProducts ?? new List<OrderProduct>();
        }
    }
}
