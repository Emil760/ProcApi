using System.Net;
using System.Net.Mail;
using Microsoft.AspNetCore.Mvc;

namespace ProcApi.Presentation.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class MailController : BaseController
    {
        [HttpPost]
        public IActionResult SendEmail()
        {
            // var smtp = new SmtpClient();
            //
            // var from = new MailAddress("emil.abbas.2408@gmail.com", "Emil From");
            //
            // var to = new MailAddress("Eldarabbasov@uygunlar.com", "Eldar");
            //
            // var mail = new MailMessage(from, to);
            // mail.Subject = "Test subject";
            // mail.Body = "<h6 style='color: red;'>Red Text Hello</h6>";
            // mail.IsBodyHtml = true;
            // mail.Priority = MailPriority.High;
            //
            //
            // var atth = new Attachment("C:\\Users\\user\\Desktop\\6 Creepy Myths And Legends That Have Survived To This Day.jpg");
            // mail.Attachments.Add(atth);
            //
            // smtp = new SmtpClient("smtp.gmail.com", 587);
            // smtp.EnableSsl = true;
            // smtp.Credentials = new NetworkCredential("emil.abbas.2408@gmail.com", "my_password");
            //
            // smtp.Send(mail);
            //
            return Ok();
        }
    }
}