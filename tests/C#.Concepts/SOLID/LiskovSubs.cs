namespace C_.Concepts.SOLID;

//liskov
//You should be able to use an instance of a sub class where a base class is expected
//A mercedes is a vehicle but is not substitutable by a lexus
public class LiskovSubs
{
    [Fact]
    public void Liskov()
    {
        Lexus lex = new Mercedes();
        Assert.NotEqual("black", lex.Color());//lex should be black
    }
}
public abstract class Vehicle
{
    public abstract string Color();
}
public class Lexus : Vehicle
{
    public override string Color() => "black";
}

public class Mercedes : Lexus
{
    public override string Color() => "white";
}