using System.ComponentModel.DataAnnotations;

namespace Blog.Web.Areas.Admin.ViewModels;

public class PostViewModel
{
    [Required, StringLength(250)]
    public string Title { get; set; } = string.Empty;

    [Required, StringLength(600)]
    public string Summary { get; set; } = string.Empty;

    [Required]
    public string Content { get; set; } = string.Empty;

    [Required]
    public int CategoryId { get; set; }
}
