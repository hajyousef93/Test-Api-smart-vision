using SmartVision.Data;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace SmartVision.Model
{
    public class Order
    {
        [Key]
        public int Id { get; set; }
        public DateTime OrderDate { get; set; }
        public string UserId { get; set; }
        public virtual ApplicationUser  User { get; set; }
        public virtual ICollection <OrderProduct> OrderProducts { get; set; }
    }
}
