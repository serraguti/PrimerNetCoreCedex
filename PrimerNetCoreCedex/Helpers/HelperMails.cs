using System.Net;
using System.Net.Mail;

namespace PrimerNetCoreCedex.Helpers
{
    public class HelperMails
    {
        private IConfiguration configuration;

        public HelperMails(IConfiguration configuration)
        {
            this.configuration = configuration;
        }

        public async Task SendMailAsync(string para, string asunto, string cuerpo)
        {
            MailMessage message = new MailMessage();
            //NECESITAMOS INDICAR EL CORREO DESDE DONDE LO ENVIAMOS
            //QUE TIENE QUE SER EL MISMO DE LA CUENTA DE CREDENCIALES
            string userEmail = this.configuration.GetValue<string>("MailSettings:UserMail");
            string password = this.configuration.GetValue<string>("MailSettings:Password");
            string smtpServer = this.configuration.GetValue<string>("MailSettings:Smtp");
            message.From = new MailAddress(userEmail);
            message.To.Add(new MailAddress(para));
            message.Subject = asunto;
            message.Body = cuerpo;
            message.IsBodyHtml = true;
            //CONFIGURAMOS SMTPCLIENT
            SmtpClient smtp = new SmtpClient();
            smtp.Host = smtpServer;
            smtp.Port = 587;
            smtp.EnableSsl = true;
            smtp.UseDefaultCredentials = true;
            NetworkCredential credentials =
                new NetworkCredential(userEmail, password);
            await smtp.SendMailAsync(message);
        }
    }
}
