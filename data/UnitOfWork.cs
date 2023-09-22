using Ecommerce.interfaces;
using Ecommerce.Repositories;
namespace Ecommerce.Data{
    public class UnitOfWork : IUnitOfWork{
    private readonly EcommerceDbContext _context;
    public IUserRepo UserRepository { get; private set; }

    public UnitOfWork(EcommerceDbContext context){
        _context = context;
        UserRepository = new UserRepo(_context);
    }

    public void Commit(){
        _context.SaveChanges();
    }

    public void Dispose(){
        _context?.Dispose();
    }
}

}