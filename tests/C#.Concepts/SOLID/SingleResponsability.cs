namespace C_.Concepts.SOLID;

// SINGLE RESPONSIBILITY
// A class should have one reason to change
// We respect SRP by keeping one responsibility per class
public class SingleResponsability
{
    [Fact]
    public void SingleRes()
    {
        IEmailService emailService = new EmailService();
        IFileService fileService = new FileService();

        Assert.Equal("Email", emailService.SendEmail("Email"));
        Assert.True(emailService.IsValidEmail("Email@hotmail.com"));
        Assert.Equal("File", fileService.SendFile("File"));
    }
}

public interface IService
{

}

public interface IEmailService
{
    //tiene dos metodos pero la razon para cambiar es la misma, manejar emails
    public string SendEmail(string email);
    public bool IsValidEmail(string email);
}

public interface IFileService : IService
{
    public string SendFile(string file);
}

public class EmailService : IEmailService
{
    public string SendEmail(string email)
    {
        return email;
    }

    public bool IsValidEmail(string email)
    {
        return email.Contains("@");
    }
}

public class FileService : IFileService
{
    public string SendFile(string file)
    {
        return file;
    }
}