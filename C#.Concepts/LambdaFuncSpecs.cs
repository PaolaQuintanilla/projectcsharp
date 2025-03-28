namespace C_.Concepts;

//CONCEPTS:
//Are anonimous functions that can be assigned to a delegate
//We can pass a lambda as an argument to a function that receive a delegate as an argument
//A lambda function can be use with Func, Action and predicate
//There are lambda expresions and lambda statements
public class LambdaFuncSpecs
{
    public delegate int SumDelegate(int numbOne, int numbTwo);

    [Fact]
    public void Members()
    {
        //lambda expression can be assign to a delegate
        SumDelegate myDeleg = (num, num2) => num*num2;
        Assert.Equal(2, myDeleg(1,2));

        //lambda statement
        SumDelegate myDeleg2 = (num, num2) =>
        {
            return num * num2;
        };
        Assert.Equal(2, myDeleg2(1, 2));

        //multicast delegate
        Func<int, int, int> myFuncDel = (num, num2) => num * num2;
        myFuncDel += (num, num2) => num + num2;

        myFuncDel.Invoke(3, 5);

        //pass a lambda expression as an argument
        var resultFunc = ExecuteSum((num1, num2) => num1 * num2, 1, 2);
        Assert.Equal(2, resultFunc);
    }

    public int ExecuteSum(Func<int, int, int> myFunc, int num1, int num2)
    {
        return myFunc(num1, num2);
    }
}
