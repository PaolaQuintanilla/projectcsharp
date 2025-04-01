namespace C_.Concepts;

//las interfaces son invariants por defecto
//covarianza permite que los tipos derivados puedan ser tratados
//como tipos base cuando se trabaja en las salidas de un tipo geerico.
public class CovarianzaSpec
{
    [Fact]
    public void Covar_spect()
    {

        //La covarianza en C# se refiere principalmente a tipos de salida
        IAnimalRepository<ICan> dogRepo = new PastorAlemanRepo();
        CanService service = new CanService(dogRepo);
        IEnumerable<ICan> result1 = service.FindCannes();
    }
}

public class CanService
{
    private readonly IAnimalRepository<ICan> repository;

    public CanService(IAnimalRepository<ICan> repository)
    {
        this.repository = repository;
    }
    public IEnumerable<ICan> FindCannes()
    {
        //repo retorna dogs pero aca retornamos ICan
        return this.repository.Find();
    }
}

//We are making this interface covariant with out keyword
public interface IAnimalRepository<out TEntity>
    where TEntity : ICan
{
    IEnumerable<TEntity> Find();
}
public class PastorAlemanRepo : IAnimalRepository<PastorAleman>
{
    public IEnumerable<PastorAleman> Find()
    {
        return new List<PastorAleman>
        {
            new PastorAleman
            {
                Name = "Firulais"
            },
            new PastorAleman
            {
                Name = "Borolas"
            },
        };
    }
}

public interface ICan { }
public class PastorAleman : ICan
{
    public string Name { get; set; }
}