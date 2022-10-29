namespace BaseFileUpload.Core.Utilities.Helpers.FileHelpers
{
    public class FileHelper : IFileHelper
    {
        public void Remove(string imagePath)
        {
            if (File.Exists(imagePath))
            {
                File.Delete(imagePath);
            }
        }

        public string Update(IFormFile formFile, string imagePath, string root)
        {
            if(File.Exists(imagePath))
            {
                File.Delete(imagePath);
            }
            return Upload(formFile, root);
        }

        public string Upload(IFormFile formFile, string root)
        {
            if (formFile.Length > 0)
            {
                if (!Directory.Exists(root))
                {
                    Directory.CreateDirectory(root);
                }

                var extension = Path.GetExtension(formFile.FileName);
                var guid = Guid.NewGuid().ToString();
                var imageUrl = guid + extension;

                using (FileStream fileStream = File.Create(root + imageUrl))
                {
                    formFile.CopyTo(fileStream);
                    fileStream.Flush();
                    return imageUrl;
                }
            }
            return null;
        }
    }
}

