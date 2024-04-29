using System.ComponentModel.DataAnnotations;
using Labb2WebbTemplate.StoreDataAccess.Interfaces;

namespace Labb2WebbTemplate.StoreDataAccess.Entities.Address;

public class AddressEntity : IEntity<int, AddressEntity>
{
    public int Id { get; set; }

    public int UserId { get; set; }
    public UserEntity User { get; set; } = null!;
    [StringLength(50)]
    public string Street { get; set; } = null!;
    [StringLength(5)]
    public string PostalCode { get; set; } = null!;
    public CityEntity City { get; set; }
    
    public void Update(AddressEntity updatedEntity)
    {
        Street = updatedEntity.Street;
        PostalCode = updatedEntity.PostalCode;
        City = updatedEntity.City;
    }


    public override string ToString()
    {
        return $"{Street} {PostalCode}, {City.Name} {City.Region.Name}";
    }
}

