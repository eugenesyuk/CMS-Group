using System;
using System.Collections.Generic;
using System.Linq;

namespace DB.DAL {
	public class PageRepository : EntityRepository, IPageRepository {
		public bool Create(string name, string title, string content, Language language) {
			throw new NotImplementedException();
		}

		public List<Page> GetAll(Language lang) {
			throw new NotImplementedException();
		}

		public Page Get(string name, Language lang) {
			return DbEntities.Pages.FirstOrDefault(x => x.Name.Equals(name) && x.Language == lang.Id);
		}

		public bool Update(string name, string newName, string title, string content, Language language) {
			throw new NotImplementedException();
		}

		public bool Delete(string name) {
			throw new NotImplementedException();
		}
	}
}
