namespace C_.Concepts.DesignPatterns;
// Problem that solves: Reduces direct communication between objects, centralizing it through a mediator
// How it’s implemented: The mediator handles the communication between objects, preventing them from referencing each other directly

public class MediatorPattern
{
    [Fact]
    public void Mediator_Spec()
    {
    }
}

public class Sender
{
    private readonly Mediator mediator;

    public Sender(Mediator mediator)
    {
        this.mediator = mediator;
    }

    public void Send(string message)
    {
        this.mediator.SendMessage(message);
    }
}

public class Mediator
{
    private readonly Receiver receiver;

    public Mediator(Receiver receiver)
    {
        this.receiver = receiver;
    }
    internal void SendMessage(string message)
    {
        this.receiver.ReceiveMessage(message);
    }
}

public class Receiver
{
    internal void ReceiveMessage(string message)
    {
        Console.WriteLine("Message received");
    }
}