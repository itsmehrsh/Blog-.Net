using Blog.Web.Data;
using Blog.Web.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Blog.Web.Controllers;

public class PostController : Controller
{
    private readonly ApplicationDbContext _db;
    public PostController(ApplicationDbContext db) => _db = db;

    public async Task<IActionResult> Index()
    {
        var items = await _db.Posts.Include(p => p.Category).OrderByDescending(p => p.Published).ToListAsync();
        return View(items);
    }

    public async Task<IActionResult> List()
    {
        var items = await _db.Posts.Include(p => p.Category).OrderByDescending(p => p.Published).ToListAsync();
        return View(items);
    }

    public async Task<IActionResult> Detail(int postId)
    {
        var post = await _db.Posts.Include(p => p.Category).FirstOrDefaultAsync(p => p.Id == postId);
        return View(post);
    }
}