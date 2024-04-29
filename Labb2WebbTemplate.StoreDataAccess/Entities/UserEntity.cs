using System.ComponentModel.DataAnnotations;
using Labb2WebbTemplate.StoreDataAccess.Entities.Address;
using Labb2WebbTemplate.StoreDataAccess.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Labb2WebbTemplate.StoreDataAccess.Entities;

[Index("Email", IsUnique = true)]
public class UserEntity : IEntity<int, UserEntity>
{
    public int Id { get; set; }

    [StringLength(50)]
    public string FirstName { get; set; } = string.Empty;
    [StringLength(50)]
    public string LastName { get; set; } = string.Empty;
    
    [StringLength(100)]
    public string Email { get; set; } = string.Empty;
    
    [StringLength(15)]
    public string Phone { get; set; } = string.Empty;
    public byte[] Hash { get; set; } = new byte[32];
    public byte[] Salt { get; set; } = new byte[32];    
    public AddressEntity Address { get; set; } = null!;
    
    public virtual List<OrderEntity> Orders { get; set; } = new List<OrderEntity>();

    public bool IsAdmin { get; set; }
    
    public void Update(UserEntity updatedEntity)
    {
        FirstName = updatedEntity.FirstName;
        LastName = updatedEntity.LastName;
        Email = updatedEntity.Email;
        Phone = updatedEntity.Phone;
        Hash = updatedEntity.Hash;
        Salt = updatedEntity.Salt;
        IsAdmin = updatedEntity.IsAdmin;
    }
    
}