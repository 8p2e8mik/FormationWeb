using Formation.WebAPI.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Formation.WebAPI.Controllers;

[Route("api/[controller]")]
[ApiController]
public class RolesController(MyDbContext context) : ControllerBase
{
    [HttpGet]
    public async Task<ActionResult<IEnumerable<Role>>> List()
    {
        try
        {
            var roles = await context.Roles.ToListAsync();
            return Ok(roles);
        }
        catch (DbUpdateException e)
        {
            return StatusCode(
                StatusCodes.Status500InternalServerError,
                new { message = $"Database Error : {e.Message}" });
        }
        catch (Exception e)
        {
            return StatusCode(
                StatusCodes.Status500InternalServerError,
                new { message = $"Unexpected Error : {e.Message}" });
        }
    }

    [HttpGet("{id:guid}")]
    public async Task<ActionResult<Role>> GetById(Guid id)
    {
        var role = await context.Roles.FindAsync(id);
        return Ok(role);
    }

    [HttpDelete("{id:guid}")]
    public async Task<ActionResult<Role>> Delete(Guid id)
    {
        try
        {
            var role = await context.Roles.FindAsync(id);
            if (role == null)
            {
                return NotFound();
            }

            context.Roles.Remove(role);
            await context.SaveChangesAsync();
            return Ok(role);
        }
        catch (DbUpdateException e)
        {
            return StatusCode(
                StatusCodes.Status500InternalServerError,
                new { message = $"Database Error : {e.Message}" });
        }
        catch (Exception e)
        {
            return StatusCode(
                StatusCodes.Status500InternalServerError,
                new { message = $"Unexpected Error : {e.Message}" });
        }
    }
}