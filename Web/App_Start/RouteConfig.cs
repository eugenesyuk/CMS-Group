using System.Web.Mvc;
using System.Web.Routing;

namespace Web {
	public class RouteConfig {
		public static void RegisterRoutes(RouteCollection routes) {
			routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

			routes.MapRoute(
				name: "Pages",
				url: "Page/{pageName}",
				defaults: new {
					controller = "Page",
					action = "Index"
				}
				);

			routes.MapRoute(name: "Blog",
				url: "Blog/{page}",
				defaults: new {
					controller = "Blog",
					action = "GetPost"
				}
				);

			routes.MapRoute(
				name: "Default",
				url: "{controller}/{action}/{id}",
				defaults: new {
					controller = "Blog",
					action = "Index",
					id = 0
				}
				);

		}
	}
}
