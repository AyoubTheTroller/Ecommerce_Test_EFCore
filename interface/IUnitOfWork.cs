namespace Ecommerce.interfaces{
    public interface IUnitOfWork : IAsyncDisposable{
        IUserRepo UserRepository { get; }
        IProductRepo ProductRepository {get;}
        ICategoryRepo CategoryRepository {get;}
        IOrderDetailRepo OrderDetailRepository {get;}
        IOrderRepo OrderRepository {get;}
        public Task CommitAsync();
    }
}