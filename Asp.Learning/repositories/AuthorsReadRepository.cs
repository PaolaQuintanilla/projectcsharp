using Asp.Learning.Contracts;
using Asp.Learning.Helpers;
using Asp.Learning.repositories.Entities;
using Asp.Learning.ResourceParameters;
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

    public async Task<PagedList<Author>> FindAsync(AuthorResourceParameters authorResourceParameters)
    {
        //if(authorResourceParameters == null)
        //{
        //    return await FindAsync();
        //}

        var collection = this._dbSet.AsQueryable();

        if(!string.IsNullOrWhiteSpace(authorResourceParameters.MainCategory))
        {
            var mainCategory = authorResourceParameters.MainCategory.Trim();
            collection = collection.Where((a) => a.MainCategory == mainCategory);
        }

        if (!string.IsNullOrWhiteSpace(authorResourceParameters.SearchQuery))
        {
            var searchQuery = authorResourceParameters.SearchQuery.Trim();
            collection = collection.Where((a) => a.MainCategory.Contains(searchQuery) 
                || a.FirstName.Contains(searchQuery)
                || a.LastName.Contains(searchQuery));
        }

        return await PagedList<Author>.CreateAsync(collection, 
            authorResourceParameters.PageNumber, 
            authorResourceParameters.PageSize);
    }
}
