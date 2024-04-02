using Application.Domain.Core.Interfaces;

namespace Adapter.Database.Postgres.Base;

public class UnitOfWork(PostgresDbContext context) : IUnitOfWork
{
    public bool Commit()
    {
        return context.SaveChanges() > 0;
    }

    public void Dispose()
    {
        context.Dispose();
    }
}
