using System.Collections.Generic;
using System.Threading.Tasks;
using EpillBox.API.Data;
using EpillBox.API.Models;
using Microsoft.EntityFrameworkCore;
using System.Net;
using System.Net.Mail;
using EpillBox.API.Dtos;

namespace EpillBox.API.Services
{
    public class EmailService
    {
        private const string FromHost = "poczta.interia.pl";
        private const int FromPort = 587;
        private const string FromEmailAddress = "testtt@interia.eu";
        private const string FromDisplayName = "EpillBox";

        private const string FromPassword = "Tacc!!11";
        private const string FromSubject = "EpillBox Lista zakupów";

        private const string EmailBodyTemplate = "Lista leków do kupienia : \n{0}";

        public void SendEmail(User user,IEnumerable<string> medicines)
        {
            var fromAddress = new MailAddress(FromEmailAddress, FromDisplayName);
            var toAddress = new MailAddress(user.Email, user.Name+' '+user.Surname);

            var smtp = new SmtpClient
            {
                Host = FromHost,
                Port = FromPort,
                EnableSsl = true,
                DeliveryMethod = SmtpDeliveryMethod.Network,
                UseDefaultCredentials = false,
                Credentials = new NetworkCredential(fromAddress.Address, FromPassword),
            };
            using (var message = new MailMessage(fromAddress, toAddress)
            {
                Subject = FromSubject,
                Body = string.Format(EmailBodyTemplate, string.Join('\n',medicines))
            })
            {
                smtp.EnableSsl = true;
                smtp.Send(message);
            }


        }
    }
}