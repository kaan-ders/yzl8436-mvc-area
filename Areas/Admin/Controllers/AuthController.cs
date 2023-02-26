using Area.Models;
using Microsoft.AspNetCore.Mvc;

namespace Area.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class AuthController : Controller
    {
        //login
        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Index(LoginModel model)
        {
            //login işlemi

            if(model.Username == "admin" && model.Password == "123")
            {
                HttpContext.Session.SetInt32("LoginMi", 1);
                return Redirect("/Admin/Home/Index");
            }

            ViewBag.Hata = "Kullanıcı adı veya şifresi yanlış";
            return View();
        }

        public IActionResult Logout()
        {
            HttpContext.Session.Remove("LoginMi");
            return Redirect("/Home/Index");
        }
    }
}
