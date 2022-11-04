using System.Net.Mail;
using System.Net;


namespace PortalNews.Util.SecureIdentity
{
    public static class EmailConfigure
    {
        private const string HOST = "smtp.zoho.com";
        private const int PORT = 587;
        private const string USER_NAME = "rafael.amaral@hvex.com.br";
        private const string PASSWORD = "Nauru@fiji12345";
        private const string FROM_NAME = "Rafael";
        private const string FROM_EMAIL = "rafael.amaral@hvex.com.br";

        public static SmtpClient SmtpClientConfigure()
        {
            var smtpClient = new SmtpClient(HOST, PORT);

            smtpClient.UseDefaultCredentials = false;
            smtpClient.Credentials = new NetworkCredential(USER_NAME, PASSWORD);
            smtpClient.DeliveryMethod = SmtpDeliveryMethod.Network;
            smtpClient.EnableSsl = true;


            return smtpClient;

        }

        public static MailMessage MailMessageConfigure(
                    string toName,
                    string toEmail,
                    string subject,
                    string body,
                    string fromName = FROM_NAME,
                    string fromEmail = FROM_EMAIL
            )
        {
            var mail = new MailMessage();

            mail.From = new MailAddress(fromEmail, fromName);
            mail.To.Add(new MailAddress(toEmail, toName));
            mail.Subject = subject;
            mail.Body = body;
            mail.IsBodyHtml = true;

            return mail;
        }

    }
}
