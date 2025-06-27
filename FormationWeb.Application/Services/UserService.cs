using FormationWeb.Domain.Contracts;
using FormationWeb.Domain.Models;

namespace FormationWeb.Application.Services;

public class UserService
{
    private readonly IUserContract<User> _userContract;

    public UserService(IUserContract<User> userContract)
    {
        _userContract = userContract;
    }
}