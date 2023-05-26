using DiplomaProject.OpenDotaAPI.APIModels;

namespace DiplomaProject.OpenDotaAPI.ApiParsers.APIParserConfigurations
{
    public class ProInfoConfiguration : APIParserConfiguration
    {
        private string _side;
        public ProInfoConfiguration(IConfiguration configuration,string side) : base(configuration)
        {
            _side = side + "_team.";
            Dictionary<string, string>? values = _configuration.GetSection("pro").GetChildren().ToDictionary(x => x.Key, x => _side + x.Value);
            AddValue(values);
        }
        protected override void AddDefault()
        {
            
        }
        public override IAPIModel GetModel()
        {
            return new ProInfoModel();
        }
    }
}
