using Asp.Learning.Contracts.Services;
using Asp.Learning.repositories.Entities;
using Microsoft.EntityFrameworkCore;

namespace Asp.Learning.repositories;
public class AuthorsWriteRepository : IWriteRepository<Author>
{
    private readonly LearningDbContext context;
    private readonly DbSet<Author> _dbSet;


    public AuthorsWriteRepository(LearningDbContext context)
    {
        this.context = context;
        _dbSet = context.Set<Author>();
    }

    public async Task<Guid> AddAsync(Author entity)
    {
        var result = this._dbSet.Add(entity);

        if (result.State != EntityState.Added)
        {
            throw new InvalidOperationException();
        }

        //ejecucion a la base de datos
        var isSaved = await this.context.SaveChangesAsync();

        if (isSaved == 0)
        {
            throw new InvalidOperationException();
        }

        return entity.Id;
    }

    public Task<int> SaveChangesASync()
    {
        return this.context.SaveChangesAsync();
    }

    public async Task<Author> FindAsync(Guid id)
    {
        var entity = await _dbSet.Include((a) => a.Courses).FirstOrDefaultAsync(a => a.Id == id);

        if (entity is null)
        {
            throw new NullReferenceException();
        }

        return entity;
    }
}
