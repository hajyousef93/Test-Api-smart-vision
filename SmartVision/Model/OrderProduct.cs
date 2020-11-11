using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace SmartVision.Model
{
    public class OrderProduct
    {
        [Key]
        public int Id { get; set; }
        public int Quantity { get; set; }
        public float Unit_price { get; set; }
        public int OrderId { get; set; }
        public virtual Order Order { get; set; }
        public int ProductId { get; set; }
        public virtual Product  Product { get; set; }
    }
}
