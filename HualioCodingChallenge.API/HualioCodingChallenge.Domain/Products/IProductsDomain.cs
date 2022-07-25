using HualioCodingChallenge.Core.Domain.Models;
using HualioCodingChallenge.Core.RequestModels;
using System;
using System.Collections.Generic;
using System.Text;

namespace HualioCodingChallenge.Domain.Products
{
    public interface IProductsDomain
    {
        void CreateProduct(Product model);
        void UpdateProduct(int productId, Product model);
        IEnumerable<Product> GetProducts(RequestWithPagingModel model);
        Product GetProductById(int productId);
        void DeleteProduct(int productId);
    }
}
