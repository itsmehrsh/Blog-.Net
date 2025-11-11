namespace Blog.Web.Models;

public class Post
{
    public int Id { get; set; }
    public string Title { get; set; } = null!;
    public string Content { get; set; } = null!;
    public string Summary { get; set; } = null!;
    public DateTime Published { get; set; }
    public string CategoryId { get; set; } = null!;  // Foreign key
    public Category Category { get; set; } = null!;  // Navigation property
}