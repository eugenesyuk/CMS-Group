using System;
using System.Collections.Generic;
using System.Linq;
using DB.Extensions;

namespace DB.DAL {
	public class BlogRepository : EntityRepository, IBlogRepository {
		public bool CreatePost(User author, string title, string content, Language lang) {
			return CreatePost(author, title, content, lang, title.GetURL());
		}

		public bool CreatePost(User author, string title, string content, Language lang, string url) {
			if(DbEntities.BlogPosts.Any(x => x.Title.Equals(title) && x.Content.Equals(content)))
				throw new ArgumentException("Post with same title and content already exists.");
			DbEntities.BlogPosts.Add(new BlogPost {
				Author = author.Id,
				Title = title,
				Content = content,
				Url = url,
				Language = lang.Id
			});
			DbEntities.SaveChanges();
			return DbEntities.BlogPosts.Any(x => x.Title.Equals(title) && x.Content.Equals(content));
		}

		public List<BlogPost> GetAll(Language lang) {
			return DbEntities.BlogPosts.Where(x => x.Language == lang.Id).ToList();
		}

		public BlogPost GetPostById(int id) {
			return DbEntities.BlogPosts.FirstOrDefault(x => x.Id.Equals(id));
		}

		public BlogPost GetPostByUrl(string url, Language lang) {
			return DbEntities.BlogPosts.FirstOrDefault(x => x.Url.Equals(url) && x.Language == lang.Id);
		}

		public List<BlogPost> GetPostsByPage(int postsOnPage, int page, Language lang) {
			return DbEntities.BlogPosts.Where(x => x.Language == lang.Id).OrderByDescending(x => x.Date).Skip(postsOnPage * page).Take(postsOnPage).ToList();
		}

		public List<BlogPost> GetPostsByAuthor(int authorId) {
			return DbEntities.BlogPosts.Where(x => x.Author.Equals(authorId)).ToList();
		}

		public bool UpdatePost(int id, string title, string content) {
			return UpdatePost(id, title, content, title.GetURL());
		}

		public bool UpdatePost(int id, string title, string content, string url) {
			var post = DbEntities.BlogPosts.FirstOrDefault(x => x.Id.Equals(id));
			if(post == null)
				throw new NullReferenceException("Post doesn't exists in database");
			post.Title = title;
			post.Content = content;
			post.Url = url;
			DbEntities.SaveChanges();
			return DbEntities.BlogPosts.Any(x => x.Title.Equals(title) && x.Content.Equals(content) && x.Url.Equals(url));
		}

		public bool DeletePostById(int id) {
			var post = DbEntities.BlogPosts.FirstOrDefault(x => x.Id.Equals(id));
			if(post == null)
				throw new NullReferenceException("Post doesn't exists in database");
			DbEntities.BlogPosts.Remove(post);
			DbEntities.SaveChanges();
			return !DbEntities.BlogPosts.Any(x => x.Id.Equals(post.Id));
		}

		public bool CreateComment(int postId, string email, string name, string content) {
			if(DbEntities.BlogComments.Any(x => x.PostId.Equals(postId) && x.Email.Equals(email) && x.Content.Equals(content) && x.Name.Equals(name)))
				throw new ArgumentException("Such comment already exists.");
			DbEntities.BlogComments.Add(new BlogComment {
				PostId = postId,
				Email = email,
				Name = name,
				Content = content
			});
			DbEntities.SaveChanges();
			return DbEntities.BlogComments.Any(x => x.PostId.Equals(postId) && x.Email.Equals(email) && x.Content.Equals(content) && x.Name.Equals(name));
		}

		public bool CreateComment(int postId, int authorId, string content) {
			if(DbEntities.BlogComments.Any(x => x.PostId.Equals(postId) && x.Author.Equals(authorId) && x.Content.Equals(content)))
				throw new ArgumentException("Comment with same content already exists.");
			DbEntities.BlogComments.Add(new BlogComment {
				PostId = postId,
				Author = authorId,
				Content = content
			});
			DbEntities.SaveChanges();
			return DbEntities.BlogComments.Any(x => x.PostId.Equals(postId) && x.Author.Equals(authorId) && x.Content.Equals(content));
		}

		public bool CreateComment(BlogPost post, User author, string content) {
			return CreateComment(post.Id, author.Id, content);
		}

		public List<BlogComment> GetCommentsToPostById(int postId) {
			return DbEntities.BlogComments.Where(x => x.PostId.Equals(postId)).ToList();
		}

		public bool DeleteCommentById(int id) {
			var comment = DbEntities.BlogComments.FirstOrDefault(x => x.Id.Equals(id));
			if(comment == null)
				throw new NullReferenceException("Comment doesn't exists in database");
			DbEntities.BlogComments.Remove(comment);
			DbEntities.SaveChanges();
			return !DbEntities.BlogPosts.Any(x => x.Id.Equals(comment.Id));
		}
	}
}
