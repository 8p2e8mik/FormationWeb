using FormationWeb.Application.Contracts;
using FormationWeb.Domain.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace FormationWeb.WebAPIPro.Controllers;

[ApiController]
[Route("api/[controller]/[action]")]
public class UserDetailsController(IUserDetailsService<UserDetails> service) : ControllerBase
{
    [HttpGet]
    public async Task<ActionResult<IEnumerable<UserDetails>>> List()
    {
        try
        {
            return Ok(await service.GetAllAsync());
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

    [HttpPost]
    public async Task<ActionResult<UserDetails>> Create([FromBody] UserDetails userDetails)
    {
        try
        {
            return Ok(await service.CreateAsync(userDetails));
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
    public async Task<ActionResult<UserDetails>> Retrieve(Guid id)
    {
        try
        {
            var userDetails = await service.GetByIdAsync(id);

            if (userDetails is null)
                return NotFound();

            return Ok(userDetails);
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

    [HttpDelete("{id:guid}")]
    public async Task<ActionResult<UserDetails>> Delete(Guid id)
    {
        try
        {
            var userDeleted = await service.DeleteAsync(id);

            if (userDeleted is null)
                return NotFound();

            return Ok(userDeleted);
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