using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using SmartVision.Model;
using SmartVision.ModelViews.Users;

namespace SmartVision.Data.Repository.Admin
{
    public class AdminRepository : IAdminRepository
    {
        private readonly ApplicationDbContext _db;
        private readonly UserManager<ApplicationUser> _userManager;

        public AdminRepository(ApplicationDbContext db, UserManager<ApplicationUser> userManager)
        {
            _db = db;
            _userManager = userManager;
        }
        public async Task<ApplicationUser> AddUser(AddUserModel model)
        {
            if (model == null)
            {
                return null;
            }
            var user = new ApplicationUser
            {
                UserName = model.Username,
                Email = model.Email,
                EmailConfirmed = model.EmailConfirmed,
               
            };
            var result = await _userManager.CreateAsync(user, model.Password);
            if (result.Succeeded)
            {
                return user;
            }
            return null;
        }

        public async Task<bool> DeleteUser(string id)
        {
            var User = await _db.Users.FirstOrDefaultAsync(x => x.Id == id);
            if (User != null)
            {
                _db.Users.Remove(User);

                await _db.SaveChangesAsync();

                return true;
            }
            return false;
        }

        public async Task<ApplicationUser> EditUser(EditUserModel model)
        {
            if (model.Id == null)
            {
                return null;
            }
            var user = await _db.Users.FirstOrDefaultAsync(x => x.Id == model.Id);
            if (user == null)
            {
                return null;
            }
            if (model.Password != user.PasswordHash)
            {
                var result = await _userManager.RemovePasswordAsync(user);
                if (result.Succeeded)
                {
                    await _userManager.AddPasswordAsync(user, model.Password);
                }
            }
            user.UserName = model.Username;
            user.Email = model.Email;
          
            user.EmailConfirmed = model.EmailConfirmed;
            _db.Users.Attach(user);
            _db.Entry(user).Property(x => x.Email).IsModified = true;
            _db.Entry(user).Property(x => x.UserName).IsModified = true;
            _db.Entry(user).Property(x => x.EmailConfirmed).IsModified = true;
            await _db.SaveChangesAsync();
            return user;
        }

        public async Task<IEnumerable<Order>> GetOrderByUser(string id)
        {
            var user = _db.Users.FirstOrDefaultAsync(x => x.Id == id);
            if(user == null)
            {
                return null;
            }
            var orders = await _db.Orders.Where(x=>x.UserId==id).ToArrayAsync();

           
            return orders;
        }

        public async Task<ApplicationUser> GetUser(string id)
        {
            if (id == null)
            {
                return null;
            }
            var user = await _db.Users.FirstOrDefaultAsync(x => x.Id == id);
            if (user == null)
            {
                return null;
            }
            return user;
        }

        public async Task<IEnumerable<ApplicationUser>> GetUsers()
        {
            return await _db.Users.ToListAsync();
        }
    }
}
