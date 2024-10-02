using System.Text.Json.Serialization;
using Task2.Domain.Entities.Common;

namespace Task2.Domain.Entities
{
    public class Order :BaseEntity
    {
        
        public Guid CustomerId { get; set; }

        public string Status { get; set; }

        public string TrackingNumber { get; set; }


        [JsonIgnore]
        public virtual Customer Customer { get; set; }

        [JsonIgnore]
        public ICollection<OrderProduct>? OrderProducts { get; set; }


        public Order()
        {
            OrderProducts = new List<OrderProduct>();
        }

        public Order(Guid customerId, string status,string trackingNumber,ICollection<OrderProduct> orderProducts) : base()
        {
            CustomerId = customerId;
            Status = status;
            TrackingNumber = trackingNumber;
            OrderProducts = orderProducts ?? new List<OrderProduct>();
        }
    }
}
