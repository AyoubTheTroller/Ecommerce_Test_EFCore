namespace Ecommerce.interfaces{
    public interface IUnitOfWork : IDisposable{
        IUserRepo UserRepository { get; }
        public Task CommitAsync();
    }
}