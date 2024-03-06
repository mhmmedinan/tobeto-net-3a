using Core.Utilities.Security.Entities;

namespace Core.Utilities.Security.Dtos;

public class UserForLoginDto
{
    public string Email { get; set; }
    public string Password { get; set; }
}

