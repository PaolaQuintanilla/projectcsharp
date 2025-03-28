namespace C_.Concepts;

//las interfaces son invariants por defecto
//contravarianza permite que los tipos base puedan ser tratados
//como tipos derivados cuando se trabaja en las entradas de un tipo genérico.
public class ContravarianzaSpec
{
    [Fact]
    public void Contravar_spect() 
    {
        Angora cat = new Angora()
        {
            Name = "Gary"
        };

        //La contracovarianza en C# se refiere principalmente a tipos de entrada
        var felinoRepo = new FelinoRepo();
        var felinoService = new AngoraService(felinoRepo);

        felinoService.Add(cat);
    }
}

public class AngoraService
{
    private readonly IFelinoRepository<Angora> felinoRepository;

    public AngoraService(IFelinoRepository<Angora> felinoRepository)
    {
        this.felinoRepository = felinoRepository;
    }

    public void Add(Angora entity)
    {
        //type ICat Cat
        this.felinoRepository.Add(entity);
    }
}

//We are making this interface contravariant with the in keyword
public interface IFelinoRepository<in TEntity>
    where TEntity : IFelino
{
    void Add(TEntity entity);
}
public class FelinoRepo : IFelinoRepository<IFelino>
{
    private List<IFelino> felinos = new List<IFelino>();
    public void Add(IFelino entity)
    {
        this.felinos.Add(entity);
    }
}

public interface IFelino { }
public class Angora : IFelino
{
    public string Name { get; set; }
}