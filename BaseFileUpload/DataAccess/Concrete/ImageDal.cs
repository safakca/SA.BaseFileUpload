using BaseFileUpload.Constant;
using BaseFileUpload.Core.Utilities.Helpers.FileHelpers;
using BaseFileUpload.DataAccess.Abstract;
using BaseFileUpload.DataAccess.Context;
using BaseFileUpload.Entities;
using System.Linq.Expressions;

namespace BaseFileUpload.DataAccess.Concrete
{
    public class ImageDal : IImageDal
    {
        private readonly DatabaseContext _context;
        private readonly IFileHelper _fileHelper;
        public ImageDal(DatabaseContext context, IFileHelper fileHelper)
        {
            _context = context;
            _fileHelper = fileHelper;
        }

        public void Add(ImageEntity entity)
        {
            entity.ImageUrl = _fileHelper.Upload(entity.FormFile, FilePath.Root);
            _context.Images.Add(entity);
            _context.SaveChanges();
        }

        public void Delete(int id)
        {
            var deleted=Get(x=>x.Id==id);
            _fileHelper.Remove(FilePath.Root + deleted.ImageUrl);
            _context.Remove(deleted);
            _context.SaveChanges();
        }

        public ImageEntity Get(Expression<Func<ImageEntity, bool>> filter)
        {
            return _context.Images.SingleOrDefault(filter);
        }

        public List<ImageEntity> GetAll(Expression<Func<ImageEntity, bool>> filter = null)
        { 
           return filter==null ? _context.Images.ToList() : _context.Images.Where(filter).ToList();
        }

        public void Update(ImageEntity entity)
        {
            var updated=Get(x=>x.Id==entity.Id);
            updated.ImageUrl = _fileHelper.Update(entity.FormFile, FilePath.Root + updated.ImageUrl, FilePath.Root);
            _context.Update(updated);
            _context.SaveChanges();
        }
    }
}
