using Domain.Core.User;
using Microsoft.EntityFrameworkCore;
using Postgres.Base;
using DomainModel = Domain.Core.User.Models;

namespace Postgres.User;

public class UserRepository(PostgresDbContext context) : Repository<DomainModel.User>(context), IUserRepository
{
    public DomainModel.User? GetByEmail(string email)
    {
        return _dbSet.AsNoTracking().FirstOrDefault(c => c.Email == email);
    }
}