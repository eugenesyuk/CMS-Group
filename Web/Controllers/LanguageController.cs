using System.Globalization;
using System.Threading;
using System.Web;
using System.Web.Mvc;
using DB.DAL;

namespace Web.Controllers {
	public class LanguageController : Controller {
		private readonly ILanguageRepository _LanguageRepository;

		public LanguageController(ILanguageRepository langRepository) {
			_LanguageRepository = langRepository;
		}

		public ActionResult Change(string code) {
			if(HttpContext.Session != null) {
				var lang = _LanguageRepository.Get(code);
				if(lang == null)
					lang = _LanguageRepository.Get("en");
				CultureInfo ci = new CultureInfo(lang.Code);
				Session["Culture"] = ci;
				Thread.CurrentThread.CurrentUICulture = ci;
				Thread.CurrentThread.CurrentCulture = CultureInfo.CreateSpecificCulture(ci.Name);
			}
			return RedirectToAction("Index", "Blog");
		}

		public PartialViewResult RederLanguageBar() {
			return PartialView(_LanguageRepository.GetAll());
		}
	}
}
