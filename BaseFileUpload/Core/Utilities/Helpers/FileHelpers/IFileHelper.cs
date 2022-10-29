namespace BaseFileUpload.Core.Utilities.Helpers.FileHelpers
{
    public interface IFileHelper
    {
        string Upload(IFormFile formFile, string root);
        void Remove(string imagePath);
        string Update(IFormFile formFile, string imagePath, string root);
    }
}
