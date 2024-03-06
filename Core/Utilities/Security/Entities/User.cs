using Core.Entities;

namespace Core.Utilities.Security.Entities;

public class User:BaseEntity<Guid>
{
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string Email { get; set; }
    public byte[] PasswordHash {  get; set; }
    public byte[] PasswordSalt { get; set; }

}
