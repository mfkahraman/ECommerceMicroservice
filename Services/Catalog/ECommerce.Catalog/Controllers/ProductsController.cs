using ECommerce.Catalog.DTOs.CategoryDtos;
using ECommerce.Catalog.DTOs.ProductDtos;
using ECommerce.Catalog.Entities;
using ECommerce.Catalog.Services.CategoryServices;
using ECommerce.Catalog.Services.ProductServices;
using Mapster;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ECommerce.Catalog.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController(IProductService productService) : ControllerBase
    {
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var products = await productService.GetAllAsync();
            var productDtos = products.Adapt<List<ResultProductDto>>();
            return Ok(productDtos);
        }

        [HttpPost]
        public async Task<IActionResult> Create(CreateProductDto productDto)
        {
            var prouduct = productDto.Adapt<Product>();
            await productService.CreateAsync(prouduct);
            return Ok("Ürün başarıyla oluşturuldu.");
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(string id)
        {
            var prouduct = await productService.GetByIdAsync(id);
            if (prouduct == null)
            {
                return BadRequest("Prouduct Not Found");
            }

            return Ok(prouduct);
        }

        [HttpPut]
        public async Task<IActionResult> Update(UpdateProductDto productDto)
        {
            var product = productDto.Adapt<Product>();
            await productService.UpdateAsync(product);
            return Ok("Ürün başarıyla güncellendi.");
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(string id)
        {
            await productService.DeleteAsync(id);
            return Ok("Ürün başarıyla silindi.");
        }
    }
}
