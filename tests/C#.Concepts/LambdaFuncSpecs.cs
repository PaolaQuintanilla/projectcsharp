namespace C_.Concepts;

//CONCEPTS:
//Are anonimous functions that can be assigned to a delegate
//We can pass a lambda as an argument to a function that receive a delegate as an argument
//A lambda function can be use with Func, Action and predicate
//There are lambda expresions and lambda statements
public class LambdaFuncSpecs
{
    public delegate int SumActionDelegate(int numbOne, int numbTwo);
    public delegate bool IsPredicateParNumber(int numbOne);

    [Fact]
    public void Members()
    {
        //lambda expression can be assign to a delegate
        SumActionDelegate myDeleg = (num, num2) => num*num2;
        Assert.Equal(2, myDeleg(1,2));

        //lambda statement
        SumActionDelegate myDeleg2 = (num, num2) =>
        {
            return num * num2;
        };
        Assert.Equal(2, myDeleg2(1, 2));

        //multicast delegate
        Func<int, int, int> myFuncDel = (num, num2) => num * num2;
        myFuncDel += (num, num2) => num + num2;

        int[] expectedResults = { 15, 8 };
        int index = 0;
        foreach (Func<int, int, int> func in myFuncDel.GetInvocationList())
        {
            Assert.Equal(expectedResults[index], func(3, 5));
            index++;
        }

        int resultMulti = myFuncDel.Invoke(3, 5);
        Assert.Equal(8, resultMulti);//devuelve el valor de la ultima funcion
        
        //pass a lambda expression as an argument
        var resultFunc = ExecuteSum((num1, num2) => num1 * num2, 1, 2);
        Assert.Equal(2, resultFunc);
    }

    [Fact]
    public void Predicate_Member()
    {
        IsPredicateParNumber isPar = (num) => {
            if (num % 2 == 0)
            {
                return true;
            }

            return false;
        };
        Assert.True(isPar(2));
    }

    private int ExecuteSum(Func<int, int, int> myFunc, int num1, int num2)
    {
        return myFunc(num1, num2);
    }
}
