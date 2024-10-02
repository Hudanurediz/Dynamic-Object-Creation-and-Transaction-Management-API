using System.Text.Json.Serialization;
using Task2.Domain.Entities.Common;
using Task2.Domain.Entities;

public class Address : BaseEntity
{
    public string Street { get; set; }
    public string City { get; set; }
    public string State { get; set; }
    public string? PostalCode { get; set; }
    public string Country { get; set; }
    public Guid? CustomerId { get; set; }

    [JsonIgnore]
    public virtual Customer? Customer { get; set; }

    public Address() : base()
    {
    }

    public Address(string street, string city, string state, string? postalCode, string country, Guid customerId) : base()
    {
        Street = street;
        City = city;
        State = state;
        PostalCode = postalCode;
        Country = country;
        CustomerId = customerId;
    }
}
