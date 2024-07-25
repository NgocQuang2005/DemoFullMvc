using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShopDTO
{
    public class CategoryDTO
    {
        [Display(Name = "Mã loại sản phẩm ")]
        public int CategoryId { get; set; }
        [Display(Name = "Tên loại sản phẩm ")]
        public string CategoryName { get; set; }

    }
}
