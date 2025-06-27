using FormationWeb.Application.Contracts;
using FormationWeb.Domain.Contracts;
using FormationWeb.Domain.Models;

namespace FormationWeb.Application.Services;

public class UserDetailsService(IUserDetailsContract<UserDetails> repository) : IUserDetailsService<UserDetails>
{
    public async Task<IEnumerable<UserDetails>> GetAllAsync()
    {
        return await repository.GetAllAsync();
    }

    public async Task<UserDetails?> GetByIdAsync(Guid id)
    {
        return await repository.GetByIdAsync(id);
    }

    public async Task<UserDetails> CreateAsync(UserDetails userDetails)
    {
        return await repository.CreateAsync(userDetails);
    }

    public Task<UserDetails> UpdateAsync(UserDetails userDetails)
    {
        throw new NotImplementedException();
    }

    public async Task<UserDetails?> DeleteAsync(Guid id)
    {
        return await repository.DeleteAsync(id);
    }
}