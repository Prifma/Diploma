using DiplomaProject.OpenDotaAPI.APIModels;

namespace DiplomaProject.OpenDotaAPI.ApiParsers.APIParserConfigurations
{
    public class TeamConfiguration : APIParserConfiguration
    {
        private bool _isRediant;
        public string Side => _isRediant ? "radiant" : "dire";
        public TeamConfiguration(IConfiguration configuration, bool isRediant) : base(configuration)
        {
            _isRediant = isRediant;
        }

        protected override void AddDefault() {
            Dictionary<string, string>? values = _configuration.GetSection("team").GetChildren().ToDictionary(x => x.Key, x => Side + x.Value);
            AddValue(values);
            AddPro();
        }
        public void AddPro() {
            AddValue("pro", "true");
        }
        public override IAPIModel GetModel()
        {
            return new TeamModel();
        }
    }
}
