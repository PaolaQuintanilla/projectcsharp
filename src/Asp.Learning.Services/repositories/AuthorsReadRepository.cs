using Asp.Learning.Contracts.Services;
using Asp.Learning.Services.domain;
using Asp.Learning.Services.repositories.context;
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

    public async Task<Author> FindAsync(Guid id)
    {
        var entity = await _dbSet.Include((a) => a.Courses).FirstOrDefaultAsync(a => a.Id == id);

        if (entity is null)
        {
            throw new KeyNotFoundException($"No se encontró el autor con ID {id}");
        }

        return entity;
    }

    //await: espera la resolucion, y hace el thread se libera
    //async: convierte el metodo en una maquina de estados
    //task: contiene informacion del stado del lonng running task
    public async Task<IReadOnlyList<Author>> FindAsync()
    {
        return await this._dbSet.Include((a) => a.Courses).ToListAsync();
    }

    public async Task<IReadOnlyList<Author>> FindAsync(string? mainCategory)
    {
        if(string.IsNullOrWhiteSpace(mainCategory))
        {
            return await FindAsync();
        }

        mainCategory = mainCategory.Trim();

        return await this._dbSet.Where((a) => a.MainCategory == mainCategory).ToListAsync();
    }
}
