using _101SendEmailNotificationDoNetCoreWebAPI.Model;

namespace UMS.Domain;

public interface IMailService
{
    Task SendEmailAsync(MailRequest mailRequest);

}