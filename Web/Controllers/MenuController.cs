using System.Web.Mvc;
using DB.DAL;

namespace Web.Controllers {
	public class MenuController : Controller {
		private readonly IMenuRepository _MenuRepository;
		private readonly ILanguageRepository _LanguageRepository;

		public MenuController(IMenuRepository menuRepository, ILanguageRepository langRepository) {
			_MenuRepository = menuRepository;
			_LanguageRepository = langRepository;
		}

		public PartialViewResult RenderMenuBar() {
			return PartialView(_MenuRepository.GetAll(_LanguageRepository.GetCurrentLanguage()));
		}
	}
}
