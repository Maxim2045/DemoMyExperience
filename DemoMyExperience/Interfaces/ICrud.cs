namespace DemoMyExperience.Interfaces
{
    public interface ICrud<T>
    {
        Task<IEnumerable<T>> GetAll();

        Task<T> Get(Guid id);

        Task Create(T entity);

        Task Update(T entity);

        Task Delete(Guid id);
    }
}
