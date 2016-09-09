using System;
using System.Collections.Generic;
using System.Linq;
using DB.Extensions;
using DB.Resources;

namespace DB.DAL {
	public class UserRepository : EntityRepository, IUserRepository {
		public bool CreateUser(string email, string name, string password) {
			if(DbEntities.Users.Any(x => x.Email.Equals(email)))
				throw new ArgumentException(Errors.UserExists);
			DbEntities.Users.Add(new User {
				Email = email,
				Name = name,
				Password = password.ToSHA1Hash()
			});
			DbEntities.SaveChanges();
			return DbEntities.Users.Any(x => x.Email.Equals(email));
		}

		public List<User> GetAll() {
			return DbEntities.Users.ToList();
		}

		public User GetUserById(int id) {
			return DbEntities.Users.FirstOrDefault(x => x.Id.Equals(id));
		}

		public User GetUserByEmail(string email) {
			return DbEntities.Users.FirstOrDefault(x => x.Email.Equals(email));
		}

		public User GetUserByName(string name) {
			return DbEntities.Users.FirstOrDefault(x => x.Name.Equals(name));
		}

		public bool UpdateUser(int id, string email, string name, string password) {
			var user = DbEntities.Users.FirstOrDefault(x => x.Id.Equals(id));
			if(user == null)
				throw new NullReferenceException(Errors.UserNotExists);
			user.Email = email;
			user.Name = name;
			user.Password = password.ToSHA1Hash();
			DbEntities.SaveChanges();
			return DbEntities.Users.Any(x => x.Email.Equals(email) && x.Name.Equals(name));
		}

		public bool DeleteUserById(int id) {
			var user = DbEntities.Users.FirstOrDefault(x => x.Id.Equals(id));
			if(user == null)
				throw new NullReferenceException(Errors.UserNotExists);
			DbEntities.Users.Remove(user);
			DbEntities.SaveChanges();
			return !DbEntities.Users.Any(x => x.Id.Equals(id));
		}

		public bool DeleteUserByEmail(string email) {
			var user = DbEntities.Users.FirstOrDefault(x => x.Email.Equals(email));
			if(user == null)
				throw new NullReferenceException(Errors.UserNotExists);
			DbEntities.Users.Remove(user);
			DbEntities.SaveChanges();
			return !DbEntities.Users.Any(x => x.Email.Equals(email));
		}

		public bool ValidateUserPassword(string email, string name, string password) {
			if(email != null)
				return DbEntities.Users.Any(x => x.Email.Equals(email) && x.Password.Equals(password.ToSHA1Hash()));
			else if(name != null)
				return DbEntities.Users.Any(x => x.Name.Equals(email) && x.Password.Equals(password.ToSHA1Hash()));
			throw new ArgumentNullException(Errors.NameEmailNotExists);
		}
	}
}
