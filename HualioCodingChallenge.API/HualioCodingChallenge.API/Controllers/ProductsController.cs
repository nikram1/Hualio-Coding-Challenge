using Microsoft.AspNetCore.Mvc;
using System;
using HualioCodingChallenge.Domain.Products;
using HualioCodingChallenge.Core.Domain.Models;
using HualioCodingChallenge.Core.RequestModels;
using HualioCodingChallenge.Core.ViewModels;

namespace HualioCodingChallenge.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController: ControllerBase
    {
        public IProductsDomain _productsDomain;
        public ProductsController(IProductsDomain productsDomain)
        {
            _productsDomain = productsDomain;
        }

        [Route("createProduct")]
        [HttpPost]
        public IActionResult CreateProduct([FromBody] CreateProductModel model)
        {
            try
            {
                _productsDomain.CreateProduct(new Product
                {
                    ProductID = model.ProductID,
                    Price = model.Price,
                    Name = model.Name,
                    ProductImage = model.ProductImage,
                    Description = model.Description
                });
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [Route("updateProduct/{productId}")]
        [HttpPut]
        public IActionResult UpdateProduct(int productId, [FromBody] CreateProductModel model)
        {
            try
            {
                _productsDomain.UpdateProduct(productId, new Product
                {
                    ProductID = model.ProductID,
                    Price = model.Price,
                    Name = model.Name,
                    ProductImage = model.ProductImage,
                    Description = model.Description
                });
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [Route("getProducts")]
        [HttpPost]
        public IActionResult GetProducts([FromBody] RequestWithPagingModel model)
        {
            try
            {
                return Ok(_productsDomain.GetProducts(model));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }


        [Route("getProductrById/{productId}")]
        [HttpGet]
        public IActionResult GetProductById(int productId)
        {
            try
            {
                return Ok(_productsDomain.GetProductById(productId));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [Route("deleteProductById/{productId}")]
        [HttpDelete]
        public IActionResult DeleteProduct(int productId)
        {
            try
            {
                _productsDomain.DeleteProduct(productId);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}