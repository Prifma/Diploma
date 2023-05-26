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
        private Dictionary<string,string> _apiParameters = new Dictionary<string,string>();
        private IConfiguration _configuration;
        public OpenDotaApiService(IConfiguration configuration) { 
            _configuration = configuration;
        }
        public IAPIModel GetMacth(long id)
        {
            string apiUrl = _openDotaURL + "/matches/" + id.ToString();
            OnceApiGetter apiGetter = new OnceApiGetter(apiUrl);
            apiGetter.Invoke();
            string json = apiGetter.Result;
            MatchConfiguration m = new MatchConfiguration(_configuration);
            m.AddPro();
            var parser = new APIParser(json,m);
            return parser.Parse();
        }

       

        public IAPIModel GetAccountInfo(long id) {
            string apiUrl = _openDotaURL + "/players/" + id.ToString();
            OnceApiGetter apiGetter = new OnceApiGetter(apiUrl);
            apiGetter.Invoke();
            string json = apiGetter.Result;
            AccountPartConfiguration conf = new AccountPartConfiguration(_configuration, "");
            APIParser parser = new APIParser(json, conf);
            Leaf composite = new Leaf(typeof(AccountModel).GetField("profile"), new ProfileModel(), parser);
            apiGetter = new OnceApiGetter(apiUrl+"/recentMatches");
            apiGetter.Invoke();
            json = apiGetter.Result;
            conf = new AccountPartConfiguration(_configuration, "recentMatches");
            LeafArray leafArray = new LeafArray(typeof(AccountModel).GetField("matches"), new RecentMatchModel[0], new RecentMatchParser(json, conf, -1));
            Composite composite1 = new Composite(new AccountModel());
            apiGetter = new OnceApiGetter(apiUrl + "/totals");
            apiGetter.Invoke();
            json = apiGetter.Result;
            conf = new AccountPartConfiguration(_configuration, "totals");
            LeafArray leafArray1 = new LeafArray(typeof(AccountModel).GetField("totals"), new TotalsModel[0], new TotalsParser(json, conf, -1));
            composite1.Add(composite);
            composite1.Add(leafArray);
            composite1.Add(leafArray1);
                composite1.Operation();
            return composite1.APIModel;
        }

        public IAPIModel GetMacth1(long id)
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
    }
}
