using auctionWebApp.persistence.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace auctionWebApp.persistence;

public class GenericPersistence<T> : IGenericPersistence<T> where T : BaseDB
{
    public readonly AuctionDbContext _context;
    public DbSet<T> entity => _context.Set<T>();
    public GenericPersistence(AuctionDbContext context)
    {
        _context = context;
    }

    public void Add(T entity)
    {
        this.entity.Add(entity);
        _context.SaveChanges(); 
    }

    public void Delete(T entity)
    {
        this.entity.Remove(entity);
        _context.SaveChanges();
    }

    public List<T> GetAll()
    {
        return this.entity.ToList();   
    }

    public T GetById(int id)
    {
        var entity = _context.Find<T>(id);
        return entity;
    }

    public void Update(T entity)
    {
        _context.Update(entity);
        _context.SaveChanges(); 
    }
    
}