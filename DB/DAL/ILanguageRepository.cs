using System.Collections.Generic;

namespace DB.DAL {
	public interface ILanguageRepository {
		bool Create(string code, string iconUrl);
		Language Get(int id);
		Language Get(string code);
		Language GetCurrentLanguage();
		List<Language> GetAll();
		bool Update(int id, string code, string iconUrl);
		bool Delete(int id);
	}
}
