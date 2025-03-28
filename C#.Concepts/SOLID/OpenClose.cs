namespace C_.Concepts.SOLID;

//OPEN CLOSED
// Add new functionality without modify existing implementations
// We use polimorphisim to respect OCP
public class OpenClose
{
    [Fact]
    public void OpenCloseTest()
    {
        //arrange
        var areaCalculator= new AreaCalculator();
        IShape rectangle = new Rectangle
        {
            Heigth = 2,
            Width = 3,
        };

        IShape circle = new Circle
        {
            Radius = 3,
        };

        //execute
        int rectangelArea = areaCalculator.Calculate(rectangle);
        int circleArea = areaCalculator.Calculate(circle);
        
        //assert
        Assert.Equal(6, rectangelArea);
        Assert.Equal(28, circleArea);
    }
}

public class AreaCalculator
{
    //can work with any kind of shapes !!
    //we do not need else if here to calculate different shapes !!
    public int Calculate(IShape shape)
    {
        return shape.GetArea();
    }
}

public interface IShape
{
    int GetArea();
}

public interface IRectangle : IShape
{
    public int Width { get; set; }
    public int Heigth { get; set; }
}

public interface ICircle : IShape
{
    public int Radius { get; set; }
}

public class Rectangle : IRectangle
{
    public int Width { get; set; }
    public int Heigth { get; set; }

    public int GetArea()
    {
        return Width * Heigth;
    }
}

public class Circle : ICircle
{
    public int Radius { get; set; }

    public int GetArea()
    {
        return (int)(Math.PI * Radius * Radius);
    }
}
