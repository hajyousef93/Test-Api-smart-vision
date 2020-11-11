using SmartVision.Model;
using SmartVision.ModelViews.Users;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SmartVision.Data.Repository.Admin
{
    public interface IAdminRepository
    {
        Task<IEnumerable<ApplicationUser>> GetUsers();
        Task<ApplicationUser> AddUser(AddUserModel model);
        Task<ApplicationUser> GetUser(string id);
        Task<ApplicationUser> EditUser(EditUserModel model);
        Task<bool> DeleteUser(string id);

        Task<IEnumerable<Order>> GetOrderByUser(string id);



    }
}
