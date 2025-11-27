namespace CleanTeeth.Application.Contracts.Persistence;

public interface IUnitOfWork
{
    Task CommitAsync(CancellationToken cancellationToken);

    Task RollbackAsync(CancellationToken cancellationToken);
}
