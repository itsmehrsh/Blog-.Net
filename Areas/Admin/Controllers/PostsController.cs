using Blog.Web.Areas.Admin.ViewModels;
using Blog.Web.Data;
using Blog.Web.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace Blog.Web.Areas.Admin.Controllers;

[Area("Admin")]
public class PostsController : Controller
{
    private readonly ApplicationDbContext _db;

    public PostsController(ApplicationDbContext db) => _db = db;

    [HttpGet]
    public IActionResult Create()
    {
        ViewBag.Categories = new SelectList(_db.Categories.OrderBy(c => c.Title).ToList(), "Id", "Title");
        return View(new PostViewModel());
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public IActionResult Create(PostViewModel vm)
    {
        if (!ModelState.IsValid)
        {
            ViewBag.Categories = new SelectList(_db.Categories.OrderBy(c => c.Title).ToList(), "Id", "Title");
            return View(vm);
        }

        var post = new Post
        {
            Title = vm.Title,
            Summary = vm.Summary,
            Content = vm.Content,
            CategoryId = vm.CategoryId,
            Published = DateTime.UtcNow
        };

        _db.Posts.Add(post);
        _db.SaveChanges();

        return RedirectToAction("Index", "Posts", new { area = "Admin" });
    }

    // Optional: Index action to list posts in admin
    [HttpGet]
    public IActionResult Index()
    {
        var posts = _db.Posts.OrderByDescending(p => p.Published).ToList();
        return View(posts);
    }
}
