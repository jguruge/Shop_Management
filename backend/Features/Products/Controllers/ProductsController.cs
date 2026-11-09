using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using ShopManagement.Api.Features.Products.Services;
using ShopManagement.Api.Features.Products.DTOs;

namespace ShopManagement.Api.Features.Products.Controllers;

[ApiController]
[Authorize]
[Route("api/[controller]")]
public class ProductsController(IProductService productService) : ControllerBase
{
    [HttpGet]
    public async Task<ActionResult<IReadOnlyList<ProductDto>>> GetAll(CancellationToken ct) =>
        Ok(await productService.GetAllAsync(ct));

    [HttpGet("{id:int}")]
    public async Task<ActionResult<ProductDto>> GetById(int id, CancellationToken ct) =>
        Ok(await productService.GetByIdAsync(id, ct));

    [HttpPost]
    public async Task<ActionResult<ProductDto>> Create(CreateProductRequest request, CancellationToken ct)
    {
        var product = await productService.CreateAsync(request, ct);
        return CreatedAtAction(nameof(GetById), new { id = product.Id }, product);
    }

    [HttpDelete("{id:int}")]
    public async Task<IActionResult> Delete(int id, CancellationToken ct)
    {
        await productService.DeleteAsync(id, ct);
        return NoContent();
    }
}
