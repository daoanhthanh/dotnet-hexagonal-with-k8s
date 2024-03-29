namespace Domain.Core.User.Models;

public struct UserRole
{
    public string Name { get; }
    public long? CustomId { get; }

    private UserRole(string name, long? customId = null)
    {
        Name = name;
        CustomId = customId;
    }
    
    public static UserRole Admin => new UserRole("Admin");
    
    public static UserRole Custom(long roleId, string name = "Custom")
    {
        return new UserRole(name, roleId);
    }
}