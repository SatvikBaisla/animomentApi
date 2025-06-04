using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace animomentapi.Models
{
    public class CartItem
    {
        [Key]
        public int ItemId { get; set; }
        public int? CartId { get; set; }
        public int? ProductId { get; set; }
        public DateTime AddedDate { get; set; } = DateTime.Now;
        [ForeignKey("CartId")]
        public Cart? Cart { get; set; }
        [ForeignKey("ProductId")]
        public Product? Product { get; set; }
    }
}