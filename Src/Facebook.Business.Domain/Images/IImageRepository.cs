namespace Facebook.Business.Domain.Images
{
    public interface IImageRepository
    {
        Image FindById(int id);

        void Add(Image img);
    }
}