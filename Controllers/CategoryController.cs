using Blog.Web.Data;
using Blog.Web.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Blog.Web.Controllers;

public class CategoryController: Controller
{
    private readonly ApplicationDbContext _db;

    public CategoryController(ApplicationDbContext db)
    {
        _db = db;
    } 
    
    public async Task<IActionResult> PostList(int categoryId, int page = 1, int pageSize = 10)
    {
        var posts = await _db.Posts.Include(p => p.Category).Where(p => p.CategoryId == categoryId).ToListAsync();
        return View(posts);
    }
}