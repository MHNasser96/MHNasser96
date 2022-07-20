using _101SendEmailNotificationDoNetCoreWebAPI.Model;
using MailKit;
using MailKit.Net.Smtp;
using MailKit.Security;
using Microsoft.Extensions.Options;
using MimeKit;
using UMS.Domain.Settings;
using IMailService = UMS.Infrastructure.Abstraction.Services.IMailService;

namespace UMS.Infrastructure.Services;

public class MailService : IMailService
{
    private readonly MailSettings _mailSettings;
    public MailService(IOptions<MailSettings> mailSettings)
    {
        _mailSettings = mailSettings.Value;
    }

    public async Task SendEmailAsync(MailRequest mailRequest)
    {
        var email = new MimeMessage();
        email.Sender = MailboxAddress.Parse("danson67yerri@outlook.com");
        email.To.Add(MailboxAddress.Parse(mailRequest.ToEmail));
        email.Subject = mailRequest.Subject;
        var builder = new BodyBuilder();
        builder.HtmlBody = mailRequest.Body;
        email.Body = builder.ToMessageBody();
        using var smtp = new SmtpClient();
        smtp.Connect("smtp.office365.com", 587, SecureSocketOptions.StartTls);
        smtp.Authenticate("danson67yerri@outlook.com", "Danson@67");
        await smtp.SendAsync(email);
        smtp.Disconnect(true);
    }
}