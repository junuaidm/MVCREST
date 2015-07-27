using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MVCE1Demo.Models.Product
{
    public class ProductModel
    {
        [Key]
        public int ProductId { get; set; }
        [Required]
        public string ProductName { get; set; }
    }
}
