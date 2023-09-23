namespace Ecommerce.interfaces{
    public interface IUnitOfWork : IAsyncDisposable{
        IUserRepo UserRepository { get; }
        IProductRepo ProductRepository {get;}
        ICategoryRepo CategoryRepository {get;}
        IOrderDetailRepo OrderDetailRepository {get;}
        public Task CommitAsync();
    }
}