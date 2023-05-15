using System.Net;
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
            return BadRequest(category.GetNotifications());
            
        try
        {
            context.Categories.Add(category);
            context.SaveChanges();
        }
        catch (DbUpdateException ex){
            return StatusCode((int)HttpStatusCode.InternalServerError, " [Error: 500X1] -  Ops! Não foi possível adicionar a categoria.");
            throw;
        }
        catch (Exception ex)
        {
            return StatusCode((int)HttpStatusCode.InternalServerError, "[Error: 500X2] - Ops! Ocorreu um erro interno no servidor.");
            throw;
        }

        return category == null ? Ok(category) : NotFound();
    }
}