using Entity.Concrete;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Service.Abstract;
using System.Runtime.CompilerServices;
using System.Text;

namespace WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MailController : ControllerBase
    {
        private readonly IMailSenderService _mailSenderService;

        public MailController(IMailSenderService mailSenderService)
        {
            _mailSenderService = mailSenderService;
        }

        [HttpPost("sendMail")]
        public ActionResult Index(Contact model)
        {
            if (ModelState.IsValid)
            {
                var body = new StringBuilder();
                body.AppendLine("Gonderen: " + model.Name);
                body.AppendLine("E-Mail Adresi: " + model.Email);
                body.AppendLine("Konu: " + model.Subject);
                body.AppendLine("Mesaj: " + model.Message);
                _mailSenderService.SendMail(body.ToString());
            }
            return Ok("Mail Gönderme Başarılı");
        }
    }
}
