using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using sda_onsite_2_csharp_backend_teamwork.src.Abstractions;
using sda_onsite_2_csharp_backend_teamwork.src.DTOs;

namespace sda_onsite_2_csharp_backend_teamwork.src.Controllers;


public class ProductController : BaseController
{
    private IProductService _productSarvice;
    public ProductController(IProductService productSarvice)
    {
        _productSarvice = productSarvice;
    }

    [HttpGet]

    [ProducesResponseType(StatusCodes.Status200OK)]
    public ActionResult<IEnumerable<ProductWithStock>> FindAll([FromQuery(Name = "limit")] int limit, [FromQuery(Name = "offset")] int offset,
    [FromQuery(Name = "searchBy")] string? searchBy)
    {
        return Ok(_productSarvice.FindAll(limit, offset, searchBy));
    }

    [HttpGet("{id}")]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesResponseType(StatusCodes.Status200OK)]
    public ActionResult<ProductDTO> FindeOne(Guid id)
    {
        ProductDTO? findId = _productSarvice.FindeOne(id);

        if (findId is null) return NotFound();
        return Ok(findId);

    }
    [HttpPost]
    // [Authorize(Roles = "Admin")]
    [ProducesResponseType(StatusCodes.Status201Created)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public ActionResult<ProductDTO> CreateOne([FromBody] ProductReadDTO newProduct)
    {
        if (newProduct is not null)
        {
            var product = _productSarvice.CreateOne(newProduct);
            return CreatedAtAction(nameof(CreateOne), product);
        }
        return BadRequest();
    }

    [HttpDelete("{id}")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    public ActionResult DeleteById(Guid id)
    {
        _productSarvice.DeleteById(id);
        return NoContent();
    }

    [HttpPatch("{productId}")]
    [ProducesResponseType(StatusCodes.Status202Accepted)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public ActionResult<Product> UpdateOne(Guid productId, [FromBody] ProductUpdateDto updateProduct)
    {
        var foundProduct = FindeOne(productId);

        if (foundProduct != null)
        {
            ProductReadDTO product = _productSarvice.UpdateOne(productId, updateProduct);

            return Accepted(product);
        }
        return NotFound();
    }

}
