using CustomerRegistration.Adapter.Context;
using CustomerRegistration.Core.IRepository;
using Microsoft.EntityFrameworkCore;

namespace CustomerRegistration.Adapter.Repository;

public class CrudRepository<T> : ICrudRepository<T> where T : class
{
    private readonly CustomerRegistrationDbContext _dbContext;
    public DbSet<T> Entities { get; init; }
    public CrudRepository(CustomerRegistrationDbContext dbContext)
    {
        Entities = dbContext.Set<T>();
        _dbContext = dbContext;
    }

    public void Add(T entity)
    {
        Entities.Add(entity);
        _dbContext.SaveChanges();
    }

    public IEnumerable<T> GetAll()
    {
        var entities = Entities.ToList();
        return entities;
    }

    public void Update(T entity)
    {
        Entities.Update(entity);
        _dbContext.SaveChanges();
    }

    public T GetById(int id)
    {
        var entity = Entities.Find(id);
        return entity;
    }
}
