using System.Collections.Generic;

namespace DB.DAL {
	public interface IMenuRepository {
		bool CreateMenu(SiteMenu parent, string title, string url, Language lang, short order);
		List<SiteMenu> GetAll(Language lang);
		SiteMenu GetMenuById(int id);
		SiteMenu GetMenuByTitle(string title);
		bool UpdateMenuById(int id, SiteMenu parent, string title, string url, Language lang);
		bool DeleteMenuById(int id);
	}
}
