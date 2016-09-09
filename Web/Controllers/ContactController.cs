using System.Net;
using System.Net.Mail;
using System.Web.Mvc;

namespace Web.Controllers {
	public class ContactController : Controller {
		[HttpPost]
		public bool Send(string name, string email, string message) {
			MailMessage mail = new MailMessage();
			SmtpClient smtp = new SmtpClient("smtp.live.com", 25);
			smtp.EnableSsl = true;
			smtp.UseDefaultCredentials = false;
			smtp.Credentials = new NetworkCredential("contact@cms-g.com", "P@$$w0rdH@ck", "");
			mail.From = new MailAddress(email, name);
			mail.To.Add("contact@cms-g.com");
			mail.Subject = "Contact Form Message";
			mail.Body = string.Format("From: {0} {1}\n\n{2}", name, email, message);
			smtp.Send(mail);
			return true;
		}
	}
}
