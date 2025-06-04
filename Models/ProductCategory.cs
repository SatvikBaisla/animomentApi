using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace animomentapi.Models
{
    public class ProductCategory
    {
        [Key]
        public int CategoryId { get; set; }
        [Required]
        public string CategoryName { get; set; } = string.Empty;
        [Required]
        public string FilterName { get; set; } = string.Empty;
        public string? ImgUrl { get; set; }
    }
}