public class FakeEmailService : IEmailService
{
    public void SendEmailNotification()
    {
        Console.WriteLine("Notificação de e-mail enviada para vendas@test.com");
        File.AppendAllText("email_log.txt", $"E-mail enviado as: {DateTime.Now}\n");
    }
}