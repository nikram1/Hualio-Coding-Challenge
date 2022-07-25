using Dapper;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using HualioCodingChallenge.Helpers.Helper;
using HualioCodingChallenge.Core.Domain.Models;
using HualioCodingChallenge.Core.Domain;
using System.Threading.Tasks;
using HualioCodingChallenge.Core.RequestModels;

namespace HualioCodingChallenge.Repository
{
    public class ProductRepository : GenericRepository<Product>, IProductRepository
    {
        private HualioCodingChallengeDBContext _context;
        public ProductRepository(HualioCodingChallengeDBContext context) : base(context)
        {
            _context = context;
        }

        public IEnumerable<Product> GetProductsWithPagination(RequestWithPagingModel model)
        {

            var products = from product in _context.Products select product;
            if (string.IsNullOrEmpty(model.SearchValue))
                products = products.Where(x => model.SearchValue.Contains(x.Name));

            if (model.SortOrder.ToLower() == "asc")
                products = products.OrderBy(a => a.GetType().GetProperty(model.SortColumn));

            return products.Take(model.PageSize).Skip(model.PageSize * model.PageNo).ToList();
        }
    }
}