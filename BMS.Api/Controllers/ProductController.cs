using BMS.Core.DTOs;
using BMS.Core.Entities;
using BMS.Core.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace BMS.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ProductController : ControllerBase
    {
        private readonly IProductRepository _productRepository;

        public ProductController(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }

        // 1️⃣ CREATE PRODUCT
        // POST: api/product
        [HttpPost]
        public async Task<IActionResult> Create(CreateProductDto dto)
        {
            var product = new Product
            {
                Name = dto.Name,
                Price = dto.Price,
                StockQuantity = dto.StockQuantity,
                IsActive = true
            };

            var result = await _productRepository.CreateAsync(product);
            return Ok(result);
        }

        // 2️⃣ GET ALL PRODUCTS
        // GET: api/product
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var products = await _productRepository.GetAllAsync();
            return Ok(products);
        }

        // 3️⃣ GET PRODUCT BY ID
        // GET: api/product/{id}
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var product = await _productRepository.GetByIdAsync(id);

            if (product == null)
                return NotFound("Product not found");

            return Ok(product);
        }

        // 4️⃣ UPDATE PRODUCT
        // PUT: api/product/{id}
        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, UpdateProductDto dto)
        {
            var existingProduct = await _productRepository.GetByIdAsync(id);

            if (existingProduct == null)
                return NotFound("Product not found");

            existingProduct.Name = dto.Name;
            existingProduct.Price = dto.Price;
            existingProduct.StockQuantity = dto.StockQuantity;

            await _productRepository.UpdateAsync(existingProduct);
            return Ok("Product updated successfully");
        }

        // 5️⃣ DELETE PRODUCT (SOFT DELETE)
        // DELETE: api/product/{id}
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var product = await _productRepository.GetByIdAsync(id);

            if (product == null)
                return NotFound("Product not found");

            await _productRepository.DeleteAsync(product);
            return Ok("Product deleted successfully");
        }
    }
}
