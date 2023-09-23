using Ecommerce.interfaces;
using Ecommerce.Models;
using Ecommerce.Data;
using Microsoft.EntityFrameworkCore;

namespace Ecommerce.Repositories{
    public class OrderDetailRepo : IOrderDetailRepo
    {
        private EcommerceDbContext _context;
        public OrderDetailRepo(EcommerceDbContext context){
            _context = context;
        }
        public OrderDetail Add(OrderDetail orderDetail)
        {
            try{
                _context.OrderDetails.Add(orderDetail);
                return orderDetail;
            }
            catch(Exception ex){
                throw new ApplicationException($"Error when adding order detail: {ex.Message}");
            }
        }

        public async Task<OrderDetail?> GetById(int id)
        {
            return await _context.OrderDetails.FirstOrDefaultAsync(p => p.Id == id);
        }

        public async Task<List<OrderDetail>> GetAll()
        {
            return await _context.OrderDetails.ToListAsync();
        }
    }
}