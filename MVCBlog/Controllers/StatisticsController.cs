using DataAccess.Concrete;
using System.Linq;
using System.Web.Mvc;

namespace MVCBlog.Controllers
{
    public class StatisticsController : Controller
    {
        Context context = new Context();
        public ActionResult Index()
        {
            var totalCategory = context.Categories.Count().ToString();
            ViewBag.TotalCategory = totalCategory;

            var subtitleSoftwareCount = context.Headings.Count(h => h.HeadingName == "Yazılım");
            ViewBag.SubtitleSoftwareCount = subtitleSoftwareCount;

            var novelistName = (from n in context.Writers
                                select n.WriterName.IndexOf("a")).Distinct().Count().ToString();
            ViewBag.NoveListName = novelistName;

            var categoryTitle = context.Categories.Where(c => c.CategoryId == context.Headings.GroupBy(b => b.CategoryId)
                                                         .OrderByDescending(y => y.Count()).Select(a => a.Key)
                                                         .FirstOrDefault()).Select(z => z.CategoryName).FirstOrDefault();
            ViewBag.CategoryTitle = categoryTitle;

            var variation = context.Categories.Count(v => v.Status == true) - context.Categories.Count(v => v.Status == false);
            ViewBag.Variation = variation;

            return View();

        }
    }
}