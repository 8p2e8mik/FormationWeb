using FormationWeb.Domain.Contracts;
using FormationWeb.Domain.Models;

namespace FormationWeb.Application.Services;

public class UserService
{
    private readonly IUserContract<User> _userRepository;

    public UserService(IUserContract<User> userRepository)
    {
        _userRepository = userRepository;
    }

    public async Task<User> CreateUser(User user)
    {
        return await _userRepository.CreateAsync(user);
    }
    
    public async Task<User?> DeleteUser(Guid id)
    {
        return await _userRepository.DeleteAsync(id);
    }
}