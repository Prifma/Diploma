using DiplomaProject.OpenDotaAPI.APIModels;
using DiplomaProject.OpenDotaAPI.ApiParsers;
using DiplomaProject.OpenDotaAPI.ApiParsers.APIParserConfigurations;
using DiplomaProject.OpenDotaAPI.Fabrics;
using DiplomaProject.OpenDotaAPI.Getters;
using DiplomaProject.OpenDotaAPI.APIComposite;
using DiplomaProject.OpenDotaAPI.PostProcces;
using DiplomaProject.DataBase;

namespace DiplomaProject.Services
{
    public class OpenDotaApiService : IDotaAPIService
    {
        private const string _openDotaURL = "https://api.opendota.com/api";
        private Dictionary<string, string> _apiParameters = new Dictionary<string, string>();
        private IConfiguration _configuration;
        private ApplicationContext _context;
        public OpenDotaApiService(IConfiguration configuration, ApplicationContext context) {
            _configuration = configuration;
            _context = context;
        }

        public IAPIModel GetAccountInfo(long id) {
            string apiUrl = _openDotaURL + "/players/" + id.ToString();
            OnceApiGetter apiGetter = new OnceApiGetter(apiUrl);
            apiGetter.Invoke();
            string json = apiGetter.Result;
            AccountPartConfiguration conf = new AccountPartConfiguration(_configuration, "");
            APIParser parser = new APIParser(json, conf);
            ProfileModel profile = (ProfileModel)parser.Parse();
            string rank = $"ranks:{profile.rankTier}";
            profile.rankTier = $"src/assets/{profile.rankTier}.webp";
            return profile;
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
            MatchPost post = new MatchPost();
            post.SetNormalDuration((MatchModel)f.APIModel);
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

        public SteamAccModel GetSteamAcc(string id)
        {
            string url = "http://api.steampowered.com/ISteamUser/GetPlayerSummaries/v0002/?key=94C8CF8E8735EE208B3E8FB0567B422F&steamids=" + id;
            OnceApiGetter onceApiGetter = new OnceApiGetter(url);
            onceApiGetter.Invoke();
            var result = onceApiGetter.Result;
            SteamConfiguratoin conf = new SteamConfiguratoin(_configuration);
            APIParser parser = new APIParser(result, conf);
            var item = (SteamAccModel)parser.Parse();
            
                var user = _context.Users.Where(u => u.Id == item.id).FirstOrDefault();
                if (user is null)
                    item.userType = DataBase.Enities.UserType.Common;
                else item.userType = user.UserType;
            
            return item;
        }

        public IAPIModel[] GetTotals(long id)
        {
            string apiUrl = _openDotaURL + "/players/" + id.ToString() + "/totals";
            var apiGetter = new OnceApiGetter(apiUrl);
            apiGetter.Invoke();
            string json = apiGetter.Result;
            var conf = new AccountPartConfiguration(_configuration, "totals");
            var parser = new TotalsParser(json, conf, -1);
            TotalsModel[] totals = (TotalsModel[])parser.ParseToArray();
            TotalsPost post = new TotalsPost();
            totals = post.ChangeToNormal(totals);
            return totals;
        }
    }
}
