using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Products.Models
{
    public class Product
    {
        public int Id { get; set; }
        [MaxLength(50)]
        [Required]
        public string Name { get; set; }
        [MaxLength(100)]
        public string Description { get; set; }
        [Range(0, 100, ErrorMessage = "Value for {0} must be between {1} and {2}.")]
        public int? AgeRestriction { get; set; }
        [MaxLength(50)]
        [Required]
        public string Company { get; set; }
        [Required]
        [Range(1, 1000, ErrorMessage = "Value for {0} must be between {1} and {2}.")]
        public decimal Price { get; set; }
    }
}
