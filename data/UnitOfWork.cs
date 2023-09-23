using Ecommerce.interfaces;
namespace Ecommerce.Data {
    public class UnitOfWork : IUnitOfWork {
        private readonly EcommerceDbContext _context;
        public IUserRepo UserRepository { get; }
        public IProductRepo ProductRepository { get; }
        public ICategoryRepo CategoryRepository {get; }
        public IOrderDetailRepo OrderDetailRepository {get; }

        public UnitOfWork(EcommerceDbContext context, IUserRepo userRepo, IProductRepo productRepo, ICategoryRepo categoryRepo, IOrderDetailRepo orderDetailRepo) {
            _context = context;
            UserRepository = userRepo;
            ProductRepository = productRepo;
            CategoryRepository = categoryRepo;
            OrderDetailRepository = orderDetailRepo;
        }

        public async Task CommitAsync() {
            await _context.SaveChangesAsync();
        }

        public async ValueTask DisposeAsync() {
            await _context.DisposeAsync();
        }
    }
}
