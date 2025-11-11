namespace Blog.Web.Models;

public class Category
{
    public string Id { get; set; } = null!;
    public string Title { get; set; } = null!;
    
    // one category can have many posts
    public List<Post> Posts { get; set; } = new();
}