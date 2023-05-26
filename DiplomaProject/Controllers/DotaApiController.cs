using DiplomaProject.OpenDotaAPI.APIModels;
using DiplomaProject.Services;
using Microsoft.AspNetCore.Mvc;

namespace DiplomaProject.Controllers
{
    [ApiController]
    [Route("api")]
    public class DotaApiController : ControllerBase
    {
        private IDotaAPIService _dotaAPI;
        public DotaApiController(IDotaAPIService dotaAPI) {
            _dotaAPI = dotaAPI;
        }
        [HttpGet]
        [Route("match")]
        public IAPIModel GetMatch(long id) {
            if (id == 0) {
                
            }
            var model = _dotaAPI.GetMacth(id);
            return model;
        }
        [HttpGet]
        [Route("account")]
        public IAPIModel GetAccount(long id)
        {
            var model = _dotaAPI.GetAccountInfo(id);
            return model;
        }
        [HttpGet]
        [Route("rMatches")]
        public IAPIModel[] GetRecentMatches(long id)
        {
            var model = _dotaAPI.GetRecentMatch(id);
            return model;
        }
        [HttpGet]
        [Route("totals")]
        public IAPIModel[] GetTotals(long id)
        {
            var model = _dotaAPI.GetTotals(id);
            return model;
        }


    }
}
