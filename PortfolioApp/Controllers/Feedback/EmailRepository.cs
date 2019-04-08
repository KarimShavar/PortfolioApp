using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Threading.Tasks;
using PortfolioApp.Models;

namespace PortfolioApp.Controllers.Feedback
{
    public class EmailRepository : IFeedbackRepository
    {
        public void SendFeedback(Contact feedback)
        {
            using (var message = new MailMessage())
            {
                message.To.Add(new MailAddress("portfoliowebfeedback@gmail.com", "To Name"));
                message.From = new MailAddress($"{feedback.Email}", $"{feedback.Name}");
                message.Subject = $"WebsiteFeedback from {feedback.Name} {feedback.LastName}";
                message.Body = $"{feedback.Email}:\n{feedback.Message}";
                message.IsBodyHtml = true;

                using (var client = new SmtpClient("smtp.gmail.com"))
                {
                    client.Port = 587;
                    client.Credentials =
                        new NetworkCredential("portfoliowebfeedback@gmail.com", Storage.PassStorage.GmailPass);
                    client.EnableSsl = true;
                    client.Send(message);
                }
            }

        }
    }
}
