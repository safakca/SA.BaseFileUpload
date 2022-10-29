using BaseFileUpload.Entities;
using System.Linq.Expressions;

namespace BaseFileUpload.DataAccess.Abstract
{
    public interface IImageDal
    {
        void Add(ImageEntity entity);
        void Update(ImageEntity entity);
        void Delete(int id);
        List<ImageEntity> GetAll(Expression<Func<ImageEntity,bool>> filter=null);
        ImageEntity Get(Expression<Func<ImageEntity, bool>> filter);

    }
}
