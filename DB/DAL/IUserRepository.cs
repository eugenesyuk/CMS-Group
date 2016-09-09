using System.Collections.Generic;

namespace DB.DAL {
	public interface IUserRepository {
		bool CreateUser(string email, string name, string password);
		List<User> GetAll();
		User GetUserById(int id);
		User GetUserByEmail(string email);
		User GetUserByName(string name);
		bool UpdateUser(int id, string email, string name, string password);
		bool DeleteUserById(int id);
		bool DeleteUserByEmail(string email);
		bool ValidateUserPassword(string email, string name, string password);
	}
}
