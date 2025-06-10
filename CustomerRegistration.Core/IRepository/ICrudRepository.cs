namespace CustomerRegistration.Core.IRepository;

public interface ICrudRepository<T> where T : class
{
    IEnumerable<T> GetAll();
    void Update(T entity);
    void Add(T entity);
}
