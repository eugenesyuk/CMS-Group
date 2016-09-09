using System;
using System.Web.Security;
using DB.DAL;
using Ninject;

namespace Web {
	public class WebsiteMembershipProvider : MembershipProvider {
		[Inject]
		public IUserRepository _UserRepository {
			get;
			set;
		}

		public override string ApplicationName {
			get {
				throw new NotImplementedException();
			}
			set {
				throw new NotImplementedException();
			}
		}

		public override bool ChangePassword(string username, string oldPassword, string newPassword) {
			throw new NotImplementedException();
		}

		public override bool ChangePasswordQuestionAndAnswer(string username, string password, string newPasswordQuestion, string newPasswordAnswer) {
			throw new NotImplementedException();
		}

		public override MembershipUser CreateUser(string username, string password, string email, string passwordQuestion, string passwordAnswer, bool isApproved, object providerUserKey, out MembershipCreateStatus status) {
			ValidatePasswordEventArgs args = new ValidatePasswordEventArgs(email, password, true);
			OnValidatingPassword(args);
			if(args.Cancel) {
				status = MembershipCreateStatus.InvalidPassword;
				return null;
			}
			if(RequiresUniqueEmail && GetUserNameByEmail(email) != string.Empty) {
				status = MembershipCreateStatus.DuplicateEmail;
				return null;
			}
			MembershipUser user = GetUser(username, true);
			if(user == null) {
				try {
					status = _UserRepository.CreateUser(email, username, password) ? MembershipCreateStatus.Success : MembershipCreateStatus.DuplicateEmail;
				} catch(ArgumentException) {
					status = MembershipCreateStatus.DuplicateEmail;
				}
				return GetUser(username, true);
			}
			status = MembershipCreateStatus.DuplicateUserName;
			return null;
		}

		public override bool DeleteUser(string username, bool deleteAllRelatedData) {
			throw new NotImplementedException();
		}

		public override bool EnablePasswordReset {
			get {
				throw new NotImplementedException();
			}
		}

		public override bool EnablePasswordRetrieval {
			get {
				throw new NotImplementedException();
			}
		}

		public override MembershipUserCollection FindUsersByEmail(string emailToMatch, int pageIndex, int pageSize, out int totalRecords) {
			throw new NotImplementedException();
		}

		public override MembershipUserCollection FindUsersByName(string usernameToMatch, int pageIndex, int pageSize, out int totalRecords) {
			throw new NotImplementedException();
		}

		public override MembershipUserCollection GetAllUsers(int pageIndex, int pageSize, out int totalRecords) {
			throw new NotImplementedException();
		}

		public override int GetNumberOfUsersOnline() {
			throw new NotImplementedException();
		}

		public override string GetPassword(string username, string answer) {
			throw new NotImplementedException();
		}

		public override MembershipUser GetUser(string username, bool userIsOnline) {
			var user = _UserRepository.GetUserByName(username);
			if(user == null)
				return null;
			return new MembershipUser("WebsiteMembershipProvider",
				user.Name, user.Id, user.Email, string.Empty, string.Empty,
				true, false, DateTime.MinValue, DateTime.MinValue, DateTime.MinValue,
				DateTime.Now, DateTime.Now);
		}

		public override MembershipUser GetUser(object providerUserKey, bool userIsOnline) {
			throw new NotImplementedException();
		}

		public override string GetUserNameByEmail(string email) {
			throw new NotImplementedException();
		}

		public override int MaxInvalidPasswordAttempts {
			get {
				throw new NotImplementedException();
			}
		}

		public override int MinRequiredNonAlphanumericCharacters {
			get {
				throw new NotImplementedException();
			}
		}

		public override int MinRequiredPasswordLength {
			get {
				return 6;
			}
		}

		public override int PasswordAttemptWindow {
			get {
				throw new NotImplementedException();
			}
		}

		public override MembershipPasswordFormat PasswordFormat {
			get {
				throw new NotImplementedException();
			}
		}

		public override string PasswordStrengthRegularExpression {
			get {
				throw new NotImplementedException();
			}
		}

		public override bool RequiresQuestionAndAnswer {
			get {
				throw new NotImplementedException();
			}
		}

		public override bool RequiresUniqueEmail {
			get {
				return false;
			}
		}

		public override string ResetPassword(string username, string answer) {
			throw new NotImplementedException();
		}

		public override bool UnlockUser(string userName) {
			throw new NotImplementedException();
		}

		public override void UpdateUser(MembershipUser user) {
			throw new NotImplementedException();
		}

		public override bool ValidateUser(string username, string password) {
			return _UserRepository.ValidateUserPassword(null, username, password);
		}
	}
}
