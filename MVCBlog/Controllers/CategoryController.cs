using Business.Concrete;
using Entities.Concrete;
using System.Web.Mvc;

namespace MVCBlog.Controllers
{
    public class CategoryController : Controller
    {
        CategoryManager categoryManager = new CategoryManager();
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult GetAll()
        {
            var categoryValues = categoryManager.GetAll();
            return View(categoryValues);
        }

        public ActionResult AddCategory()
        {
            return View();
        }

        [HttpPost]
        public ActionResult AddCategory(Category category)
        {
            categoryManager.Add(category);
            return RedirectToAction("GetAll"); //Ekleme işlemi yaptıktan sonra buradaki metoda git.
        }

    }
}