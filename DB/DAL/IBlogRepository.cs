using System.Collections.Generic;

namespace DB.DAL {
	public interface IBlogRepository {
		bool CreatePost(User author, string title, string content, Language lang);
		bool CreatePost(User author, string title, string content, Language lang, string url);
		List<BlogPost> GetAll(Language lang);
		BlogPost GetPostById(int id);
		BlogPost GetPostByUrl(string url, Language lang);
		List<BlogPost> GetPostsByPage(int postsOnPage, int page, Language lang);
		List<BlogPost> GetPostsByAuthor(int authorId);
		bool UpdatePost(int id, string title, string content);
		bool UpdatePost(int id, string title, string content, string url);
		bool DeletePostById(int id);
		// IBlogRepository also works with blog comments
		bool CreateComment(int postId, string email, string name, string content);
		bool CreateComment(int postId, int authorId, string content);
		bool CreateComment(BlogPost post, User author, string content);
		List<BlogComment> GetCommentsToPostById(int postId);
		bool DeleteCommentById(int id);
	}
}
