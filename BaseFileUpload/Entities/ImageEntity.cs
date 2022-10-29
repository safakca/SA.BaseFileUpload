using System.ComponentModel.DataAnnotations.Schema;

namespace BaseFileUpload.Entities;
public class ImageEntity
{
    public int Id { get; set; }
    public string ImageUrl { get; set; } = string.Empty;
    public DateTime CreatedDate { get; set; } = DateTime.Now;

    [NotMapped]
    public IFormFile? FormFile { get; set; }
}

