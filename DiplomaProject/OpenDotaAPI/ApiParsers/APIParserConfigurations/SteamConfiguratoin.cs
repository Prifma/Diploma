using DiplomaProject.OpenDotaAPI.APIModels;
using System.Drawing;

namespace DiplomaProject.OpenDotaAPI.ApiParsers.APIParserConfigurations
{
    public class SteamConfiguratoin : APIParserConfiguration
    {
        public SteamConfiguratoin(IConfiguration configuration) : base(configuration)
        {
        }
        protected override void AddDefault()
        {
            Dictionary<string, string>? values = _configuration.GetSection("steam").GetChildren().ToDictionary(x => x.Key, x => x.Value??"");
            AddValue(values);
        }
        public override IAPIModel GetModel()
        {
            return new SteamAccModel();
        }
    }
}
