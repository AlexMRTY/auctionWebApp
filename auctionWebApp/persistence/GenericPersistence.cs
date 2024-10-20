using System.Linq.Expressions;
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
    
    public void DeleteAll(List<T> entities)
    {
        this.entity.RemoveRange(entities);
        _context.SaveChanges();
    }

    public List<T> GetAll(Expression<Func<T, bool>>? filter = null,
        Func<IQueryable<T>, IOrderedQueryable<T>>? orderBy = null)
    {
        IQueryable<T> query = entity;
        
        // Apply filtering if a filter is provided
        if (filter != null)
        {
            query = query.Where(filter);
        }
        
        // Apply ordering if an orderBy expression is provided
        if (orderBy != null)
        {
            query = orderBy(query);
        }
        
        return query.ToList();
    }

    public T GetById(int id, Expression<Func<T, object>>? include = null)
    {
        IQueryable<T> query = entity;
        
        // Dynamically apply the Include expression
        if (include != null)
        {
            query = query.Include(include);
        }
        
        var result  = query.FirstOrDefault(e => EF.Property<int>(e, "Id") == id);
        
        // If bids are included, sort them by price in descending order
        if (result  is AuctionItemDb auction && auction.Bids != null)
        {
            auction.Bids = auction.Bids.OrderByDescending(b => b.Amount).ToList();
        }

        return result ;
    }

    public void Update(T entity)
    {
        _context.Update(entity);
        _context.SaveChanges(); 
    }
    
}