using Domain.Core.User.Models;

namespace In.User.DTOs;

public class UserViewModel: DtoAudit
{
    public string Name { get; set; }

    public UserRole Role { get; set; }

    public string Email { get; set; }

    public DateTime BirthDate { get; set; }
}