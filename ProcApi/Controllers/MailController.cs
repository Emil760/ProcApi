using Microsoft.AspNetCore.Mvc;
using System.Net;
using System.Net.Mail;

namespace ProcApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class MailController : BaseController
    {
        [HttpPost]
        public IActionResult SendEmail()
        {
            //Host: smtp - сервер, с которого производится отправление почты.Например, smtp.yandex.ru

            //Port: порт, используемый smp-сервером.Если не указан, то по умолчанию используется 25 порт.

            //Credentials: аутентификационные данные отправителя

            //EnableSsl: указывает, будет ли использоваться протокол SSL при отправке
            var smtp = new SmtpClient();


            //Attachments: содержит все прикрепления к письму

            //Body: непосредственно текст письма

            //From: адрес отправителя. Представляет объект MailAddress

            //To: адрес получателя. Также представляет объект MailAddress

            //Subject: определяет тему письма

            //IsBodyHtml: указывает, представляет ли письмо содержимое с кодом html

            var from = new MailAddress("emil.abbas.2408@gmail.com", "Emil From");

            var to = new MailAddress("Eldarabbasov@uygunlar.com", "Eldar");

            var mail = new MailMessage(from, to);
            mail.Subject = "Test subject";
            mail.Body = "<h6 style='color: red;'>Red Text Hello</h6>";
            mail.IsBodyHtml = true;
            mail.Priority = MailPriority.High;


            var atth = new Attachment("C:\\Users\\user\\Desktop\\6 Creepy Myths And Legends That Have Survived To This Day.jpg");
            mail.Attachments.Add(atth);

            smtp = new SmtpClient("smtp.gmail.com", 587);
            smtp.EnableSsl = true;
            smtp.Credentials = new NetworkCredential("emil.abbas.2408@gmail.com", "my_password");

            smtp.Send(mail);

            return Ok();
        }
    }
}
