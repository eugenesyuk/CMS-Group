using System;
using System.Collections.Generic;
using System.Linq;
using DB.Resources;

namespace DB.DAL {
	public class MenuRepository : EntityRepository, IMenuRepository {
		public bool CreateMenu(SiteMenu parent, string title, string url, Language lang, short order) {
			SiteMenu menu = new SiteMenu();
			menu.Parent = parent.Id;
			menu.Title = title;
			menu.Url = url;
			menu.Language = lang.Id;
			menu.Order = order;
			DbEntities.SiteMenus.Add(menu);
			DbEntities.SaveChanges();
			return DbEntities.SiteMenus.Any(x => x.Id.Equals(menu.Id));
		}

		public List<SiteMenu> GetAll(Language lang) {
			return DbEntities.SiteMenus.Where(x => x.Language == lang.Id).OrderBy(x => x.Order).ToList();
		}

		public SiteMenu GetMenuById(int id) {
			return DbEntities.SiteMenus.FirstOrDefault(x => x.Id.Equals(id));
		}

		public SiteMenu GetMenuByTitle(string title) {
			return DbEntities.SiteMenus.FirstOrDefault(x => x.Title.Equals(title));
		}

		public bool UpdateMenuById(int id, SiteMenu parent, string title, string url, Language lang) {
			var menu = DbEntities.SiteMenus.FirstOrDefault(x => x.Id.Equals(id));
			if(menu == null)
				throw new NullReferenceException(Errors.MenuNotExists);
			menu.Title = title;
			menu.Url = url;
			menu.Parent = parent.Id;
			menu.Title = title;
			DbEntities.SaveChanges();
			return DbEntities.SiteMenus.Any(x => x.Title.Equals(title) && x.Url.Equals(url));
		}

		public bool DeleteMenuById(int id) {
			var menu = DbEntities.SiteMenus.FirstOrDefault(x => x.Id.Equals(id));
			if(menu == null)
				throw new NullReferenceException(Errors.MenuNotExists);
			DbEntities.SiteMenus.Remove(menu);
			DbEntities.SaveChanges();
			return !DbEntities.SiteMenus.Any(x => x.Id.Equals(id));
		}
	}
}
