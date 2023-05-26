using DiplomaProject.OpenDotaAPI.APIModels;
using DiplomaProject.OpenDotaAPI.ApiParsers;
using DiplomaProject.OpenDotaAPI.ApiParsers.APIParserConfigurations;
using DiplomaProject.OpenDotaAPI.Fabrics;
using DiplomaProject.OpenDotaAPI.Getters;
using DiplomaProject.OpenDotaAPI.APIComposite;

namespace DiplomaProject.Services
{
    public class OpenDotaApiService : IDotaAPIService
    {
        private const string _openDotaURL = "https://api.opendota.com/api";
        private Dictionary<string, string> _apiParameters = new Dictionary<string, string>();
        private IConfiguration _configuration;
        public OpenDotaApiService(IConfiguration configuration) {
            _configuration = configuration;
        }

        public IAPIModel GetAccountInfo(long id) {
            string apiUrl = _openDotaURL + "/players/" + id.ToString();
            OnceApiGetter apiGetter = new OnceApiGetter(apiUrl);
            apiGetter.Invoke();
            string json = apiGetter.Result;
            AccountPartConfiguration conf = new AccountPartConfiguration(_configuration, "");
            APIParser parser = new APIParser(json, conf);
            return parser.Parse();
        }

        public IAPIModel GetMacth(long id)
        {
            string apiUrl = _openDotaURL + "/matches/" + id.ToString();
            OnceApiGetter apiGetter = new OnceApiGetter(apiUrl);
            apiGetter.Invoke();
            string json = apiGetter.Result;
            APIParserFactory factory = new APIParserFactory(_configuration);
            Component f = factory.GetMatch(json);
            f.Operation();
            return f.APIModel;
        }

        public IAPIModel[] GetRecentMatch(long id)
        {
            string apiUrl = _openDotaURL + "/players/" + id.ToString() + "/recentMatches";
            var apiGetter = new OnceApiGetter(apiUrl );
            apiGetter.Invoke();
            string json = apiGetter.Result;
            var conf = new AccountPartConfiguration(_configuration, "recentMatches");
            var parser = new RecentMatchParser(json, conf, -1);
            return parser.ParseToArray();
        }

        public IAPIModel[] GetTotals(long id)
        {
            string apiUrl = _openDotaURL + "/players/" + id.ToString() + "/totals";
            var apiGetter = new OnceApiGetter(apiUrl);
            apiGetter.Invoke();
            string json = apiGetter.Result;
            var conf = new AccountPartConfiguration(_configuration, "totals");
            var parser = new TotalsParser(json, conf, -1);
            return parser.ParseToArray();
        }
    }
}
