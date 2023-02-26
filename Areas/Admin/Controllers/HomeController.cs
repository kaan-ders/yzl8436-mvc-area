using Area.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MvcEf;

namespace Area.Areas.Admin.Controllers
{
    [Area("Admin")]
    [LoginKontrol]
    public class HomeController : Controller
    {
        private CmsContext _context;
        public HomeController(CmsContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            //kişi login mi?
            //if(HttpContext.Session.GetInt32("LoginMi") == null)
            //{
            //    return Redirect("/Admin/Auth/Index");
            //}

            List<BlogPost> postlar = _context.BlogPost.ToList();
            return View(postlar);
        }

        [HttpGet]
        public IActionResult Add()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Add(BlogPost model)
        {
            _context.BlogPost.Add(model);
            _context.SaveChanges();

            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult Update(int id)
        {
            var model = _context.BlogPost.FirstOrDefault(x => x.Id == id);
            return View(model);
        }

        [HttpPost]
        public IActionResult Update(BlogPost model)
        {
            _context.BlogPost.Update(model);
            _context.SaveChanges();

            return RedirectToAction("Index");
        }

        public IActionResult Delete(int id)
        {
            _context.Database.ExecuteSqlRaw($"delete from BlogPost where Id = {id}");
            return RedirectToAction("Index");
        }
    }
}
