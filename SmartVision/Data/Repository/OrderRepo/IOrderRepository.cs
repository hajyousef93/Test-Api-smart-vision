using SmartVision.Model;
using SmartVision.ModelViews.Orders;
using SmartVision.ModelViews.Users;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SmartVision.Data.Repository.OrderRepo
{
    interface IOrderRepository
    {
        Task<IEnumerable<Order>> GetOrders();
        Task<Order> AddOrder();
        Task<Order> GetOrder(int id);
        Task<Order> EditOrder(EditOrderModel model);
        Task<bool> DeleteOrder(int id);
    }
}
