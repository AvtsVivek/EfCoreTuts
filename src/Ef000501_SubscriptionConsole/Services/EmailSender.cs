namespace Ef000501_SubscriptionConsole.Services;

public interface IEmailSender
{
  Task SendEmailAsync(string subject);
}
public class EmailSender : IEmailSender
{
  public Task SendEmailAsync(string subject)
  {
    return Task.CompletedTask;
  }
}
