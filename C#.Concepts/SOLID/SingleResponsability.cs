namespace C_.Concepts.SOLID;

//SINGLE RESPONSABILITY
//A single reason to change
public class SingleResponsability
{
    [Fact]
    public void SingleRes()
    {
        var emailService = new EmailService();
        var fileService = new FileService();

        Assert.Equal("Email", emailService.SendEmail("Email"));
        Assert.Equal("File", fileService.SendFile("File"));
    }
}

public interface IService
{

}

public interface IEmailService
{
    public string SendEmail(string email);
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
}

public class FileService : IFileService
{
    public string SendFile(string file)
    {
        return file;
    }
}