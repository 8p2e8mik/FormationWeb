using FormationWeb.Domain.Contracts;
using FormationWeb.Domain.Models;
using FormationWeb.Repository.Persistence;
using Microsoft.EntityFrameworkCore;

namespace FormationWeb.Repository.CommandQueries;

public class UserRepository(MyDbContext context) : IUserContract<User>
{
    // We are not going to implement the sync methods, there are here for reference
    public IEnumerable<User> GetAll()
    {
        throw new NotImplementedException();
    }

    public User GetById(Guid id)
    {
        throw new NotImplementedException();
    }

    public User GetByName(string name)
    {
        throw new NotImplementedException();
    }

    public User Create(User user)
    {
        throw new NotImplementedException();
    }

    public User Update(User user)
    {
        throw new NotImplementedException();
    }

    public User Delete(Guid id)
    {
        throw new NotImplementedException();
    }

    public async Task<IEnumerable<User>> GetAllAsync()
    {
        try
        {
            return await context.Users.ToListAsync();
        }
        catch (DbUpdateException e)
        {
            Console.WriteLine(e.Message);
            throw new Exception($"{nameof(GetAllAsync)} : {e.Message}");
        }
    }

    public async Task<User?> GetByIdAsync(Guid id)
    {
        try
        {
            return await context.Users.FindAsync(id);
        }
        catch (DbUpdateException e)
        {
            Console.WriteLine(e.Message);
            throw new Exception($"{nameof(GetAllAsync)} : {e.Message}");
        }
    }

    public Task<User?> GetByNameAsync(string name)
    {
        throw new NotImplementedException();
    }

    public async Task<User> CreateAsync(User user)
    {
        try
        {
            user.Id = Guid.NewGuid();
            await context.Users.AddAsync(user);
            await context.SaveChangesAsync();
            return user;
        }
        catch (DbUpdateException e)
        {
            Console.WriteLine(e.Message);
            throw new Exception($"{nameof(CreateAsync)} : {e.Message}");
        }
    }

    public Task<User> UpdateAsync(User user)
    {
        throw new NotImplementedException();
    }

    public async Task<User?> DeleteAsync(Guid id)
    {
        try
        {
            var user = await context.Users.FindAsync(id);

            if (user == null)
                return null;

            context.Users.Remove(user);
            await context.SaveChangesAsync();
            return user;
        }
        catch (DbUpdateException e)
        {
            Console.WriteLine(e.Message);
            throw new Exception($"{nameof(CreateAsync)} : {e.Message}");
        }
    }
}