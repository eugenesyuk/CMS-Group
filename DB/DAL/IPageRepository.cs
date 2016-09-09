using System.Collections.Generic;
namespace DB.DAL {
	public interface IPageRepository {
		bool Create(string name, string title, string content, Language language);
		List<Page> GetAll(Language lang);
		Page Get(string name, Language lang);
		bool Update(string name, string newName, string title, string content, Language language);
		bool Delete(string name);
	}
}
