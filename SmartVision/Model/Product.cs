using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace SmartVision.Model
{
    public class Product
    {
        [Key]
        public int Id { get; set; }
        [Required]
        [Display(Name = "Product Name")]
        public string Name { get; set; }
        [Required]
        [Display(Name = "Product Price")]
        public float Price { get; set; }
        public virtual ICollection<OrderProduct> OrderProducts { get; set; }
    }
}
