using System.Data.Entity;
using Facebook.Business.Domain.Images;
using Facebook.Infrastructure.Contracts;

namespace Facebook.Data.EntityFramework.Repositories
{
    class ImageRepository : Repository<Image>, IImageRepository
    {
        public ImageRepository(DbSet<Image> set) : base(set)
        {
        }

        #region Implementation of IImageRepository

        public Image FindById(int id)
        {
            return Set.Find(id);
        }

        public void Add(Image img)
        {
            ContractUtil.NotNull(img);

            Set.Add(img);
        }

        #endregion
    }
}