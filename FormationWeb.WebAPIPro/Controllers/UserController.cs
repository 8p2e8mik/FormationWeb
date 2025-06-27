using FormationWeb.Application.Contracts;
using FormationWeb.Domain.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace FormationWeb.WebAPIPro.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserService<User> _service;

        public UserController(IUserService<User> service)
        {
            _service = service;
        }

        [HttpPost]
        public async Task<ActionResult<User>> CreateUser([FromBody] User user)
        {
            if (user is null)
                return BadRequest(new { message = "User cannot be null" });

            try
            {
                return Ok(await _service.CreateAsync(user));
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
        public async Task<ActionResult<User>> DeleteUser(Guid id)
        {
            try
            {
                return Ok(await _service.DeleteAsync(id));
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
}