using Business.Concrete;
using DataAccess.Concrete.EntityFramework;
using System.Web.Mvc;

namespace MVCBlog.Controllers
{
    public class SkillController : Controller
    {
        SkillManager skillManager = new SkillManager(new EfSkillDal());
        public ActionResult Index()
        {
            var skillValue = skillManager.GetAll();
            return View(skillValue);
        }
    }
}