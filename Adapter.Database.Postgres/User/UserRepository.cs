using Adapter.Database.Postgres.Base;
using Application.Domain.Core.Interfaces;
using Application.Domain.Core.User;
using Microsoft.EntityFrameworkCore;
using DomainModel = Application.Domain.Core.User.Models;

namespace Adapter.Database.Postgres.User;

public class UserRepository(PostgresDbContext context) : Repository<DomainModel.User>(context), IUserRepository
{
    public DomainModel.User? GetByEmail(string email)
    {
        return _dbSet.AsNoTracking().FirstOrDefault(c => c.Email == email);
    }
}