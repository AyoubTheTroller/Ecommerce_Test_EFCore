namespace Ecommerce.interfaces{
    public interface IUnitOfWork : IDisposable{
        IUserRepo UserRepository { get; }
        public void Commit();
    }
}