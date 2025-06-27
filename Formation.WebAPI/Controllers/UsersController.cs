using Formation.WebAPI.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Formation.WebAPI.Controllers;

[Route("api/[controller]/[action]")]
[ApiController]
public class UsersController : ControllerBase
{
    private readonly MyDbContext _context;

    public UsersController(MyDbContext context)
    {
        _context = context;
    }

    [HttpGet]
    public async Task<ActionResult<IEnumerable<User>>> List()
    {
        try
        {
            var users = await _context.Users.Include(u => u.Details).ToListAsync();
            if (users.Count == 0)
                return NotFound("No users found in the database");
            return Ok(users);
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
    public async Task<ActionResult<User>> GetById(Guid id)
    {
        try
        {
            return Ok(await _context.Users.FindAsync(id));
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
    public async Task<ActionResult<User>> CreateUser([FromBody] User user)
    {
        try
        {
            user.Id = Guid.NewGuid();

            if (user.Details != null)
            {
                user.Details.Id = Guid.NewGuid();
                user.Details.UserId = user.Id;
            }

            foreach (var userRole in user.Roles)
            {
                userRole.Id = Guid.NewGuid();
                userRole.UserId = user.Id;
            }

            await _context.Users.AddAsync(user);
            await _context.SaveChangesAsync();
            return user;
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

    [HttpPut]
    public async Task<ActionResult<User>> UpdateUser([FromBody] User user)
    {
        try
        {
            var userToUpdate = await _context.Users.Include(u => u.Details).FirstOrDefaultAsync(u => u.Id == user.Id);

            if (userToUpdate == null)
            {
                return NotFound();
            }

            userToUpdate.Email = user.Email;
            userToUpdate.Password = user.Password;
            userToUpdate.FirstName = user.FirstName;
            userToUpdate.LastName = user.LastName;

            if (user.Details != null)
            {
                if (userToUpdate.Details == null)
                {
                    // user.Details.Id = Guid.NewGuid();
                    // user.Details.UserId = user.Id;
                    // userToUpdate.Details = user.Details;
                    // _context.UserDetails.Add(userToUpdate.Details);
                    userToUpdate.Details = new UserDetails
                    {
                        Id = Guid.NewGuid(),
                        UserId = userToUpdate.Id,
                        Address = user.Details.Address,
                        PhoneNumber = user.Details.PhoneNumber,
                    };
                }
                else
                {
                    userToUpdate.Details.Address = user.Details.Address;
                    userToUpdate.Details.PhoneNumber = user.Details.PhoneNumber;
                }
            }

            _context.Users.Update(userToUpdate);
            
            await _context.SaveChangesAsync();
            return Ok(userToUpdate);
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
            var user = await _context.Users.FindAsync(id);
            if (user == null)
            {
                return NotFound();
            }

            _context.Users.Remove(user);
            await _context.SaveChangesAsync();
            return Ok(user);
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

    [HttpGet]
    public async Task<ActionResult<IEnumerable<User>>> FindByString(string searchWord)
    {
        try
        {
            // var users = await _context.Users.Where(u =>
            //         u.FirstName.Contains(searchWord) ||
            //         u.LastName.Contains(searchWord))
            //     .ToListAsync();

            var users = await _context.Users.Where(u =>
                    u.FirstName.ToLower().Contains(searchWord.ToLower()) ||
                    u.LastName.ToLower().Contains(searchWord.ToLower()))
                .ToListAsync();

            // var users = await _context.Users.Where(u =>
            //         u.FirstName.ToLower() == searchWord.ToLower() ||
            //         u.LastName.ToLower() == searchWord.ToLower())
            //     .ToListAsync();

            if (users.Count == 0)
                return NotFound("No users found");

            return Ok(users);
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