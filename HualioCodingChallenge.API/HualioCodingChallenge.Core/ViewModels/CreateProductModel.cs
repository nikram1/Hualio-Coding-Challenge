using System;
using System.Collections.Generic;
using System.Text;

namespace HualioCodingChallenge.Core.ViewModels
{
    public class CreateProductModel
    {
        public int ProductID { get; set; }
        public double Price { get; set; }
        public string Name { get; set; }
        public string ProductImage { get; set; }
        public string Description { get; set; }
    }
}
