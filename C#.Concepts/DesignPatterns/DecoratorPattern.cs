namespace C_.Concepts.DesignPatterns;

//Problem that solves: Allow us to extend behaviour witouth changing code
//Como se implementa: Se implementa envolviendo objetos con decoradores que agregan funcionalidad
public class DecoratorPattern
{
    [Fact]
    public void decorator_spec()
    {
        IMailService mailService = new MailService();
        IMailService service = new DecoratorMailService(mailService);
        service.SendMail();
    }
}

public interface IMailService
{
    void SendMail();
}

public class MailService : IMailService
{
    public void SendMail()
    {
        throw new NotImplementedException();
    }
}


public class DecoratorMailService : IMailService
{
    private readonly IMailService mailService;

    public DecoratorMailService(IMailService mailService)
    {
        this.mailService = mailService;
    }
    public void SendMail()
    {
        Console.WriteLine("doing some decoration");
        this.mailService.SendMail();
    }
}
