using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using SmartVision.Model;
using SmartVision.ModelViews.Orders;

namespace SmartVision.Data.Repository.OrderRepo
{
    public class OrderRepository : IOrderRepository
    {
        private readonly ApplicationDbContext _db;

        public OrderRepository(ApplicationDbContext db)
        {
            _db = db;
        }
        public async Task<Order> AddOrder()
        {
            var Order = new Order
            {
                OrderDate = DateTime.Now,
                UserId= _db.Users.Find(ClaimTypes.NameIdentifier)?.Id

            };
            await _db.Orders.AddAsync(Order);

            return Order;
        }

        public async Task<bool> DeleteOrder(int id)
        {
            var order = await _db.Orders.FirstOrDefaultAsync(x => x.Id == id);
            if (order != null)
            {
                _db.Orders.Remove(order);

                await _db.SaveChangesAsync();

                return true;
            }
            return false;

        }

        public async Task<Order> EditOrder(EditOrderModel model)
        {
            var order = await _db.Orders.FirstOrDefaultAsync(x => x.Id == model.Id);
            if (order == null)
            {
                return null;
            }
            order.OrderDate = model.OrderDate;
            
            _db.Orders.Attach(order);
            _db.Entry(order).Property(x => x.OrderDate).IsModified = true;
           
            await _db.SaveChangesAsync();
            return order;
        }

        public async Task<Order> GetOrder(int id)
        {
            var order = await _db.Orders.FirstOrDefaultAsync(x => x.Id == id);
            if (order == null)
            {
                return null;
            }
            return order;
        }

        public async Task<IEnumerable<Order>> GetOrders()
        {
            return await _db.Orders.ToListAsync();
        }
    }
}
