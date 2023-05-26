using DiplomaProject.OpenDotaAPI.APIModels;
using Newtonsoft.Json.Linq;

namespace DiplomaProject.OpenDotaAPI.ApiParsers.APIParserConfigurations
{
    public class MatchConfiguration : APIParserConfiguration
    {
        public MatchConfiguration(IConfiguration configuration) : base(configuration) {
            
        }

        protected override void AddDefault() {
            Dictionary<string,string>? values = _configuration.GetSection("match").GetChildren().ToDictionary(x=>x.Key, x => x.Value??"");
            AddValue(values);
        }
        public void AddPro() {
            AddValue("leagueId","leagueid");
        }
        public override IAPIModel GetModel()
        {
            return new MatchModel();
        }

    }
}
