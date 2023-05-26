using DiplomaProject.OpenDotaAPI.APIModels;

namespace DiplomaProject.OpenDotaAPI.ApiParsers.APIParserConfigurations
{
    public class AccountPartConfiguration : APIParserConfiguration
    {
        private string _section;
        public string Section { get { return _section; } }
        public AccountPartConfiguration(IConfiguration configuration,string section) : base(configuration)
        {
            _section = section;
            Dictionary<string, string>? values = _configuration.GetSection("account:" + _section).
                                                                GetChildren().ToDictionary(x => x.Key, x => x.Value??"");
            AddValue(values);
        }
        protected override void AddDefault()
        {
        }
        public override IAPIModel GetModel()
        {
            if (_section == "recentMatches")
            {
                return new RecentMatchModel();
            }
            else if (_section == "totals")
            {
                return new TotalsModel();
            }
            else
                return new ProfileModel();
        }

    }
}
