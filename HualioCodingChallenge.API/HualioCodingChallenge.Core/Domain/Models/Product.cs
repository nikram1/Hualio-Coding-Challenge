using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace HualioCodingChallenge.Core.Domain.Models
{
    public class Product
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Key]
        public int ProductID { get; set; }
        public double Price { get; set; }
        public string Name { get; set; }
        public string ProductImage { get; set; }
        public string Description { get; set; }
    }
}
