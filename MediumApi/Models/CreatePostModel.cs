using System.ComponentModel.DataAnnotations;

namespace MediumApi.Models
{
    public class CreatePostModel
    {
        [Required] public string Title { get; set; }
        [Required] public string Description { get; set; }
    }
}