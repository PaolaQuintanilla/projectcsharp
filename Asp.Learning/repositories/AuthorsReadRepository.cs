using Asp.Learning.Contracts;
using Asp.Learning.repositories.Entities;
using Microsoft.EntityFrameworkCore;

namespace Asp.Learning.repositories;
public class AuthorsReadRepository : IReadRepository<Author>
{
    private readonly LearningDbContext context;
    private readonly DbSet<Author> _dbSet;


    public AuthorsReadRepository(LearningDbContext context)
    {
        this.context = context;
        _dbSet = context.Set<Author>();
    }

    public int SaveChangesASync()
    {
        return this.context.SaveChanges();
    }

    public Author Find(Guid id)
    {
        var entity = _dbSet.Include((a) => a.Courses).FirstOrDefault(a => a.Id == id);

        if (entity is null)
        {
            throw new NullReferenceException();
        }

        return entity;
    }

    public IReadOnlyList<Author> Find()
    {
        return this._dbSet.Include((a) => a.Courses).ToList();
    }
}
