namespace C_.Concepts.SOLID;

// LISKOV SUBSTITUTION
// Subtypes must not break expected behavior
// We achieve this by respecting the base contract
// Any client that uses the base type should be able to rely on the behaviors
// promised by the base type without knowing which subtype it is.
public class LiskovVIP
{
    [Fact]
    public void LiskovViolation()
    {
        // Client expects that any ICustomer can provide lounge access
        ICustomer regularCustomer = new RegularCustomer();
        ICustomer vipCustomer = new VIPCustomer();

        // Regular customer cannot provide lounge access
        Assert.Throws<NotSupportedException>(() => regularCustomer.AccessLounge());

        // VIP customer can access lounge
        Assert.Equal("Welcome to the VIP lounge!", vipCustomer.AccessLounge());

        // From client perspective: they expected any ICustomer could use lounge
        // Substituting RegularCustomer breaks that expectation → LSP violation
        bool canAccess = regularCustomer.AccessLounge() == "Welcome to the VIP lounge!";
        Assert.False(canAccess); // Demonstrates LSP violation clearly
    }
}

// Base contract
public interface ICustomer
{
    string AccessLounge();
}

// Subtypes
public class RegularCustomer : ICustomer
{
    public string AccessLounge()
    {
        // Regular customers are not allowed in the VIP lounge
        //this breaks liskov substitution
        throw new NotSupportedException("Regular customers cannot access VIP lounge!");
    }
}

public class VIPCustomer : ICustomer
{
    public string AccessLounge()
    {
        return "Welcome to the VIP lounge!";
    }
}
