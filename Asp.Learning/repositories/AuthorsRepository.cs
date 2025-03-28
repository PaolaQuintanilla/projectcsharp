using Asp.Learning.Contracts;
using Asp.Learning.repositories.Entities;
using Microsoft.EntityFrameworkCore;

namespace Asp.Learning.repositories;
public class AuthorsRepository : IRepository<Author>
{
    private readonly LearningDbContext context;
    private readonly DbSet<Author> _dbSet;


    public AuthorsRepository(LearningDbContext context)
    {
        this.context = context;
        _dbSet = context.Set<Author>();
    }

    public Guid Add(Author entity)
    {
        var result = this._dbSet.Add(entity);

        if (result.State != EntityState.Added)
        {
            throw new InvalidOperationException();
        }
        var isSaved = this.context.SaveChanges();

        if (isSaved == 0)
        {
            throw new InvalidOperationException();
        }

        return entity.Id;
    }

    public void Delete(Author entity)
    {
        var result = this._dbSet
            .Remove(entity);

        if (result.State != EntityState.Deleted)
        {
            throw new InvalidOperationException();
        }
    }

    public void Update(Author entity)
    {
        throw new NotImplementedException();
    }

    public int SaveChangesASync()
    {
        return this.context.SaveChanges();
    }

    public Author Find(Guid id)
    {
        var entity = _dbSet.Find(id);

        if (entity is null)
        {
            throw new NullReferenceException();
        }

        return entity;
    }

    public IReadOnlyList<Author> Find()
    {
        return this._dbSet.ToList();
    }
}
