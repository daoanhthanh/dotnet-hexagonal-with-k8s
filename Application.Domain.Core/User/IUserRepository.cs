using Application.Domain.Core.Interfaces;
using DomainModel = Application.Domain.Core.User.Models;

namespace Application.Domain.Core.User;

using User = Models.User;

public interface IUserRepository: IRepository<User>
{
    User? GetByEmail(string email);
}