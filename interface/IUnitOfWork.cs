namespace Ecommerce.interfaces{
    public interface IUnitOfWork : IAsyncDisposable{
        IUserRepo UserRepository { get; }
        IProductRepo ProductRepository {get;}
        ICategoryRepo CategoryRepository {get;}
        public Task CommitAsync();
    }
}