using System.Web.Mvc;
using DB.DAL;

namespace Web.Controllers {
	public class PageController : Controller {
		private readonly IPageRepository _PageRepository;
		private readonly ILanguageRepository _LanguageRepository;

		public PageController(IPageRepository pageRepository, ILanguageRepository langRepository) {
			_PageRepository = pageRepository;
			_LanguageRepository = langRepository;
		}

		public ActionResult Index(string pageName) {
			if(pageName == string.Empty || pageName == null)
				return RedirectToAction("Index", "Blog");
			return View(_PageRepository.Get(pageName.Replace("-", " "), _LanguageRepository.GetCurrentLanguage()));
		}
	}
}
