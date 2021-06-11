using System;
using System.ComponentModel.DataAnnotations;

namespace ShoesWebsite.Models
{
    public class ShoesModel
    {
        public Guid Id { get; set; }
        [Required]
        public string Brand { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public string Category { get; set; }
        [Range(1, 100000)]
        public decimal Price { get; set; }
    }
}
