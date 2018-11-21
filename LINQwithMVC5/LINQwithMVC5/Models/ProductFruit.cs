using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace LINQwithMVC5.Models
{
    public class ProductFruit
    {
        [Key]
        public int Id { get; set; }
        [Required(ErrorMessage = "Can not be null or empty.")]
        public string Name { get; set; }
        [Required(ErrorMessage = "Can not be null or empty.")]
        public int Qty { get; set; }
        [Required(ErrorMessage = "Can not be null or empty.")]
        public decimal Price { get; set; }
        [Required(ErrorMessage = "Can not be null or empty.")]
        public DateTime EntryDate { get; set; }

    }
}