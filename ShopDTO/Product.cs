using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShopDTO
{
    public class ProductDTO
    {
        [Display(Name = "Mã sản phẩm ")]
        public int ProductId { get; set; }
        [Display(Name = "Tên sản phẩm ")]
        public string ProductName { get; set; }
        [Display(Name = "Loại sản phẩm ")]
        public int CategoryId { get; set; }
        [Display(Name = "Tên loại sản phẩm ")]
        public string CategoryName { get; set; }
    }
}
