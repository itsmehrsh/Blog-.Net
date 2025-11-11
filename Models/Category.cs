namespace Blog.Web.Models;

public class Category
{
    public int Id { get; set; }
    public string Title { get; set; } = null!;
    
    // one category can have many posts
    public List<Post> Posts { get; set; } = new();
}