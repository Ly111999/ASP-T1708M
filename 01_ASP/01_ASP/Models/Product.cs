using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace _01_ASP.Models
{
    public class Product
    {
        [Key]
        public int Id { get; set; }
        [DisplayName("Name")]
        [Required(ErrorMessage = "Product name is required")]
        [StringLength(50, MinimumLength = 5)]
        public string ProductName { get; set; }
        [Required(ErrorMessage = "Price is required")]
        public decimal Price { get; set; }
        [Required(ErrorMessage = "Description is required")]
        [StringLength(300, MinimumLength = 10)]
        public string Description { get; set; }
    }
}