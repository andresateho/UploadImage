namespace UploadImage.Model
{
    using Microsoft.AspNetCore.Http;
    using System.ComponentModel.DataAnnotations;

    public class FileImageModel
    {
        [Required]
        public IFormFile Image { get; set; }
    }
}
