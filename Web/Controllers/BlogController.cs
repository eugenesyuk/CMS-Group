using System.Web.Mvc;
using DB.DAL;

namespace Web.Controllers {
	public class BlogController : Controller {
		private readonly IBlogRepository _BlogRepository;
		private readonly ILanguageRepository _LanguageRepository;

		public BlogController(IBlogRepository blogRepository, ILanguageRepository langRepository) {
			_BlogRepository = blogRepository;
			_LanguageRepository = langRepository;
		}

		public ActionResult Index(int page = 0) {
			return View(_BlogRepository.GetPostsByPage(5, page, _LanguageRepository.GetCurrentLanguage()));
		}

		public ActionResult GetPost(string url) {
			return View(_BlogRepository.GetPostByUrl(url, _LanguageRepository.GetCurrentLanguage()));
		}
	}
}
