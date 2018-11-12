using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Net;
using System.Net.Mail;
namespace ScrumApplication.Services
{
    // This class is used by the application to send email for account confirmation and password reset.
    // For more details see https://go.microsoft.com/fwlink/?LinkID=532713
    public class EmailSender : IEmailSender
    {
        public Task SendEmailAsync(string email, string subject, string message)
        {
            //
            try
            {
                //To Address    
                string ToAddress = email;
                string ToAdressTitle = "Gửi thư điện tử";
                //Smtp Server    
                string SmtpServer = "smtp.gmail.com";
                //Smtp Port Number    
                int SmtpPortNumber = 587;
                //
                MailAddress from = new MailAddress("tradaviahe1982@gmail.com", "Nguyễn Việt Anh");
                MailAddress to = new MailAddress(ToAddress, ToAdressTitle);
                MailMessage Message = new MailMessage(from, to);
                // message.Subject = "Using the SmtpClient class.";
                Message.Subject = subject;
                Message.Body = message;
                //
                using (var smtp = new SmtpClient())
                {
                    //
                    smtp.Host = SmtpServer;
                    smtp.Port = SmtpPortNumber;
                    smtp.EnableSsl = true;
                    smtp.DeliveryMethod = SmtpDeliveryMethod.Network;
                    smtp.UseDefaultCredentials = false;
                    smtp.Credentials = new NetworkCredential("tradaviahe1982@gmail.com", "coninbeodangyeu0711");
                    smtp.Send(Message);
                    //
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }

            //
            return Task.CompletedTask;
        }
    }
}
