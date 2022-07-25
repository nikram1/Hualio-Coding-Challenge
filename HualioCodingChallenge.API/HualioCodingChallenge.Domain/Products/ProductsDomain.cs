using HualioCodingChallenge.Core.Domain.Models;
using HualioCodingChallenge.Core.RequestModels;
using HualioCodingChallenge.Repository.UnitOfWork;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace HualioCodingChallenge.Domain.Products
{
    public class ProductsDomain : IProductsDomain
    {
        public IUnitOfWork _unitOfWork;
        public ProductsDomain(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public void CreateProduct(Product model)
        {
            _unitOfWork.Products.Add(model);
            _unitOfWork.Complete();
        }

        public void UpdateProduct(int productId, Product model)
        {
            Product existingProduct = _unitOfWork.Products.GetById(productId);
            existingProduct.Name = model.Name;
            existingProduct.ProductImage = model.ProductImage;
            existingProduct.Description = model.Description;

            _unitOfWork.Products.Add(model);
            _unitOfWork.Complete();
        }

        public IEnumerable<Product> GetProducts(RequestWithPagingModel model)
        {
            return _unitOfWork.Products.GetProductsWithPagination(model);
        }

        public Product GetProductById(int productId)
        {
            return _unitOfWork.Products.GetById(productId);
        }

        public void DeleteProduct(int productId)
        {
            _unitOfWork.Products.Remove(new Product { ProductID = productId });
            _unitOfWork.Complete();
        }
    }
}