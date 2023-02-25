using Microsoft.AspNetCore.Mvc;
using MvcEf;

namespace Area.Controllers
{
    public class HomeController : Controller
    {
        private CmsContext _context;
        public HomeController(CmsContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            var postlar = _context.BlogPost.ToList();
            return View(postlar);
        }

        public IActionResult Post(int id)
        {
            var post = _context.BlogPost.First(x => x.Id == id);
            return View(post);
        }
    }
}