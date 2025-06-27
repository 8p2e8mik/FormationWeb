using FormationWeb.Domain.Contracts;
using FormationWeb.Domain.Models;
using FormationWeb.Repository.Persistence;
using Microsoft.EntityFrameworkCore;

namespace FormationWeb.Repository.CommandQueries;

public class UserDetailsRepository(MyDbContext context) : IUserDetailsContract<UserDetails>
{
    public async Task<IEnumerable<UserDetails>> GetAllAsync()
    {
        try
        {
            return await context.UserDetails.ToListAsync();
        }
        catch (Exception e)
        {
            Console.WriteLine(e.Message);
            throw new Exception($"{nameof(GetAllAsync)} : {e.Message}");
        }
    }

    public async Task<UserDetails?> GetByIdAsync(Guid id)
    {
        try
        {
            return await context.UserDetails.FindAsync(id);
        }
        catch (Exception e)
        {
            Console.WriteLine(e.Message);
            throw new Exception($"{nameof(GetAllAsync)} : {e.Message}");
        }
    }

    public async Task<UserDetails> CreateAsync(UserDetails userDetails)
    {
        try
        {
            userDetails.Id = Guid.NewGuid();
            await context.UserDetails.AddAsync(userDetails);
            await context.SaveChangesAsync();
            return userDetails;
        }
        catch (DbUpdateException e)
        {
            Console.WriteLine(e.Message);
            throw new Exception($"{nameof(CreateAsync)} : {e.Message}");
        }
    }

    public Task<UserDetails> UpdateAsync(UserDetails user)
    {
        throw new NotImplementedException();
    }

    public async Task<UserDetails?> DeleteAsync(Guid id)
    {
        try
        {
            var userDetails = await context.UserDetails.FindAsync(id);

            if (userDetails == null)
                return null;

            context.UserDetails.Remove(userDetails);
            await context.SaveChangesAsync();
            return userDetails;
        }
        catch (DbUpdateException e)
        {
            Console.WriteLine(e.Message);
            throw new Exception($"{nameof(CreateAsync)} : {e.Message}");
        }
    }
}