using PortalNews.Util.SecureIdentity;

namespace PortalNews.Api.Services
{
    public class EmailService
    {
        public void Send(string name , string email, string subject , string body)
        {
             var mail = EmailConfigure.MailMessageConfigure(name, email, subject, body);
             EmailConfigure.SmtpClientConfigure().Send(mail);
        }
    }
}
