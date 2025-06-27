namespace FormationWeb.Domain.Contracts;

public interface IUserDetailsContract<T> where T : class
{
    Task<IEnumerable<T>> GetAllAsync();
    Task<T?> GetByIdAsync(Guid id);
    Task<T> CreateAsync(T userDetails);
    Task<T> UpdateAsync(T userDetails);
    Task<T?> DeleteAsync(Guid id);
}