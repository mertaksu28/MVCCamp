using Business.Concrete;
using Business.ValidationRules;
using DataAccess.Concrete.EntityFramework;
using Entities.Concrete;
using FluentValidation.Results;
using System.Web.Mvc;

namespace MVCBlog.Controllers
{
    public class AdminCategoryController : Controller
    {
        CategoryManager categoryManager = new CategoryManager(new EfCategoryDal());
        public ActionResult Index()
        {
            var categoryValue = categoryManager.GetAll();
            return View(categoryValue);
        }

        [HttpGet]
        public ActionResult AddCategory()
        {
            return View();
        }

        [HttpPost]
        public ActionResult AddCategory(Category category)
        {
            CategoryValidator validationRules = new CategoryValidator();
            ValidationResult validationResult = validationRules.Validate(category);
            if (validationResult.IsValid)
            {
                categoryManager.Add(category);
                return RedirectToAction("Index");
            }
            else
            {
                foreach (var item in validationResult.Errors)
                {
                    ModelState.AddModelError(item.PropertyName, item.ErrorMessage);
                }
            }
            return View();
        }

        public ActionResult DeleteCategory(int id)
        {
            var categoryId = categoryManager.GetById(id);
            categoryManager.Delete(categoryId);
            return RedirectToAction("Index");
        }
        // Güncelleme işlemi için iki işlem mevcut
        // 1-Güncellenecek bilgilerin güncellenme sayfasına taşınması işlemi
        // 2-Güncelleme işleminin yapılması işlemi
        [HttpGet]
        public ActionResult UpdateCategory(int id)
        {
            // Önce Güncellenecek olan kategoriyi bulmak gerekir
            var categoryId = categoryManager.GetById(id);
            return View(categoryId);
        }

        [HttpPost]
        public ActionResult UpdateCategory(Category category)
        {
            categoryManager.Update(category);
            return RedirectToAction("Index");
        }

    }
}


