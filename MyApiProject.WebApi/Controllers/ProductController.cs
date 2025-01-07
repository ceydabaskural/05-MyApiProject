using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MyApiProject.BusinessLayer.Abstract;
using MyApiProject.DtoLayer.ProductDtos;
using MyApiProject.EntityLayer.Concrete;

namespace MyApiProject.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly IProductService _productService;

        public ProductController(IProductService productService)
        {
            _productService = productService;
        }
        [HttpGet]
        public IActionResult ProductList()
        {
            var value = _productService.TGetAll();
            return Ok(value);
        }

        [HttpPost]
        public IActionResult CreateProduct(CreateProductDto createProductDto)
        {
            Product product = new Product();
            product.ProductName = createProductDto.ProductName;
            product.ProductPrice = createProductDto.ProductPrice;
            product.ProductStock = createProductDto.ProductStock;
            product.CategoryId = createProductDto.CategoryId;
            _productService.TInsert(product);
            return Ok("Ekleme başarılı.");
        }

        [HttpDelete]
        public IActionResult DeleteProduct(int id)
        {
            _productService.TDelete(id);
            return Ok("İşlem başarılı.");
        }

        [HttpGet("GetProduct")]
        public IActionResult GetProduct(int id)
        {
            var value = _productService.TGetById(id);
            return Ok(value);
        }

        [HttpPut]
        public IActionResult UpdateProduct(UpdateProductDto updateProductDto)
        {
            Product product = new Product();
            product.ProductId = updateProductDto.ProductId;
            product.ProductName = updateProductDto.ProductName;
            product.ProductPrice = updateProductDto.ProductPrice;
            product.ProductStock = updateProductDto.ProductStock;
            product.CategoryId = updateProductDto.CategoryId;
            _productService.TUpdate(product);
            return Ok("Güncelleme başarılı");
        }
    }
}
