namespace C_.Concepts;
//CONCEPTS:
//Generics help you write reusable and type-safe code
//Reusability – One Generic Class for Multiple Types
//Type Safety – Avoids Boxing/Unboxing and Runtime Errors
//Flexibility – Works with Different ID Types

//CONSTRAINTS
//new() T must have a parameterless constructor
//interface, class, struct, concreteBaseClass (so T must inherit from interface
//must be a reference type, a struct, or must inherit from a base class)
public class GenericsSpecs
{

    [Fact]
    public void Members()
    {
        var person = new Person
        {
            Id = 1,
            Name = "Oliver"
        };

        var concrete = new ConcreteClass();
        concrete.Insert(person);
        var found = concrete.Find(1);
        Assert.Equal(person.Id, found.Id);
        Assert.Equal(person.Name, found.Name);


        var factory = new Factory<Person>();
        Assert.IsType<Person>(factory.CreateInstance());

    }

}

public interface IGeneric<T, TId>
    where T : class
{
    T Find(TId id);
}

//THis generic abstract class can find any entity
//That checks the constraint
public abstract class AbstractGeneric<T, TId> : IGeneric<T, TId>
    where T : class, IEntity<TId>
{
    protected List<T> items = new();
    public T Find(TId id)
    {
        return items.FirstOrDefault((item) => item.Id.Equals(id));
    }

    public abstract void Insert(T generic);
}

//new() allow us to create new instances without knowing the specifics
//then person needs to have a parameterless constructor
public class Factory<T> where T : new()
{
    public T CreateInstance()
    {
        return new T();  // We can now create an instance of T since it has a parameterless constructor
    }
}

public class ConcreteClass : AbstractGeneric<Person, int>
{
    public override void Insert(Person person)
    {
        base.items.Add(person);
    }
}

public interface IEntity<TId>
{
    TId Id { get; set; }
}

public class Person : IEntity<int>
{
    //now we can instantiate a new() person
    public Person() {}
    public Person(int id, string name)
    {
        this.Id = id;
        this.Name = name;
    }
    public int Id{ get; set; }
    public string Name { get; set; }
}