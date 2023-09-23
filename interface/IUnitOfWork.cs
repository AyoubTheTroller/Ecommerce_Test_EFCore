namespace Ecommerce.interfaces{
    public interface IUnitOfWork : IAsyncDisposable{
        IUserRepo UserRepository { get; }
        IProductRepo ProductRepository {get;}
        public Task CommitAsync();
    }
}