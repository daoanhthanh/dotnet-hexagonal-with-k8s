namespace Domain.Core.User.Models;

public class User: EntityAudit
{
    public User(UserId id, string name, UserRole role, string email, DateTime birthDate)
    {
        Id = id;
        Name = name;
        Role = role;
        Email = email;
        BirthDate = birthDate;
    }

    // Empty constructor for EF
    protected User()
    {
    }

    public string Name { get; private set; }
    
    public UserRole Role { get; private set; }

    public string Email { get; private set; }

    public DateTime BirthDate { get; private set; }
}