using System.ComponentModel.DataAnnotations;

namespace DemoApplication.Areas.Admin.ViewModels.BookImage
{
    public class UpdateViewModel
    {
        public int Id { get; set; }
        public string? ImageUrl { get; set; }
        public IFormFile? ImageName { get; set; }
    }
}
