using FormationWeb.Application.Contracts;
using FormationWeb.Domain.Contracts;
using FormationWeb.Domain.Models;

namespace FormationWeb.Application.Services;

public class UserService : IUserService<User>
{
    private readonly IUserContract<User> _userRepository;

    public UserService(IUserContract<User> userRepository)
    {
        _userRepository = userRepository;
    }

    // public async Task<User> CreateUser(User user)
    // {
    //     return await _userRepository.CreateAsync(user);
    // }
    //
    // public async Task<User?> DeleteUser(Guid id)
    // {
    //     return await _userRepository.DeleteAsync(id);
    // }

    public Task<IEnumerable<User>> GetAllAsync()
    {
        throw new NotImplementedException();
    }

    public Task<User?> GetByIdAsync(Guid id)
    {
        throw new NotImplementedException();
    }

    public Task<User?> GetByNameAsync(string name)
    {
        throw new NotImplementedException();
    }

    public async Task<User> CreateAsync(User user)
    {
        return await _userRepository.CreateAsync(user);
    }

    public Task<User> UpdateAsync(User user)
    {
        throw new NotImplementedException();
    }

    public async Task<User?> DeleteAsync(Guid id)
    {
        return await _userRepository.DeleteAsync(id);
    }
}