using System;
using Application.Domain.Core.User.Models;

namespace Application.Ports.In.User.DTOs;

public class UserViewModel: DtoAudit
{
    public string Name { get; set; }

    public UserRole Role { get; set; }

    public string Email { get; set; }

    public DateTime BirthDate { get; set; }
}