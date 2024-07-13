using MimeKit;
using Microsoft.Extensions.Options;
using EComServices.Repository.@interface;
using MailKit.Net.Smtp;
using MailKit.Security;

namespace EComServices.Repository.Implementation
{
    public class MailServices : IMailRequestService
    {
        private readonly MailSettings _mailsettings;
        public MailServices(IOptions<MailSettings> mailsettings)
        {
            _mailsettings = mailsettings.Value;
        }
        //public async Task SendEmail(MailRequest req)
        //{
        //    MimeMessage email = new MimeMessage();
        //    // MailboxAddress addredd = new MailboxAddress();
        //    email.Sender = MailboxAddress.Parse(_mailsettings.Mail);
        //   // MailRequest req = new MailRequest();
        //    email.To.Add(MailboxAddress.Parse(req.ToEmail));
        //    email.Subject = req.Subject;
        //    BodyBuilder build = new BodyBuilder();
        //    build.HtmlBody = req.Body;
        //    email.Body = build.ToMessageBody();
        //    SmtpClient smtp = new SmtpClient();
        //    smtp.Connect(_mailsettings.Host, _mailsettings.Port, SecureSocketOptions.StartTls);
        //    smtp.Authenticate(_mailsettings.Mail, _mailsettings.Password);
        //    await smtp.SendAsync(email);
        //    smtp.Disconnect(true);
        //}

        public async Task<MailRequest> SendEMails(MailRequest req)
        {
            MimeMessage email = new MimeMessage();
            // MailboxAddress addredd = new MailboxAddress();
            email.Sender = MailboxAddress.Parse(_mailsettings.Mail);
            // MailRequest req = new MailRequest();
            email.To.Add(MailboxAddress.Parse(req.ToEmail));
            email.Subject = req.Subject;
            BodyBuilder build = new BodyBuilder();
            build.HtmlBody = req.Body;
            email.Body = build.ToMessageBody();
            SmtpClient smtp = new SmtpClient();
            smtp.Connect(_mailsettings.Host, _mailsettings.Port, SecureSocketOptions.StartTls);
            //smtp.Authenticate(_mailsettings.Mail, _mailsettings.Password);
            await smtp.SendAsync(email);
            smtp.Disconnect(true);
            throw new NotImplementedException();
        }
    }
}
