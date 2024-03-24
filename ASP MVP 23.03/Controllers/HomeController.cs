using ASP_MVP_23._03.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace ASP_MVP_23._03.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Registration()
        {
            return View();
        }


        [HttpPost]
        public ActionResult Register()
        {
            var reqest = HttpContext.Request;
            string Name = reqest.Form["name"].ToString();   
            string Nick = reqest.Form["nick"].ToString();
            DateOnly date = DateOnly.Parse( reqest.Form["birth"].ToString());
            string Email = reqest.Form["email"].ToString();
            string Password = reqest.Form["password"].ToString();
            return Content(new Person()
            {
               name = Name,
               nickname = Nick,
               birth = date,
               email= Email,
               password = Password

            }.ToString());
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }

    public class Person
    {
        public string? name { get; set; }
        public string? email { get; set; }
        public string? nickname { get; set; }
        public DateOnly birth { get; set; }
        public string? password { private get; set; }
        public override string ToString()
        {
            return
                $"""
                 Name: {name}
                 Nickname: {nickname}
                 Brith date: {birth.ToString()}
                 Email: {email}
                 Password: {Global.md5(password ?? " ")}
                """;
        }
    }

}
