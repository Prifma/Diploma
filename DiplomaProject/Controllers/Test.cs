using DiplomaProject.OpenDotaAPI.APIModels;
using DiplomaProject.Services;
using Microsoft.AspNetCore.Mvc;

namespace DiplomaProject.Controllers
{
    [ApiController]
    [Route("/")]
    public class Test : ControllerBase
    {
        [HttpGet]
        [Route("images")]
        public IAPIModel GetModel(IDotaAPIService c)
        {
            MatchModel ci = (MatchModel)c.GetMacth(7155583756);
            Console.WriteLine(ci.heroes[0].heroId);
            return ci;
        }
    }
}
