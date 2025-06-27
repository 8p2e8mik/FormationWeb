namespace FormationWeb.Application.Contracts;

public interface IUserService<T> where T : class
{
    Task<IEnumerable<T>> GetAllAsync();
    Task<T?> GetByIdAsync(Guid id);
    Task<T?> GetByNameAsync(string name);
    Task<T> CreateAsync(T user);
    Task<T> UpdateAsync(T user);
    Task<T?> DeleteAsync(Guid id);
}