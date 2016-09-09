using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;

namespace DB.DAL {
	public class LanguageRepository : EntityRepository, ILanguageRepository {
		public bool Create(string code, string iconUrl) {
			throw new NotImplementedException();
		}

		public Language Get(int id) {
			throw new NotImplementedException();
		}

		public Language Get(string code) {
			return DbEntities.Languages.FirstOrDefault(x => x.Code.Equals(code));
		}

		public Language GetCurrentLanguage() {
			return DbEntities.Languages.FirstOrDefault(x => x.Code.Equals(Thread.CurrentThread.CurrentCulture.Name.Substring(0, 2)));
		}

		public List<Language> GetAll() {
			return DbEntities.Languages.ToList();
		}

		public bool Update(int id, string code, string iconUrl) {
			throw new NotImplementedException();
		}

		public bool Delete(int id) {
			throw new NotImplementedException();
		}
	}
}
