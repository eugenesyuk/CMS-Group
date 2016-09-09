namespace DB.DAL {
	public class EntityRepository {
		protected DbModelContainer DbEntities;

		protected EntityRepository() {
			DbEntities = new DbModelContainer();
		}
	}
}
