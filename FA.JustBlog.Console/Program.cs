using System;
using FA.JustBlog.Core.Models;
using FA.JustBlog.Core.Repositories;
using FA.JustBlog.Core.Repositories.Implementation;
using FA.JustBlog.Core.Repositories.Interfaces;
using System.Xml.Linq;

namespace FA.JustBlog.Console
{
    public class Program
    {
        static private JustBlogContext _context = new JustBlogContext();
        static private IPostRepository _postRepository = new PostRepository(_context);
        static private ICategoryRepository _categoryRepository = new CategoryRepository(_context);
        static private ICommentRepository _commentRepository = new CommentRepository(_context);
        static private ITagRepository _tagRepository = new TagRepository(_context);
        static void Main(string[] args)
        {
            System.Console.WriteLine("----------Posts----------");
            var posts = _postRepository.GetAll();
            foreach(var item in posts)
            {
                System.Console.WriteLine("Title: {0,-35} | Url Slug: {1:-35}", item.Title, item.UrlSlug);
            }

            System.Console.WriteLine("----------Comments----------");
            var comments = _commentRepository.GetAll();
            foreach (var item in comments)
            {
                System.Console.WriteLine("Header: {0,-30} | Text: {1:-35}", item.CommentHeader, item.CommentText);
            }

            System.Console.WriteLine("----------Categories----------");
            var categories = _categoryRepository.GetAll();
            foreach (var item in categories)
            {
                System.Console.WriteLine("Name: {0,-35} | Url Slug: {1:-35}", item.Name, item.UrlSlug);
            }
        }
    }
}