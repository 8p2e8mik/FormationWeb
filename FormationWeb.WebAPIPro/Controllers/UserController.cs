using FormationWeb.Application.Contracts;
using FormationWeb.Domain.Models;
using Microsoft.AspNetCore.Mvc;

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
        
        
    }
}
