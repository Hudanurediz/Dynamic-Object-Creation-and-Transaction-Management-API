using System.Text.Json.Serialization;
using Task2.Domain.Entities.Common;

namespace Task2.Domain.Entities
{
    public class OrderProduct:BaseEntity
    {

        public Guid ProductId { get; set; }

        public Guid OrderId { get; set; }

        public int Quantity { get; set; }

        [JsonIgnore]
        public virtual Product? Product { get; set; }

        [JsonIgnore]
        public virtual Order? Order { get; set; }



        public OrderProduct() : base()
        {
        }


        public OrderProduct(Guid productId, Guid orderId, int quantity) : base()
        {
            ProductId = productId;
            OrderId = orderId;
            Quantity = quantity;
        }

    }
}
