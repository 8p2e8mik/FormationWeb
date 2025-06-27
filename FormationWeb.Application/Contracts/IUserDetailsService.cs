namespace FormationWeb.Application.Contracts;

public interface IUserDetailsService<T> where T : class
{
    Task<IEnumerable<T>> GetAllAsync();
    Task<T?> GetByIdAsync(Guid id);
    Task<T> CreateAsync(T userDetail);
    Task<T> UpdateAsync(T userDetail);
    Task<T?> DeleteAsync(Guid id);
}