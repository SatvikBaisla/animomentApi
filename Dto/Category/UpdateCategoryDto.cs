using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace animomentapi.Dto.Category
{
    public class UpdateCategoryDto
    {
        public string CategoryName { get; set; } = string.Empty;
        public string FilterName { get; set; } = string.Empty;
        public string? ImgUrl { get; set; }
    }
}