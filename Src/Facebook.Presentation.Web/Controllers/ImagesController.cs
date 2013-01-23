using System.IO;
using System.Web;
using System.Web.Mvc;
using Facebook.Business.Domain.Images;
using Facebook.Data;

namespace Facebook.Presentation.Web.Controllers
{
    public class ImagesController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;

        public ImagesController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }


        public ActionResult GetImageFromId(int id)
        {
            var images = _unitOfWork.Images;
            var img = images.FindById(id);
            return new FileContentResult(img.Data, string.Format("image/{0}", img.Format));
        }

        //public FileContentResult GetImage(Image img)
        //{
        //    return new FileContentResult(img.Data, string.Format("image/{0}", img.Format));
        //}

        [HttpPost]
        public ActionResult Upload(HttpPostedFileBase file, string description)
        {
            var format = Path.GetExtension(file.FileName);
            var data = new byte[file.InputStream.Length];
            file.InputStream.Read(data, 0, data.Length);

            _unitOfWork.Images.Add(new Image(data, format, description));

            return null;
        }
    }
}
