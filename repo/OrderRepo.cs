using Ecommerce.interfaces;
using Ecommerce.Models;
using Ecommerce.Data;
using Microsoft.EntityFrameworkCore;

namespace Ecommerce.Repositories{
    public class OrderRepo : IOrderRepo
    {
        private EcommerceDbContext _context;
        public OrderRepo(EcommerceDbContext context){
            _context = context;
        }
        public Order Add(Order order)
        {
            try{
                _context.Orders.Add(order);
                return order;
            }
            catch(Exception ex){
                throw new ApplicationException($"Error when adding order: {ex.Message}");
            }
        }

        public async Task<Order?> GetById(int id)
        {
            return await _context.Orders.FirstOrDefaultAsync(p => p.Id == id);
        }

        public async Task<List<Order>> GetAll()
        {
            return await _context.Orders.ToListAsync();
        }
    }
}