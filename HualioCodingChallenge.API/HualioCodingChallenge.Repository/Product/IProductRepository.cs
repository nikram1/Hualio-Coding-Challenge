using System;
using System.Collections.Generic;
using System.Text;
using HualioCodingChallenge.Core.Domain.Models;
using HualioCodingChallenge.Core.RequestModels;

namespace HualioCodingChallenge.Repository
{
    public interface IProductRepository : IGenericRepository<Product>
    {
        IEnumerable<Product> GetProductsWithPagination(RequestWithPagingModel model);
    }
}
