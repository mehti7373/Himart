namespace Framework.Ef;

public interface IUnitOfWork : IDisposable
{
    Task<int> SaveChangesAsync();
}
