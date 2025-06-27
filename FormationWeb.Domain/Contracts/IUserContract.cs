namespace FormationWeb.Domain.Contracts;

public interface IUserContract<T> where T : class
{
    IEnumerable<T> GetAll();
    T GetById(Guid id);
    T GetByName(string name);
    T Create(T user);
    T Update(T user);
    T Delete(Guid id);

    Task<IEnumerable<T>> GetAllAsync();
    Task<T?> GetByIdAsync(Guid id);
    Task<T?> GetByNameAsync(string name);
    Task<T> CreateAsync(T user);
    Task<T> UpdateAsync(T user);
    Task<T?> DeleteAsync(Guid id);
}
