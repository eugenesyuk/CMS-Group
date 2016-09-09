using System;
using System.Globalization;
using System.Linq;
using System.Threading;
using System.Web;
using System.Web.Http;
using System.Web.Mvc;
using System.Web.Routing;
using System.Web.Security;
using DB.DAL;
using Ninject;

namespace Web {
	public class MvcApplication : HttpApplication {
		private ILanguageRepository _LanguageRepository;

		protected void Application_AcquireRequestState(object sender, EventArgs e) {
			if(HttpContext.Current.Session != null) {
				CultureInfo ci = (CultureInfo) Session["Culture"];
				if(ci == null) {
					string lang = "en";
					if(HttpContext.Current.Request.UserLanguages != null && HttpContext.Current.Request.UserLanguages.Length != 0)
						lang = HttpContext.Current.Request.UserLanguages[0].Substring(0, 2);
					if(lang.Equals("ru"))
						lang = "uk";
					else if(_LanguageRepository.GetAll().Count(x => x.Code.Equals(lang)) == 0)
						lang = "en";
					ci = new CultureInfo(lang);
					Session["Culture"] = ci;
				}
				Thread.CurrentThread.CurrentUICulture = ci;
				Thread.CurrentThread.CurrentCulture = CultureInfo.CreateSpecificCulture(ci.Name);
			}
		}

		public override void Init() {
			base.Init();
			// Dependency Injection
			IKernel diKernel = new StandardKernel();
			diKernel.Bind<IBlogRepository>().To<BlogRepository>();
			diKernel.Bind<IMenuRepository>().To<MenuRepository>();
			diKernel.Bind<ISliderRepository>().To<SliderRepository>();
			diKernel.Bind<IUserRepository>().To<UserRepository>();
			diKernel.Bind<ILanguageRepository>().To<LanguageRepository>();
			diKernel.Bind<IPageRepository>().To<PageRepository>();
			diKernel.Inject(Membership.Provider);
			DependencyResolver.SetResolver(new WebsiteDependencyResolver(diKernel));
			_LanguageRepository = (ILanguageRepository) DependencyResolver.Current.GetService(typeof(ILanguageRepository));
		}

		protected void Application_Start() {
			AreaRegistration.RegisterAllAreas();

			WebApiConfig.Register(GlobalConfiguration.Configuration);
			FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
			RouteConfig.RegisterRoutes(RouteTable.Routes);
		}
	}
}
