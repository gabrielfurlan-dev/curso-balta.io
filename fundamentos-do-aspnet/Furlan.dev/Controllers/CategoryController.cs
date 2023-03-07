using Furlan.dev.Data;
using Furlan.dev.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Furlan.dev.Controllers;

[ApiController]
public class CategoryController : ControllerBase
{
    [HttpGet("v1/categories")]
    public async Task<IActionResult> GetAsync(
        [FromServices] BlogDataContext context
    )
        => Ok(await context.Categories.ToListAsync());

    [HttpGet("v1/categories/{id:int}")]
    public async Task<IActionResult> GetByIdAsync(
    [FromRoute] int id,
    [FromServices] BlogDataContext context
    )
    {
        var category = await context.Categories.FirstOrDefaultAsync(x => x.Id == id);

        return category == null ? Ok(category) : NotFound();
    }

    [HttpPost("v1/categories")]
    public async Task<IActionResult> PostAsync(
    [FromBody] Category category,
    [FromServices] BlogDataContext context
    )
    {
        if(!category.EhValido())
            return BadRequest();
            
        context.Categories.Add(category);
        context.SaveChanges();

        return category == null ? Ok(category) : NotFound();
    }
}