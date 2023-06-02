using DiplomaProject.OpenDotaAPI.Getters;
using Microsoft.AspNetCore.Mvc;

namespace DiplomaProject.Controllers
{
    public class HomeController : Controller
    {
        [Route("/")]
        public IActionResult Index()
        {
            return View();
        }

        [Route("/test")]
        public void Test() {
            var c = HttpContext;
            var u = c.User;
            foreach (var item in c.User.Claims)
            {
                string h = item.Value.Replace("https://steamcommunity.com/openid/id/", "");
                string url = "http://api.steampowered.com/ISteamUser/GetPlayerSummaries/v0002/?key=94C8CF8E8735EE208B3E8FB0567B422F&steamids=" + h;
                Console.WriteLine(url);
                OnceApiGetter a = new OnceApiGetter(url);
                a.Invoke();
                Console.WriteLine(a.Result);
            }
        }
        [HttpGet]
        [Route("/auth/loaduser")]
        public object LoadUser()
        {
            if (User?.Identity?.IsAuthenticated ?? false){
                var s = HttpContext.User.Claims.First().Value;
                var result = new { m = s.Replace("https://steamcommunity.com/openid/id/", ""), redirect = "/" };
                return result;
            }
            else return new
            {
                m = "",
                redirect = "/"
            };
        }
    }
}
