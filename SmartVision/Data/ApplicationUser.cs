using Microsoft.AspNetCore.Identity;
using SmartVision.Model;
using System.Collections.Generic;

namespace SmartVision.Data
{
    public class ApplicationUser:IdentityUser
    {
        public virtual ICollection<Order> Orders { get; set; }
    }
}