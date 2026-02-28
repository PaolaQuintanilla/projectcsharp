namespace C_.Concepts.SOLID;

//INTERFACE SEGREGATION
// clients shouldn’t be forced to depend on methods they do not use.
// we respect ISP by keeping  small and focused interfaces,
    // so clients only depend on what they actually need.
public class InterfaceSegregation
{
    [Fact]
    public void Segregation()
    {
        ISmtpService service = new SmtpService();
        ITextMessageService textMessageService = new TextMessageService();

        Assert.Equal("Text", textMessageService.SendText());
        Assert.Equal("Email", service.SendEmail());
    }
}

public interface ISmtpService
{
    string SendEmail();
}

public class SmtpService : ISmtpService
{
    public string SendEmail()
    {
        return "Email";
    }
}

public interface ITextMessageService
{
    string SendText();
}
// A separate class that actually supports text messages
public class TextMessageService : ITextMessageService
{
    public string SendText()
    {
        return "Text";
    }
}