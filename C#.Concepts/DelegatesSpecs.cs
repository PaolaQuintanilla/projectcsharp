namespace C_.Concepts;

//Delegate concepts
//a. Delegates are a data type and pointers to function
//b. We can declare a delegate and assign a function to the delegate
//with the same signature.
//c. We have some built-int delegates like Func, Action and Predicate
//d. Func return a value, action is void and predicate return a boolean
//e. We can use multicast delegates assigning many function reference to a delegate
//the last function result is return in case of a Func<T> delegate
//f. We can use on events and callbacks
public class DelegatesSpecs
{
    //declare a delegate
    public delegate int SumDelegate(int numbOne, int numbTwo);
    
    [Fact]
    public void Members()
    {
        //El compilador de C# infiera automáticamente que SumValues
        //coincide con la firma del delegado y genera una instancia por ti.
        SumDelegate newDel2 = SumValues;
        Assert.Equal(3, newDel2(1, 2));//executo el delegado

        //puedo pasar el delegado como argumento a una funcion
        int delResult = ExecuteSum(newDel2, 4, 5);
        Assert.Equal(9, delResult);

        //multicast delegate
        //si el delegado devuelve un valor
        //solo se devolvera el ultimo
        SumDelegate newDel3 = SumValues;
        newDel3 += SumValues;

        //Built-int delegates
        Func<int, int, int> funcDel = SumValues;
        Assert.Equal(3, funcDel(1, 2));
        Action<int, int> actionDel = logValues;
        Predicate<int> myPred = num => num % 2 == 0;
        Assert.True(myPred(2));
    }

    // Método que recibe un delegado como parámetro
    public int ExecuteSum(SumDelegate sumDelegate, int a, int b)
    {
        return sumDelegate.Invoke(a, b);
    }

    public int SumValues(int val1, int val2)
    {
        return val1 + val2;
    }

    public void logValues(int val1, int val2)
    {
    }
}
