using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using MVC02.Data;
using MVC02.Models;


namespace MVC02.Controllers
{
    public class PostController : Controller
    {
        private readonly ApplicationDbContext _context;

        public PostController()
        {
            _context = new();
        }

        public IActionResult Index()
        {
            var posts = _context.Posts.Include(p => p.User).ToList();
            return View(posts);
        }


        public IActionResult Details(int id)
        {
            Post post = _context.Posts.SingleOrDefault(p => p.Id == id);

            if (post == null)
            {
                return Content("Post Not Found");
            }

            return View(post);
        }

        public IActionResult Create()
        {
            ViewBag.UserId = new SelectList(_context.Users, "Id", "Name");

            return View();
        }

        [HttpPost]
        public IActionResult Create(Post post)
        {
            _context.Posts.Add(post);
            _context.SaveChanges();
            TempData["Message"] = "Post created successfully";
            return RedirectToAction("Index");
        }
     

        public IActionResult Edit(int id)
        {
            var post = _context.Posts.SingleOrDefault(p => p.Id == id);
            if (post == null)
            {
                return NotFound();
            }
            ViewBag.UserId = new SelectList(_context.Users, "Id", "Name");
            return View(post);
        }


        [HttpPost]
        public IActionResult Edit(Post post)
        {
            Post existingPost = _context.Posts.SingleOrDefault(p => p.Id == post.Id);
            if (existingPost == null) return Content("Post not Found");

            existingPost.Title = post.Title;
            existingPost.Category = post.Category;
            existingPost.Body = post.Body;
            existingPost.Likes = post.Likes;
            existingPost.Share = post.Share;
            existingPost.UserId = post.UserId;

            _context.SaveChanges();
            TempData["Message"] = "Post updated successfully";
            return RedirectToAction("Index");
        }

        public IActionResult Delete(int id)
        {
            Post post = _context.Posts.SingleOrDefault(p => p.Id == id);
            if (post == null) return Content("Post not Found");

            _context.Posts.Remove(post);
            _context.SaveChanges();
            TempData["Message"] = "Post deleted successfully";
            return RedirectToAction("Index");
        }
    }
}
