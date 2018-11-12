using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Encodings.Web;
using System.Threading.Tasks;
using ScrumApplication.Services;

namespace ScrumApplication.Extensions
{
    public static class EmailSenderExtensions
    {
        public static Task SendEmailConfirmationAsync(this IEmailSender emailSender, string email, string link)
        {
            //return emailSender.SendEmailAsync(email, "Xác nhận thư điện tử của bạn",
            //    $"Bạn click liên kết để xác nhận: <a href='{HtmlEncoder.Default.Encode(link)}'>link</a>");
            return emailSender.SendEmailAsync(email, "Xác nhận thư điện tử của bạn",
                $"Bạn click liên kết để xác nhận: <a href='{link}'>link</a>");
        }
    }
}
