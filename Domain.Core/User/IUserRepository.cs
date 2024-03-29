using Domain.Core.Interfaces;
using DomainModel = Domain.Core.User.Models;

namespace Domain.Core.User;

public interface IUserRepository: IRepository<DomainModel.User>
{
    DomainModel.User? GetByEmail(string email);
}