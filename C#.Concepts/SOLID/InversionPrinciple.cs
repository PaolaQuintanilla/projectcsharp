namespace C_.Concepts.SOLID;

//inversion principle
//module: a logical unit of functionality
//module: logical groupings of related classes
//ServiceSquare is part of a business logic unit
//High-level modules should depend on abstractions instead concrete implementation
public class InversionPrinciple
{
    [Fact]
    public void InversionPrinc()
    {
        var repo = new MongoDb();
        var service = new ServiceSquare(repo);
        var newSquare = service.AddSquare(new Square
        {
            Width = 4
        });

        Assert.Equal(5, newSquare.Id);
        Assert.Equal(4, newSquare.Width);

        var sqlRepo = new SqlDb();
        var service2 = new ServiceSquare(sqlRepo);
        var newSquare2 = service2.AddSquare(new Square
        {
            Width = 4
        });

        Assert.Equal(6, newSquare2.Id);
        Assert.Equal(4, newSquare2.Width);

    }
}

public interface IRepository
{
    Square Add(Square square);
}

public class ServiceSquare
{
    private IRepository _repository;
    public ServiceSquare(IRepository repository)
    {
        _repository = repository;
    }

    public Square AddSquare(Square square)
    {
        return this._repository.Add(square);
    }
}

public class MongoDb : IRepository
{
    public Square Add(Square square)
    {
        square.Id = 5;
        return square;
    }
}

public class SqlDb : IRepository
{
    public Square Add(Square square)
    {
        square.Id = 6;
        return square;
    }
}

public class Square
{
    public int Id { get; set; }
    public int Width { get; set; }
}
