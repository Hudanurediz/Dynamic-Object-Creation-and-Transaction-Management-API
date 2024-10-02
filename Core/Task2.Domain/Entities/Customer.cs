using System.Text.Json.Serialization;
using Task2.Domain.Entities.Common;

namespace Task2.Domain.Entities
{
    public class Customer:BaseEntity
    {
        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string? UserName { get; set; }

        public string Email { get; set; }

        public string PhoneNumber { get; set; }

        [JsonIgnore]
        public virtual ICollection<Address>? Addresses { get; set; }

        [JsonIgnore]
        public virtual ICollection<Order>? Orders { get; set; }

        public Customer()
        {
            Addresses = new List<Address>();
            Orders = new List<Order>();
        }

        public Customer(string firstName, string lastName, string? userName, string email , string phoneNumber, ICollection<Address> addresses, ICollection<Order>? orders) :base()
        {
            FirstName = firstName;
            LastName = lastName;
            UserName = userName;
            Email = email;
            PhoneNumber = phoneNumber;
            Addresses = addresses ?? new List<Address>();
            Orders = orders ?? new List<Order>(); 
        }
    }
}
