using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace animomentapi.Models
{
    public class Product
    {
        [Key]
        public int ProductId { get; set; }
        public int? CategoryId { get; set; }
        [Required]
        public int ArticleNumber { get; set; }
        [Column(TypeName = "NVARCHAR(200)")]
        public string Title { get; set; } = string.Empty;
        public string? Description { get; set; }
        [Column(TypeName = "decimal(10, 2)")]
        public decimal Price { get; set; }
        public string? ImgUrl { get; set; }
        public string? ImgUrl2 { get; set; }
        public string? ImgUrl3 { get; set; }
        public string? ImgUrl4 { get; set; }
        public string? ImgUrl5 { get; set; }
        public DateTime created_date { get; set; } = DateTime.Now;
        public DateTime updated_date { get; set; } = DateTime.Now;
        [ForeignKey("CategoryId")]
        public ProductCategory? ProductCategory { get; set; } // Navigation property connects -> category id 
    }
}