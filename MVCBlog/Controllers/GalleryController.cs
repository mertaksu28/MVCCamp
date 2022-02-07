using Business.Concrete;
using DataAccess.Concrete.EntityFramework;
using System.Web.Mvc;

namespace MVCBlog.Controllers
{
    public class GalleryController : Controller
    {
        ImageFileManager fileManager = new ImageFileManager(new EfImageFileDal());
        public ActionResult Index()
        {
            var imageFiles = fileManager.GetAll();
            return View(imageFiles);
        }
    }
}